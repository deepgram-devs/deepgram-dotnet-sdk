﻿using System.Collections.Concurrent;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Deepgram.Logger
{
    public interface ILogProvider
    {
    }
    public class LogProvider : ILogProvider
    {
        private static IDictionary<string, ILogger> _loggers = new ConcurrentDictionary<string, ILogger>();
        private static ILoggerFactory _loggerFactory = new LoggerFactory();

        public static void SetLogFactory(ILoggerFactory factory)
        {
            _loggerFactory?.Dispose();
            _loggerFactory = factory;
            _loggers.Clear();
        }

        public static ILogger GetLogger(string category)
        {
            if (!_loggers.ContainsKey(category))
            {
                _loggers[category] = _loggerFactory?.CreateLogger(category) ?? NullLogger.Instance;
            }
            return _loggers[category];
        }
    }
}
