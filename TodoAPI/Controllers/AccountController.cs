using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TodoAPI.DTO;
using TodoAPI.Models;
using TodoAPI.Repository;

namespace TodoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        
        public IMapper _mapper { get; }
        IAccountRepository _repo;
        public AccountController( IAccountRepository accRepo,
                                 IMapper mapper)
        {
            _repo = accRepo;
            _mapper = mapper;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Register(SignUpDTO userDTO)
        {
            /*var user = new ApplicationUser()
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Email = userDTO.Email,
                UserName = userDTO.Email
            };*/

            var user = _mapper.Map<ApplicationUser>(userDTO);

            var val = await _repo.SignUpUserAsync(user, userDTO.Password);
            return Ok();
        }
    }
}
