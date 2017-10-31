using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evernote.WinForms.Forms
{
	public partial class EditUserForm : Form
	{
		public EditUserForm()
		{
			InitializeComponent();
		}

		public string UserName
		{
			get { return editUserControl.UserName; }
		}
	}
}
