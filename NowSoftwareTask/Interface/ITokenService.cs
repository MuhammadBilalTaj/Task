﻿using NowSoftwareTask.Models;


namespace NowSoftwareTask.Interface
{
   public interface ITokenService
    {
        string BuildToken(string key, string issuer, User user);
        //string GenerateJSONWebToken(string key, string issuer, UserDTO user);
        bool IsTokenValid(string key, string issuer, string token);
    }
}
