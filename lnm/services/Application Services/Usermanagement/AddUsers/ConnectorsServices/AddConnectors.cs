using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using model;
using model.MOUs;
using services.Application_Services.Usermanagement.AddUsers.Connectors.DTO;
using services.Application_Services.Usermanagement.AddUsers.ConnectorsServices.DTO;
using services.Application_Services.Usermanagement.Connectors.DTO;
using services.Repository;
using model.User;

namespace services.Application_Services.Usermanagement.AddUsers.Connectors
{
    public class AddConnectors : IAddConnectors
    {
        private readonly IApplicationRepository<tbl_employee_master> _repository;
        private readonly IApplicationRepository<tbl_user_login_details> _loginrepository;


        private readonly IMapper _mapper;

        public AddConnectors(IApplicationRepository<tbl_employee_master> repository,IApplicationRepository<tbl_user_login_details> loginrepository ,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _loginrepository = loginrepository;
        }
        public async Task<CommonResponse<AddConnectordto>> CreateConnectorAsync(AddConnectordto dto)
        {
            if (dto == null)
            {
                return new CommonResponse<AddConnectordto>(false, "Error", 404, null);
            }

            var existingConnector = await _repository.GetSingleAsync(u => u.em_id == dto.connector_id);
            if (existingConnector != null)
            {
                return new CommonResponse<AddConnectordto>(false, "user already exist", 400, null);
            }

            tbl_employee_master user = _mapper.Map<tbl_employee_master>(dto);
            user.em_created_date = DateTime.Now;
            user.em_is_active = true;

            await _repository.CreateAsync(user); 

            tbl_user_login_details loginDetails = new tbl_user_login_details
            {
                uld_contact_number = user.em_contact_number,
                uld_created_date = DateTime.Now,
                uld_otp_time = DateTime.Now.AddMinutes(5),
                uld_employee_id = user.em_id, 
                uld_is_active = true,
            };

            await _loginrepository.CreateAsync(loginDetails); 

            return new CommonResponse<AddConnectordto>(true, "Connector created successfully", 200, dto);
        }

        public async Task<CommonResponse<AddConnectordto>> UpdateConnectorAsync(AddConnectordto dto)
        {
            if (dto == null)
            {
                return new CommonResponse<AddConnectordto>(false, "fields are empty", 404, null);
            }
            var existingConnector = await _repository.GetSingleAsync(u => u.em_id == dto.connector_id);
            if (existingConnector == null)
            {
                return new CommonResponse<AddConnectordto>(false, "connnector does not exist", 404, null);
            }

            _mapper.Map(dto,existingConnector);
            existingConnector.em_updated_date = DateTime.Now;

            await _repository.UpdateAsync(existingConnector);
            return new CommonResponse<AddConnectordto>(true, "connector details updated successfully", 201, dto);

        }

        public async Task<CommonResponse<object>> DeleteConnectorAsync(int id)
        {
            if (id <= 0)
            {
                return new CommonResponse<object>(false, "Enter a valid employee ID", 404, null);
            }

            var existingConnector = await _repository.GetSingleAsync(u => u.em_id == id);
            if (existingConnector == null)
            {
                return new CommonResponse<object>(false, "Cannot find user", 404, null);
            }

            await _repository.DeleteAsync(existingConnector);
            return new CommonResponse<object>(true, "Connector deleted successfully", 200, null);
        }


        public async Task<CommonResponse<List<Connectordto>>> GetAllConnectorAsync()
        {
            var connectors = await _repository.GetAllAsync();
            var data = _mapper.Map<List<Connectordto>>(connectors);
            return new CommonResponse<List<Connectordto>>(true, "connectors fetched successfully", 200, data);

        }
      
        public async Task<CommonResponse<AddConnectordto>> GetConnectorByIdAsync(int id)
        {
            if (id < 0)
            {
                return new CommonResponse<AddConnectordto>(false, "invalid id", 404, null);
            }
            var existingConnector = await _repository.GetSingleAsync(u => u.em_id == id);
            if (existingConnector == null)
            {
                return new CommonResponse<AddConnectordto>(false, "user does not exist", 404, null);

            }
            var data = _mapper.Map<AddConnectordto>(existingConnector);
            return new CommonResponse<AddConnectordto>(true, "connector fetched successfully", 200, data);

        }

