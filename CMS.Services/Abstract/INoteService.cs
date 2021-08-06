using CMS.Entities.Dtos;
using CMS.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Services.Abstract
{
    public interface INoteService
    {
        Task<IDataResult<NoteDto>> Get(int noteId);
        Task<IDataResult<NoteListDto>> GetAll();
        Task<IDataResult<NoteListDto>> GetAllByNonDeleted();
        Task<IDataResult<NoteListDto>> GetAllByDeleted();
        Task<IDataResult<NoteListDto>> GetAllByActiveAndNonDeleted();

        Task<IDataResult<NoteDto>> Add(NoteAddDto noteAddDto, string userName);
        Task<IDataResult<NoteDto>> Update(NoteUpdateDto noteUpdateDto, string userName);

        Task<IResult> Delete(int noteId, string userName);
        Task<IResult> HardDelete(int noteId);
    }
}
