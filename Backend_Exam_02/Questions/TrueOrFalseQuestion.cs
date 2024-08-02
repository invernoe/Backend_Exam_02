using Backend_Exam_02.Answers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Exam_02.Questions
{
    internal class TrueOrFalseQuestion : Question
    {
        public TrueOrFalseQuestion(string header, string body, decimal mark, Answer[] answers, Answer correctAnswer) : base(header, body, mark, answers, correctAnswer)
        {
        }

        public static TrueOrFalseQuestion CreateQuestion()
        {
            string header = "True or False Question";
            CreateQuestionBase(header, out string body, out decimal mark);

            int correctIdx = MyTryParse.loopUntilParsed<int>(
                () => Console.WriteLine("Please enter the right answer id (1: True, 2: False)"),
                int.TryParse
                );

            Answer[] answers = [new(1, "True"), new(2, "False")];
            Answer correctAnswer = (Answer)answers[correctIdx - 1].Clone();

            return new TrueOrFalseQuestion(header, body, mark, answers, correctAnswer);
        }
    }
}
