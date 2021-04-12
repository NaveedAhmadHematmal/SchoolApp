using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoursePlanner.Data;
using CoursePlanner.Models;

namespace CoursePlanner.Controllers
{
    [Route("[Controller]")]
    public class TopicController : Controller
    {
        private readonly CoursePlannerDbContext _context;

        public TopicController(CoursePlannerDbContext context)
        {
            _context = context;
        }

        // GET: Topic
        [Route("Index")]
        [Route("")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.TopicViewModel.ToListAsync());
        }

        // GET: Topic/Details/5
        [Route("Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topicViewModel = await _context.TopicViewModel
                .FirstOrDefaultAsync(m => m.TopicId == id);
            if (topicViewModel == null)
            {
                return NotFound();
            }

            return View(topicViewModel);
        }

        // GET: Topic/Create
        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Topic/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create")]
        public async Task<IActionResult> Create([Bind("TopicId,Topic,Details,CodeSnippetsLink,Assignment,Remarks")] TopicViewModel topicViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(topicViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(topicViewModel);
        }

        // GET: Topic/Edit/5
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topicViewModel = await _context.TopicViewModel.FindAsync(id);
            if (topicViewModel == null)
            {
                return NotFound();
            }
            return View(topicViewModel);
        }

        // POST: Topic/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("TopicId,Topic,Details,CodeSnippetsLink,Assignment,Remarks")] TopicViewModel topicViewModel)
        {
            if (id != topicViewModel.TopicId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(topicViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TopicViewModelExists(topicViewModel.TopicId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(topicViewModel);
        }

        // GET: Topic/Delete/5
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var topicViewModel = await _context.TopicViewModel
                .FirstOrDefaultAsync(m => m.TopicId == id);
            if (topicViewModel == null)
            {
                return NotFound();
            }

            return View(topicViewModel);
        }

        // POST: Topic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var topicViewModel = await _context.TopicViewModel.FindAsync(id);
            _context.TopicViewModel.Remove(topicViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TopicViewModelExists(int id)
        {
            return _context.TopicViewModel.Any(e => e.TopicId == id);
        }
    }
}
