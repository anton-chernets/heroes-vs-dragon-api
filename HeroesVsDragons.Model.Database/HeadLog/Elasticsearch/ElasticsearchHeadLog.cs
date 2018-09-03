using System;
using System.Collections.Generic;
using System.Linq;
using Serilog;
using HeroesVsDragons.Model.CustomExceptions;

namespace HeroesVsDragons.Model.Database.HeadLog.Elasticsearch
{
    /// <summary>
    /// Elasticsearch head log.
    /// </summary>
    public sealed class ElasticsearchHeadLog : IHeadLog
    {
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:YoiPos.Model.Database.HeadLog.Elasticsearch.ElasticsearchHeadLog"/> class.
        /// </summary>
        /// <param name="logger">Logger.</param>
        public ElasticsearchHeadLog(ILogger logger)
        {
            _logger = logger;
        }

        #region -- IHeadLog implementation --

        /// <summary>
        /// Logs the error.
        /// </summary>
        /// <param name="ex">Ex.</param>
        /// <param name="propertyDictionary">Property dictionary.</param>
        public void LogError(Exception ex, string message, IDictionary<string, string> propertyDictionary = null)
        {
            message = message ?? "No error message";

            Log(ElasticSearchLogLevel.Error, message, propertyDictionary, ex ?? new Exception(message));
        }

        /// <summary>
        /// Logs the error.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="propertyDictionary">Property dictionary.</param>
        public void LogError(string message, IDictionary<string, string> propertyDictionary = null)
        {
            message = message ?? "No error message";

            Log(ElasticSearchLogLevel.Error, message, propertyDictionary, new Exception(message));
        }

        /// <summary>
        /// Logs the info.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="propertyDictionary">Property dictionary.</param>
        public void LogInfo(string message, IDictionary<string, string> propertyDictionary = null)
            => Log(ElasticSearchLogLevel.Info, message ?? "No info message", propertyDictionary, null);
        

        /// <summary>
        /// Logs the verbose.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="propertyDictionary">Property dictionary.</param>
        public void LogVerbose(string message, IDictionary<string, string> propertyDictionary = null) 
            => throw new NotImplementedException();

        /// <summary>
        /// Logs the warning.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="propertyDictionary">Property dictionary.</param>
        public void LogWarning(string message, IDictionary<string, string> propertyDictionary = null)
            => Log(ElasticSearchLogLevel.Warning, message ?? "No warning message", propertyDictionary, null);
        

        #endregion

        #region -- Private helpers --

        /// <summary>
        /// Log the specified logLevel, message, propertyDictionary and ex.
        /// </summary>
        /// <returns>The log.</returns>
        /// <param name="logLevel">Log level.</param>
        /// <param name="message">Message.</param>
        /// <param name="propertyDictionary">Property dictionary.</param>
        /// <param name="ex">Ex.</param>
        private void Log(ElasticSearchLogLevel logLevel, string message, IDictionary<string, string> propertyDictionary, Exception ex)
        {
            message = $"Message: '{message}'";

            IEnumerable<string> properties = propertyDictionary?.Select(x => $"(\"{x.Key}\" : \"{x.Value})\"") ?? Enumerable.Empty<string>();

            if(properties.Any()) 
                message += $"Properties: '{string.Join(", ", properties)}'";
                
            switch (logLevel)
            {
                case ElasticSearchLogLevel.Info:    _logger.Information(message); break;
                case ElasticSearchLogLevel.Warning: _logger.Warning(message); break;
                case ElasticSearchLogLevel.Verbose: _logger.Verbose(message); break;
                case ElasticSearchLogLevel.Error:   _logger.Error(ex, message); break;
                default: throw new SwitchMissingCaseException();
            }
        }

        #endregion
    }
}
