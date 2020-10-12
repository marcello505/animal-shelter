using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DomainServices
{
    public interface ICommentRepository
    {
        public IEnumerable<Comment> GetAll();
        public void Add(Comment comment);
        public void Update(Comment comment);
        public void Delete(int id);

    }
}
