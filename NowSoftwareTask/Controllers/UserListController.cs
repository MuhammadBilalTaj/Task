using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NowSoftwareTask.Interface;
using NowSoftwareTask.Models;

namespace NowSoftwareTask.Controllers
{
    public class UserListController : Controller
    {
        private readonly IUserRepo _UserRepo;
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _config;

        public UserListController(IUserRepo UserRep, ITokenService tokenService, IConfiguration config)
        {
            _UserRepo = UserRep;
            _tokenService = tokenService;
            _config = config;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListOfUsers()
        {
            return View();
        }

        [HttpGet]
        public JsonResult Users()
        {
            var users = _UserRepo.GetAllUsers();            
            return Json(users);
        }
        [HttpGet]
        public JsonResult GetUserByID(int ID)
        {
            var UserBYID = _UserRepo.GetUserByID(ID);
            return Json(UserBYID);
        }

        [HttpPost]
        [Authorize]
        public IActionResult EditUser(User UserData)
        {
            string token = HttpContext.Session.GetString("Token");

            if (token == null)
            {
                return (RedirectToAction("/Account/Login"));
            }

            if (!_tokenService.IsTokenValid(_config["Jwt:Key"].ToString(),
                _config["Jwt:Issuer"].ToString(), token))
            {
                return (RedirectToAction("/Account/Login"));
            }
            bool IsUpdated=_UserRepo.UpdateUser(UserData.id, UserData);
            return Json("");
        }

        [HttpPost]
       
        public JsonResult Create(User UserData)
        {
            _UserRepo.AddUser(UserData);
            return Json("User Added");
        }




    }
}