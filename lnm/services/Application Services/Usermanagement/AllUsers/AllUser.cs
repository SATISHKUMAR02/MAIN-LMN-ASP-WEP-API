using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using model;
using services.Application_Services.Usermanagement.AllUsers.DTO;
using services.Repository;
using model.User;

namespace services.Application_Services.Usermanagement.AllUsers
{
    public class AllUser : IAllUser
    {
        private readonly IApplicationRepository<tbl_employee_master> _repository;
        private readonly IMapper _mapper;
        public AllUser(IApplicationRepository<tbl_employee_master> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CommonResponse<AllUserdto>> GetEmployeeByIdAsync(int id)
        {
            if (id < 0)
            {
                return new CommonResponse<AllUserdto>(false, "invlalid id",404,null);
            }
            var employee = await _repository.GetSingleAsync(u=>u.em_id == id);

            if (employee == null) {

                return new CommonResponse<AllUserdto>(false,"Employee does not exist",404,null);
            }
            var response = _mapper.Map<AllUserdto>(employee);

            return new CommonResponse<AllUserdto>(true, "Employee fetched successfully",200,response);

        }

       

    }
}
