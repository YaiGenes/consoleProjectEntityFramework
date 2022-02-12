using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entityFrameworkTest.Services.Handlers
{
    public class Handle<T> : IHandler<T> where T : class
    {
        private readonly Func<T, bool> _canHandle;
        private readonly Action<T> _process;
        private readonly IHandler<T> _next;

        public Handle(Func<T, bool> canHandle, Action<T> process, IHandler<T> next = null)
        {
            _canHandle = canHandle;
            _process = process;
            _next = next;
        }

        protected bool CanHandle(T entity)
        {
            return _canHandle(entity);
        }

        public void Handle(T entity)
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
