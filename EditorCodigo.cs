using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Reflection;

namespace Carga_Dlls_Dinam
{
	/// <summary>
	/// Summary description for WinForm.
	/// </summary>
	public class EditorCodigo : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button button1;


		/// información necesaria
		private string codigoAsociado;        // el codigo agregado por el usuario
		private int    idComponente;		  // id del componente que contiene el evento al que se le está asociando el codigo
		private int	   idFrame;				  // id del frame donde esta contenido el componente que genera el evento
		private string eventoActual;		  // nombre del evento al que se le asocia el codigo
		private string tipoEvento;			  // el tipo
		private string tipoComponente;        // el tipo del compo
		private EventInfo eventoRelacionado;  // el evento como tal
		private string[] listaMetodos;
		private bool   viendose;


		/// instancia del frame de paleta para pasar información de este
		/// editor de codigo a la paleta de componentes
		private Paleta paleta;
		private System.Windows.Forms.TextBox codigo;
		private System.Windows.Forms.Button button2;




		public bool Viendose
		{
			get
			{
				return viendose;
			}
			set
			{
				viendose=value;
			}
        }


		public string[] ListaMetodos
		{
			get
			{
				return listaMetodos;
			}
			set
			{
				listaMetodos=value;
            }
        }




		/// tipo del evento al que se le asocia el codigo introducido
		public string TipoEvento
		{
			get
			{
				return tipoEvento;
			}
			set
			{
				tipoEvento=value;
			}
		}


		/// el evento al que se le está asoaciando codigo
		public EventInfo EventoRelacionado
		{
			get
			{
				return eventoRelacionado;
			}
			set
			{
				eventoRelacionado=value;
			}
		}


		/// el tipo del componente al que pertenece el evento al que se le esta
		/// asociando el codigo
		public string TipoComponente
		{
			get
			{
				return tipoComponente;
			}
			set
			{
				tipoComponente=value;
			}
		}


		/// id del componente al que pertenece el evento al que se le está
		/// asociando el codigo
		public int IdComponente
		{
			get
			{
				return idComponente;
			}
			set
			{
				idComponente=value;
			}
		}


		/// id relacionado con el frame que contiene el componente que esta
		/// emitiendo el evento
		public int IdFrame
		{
			get
			{
				return idFrame;
			}
			set
			{
                idFrame=value;
            }
        }



		/// nombre del evento (string) al qie se le asocia codigo
		public string EventoActual
		{
			get
			{
				return eventoActual;
			}
			set
			{
				eventoActual=value;
			}
		}



		/// el codigo insertado
		public string CodigoAsociado
		{
			get
			{
				return codigoAsociado;
			}
			set
			{
				this.codigo.Clear();
				string[] lineas=value.Split('\n');
				int nuLin=lineas.Length;
				for (int i = 0; i < nuLin; i++)
				{
					lineas[i]=lineas[i].Replace("\n","");
				}
				this.codigo.Lines=lineas;

				nuLin=this.codigo.Lines.Length;
				for (int u = 0; u < nuLin; u++)
				{
					this.codigo.Lines[u]=this.codigo.Lines[u].Replace("\n","");
                    this.codigo.Refresh();
                }


				codigoAsociado=this.codigo.Text;
            }
        }


		public EditorCodigo(Paleta paleta)
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.codigo = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.button1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 434);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(642, 44);
			this.panel1.TabIndex = 0;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(458, 10);
			this.button2.Name = "button2";
			this.button2.TabIndex = 1;
			this.button2.Text = "Cancelar";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(548, 10);
			this.button1.Name = "button1";
			this.button1.TabIndex = 0;
			this.button1.Text = "Aceptar";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// codigo
			// 
			this.codigo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.codigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.codigo.Location = new System.Drawing.Point(0, 0);
			this.codigo.Multiline = true;
			this.codigo.Name = "codigo";
			this.codigo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.codigo.Size = new System.Drawing.Size(642, 434);
			this.codigo.TabIndex = 1;
			this.codigo.Text = "";
			// 
			// EditorCodigo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(642, 478);
			this.Controls.Add(this.codigo);
			this.Controls.Add(this.panel1);
			this.Name = "EditorCodigo";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Editor de Codigo";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.EditorCodigo_Closing);
			this.VisibleChanged += new System.EventHandler(this.EditorCodigo_VisibleChanged);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.EditorCodigo_Paint);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		#endregion


		/// al cerrar el editor de codigo
		private void button1_Click(object sender, System.EventArgs e)
		{
			// 1. Obtiene los argumentos del evento como cadena y pasa ese valor a la paleta
			this.paleta.TipoArgumentos=this.paleta.DameTiposParametrosEvento(this.EventoRelacionado)[1];
			// 2. Obtiene el tipo de componente al que se le asocia codigo y manda a paleta
			this.paleta.TipoComponente=this.TipoComponente;
			// 3. se obtiene el tipo de evento y manda a paleta
			this.paleta.TipoEventoActivado=this.TipoEvento;

			// 5. se da de alta el codigo asociado en la estructura "controlEventos"

			Paleta.PonCodigoAsociado(this.IdComponente,this.IdFrame,this.EventoActual,this.codigo.Lines);

			// 4. activa la compilación
			this.paleta.CompilacionP=this.codigo.Text;

			// 6. se cierra la ventana
			this.Viendose=false;

			if (this.paleta.resulCompilacion!=DialogResult.OK && this.paleta.resulCompilacion!=DialogResult.No)	this.Hide();
		}
		
		private void EditorCodigo_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
             e.Cancel=true;
			 this.Hide();
		}
		
		private void EditorCodigo_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{

		}
		
		private void codigo_VisibleChanged(object sender, System.EventArgs e)
		{
			if (this.Visible)
			{
			}

		}
		
		private void EditorCodigo_VisibleChanged(object sender, System.EventArgs e)
		{



		}


		public void InsertaMetodo(object o,Dinamica.Eventos.EnviaMetodoEventArgs emea)
		{
			if (this.Viendose==true)
			{
				 string cadena=emea.cadenaDeMetodo;
				 cadena=cadena.Replace("Void ","");
				 int indice=this.codigo.SelectionStart;
				 codigo.Text= codigo.Text.Insert(indice,cadena);
				 this.Activate();
            }
		}
		
		private void button2_Click(object sender, System.EventArgs e)
		{
            this.Hide();
		}
		
	}
}

