using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Domain.Interfaces;
using d = Domain.Models;
using DataAccess.Models;

namespace DataAccess.Repository
{
    public class UserRepository : IUserRepo
    {
        private readonly NewDataBaseContext _context;
        public UserRepository(NewDataBaseContext context)
        {
            _context = context;
        }
        public int Add(d.User newUser)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public d.User Get(int Id)
        {
            throw new NotImplementedException();
        }

        public int Update(d.User newUser)
        {
            throw new NotImplementedException();
        }
    }
}
