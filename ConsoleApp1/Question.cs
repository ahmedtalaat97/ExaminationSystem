

namespace ConsoleApp1
{
    public class Question
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int Mark { get; set; }
        public List<Answer> AnswerList { get; set; }
        public int CorrectAnswerId { get; set; }
        public string UserSelectedAnswer { get; internal set; }

        public Question(string header, string body, int mark, List<Answer> answers, int correctAnswerId)
        {
            Header = header;
            Body = body;
            Mark = mark;
            AnswerList = answers;
            CorrectAnswerId = correctAnswerId;
        }
        public void ShowQuestion()
        {
            Console.WriteLine($"{Header}: {Body}           Marks ({Mark})");
            Console.WriteLine();
            Console.WriteLine("Choices:");

            foreach (var answer in AnswerList)
            {
                Console.WriteLine($"     {answer.AnswerId}. {answer.AnswerText}");

                Console.WriteLine();
            }
        }

    }

}
