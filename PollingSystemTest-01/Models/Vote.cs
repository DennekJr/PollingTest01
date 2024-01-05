using System;
namespace PollingSystemTest_01.Models
{
	public class Vote
	{
		public int Id { get; set; }
		public ApplicationUser User { get; set; }

		public bool Decision { get; set; }

		public PollQuestion? PollQuestion { get; set; }

		public int? PollQuestionId { get; set; }
		public int? PollOptionId { get; set; }

		public PollOption? PollOption { get; set; }
	}
}

