using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;
using model.Activities;
using model.Institution;
using services.Application_Services.ActivityServices.DTO;
using services.Application_Services.LeadServices.DTO;

namespace services.Application_Services.ActivityServices
{
    public interface IActivityService
    {
        Task<CommonResponse<AddInstitutionActivitydto>> CreateNewActivityAsync(AddInstitutionActivitydto dto);

        Task<CommonResponse<AddInstitutionActivitydto>> UpdateActivityAsync(int id, AddInstitutionActivitydto dto);

        Task<CommonResponse<object>> DeleteActivityAsync(int activityId);

        Task<CommonResponse<List<AddInstitutionActivitydto>>> GetAllInstitutionActivityAsync();

        Task<CommonResponse<List<TblActivityMaster>>> GetAllActivityAsync(); // this is from the activity master

        //Task<List<LeadDto>> GetAllActivityAsync();


        //Task<LeadDto> GetActivityByIdAsync(int id); // this is for the getting activities from activitymaster

        //Task<LeadDto> GetActivityByNameAsync(string institutionName);

    }
}
