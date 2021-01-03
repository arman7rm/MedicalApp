using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IReviewRepo
    {
        int Add(Review newReview);
        IEnumerable<Review> GetReviews(int DoctorId);
        void Delete(int Id);
        void Update(Review newReview);
    }
}
