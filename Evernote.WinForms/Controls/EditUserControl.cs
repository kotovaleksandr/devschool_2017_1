using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evernote.WinForms
{
	public partial class EditUserControl : UserControl
	{
		public EditUserControl()
		{
			InitializeComponent();
		}

		public string UserName
		{
			get { return txtUserName.Text; }
		}
	}
}
