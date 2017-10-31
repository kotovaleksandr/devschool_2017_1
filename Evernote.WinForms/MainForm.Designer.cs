namespace Evernote.WinForms
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnCreateUser = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnCreateUser
			// 
			this.btnCreateUser.Location = new System.Drawing.Point(12, 12);
			this.btnCreateUser.Name = "btnCreateUser";
			this.btnCreateUser.Size = new System.Drawing.Size(151, 32);
			this.btnCreateUser.TabIndex = 0;
			this.btnCreateUser.Text = "Создать пользователя";
			this.btnCreateUser.UseVisualStyleBackColor = true;
			this.btnCreateUser.Click += new System.EventHandler(this.btnCreateUser_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.Controls.Add(this.btnCreateUser);
			this.Name = "MainForm";
			this.Text = "Evernote";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnCreateUser;
	}
}

