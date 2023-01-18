using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CovoitEco.Core.Infrastructure.Loggers
{
    public class CustomLoggerProvider : ILoggerProvider
    {
        #region Feilds

        private ConcurrentDictionary<string, CustomMessageLogger> _loggers = new ConcurrentDictionary<string, CustomMessageLogger>();

        #endregion

        #region Methods

        public void Dispose()
        {
            this._loggers.Clear();
        }

        public ILogger CreateLogger(string categoryName)
        {
            this._loggers.GetOrAdd(categoryName, KeyNotFoundException => new CustomMessageLogger());
            return this._loggers[categoryName];
        }

        #endregion
    }
}
