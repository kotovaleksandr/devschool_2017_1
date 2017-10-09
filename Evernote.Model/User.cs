using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evernote.Model
{
	public class User
	{
		public Guid Id { get; set; }

		public string Name { get; set; }

		public IEnumerable<Category> Categories { get; set; }
	}
}
