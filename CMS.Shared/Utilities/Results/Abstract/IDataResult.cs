
using CMS.Shared.Entities.Abstract;

namespace CMS.Shared.Utilities.Results.Abstract
{
    public interface IDataResult<out D>: IResult
    {
        public D Data { get; }
    }
}
