using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Carga_Dlls_Dinam
{

	public class Advertencia : System.Windows.Forms.Form
	{

		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;

		private Paleta paleta;
		private Disenno dis;

		public Advertencia(Paleta paleta,Disenno disenno)
		{
			this.paleta=paleta;
			this.dis=disenno;
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
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(318, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "¿Desea suprimir esta forma de Diseño del Proyecto actual?";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(52, 36);
			this.button1.Name = "button1";
			this.button1.TabIndex = 1;
			this.button1.Text = "Si";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(192, 38);
			this.button2.Name = "button2";
			this.button2.TabIndex = 2;
			this.button2.Text = "No";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// Advertencia
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(342, 74);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Name = "Advertencia";
			this.Text = "Advertencia";
			this.ResumeLayout(false);
		}
		#endregion

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Hide();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			int idDisenno=this.dis.ID;
			string nomDisenno=this.dis.Nombre;
			this.paleta.BorraFormaDisenno(idDisenno,nomDisenno);
		}
	}
}
