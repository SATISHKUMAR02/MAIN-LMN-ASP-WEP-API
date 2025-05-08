using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using model;
using services.Application_Services.Usermanagement.AddUsers.Connectors.DTO;
using services.Application_Services.Usermanagement.AddUsers.TelecallersServices.DTO;
using services.Application_Services.Usermanagement.Connectors.DTO;
using services.Repository;
using model.User;

namespace services.Application_Services.Usermanagement.AddUsers.TelecallersServices
{
    public class AddTelecaller : IAddTelecaller
    {
        private readonly IApplicationRepository<tbl_employee_master> _repository;
        private readonly IApplicationRepository<tbl_user_login_details> _loginrepository;
        
        private readonly IMapper _mapper;

        public AddTelecaller(IApplicationRepository<tbl_employee_master> repository, IMapper mapper,IApplicationRepository<tbl_user_login_details> loginrepository)
        {
            _repository = repository;
            _mapper = mapper;
            _loginrepository = loginrepository;
        }
        public async Task<CommonResponse<AddTelecallerdto>> CreateTelecallerAsync(AddTelecallerdto dto)
        {
            if (dto == null)
            {

                //throw new Exception("no body");
                return new CommonResponse<AddTelecallerdto>(false, "Error", 404, null);

            }
            var existingTelecaller = await _repository.GetSingleAsync(u => u.em_id == dto.telecaller_id || u.em_role_id == 2 ||
            u.em_contact_number == dto.phonenumber);
            if (existingTelecaller != null)
            {
                return new CommonResponse<AddTelecallerdto>(false, "user already exist", 400, null);

            }
            tbl_employee_master user = new tbl_employee_master
            {
                em_id = dto.telecaller_id,
                em_name_e = dto.Firstname,
                em_name_k = dto.Lastname,
                em_contact_number = dto.phonenumber,
                em_gender =  dto.gender,
                em_is_active  = true,
                em_role_id = 2,
                em_created_date=DateTime.Now,
                em_joining_date = dto.hireDate,
                em_email_address = dto.Email,
                em_updated_date = DateTime.Now,

            };
      
            await _repository.CreateAsync(user);

            tbl_user_login_details loginDetails = new tbl_user_login_details
            {
                uld_contact_number = user.em_contact_number,
                uld_created_date = DateTime.Now,
                uld_employee_id = user.em_id,
                uld_is_active=true,
                uld_otp = "9876",
                uld_otp_time = DateTime.Now.AddSeconds(300),

            };
            await _loginrepository.CreateAsync(loginDetails);

            return new CommonResponse<AddTelecallerdto>(true, "Telecaller created successfully", 200, dto);


        }
        public async Task<CommonResponse<AddTelecallerdto>> UpdateTelecallerAsync(AddTelecallerdto dto)
        {
            if (dto == null)
            {
                return new CommonResponse<AddTelecallerdto>(false, "fields are empty", 404, null);
            }
            var existingTelecaller = await _repository.GetSingleAsync(u => u.em_id == dto.telecaller_id);
            if (existingTelecaller == null)
            {
                return new CommonResponse<AddTelecallerdto>(false, "Telecaller does not exist", 404, null);
            }
            var telecallerToUpdate = _mapper.Map<tbl_employee_master>(dto);
            telecallerToUpdate.em_updated_date = DateTime.Now;

            await _repository.UpdateAsync(telecallerToUpdate);
            return new CommonResponse<AddTelecallerdto>(true, "Telecaller details updated successfully", 201, dto);

        }
        public async Task<CommonResponse<object>> DeleteTempTelecallerAsync(int id)
        {
            if (id <= 0)
            {
                return new CommonResponse<object>(false, "fields are empty", 404, null);
            }

            var existingTelecaller = await _repository.GetSingleAsync(u => u.em_id == id && u.em_is_active == true);
            if (existingTelecaller == null)
            {
                return new CommonResponse<object>(false, "Telecaller does not exist", 404, null);
            }

            existingTelecaller.em_is_active = false;
            await _repository.UpdateAsync(existingTelecaller);

            var logindetails = await _loginrepository.GetSingleAsync(u => u.uld_employee_id == id && u.uld_is_active==true);
            if (logindetails == null)
            {
                return new CommonResponse<object>(false, "Login details not found", 404, null);
            }

            logindetails.uld_is_active = false;
            await _loginrepository.UpdateAsync(logindetails);

            return new CommonResponse<object>(true, "Telecaller details deleted successfully", 200, null);
        }


        public async Task<CommonResponse<object>> DeleteTelecallerAsync(int id)
        {
            if (id <= 0)
            {
                return new CommonResponse<object>(false, "Enter a valid employee ID", 404, null);
            }

            var existingTelecaller = await _repository.GetSingleAsync(u => u.em_id == id);
            if (existingTelecaller == null)
            {
                return new CommonResponse<object>(false, "Cannot find Telecaller", 404, null);
            }

            await _repository.DeleteAsync(existingTelecaller);
            return new CommonResponse<object>(true, "Telecaller deleted successfully", 200, null);
        }


        public async Task<CommonResponse<List<Telecallerdto>>> GetAllTelecallerAsync()
        {
            var telecaller = await _repository.GetAllByAnyAsync(u=>u.em_is_active ==true && u.em_role_id==2);
            var data = _mapper.Map<List<Telecallerdto>>(telecaller);
            return new CommonResponse<List<Telecallerdto>>(true, "Telecaller fetched successfully", 200, data);

        }

        public async Task<CommonResponse<AddTelecallerdto>> GetTelecallerByIdAsync(int id)
        {
            if (id < 0)
            {
                return new CommonResponse<AddTelecallerdto>(false, "invalid id", 404, null);
            }
            var existingtelecaller = await _repository.GetSingleAsync(u => u.em_id == id && u.em_role_id == 2);
            if (existingtelecaller == null)
            {
                return new CommonResponse<AddTelecallerdto>(false, "user does not exist", 404, null);

            }
            var data = _mapper.Map<AddTelecallerdto>(existingtelecaller);
            return new CommonResponse<AddTelecallerdto>(true, "Telecaller fetched successfully", 200, data);

        }
    }

}
