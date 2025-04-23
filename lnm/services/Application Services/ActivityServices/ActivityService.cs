using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Identity.Client;
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
        public async Task<bool> CreateNewActivityAsync(AddInstitutionActivitydto dto)
        {
            if (dto == null)
            {
                throw new Exception("empty data");
            }
            var existingActivity = await _repository.GetSingleAsync(u => u.ImActivityId.Equals(dto.ActivityId));
            if (existingActivity != null) { 
                throw new ArgumentNullException(nameof(existingActivity));
              }
            TblInstitutionActivity institutionActivity = _mapper.Map<TblInstitutionActivity>(dto);
            await _repository.CreateAsync(institutionActivity);
            institutionActivity.ImCreatedDate = DateTime.Now;
            institutionActivity.ImUpdatedDate = DateTime.Now;

            return true;

        }
        public async Task<bool> UpdateActivityAsync (AddInstitutionActivitydto dto)
        {
            if (dto == null)
            {
                throw new Exception("empty data");
            }
            var existingActivity = await _repository.GetSingleAsync(u=>u.ImActivityId.Equals(dto.ActivityId));
            if (existingActivity == null)
            {
                throw new Exception("activity not found");
            }
            var activityToUpdate = _mapper.Map<TblInstitutionActivity>(dto);
            activityToUpdate.ImUpdatedDate = DateTime.Now;
            await _repository.UpdateAsync(activityToUpdate);
            return true;
        }

        public async Task<bool> DeleteActivityAsync(int activityId)
        {
            if (activityId <= 0)
            {
                throw new ArgumentNullException(nameof(activityId));
            }
            var existingActivity = await _repository.GetSingleAsync(i => i.ImActivityId == activityId);
            if (existingActivity == null)
            {
                throw new Exception("activity not found");
            }
            await _repository.DeleteAsync(existingActivity);
            return true;
        }
        public async Task<List<TblInstitutionActivity>> GetAllInstitutionActivityAsync()
        { 
            //================================================================= below code needs to be changed
            var activities = await _repository.GetAllByAnyAsync(u=>u.ImInstitutionId!=1);
            return _mapper.Map<List<TblInstitutionActivity>>(activities);
        }

        public async Task<List<TblActivityMaster>> GetAllActivityAsync()
        {
            var institutiotnActivities = await _repository.GetAllAsync();
            return _mapper.Map<List<TblActivityMaster>>(institutiotnActivities);
        }
    }
   

}
