﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questionnaire4.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public string PersonAnswer { get; set; }

        public int QuestionId { get; set; }
    }
}
