using System;
using System.Collections.Generic;

namespace PollingSystemTest_01.Models
{
    public class PollOption
	{
        public int Id { get; set; }

        public int PollQuestionId { get; set; }
        public bool PollOptionIsCorrect { get; set; } = false;

        public PollQuestion PollQuestionToAnswer { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }

        public virtual ICollection<Vote>? Votes { get; set; }
        public string Description { get; set; }

        public PollOption()
		{
            Votes = new HashSet<Vote>();
        }
    }
}

