using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IRatingRepo
    {
        int Add(Rating newRating);
        double GetRating(int DoctorId);
    }
}
