﻿
using CMS.Entities.Dtos;
using CMS.Shared.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Services.Abstract
{
    public interface IMissionService
    {
        Task<IDataResult<MissionDto>> Get(int missionId);
        Task<IDataResult<MissionListDto>> GetAll();

        Task<IResult> Add(MissionAddDto missionAddDto, string userName);
        Task<IResult> Update(MissionUpdateDto missionUpdateDto, string userName);

        Task<IResult> Delete(int missionId);
        Task<IResult> HardDelete(int missionId);
    }
}
