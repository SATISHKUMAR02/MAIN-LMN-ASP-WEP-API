using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using model;
using model.Institution;
using services.Application_Services.LeadServices.DTO;
using services.Repository;

namespace services.Application_Services.History
{
    public class HistoryServices : IHistoryServices

    {
        private readonly IApplicationRepository<TblMeetingsMaster> _repository;
        private readonly IMapper _mapper;
        //======================================================================================================== HISTORY PART


        public async Task<CommonResponse<List<Meetingdto>>> GetAllMeetingsBySchoolIdAsync(int id)
        {
            if (id <= 0)
            {
                return new CommonResponse<List<Meetingdto>>(false, "Invalid school ID", 404, null);
            }

            var leads = await _repository.GetAllByAnyAsync(lead => lead.MmInstitutionId == id);

            if (leads == null || !leads.Any())
            {
                return new CommonResponse<List<Meetingdto>>(false, "Meeting details do not exist", 404, null);
            }

            var data = _mapper.Map<List<Meetingdto>>(leads);
            return new CommonResponse<List<Meetingdto>>(true, "Meeting details fetched successfully", 200, data);
        }

    }
}
