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
        private readonly IMapper _mapper;

        public AddTelecaller(IApplicationRepository<tbl_employee_master> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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
            tbl_employee_master user = _mapper.Map<tbl_employee_master>(dto);
            user.em_created_date = DateTime.Now;
            user.em_role_id = 2;
            user.em_is_active = true;
            _repository.CreateAsync(user);

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
            var existingConnector = await _repository.GetSingleAsync(u => u.em_id == id);
            if (existingConnector == null)
            {
                return new CommonResponse<AddTelecallerdto>(false, "user does not exist", 404, null);

            }
            var data = _mapper.Map<AddTelecallerdto>(existingConnector);
            return new CommonResponse<AddTelecallerdto>(true, "Telecaller fetched successfully", 200, data);

        }
    }

}
