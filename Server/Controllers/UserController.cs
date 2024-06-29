using ESProjeto.Server.Models;
using Microsoft.AspNetCore.Identity;
using ESProjeto.Shared.Patterns;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using ESProjeto.Shared;
using Microsoft.AspNetCore.Mvc;
using ESProjeto.Client.Pages;

namespace ESProjeto.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private EventHandler<CompetitionStatus> Handler { get; set; }
        private IHttpContextAccessor _httpContextAccessor;


        public IObservable Observable { get; set; }

        public UserController(UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task CreateUser(ApplicationUser user, string password)
        {
            await _userManager.CreateAsync(user, password);
        }

        public async Task<ApplicationUser> GetUserById(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<ApplicationUser> GetUserByUsername(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }

        [HttpGet("current-user-id")]
        public async Task<string> GetCurrentUserId()
        {
            var user = _httpContextAccessor.HttpContext.User;
            Console.WriteLine(" USER DATA : " + user);
            throw new Exception("Current user not found.");
        }

        //OSERVER

        public void Subscribe(IObservable observable)
        {
            Observable = observable;
            Observable.NotifyStatus += Handler;
        }

        public void Unsubscribe()
        {
            if (Observable == null) return;
            Observable.NotifyStatus -= Handler;
        }


    }
}
