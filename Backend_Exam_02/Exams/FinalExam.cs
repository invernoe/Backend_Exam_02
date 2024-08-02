using Backend_Exam_02.Answers;
using Backend_Exam_02.Questions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Exam_02.Exams
{
    internal class FinalExam : Exam
    {
        public Question[] Questions { get; set; }
        public FinalExam(int time, int numberOfQuestions, Question[] questions) : base(time, numberOfQuestions)
        {
            Questions = questions;
        }

        public static Exam CreateExam(int time, int numberOfQuestions)
        {
            Question[] questions = new Question[numberOfQuestions];
            for (int i = 0; i < numberOfQuestions; i++)
            {
                int questionType = MyTryParse.loopUntilParsed<int>(
                () => Console.WriteLine($"Please Enter Type of Question {i + 1} (1: MCQ, 2: True or False)"),
                int.TryParse,
                (res) => (res == 1 || res == 2)
                );

                Question question = questionType == 1 ? MCQ.CreateQuestion() : TrueOrFalseQuestion.CreateQuestion();
                questions[i] = question;
            }

            return new FinalExam(time, numberOfQuestions, questions);
        }

        public override void Start()
        {
            //clear the console to start test
            Console.Clear();

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            decimal fullMark = 0;
            decimal currentMark = 0;
            Answer[] answers = new Answer[Questions.Length];

            for (int i = 0; i < Questions.Length; i++)
            {
                Console.WriteLine(Questions[i]);
                fullMark += Questions[i].Mark;
                answers[i] = Questions[i].GetUserAnswer();
                if (Questions[i].CheckAnswer(answers[i]))
                {
                    currentMark += Questions[i].Mark;
                }
            }

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes,
                ts.Seconds, ts.Milliseconds / 10);

            //clear the console to show test results
            Console.Clear();
            for (int i = 0; i < Questions.Length; i++)
            {
                Console.Write($"Question {i + 1} - ");
                Questions[i].PrintAnswer(answers[i]);
            }
            Console.WriteLine($"Your Grade is {currentMark} from {fullMark}");
            Console.WriteLine("Time: " + elapsedTime);
            Console.WriteLine("Thank You");
        }
    }
}
