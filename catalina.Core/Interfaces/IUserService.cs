using catalina.Repositories.Entities;
using catalina.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace catalina.Core.Interfaces
{
    public interface IUserService
    {
        User PostUser(UserPostVM user);
    }
}
