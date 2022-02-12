using System;


namespace entityFrameworkTest.Domain
{
    public class ErrorObject
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public Exception Exception { get; set; }
    }
}
