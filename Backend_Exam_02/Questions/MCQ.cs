using Backend_Exam_02.Answers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Exam_02.Questions
{
    internal class MCQ : Question
    {
        public MCQ(string header, string body, decimal mark, Answer[] answers, Answer correctAnswer) : base(header, body, mark, answers, correctAnswer)
        {
        }

        public static MCQ CreateQuestion()
        {
            string header = "MCQ Question";
            CreateQuestionBase(header, out string body, out decimal mark);

            Answer[] answers = new Answer[3];
            for (int i = 0; i < 3; i++)
            {
                string answerString = MyTryParse.loopUntilNotEmptyString($"Please enter choice number {i + 1}");
                answers[i] = new Answer(i + 1, answerString);
            }

            int correctIdx = MyTryParse.loopUntilParsed<int>(
                () => Console.WriteLine("Please enter the right answer id"),
                int.TryParse,
                (res) => (res >= 1 && res <= 3)
                );

            Answer correct = (Answer)answers[correctIdx - 1].Clone();

            return new MCQ(header, body, mark, answers, correct);
        }
    }
}
