using AutoMapper;
using AutoMapper.Configuration.Annotations;
using FluentAssertions.Common;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using model;
using services.Application_Services.User_Service.DTO;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace services.Application_Services.User_Service
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly DBConnection _context;
        private readonly IMapper _mapper;

        public UserService(IConfiguration configuration,DBConnection connection,IMapper mapper) 
        { 
            _configuration = configuration;
            _context = connection;
            _mapper = mapper;
        }

        public async Task<CommonResponse<UserDetails>> Login(string contact_number, string otp)
        {
            try
            {
                Console.WriteLine($"Searching for user with contact number: {contact_number}");
                var valid_user = await _context.tbl_user_login_details
                    .FirstOrDefaultAsync(x => x.uld_contact_number == contact_number);

                if (valid_user == null)
                {
                    return new CommonResponse<UserDetails>(false, "User not found", 404);
                }

                var userId = valid_user.uld_id;

                var valid_otp = await _context.tbl_user_login_details
                .FirstOrDefaultAsync(x => x.uld_id == userId && x.uld_is_active == true && x.uld_otp == otp);


                if (valid_otp == null)
                {
                    return new CommonResponse<UserDetails>(false, "Invalid OTP", 404);
                }

                //return new CommonResponse<UserDetails>(true, "valid_otp", 200, null);

                var token = CreateJwtSecurityToken(valid_otp.uld_id.ToString());

                var response = (from a in _context.tbl_user_login_details
                                join b in _context.tbl_employee_master on a.uld_employee_id equals b.em_id
                                join c in _context.tbl_role_master on b.em_role_id equals c.rm_id
                                where a.uld_id == valid_otp.uld_id
                                select new UserDetails
                                {
                                    user_id = b.em_id,
                                    user_name = b.em_name_e,
                                    user_contact_number = b.em_contact_number,
                                    user_role_id = (int)b.em_role_id,
                                    user_role = c.rm_name_e,
                                    token = token,
                                }).FirstOrDefault();
                return new CommonResponse<UserDetails>(true, "Success", 200, response);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CommonResponse<object>> SendOTP(string registered_mnumber)
        {
            try
            {
                Console.WriteLine("checking valid user");
                var valid_user = await _context.tbl_user_login_details
                    .FirstOrDefaultAsync(x => x.uld_contact_number == registered_mnumber);
                Console.WriteLine("checked valid user");

                if (valid_user == null)
                {
                    return new CommonResponse<object>(false,"User not found",404,null);
                }
                Console.WriteLine("verified valid user");



                valid_user.uld_otp = "1234";
                valid_user.uld_otp_time = DateTime.Now;

                await _context.SaveChangesAsync();
                return new CommonResponse<object>(true, "OTP sent successfully", 200);
            }catch(Exception ex)
            {
                return new CommonResponse<object>(false, $"Internal error: {ex.Message}", 500, null);

            }
        }

        public string CreateJwtSecurityToken(string post_id)
        {
            try
            {
                var authClaims = new List<Claim>
                {
                new Claim(ClaimTypes.NameIdentifier, post_id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddDays(10),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            catch (Exception ex)
            {               
                throw ;
            }
        }
    }
}
