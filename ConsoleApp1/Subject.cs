

namespace ConsoleApp1
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam ExamOfSubject { get; set; }

        public Subject(int subjectId, string subjectName, Exam examOfSubject)
        {

            SubjectId = subjectId;
            SubjectName = subjectName;
            ExamOfSubject = examOfSubject;
        }

        public  void CreateExam()
        {
           

            int examType;
            do
            {

                Console.WriteLine("=================================");
                Console.WriteLine("Please enter the type of exam you want to create (1 for practical and 2 for final): ");
                int.TryParse(Console.ReadLine(), out examType);
            } while (examType!=1 &&examType!=2);

            int timeOfExam;
            Console.WriteLine("Please enter the time of exam in minutes: ");


            while (!int.TryParse(Console.ReadLine(),out timeOfExam))
            {
                Console.WriteLine("please enter a valid time ");
            }

            Console.WriteLine("Enter the number of questions you want to create: ");

            int numberOfQuestions;


            while (!int.TryParse(Console.ReadLine(), out numberOfQuestions))
            {
                Console.WriteLine("please enter a valid number Of Questions ");
            }

            Console.Clear();



            List<Question> questions = new List<Question>();

            if (examType == 2)
            {


                for (int i = 0; i < numberOfQuestions; i++)
                {


                    int questionType;

                    do
                    {

                        Console.WriteLine("=================================");
                        Console.WriteLine($"Enter the type of question {i + 1} (1 for true or false, 2 for MCQ): ");
                        int.TryParse(Console.ReadLine(), out questionType);
                    } while (questionType != 1 && questionType != 2);

                    string questionBody;
                  
                    do
                    {
                        Console.WriteLine($"Enter the body of question {i + 1}:  please dont enter null value  ");
                        questionBody = Console.ReadLine();
                       

                    } while (String.IsNullOrEmpty(questionBody));
                 

                    int questionMarks;

                    Console.WriteLine("Please enter how many points for this question");

                    while (!int.TryParse(Console.ReadLine(), out questionMarks))
                    {
                        Console.WriteLine("please enter a valid question Mark ");
                    }

                    int correctAnswer;
                    List<Answer> answers = new List<Answer>();


                    if (questionType == 1)
                    {

                        do
                        {

                           
                            Console.WriteLine($"Enter the correct answer for question {i + 1} (1 for true ||2 for false ): ");
                            int.TryParse(Console.ReadLine(), out correctAnswer);
                        } while (correctAnswer != 1 && correctAnswer != 2);

                        answers.Add(new Answer(1, "True"));
                        answers.Add(new Answer(2, "False"));
                        questions.Add(new TrueFalseQuestion($"Question {i + 1}", questionBody, questionMarks, answers, correctAnswer ));
                    }


                    else if (questionType == 2)
                    {
                        Console.WriteLine("Enter the answer choices (one per line, press enter after each): ");

                        for (int j = 0; j < 3; j++)
                        {
                            Console.WriteLine($"Choice {j + 1}: ");
                            string choice = Console.ReadLine();
                            answers.Add(new Answer(j + 1, choice));

                        }

                        do
                        {
                            Console.WriteLine($"Enter the correct answer for question {i + 1} (1 or 2 or 3 ): ");
                            int.TryParse(Console.ReadLine(), out correctAnswer);
                        } while (correctAnswer != 1 && correctAnswer != 2 && correctAnswer != 3);


                        questions.Add(new MCQQuestion($"Question {i + 1}", questionBody, questionMarks, answers, correctAnswer));

                    }


                }





                Console.Clear();


            }



            //////////////////////////////////////

            if (examType == 1)
            {


                for (int i = 0; i < numberOfQuestions; i++)
                {


                    int questionType;

                    do
                    {
                        Console.WriteLine("=================================");
                        Console.WriteLine($"Enter the type of question {i + 1} (1 => for true or false):  [You have only one option '1']");
                        int.TryParse(Console.ReadLine(), out questionType);
                    } while (questionType != 1 );

                
                    string questionBody;
                   
                    do
                    {
                        Console.WriteLine($"Enter the body of question {i + 1}:  please dont enter null value  ");
                        questionBody = Console.ReadLine();
                        

                    } while (String.IsNullOrEmpty(questionBody));

                    int questionMarks;

                    Console.WriteLine("Please enter how many points for this question");

                    while (!int.TryParse(Console.ReadLine(), out questionMarks))
                    {
                        Console.WriteLine("please enter a valid question Mark ");
                    }

                    int correctAnswer;
                   
                    List<Answer> answers = new List<Answer>();


                   

                        do
                        {
                            Console.WriteLine($"Enter the correct answer for question {i + 1} (1 for true ||2 for false ): ");
                            int.TryParse(Console.ReadLine(), out correctAnswer);
                        } while (correctAnswer != 1 && correctAnswer != 2);

                  

                        answers.Add(new Answer(1, "True"));
                        answers.Add(new Answer(2, "False"));
                        questions.Add(new TrueFalseQuestion($"Question {i + 1}", questionBody, questionMarks, answers, correctAnswer));
                    


                   


                }

                Console.Clear();

            }



            if(examType == 1)
            {
                ExamOfSubject=  new PracticalExam(TimeSpan.FromMinutes(timeOfExam), numberOfQuestions,this  , questions);
            }
            else if(examType == 2)
            {
                ExamOfSubject= new FinalExam(TimeSpan.FromMinutes(timeOfExam), numberOfQuestions, this, questions);
            }

            
        }
    }
}
