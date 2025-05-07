
using AutoMapper;
using model.Institution;
using model.MOUs;
using services.Application_Services.LeadServices.DTO;
using services.Application_Services.MouServices.DTO;
using services.Application_Services.Usermanagement.AddUsers.Connectors.DTO;
using services.Application_Services.Usermanagement.AddUsers.TelecallersServices.DTO;
using model.User;
using System.Reflection;
using services.Application_Services.Usermanagement.AllUsers.DTO;
using services.Application_Services.Usermanagement.Connectors.DTO;

namespace services.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig() {
            CreateMap<tbl_employee_master, AllUserdto>().ReverseMap();
            CreateMap<TblInstitutionMaster,LeadDto>().ReverseMap();
            CreateMap<tbl_employee_master,Connectordto>()
                .ForMember(dest=>dest.connectorId,opt=>opt.MapFrom(src=>src.em_id))
                .ForMember(dest=>dest.connectorName,opt=>opt.MapFrom(src=>src.em_name_e))
                .ForMember(dest=>dest.joining_date,opt=>opt.MapFrom(src=>src.em_joining_date))
                .ForMember(dest=>dest.phone_number,opt=>opt.MapFrom(src=>src.em_contact_number))
                .ForMember(dest=>dest.email,opt=>opt.MapFrom(src=>src.em_email_address))
                .ForMember(dest=>dest.status,opt=>opt.MapFrom(src=>src.em_is_active))

                
                .ReverseMap();
        //     public int connectorId { get; set; }

        //public string connectorName { get; set; }

        //public DateTime joining_date { get; set; }

        //public string phone_number { get; set; }

        //public string email { get; set; }

        //public bool status { get; set; }

        //public string view { get; set; } // this is for storing the MOU URL

        CreateMap<AddConnectordto, tbl_employee_master>()
                .ForMember(dest => dest.em_id, opt => opt.MapFrom(src => src.connector_id))
                .ForMember(dest => dest.em_name_e, opt => opt.MapFrom(src => $"{src.Firstname} {src.Lastname}"))
                .ForMember(dest => dest.em_contact_number, opt => opt.MapFrom(src => src.phonenumber))
                .ForMember(dest => dest.em_email_address, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.em_joining_date, opt => opt.MapFrom(src => src.hireDate))
                .ForMember(dest => dest.em_updated_date, opt => opt.MapFrom(src => src.updated_date))
                .ForMember(dest => dest.em_is_active, opt => opt.MapFrom(src => true)).ReverseMap();


            CreateMap<tbl_employee_master, AddTelecallerdto>().ReverseMap();
            CreateMap<InstitutionMou, connectorDtocs>().ReverseMap();
            CreateMap<TblMeetingsMaster, Meetingdto>().ReverseMap();
            CreateMap<tbl_employee_master, AllUserdto>();




        }

        

    }

}
