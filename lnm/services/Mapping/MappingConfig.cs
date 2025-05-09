
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
using services.Application_Services.Usermanagement.AddUsers.ConnectorsServices.DTO;
using services.Application_Services.LeadServices.Meetings.DTO;

namespace services.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig() {
            CreateMap<tbl_employee_master, AllUserdto>().ReverseMap();


            CreateMap<TblInstitutionMaster, LeadDto>()
                .ForMember(dest => dest.institution_id, opt => opt.MapFrom(src => src.ImInstitutionId))
                .ForMember(dest => dest.institution_type, opt => opt.MapFrom(src => src.ImInstitutionType))
                .ForMember(dest => dest.institution_name, opt => opt.MapFrom(src => src.ImInstitutionName))
                .ForMember(dest => dest.assigned_connector, opt => opt.MapFrom(src => src.ImAssignConnector))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.ImInstitutionAddress))
                .ForMember(dest => dest.principal_name, opt => opt.MapFrom(src => src.ImPrincipalName))
                .ForMember(dest => dest.principal_email, opt => opt.MapFrom(src => src.ImPrincipalEmail))
                .ForMember(dest => dest.principal_contact, opt => opt.MapFrom(src => src.ImPrincipalContact))
                .ForMember(dest => dest.other_name, opt => opt.MapFrom(src => src.ImOtherName))
                .ForMember(dest => dest.other_designation, opt => opt.MapFrom(src => src.ImOtherDesignation))
                .ForMember(dest => dest.other_email, opt => opt.MapFrom(src => src.ImOtherEmail))
                .ForMember(dest => dest.other_contact, opt => opt.MapFrom(src => src.ImOtherContact))
                .ForMember(dest => dest.student_strength, opt => opt.MapFrom(src => src.ImStudentStrength))
                .ReverseMap();

            CreateMap<TblInstitutionMaster, DashboardLeadDto>()
                .ForMember(dest => dest.institutiton_id, opt => opt.MapFrom(src => src.ImInstitutionId))
                .ForMember(dest => dest.institutiton_name, opt => opt.MapFrom(src => src.ImInstitutionName))
                .ForMember(dest => dest.institution_type, opt => opt.MapFrom(src => src.ImInstitutionType))
                .ForMember(dest => dest.institution_status, opt => opt.MapFrom(src => src.ImInstitutionStatus))
                .ForMember(dest => dest.mou_status, opt => opt.MapFrom(src => src.ImMouStatus))
                .ForMember(dest => dest.assign_connector, opt => opt.MapFrom(src => src.ImAssignConnector)).ReverseMap();

            CreateMap<tbl_employee_master, Connectordto>()
                .ForMember(dest => dest.connectorId, opt => opt.MapFrom(src => src.em_id))
                .ForMember(dest => dest.connectorName, opt => opt.MapFrom(src => src.em_name_e))
                .ForMember(dest => dest.joining_date, opt => opt.MapFrom(src => src.em_joining_date))
                .ForMember(dest => dest.phone_number, opt => opt.MapFrom(src => src.em_contact_number))
                .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.em_email_address))
                .ForMember(dest => dest.status, opt => opt.MapFrom(src => src.em_is_active))
                .ReverseMap();
            CreateMap<tbl_employee_master, Telecallerdto>()
               .ForMember(dest => dest.telecallerId, opt => opt.MapFrom(src => src.em_id))
               .ForMember(dest => dest.telecallerName, opt => opt.MapFrom(src => src.em_name_e))
               .ForMember(dest => dest.joining_date, opt => opt.MapFrom(src => src.em_joining_date))
               .ForMember(dest => dest.phonenumber, opt => opt.MapFrom(src => src.em_contact_number))
               .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.em_email_address))
               .ForMember(dest => dest.status, opt => opt.MapFrom(src => src.em_is_active))
               .ReverseMap();

            CreateMap<tbl_employee_master, AddTelecallerdto>()
             .ForMember(dest => dest.telecaller_id, opt => opt.MapFrom(src => src.em_id))
             .ForMember(dest => dest.Firstname, opt => opt.MapFrom(src => src.em_name_e))
             .ForMember(dest => dest.Lastname, opt => opt.MapFrom(src => src.em_name_k))
             .ForMember(dest => dest.phonenumber, opt => opt.MapFrom(src => src.em_contact_number))
             .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.em_email_address))
             .ForMember(dest => dest.hireDate, opt => opt.MapFrom(src => src.em_joining_date))
             .ForMember(dest => dest.updated_date, opt => opt.MapFrom(src => src.em_updated_date))
             .ForMember(dest => dest.gender, opt => opt.MapFrom(src => src.em_gender))
             .ForMember(dest => dest.dateOfbirth, opt => opt.MapFrom(src => src.dob));

            CreateMap<AddConnectordto, tbl_employee_master>()
                .ForMember(dest => dest.em_id, opt => opt.MapFrom(src => src.connector_id))
                .ForMember(dest => dest.em_name_e, opt => opt.MapFrom(src => $"{src.Firstname} {src.Lastname}"))
                .ForMember(dest => dest.em_contact_number, opt => opt.MapFrom(src => src.phonenumber))
                .ForMember(dest => dest.em_email_address, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.em_joining_date, opt => opt.MapFrom(src => src.hireDate))
                .ForMember(dest => dest.em_updated_date, opt => opt.MapFrom(src => src.updated_date))
                .ForMember(dest => dest.em_gender, opt => opt.MapFrom(src => src.gender))
                .ForMember(dest => dest.em_is_active, opt => opt.MapFrom(src => true)).ReverseMap();

            CreateMap<AddSubConnectordto, tbl_employee_master>()
               .ForMember(dest => dest.em_id, opt => opt.MapFrom(src => src.employee_id))
               .ForMember(dest => dest.em_name_e, opt => opt.MapFrom(src => src.FirstName))
               .ForMember(dest => dest.em_name_k, opt => opt.MapFrom(src => src.LastName))
               .ForMember(dest => dest.em_contact_number, opt => opt.MapFrom(src => src.phoneNo))
               .ForMember(dest => dest.em_email_address, opt => opt.MapFrom(src => src.Email))
               .ForMember(dest => dest.em_joining_date, opt => opt.MapFrom(src => src.HireDate))
               .ForMember(dest => dest.em_updated_date, opt => opt.MapFrom(src => src.updated_date))
               .ForMember(dest => dest.em_gender, opt => opt.MapFrom(src => src.Gender))
               .ForMember(dest => dest.em_is_active, opt => opt.MapFrom(src => true)).ReverseMap();

            CreateMap<SubConnectordto, tbl_employee_master>()
              .ForMember(dest => dest.em_id, opt => opt.MapFrom(src => src.sub_connector_id))
              .ForMember(dest => dest.em_name_e, opt => opt.MapFrom(src => src.sub_connector_name))
              .ForMember(dest => dest.em_contact_number, opt => opt.MapFrom(src => src.Contact))
              .ForMember(dest => dest.em_email_address, opt => opt.MapFrom(src => src.email))
              .ForMember(dest => dest.em_joining_date, opt => opt.MapFrom(src => src.hire_Date))
             .ReverseMap();

            CreateMap<TblMeetingsMaster, ScheduleMeetingdto>()
                 .ForMember(dest => dest.meeting_id, opt => opt.MapFrom(src => src.MmMeetingId))
                 .ForMember(dest => dest.institution_id, opt => opt.MapFrom(src => src.MmInstitutionId))
                 .ForMember(dest => dest.date, opt => opt.MapFrom(src => src.MmMeetingScheduleDate))
                 .ForMember(dest => dest.time, opt => opt.MapFrom(src => src.MmMeetingTime))
                 .ForMember(dest => dest.type, opt => opt.MapFrom(src => src.MmMeetingType))
                 .ForMember(dest => dest.descritpion, opt => opt.MapFrom(src => src.MmMeetingDescritpion))
                 .ForMember(dest => dest.created_by, opt => opt.MapFrom(src => src.MmCreatedBy))
                .ReverseMap();

            CreateMap<TblMeetingsMaster, ScheduleCallbackdto>()
                 .ForMember(dest => dest.meeting_id, opt => opt.MapFrom(src => src.MmMeetingId))
                 .ForMember(dest => dest.institution_id, opt => opt.MapFrom(src => src.MmInstitutionId))
                 .ForMember(dest => dest.date, opt => opt.MapFrom(src => src.MmMeetingScheduleDate))
                 .ForMember(dest => dest.time, opt => opt.MapFrom(src => src.MmMeetingTime))
                 .ForMember(dest => dest.type, opt => opt.MapFrom(src => src.MmMeetingType))
                 .ForMember(dest => dest.descritpion, opt => opt.MapFrom(src => src.MmMeetingDescritpion))
                 .ForMember(dest => dest.created_by, opt => opt.MapFrom(src => src.MmCreatedBy))
                .ReverseMap();

            CreateMap<TblMeetingsMaster, MeetingCallbackdashdto>()
                 .ForMember(dest => dest.date, opt => opt.MapFrom(src => src.MmMeetingScheduleDate))
                 .ForMember(dest => dest.time, opt => opt.MapFrom(src => src.MmMeetingTime))
                 .ForMember(dest => dest.type, opt => opt.MapFrom(src => src.MmMeetingType))
                 .ForMember(dest => dest.meeting_conducted, opt => opt.MapFrom(src => src.MmMeetingConducted))
                 .ForMember(dest => dest.meeting_outcome, opt => opt.MapFrom(src => src.MmmeetingOutcome))
                 .ForMember(dest => dest.status, opt => opt.MapFrom(src => src.MmMeetingStatus))
                 .ReverseMap(); 
                 
            CreateMap<TblMeetingsMaster,Historydto>()
                .ForMember(dest=>dest.date,opt=>opt.MapFrom(src=>src.MmMeetingScheduleDate))
                .ForMember(dest=>dest.time,opt=>opt.MapFrom(src=>src.MmMeetingTime))
                .ForMember(dest=>dest.updated_by,opt=>opt.MapFrom(src=>src.MmUpdatedBy))
                .ForMember(dest=>dest.description,opt=>opt.MapFrom(src=>src.MmMeetingDescritpion))
                .ReverseMap();

                

            CreateMap<InstitutionMou, connectorDtocs>().ReverseMap();
            CreateMap<tbl_employee_master, AllUserdto>();




        }
    
        

    }

}
