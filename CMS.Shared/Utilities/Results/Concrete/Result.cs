using CMS.Shared.Utilities.Results.Abstract;
using CMS.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Shared.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        public ResultStatus Status { get; }

        public string Message { get; }

        public Exception Exception { get; }

        public Result(ResultStatus status,string message = null, Exception exception = null) {
            Status = status;
            Message = message;
            Exception = exception;
        }
    }
}
