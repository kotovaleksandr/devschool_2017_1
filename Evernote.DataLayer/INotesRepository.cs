using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evernote.Model;

namespace Evernote.DataLayer
{
	public interface INotesRepository
	{
		Note Create(Note note);
		void Delete(Guid id);
		IEnumerable<Note> GetUserNotes(Guid userId);
		Note UpdateNote(Note note);
	}
}
