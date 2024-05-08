namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            Subject Sub1 =new Subject(10,"c#",null);
            Sub1.CreateExam();
    
          
            Sub1.ExamOfSubject.ShowExam();
           



        }
    }
}
