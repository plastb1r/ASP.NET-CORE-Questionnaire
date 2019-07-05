using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Questionnaire4.Infrastructure;
using Questionnaire4.Models;

namespace Questionnaire4.Controllers
{
    public class HomeController : Controller
    {
        QuestionnaireContext db;
        public HomeController(QuestionnaireContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Questions()
        {
            return View(db.Questions.ToList());
        }
        [HttpPost]
        public string Questions(string Name,List<String> Answer, List<Int32> QId)
        {
            db.Persons.Add(new Person { PersonName = Name });
            for (int i = 0; i < Answer.Count; i++)
            {
                db.Answers.Add(new Answer
                {
                    AnswerText = Answer[i],
                    PersonId = db.Persons.Count() + 1,
                    QuestionId = QId[i]
                    
                });
            }
            db.SaveChanges();
            return "Спасибо за ваш ответ, " + Name + "!";
        }

    }
}
