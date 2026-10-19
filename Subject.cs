using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Exam.Net.OPP.C_
{
    public class Subject : Exam
    {
        public string SubjectName { get; private set; }
        public Subject(string subjectName, int TimeExam, Question[] questionList) : base(TimeExam, questionList)
        {
            SubjectName = subjectName;
        }
        public static void CreateExam()
        {
            Console.Write("Enter the subject name: ");
            string subjectName = Console.ReadLine();
            Console.Write("Enter the time limit for the exam (Between 30 and 180 minutes): ");
            int timeExam = int.Parse(Console.ReadLine());
            if (timeExam < 30 || timeExam > 180)
            {
                Console.WriteLine("Invalid time limit. Please enter a value between 30 and 180 minutes.");
                return;
            }
            Console.Write("Enter the number of questions for the exam: ");
            int numQuestions = int.Parse(Console.ReadLine());
            Question[] questions = new Question[numQuestions];
            Console.Write($"Enter The Exam Final => 1 Or Practicaal => 2: ");
            int TypeOfExam = int.Parse(Console.ReadLine());
            Console.Clear();
            if (TypeOfExam == 1)
            {
                for (int i = 0; i < numQuestions; i++)
                {
                    Console.WriteLine($"Enter details for question {i + 1}: ");
                    Console.Write("Header MCQ | TrueFalse : ");
                    string header = Console.ReadLine();
                    Console.Write($"Body Of Question {i + 1}: ");
                    string body = Console.ReadLine();
                    Console.Write($"Mark Of Question {i + 1}: ");
                    int mark = int.Parse(Console.ReadLine());
                    if (header.Contains("True") || header.Contains("False"))
                    {
                        Console.Write("Enter the correct answer (1 for True, 0 for False): ");
                        int.TryParse(Console.ReadLine(), out int correctAnswer);
                        questions[i] = new TrueFalse(header, body, mark, new Answer[]
                        {
                            new Answer("True", 1),
                            new Answer("False", 0)
                        }, correctAnswer);
                    }
                    else
                    {
                        Answer[] answers = new Answer[4];
                        for (int j = 0; j < 4; j++)
                        {
                            Console.Write($"Enter Choice Number {j + 1}: ");
                            string text = Console.ReadLine();
                            int Id = j + 1;
                            answers[j] = new Answer(text, Id);
                        }
                        Console.Write("Enter the correct answer Id: ");
                        int.TryParse(Console.ReadLine(), out int correctAnswer);
                        questions[i] = new MCQ(header, body, mark, answers, correctAnswer);
                    }
                }
            }
            else
            {
                for (int i = 0; i < numQuestions; i++)
                {
                    Console.WriteLine($"Enter details for question {i + 1}: ");
                    Console.Write($"Body Of Question {i + 1}: ");
                    string body = Console.ReadLine();
                    Console.Write($"Mark Of Question {i + 1}: ");
                    int mark = int.Parse(Console.ReadLine());
                    Answer[] answers = new Answer[4];
                    for (int j = 0; j < 4; j++)
                    {
                        Console.Write($"Enter Choice Number {j + 1}: ");
                        string text = Console.ReadLine();
                        int Id = j + 1;
                        answers[j] = new Answer(text, Id);
                    }
                    Console.Write("Enter the correct answer Id: ");
                    int.TryParse(Console.ReadLine(), out int correctAnswer);
                    questions[i] = new MCQ("MCQ" ,body, mark, answers, correctAnswer);
                    Console.WriteLine("===============================");
                }
            }
            Subject subject = new Subject(subjectName, timeExam, questions);
            Console.WriteLine($"Do you want to start exam for subject {subjectName}? (yes => 1 | no => 0)");
            int showExam = int.Parse(Console.ReadLine());
            Console.Clear();
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
