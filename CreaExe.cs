using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Carga_Dlls_Dinam
{
	public class CreaExe : System.Windows.Forms.Form
	{
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox nombreExe;
		private System.Windows.Forms.Button button1;
		private Paleta paleta;
		private System.Windows.Forms.Button button2;

		public CreaExe(Paleta paleta)
		{
			this.paleta=paleta;
			InitializeComponent();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
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
			this.label1 = new System.Windows.Forms.Label();
			this.nombreExe = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(22, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "Nombre del ejecutable";
			// 
			// nombreExe
			// 
			this.nombreExe.Location = new System.Drawing.Point(20, 28);
			this.nombreExe.Name = "nombreExe";
			this.nombreExe.Size = new System.Drawing.Size(336, 20);
			this.nombreExe.TabIndex = 1;
			this.nombreExe.Text = "";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(190, 56);
			this.button1.Name = "button1";
			this.button1.TabIndex = 2;
			this.button1.Text = "Crear EXE";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(280, 56);
			this.button2.Name = "button2";
			this.button2.TabIndex = 3;
			this.button2.Text = "Cancelar";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// CreaExe
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(374, 92);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.nombreExe);
			this.Controls.Add(this.label1);
			this.Name = "CreaExe";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Creando ejecutable";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.CreaExe_Closing);
			this.ResumeLayout(false);
		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			if (this.nombreExe.Text!="")
			{
				this.paleta.Ejecuta2(nombreExe.Text+".exe",true);
				this.Hide();
			}

			if (this.nombreExe.Text=="")
			{
                MessageBox.Show("No ha especificado el nombre del ejecutable");
            }
		}
		
		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Hide();
		}
		
		private void CreaExe_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
            this.Hide();
		}
	}
}
