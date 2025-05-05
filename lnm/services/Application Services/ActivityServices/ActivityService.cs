using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Identity.Client;
using model;
using model.Activities;
using model.Institution;
using services.Application_Services.ActivityServices.DTO;
using services.Repository;

namespace services.Application_Services.ActivityServices
{
    public class ActivityService : IActivityService 

    {
        private readonly IApplicationRepository<TblInstitutionActivity> _repository;
        
        private readonly IMapper _mapper;
        public ActivityService(IApplicationRepository<TblInstitutionActivity> repository)
        {
            _repository = repository;            
        }
        public async Task<CommonResponse<AddInstitutionActivitydto>> CreateNewActivityAsync(int id,AddInstitutionActivitydto dto)
        {
            if (dto == null || dto.InstitutionId != id)
            {
                return new CommonResponse<AddInstitutionActivitydto>(false, "fields are empty", 404, null);
            }
            var existingActivity = await _repository.GetSingleAsync(u => u.ImActivityId.Equals(dto.ActivityId));
            if (existingActivity != null) {
                return new CommonResponse<AddInstitutionActivitydto>(false, "activity already exist", 404, null);

            }
            TblInstitutionActivity institutionActivity = _mapper.Map<TblInstitutionActivity>(dto);

            institutionActivity.ImCreatedDate = DateTime.Now;

            institutionActivity.ImUpdatedDate = DateTime.Now;

            await _repository.CreateAsync(institutionActivity);
            
            var response = _mapper.Map<AddInstitutionActivitydto>(institutionActivity);

            return new CommonResponse<AddInstitutionActivitydto>(true, "activity created successfully", 201, response);

        }
        public async Task<CommonResponse<AddInstitutionActivitydto>> UpdateActivityAsync(int id, AddInstitutionActivitydto dto)
        {
            if (dto == null||dto.ActivityId!=id)
            {
                return new CommonResponse<AddInstitutionActivitydto>(false, "invalid input credentials", 404, null);
            }
            var existingActivity = await _repository.GetSingleAsync(u=>u.ImActivityId.Equals(dto.ActivityId));
            
            if (existingActivity == null)
            {
                return new CommonResponse<AddInstitutionActivitydto>(false, "activity not found", 404, null);
            }
             _mapper.Map(dto,existingActivity);
            
            existingActivity.ImUpdatedDate = DateTime.Now;
            
            await _repository.UpdateAsync(existingActivity);
            
            var response = _mapper.Map<AddInstitutionActivitydto>(existingActivity);
            
            return new CommonResponse<AddInstitutionActivitydto>(true,"activity updated sucessfully",200,response);
           
        }

        public async Task<CommonResponse<object>> DeleteActivityAsync(int activityId)
        {
            if (activityId <= 0)
            {
                return new CommonResponse<object>(false, "invalid activity", 404, null);
            }
            var existingActivity = await _repository.GetSingleAsync(i => i.ImActivityId == activityId);
            
            if (existingActivity == null)
            {
                return new CommonResponse<object>(false, "activity does not exist", 404, null);
            }
            await _repository.DeleteAsync(existingActivity);
            
            return new CommonResponse<object>(true, "activity removed successfully", 200, null);

        }


        public async Task<CommonResponse<List<AddInstitutionActivitydto>>> GetAllInstitutionActivityAsync()
        {
            //=========================================================================== below code needs to be changed ===================
            var activities = await _repository.GetAllByAnyAsync(u => u.ImInstitutionId != 1);
            
            var data = _mapper.Map<List<AddInstitutionActivitydto>>(activities);
           
            return new CommonResponse<List<AddInstitutionActivitydto>>(true, "Institution activities fetched successfully", 200, data);
        }


        public async Task<CommonResponse<List<TblActivityMaster>>> GetAllActivityAsync() //===================== this is for first box display all activities
        {
            var institutionActivities = await _repository.GetAllAsync();
            
            var data =  _mapper.Map<List<TblActivityMaster>>(institutionActivities);
            
            return new CommonResponse<List<TblActivityMaster>>(true,"activity fetched successfully",200,data);
        }
    }
   

}
