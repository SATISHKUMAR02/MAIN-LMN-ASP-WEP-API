using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using model;
using services.Application_Services.Usermanagement.AddUsers.Connectors.DTO;
using services.Application_Services.Usermanagement.Connectors.DTO;
using services.Repository;
using services.User;

namespace services.Application_Services.Usermanagement.AddUsers.Connectors
{
    public class AddConnectors : IAddConnectors
    {
        private readonly IApplicationRepository<tbl_employee_master> _repository;
        private readonly IMapper _mapper;

        public AddConnectors(IApplicationRepository<tbl_employee_master> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CommonResponse<AddConnectordto>> CreateConnectorAsync(AddConnectordto dto)
        {
            if (dto == null)
            {

                //throw new Exception("no body");
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
            var connectorToUpdate = _mapper.Map<tbl_employee_master>(dto);
            connectorToUpdate.em_updated_date = DateTime.Now;

            await _repository.UpdateAsync(connectorToUpdate);
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
    }
}
