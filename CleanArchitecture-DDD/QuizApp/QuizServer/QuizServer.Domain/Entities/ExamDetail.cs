namespace QuizServer.Domain.Entities;

public sealed class ExamDetail
{
    public int Id { get; set; }
    public int ExamId { get; set; }
    public Exam Exam { get; set; }
    public string Question { get; set; }
    public string AnswerA { get; set; }
    public string AnswerB { get; set; }
    public string AnswerC { get; set; }
    public string AnswerD { get; set; }
    public string RightAnswer { get; set; }
    public int TimeLimit { get; set; }
}