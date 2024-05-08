

namespace ConsoleApp1
{
    public class MCQQuestion : Question
    {
        public MCQQuestion(string header, string body, int mark, List<Answer> answers, int correctAnswerId) : base(header, body, mark, answers, correctAnswerId)
        {
        }
    }
}
