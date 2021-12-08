using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using NowSoftwareTask.Interface;
using NowSoftwareTask.Models;

namespace NowSoftwareTask.Pages.Account
{
    public class LoginModel : PageModel
    {

        private readonly IUserRepo _UserRepo;

        public LoginModel(IUserRepo UserRepo)
        {
            _UserRepo = UserRepo;
        }



        [BindProperty]
        public credentials credential { get; set; }





        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            string UserName=credential.UserName;
            string Pass = credential.Password;

            if (ModelState.IsValid)
            {
                var User = authenticateUser(credential.UserName, credential.Password);

                if (User != null)
                {
                    return LocalRedirect("/UserList/ListOfUsers");
                    // RedirectToAction("ListOfUsers", "UserList");
                }
            }
            return LocalRedirect("/Error");


        }



        public User authenticateUser(string UserName,string Pass)
        {
            var User = _UserRepo.GetUserByQuery(@"SELECT * FROM [Now].[dbo].[Task_User] where UserName='" + UserName + "' And Password='" + Pass + "'");
            return User;
        }


        
    }


    public class credentials
    {
        [Required(ErrorMessage = "User Name is required.")]
        [Display(Name ="User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}