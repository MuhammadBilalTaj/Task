using NowSoftwareTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NowSoftwareTask.Interface
{
   public interface IUserRepo
    {
        IList<User> GetAllUsers();
        User GetUserByID(int UserID);
        int AddUser(User User);
        bool UpdateUser(int UserID, User User);

        User GetUserByQuery(string Query);


    }
}
