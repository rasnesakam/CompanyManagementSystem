using CMS.Shared.Utilities.Results.Abstract;
using CMS.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Shared.Utilities.Results.Concrete
{
    public class DataResult<D> :Result, IDataResult<D>
    {
        public D Data { get; }

        public DataResult(ResultStatus status, D data, string message = null, Exception exception = null)
        :base(status,message,exception)
        {
            Data = data;
        }
        public DataResult(ResultStatus status, string message = null, Exception exception = null)
        : base(status, message, exception)
        {
        }
    }
}
