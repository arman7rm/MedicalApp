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
    public class ReviewRepository : IReviewRepo
    {
        private readonly NewDataBaseContext _context;
        public ReviewRepository(NewDataBaseContext context)
        {
            _context = context;
        }
        public int Add(d.Review newReview)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<d.Review> GetReviews(int DoctorId)
        {
            throw new NotImplementedException();
        }

        public void Update(d.Review newReview)
        {
            throw new NotImplementedException();
        }
    }
}
