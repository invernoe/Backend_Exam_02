using Backend_Exam_02.Exams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend_Exam_02
{
    internal class Subject
    {
        private Exam exam;
        public int Id { get; set; }
        public string Name { get; set; }
        public Exam Exam
        {
            get { return exam == null ? CreateExam() : exam; }
            set { exam = value; }
        }

        public Subject(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Exam CreateExam()
        {
            int examType = MyTryParse.loopUntilParsed<int>(
                () => Console.WriteLine("Please Enter The Type of Exam (1: Practical | 2: Final)"),
                int.TryParse,
                (res) => (res == 1 || res == 2)
                );

            int examTime = MyTryParse.loopUntilParsed<int>(
                () => Console.WriteLine("Please Enter The Time for Exam (30 to 180 min)"),
                int.TryParse,
                (res) => (res >= 30 && res <= 180)
                );

            int numOfQuestions = MyTryParse.loopUntilParsed<int>(
                () => Console.WriteLine("Please Enter Number of Questions"),
                int.TryParse
                );

            Exam = (examType == 1) ? PracticalExam.CreateExam(examTime, numOfQuestions) : FinalExam.CreateExam(examTime, numOfQuestions);

            return Exam;
        }

    }
}
