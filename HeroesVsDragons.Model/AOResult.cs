using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using HeroesVsDragons.Model.CustomExceptions;
using System.Diagnostics;
using HeroesVsDragons.Model;

namespace HeroesVsDragons.Model
{
    /// <summary>
    /// Base async operation result.
    /// Thiss class calculates how it log
    /// from start async operation (create instance) to finish asyncOperation (SetResult)
    /// </summary>
    public class AOResult<T>
    {
        private bool _isResultSet;
        private readonly DateTime _creationUtcTime;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:XCoin.Responses.AOResult`1"/> class.
        /// </summary>
        /// <param name="callerName">Caller name.</param>
        /// <param name="callerFile">Caller file.</param>
        /// <param name="callerLineNumber">Caller line number.</param>
        public AOResult([CallerMemberName]string callerName = null, [CallerFilePath]string callerFile = null, [CallerLineNumber]int callerLineNumber = 0)
        {
            ResultSet(false);
            _creationUtcTime = DateTime.UtcNow;
            CallerName = callerName;
            CallerFile = callerFile;
            CallerLineNumber = callerLineNumber;
        }

        #region -- Public properties --

        /// <summary>
        /// Gets the operation time.
        /// </summary>
        /// <value>The operation time.</value>
        public TimeSpan OperationTime { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:YoiPos.Model.Outputs.AOResult`1"/> is success.
        /// </summary>
        /// <value><c>true</c> if is success; otherwise, <c>false</c>.</value>
        public bool IsSuccess { get; private set; }

        /// <summary>
        /// Gets the exception.
        /// </summary>
        /// <value>The exception.</value>
        public Exception Exception { get; private set; }

        /// <summary>
        /// Gets the error identifier.
        /// </summary>
        /// <value>The error identifier.</value>
        public string ErrorId { get; private set; }

        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; private set; }

        /// <summary>
        /// Gets the code.
        /// </summary>
        /// <value>The code.</value>
        public Code Code { get; private set; }

        /// <summary>
        /// Gets the name of the caller.
        /// </summary>
        /// <value>The name of the caller.</value>
        public string CallerName { get; private set; }

        /// <summary>
        /// Gets the caller file.
        /// </summary>
        /// <value>The caller file.</value>
        public string CallerFile { get; private set; }

        /// <summary>
        /// Gets the caller line number.
        /// </summary>
        /// <value>The caller line number.</value>
        public int CallerLineNumber { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:YoiPos.Model.Outputs.AOResult`1"/> tracking result.
        /// </summary>
        /// <value><c>true</c> if tracking result; otherwise, <c>false</c>.</value>
        public bool TrackingResult { get; set; } = true;

        /// <summary>
        /// Gets or sets the errors.
        /// </summary>
        /// <value>The errors.</value>
        public IEnumerable<Error> Errors { get; set; }

        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <value>The result.</value>
        public T Result { get; private set; }
        #endregion

        #region -- Public methods --

        /// <summary>
        /// Sets the success.
        /// </summary>
        public void SetSuccess()
        {
            CheckResult();

            SetResult(true, Code.Ok, default(T), null, null, null);
        }

        /// <summary>
        /// Sets the success.
        /// </summary>
        /// <param name="result">Result.</param>
        public void SetSuccess(T result)
        {
            CheckResult();

            SetResult(true, Code.Ok, result, null, null, null);
        }

        /// <summary>
        /// Sets the error.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="ex">Ex.</param>
        public void SetError(string message, Code code = Code.Error, Exception ex = null)
        {
            CheckResult();

            SetResult(false, code, default(T), message, null, ex);
        }

        /// <summary>
        /// Sets the error.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="erorrs">Erorrs.</param>
        /// <param name="ex">Ex.</param>
        public void SetError(string message, IEnumerable<Error> erorrs, Code code = Code.Error, Exception ex = null)
        {
            CheckResult();

            SetResult(false, code, default(T), message, erorrs, ex);
        }

        #endregion

        #region -- Private helpers --

        private void CheckResult()
        {
            if (_isResultSet)
            {             
                throw new ResultAlreadySetAOResultException();
			} else 
            {
                //just exits
            }
        }

        private void ResultSet(bool isResultSet)
        {
            _isResultSet = isResultSet;
        }

        private void SetResult(bool isSuccess, Code code, T result, string message, IEnumerable<Error> erorrs, Exception ex)
        {
            var finishTime = DateTime.UtcNow;
            OperationTime = finishTime - _creationUtcTime;
            IsSuccess = isSuccess;
            Exception = ex;
            Errors = erorrs;
            Result = result;
            Code = code;
            Message = message;
            if (TrackingResult)
            {
				TrackResult();              
            } else 
            {
                //do not track result    
            }

#if DEBUG
            Debug.WriteLine($@"
****** AO Result ******
Method = {CallerName}
Time = {OperationTime}
");
#endif

            ResultSet(true);
        }

        #endregion

        #region -- Protected helpers --

        /// <summary>
        /// Tracks the result.
        /// </summary>
        protected virtual void TrackResult()
        {
            if (!IsSuccess)
            {
                IAOResultLogger aoResultLogger = AOResultLoggerProvider.GetAOResultLogger() ?? throw new LoggerNotInitAOResultException();

                aoResultLogger.LogAOResult(this);                    
            } 
            else
            {
                //do not track if success    
            }
        }

        #endregion
    }

}