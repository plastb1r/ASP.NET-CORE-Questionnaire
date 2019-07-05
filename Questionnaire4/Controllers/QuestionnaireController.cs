using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Questionnaire4.Infrastructure;
using Questionnaire4.Models;


namespace Questionnaire4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionnaireController : ControllerBase
    {
        QuestionnaireContext db;
        public QuestionnaireController(QuestionnaireContext context)
        {
            db = context;
        }

        [HttpGet]
        [Route("questionList")]
        public ICollection<Question> GetQuestions()
        {
            return db.Questions.ToList();
        }

        [HttpGet]
        [Route("question/add/{question:minlength(5)}")]
        public String AddQuestion(string question)
        {
            db.Questions.Add(new Question { QuestionText = question + "?" });
            db.SaveChanges();
            return "Вопрос добавлен";
        }


        [HttpGet]
        [Route("person/{pId:int}")]
        public ICollection GetPerson(int pId)
        {
            List<Person> persons = db.Persons.ToList();
            List<Answer> answers = db.Answers.ToList();
            List<Question> questions = db.Questions.ToList();

            var QA = answers.Join(
                questions,
                a => a.QuestionId,
                q => q.QuestionId,
                (a, q) => new { a.PersonId, q.QuestionText, a.AnswerText });

            var getPersons = from p in persons
                      where p.PersonId == pId
                      select p;

            var getQA = QA.Join(
                 getPersons,
                 g => g.PersonId,
                 p => p.PersonId,
                 (g, p) => new { p.PersonName, g.QuestionText, g.AnswerText });


            return getQA.ToList();
        }
    }
}