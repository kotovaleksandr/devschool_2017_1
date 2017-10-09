using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evernote.Model
{
	public class Note
	{
		public Guid Id { get; set; }

		public string Title { get; set; }

		public string Content { get; set; }

		public User Owner { get; set; }

		public DateTime Created { get; set; }

		public DateTime Changed { get; set; }

		public IEnumerable<Category> Categories { get; set; }

		public IEnumerable<User> Shared { get; set; }
	}
}
