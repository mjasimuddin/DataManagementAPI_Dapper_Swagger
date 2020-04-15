using DataManagement.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataManagement.Repository.Interfaces
{
    public interface IAuthenticateService
    {
        User Authenticate(string username, string password);
    }
}
