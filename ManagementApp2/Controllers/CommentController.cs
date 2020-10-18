using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DomainServices;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ManagementApplication.Controllers
{
    public class CommentController : Controller
    {
        private readonly ILogger<CommentController> _logger;
        private readonly ICommentRepository _context;
        public CommentController(ILogger<CommentController> logger, ICommentRepository context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: CommentController/Create
        [Authorize]
        public ActionResult Create(int id)
        {
            return View(new Comment { Id = 0, AnimalId = id});
        }

        // POST: CommentController/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Comment comment)
        {
            comment.Id = 0;
            comment.DateOfComment = DateTime.Now;
            comment.CommentMadeBy = User.Identity.Name;
            _context.Add(comment);
            return RedirectToAction("Details", "Animal", new { id = comment.AnimalId });
        }

    }
}
