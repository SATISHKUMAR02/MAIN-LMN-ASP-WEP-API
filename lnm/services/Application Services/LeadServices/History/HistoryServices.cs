using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using model;
using model.Institution;
using services.Application_Services.LeadServices.Meetings.DTO;
using services.Repository;

namespace services.Application_Services.LeadServices.History
{
    public class HistoryServices : IHistoryServices
    {
        private readonly IApplicationRepository<TblMeetingsMaster> _repository;

        private readonly IMapper _mapper;

        public HistoryServices(IApplicationRepository<TblMeetingsMaster> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CommonResponse<List<Historydto>>> GetAllHistoryAsync()
        {
            var events = await _repository.GetAllAsync();

            var data = _mapper.Map<List<Historydto>>(events);
            
            return new CommonResponse<List<Historydto>>(true,"events fetched successfully",200,data);
        }
    }
}
