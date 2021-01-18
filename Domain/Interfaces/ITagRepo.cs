using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface ITagRepo
    {
        void Add(string term);
        void Delete(string term);

    }
}
