using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Carga_Dlls_Dinam
{
	/// <summary>
	/// Summary description for WinForm.
	/// </summary>
	public class CargaCompo : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox PathCompo;
		private System.Windows.Forms.Button btnBusca;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button BtnAceptar;
		private System.Windows.Forms.Button BtnCancelar;
		private System.Windows.Forms.OpenFileDialog AbreDlg;

		private Paleta paleta;

		private string[] opciones;




		 public string[] Opciones
		 {
			get
			{
				return opciones;
			}

			set
			{
				this.opciones=value;
				PonTextTabsItems(value);

			}
		 }



		public CargaCompo(Paleta paleta)
		{
			//
			// Required for Windows Form Designer support
			//
			this.paleta=paleta;
			InitializeComponent();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(CargaCompo));
			this.label1 = new System.Windows.Forms.Label();
			this.PathCompo = new System.Windows.Forms.TextBox();
			this.btnBusca = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.BtnAceptar = new System.Windows.Forms.Button();
			this.BtnCancelar = new System.Windows.Forms.Button();
			this.AbreDlg = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AccessibleDescription = resources.GetString("label1.AccessibleDescription");
			this.label1.AccessibleName = resources.GetString("label1.AccessibleName");
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label1.Anchor")));
			this.label1.AutoSize = ((bool)(resources.GetObject("label1.AutoSize")));
			this.label1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label1.Dock")));
			this.label1.Enabled = ((bool)(resources.GetObject("label1.Enabled")));
			this.label1.Font = ((System.Drawing.Font)(resources.GetObject("label1.Font")));
			this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
			this.label1.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label1.ImageAlign")));
			this.label1.ImageIndex = ((int)(resources.GetObject("label1.ImageIndex")));
			this.label1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label1.ImeMode")));
			this.label1.Location = ((System.Drawing.Point)(resources.GetObject("label1.Location")));
			this.label1.Name = "label1";
			this.label1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label1.RightToLeft")));
			this.label1.Size = ((System.Drawing.Size)(resources.GetObject("label1.Size")));
			this.label1.TabIndex = ((int)(resources.GetObject("label1.TabIndex")));
			this.label1.Text = resources.GetString("label1.Text");
			this.label1.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label1.TextAlign")));
			this.label1.Visible = ((bool)(resources.GetObject("label1.Visible")));
			// 
			// PathCompo
			// 
			this.PathCompo.AccessibleDescription = resources.GetString("PathCompo.AccessibleDescription");
			this.PathCompo.AccessibleName = resources.GetString("PathCompo.AccessibleName");
			this.PathCompo.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("PathCompo.Anchor")));
			this.PathCompo.AutoSize = ((bool)(resources.GetObject("PathCompo.AutoSize")));
			this.PathCompo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PathCompo.BackgroundImage")));
			this.PathCompo.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("PathCompo.Dock")));
			this.PathCompo.Enabled = ((bool)(resources.GetObject("PathCompo.Enabled")));
			this.PathCompo.Font = ((System.Drawing.Font)(resources.GetObject("PathCompo.Font")));
			this.PathCompo.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("PathCompo.ImeMode")));
			this.PathCompo.Location = ((System.Drawing.Point)(resources.GetObject("PathCompo.Location")));
			this.PathCompo.MaxLength = ((int)(resources.GetObject("PathCompo.MaxLength")));
			this.PathCompo.Multiline = ((bool)(resources.GetObject("PathCompo.Multiline")));
			this.PathCompo.Name = "PathCompo";
			this.PathCompo.PasswordChar = ((char)(resources.GetObject("PathCompo.PasswordChar")));
			this.PathCompo.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("PathCompo.RightToLeft")));
			this.PathCompo.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("PathCompo.ScrollBars")));
			this.PathCompo.Size = ((System.Drawing.Size)(resources.GetObject("PathCompo.Size")));
			this.PathCompo.TabIndex = ((int)(resources.GetObject("PathCompo.TabIndex")));
			this.PathCompo.Text = resources.GetString("PathCompo.Text");
			this.PathCompo.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("PathCompo.TextAlign")));
			this.PathCompo.Visible = ((bool)(resources.GetObject("PathCompo.Visible")));
			this.PathCompo.WordWrap = ((bool)(resources.GetObject("PathCompo.WordWrap")));
			// 
			// btnBusca
			// 
			this.btnBusca.AccessibleDescription = resources.GetString("btnBusca.AccessibleDescription");
			this.btnBusca.AccessibleName = resources.GetString("btnBusca.AccessibleName");
			this.btnBusca.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnBusca.Anchor")));
			this.btnBusca.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBusca.BackgroundImage")));
			this.btnBusca.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnBusca.Dock")));
			this.btnBusca.Enabled = ((bool)(resources.GetObject("btnBusca.Enabled")));
			this.btnBusca.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnBusca.FlatStyle")));
			this.btnBusca.Font = ((System.Drawing.Font)(resources.GetObject("btnBusca.Font")));
			this.btnBusca.Image = ((System.Drawing.Image)(resources.GetObject("btnBusca.Image")));
			this.btnBusca.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnBusca.ImageAlign")));
			this.btnBusca.ImageIndex = ((int)(resources.GetObject("btnBusca.ImageIndex")));
			this.btnBusca.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnBusca.ImeMode")));
			this.btnBusca.Location = ((System.Drawing.Point)(resources.GetObject("btnBusca.Location")));
			this.btnBusca.Name = "btnBusca";
			this.btnBusca.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnBusca.RightToLeft")));
			this.btnBusca.Size = ((System.Drawing.Size)(resources.GetObject("btnBusca.Size")));
			this.btnBusca.TabIndex = ((int)(resources.GetObject("btnBusca.TabIndex")));
			this.btnBusca.Text = resources.GetString("btnBusca.Text");
			this.btnBusca.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnBusca.TextAlign")));
			this.btnBusca.Visible = ((bool)(resources.GetObject("btnBusca.Visible")));
			this.btnBusca.Click += new System.EventHandler(this.btnBusca_Click);
			// 
			// label2
			// 
			this.label2.AccessibleDescription = resources.GetString("label2.AccessibleDescription");
			this.label2.AccessibleName = resources.GetString("label2.AccessibleName");
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label2.Anchor")));
			this.label2.AutoSize = ((bool)(resources.GetObject("label2.AutoSize")));
			this.label2.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label2.Dock")));
			this.label2.Enabled = ((bool)(resources.GetObject("label2.Enabled")));
			this.label2.Font = ((System.Drawing.Font)(resources.GetObject("label2.Font")));
			this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
			this.label2.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label2.ImageAlign")));
			this.label2.ImageIndex = ((int)(resources.GetObject("label2.ImageIndex")));
			this.label2.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label2.ImeMode")));
			this.label2.Location = ((System.Drawing.Point)(resources.GetObject("label2.Location")));
			this.label2.Name = "label2";
			this.label2.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label2.RightToLeft")));
			this.label2.Size = ((System.Drawing.Size)(resources.GetObject("label2.Size")));
			this.label2.TabIndex = ((int)(resources.GetObject("label2.TabIndex")));
			this.label2.Text = resources.GetString("label2.Text");
			this.label2.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label2.TextAlign")));
			this.label2.Visible = ((bool)(resources.GetObject("label2.Visible")));
			// 
			// comboBox1
			// 
			this.comboBox1.AccessibleDescription = resources.GetString("comboBox1.AccessibleDescription");
			this.comboBox1.AccessibleName = resources.GetString("comboBox1.AccessibleName");
			this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("comboBox1.Anchor")));
			this.comboBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("comboBox1.BackgroundImage")));
			this.comboBox1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("comboBox1.Dock")));
			this.comboBox1.Enabled = ((bool)(resources.GetObject("comboBox1.Enabled")));
			this.comboBox1.Font = ((System.Drawing.Font)(resources.GetObject("comboBox1.Font")));
			this.comboBox1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("comboBox1.ImeMode")));
			this.comboBox1.IntegralHeight = ((bool)(resources.GetObject("comboBox1.IntegralHeight")));
			this.comboBox1.ItemHeight = ((int)(resources.GetObject("comboBox1.ItemHeight")));
			this.comboBox1.Location = ((System.Drawing.Point)(resources.GetObject("comboBox1.Location")));
			this.comboBox1.MaxDropDownItems = ((int)(resources.GetObject("comboBox1.MaxDropDownItems")));
			this.comboBox1.MaxLength = ((int)(resources.GetObject("comboBox1.MaxLength")));
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("comboBox1.RightToLeft")));
			this.comboBox1.Size = ((System.Drawing.Size)(resources.GetObject("comboBox1.Size")));
			this.comboBox1.TabIndex = ((int)(resources.GetObject("comboBox1.TabIndex")));
			this.comboBox1.Text = resources.GetString("comboBox1.Text");
			this.comboBox1.Visible = ((bool)(resources.GetObject("comboBox1.Visible")));
			// 
			// BtnAceptar
			// 
			this.BtnAceptar.AccessibleDescription = resources.GetString("BtnAceptar.AccessibleDescription");
			this.BtnAceptar.AccessibleName = resources.GetString("BtnAceptar.AccessibleName");
			this.BtnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("BtnAceptar.Anchor")));
			this.BtnAceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnAceptar.BackgroundImage")));
			this.BtnAceptar.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("BtnAceptar.Dock")));
			this.BtnAceptar.Enabled = ((bool)(resources.GetObject("BtnAceptar.Enabled")));
			this.BtnAceptar.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("BtnAceptar.FlatStyle")));
			this.BtnAceptar.Font = ((System.Drawing.Font)(resources.GetObject("BtnAceptar.Font")));
			this.BtnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("BtnAceptar.Image")));
			this.BtnAceptar.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("BtnAceptar.ImageAlign")));
			this.BtnAceptar.ImageIndex = ((int)(resources.GetObject("BtnAceptar.ImageIndex")));
			this.BtnAceptar.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("BtnAceptar.ImeMode")));
			this.BtnAceptar.Location = ((System.Drawing.Point)(resources.GetObject("BtnAceptar.Location")));
			this.BtnAceptar.Name = "BtnAceptar";
			this.BtnAceptar.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("BtnAceptar.RightToLeft")));
			this.BtnAceptar.Size = ((System.Drawing.Size)(resources.GetObject("BtnAceptar.Size")));
			this.BtnAceptar.TabIndex = ((int)(resources.GetObject("BtnAceptar.TabIndex")));
			this.BtnAceptar.Text = resources.GetString("BtnAceptar.Text");
			this.BtnAceptar.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("BtnAceptar.TextAlign")));
			this.BtnAceptar.Visible = ((bool)(resources.GetObject("BtnAceptar.Visible")));
			this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
			// 
			// BtnCancelar
			// 
			this.BtnCancelar.AccessibleDescription = resources.GetString("BtnCancelar.AccessibleDescription");
			this.BtnCancelar.AccessibleName = resources.GetString("BtnCancelar.AccessibleName");
			this.BtnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("BtnCancelar.Anchor")));
			this.BtnCancelar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnCancelar.BackgroundImage")));
			this.BtnCancelar.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("BtnCancelar.Dock")));
			this.BtnCancelar.Enabled = ((bool)(resources.GetObject("BtnCancelar.Enabled")));
			this.BtnCancelar.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("BtnCancelar.FlatStyle")));
			this.BtnCancelar.Font = ((System.Drawing.Font)(resources.GetObject("BtnCancelar.Font")));
			this.BtnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("BtnCancelar.Image")));
			this.BtnCancelar.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("BtnCancelar.ImageAlign")));
			this.BtnCancelar.ImageIndex = ((int)(resources.GetObject("BtnCancelar.ImageIndex")));
			this.BtnCancelar.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("BtnCancelar.ImeMode")));
			this.BtnCancelar.Location = ((System.Drawing.Point)(resources.GetObject("BtnCancelar.Location")));
			this.BtnCancelar.Name = "BtnCancelar";
			this.BtnCancelar.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("BtnCancelar.RightToLeft")));
			this.BtnCancelar.Size = ((System.Drawing.Size)(resources.GetObject("BtnCancelar.Size")));
			this.BtnCancelar.TabIndex = ((int)(resources.GetObject("BtnCancelar.TabIndex")));
			this.BtnCancelar.Text = resources.GetString("BtnCancelar.Text");
			this.BtnCancelar.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("BtnCancelar.TextAlign")));
			this.BtnCancelar.Visible = ((bool)(resources.GetObject("BtnCancelar.Visible")));
			// 
			// AbreDlg
			// 
			this.AbreDlg.Filter = resources.GetString("AbreDlg.Filter");
			this.AbreDlg.Title = resources.GetString("AbreDlg.Title");
			// 
			// CargaCompo
			// 
			this.AccessibleDescription = resources.GetString("$this.AccessibleDescription");
			this.AccessibleName = resources.GetString("$this.AccessibleName");
			this.AutoScaleBaseSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScaleBaseSize")));
			this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
			this.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMargin")));
			this.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMinSize")));
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = ((System.Drawing.Size)(resources.GetObject("$this.ClientSize")));
			this.Controls.Add(this.BtnCancelar);
			this.Controls.Add(this.BtnAceptar);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnBusca);
			this.Controls.Add(this.PathCompo);
			this.Controls.Add(this.label1);
			this.Enabled = ((bool)(resources.GetObject("$this.Enabled")));
			this.Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
			this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
			this.MaximumSize = ((System.Drawing.Size)(resources.GetObject("$this.MaximumSize")));
			this.MinimumSize = ((System.Drawing.Size)(resources.GetObject("$this.MinimumSize")));
			this.Name = "CargaCompo";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			this.Closed += new System.EventHandler(this.CargaCompo_Closed);
			this.ResumeLayout(false);
		}
		#endregion



		private void PonTextTabsItems(string[] lista)
		{
			this.comboBox1.Items.Clear();
			this.PathCompo.Clear();
			int tam;
			tam=lista.Length;
			if (tam>1)
			{
				for (int i = 0; i < tam; i++)
				{
					this.comboBox1.Items.Add(lista[i]);
				}
			}

			if (tam==1)
			{
				this.comboBox1.Items.Add(lista[0]);
			}
		}





		private void btnBusca_Click(object sender, System.EventArgs e)
		{
		   if (AbreDlg.ShowDialog()==DialogResult.OK)
		   {
				PathCompo.Text=AbreDlg.FileName;
		   }
		}




		private bool NuevoItem(string textCombo)
		{
			string[] todosItems;
			int		 numeroItems;
			bool	 salida;
//
			salida=true;
			numeroItems=this.comboBox1.Items.Count;
			todosItems=new string[numeroItems];

			if (numeroItems>1)
			{
				for (int i = 0; i < numeroItems-1; i++)
				{
					todosItems[i]=(string)this.comboBox1.Items[i];
				}

				for (int i = 0; i < numeroItems-1; i++)
				{
					if (textCombo==todosItems[i])
					{
						salida=false;
						break;
					}
				}
			}

			if (numeroItems==1)
			{
				if (textCombo==(string)this.comboBox1.Items[0])
				{
					salida=false;
				}
			}

		   return salida;
		}






		private void BtnAceptar_Click(object sender, System.EventArgs e)
		{

			bool   nuevoItem;

			if (this.comboBox1.Text!="")
			{
				nuevoItem=NuevoItem(this.comboBox1.Text);
				if (nuevoItem)
				{
					this.comboBox1.Items.Add(this.comboBox1.Text);
				}
			}

		   this.Close();
		}





		private void CargaCompo_Closed(object sender, System.EventArgs e)
		{
			string[] tabss;
			int nu;
			string   dll;

			if (this.PathCompo.Text!="" && this.comboBox1.Text!="")
			{
					nu=this.comboBox1.Items.Count;
					tabss=new string[nu];

					for (int i = 0; i < nu; i++)
					{
						tabss[i]=(string)this.comboBox1.Items[i];
					}

					dll=this.PathCompo.Text;

					this.paleta.NuevasTabs=tabss;
					this.paleta.DllParaCopiar=dll;


					this.PathCompo.Clear();
					this.comboBox1.Items.Clear();
            }

		  }

	}
}
