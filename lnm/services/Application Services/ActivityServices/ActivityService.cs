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
        private readonly IApplicationRepository<TblInstitutionMaster> _institution;
        private readonly IApplicationRepository<TblActivityMaster> _activity;

        private readonly IMapper _mapper;
        public ActivityService(IApplicationRepository<TblInstitutionActivity> repository, IMapper mapper, IApplicationRepository<TblActivityMaster> activity,
            IApplicationRepository<TblInstitutionMaster> institution
            )
        {
            _repository = repository;
            _mapper = mapper;
            _activity = activity;
            _institution = institution;

        }


        public async Task<CommonResponse<AddInstitutionActivitydto>> CreateNewActivityAsync(AddInstitutionActivitydto dto)
        {
            if (dto == null)
            {
                return new CommonResponse<AddInstitutionActivitydto>(false, "Fields are empty", 400, null);
            }

            var existingActivity = await _repository.GetSingleAsync(u =>
                u.ImInstitutionId==dto.InstitutionId && u.ImActivityId == dto.ActivityId);

            if (existingActivity != null)
            {
                return new CommonResponse<AddInstitutionActivitydto>(false, "Activity already exists", 409, null);
            }

            var data = await _institution.GetSingleAsync(u => u.ImInstitutionId==dto.InstitutionId);

            if (data == null)
            {
                return new CommonResponse<AddInstitutionActivitydto>(false, "Institution not found", 404, null);
            }
            TblInstitutionActivity institutionActivity = _mapper.Map<TblInstitutionActivity>(dto);
            institutionActivity.ImCreatedDate = DateTime.Now;
            institutionActivity.ImUpdatedDate = DateTime.Now;
            institutionActivity.ImInstitutionAddress = data.ImInstitutionAddress;
            institutionActivity.ImCreatedBy =  1;// ==============================================this will be changed
            institutionActivity.ImInstitutionName = data.ImInstitutionName;
            institutionActivity.ImInstitutionId = data.ImInstitutionId;
            institutionActivity.ImUpdatedBy = 1; //  =====================================this will be changed
            institutionActivity.ImInstitutionType = data.ImInstitutionType;
            institutionActivity.ImAssignConnector = data.ImAssignConnector;
            institutionActivity.ImUpdatedDate = DateTime.Now;

            await _repository.CreateAsync(institutionActivity);

            var response = _mapper.Map<AddInstitutionActivitydto>(institutionActivity);

            return new CommonResponse<AddInstitutionActivitydto>(true, "Activity created successfully", 201, response);
        }

        public async Task<CommonResponse<AddInstitutionActivitydto>> UpdateActivityAsync(int id, AddInstitutionActivitydto dto)
        {
            if (dto == null || dto.ActivityId != id)
            {
                return new CommonResponse<AddInstitutionActivitydto>(false, "invalid input credentials", 404, null);
            }
            var existingActivity = await _repository.GetSingleAsync(u => u.ImActivityId.Equals(dto.ActivityId));

            if (existingActivity == null)
            {
                return new CommonResponse<AddInstitutionActivitydto>(false, "activity not found", 404, null);
            }
            _mapper.Map(dto, existingActivity);

            existingActivity.ImUpdatedDate = DateTime.Now;

            await _repository.UpdateAsync(existingActivity);

            var response = _mapper.Map<AddInstitutionActivitydto>(existingActivity);

            return new CommonResponse<AddInstitutionActivitydto>(true, "activity updated sucessfully", 200, response);

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


        public async Task<CommonResponse<List<AddInstitutionActivitydto>>> GetAllInstitutionActivityAsync(int institutionId)
        {
            //=========================================================================== below code needs to be changed =================== corrected
            var activities = await _repository.GetAllByAnyAsync(u=> u.ImInstitutionId==institutionId);

            var data = _mapper.Map<List<AddInstitutionActivitydto>>(activities);

            return new CommonResponse<List<AddInstitutionActivitydto>>(true, "Institution activities fetched successfully", 200, data);
        }


        public async Task<CommonResponse<List<TblActivityMaster>>> GetAllActivityAsync() //===================== this is for first box display all activities
        {
            var activities = await _activity.GetAllAsync();

            return new CommonResponse<List<TblActivityMaster>>(true, "activity fetched successfully", 200, activities);
        }
    }

   

}
