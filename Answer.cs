using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Net.OPP.C_
{
    public class Answer
    {
        public string AnswerText { get; private set; }
        public int AnswerId { get; private set; }
        public Answer(string answerText, int answerId)
        {
            AnswerText = answerText;
            AnswerId = answerId;
        }
        public override string ToString()
        {
            return $"Answer ID: {AnswerId}, Answer Text: {AnswerText}";
        }
    }
}
