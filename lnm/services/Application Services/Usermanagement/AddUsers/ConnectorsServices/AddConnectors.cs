using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Newtonsoft.Json;

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

            var existingConnector = await _repository.GetSingleAsync(u => u.em_id == dto.connector_id || u.em_contact_number == dto.phonenumber);
            if (existingConnector != null)
            {
                return new CommonResponse<AddConnectordto>(false, "user already exist", 400, null);
            }

            // Manual mapping
            tbl_employee_master user = new tbl_employee_master
            {
                em_id = dto.connector_id,
                em_name_e = dto.Firstname + " " + dto.Lastname,
                em_contact_number = dto.phonenumber,
                em_email_address = dto.Email,
                em_joining_date = dto.hireDate,
                em_updated_date = dto.updated_date,
                em_gender = dto.gender,
                //dob = DateOnly.FromDateTime(dto.dateOfbirth),
                em_created_date = DateTime.Now,
                em_role_id = 1,
                em_is_active = true
            };

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

        public async Task<CommonResponse<object>> DeleteTempConnectorAsync(int id)
        {
            if (id <= 0)
            {
                return new CommonResponse<object>(false, "fields are empty", 404, null);
            }
            var existingConnector = await _repository.GetSingleAsync(u => u.em_id == id && u.em_is_active==true);
            if (existingConnector == null)
            {
                return new CommonResponse<object>(false, "connnector does not exist", 404, null);
            }


            existingConnector.em_is_active = false;
            await _repository.UpdateAsync(existingConnector);

            var logindetails = await _loginrepository.GetSingleAsync(u => u.uld_employee_id == id);
            if (logindetails == null)
            {
                return new CommonResponse<object>(false, "connnector does not exist", 404, null);
            }
            logindetails.uld_is_active = false;
            await _loginrepository.UpdateAsync(logindetails);
            return new CommonResponse<object>(true, "connector details deleted successfully", 200, null);

        }





        public async Task<CommonResponse<object>> DeleteConnectorAsync(int id)
        {
            if (id <= 0)
            {
                return new CommonResponse<object>(false, "Enter a valid employee ID", 404, null);
            }

            var existingConnector = await _repository.GetSingleAsync(u => u.em_id == id && u.em_is_active ==true);
            if (existingConnector == null)
            {
                return new CommonResponse<object>(false, "Cannot find user", 404, null);
            }

            await _repository.DeleteAsync(existingConnector);
            //await _loginrepository.DeleteAsync(existingConnector);

            var loginrecord = await _repository.GetSingleAsync(u=>u.em_id==id && u.em_is_active == true);
            
            if (loginrecord == null)
            {
                return new CommonResponse<object>(false, "Cannot find user", 404, null);
            }

            await _repository.DeleteAsync(loginrecord);
            return new CommonResponse<object>(true, "Connector deleted successfully", 200, null);

        }


        public async Task<CommonResponse<List<Connectordto>>> GetAllConnectorAsync()
        {
            var connectors = await _repository.GetAllByAnyAsync(u=>u.em_is_active==true && u.em_role_id == 1);
            var data = _mapper.Map<List<Connectordto>>(connectors);
            return new CommonResponse<List<Connectordto>>(true, "connectors fetched successfully", 200, data);

        }
      
        public async Task<CommonResponse<AddConnectordto>> GetConnectorByIdAsync(int id)
        {
            if (id < 0)
            {
                return new CommonResponse<AddConnectordto>(false, "invalid id", 404, null);
            }
            var existingConnector = await _repository.GetSingleAsync(u => u.em_id == id && u.em_role_id==1);
            Console.WriteLine(JsonConvert.SerializeObject(existingConnector));

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
            tbl_employee_master subconnector = new tbl_employee_master
            {
                em_id = dto.employee_id,
                em_name_e = dto.FirstName,
                em_name_k = dto.LastName,
                em_contact_number = dto.phoneNo,
                em_email_address = dto.Email,
                em_updated_date = dto.updated_date,
                em_gender = dto.Gender,
                em_created_by = dto.created_by,
                //dob = DateOnly.FromDateTime(dto.dateOfbirth),
                em_created_date = DateTime.Now,
                em_role_id = 4,
                em_is_active = true
            };
            
            await _repository.CreateAsync(subconnector);

            tbl_user_login_details loginDetails = new tbl_user_login_details
            {
                uld_contact_number = subconnector.em_contact_number,
                uld_created_date = DateTime.Now,
                
                uld_otp_time = DateTime.Now.AddMinutes(5),
                uld_employee_id = subconnector.em_id,
                uld_is_active = true,
            };
            await _loginrepository.CreateAsync(loginDetails);

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

        public async Task<CommonResponse<object>> DeleteTempSubConnectorAsync(int id)
        {
            if (id <= 0)
            {
                return new CommonResponse<object>(false, "fields are empty", 404, null);
            }
            var existingSubConnector = await _repository.GetSingleAsync(u => u.em_id == id && u.em_role_id == 4);
            if (existingSubConnector == null)
            {
                return new CommonResponse<object>(false, "subconnnector does not exist", 404, null);
            }


            existingSubConnector.em_is_active = false;
            await _repository.UpdateAsync(existingSubConnector);

            var logindetails = await _loginrepository.GetSingleAsync(u => u.uld_employee_id == id);
            if (logindetails == null)
            {
                return new CommonResponse<object>(false, "subconnnector does not exist", 404, null);
            }
            logindetails.uld_is_active=false;
            await _loginrepository.UpdateAsync(logindetails);



            return new CommonResponse<object>(true, "subconnector details deleted successfully", 200, null);

        }



        public async Task<CommonResponse<List<SubConnectordto>>> GetAllSubConnectorsAsync()
        {
            var subconnectors = await _repository.GetAllByAnyAsync(u=>u.em_role_id==4 && u.em_is_active ==true);
            
            var data = _mapper.Map<List<SubConnectordto>>(subconnectors);
            
            return new CommonResponse<List<SubConnectordto>>(true,"subconnectors fetched successfully",200,data);
        }

        public async Task<CommonResponse<AddSubConnectordto>> GetSubConnectorAsync(int id)
        {
            if(id < 0){

                return new CommonResponse<AddSubConnectordto>(false,"invalid id",404,null);
            }
            var existingSubconnector = await _repository.GetSingleAsync(u=>u.em_id==id);
            
            if (existingSubconnector == null) {

                return new CommonResponse<AddSubConnectordto>(false,"sub connector does not exist",400,null);
            }
            var data = _mapper.Map<AddSubConnectordto>(existingSubconnector);

            return new CommonResponse<AddSubConnectordto>(true, "sub connector fetched succesfully", 200, data);
        }

       



    }
}
