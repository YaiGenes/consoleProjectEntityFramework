using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entityFrameworkTest.Services.Handlers
{
    public interface IHandler<T> where T : class
    {
        void Handle(T entity);
    }
}
