using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using HeroesVsDragons.Model.Attributes;
using HeroesVsDragons.Model.Database.HeadLog;
using Microsoft.EntityFrameworkCore;

namespace HeroesVsDragons.Model.Database.Services
{

    /// <summary>
    /// Base service.
    /// </summary>
    public abstract class BaseService
    {
        protected const string ModelIsNotValidErrorMessage = "Model Is Not Valid.";
        private const string MethodInvokedWithError = "Method " + nameof(CheckRequest) + "invoked with error.";

        private const string EntityNotFoundFormat = "'{0}' Not Found.";
        private const string EntityAlreadyExistsFormat = "'{0}' Already Exists.";
        private const string SomeEntitiesNotExistFormat = "Next entities: '{0}' Are Not Exists.";

        protected readonly IHeadLog _headlog;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:YoiPos.Model.Database.Services.BaseService"/> class.
        /// </summary>
        /// <param name="headLog">Head log.</param>
        protected BaseService(IHeadLog headLog)
        {
            _headlog = headLog;
        }

        /// <summary>
        /// Bases the invoke.
        /// </summary>
        /// <returns>The invoke.</returns>
        /// <param name="action">Action.</param>
        /// <param name="callerName">Caller name.</param>
        /// <param name="callerFile">Caller file.</param>
        /// <param name="callerLineNumber">Caller line number.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        protected AOResult<T> BaseInvoke<T>(Action<AOResult<T>> action, object request = null, [CallerMemberName]string callerName = null, [CallerFilePath]string callerFile = null, [CallerLineNumber]int callerLineNumber = 0)
        {
            AOResult<T> aoResult = new AOResult<T>(callerName, callerFile, callerLineNumber);
            try
            {
                List<ValidationResult> checkModelAOResult = CheckRequest(request);

                if (checkModelAOResult.Any())
                {
                    aoResult.SetError(ModelIsNotValidErrorMessage, checkModelAOResult.Select(x => new Error { Key = x.MemberNames.FirstOrDefault(), Message = x.ErrorMessage }));
                }
                else
                {
                    action(aoResult);
                }
            }
            catch (DbUpdateException dbException)
            {
                aoResult.SetError(dbException.InnerException.Message, ex: dbException);
            }
            catch (Exception ex)
            {
                aoResult.SetError(ex.Message, ex: ex);
            }
            return aoResult;
        }

        /// <summary>
        /// Bases the invoke async.
        /// </summary>
        /// <returns>The invoke async.</returns>
        /// <param name="func">Func.</param>
        /// <param name="callerName">Caller name.</param>
        /// <param name="callerFile">Caller file.</param>
        /// <param name="callerLineNumber">Caller line number.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        protected async Task<AOResult<T>> BaseInvokeAsync<T>(Func<AOResult<T>, Task> func, object request = null, [CallerMemberName]string callerName = null, [CallerFilePath]string callerFile = null, [CallerLineNumber]int callerLineNumber = 0)
        {
            AOResult<T> aoResult = new AOResult<T>(callerName, callerFile, callerLineNumber);
            try
            {
                List<ValidationResult> checkModelAOResult = CheckRequest(request);

                if (checkModelAOResult.Any())
                {
                    aoResult.SetError(ModelIsNotValidErrorMessage, checkModelAOResult.Select(x => new Error { Key = x.MemberNames.FirstOrDefault(), Message = x.ErrorMessage }));
                }
                else
                {
                    await func(aoResult);
                }
            }
            catch (DbUpdateException dbException)
            {
                aoResult.SetError(dbException.InnerException.Message, ex: dbException);
            }
            catch (Exception ex)
            {
                aoResult.SetError(ex.Message, ex: ex);
            }
            return aoResult;
        }

        /// <summary>
        /// Cants the be null or empty error.
        /// </summary>
        /// <returns>The be null or empty error.</returns>
        /// <param name="name">Name.</param>
        protected string IsRequiredError(string name) => $"Property '{name}' is required.";

        /// <summary>
        /// Gets the name of the service.
        /// </summary>
        /// <returns>The service name.</returns>
        /// <param name="serviceName">Service name.</param>
        protected static string RemoveServicePostfix(string serviceName)
        => serviceName.EndsWith("Service", StringComparison.Ordinal) ? serviceName.Replace("Service", string.Empty) : serviceName;

        /// <summary>
        /// Entities the not found.
        /// </summary>
        /// <returns>The not found.</returns>
        /// <param name="entityName">Entity name.</param>
        protected string EntityNotFound(object entityName)
        {
            if (entityName == null)
            {
                throw new ArgumentNullException(nameof(entityName));
            }
            else
            {
                return string.Format(EntityNotFoundFormat, entityName);
            }
        }

        protected string EntityAlreadyExists(object entityName)
        {
            if (entityName == null)
            {
                throw new ArgumentNullException(nameof(entityName));
            }
            else
            {
                return string.Format(EntityAlreadyExistsFormat, entityName);
            }
        }

        protected string EntitiesNotExist<T>(IEnumerable<T> enties)
        {
            if (enties == null)
            {
                throw new ArgumentNullException(nameof(enties));
            }
            else
            {
                //return string.Format(SomeEntitiesNotExistFormat, enties.Select(x => x?.ToString()).Where(x => x != null).JoinStr());
                return "some string";
            }
        }

        #region -- Private helper --

        private List<ValidationResult> CheckRequest(object request)
        {
            request = request ?? new { };

            var validationResultList = new List<ValidationResult>();
            Validator.TryValidateObject(request, new ValidationContext(request), validationResultList, true);

            return SelectMany(validationResultList);
        }

        private List<ValidationResult> SelectMany(IEnumerable<ValidationResult> validationResultList)
        {
            var list = new List<ValidationResult>();

            list.AddRange(validationResultList.Select(x =>
            {
                if (x is CompositeValidationResult cvr)
                {
                    list.AddRange(SelectMany(cvr.Results));
                }
                return x;
            }));

            return list;
        }

        #endregion
    }
}
