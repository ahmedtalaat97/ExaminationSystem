

namespace ConsoleApp1
{
    public abstract class Exam
    {
        public TimeSpan TimeOfExam { get; set; }
        public int NumberOfQuestions { get; set; }
        public Subject AssociatedSubject { get; set; }

        public Exam(TimeSpan timeOfExam , int numberOfQuestions, Subject associatedSubject)

        {
            NumberOfQuestions = numberOfQuestions;
            TimeOfExam = timeOfExam;
            AssociatedSubject = associatedSubject;
            
        }

        public abstract void ShowExam();
    }
}
