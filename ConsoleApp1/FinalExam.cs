


namespace ConsoleApp1
{
    public class FinalExam : Exam
    {

        public List<Question> Questions { get; set; }

        public int Grade { get; set; }
        public FinalExam(TimeSpan timeOfExam, int numberOfQuestions, Subject associatedSubject , List<Question> questions) : base(timeOfExam, numberOfQuestions, associatedSubject)
        {
            Questions = questions;
        }

        public override void ShowExam()
        {
            Console.WriteLine($"Final Exam for {AssociatedSubject.SubjectName}");
            Console.WriteLine($"Time of Exam: {TimeOfExam}");
            Console.WriteLine($"Number of Questions: {NumberOfQuestions}");
            Console.WriteLine("Press Enter to start the exam...");
            Console.ReadLine();

            int totalScore = 0;
            int totalMarks= 0;
            DateTime startTime = DateTime.Now;
            int userAnswer;
            
            for (int i = 0; i < NumberOfQuestions; i++)
            {
                Console.Clear();
                
                Questions[i].ShowQuestion();
                Console.Write("Your Answer: ");
               
                while (!int.TryParse(Console.ReadLine(), out userAnswer) ||
                       userAnswer < 1 || userAnswer > Questions[i].AnswerList.Count)
                {
                    Console.WriteLine("Invalid choice. Please enter a valid answer.");
                    Console.WriteLine();
                    Console.Write("Your Answer: ");
                }

              string  myAnswer = Questions[i].AnswerList[userAnswer-1].AnswerText;
                Questions[i].UserSelectedAnswer = myAnswer;

                if (userAnswer == Questions[i].CorrectAnswerId)
                {
                    totalScore += Questions[i].Mark;
                }
                totalMarks += Questions[i].Mark;
            }

            

            DateTime endTime = DateTime.Now;
            TimeSpan timeTaken = endTime - startTime;

            Console.Clear();
            Console.WriteLine($"Final Exam for {AssociatedSubject.SubjectName} - Results");
            Console.WriteLine("======================================");
            Console.WriteLine($"Your Score: {totalScore} from {totalMarks} ");
            Console.WriteLine("======================================");
            Console.WriteLine($"Time Taken: {timeTaken.TotalMinutes} minutes");
            Console.WriteLine("======================================");

            Console.WriteLine($"Time required to solve the exam  : {TimeOfExam.Minutes} minutes  ");
            Console.WriteLine("======================================");


            Console.WriteLine("Correct Answers:");
            Console.WriteLine("======================================");
            for (int i = 0; i < NumberOfQuestions; i++)
            {
                Console.WriteLine($"Question {i + 1}:  {Questions[i].Body}     Correct Answers:  {Questions[i].AnswerList[Questions[i].CorrectAnswerId -1].AnswerText}     Your Answer : {Questions[i].UserSelectedAnswer} ");

                Console.WriteLine();
            }
        }
    }
}
