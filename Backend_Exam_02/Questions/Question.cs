using Backend_Exam_02.Answers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Exam_02.Questions
{
    internal abstract class Question
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public decimal Mark { get; set; }
        public Answer[] Answers { get; set; }
        public Answer CorrectAnswer { get; set; }

        protected Question(string header, string body, decimal mark, Answer[] answers, Answer correctAnswer)
        {
            Header = header;
            Body = body;
            Mark = mark;
            Answers = answers;
            CorrectAnswer = correctAnswer;
        }

        public static void CreateQuestionBase(string header, out string body, out decimal mark)
        {
            Console.WriteLine(header);
            body = MyTryParse.loopUntilNotEmptyString("Please enter Question Body");
            mark = MyTryParse.loopUntilParsed<decimal>(
                () => Console.WriteLine("Please enter Question Mark"),
                decimal.TryParse,
                (res) => (res > 0)
                );
        }

        public bool CheckAnswer(Answer answer)
        {
            return CorrectAnswer.Equals(answer);
        }

        public Answer GetUserAnswer()
        {
            int answerId = MyTryParse.loopUntilParsed<int>(
                () => Console.WriteLine("Please Enter Answer Id"),
                int.TryParse
                );

            foreach (var item in Answers)
            {
                if (item.Id == answerId) return item;
            }

            //if id was wrong we re-call the function
            return GetUserAnswer();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Header);
            sb.Append("\t");
            sb.Append("Mark ");
            sb.Append(Mark);
            sb.Append("\n\n");
            sb.Append(Body);
            sb.Append("\n\n");
            foreach (var item in Answers) sb.AppendLine(item.ToString());

            return sb.ToString();
        }

        public void PrintAnswer(Answer answer)
        {
            Console.WriteLine(Body);
            Console.WriteLine($"Your Answer: {answer.Text}");
            Console.WriteLine($"Correct Answer: {CorrectAnswer.Text}");
        }
    }
}
