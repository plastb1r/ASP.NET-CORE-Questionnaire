using Microsoft.EntityFrameworkCore;
using Questionnaire4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questionnaire4.Infrastructure
{
    public class QuestionnaireContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public QuestionnaireContext(DbContextOptions<QuestionnaireContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
