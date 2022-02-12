using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entityFrameworkTest.Domain
{
    public class SynthesisResult
    {
        public List<ErrorObject> Errors { get; set; } = new List<ErrorObject>();
        public bool HasError()=> Errors.Count > 0;
        public SynthesisResult() { }
        public SynthesisResult(Exception exception)
        {
            AddError(exception);
        }

        public SynthesisResult(int code, string message, Exception exception = null)
        {
            AddError(code, message, exception);
        }


        public void AddError(int code, string message, Exception exception = null)
        {
            Errors.Add(new ErrorObject { Code = code, Message = message, Exception = exception });
        }
        public void AddError(Exception exception)
        {
             if(exception == null) throw new ArgumentNullException("exception");
             Errors.Add(new ErrorObject { Exception = exception, Message = exception.Message });
        }
    }

    public class SynthesisResult<T> : SynthesisResult
    {
        public T Result { get; set; }
        public SynthesisResult() { }
        public SynthesisResult(T result) => Result = result;
        public SynthesisResult(Exception exception) : base(exception) { }
        public SynthesisResult(int code, string message, Exception exception = null) : base(code, message, exception) { }
        public void SetResult(T result) => Result = result;

    }
}
