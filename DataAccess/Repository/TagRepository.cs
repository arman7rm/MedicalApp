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
    public class TagRepository : ITagRepo
    {
        private readonly NewDataBaseContext _context;
        public TagRepository(NewDataBaseContext context)
        {
            _context = context;
        }
        public void Add(string t)
        {
            Tag tag = new Tag
            {
                term = t.ToLower()
            };
            _context.Tags.Add(tag);
            _context.SaveChanges();
        }

        public void Delete(string val)
        {
            var entity = _context.Tags.First(t => t.term.Equals(val.ToLower()));
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            _context.Tags.Remove(entity);
            _context.SaveChanges();
        }
    }
}
