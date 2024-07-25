using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShopAPI.DataContext;
using ShopAPI.DTOs.AccountDTOs;
using ShopAPI.Helper.Email;
using ShopAPI.Models;

namespace ShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ClassDbContext _classDbContext;
        private readonly IMapper _mapper;
        private readonly EmailService _emailService;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        public AccountsController(ClassDbContext classDbContext, IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, EmailService emailService)
        {
            _signInManager = signInManager;
            _classDbContext = classDbContext;
            _mapper = mapper;
            _userManager = userManager;
            _emailService = emailService;
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register(AccountDTO accountDTO)
        {

            AppUser user =  _mapper.Map<AppUser>(accountDTO);
            

            await _classDbContext.SaveChangesAsync();
            var results = await _userManager.CreateAsync(user, accountDTO.Password);
            if (!results.Succeeded)
            {

                return BadRequest("Emeliyyat Ugursuzdur");
            }

            await _classDbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(AccountDTO accountDTO )
        {
            AppUser appUser = await _userManager.FindByNameAsync(accountDTO.Username);
            if (appUser == null)
            {

                return BadRequest("Username  Movcud deyil...");

            }
            var result = await _signInManager.PasswordSignInAsync(accountDTO.Username, accountDTO.Password, true, false);
            if (!result.Succeeded)
            {
                return BadRequest("Sifre Yalnisdir");

            }
            EmailData emailData = new EmailData();
            EmailData data = _mapper.Map<EmailData>(emailData);
            _emailService.EmailSender(emailData);
            return Ok("Xosh Geldiniz!");





        }


    }
}
