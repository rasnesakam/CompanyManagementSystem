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
    public class MailManager : IMailService
    {

        private IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public MailManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IDataResult<MailDto>> Add(MailAddDto mailAddDto, string userName)
        {
            var mail = _mapper.Map<Mail>(mailAddDto);
            mail.CreatedByName = userName;
            mail.ModifiedByName = userName;
            mail.CreateDate = DateTime.Now;
            mail.ModifiedDate = DateTime.Now;
            var newMail = await _unitOfWork.Mails.AddAsync(mail);
            await _unitOfWork.SaveAsync();
            return new DataResult<MailDto>(ResultStatus.Success, new MailDto
            {
                Mail = newMail,
                ResultStatus = ResultStatus.Success,
                Message = "Yeni posta adresi başarıyla eklendi"
            });
        }

        public async Task<IResult> Delete(int mailId, string userName)
        {
            var mail = await _unitOfWork.Mails.GetAsync(m => m.Id == mailId);
            if (mail != null)
            {
                mail.ModifiedByName = userName;
                mail.ModifiedDate = DateTime.Now;
                mail.IsDeleted = true;
                await _unitOfWork.Mails.UpdateAsync(mail);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, "E posta silindi. İşlemi geri almak için çöp kutusuna göz atın");
            }
            return new Result(ResultStatus.Error, "E posta adresi silinirken bir hata oluştu");
        }

        public async Task<IDataResult<MailDto>> Get(int mailId)
        {
            var mail = await _unitOfWork.Mails.GetAsync(m => m.Id == mailId);
            if (mail != null) return new DataResult<MailDto>(ResultStatus.Success,new MailDto
            {
                Mail = mail,
                ResultStatus = ResultStatus.Success
            });
            return new DataResult<MailDto>(ResultStatus.Error,message:"Aranan e posta adresi bulunamadı",data:new MailDto
            {
                Mail = null,
                ResultStatus = ResultStatus.Error,
                Message = "Aranan e posta adresi bulunamadı"
            });
        }

        public async Task<IDataResult<MailListDto>> GetAll()
        {
            var mails = await _unitOfWork.Mails.GetAllAsync(null);
            if (mails.Count > -1) return new DataResult<MailListDto>(ResultStatus.Success, new MailListDto
            {
                Mails = mails,
                ResultStatus = ResultStatus.Success
            });
            return new DataResult<MailListDto>(ResultStatus.Error, message: "Aranan e posta adresi bulunamadı", data: new MailListDto
            {
                Mails = null,
                ResultStatus = ResultStatus.Error,
                Message = "Aranan e posta adresi bulunamadı"
            });
        }

        public async Task<IDataResult<MailListDto>> GetAllByActiveAndNonDeleted()
        {
            var mails = await _unitOfWork.Mails.GetAllAsync(m => m.IsActive && !m.IsDeleted);
            if (mails.Count > -1) return new DataResult<MailListDto>(ResultStatus.Success, new MailListDto
            {
                Mails = mails,
                ResultStatus = ResultStatus.Success
            });
            return new DataResult<MailListDto>(ResultStatus.Error, message: "Aranan e posta adresi bulunamadı", data: new MailListDto
            {
                Mails = null,
                ResultStatus = ResultStatus.Error,
                Message = "Aranan e posta adresi bulunamadı"
            });
        }

        public async Task<IDataResult<MailListDto>> GetAllByDeleted()
        {
            var mails = await _unitOfWork.Mails.GetAllAsync(m => m.IsDeleted);
            if (mails.Count > -1) return new DataResult<MailListDto>(ResultStatus.Success, new MailListDto
            {
                Mails = mails,
                ResultStatus = ResultStatus.Success
            });
            return new DataResult<MailListDto>(ResultStatus.Error, message: "Aranan e posta adresi bulunamadı", data: new MailListDto
            {
                Mails = null,
                ResultStatus = ResultStatus.Error,
                Message = "Aranan e posta adresi bulunamadı"
            });
        }

        public async Task<IDataResult<MailListDto>> GetAllByNonDeleted()
        {
            var mails = await _unitOfWork.Mails.GetAllAsync(m => !m.IsDeleted);
            if (mails.Count > -1) return new DataResult<MailListDto>(ResultStatus.Success, new MailListDto
            {
                Mails = mails,
                ResultStatus = ResultStatus.Success
            });
            return new DataResult<MailListDto>(ResultStatus.Error, message: "Aranan e posta adresi bulunamadı", data: new MailListDto
            {
                Mails = null,
                ResultStatus = ResultStatus.Error,
                Message = "Aranan e posta adresi bulunamadı"
            });
        }

        public async Task<IResult> HardDelete(int mailId)
        {
            var mail = await _unitOfWork.Mails.GetAsync(m => m.Id == mailId);
            if (mail != null)
            {
                await _unitOfWork.Mails.DeleteAsync(mail);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, "E posta kalıcı olarak silindi");
            }
            return new Result(ResultStatus.Error, "E posta silinirken hata oluştu");
        }

        public async Task<IDataResult<MailDto>> Update(MailUpdateDto mailUpdateDto, string userName)
        {
            var mail = _mapper.Map<Mail>(mailUpdateDto);
            mail.ModifiedByName = userName;
            mail.ModifiedDate = DateTime.Now;

            var newMail = await _unitOfWork.Mails.UpdateAsync(mail);
            await _unitOfWork.SaveAsync();
            return new DataResult<MailDto>(ResultStatus.Success, message: "E posta başarıyla güncellendi", data: new MailDto
            {
                Mail = newMail,
                ResultStatus = ResultStatus.Success,
                Message = "E posta başarıyla güncellendi"
            });

        }
    }
}
