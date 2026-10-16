using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Net.OPP.C_
{
    public class Question
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }

        public Question(string header, string body, int mark)
        {
            Header = header;
            Body = body;
            Mark = mark;
        }
        public override string ToString()
        {
            return $"Header: {Header}\nBody: {Body}\nMark: {Mark}";
        }

    }
    public class MCQ : Question
    {
        public MCQ(string header, string body, int mark) : base(header, body, mark)
        {
        }
        
    }
}
