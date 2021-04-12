using CoursePlanner.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursePlanner.Data
{
    public class CoursePlannerDbContext : DbContext
    {
        public CoursePlannerDbContext(DbContextOptions<CoursePlannerDbContext> options) : base(options) { }
        public DbSet<CourseViewModel> CourseViewModel { get; set; }
        public DbSet<TeacherViewModel> TeacherViewModel { get; set; }
        public DbSet<TopicViewModel> TopicViewModel { get; set; }
    }
}
