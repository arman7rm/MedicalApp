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
            var entity = new Review
            {
                DoctorId = newReview.DoctorId,
                UserId = newReview.UserId,
                Rating = newReview.Rating,
                Review1 = newReview.Content
            };
            _context.Reviews.Add(entity);
            _context.SaveChanges();
            return entity.ReviewId;
        }

        public void Delete(int Id)
        {
            var entity = _context.Reviews.Find(Id);
            if(entity == null)
            {
                throw new ArgumentNullException();
            }
            _context.Reviews.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<d.Review> GetReviews(int DoctorId)
        {
            var entities = _context.Reviews
                .Where(r => r.DoctorId==DoctorId);
            return entities.Select(m => new d.Review
            {
                ReviewId = m.ReviewId,
                Rating = m.Rating,
                Content = m.Review1,
                DoctorId = m.DoctorId,
                UserId = m.UserId
            });
        }

        public void Update(d.Review newReview)
        {
            var entity = _context.Reviews.Find(newReview.ReviewId);
            entity.DoctorId = newReview.DoctorId;
            entity.UserId = newReview.UserId;
            entity.Rating = newReview.Rating;
            entity.Review1 = newReview.Content;
            _context.Reviews.Update(entity);
            _context.SaveChanges();
        }
    }
}
