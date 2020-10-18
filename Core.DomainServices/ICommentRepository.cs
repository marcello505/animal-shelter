using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.DomainServices
{
    public interface ICommentRepository
    {
        public IEnumerable<Comment> GetAll();
        public Task Add(Comment comment);

    }
}
