using Dapper;
using NowSoftwareTask.Interface;
using NowSoftwareTask.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace NowSoftwareTask.Repository
{
    public class UserRepo:IUserRepo
    {

        private readonly IConnectionFactory _connectionFactory;

        public UserRepo(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }


        public IList<User> GetAllUsers()
        {
            var EmpList = new List<User>();
            var SqlQuery = @"SELECT * from Task_User";

            using (IDbConnection conn = _connectionFactory.GetConnection)
            {
                var result = conn.Query<User>(SqlQuery);
                return result.ToList();
            }
        }


        public int AddUser(User user)
        {
            string procName = "SP_InsertUser";
            var param = new DynamicParameters();
            int UserID = 0;

            //param.Add("@UserID", User.ID, null, ParameterDirection.Output);
            param.Add("@FirstName", user.FirstName);
            param.Add("@LastName", user.LastName);
            param.Add("@UserName", "");
            param.Add("@Email", user.Email);
            param.Add("@MobileNumber", user.MobileNumber);
            param.Add("@IsActive", user.IsActive);
            

            try
            {
                SqlMapper.Execute(_connectionFactory.GetConnection,
                procName, param, commandType: CommandType.StoredProcedure);

               
            }
            finally
            {
                _connectionFactory.CloseConnection();
            }

            return UserID;
        }


        public bool UpdateUser(int UserID, User user)
        {
            string procName = "SP_UpdateUser";
            var param = new DynamicParameters();
            bool IsSuccess = true;

            param.Add("@ID", UserID, null, ParameterDirection.Input);
            param.Add("@FirstName", user.FirstName);
            param.Add("@LastName", user.LastName);
            param.Add("@UserName", "");
            param.Add("@Email", user.Email);
            param.Add("@MobileNumber", user.MobileNumber);
            param.Add("@IsActive", user.IsActive);

            try
            {
                var rowsAffected = SqlMapper.Execute(_connectionFactory.GetConnection,
                procName, param, commandType: CommandType.StoredProcedure);
                if (rowsAffected <= 0)
                {
                    IsSuccess = false;
                }
            }
            finally
            {
                _connectionFactory.CloseConnection();
            }

            return IsSuccess;
        }


        public User GetUserByID(int ID)
        {
            var user = new User();
            var procName = "SP_GetUserByID";
            var param = new DynamicParameters();
            param.Add("@ID", ID);

            try
            {
                using (var multiResult = SqlMapper.QueryMultiple(_connectionFactory.GetConnection,
                procName, param, commandType: CommandType.StoredProcedure))
                {
                    user = multiResult.ReadFirstOrDefault<User>();
                    
                }
            }
            finally
            {
                _connectionFactory.CloseConnection();
            }

            return user;
        }




        public User GetUserByQuery(String Query)
        {
            var user = new User();
            var procName = Query;
            var param = new DynamicParameters();
            

            try
            {
                using (var multiResult = SqlMapper.QueryMultiple(_connectionFactory.GetConnection,
                procName, param, commandType: CommandType.Text))
                {
                    user = multiResult.ReadFirstOrDefault<User>();

                }
            }
            finally
            {
                _connectionFactory.CloseConnection();
            }

            return user;
        }



    }
}
