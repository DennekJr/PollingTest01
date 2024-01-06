using System;
using System.Collections.Generic;

namespace PollingSystemTest_01.Models
{
	public class PollQuestion
	{
		public int Id { get; set; }
		public int VoteCount { get; set; } = 0;
		public bool disPlayPercentage { get; set; } = false;

		public string Name { get; set; }
		public string Description { get; set; }

		public virtual ApplicationUser? User { get; set; }
		public virtual ICollection<PollOption> PollOptions { get; set; }
		public virtual ICollection<Vote>? Votes { get; set; }
		public virtual ICollection<UsersSelected> UsersSelected { get; set; }

		public DateTime DOC { get; set; }

		public string? UserId { get; set; }
		public PollQuestion()
		{
			PollOptions = new HashSet<PollOption>();
			Votes = new HashSet<Vote>();
			UsersSelected = new HashSet<UsersSelected>();
		}
	}
}

