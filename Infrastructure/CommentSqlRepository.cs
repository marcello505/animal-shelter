using Core.DomainServices;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class CommentSqlRepository : ICommentRepository
    {
        private AnimalShelterSqlContext _context;
        public CommentSqlRepository()
        {
            _context = new AnimalShelterSqlContext();            
        }
        public async Task Add(Comment comment)
        {
            _context.Add(comment);
            await _context.SaveChangesAsync();
        }

        public IEnumerable<Comment> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
