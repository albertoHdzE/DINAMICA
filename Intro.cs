using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Carga_Dlls_Dinam
{

	public class Intro : System.Windows.Forms.Form
	{

		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Timer timer1;
		private bool soyVisible=false;


		public bool SoyVisible
		{
			set
			{
				soyVisible=value;
			}
			get
			{
				return soyVisible;
            }
        }


	   //	private int contador=0;



		public Intro()
		{

			InitializeComponent();
			this.timer1.Enabled=true;

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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Intro));
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(408, 280);
			this.label2.Name = "label2";
			this.label2.TabIndex = 1;
			this.label2.Text = "Ver. 1.0.666";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.White;
			this.label3.Location = new System.Drawing.Point(288, 80);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(208, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "Facultad de Ciencias";
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.White;
			this.label4.Location = new System.Drawing.Point(336, 40);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(104, 32);
			this.label4.TabIndex = 3;
			this.label4.Text = "MTUIC";
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.White;
			this.label5.Location = new System.Drawing.Point(336, 112);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(120, 32);
			this.label5.TabIndex = 4;
			this.label5.Text = "UNAM";
			// 
			// label6
			// 
			this.label6.ForeColor = System.Drawing.Color.White;
			this.label6.Location = new System.Drawing.Point(80, 208);
			this.label6.Name = "label6";
			this.label6.TabIndex = 5;
			this.label6.Text = "Humberto Carrillo";
			// 
			// label7
			// 
			this.label7.ForeColor = System.Drawing.Color.White;
			this.label7.Location = new System.Drawing.Point(80, 232);
			this.label7.Name = "label7";
			this.label7.TabIndex = 6;
			this.label7.Text = "Luis Nava";
			// 
			// label8
			// 
			this.label8.ForeColor = System.Drawing.Color.White;
			this.label8.Location = new System.Drawing.Point(80, 256);
			this.label8.Name = "label8";
			this.label8.TabIndex = 7;
			this.label8.Text = "Ramón Ramirez";
			// 
			// label9
			// 
			this.label9.ForeColor = System.Drawing.Color.White;
			this.label9.Location = new System.Drawing.Point(80, 280);
			this.label9.Name = "label9";
			this.label9.TabIndex = 8;
			this.label9.Text = "Alberto Hernández";
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Black;
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(600, 400);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 9;
			this.pictureBox1.TabStop = false;
			// 
			// timer1
			// 
			this.timer1.Interval = 10000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// Intro
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(600, 400);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Intro";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "DINAMICA";
			this.Load += new System.EventHandler(this.Intro_Load);
			this.ResumeLayout(false);
		}
		#endregion
		
		private void timer1_Tick(object sender, System.EventArgs e)
		{
//			do
//			{
//			   contador=contador+1;
//			}
//			while ((contador<50));
//
//			if (contador==50)
//			{
//				this.timer1.Enabled=false;
//				this.SoyVisible=false;
//				this.Visible=false;
//            }
		}
		
		private void Intro_Load(object sender, System.EventArgs e)
		{

		}
	}
}
