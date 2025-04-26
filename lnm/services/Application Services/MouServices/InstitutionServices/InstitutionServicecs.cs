using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using model;
using model.Institution;
using model.MOUs;
using services.Application_Services.MouServices.DTO;
using services.Application_Services.MouServices.TelecallerServices;
using services.Repository;

namespace services.Application_Services.MouServices.InstitutionServices
{
    public class InstitutionServicecs : IInstitutionService
    {
        private readonly IApplicationRepository<InstitutionMou> _repository;
        private readonly IMapper _mapper;

        public async Task<CommonResponse<List<Institutiondto>>> GetAllInstitutitionMouAsync()
        {
            var institutions = await _repository.GetAllAsync();
            var data = _mapper.Map<List<Institutiondto>>(institutions);
            return new CommonResponse<List<Institutiondto>>(true, "institution mou fetched successfully", 200, data);
        }

        public async Task<CommonResponse<object>> GetInstitutionMouByVersion(float versionno)
        {
            if (versionno == null)
            {
                return new CommonResponse<object>(false, "mou does not exist", 404, null);
            }
            var mou = await _repository.GetSingleAsync(u => u.ImoMouVerionNo == versionno);
            return new CommonResponse<object>(true, "mou retireved successfully", 200, mou);

        }

        public async Task<CommonResponse<object>> GetCurrentInstitutionMouByVersionAsync()
        {
            var allMous = await _repository.GetAllAsync();

            var latestVersion = allMous.Max(m => m.ImoMouVerionNo);

            var mou = await _repository.GetSingleAsync(u => u.ImoMouVerionNo == latestVersion);

            return new CommonResponse<object>(true, "current mou fetched successfully", 200, mou);
        }


    }
}
