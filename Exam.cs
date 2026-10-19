using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Exam.Net.OPP.C_
{
    public class Exam
    {
        public double TimeExam { get; private set; }
        public int NumberOfQuestions { get; set; }
        internal Question[] QuestionList { get; set; }


        public Exam(int timeExam, Question[] questionList)
        {
            TimeExam = timeExam;
            NumberOfQuestions = questionList.Length;
            QuestionList = (Question[])questionList.Clone();
        }

        public virtual void ShowExam()
        {

        }
        

    }

    public class FinalExam : Exam
    {
        public int YourAnswer { get; set; }
        public FinalExam(int timeExam, Question[] question) : base(timeExam, question)
        {
        }
        public override void ShowExam()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            Console.WriteLine($"Final Exam Results");
            int totalMarks = 0;
            foreach (var question in QuestionList)
            {
                Console.WriteLine($"Question: {question.Header}");
                Console.WriteLine($"Body: {question.Body}");
                Console.WriteLine($"Answers:");
                foreach (var answer in question.AnswerList)
                {
                    Console.WriteLine($"{answer.AnswerId}- {answer.AnswerText}");
                }
                Console.Write($"Enter your answer Id: ");
                YourAnswer = int.Parse(Console.ReadLine());
                if (YourAnswer == question.CorrectAnswerId)
                {
                    totalMarks += question.Mark;
                }
                if (stopwatch.Elapsed.TotalSeconds >= TimeExam)
                {
                    Console.WriteLine("Time's up!");
                    break;
                }
            }
            Console.Clear();
            Console.WriteLine("======================");
            for (int i = 0; i < QuestionList.Length; i++)
            {
                Console.WriteLine($"Question {i + 1}: {QuestionList[i].Header}");
                Console.WriteLine($"Body: {QuestionList[i].Body}");
                Console.WriteLine($"Correct Answer Id: {QuestionList[i].CorrectAnswerId}");
                Console.WriteLine($"Your Answer Id: {YourAnswer}");
                Console.WriteLine("----------------------");
            }
            Console.WriteLine($"Total Marks: {totalMarks}");
            Console.WriteLine($"Time Taken: {stopwatch} seconds");
        }
    }
    public class PracticalExam : Exam
    {
        public int YourAnswer { get; set; }
        public PracticalExam(int timeExam, Question[] question) : base(timeExam, question)
        {
        }
        public override void ShowExam()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            Console.WriteLine($"Practical Exam Results");
            int totalMarks = 0;
            foreach (var question in QuestionList)
            {
                if(question.Header != "MCQ")
                {
                    throw new InvalidOperationException("Practical Exam can only contain MCQ questions.");
                }
                Console.WriteLine("Question: MCQ");
                Console.WriteLine($"Body: {question.Body}");
                foreach (var answer in question.AnswerList)
                {
                    Console.WriteLine($"{answer.AnswerId}- {answer.AnswerText}");
                }
                    Console.Write($"Enter your answer Id: ");
                    YourAnswer = int.Parse(Console.ReadLine());
                    if(YourAnswer == question.CorrectAnswerId)
                    {
                        totalMarks += question.Mark;
                    }
                if (stopwatch.Elapsed.TotalSeconds >= TimeExam)
                {
                    Console.WriteLine("Time's up!");
                    break;
                }
            }
            Console.Clear();
            for(int i = 0; i < QuestionList.Length; i++)
            {
                Console.WriteLine($"Question {i + 1}: MCQ");
                Console.WriteLine($"Body: {QuestionList[i].Body}");
                Console.WriteLine($"Correct Answer Id: {QuestionList[i].CorrectAnswerId}");
                Console.WriteLine($"Your Answer Id: {YourAnswer}");
                Console.WriteLine("----------------------");
            }
            Console.WriteLine($"Total Marks: {totalMarks}");
            Console.WriteLine($"Time Taken: {stopwatch} seconds");

        }
    }
}
