using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Evernote.Model;
using Evernote.WinForms.Forms;

namespace Evernote.WinForms
{
	public partial class MainForm : Form
	{
		private ServiceClient _serviceClient;

		public MainForm()
		{
			InitializeComponent();
		}

		private void btnCreateUser_Click(object sender, EventArgs e)
		{
			using (var form = new EditUserForm())
			{
				if (form.ShowDialog() == DialogResult.OK)
				{
					var user = _serviceClient.CreateUser(new User { Name = form.UserName });
					MessageBox.Show($"Id пользователя: {user.Id}", "Пользователь", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			_serviceClient = new ServiceClient("http://localhost:49858/api/");
		}
	}
}
