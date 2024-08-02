namespace Backend_Exam_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject(1, "C#");
            subject.CreateExam();
            Console.WriteLine("Do you want to start exam (Y | N)");
            bool isStart = Console.ReadLine() == "Y" ? true : false;
            if (isStart)
            {
                subject.Exam.Start();
            }
        }
    }
}
