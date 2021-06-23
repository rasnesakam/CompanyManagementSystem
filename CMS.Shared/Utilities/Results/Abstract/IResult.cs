
using CMS.Shared.Utilities.Results.ComplexTypes;

namespace CMS.Shared.Utilities.Results.Abstract
{
    public interface IResult
    {
        public ResultStatus Status { get; }
        public string Message { get; }
        public System.Exception Exception { get; }

    }
}
