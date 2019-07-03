using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questionnaire4.Models
{
    public class QuestionnaireContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Person> Persons { get; set; }

        public QuestionnaireContext(DbContextOptions<QuestionnaireContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
