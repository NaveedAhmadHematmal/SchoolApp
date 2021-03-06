using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoursePlanner.Data;
using CoursePlanner.Models;
using Microsoft.AspNetCore.Authorization;

namespace CoursePlanner.Controllers
{
    [Route("[Controller]")]
    public class CourseController : Controller
    {
        private readonly CoursePlannerDbContext _context;

        public CourseController(CoursePlannerDbContext context)
        {
            _context = context;
        }

        // GET: Course
        [Route("{id}")]
        [Route("Index/{id}")]
        [Route("Index")]
        [Route("")]
        [Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> Index(int? id)
        {
            if (id != null)
            {
                return View(await _context.CourseViewModel.Where(x => x.CourseId == id ).ToListAsync());
            }
            else
            {
                return View(await _context.CourseViewModel.ToListAsync());
            }
        }

        // GET: Course/Details/5
        [Route("Details")]
        [Authorize(Roles = "User, Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseViewModel = await _context.CourseViewModel
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (courseViewModel == null)
            {
                return NotFound();
            }

            return View(courseViewModel);
        }

        // GET: Course/Create
        [Authorize(Roles = "Admin")]
        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Create")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("CourseId,CourseName,Time,StartDate,EndDate")] CourseViewModel courseViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(courseViewModel);
        }

        // GET: Course/Edit/5
        [Route("Edit/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseViewModel = await _context.CourseViewModel.FindAsync(id);
            if (courseViewModel == null)
            {
                return NotFound();
            }
            return View(courseViewModel);
        }

        // POST: Course/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Edit/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("CourseId,CourseName,Time,StartDate,EndDate")] CourseViewModel courseViewModel)
        {
            if (id != courseViewModel.CourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseViewModelExists(courseViewModel.CourseId))
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
            return View(courseViewModel);
        }

        // GET: Course/Delete/5
        [Route("Delete/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseViewModel = await _context.CourseViewModel
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (courseViewModel == null)
            {
                return NotFound();
            }

            return View(courseViewModel);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("Delete/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courseViewModel = await _context.CourseViewModel.FindAsync(id);
            _context.CourseViewModel.Remove(courseViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseViewModelExists(int id)
        {
            return _context.CourseViewModel.Any(e => e.CourseId == id);
        }
    }
}
