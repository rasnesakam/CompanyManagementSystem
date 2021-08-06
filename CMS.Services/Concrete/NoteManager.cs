using AutoMapper;
using CMS.Data.Abstract;
using CMS.Entities.Concrete;
using CMS.Entities.Dtos;
using CMS.Services.Abstract;
using CMS.Shared.Utilities.Results.Abstract;
using CMS.Shared.Utilities.Results.ComplexTypes;
using CMS.Shared.Utilities.Results.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Services.Concrete
{
    public class NoteManager : INoteService
    {

        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public NoteManager(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<NoteDto>> Add(NoteAddDto noteAddDto, string userName)
        {
            var note = _mapper.Map<Note>(noteAddDto);
            note.CreatedByName = userName;
            note.ModifiedByName = userName;
            note.CreateDate = DateTime.Now;
            note.ModifiedDate = DateTime.Now;
            var newNote = await _unitOfWork.Notes.AddAsync(note);
            await _unitOfWork.SaveAsync();
            return new DataResult<NoteDto>(ResultStatus.Success, new NoteDto
            {
                Note = newNote,
                ResultStatus = ResultStatus.Success,
                Message = "Yeni posta adresi başarıyla eklendi"
            });
        }

        public async Task<IResult> Delete(int noteId, string userName)
        {
            var note = await _unitOfWork.Notes.GetAsync(m => m.Id == noteId);
            if (note != null)
            {
                note.ModifiedByName = userName;
                note.ModifiedDate = DateTime.Now;
                note.IsDeleted = true;
                await _unitOfWork.Notes.UpdateAsync(note);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, "Not bilgisi silindi. İşlemi geri almak için çöp kutusuna göz atın");
            }
            return new Result(ResultStatus.Error, "Not bilgisi silinirken bir hata oluştu");
        }

        public async Task<IDataResult<NoteDto>> Get(int noteId)
        {
            var note = await _unitOfWork.Notes.GetAsync(n => n.Id == noteId);
            if (note != null) return new DataResult<NoteDto>(ResultStatus.Success, new NoteDto
            {
                Note = note,
                ResultStatus = ResultStatus.Success
            });
            return new DataResult<NoteDto>(ResultStatus.Error, message: "Aranan not bilgisi bulunamadı", data: new NoteDto
            {
                Note = null,
                ResultStatus = ResultStatus.Error,
                Message = "Aranan not bilgisi bulunamadı"
            });
        }

        public async Task<IDataResult<NoteListDto>> GetAll()
        {
            var notes = await _unitOfWork.Notes.GetAllAsync(null, n => n.User, n => n.Parent);
            if (notes.Count > -1) return new DataResult<NoteListDto>(ResultStatus.Success, new NoteListDto
            {
                Notes = notes,
                ResultStatus = ResultStatus.Success
            });
            return new DataResult<NoteListDto>(ResultStatus.Error, message: "Aranan not bilgisi bulunamadı", data: new NoteListDto
            {
                Notes = null,
                ResultStatus = ResultStatus.Error,
                Message = "Aranan not bilgisi bulunamadı"
            });
        }

        public async Task<IDataResult<NoteListDto>> GetAllByActiveAndNonDeleted()
        {
            var notes = await _unitOfWork.Notes.GetAllAsync(n=> !n.IsDeleted && n.IsActive, n => n.User, n => n.Parent);
            if (notes.Count > -1) return new DataResult<NoteListDto>(ResultStatus.Success, new NoteListDto
            {
                Notes = notes,
                ResultStatus = ResultStatus.Success
            });
            return new DataResult<NoteListDto>(ResultStatus.Error, message: "Aranan not bilgisi bulunamadı", data: new NoteListDto
            {
                Notes = null,
                ResultStatus = ResultStatus.Error,
                Message = "Aranan not bilgisi bulunamadı"
            });
        }

        public async Task<IDataResult<NoteListDto>> GetAllByDeleted()
        {
            var notes = await _unitOfWork.Notes.GetAllAsync(n => n.IsDeleted, n => n.User, n => n.Parent);
            if (notes.Count > -1) return new DataResult<NoteListDto>(ResultStatus.Success, new NoteListDto
            {
                Notes = notes,
                ResultStatus = ResultStatus.Success
            });
            return new DataResult<NoteListDto>(ResultStatus.Error, message: "Aranan not bilgisi bulunamadı", data: new NoteListDto
            {
                Notes = null,
                ResultStatus = ResultStatus.Error,
                Message = "Aranan not bilgisi bulunamadı"
            });
        }

        public async Task<IDataResult<NoteListDto>> GetAllByNonDeleted()
        {
            var notes = await _unitOfWork.Notes.GetAllAsync(n => !n.IsDeleted, n => n.User, n => n.Parent);
            if (notes.Count > -1) return new DataResult<NoteListDto>(ResultStatus.Success, new NoteListDto
            {
                Notes = notes,
                ResultStatus = ResultStatus.Success
            });
            return new DataResult<NoteListDto>(ResultStatus.Error, message: "Aranan not bilgisi bulunamadı", data: new NoteListDto
            {
                Notes = null,
                ResultStatus = ResultStatus.Error,
                Message = "Aranan not bilgisi bulunamadı"
            });
        }

        public async Task<IResult> HardDelete(int noteId)
        {
            var note = await _unitOfWork.Notes.GetAsync(m => m.Id == noteId);
            if (note != null)
            {
                await _unitOfWork.Notes.DeleteAsync(note);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, "Not bilgisi kalıcı olarak silindi");
            }
            return new Result(ResultStatus.Error, "Not bilgisi silinirken hata oluştu");
        }

        public async Task<IDataResult<NoteDto>> Update(NoteUpdateDto noteUpdateDto, string userName)
        {
            var note = _mapper.Map<Note>(noteUpdateDto);
            note.ModifiedByName = userName;
            note.ModifiedDate = DateTime.Now;

            var newNote = await _unitOfWork.Notes.UpdateAsync(note);
            await _unitOfWork.SaveAsync();
            return new DataResult<NoteDto>(ResultStatus.Success, message: "E posta başarıyla güncellendi", data: new NoteDto
            {
                Note = newNote,
                ResultStatus = ResultStatus.Success,
                Message = "E posta başarıyla güncellendi"
            });
        }
    }
}
