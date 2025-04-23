
using AutoMapper;
using model.Institution;
using model.MOUs;
using services.Application_Services.LeadServices.DTO;
using services.Application_Services.MouServices.DTO;
using services.Application_Services.Usermanagement.AddUsers.Connectors.DTO;
using services.Application_Services.Usermanagement.AddUsers.TelecallersServices.DTO;
using services.User;
using System.Reflection;

namespace services.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig() { 
        
            CreateMap<TblInstitutionMaster,LeadDto>().ReverseMap();
            CreateMap<tbl_employee_master, AddConnectordto>().ReverseMap();
            CreateMap<tbl_employee_master, AddTelecallerdto>().ReverseMap();
            CreateMap<InstitutionMou, connectorDtocs>().ReverseMap();


        }

    }

}
