using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Net.OPP.C_
{
    public class Answer
    {
        public string AnswerText { get; set; }
        public int AnswerId { get; set; }
        public Answer(string answerText, int answerId)
        {
            AnswerText = answerText;
            AnswerId = answerId;
        }

    }
}
