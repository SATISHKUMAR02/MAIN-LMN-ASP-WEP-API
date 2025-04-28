using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using model;
using model.Institution;
using services.Application_Services.LeadServices.DTO;
using services.Application_Services.Usermanagement.AddUsers.TelecallersServices.DTO;
using services.Repository;

namespace services.Application_Services.LeadServices
{
    public class LeadService : ILeadService
    {

        private readonly IApplicationRepository<TblInstitutionMaster> _repository;
        private readonly IMapper _mapper;

        public async Task<CommonResponse<LeadDto>> CreateLeadAsync(LeadDto dto)
        {
            if (dto == null)
            {
                return new CommonResponse<LeadDto>(false, "fields are empty", 400, null);
            }
            var existingLead = await _repository.GetSingleAsync(u => u.ImInstitutionId.Equals(dto.institution_id));
            if (existingLead != null)
            {
                return new CommonResponse<LeadDto>(false, "lead already exist", 400, null);
            }
            TblInstitutionMaster institution = _mapper.Map<TblInstitutionMaster>(dto);
            institution.ImCreatedDate = DateTime.Now;

             var data =  await _repository.CreateAsync(institution);
            var response = _mapper.Map<LeadDto>(dto);
             return new CommonResponse<LeadDto>(true, "Telecaller created successfully", 200, response);

        }

        public async Task<CommonResponse<LeadDto>> UpdateLeadAsync(LeadDto dto)
        {
            if (dto == null)
            {
                return new CommonResponse<LeadDto>(false, "fields are empty", 400, null);
            }
            var exuser = await _repository.GetSingleAsync(u => u.ImInstitutionId.Equals(dto.institution_id) && u.ImIsDeleted==false);
            if (exuser != null)
            {
                return new CommonResponse<LeadDto>(false, "lead does not exist", 400, null);
            }
            var LeadtoUpdate = _mapper.Map<TblInstitutionMaster>(dto);
            LeadtoUpdate.ImUpdatedDate = DateTime.Now;
            await _repository.UpdateAsync(LeadtoUpdate);
            return new CommonResponse<LeadDto>(true, "lead updated successfully", 200, dto);

        }
        // ====================================================================================================
        // DashBoardLeadDto is being used here 
        public async Task<CommonResponse<List<DashboardLeadDto>>> GetAllLeadAsync()
        {
            var leads = await _repository.GetAllAsync();
            var data = _mapper.Map<List<DashboardLeadDto>>(leads);
            return new CommonResponse<List<DashboardLeadDto>>(true, "leads fetched successfully", 200, data);
        }

        public async Task<CommonResponse<List<LeadDto>>> GetleadAsync() // just created ========= use it when needed
        {
            var leads = await _repository.GetAllAsync();
            var data =  _mapper.Map<List<LeadDto>>(leads);
            return new CommonResponse<List<LeadDto>>(true, "lead fetched successfully", 200, data);
        }
        public async Task<CommonResponse<LeadDto>> GetLeadByIdAsync(int id)
        {
            if (id < 0)
            {
                return new CommonResponse<LeadDto>(false, "invalid Id", 404, null);

            }
            var leads = await _repository.GetAllByAnyAsync(lead => lead.ImInstitutionId == id && lead.ImIsDeleted==false);
            if (leads == null)
            {
                return new CommonResponse<LeadDto>(false, "lead does not exist", 404, null);
            }
            var data = _mapper.Map<LeadDto>(leads);
            return new CommonResponse<LeadDto>(true, "single lead fetched successfully", 200, data);

        }
        public async Task<CommonResponse<LeadDto>> GetLeadByNameAsync(string institution)
        {
            if (institution == "")
            {
                return new CommonResponse<LeadDto>(false, "fields are empty", 404, null);
            }

            var leads = await _repository.GetAllByAnyAsync(lead => lead.ImInstitutionName == institution && lead.ImIsDeleted == false);
            if (leads == null)
            {
                return new CommonResponse<LeadDto>(false, "lead does not exist ", 404, null);

            }
            var data = _mapper.Map<LeadDto>(leads);
            return new CommonResponse<LeadDto>(true, "lead fetched successfully", 200, data);

        }
        public async Task<CommonResponse<object>> DeleteLeadAdminAsync(int id) //============================================ this is only for Admin for permanent deletion
        {

            if(id == 0)
            {
                return new CommonResponse<object>(false, "invalid credentials", 404, null);
            }
            var lead = await _repository.GetSingleAsync(u=>u.ImInstitutionId == id);
            if(lead == null)
            {
                return new CommonResponse<object>(false,"lead does not exist",404,null);
            }
            await _repository.DeleteAsync(lead);
            return new CommonResponse<object>(true,"lead deleted successfully",200,null);
        }

        public async Task<CommonResponse<object>> DeleteLeadOthersAsync(int id) //============================================ this is for Others ,  ImIsDeleted flag = true
        {

            if (id == 0)
            {
                return new CommonResponse<object>(false, "invalid credentials", 404, null);
            }
            var lead = await _repository.GetSingleAsync(u => u.ImInstitutionId == id);
            if (lead == null)
            {
                return new CommonResponse<object>(false, "lead does not exist", 404, null);
            }
            lead.ImIsDeleted = true;
            return new CommonResponse<object>(true, "lead deleted successfully", 200, null);
        }




    }
}
