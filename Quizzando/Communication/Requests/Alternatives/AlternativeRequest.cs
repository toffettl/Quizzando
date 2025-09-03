using System;

public class AlternativeRequest
{
	public AlternativeRequest()
	{
		public string? Text { get; set; }
		public bool IsCorrect { get; set; }
		public Guid QuestionId { get; set; }
	}
}
