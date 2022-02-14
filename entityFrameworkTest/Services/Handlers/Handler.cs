using System;

namespace entityFrameworkTest.Services.Handlers
{
    public class Handler<T> : IHandler<T> where T : class
    {
        private readonly Func<T, bool> _canHandle;
        private readonly Action<T> _process;
        private readonly IHandler<T> _next;

        public Handler(Func<T, bool> canHandle, Action<T> process, IHandler<T> next = null)
        {
            _canHandle = canHandle;
            _process = process;
            _next = next;
        }

        protected bool CanHandle(T entity)
        {
            return _canHandle(entity);
        }

        void IHandler<T>.Handle(T entity)
        {
            if(CanHandle(entity))
            {
                _process(entity);
            }
            else
            {
                _next?.Handle(entity);
            }
        }
    }
}
