using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Net.OPP.C_
{
    internal class Subject : Exam
    {
        public string SubjectName { get; private set; }
        public int SubjectId { get; private set; }
        public Subject(string subjectName, int subjectId, int TimeExam, Question[] questionList) : base(TimeExam, questionList)
        {
            SubjectName = subjectName;
            SubjectId = subjectId;
        }
        public static void CreateExam()
        {
            Console.WriteLine("Enter the subject name:");
            string subjectName = Console.ReadLine();
            Console.WriteLine("Enter the subject ID:");
            int subjectId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the time limit for the exam (Between 30 and 120 minutes):");
            int timeExam = int.Parse(Console.ReadLine());
            if (timeExam < 30 || timeExam > 120)
            {
                Console.WriteLine("Invalid time limit. Please enter a value between 30 and 120 minutes.");
                return;
            }
            Console.WriteLine("Enter the number of questions for the exam:");
            int numQuestions = int.Parse(Console.ReadLine());
            Question[] questions = new Question[numQuestions];
            Console.WriteLine($"Enter The Exam Final => 1 Or Practicaal => 2");
            int TypeOfExam = int.Parse(Console.ReadLine());
            for (int i = 0; i < numQuestions; i++)
            {
                Console.WriteLine($"Enter details for question {i + 1}:");
                Console.Write("Header: ");
                string header = Console.ReadLine();
                Console.Write("Body: ");
                string body = Console.ReadLine();
                Console.Write("Mark: ");
                int mark = int.Parse(Console.ReadLine());
                if (header.Contains("True") || header.Contains("False"))
                {
                    questions[i] = new TrueFalse(header, body, mark, new Answer[]
                    {
                        new Answer("True", 1),
                        new Answer("False", 2)
                    }, 1);
                    Console.WriteLine("Enter the correct answer (1 for True, 2 for False):");
                    int correctAnswer = int.Parse(Console.ReadLine());
                    questions[i] = new TrueFalse(header, body, mark, new Answer[]
                    {
                        new Answer("True", 1),
                        new Answer("False", 2)
                    }, correctAnswer);
                }
                else
                {
                    Answer[] answers = new Answer[4];
                    for (int j = 0; j < 4; j++)
                    {
                        Console.Write($"Answer {j + 1} text: ");
                        string text = Console.ReadLine();
                        int value = j + 1;
                        answers[j] = new Answer(text, value);
                    }
                    questions[i] = new MCQ(header, body, mark, answers, 1);
                    Console.WriteLine("Enter the correct answer Id:");
                    int correctAnswer = int.Parse(Console.ReadLine());
                    questions[i] = new MCQ(header, body, mark, answers, correctAnswer);
                }
            }
            Subject subject = new Subject(subjectName, subjectId, timeExam, questions);
            Console.WriteLine($"Do you want to show the exam for subject {subjectName}? (yes => 1 | no => 0)");
            int showExam = int.Parse(Console.ReadLine());
            if (showExam == 1)
            {

                if (TypeOfExam == 1)
                {
                    FinalExam finalExam = new FinalExam(timeExam, questions);
                    finalExam.ShowExam();
                }
                else
                {
                    PracticalExam practicalExam = new PracticalExam(timeExam, questions);
                    practicalExam.ShowExam();
                }
            }
        }
    }
}
