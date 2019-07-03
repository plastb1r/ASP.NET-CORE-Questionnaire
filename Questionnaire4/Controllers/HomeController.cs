using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Questionnaire4.Models;

namespace Questionnaire4.Controllers
{
    public class HomeController : Controller
    {
        QuestionnaireContext db;
        Person person;
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
            for (int i = 0; i < Answer.Count; i++)
            {
                    db.Persons.Add( new Person {
                        PersonName = Name,
                        PersonAnswer = Answer[i].ToString(),
                        QuestionId = QId[i],
                        });
            }
            db.SaveChanges();
            return "Спасибо за ваш ответ, " + Name + "!";
        }

    }
}
