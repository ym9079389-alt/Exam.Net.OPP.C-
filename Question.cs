using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic;

namespace Exam.Net.OPP.C_
{
    public abstract class Question
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public int CorrectAnswerId { get; set; }
        public Answer[] AnswerList;

        public Question(string header, string body, int mark, Answer[] answerList, int correctAnswerId)
        {
            Header = header;
            Body = body;
            Mark = mark;
            AnswerList = (Answer[])answerList.Clone();
            CorrectAnswerId = correctAnswerId;
        }
        public abstract bool Check();
    }
    public class MCQ : Question
    {
        public MCQ(string header, string body, int mark, Answer[] answerList, int correctAnswerId) : base(header, body, mark, answerList, correctAnswerId)
        {
            bool isValid = Check();
            if (!isValid)
            {
                throw new ArgumentException("True/False question must have exactly two answers.");
            }
        }
        public override bool Check()
        {
            if (AnswerList.Length > 2)
            {
                foreach (var answer in AnswerList)
                {
                    if (CorrectAnswerId == answer.AnswerId)
                    {
                        return true;
                    }
                }
                return false;
            }
            return false;
        }
    }
    public class TrueFalse : Question
    {
        public TrueFalse(string header, string body, int mark, Answer[] answerList, int correctAnswerId) : base(header, body, mark, answerList, correctAnswerId)
        {
            bool isValid = Check();
            if(!isValid)
            {
                throw new ArgumentException("True/False question must have exactly two answers.");
            }
        }
        public override bool Check()
        {
            if (AnswerList.Length == 2)
            {
                foreach (var answer in AnswerList)
                {
                    if (CorrectAnswerId == answer.AnswerId)
                    {
                        return true;
                    }
                }
                return false;
            }
            return false;
        }
        
    }
}
