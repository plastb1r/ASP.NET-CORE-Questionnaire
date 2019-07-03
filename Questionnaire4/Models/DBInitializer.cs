using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questionnaire4.Models
{
    public class DBInitializer
    {
        public static void Initialize(QuestionnaireContext context)
        {
            if (!context.Questions.Any())
            {
                context.Questions.AddRange(
                    new Question
                    {
                        QuestionText = "сколько вам лет?",
                    },
                    new Question
                    {
                        QuestionText = "Кем вы работаете?",
                    },
                    new Question
                    {
                        QuestionText = "У вас есть хобби?",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
