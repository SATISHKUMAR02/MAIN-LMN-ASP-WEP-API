using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model.Activities;
using model.Institution;
using services.Application_Services.ActivityServices.DTO;
using services.Application_Services.LeadServices.DTO;

namespace services.Application_Services.ActivityServices
{
    public interface IActivityService
    {
        Task<bool> CreateNewActivityAsync(AddInstitutionActivitydto dto);

        Task<bool> UpdateActivityAsync(AddInstitutionActivitydto dto);

        Task<bool> DeleteActivityAsync(int activityId);

        Task<List<TblInstitutionActivity>> GetAllInstitutionActivityAsync();

        Task<List<TblActivityMaster>> GetAllActivityAsync(); // this is from the activity master

        //Task<List<LeadDto>> GetAllActivityAsync();


        //Task<LeadDto> GetActivityByIdAsync(int id); // this is for the getting activities from activitymaster

        //Task<LeadDto> GetActivityByNameAsync(string institutionName);

    }
}
