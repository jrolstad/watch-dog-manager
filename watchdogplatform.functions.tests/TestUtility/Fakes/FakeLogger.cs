using System;
using Microsoft.Extensions.Logging;

namespace watchdogplatform.functions.tests.TestUtility.Fakes
{
    public class FakeLogger:ILogger
    {
        private readonly TestContext _context;

        public FakeLogger(TestContext context)
        {
            _context = context;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return new DisposableObject();
        }
    }

    public class DisposableObject : IDisposable
    {
        public void Dispose()
        {
        }
    }
}