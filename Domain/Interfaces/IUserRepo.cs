using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IUserRepo
    {
        int Add(User newUser);
        User Get(int Id);
        int Update(User newUser);
        void Delete(int Id);
    }
}
