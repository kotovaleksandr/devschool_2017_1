using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evernote.Model;

namespace Evernote.DataLayer
{
	public interface ICategoriesRepository
	{
		Category Create(Guid userId, string name);
		IEnumerable<Category> GetUserCategories(Guid userId);
	}
}