        public async Task<CommonResponse<object>> GetConnectorMouByIdAsync(float version) //===================================== pending 
        {//===============================================================================  NEED TO USE LINQ here ========================
            if (version < 0) {
                return new CommonResponse<object>(false,"invalid input credentials",404,null);
            }
            var mou = await _repository.GetSingleAsync(u=>u.em_id==version);
            if (mou == null) {
                return new CommonResponse<object>(false, "mou does not exist", 404, null);
                }

            return new CommonResponse<object>(true,"mou fetched successfully",200,mou);
        }
        //========================================================================================================================== |
        //   sub connector CRUD operations by Connector                                                                                                                          V
        //
        //                                                                               

        public async Task<CommonResponse<AddSubConnectordto>> CreateSubConnectorAsync(AddSubConnectordto dto)
        {
            if (dto == null)
            {
                return new CommonResponse<AddSubConnectordto>(false,"invalid input credentials",404,null);
            }
            var existingSubConnector = await _repository.GetSingleAsync(u=>u.em_id == dto.employee_id);

            if (existingSubConnector != null)
            {
                return new CommonResponse<AddSubConnectordto>(false, "sub connector already exist", 400, null);
            }
            tbl_employee_master subconnector = _mapper.Map<tbl_employee_master>(dto);

            subconnector.em_created_date = DateTime.Now;

            subconnector.em_updated_date = DateTime.Now;
            
            subconnector.em_created_by = dto.created_emp_id;

            return new CommonResponse<AddSubConnectordto>(true,"sub connector created successfully",201,dto);

        }

        public async Task<CommonResponse<AddSubConnectordto>> UpdateSubConnectorAsync(AddSubConnectordto dto)
        {
            if(dto == null)
            {
                return new CommonResponse<AddSubConnectordto>(false,"invalid input credentials",404,null);
            }
            var existingSubConnector = await _repository.GetSingleAsync(u=>u.em_id == dto.employee_id);

            if(existingSubConnector == null)
            {
                return new CommonResponse<AddSubConnectordto>(false,"sub connector does not exist",400,null);
            }
            _mapper.Map(dto,existingSubConnector);
            
            existingSubConnector.em_updated_date = DateTime.Now;

            await _repository.UpdateAsync(existingSubConnector);
            
            return new CommonResponse<AddSubConnectordto>(true, "sub connector updated successfully", 203, dto);
        }

        public async Task<CommonResponse<AddSubConnectordto>> DeleteSubConnectorAsync(int id)
        {
            if (id < 0)
            {
                return new CommonResponse<AddSubConnectordto>(false, "invalid input id", 404, null);
            }
            var existingSubConnector = await _repository.GetSingleAsync(u=>u.em_id==id);

            if(existingSubConnector == null)
            {
                return new CommonResponse<AddSubConnectordto>(false,"user not found",400,null);
            }
            await _repository.DeleteAsync(existingSubConnector);

            return new CommonResponse<AddSubConnectordto>(true,"sub connector deleted successfully",200,null);
        }

        public async Task<CommonResponse<List<SubConnectordto>>> GetAllSubConnectorsAsync()
        {
            var subconnectors = await _repository.GetAllAsync();
            
            var data = _mapper.Map<List<SubConnectordto>>(subconnectors);
            
            return new CommonResponse<List<SubConnectordto>>(true,"subconnectors fetched successfully",200,data);
        }

        public async Task<CommonResponse<SubConnectordto>> GetSubConnectorAsync(int id)
        {
            if(id < 0){

                return new CommonResponse<SubConnectordto>(false,"invalid id",404,null);
            }
            var existingSubconnector = await _repository.GetSingleAsync(u=>u.em_id==id);
            
            if (existingSubconnector == null) {

                return new CommonResponse<SubConnectordto>(false,"sub connector does not exist",400,null);
            }
            var data = _mapper.Map<SubConnectordto>(existingSubconnector);

            return new CommonResponse<SubConnectordto>(true, "sub connector fetched succesfully", 200, data);
        }

       



    }
}
