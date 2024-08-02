using Backend_Exam_02.Answers;
using Backend_Exam_02.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Exam_02.Exams
{
    internal class PracticalExam : Exam
    {
        public MCQ[] Questions { get; set; }

        public PracticalExam(int time, int numberOfQuestions, MCQ[] questions) : base(time, numberOfQuestions)
        {
            Questions = questions;
        }

        public static Exam CreateExam(int time, int numberOfQuestions)
        {
            MCQ[] questions = new MCQ[numberOfQuestions];
            for (int i = 0; i < numberOfQuestions; i++)
            {
                questions[i] = MCQ.CreateQuestion();
            }

            return new PracticalExam(time, numberOfQuestions, questions);
        }

        public override void Start()
        {
            //clear the console to start test
            Console.Clear();

            Answer[] answers = new Answer[Questions.Length];

            for (int i = 0; i < Questions.Length; i++)
            {
                Console.WriteLine(Questions[i]);
                answers[i] = Questions[i].GetUserAnswer();
            }

            //clear the console to show test results
            Console.Clear();
            for (int i = 0; i < Questions.Length; i++)
            {
                Console.Write($"Question {i + 1} - ");
                Questions[i].PrintAnswer(answers[i]);
            }

            Console.WriteLine("Thank You");
        }
    }
}
