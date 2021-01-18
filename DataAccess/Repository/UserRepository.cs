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
            var entity = new User
            {
                Username = newUser.UserName,
                Pass = newUser.PassWord,
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Email = newUser.Email,
                City = newUser.City.ToLower(),
                State = newUser.State,
                Phone = newUser.Phone
            };
            _context.Users.Add(entity);
            _context.SaveChanges();
            return entity.UserId;
        }

        public void Delete(int Id)
        {
            var entity = _context.Users.Find(Id);
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            _context.Users.Remove(entity);
            _context.SaveChanges();
        }

        public d.User Get(int Id)
        {
            var entity = _context.Users.Find(Id);
            return new d.User
            {
                UserId = entity.UserId,
                UserName = entity.Username,
                PassWord = entity.Pass,
                FirstName = entity.FirstName,
                LastName = entity.LastName, 
                Email = entity.Email,
                City = entity.City,
                State = entity.State,
                Phone = entity.Phone
            };
        }

        public int Update(d.User newUser)
        {
            var entity = _context.Users.Find(newUser.UserId);
            entity.FirstName = newUser.FirstName;
            entity.LastName = newUser.LastName;
            entity.Username = newUser.UserName;
            entity.Pass = newUser.PassWord;
            entity.City = newUser.City;
            entity.State = newUser.State;
            entity.Phone = newUser.Phone;
            entity.Email = newUser.Email;
            _context.Users.Update(entity);
            _context.SaveChanges();
            return entity.UserId;
        }
    }
}
