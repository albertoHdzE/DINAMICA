using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Reflection;
using Dinamica;
using ComponentesIDEdinamica;
using System.CodeDom.Compiler;
using Microsoft.CSharp;  //Da acceso a la definición de C#
using System.Runtime.Remoting;
using RectTrackerSharp;
using System.Runtime.InteropServices;




namespace Carga_Dlls_Dinam
{




                                             
	/// ************************************************************
	/// de esta clase hereda la plantilla que representa la clase
	/// que es compilada en tiempo de diseño, cada vez que se cierra
	/// el editor de código para verificar errores en el código del
	/// usuario
	/// *************************************************************
	///
public class MiVirtual
{
	public virtual void Inicia(System.Windows.Forms.Control.ControlCollection al,System.Object ev)
	{
		 System.Windows.Forms.MessageBox.Show("ACA");
	}
}


public class MiVirtual2
{
	public virtual void AsignaProps(BaseDinamica[] ArrayCompos)
	{

	}
}

public class MiVirtualTabs
{
	public virtual void AsignaTabs(object[] ArrayCompos)
	{

    }
}








public class Paleta : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.TabControl Tabs;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItemArchivo;
		private System.Windows.Forms.MenuItem menuItemNuevo;
		private System.Windows.Forms.MenuItem menuItemComponentes;
		private System.Windows.Forms.MenuItem menuItemCargar;
		private System.Windows.Forms.MenuItem menuItemBorrar;



	/// *********************************************************
		/// esta es la platilla la cual representa la clase PRINCIPAL que es
		/// compilada en tiempo de diseño en Dinámica (cuando se)
		/// cierra el editor de código.
		///
		public const string Template =
		@"using System;
			using System.Windows.Forms;

			namespace Carga_Dlls_Dinam
			{
			 public class PruebaCod : MiVirtual {
			   //	public event <TIPO_EVENTOS> eventos;

				public override void Inicia(System.Windows.Forms.Control.ControlCollection al,System.Object ev)
				{
				  <TIPO_EVENTOS> eventos=(<TIPO_EVENTOS>)ev;

				<VARIABLES>
				try{
				<CODIGO>
				}
				catch(Exception e)
				{System.Windows.Forms.MessageBox.Show(e.Message);}
				}
			}
			}";

public const string miClasesita =
		@"using System;
			using System.Windows.Forms;
			using Dinamica;
			using System.Drawing;
			using System.Collections;

			namespace Carga_Dlls_Dinam
			{
			 public class AplicaPropiedades : MiVirtual2 {
				public override void AsignaProps(BaseDinamica[] ArrayCompos) {
				try{
				<CODIGO>
				}
				catch(Exception e)
				{System.Windows.Forms.MessageBox.Show(e.Message);}
				}
	   }
			}";


public const string ClasesitaTabs =
      @"using System;
			using System.Windows.Forms;
			using Dinamica;
			using System.Drawing;
			using System.Collections;

			namespace Carga_Dlls_Dinam
			{
			 public class AplicaPropiedades : MiVirtualTabs {
				public override void AsignaTabs(object[] ArrayCompos) {
				try{
				<CODIGO>
				}
				catch(Exception e)
				{System.Windows.Forms.MessageBox.Show(e.Message);}
				}
	   }
			}";





	  /// ***********************************************************
	   /// Esta es la clase de cada una de las formas instanciadas
	   ///
	   public const string ClaseInstanciada =
	   @"
		  namespace MiEspacio
		  {
			  public class <NOMBRE CLASE INSTANCIADA> : System.Windows.Forms.Form
			  {

				 /// Declaraciones de los componentes contendos en la forma
				 private Principal <NOMBRE CLASE PRINCIPAL>;
				 <DECLARACION VAR COMPONENTES>


				 public  <NOMBRE CLASE INSTANCIADA>(Principal <NOMBRE CLASE PRINCIPAL>)
				 {
					this.<NOMBRE CLASE PRINCIPAL>=<NOMBRE CLASE PRINCIPAL>;
					InicializaComponentes();
					<CONFIGURACION>
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


				  private void InicializaComponentes()
				  {
					 /// Crea todos los componentes contenidos en la forma
					 <CREACION DE VAR COMPONENTES>

					 /// Especificacion de posicion y dimenciones de componentes
					 <CONFIGURACION INICIAL COMPONENTES>

				  }



			  }/// fin de clase


			  ///<CLASE INSTANCIADA>
		  }/// FIN DE MiEspacio

		  "
	   ;




	  /// ***********************************************************
	   /// esta es la plantilla que representa la clase que es compilada
	   /// y de donde se crea el ejecutable de un proyeto generado
	   /// con dinámica
	   ///
	   public const string Plantilla =
	   @"
		  using System;
		  using System.Drawing;
		  using System.Collections;
		  using System.ComponentModel;
		  using System.Windows.Forms;
		  using System.Data;
		  using System.IO;


		  ///<MIS USING>


		  ///<CLASE INSTANCIADA>

		  namespace MiEspacio
		  {
			  public class Principal : System.Windows.Forms.Form
			  {
				 /// Declaraciones de los componentes contendos en la forma de diseño
				 <DECLARACION VAR COMPONENTES>


				 //<DECLARACION DE FRAMES INSTANCIADOS>

				 public  Principal()
				 {

					//<CONSTRUCCION DE FRAMES INSTANCIADOS>
					InicializaComponentes();
                    <CONFIGURACION>

				 }

				  [STAThread]
				  static void Main()
				  {
						Application.Run(new Principal());
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


				  private void InicializaComponentes()
				  {
					 /// Crea todos los componentes contenidos en la forma
					 <CREACION DE VAR COMPONENTES>

					 /// Especificacion de posicion y dimenciones de componentes
					 <CONFIGURACION INICIAL COMPONENTES>

					 /// Direcciona el codigo agregado por usuario a un metodo en la clase
					 <CODIGO EVENTOS>

				  



			  }/// fin de clase

		  }/// fin de namespace"
	   ;






	   /// ************************************************************
	   ///            DOCUMENTACIÓN DE VARIABLES
	   ///
	   /// 1. aCrear. Variable global (estática), define que componente se
	   /// 	  va a agregar a la forma de diseño.
	   /// 2. dllOrigen.Nombre de la clase a cargar.
	   /// 3. controlEventos. Array de estructuras que contiene el codigo
	   /// 	  asociado a un evento agregado por el usuario.
	   ///


	   /// nombre del componente a crear en la forma de diseño
		static public string aCrear="";
		/// dll origen donde se contiene el componente que se va a crear
		static public string dllOrigen="";
		static public System.Collections.ArrayList controlEventos;


		public Disenno       disenno;     		// forma de diseño
		public Inspector     inspector;	  		// inspector de propiedades
		public CargaCompo    cargaCompo;  		// interfaz para agregar dll's de componentes
		public CreaExe		 creaExe;           // ibnterfaz para darle nombre al ejecutable
		public Intro         miIntro;			// forma de prsentación
		public int		     anchoPantalla;
		public int           altoPantalla;
		public DialogResult  resulCompilacion;

		public string        directorio;        // donde se copian las dll's cargadas
		private string[]     nuevasTabs;		// tabs a crear en la paleta guardar los compos de la dll cargada
		private string       dllParaCopiar;     // nombre oroginal de la dll a cargar
		private string       nuevoNombreDll;    // nombre con el que es copiada la dll cargada
		private string       nuevaTab;			// cada una de las tabs a crear
		private string		 compilacion;       // codigo a com pilar
		private string		 tipoEventoActivado;// el tipo de evento al que se le asoció codigo
		private string		 tipoComponente;	// tipo del componente asociado a un boton de la paleta
		private string  	 tipoArgumentos;	// el tipo de los argumentos del evento al que se le asoció código
		private int			 noFrames;	    	//numero de frames en el proyecto
		private System.Collections.ArrayList   nombresFrames=new System.Collections.ArrayList();     // contiene los nombres de los frames.
		public System.Collections.ArrayList    todosFrames=new System.Collections.ArrayList();       // contiene todos los frames de diseño
//		private Disenno[]    copiaTodosFrames;


		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.Button BotonAbrir;
		private System.Windows.Forms.Button BotonGuardar;
		private System.Windows.Forms.Button BotonAddCompo;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button BotonSalir;
		private System.Windows.Forms.Button BotonCrearExe;
		private System.Windows.Forms.Button BotonNewForma;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.MenuItem menuItem11;



		///  se genera una estructura por cada evento al que se le agrega
		/// código por parte del usuario. Cada estructura generada se guarda en
		/// el array controlEventos
		///
		public struct templateEstruct
		{
			public int    idFrame;
			public int    idCompo;
			public string evento;
			public string[] codigo;
		}

		///  una estrucutra para el control de los frames de un proyecto
		public struct controlFrame
		{
			public string ordinalFrame;
			public string nombreFrame;
		}

		private static templateEstruct    codigoAsociado;


		public string[,] relacion=new string[0,2];

		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.OpenFileDialog AbreProyecto;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.SaveFileDialog GuardaProyecto;

#region PROPIEDADES

	   /// contiene las tabas que "deben" estar en la paleta de componentes
       /// cuando se asigna algun valo, se compara con las que existen
       /// si el arreglo que entra es diferente al original, entonces
	   /// se actualizan los tabs

	   public string[] NuevasTabs
		{
			get
			{
			  return nuevasTabs;
			}
			set
			{
				nuevasTabs=value;
				ActualizaTabs(value);
			}
		}


        /// mediante la asignación se esta prop, se copian las dll's
		/// de los componentes a cargar en el directorio de DINAMICA
		public string DllParaCopiar
		{
			get
			{
				return dllParaCopiar;
			}
			set
			{
				dllParaCopiar=value;
				CopiaArchivos(value,true);
			}
		}


		/// activa el proceso de compilación
		public string CompilacionP
		{
			get
			{
				return compilacion;
			}
			set
			{
				compilacion=value;
				//Compilacion(value);
				Ejecuta2("",false);
			}
		}

		/// tipo de evento al que se le ha asociado código
		public string TipoEventoActivado
		{
			get
			{
				return tipoEventoActivado;
			}
			set
            {
				tipoEventoActivado=value;
            }
		}


		/// el tipo de los argumentos del evento al que se le ha
		/// asociado código
		public string TipoArgumentos
		{
			get
            {
				return tipoArgumentos;
			}
			set
			{
                tipoArgumentos=value;
            }
		}


		/// el tipo del componente al que se le ha asiciado código
        /// a alguno de sus eventos
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




#endregion



		public Paleta()
		{

			/// Hilo para la forma de presentación de DINAMICA
			System.Threading.Thread th = new System.Threading.Thread(new System.Threading.ThreadStart(DoSplash));
			th.Start();
			System.Threading.Thread.Sleep(3000);
			th.Abort();
			System.Threading.Thread.Sleep(1000);

			// se toman las dimensiones en pantalla y el directorio de DINAMICA
			anchoPantalla=System.Windows.Forms.Screen.GetBounds(new Point (0,0)).Width;
			altoPantalla=System.Windows.Forms.Screen.GetBounds(new Point(0,0)).Height;
			directorio=System.IO.Directory.GetCurrentDirectory();

			InitializeComponent();

			// se dimensiona el IDE a la pantalla actual
			this.Resize += new System.EventHandler(Redimensiona);
			this.Width=anchoPantalla;
			this.Height=135;
			this.Tabs.Width=this.Width-100;

			/// se crean todo el IDE
			creaExe   = new CreaExe(this);
			inspector = new Inspector(this,disenno);
			disenno   = new Disenno(this,inspector);

			///  éstructura para guardar el codigo asiciado a eventos
			controlEventos =new System.Collections.ArrayList();

			/// INSPECTOR
			inspector.Location=new Point(7,165);
			inspector.Height=altoPantalla-300;
			inspector.Show();
			this.AddOwnedForm(inspector);

			/// FORMA DE DISEÑO
			disenno.Location=new Point(anchoPantalla - (anchoPantalla-250),165);
			disenno.Height=altoPantalla-300;
			disenno.Width=anchoPantalla-250;
			disenno.EnviaObjeto+=new  Dinamica.Eventos.EnviaObjetoEventHandler(inspector.PonPropiedades);
			disenno.EnviaObjeto+=new  Dinamica.Eventos.EnviaObjetoEventHandler(this.VerificaAgregaNombresFrames);
			disenno.Show();
			this.AddOwnedForm(disenno);
			///  la forma de diseño se agrega al control de FD del proyecto actual
			controlFrame inicial;
			inicial.ordinalFrame="1";
			inicial.nombreFrame="Forma1";
			nombresFrames.Add(inicial);
			noFrames=1;
			todosFrames.Add(disenno);


			CargaDllsCfgEnTab();

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Paleta));
			this.Tabs = new System.Windows.Forms.TabControl();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItemArchivo = new System.Windows.Forms.MenuItem();
			this.menuItemNuevo = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItemComponentes = new System.Windows.Forms.MenuItem();
			this.menuItemCargar = new System.Windows.Forms.MenuItem();
			this.menuItemBorrar = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.menuItem11 = new System.Windows.Forms.MenuItem();
			this.AbreProyecto = new System.Windows.Forms.OpenFileDialog();
			this.GuardaProyecto = new System.Windows.Forms.SaveFileDialog();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.BotonNewForma = new System.Windows.Forms.Button();
			this.BotonCrearExe = new System.Windows.Forms.Button();
			this.BotonSalir = new System.Windows.Forms.Button();
			this.BotonAddCompo = new System.Windows.Forms.Button();
			this.BotonGuardar = new System.Windows.Forms.Button();
			this.BotonAbrir = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// Tabs
			// 
			this.Tabs.AccessibleDescription = resources.GetString("Tabs.AccessibleDescription");
			this.Tabs.AccessibleName = resources.GetString("Tabs.AccessibleName");
			this.Tabs.Alignment = ((System.Windows.Forms.TabAlignment)(resources.GetObject("Tabs.Alignment")));
			this.Tabs.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Tabs.Anchor")));
			this.Tabs.Appearance = ((System.Windows.Forms.TabAppearance)(resources.GetObject("Tabs.Appearance")));
			this.Tabs.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Tabs.BackgroundImage")));
			this.Tabs.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Tabs.Dock")));
			this.Tabs.Enabled = ((bool)(resources.GetObject("Tabs.Enabled")));
			this.Tabs.Font = ((System.Drawing.Font)(resources.GetObject("Tabs.Font")));
			this.Tabs.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Tabs.ImeMode")));
			this.Tabs.ItemSize = ((System.Drawing.Size)(resources.GetObject("Tabs.ItemSize")));
			this.Tabs.Location = ((System.Drawing.Point)(resources.GetObject("Tabs.Location")));
			this.Tabs.Name = "Tabs";
			this.Tabs.Padding = ((System.Drawing.Point)(resources.GetObject("Tabs.Padding")));
			this.Tabs.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Tabs.RightToLeft")));
			this.Tabs.SelectedIndex = 0;
			this.Tabs.ShowToolTips = ((bool)(resources.GetObject("Tabs.ShowToolTips")));
			this.Tabs.Size = ((System.Drawing.Size)(resources.GetObject("Tabs.Size")));
			this.Tabs.TabIndex = ((int)(resources.GetObject("Tabs.TabIndex")));
			this.Tabs.Text = resources.GetString("Tabs.Text");
			this.toolTip1.SetToolTip(this.Tabs, resources.GetString("Tabs.ToolTip"));
			this.Tabs.Visible = ((bool)(resources.GetObject("Tabs.Visible")));
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
						this.menuItemArchivo,
						this.menuItemComponentes,
						this.menuItem1,
						this.menuItem8,
						this.menuItem10});
			this.mainMenu1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("mainMenu1.RightToLeft")));
			// 
			// menuItemArchivo
			// 
			this.menuItemArchivo.Enabled = ((bool)(resources.GetObject("menuItemArchivo.Enabled")));
			this.menuItemArchivo.Index = 0;
			this.menuItemArchivo.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
						this.menuItemNuevo,
						this.menuItem3,
						this.menuItem4,
						this.menuItem7});
			this.menuItemArchivo.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuItemArchivo.Shortcut")));
			this.menuItemArchivo.ShowShortcut = ((bool)(resources.GetObject("menuItemArchivo.ShowShortcut")));
			this.menuItemArchivo.Text = resources.GetString("menuItemArchivo.Text");
			this.menuItemArchivo.Visible = ((bool)(resources.GetObject("menuItemArchivo.Visible")));
			// 
			// menuItemNuevo
			// 
			this.menuItemNuevo.Enabled = ((bool)(resources.GetObject("menuItemNuevo.Enabled")));
			this.menuItemNuevo.Index = 0;
			this.menuItemNuevo.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuItemNuevo.Shortcut")));
			this.menuItemNuevo.ShowShortcut = ((bool)(resources.GetObject("menuItemNuevo.ShowShortcut")));
			this.menuItemNuevo.Text = resources.GetString("menuItemNuevo.Text");
			this.menuItemNuevo.Visible = ((bool)(resources.GetObject("menuItemNuevo.Visible")));
			this.menuItemNuevo.Click += new System.EventHandler(this.menuItemNuevo_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Enabled = ((bool)(resources.GetObject("menuItem3.Enabled")));
			this.menuItem3.Index = 1;
			this.menuItem3.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuItem3.Shortcut")));
			this.menuItem3.ShowShortcut = ((bool)(resources.GetObject("menuItem3.ShowShortcut")));
			this.menuItem3.Text = resources.GetString("menuItem3.Text");
			this.menuItem3.Visible = ((bool)(resources.GetObject("menuItem3.Visible")));
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Enabled = ((bool)(resources.GetObject("menuItem4.Enabled")));
			this.menuItem4.Index = 2;
			this.menuItem4.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuItem4.Shortcut")));
			this.menuItem4.ShowShortcut = ((bool)(resources.GetObject("menuItem4.ShowShortcut")));
			this.menuItem4.Text = resources.GetString("menuItem4.Text");
			this.menuItem4.Visible = ((bool)(resources.GetObject("menuItem4.Visible")));
			// 
			// menuItem7
			// 
			this.menuItem7.Enabled = ((bool)(resources.GetObject("menuItem7.Enabled")));
			this.menuItem7.Index = 3;
			this.menuItem7.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuItem7.Shortcut")));
			this.menuItem7.ShowShortcut = ((bool)(resources.GetObject("menuItem7.ShowShortcut")));
			this.menuItem7.Text = resources.GetString("menuItem7.Text");
			this.menuItem7.Visible = ((bool)(resources.GetObject("menuItem7.Visible")));
			this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
			// 
			// menuItemComponentes
			// 
			this.menuItemComponentes.Enabled = ((bool)(resources.GetObject("menuItemComponentes.Enabled")));
			this.menuItemComponentes.Index = 1;
			this.menuItemComponentes.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
						this.menuItemCargar,
						this.menuItemBorrar});
			this.menuItemComponentes.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuItemComponentes.Shortcut")));
			this.menuItemComponentes.ShowShortcut = ((bool)(resources.GetObject("menuItemComponentes.ShowShortcut")));
			this.menuItemComponentes.Text = resources.GetString("menuItemComponentes.Text");
			this.menuItemComponentes.Visible = ((bool)(resources.GetObject("menuItemComponentes.Visible")));
			// 
			// menuItemCargar
			// 
			this.menuItemCargar.Enabled = ((bool)(resources.GetObject("menuItemCargar.Enabled")));
			this.menuItemCargar.Index = 0;
			this.menuItemCargar.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuItemCargar.Shortcut")));
			this.menuItemCargar.ShowShortcut = ((bool)(resources.GetObject("menuItemCargar.ShowShortcut")));
			this.menuItemCargar.Text = resources.GetString("menuItemCargar.Text");
			this.menuItemCargar.Visible = ((bool)(resources.GetObject("menuItemCargar.Visible")));
			this.menuItemCargar.Click += new System.EventHandler(this.menuItemCargar_Click);
			// 
			// menuItemBorrar
			// 
			this.menuItemBorrar.Enabled = ((bool)(resources.GetObject("menuItemBorrar.Enabled")));
			this.menuItemBorrar.Index = 1;
			this.menuItemBorrar.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuItemBorrar.Shortcut")));
			this.menuItemBorrar.ShowShortcut = ((bool)(resources.GetObject("menuItemBorrar.ShowShortcut")));
			this.menuItemBorrar.Text = resources.GetString("menuItemBorrar.Text");
			this.menuItemBorrar.Visible = ((bool)(resources.GetObject("menuItemBorrar.Visible")));
			// 
			// menuItem1
			// 
			this.menuItem1.Enabled = ((bool)(resources.GetObject("menuItem1.Enabled")));
			this.menuItem1.Index = 2;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
						this.menuItem2,
						this.menuItem5});
			this.menuItem1.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuItem1.Shortcut")));
			this.menuItem1.ShowShortcut = ((bool)(resources.GetObject("menuItem1.ShowShortcut")));
			this.menuItem1.Text = resources.GetString("menuItem1.Text");
			this.menuItem1.Visible = ((bool)(resources.GetObject("menuItem1.Visible")));
			// 
			// menuItem2
			// 
			this.menuItem2.Enabled = ((bool)(resources.GetObject("menuItem2.Enabled")));
			this.menuItem2.Index = 0;
			this.menuItem2.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuItem2.Shortcut")));
			this.menuItem2.ShowShortcut = ((bool)(resources.GetObject("menuItem2.ShowShortcut")));
			this.menuItem2.Text = resources.GetString("menuItem2.Text");
			this.menuItem2.Visible = ((bool)(resources.GetObject("menuItem2.Visible")));
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Enabled = ((bool)(resources.GetObject("menuItem5.Enabled")));
			this.menuItem5.Index = 1;
			this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
						this.menuItem6});
			this.menuItem5.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuItem5.Shortcut")));
			this.menuItem5.ShowShortcut = ((bool)(resources.GetObject("menuItem5.ShowShortcut")));
			this.menuItem5.Text = resources.GetString("menuItem5.Text");
			this.menuItem5.Visible = ((bool)(resources.GetObject("menuItem5.Visible")));
			// 
			// menuItem6
			// 
			this.menuItem6.Enabled = ((bool)(resources.GetObject("menuItem6.Enabled")));
			this.menuItem6.Index = 0;
			this.menuItem6.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuItem6.Shortcut")));
			this.menuItem6.ShowShortcut = ((bool)(resources.GetObject("menuItem6.ShowShortcut")));
			this.menuItem6.Text = resources.GetString("menuItem6.Text");
			this.menuItem6.Visible = ((bool)(resources.GetObject("menuItem6.Visible")));
			this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click1);
			// 
			// menuItem8
			// 
			this.menuItem8.Enabled = ((bool)(resources.GetObject("menuItem8.Enabled")));
			this.menuItem8.Index = 3;
			this.menuItem8.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
						this.menuItem9});
			this.menuItem8.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuItem8.Shortcut")));
			this.menuItem8.ShowShortcut = ((bool)(resources.GetObject("menuItem8.ShowShortcut")));
			this.menuItem8.Text = resources.GetString("menuItem8.Text");
			this.menuItem8.Visible = ((bool)(resources.GetObject("menuItem8.Visible")));
			// 
			// menuItem9
			// 
			this.menuItem9.Enabled = ((bool)(resources.GetObject("menuItem9.Enabled")));
			this.menuItem9.Index = 0;
			this.menuItem9.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuItem9.Shortcut")));
			this.menuItem9.ShowShortcut = ((bool)(resources.GetObject("menuItem9.ShowShortcut")));
			this.menuItem9.Text = resources.GetString("menuItem9.Text");
			this.menuItem9.Visible = ((bool)(resources.GetObject("menuItem9.Visible")));
			this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
			// 
			// menuItem10
			// 
			this.menuItem10.Enabled = ((bool)(resources.GetObject("menuItem10.Enabled")));
			this.menuItem10.Index = 4;
			this.menuItem10.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
						this.menuItem11});
			this.menuItem10.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuItem10.Shortcut")));
			this.menuItem10.ShowShortcut = ((bool)(resources.GetObject("menuItem10.ShowShortcut")));
			this.menuItem10.Text = resources.GetString("menuItem10.Text");
			this.menuItem10.Visible = ((bool)(resources.GetObject("menuItem10.Visible")));
			// 
			// menuItem11
			// 
			this.menuItem11.Enabled = ((bool)(resources.GetObject("menuItem11.Enabled")));
			this.menuItem11.Index = 0;
			this.menuItem11.Shortcut = ((System.Windows.Forms.Shortcut)(resources.GetObject("menuItem11.Shortcut")));
			this.menuItem11.ShowShortcut = ((bool)(resources.GetObject("menuItem11.ShowShortcut")));
			this.menuItem11.Text = resources.GetString("menuItem11.Text");
			this.menuItem11.Visible = ((bool)(resources.GetObject("menuItem11.Visible")));
			this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
			// 
			// AbreProyecto
			// 
			this.AbreProyecto.Filter = resources.GetString("AbreProyecto.Filter");
			this.AbreProyecto.Title = resources.GetString("AbreProyecto.Title");
			// 
			// GuardaProyecto
			// 
			this.GuardaProyecto.Filter = resources.GetString("GuardaProyecto.Filter");
			this.GuardaProyecto.Title = resources.GetString("GuardaProyecto.Title");
			// 
			// panel1
			// 
			this.panel1.AccessibleDescription = resources.GetString("panel1.AccessibleDescription");
			this.panel1.AccessibleName = resources.GetString("panel1.AccessibleName");
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("panel1.Anchor")));
			this.panel1.AutoScroll = ((bool)(resources.GetObject("panel1.AutoScroll")));
			this.panel1.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("panel1.AutoScrollMargin")));
			this.panel1.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("panel1.AutoScrollMinSize")));
			this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
			this.panel1.Controls.Add(this.BotonNewForma);
			this.panel1.Controls.Add(this.BotonCrearExe);
			this.panel1.Controls.Add(this.BotonSalir);
			this.panel1.Controls.Add(this.BotonAddCompo);
			this.panel1.Controls.Add(this.BotonGuardar);
			this.panel1.Controls.Add(this.BotonAbrir);
			this.panel1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("panel1.Dock")));
			this.panel1.Enabled = ((bool)(resources.GetObject("panel1.Enabled")));
			this.panel1.Font = ((System.Drawing.Font)(resources.GetObject("panel1.Font")));
			this.panel1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("panel1.ImeMode")));
			this.panel1.Location = ((System.Drawing.Point)(resources.GetObject("panel1.Location")));
			this.panel1.Name = "panel1";
			this.panel1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("panel1.RightToLeft")));
			this.panel1.Size = ((System.Drawing.Size)(resources.GetObject("panel1.Size")));
			this.panel1.TabIndex = ((int)(resources.GetObject("panel1.TabIndex")));
			this.panel1.Text = resources.GetString("panel1.Text");
			this.toolTip1.SetToolTip(this.panel1, resources.GetString("panel1.ToolTip"));
			this.panel1.Visible = ((bool)(resources.GetObject("panel1.Visible")));
			// 
			// BotonNewForma
			// 
			this.BotonNewForma.AccessibleDescription = resources.GetString("BotonNewForma.AccessibleDescription");
			this.BotonNewForma.AccessibleName = resources.GetString("BotonNewForma.AccessibleName");
			this.BotonNewForma.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("BotonNewForma.Anchor")));
			this.BotonNewForma.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BotonNewForma.BackgroundImage")));
			this.BotonNewForma.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("BotonNewForma.Dock")));
			this.BotonNewForma.Enabled = ((bool)(resources.GetObject("BotonNewForma.Enabled")));
			this.BotonNewForma.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("BotonNewForma.FlatStyle")));
			this.BotonNewForma.Font = ((System.Drawing.Font)(resources.GetObject("BotonNewForma.Font")));
			this.BotonNewForma.Image = ((System.Drawing.Image)(resources.GetObject("BotonNewForma.Image")));
			this.BotonNewForma.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("BotonNewForma.ImageAlign")));
			this.BotonNewForma.ImageIndex = ((int)(resources.GetObject("BotonNewForma.ImageIndex")));
			this.BotonNewForma.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("BotonNewForma.ImeMode")));
			this.BotonNewForma.Location = ((System.Drawing.Point)(resources.GetObject("BotonNewForma.Location")));
			this.BotonNewForma.Name = "BotonNewForma";
			this.BotonNewForma.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("BotonNewForma.RightToLeft")));
			this.BotonNewForma.Size = ((System.Drawing.Size)(resources.GetObject("BotonNewForma.Size")));
			this.BotonNewForma.TabIndex = ((int)(resources.GetObject("BotonNewForma.TabIndex")));
			this.BotonNewForma.Text = resources.GetString("BotonNewForma.Text");
			this.BotonNewForma.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("BotonNewForma.TextAlign")));
			this.toolTip1.SetToolTip(this.BotonNewForma, resources.GetString("BotonNewForma.ToolTip"));
			this.BotonNewForma.Visible = ((bool)(resources.GetObject("BotonNewForma.Visible")));
			this.BotonNewForma.Click += new System.EventHandler(this.menuItem6_Click);
			// 
			// BotonCrearExe
			// 
			this.BotonCrearExe.AccessibleDescription = resources.GetString("BotonCrearExe.AccessibleDescription");
			this.BotonCrearExe.AccessibleName = resources.GetString("BotonCrearExe.AccessibleName");
			this.BotonCrearExe.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("BotonCrearExe.Anchor")));
			this.BotonCrearExe.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BotonCrearExe.BackgroundImage")));
			this.BotonCrearExe.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("BotonCrearExe.Dock")));
			this.BotonCrearExe.Enabled = ((bool)(resources.GetObject("BotonCrearExe.Enabled")));
			this.BotonCrearExe.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("BotonCrearExe.FlatStyle")));
			this.BotonCrearExe.Font = ((System.Drawing.Font)(resources.GetObject("BotonCrearExe.Font")));
			this.BotonCrearExe.Image = ((System.Drawing.Image)(resources.GetObject("BotonCrearExe.Image")));
			this.BotonCrearExe.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("BotonCrearExe.ImageAlign")));
			this.BotonCrearExe.ImageIndex = ((int)(resources.GetObject("BotonCrearExe.ImageIndex")));
			this.BotonCrearExe.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("BotonCrearExe.ImeMode")));
			this.BotonCrearExe.Location = ((System.Drawing.Point)(resources.GetObject("BotonCrearExe.Location")));
			this.BotonCrearExe.Name = "BotonCrearExe";
			this.BotonCrearExe.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("BotonCrearExe.RightToLeft")));
			this.BotonCrearExe.Size = ((System.Drawing.Size)(resources.GetObject("BotonCrearExe.Size")));
			this.BotonCrearExe.TabIndex = ((int)(resources.GetObject("BotonCrearExe.TabIndex")));
			this.BotonCrearExe.Text = resources.GetString("BotonCrearExe.Text");
			this.BotonCrearExe.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("BotonCrearExe.TextAlign")));
			this.toolTip1.SetToolTip(this.BotonCrearExe, resources.GetString("BotonCrearExe.ToolTip"));
			this.BotonCrearExe.Visible = ((bool)(resources.GetObject("BotonCrearExe.Visible")));
			this.BotonCrearExe.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// BotonSalir
			// 
			this.BotonSalir.AccessibleDescription = resources.GetString("BotonSalir.AccessibleDescription");
			this.BotonSalir.AccessibleName = resources.GetString("BotonSalir.AccessibleName");
			this.BotonSalir.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("BotonSalir.Anchor")));
			this.BotonSalir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BotonSalir.BackgroundImage")));
			this.BotonSalir.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("BotonSalir.Dock")));
			this.BotonSalir.Enabled = ((bool)(resources.GetObject("BotonSalir.Enabled")));
			this.BotonSalir.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("BotonSalir.FlatStyle")));
			this.BotonSalir.Font = ((System.Drawing.Font)(resources.GetObject("BotonSalir.Font")));
			this.BotonSalir.Image = ((System.Drawing.Image)(resources.GetObject("BotonSalir.Image")));
			this.BotonSalir.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("BotonSalir.ImageAlign")));
			this.BotonSalir.ImageIndex = ((int)(resources.GetObject("BotonSalir.ImageIndex")));
			this.BotonSalir.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("BotonSalir.ImeMode")));
			this.BotonSalir.Location = ((System.Drawing.Point)(resources.GetObject("BotonSalir.Location")));
			this.BotonSalir.Name = "BotonSalir";
			this.BotonSalir.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("BotonSalir.RightToLeft")));
			this.BotonSalir.Size = ((System.Drawing.Size)(resources.GetObject("BotonSalir.Size")));
			this.BotonSalir.TabIndex = ((int)(resources.GetObject("BotonSalir.TabIndex")));
			this.BotonSalir.Text = resources.GetString("BotonSalir.Text");
			this.BotonSalir.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("BotonSalir.TextAlign")));
			this.toolTip1.SetToolTip(this.BotonSalir, resources.GetString("BotonSalir.ToolTip"));
			this.BotonSalir.Visible = ((bool)(resources.GetObject("BotonSalir.Visible")));
			this.BotonSalir.Click += new System.EventHandler(this.menuItem7_Click);
			// 
			// BotonAddCompo
			// 
			this.BotonAddCompo.AccessibleDescription = resources.GetString("BotonAddCompo.AccessibleDescription");
			this.BotonAddCompo.AccessibleName = resources.GetString("BotonAddCompo.AccessibleName");
			this.BotonAddCompo.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("BotonAddCompo.Anchor")));
			this.BotonAddCompo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BotonAddCompo.BackgroundImage")));
			this.BotonAddCompo.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("BotonAddCompo.Dock")));
			this.BotonAddCompo.Enabled = ((bool)(resources.GetObject("BotonAddCompo.Enabled")));
			this.BotonAddCompo.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("BotonAddCompo.FlatStyle")));
			this.BotonAddCompo.Font = ((System.Drawing.Font)(resources.GetObject("BotonAddCompo.Font")));
			this.BotonAddCompo.Image = ((System.Drawing.Image)(resources.GetObject("BotonAddCompo.Image")));
			this.BotonAddCompo.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("BotonAddCompo.ImageAlign")));
			this.BotonAddCompo.ImageIndex = ((int)(resources.GetObject("BotonAddCompo.ImageIndex")));
			this.BotonAddCompo.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("BotonAddCompo.ImeMode")));
			this.BotonAddCompo.Location = ((System.Drawing.Point)(resources.GetObject("BotonAddCompo.Location")));
			this.BotonAddCompo.Name = "BotonAddCompo";
			this.BotonAddCompo.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("BotonAddCompo.RightToLeft")));
			this.BotonAddCompo.Size = ((System.Drawing.Size)(resources.GetObject("BotonAddCompo.Size")));
			this.BotonAddCompo.TabIndex = ((int)(resources.GetObject("BotonAddCompo.TabIndex")));
			this.BotonAddCompo.Text = resources.GetString("BotonAddCompo.Text");
			this.BotonAddCompo.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("BotonAddCompo.TextAlign")));
			this.toolTip1.SetToolTip(this.BotonAddCompo, resources.GetString("BotonAddCompo.ToolTip"));
			this.BotonAddCompo.Visible = ((bool)(resources.GetObject("BotonAddCompo.Visible")));
			this.BotonAddCompo.Click += new System.EventHandler(this.menuItemCargar_Click);
			// 
			// BotonGuardar
			// 
			this.BotonGuardar.AccessibleDescription = resources.GetString("BotonGuardar.AccessibleDescription");
			this.BotonGuardar.AccessibleName = resources.GetString("BotonGuardar.AccessibleName");
			this.BotonGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("BotonGuardar.Anchor")));
			this.BotonGuardar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BotonGuardar.BackgroundImage")));
			this.BotonGuardar.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("BotonGuardar.Dock")));
			this.BotonGuardar.Enabled = ((bool)(resources.GetObject("BotonGuardar.Enabled")));
			this.BotonGuardar.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("BotonGuardar.FlatStyle")));
			this.BotonGuardar.Font = ((System.Drawing.Font)(resources.GetObject("BotonGuardar.Font")));
			this.BotonGuardar.Image = ((System.Drawing.Image)(resources.GetObject("BotonGuardar.Image")));
			this.BotonGuardar.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("BotonGuardar.ImageAlign")));
			this.BotonGuardar.ImageIndex = ((int)(resources.GetObject("BotonGuardar.ImageIndex")));
			this.BotonGuardar.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("BotonGuardar.ImeMode")));
			this.BotonGuardar.Location = ((System.Drawing.Point)(resources.GetObject("BotonGuardar.Location")));
			this.BotonGuardar.Name = "BotonGuardar";
			this.BotonGuardar.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("BotonGuardar.RightToLeft")));
			this.BotonGuardar.Size = ((System.Drawing.Size)(resources.GetObject("BotonGuardar.Size")));
			this.BotonGuardar.TabIndex = ((int)(resources.GetObject("BotonGuardar.TabIndex")));
			this.BotonGuardar.Text = resources.GetString("BotonGuardar.Text");
			this.BotonGuardar.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("BotonGuardar.TextAlign")));
			this.toolTip1.SetToolTip(this.BotonGuardar, resources.GetString("BotonGuardar.ToolTip"));
			this.BotonGuardar.Visible = ((bool)(resources.GetObject("BotonGuardar.Visible")));
			this.BotonGuardar.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// BotonAbrir
			// 
			this.BotonAbrir.AccessibleDescription = resources.GetString("BotonAbrir.AccessibleDescription");
			this.BotonAbrir.AccessibleName = resources.GetString("BotonAbrir.AccessibleName");
			this.BotonAbrir.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("BotonAbrir.Anchor")));
			this.BotonAbrir.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BotonAbrir.BackgroundImage")));
			this.BotonAbrir.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("BotonAbrir.Dock")));
			this.BotonAbrir.Enabled = ((bool)(resources.GetObject("BotonAbrir.Enabled")));
			this.BotonAbrir.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("BotonAbrir.FlatStyle")));
			this.BotonAbrir.Font = ((System.Drawing.Font)(resources.GetObject("BotonAbrir.Font")));
			this.BotonAbrir.Image = ((System.Drawing.Image)(resources.GetObject("BotonAbrir.Image")));
			this.BotonAbrir.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("BotonAbrir.ImageAlign")));
			this.BotonAbrir.ImageIndex = ((int)(resources.GetObject("BotonAbrir.ImageIndex")));
			this.BotonAbrir.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("BotonAbrir.ImeMode")));
			this.BotonAbrir.Location = ((System.Drawing.Point)(resources.GetObject("BotonAbrir.Location")));
			this.BotonAbrir.Name = "BotonAbrir";
			this.BotonAbrir.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("BotonAbrir.RightToLeft")));
			this.BotonAbrir.Size = ((System.Drawing.Size)(resources.GetObject("BotonAbrir.Size")));
			this.BotonAbrir.TabIndex = ((int)(resources.GetObject("BotonAbrir.TabIndex")));
			this.BotonAbrir.Text = resources.GetString("BotonAbrir.Text");
			this.BotonAbrir.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("BotonAbrir.TextAlign")));
			this.toolTip1.SetToolTip(this.BotonAbrir, resources.GetString("BotonAbrir.ToolTip"));
			this.BotonAbrir.Visible = ((bool)(resources.GetObject("BotonAbrir.Visible")));
			this.BotonAbrir.Click += new System.EventHandler(this.menuItemNuevo_Click);
			// 
			// Paleta
			// 
			this.AccessibleDescription = resources.GetString("$this.AccessibleDescription");
			this.AccessibleName = resources.GetString("$this.AccessibleName");
			this.AutoScaleBaseSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScaleBaseSize")));
			this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
			this.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMargin")));
			this.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMinSize")));
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = ((System.Drawing.Size)(resources.GetObject("$this.ClientSize")));
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.Tabs);
			this.Enabled = ((bool)(resources.GetObject("$this.Enabled")));
			this.Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
			this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
			this.MaximumSize = ((System.Drawing.Size)(resources.GetObject("$this.MaximumSize")));
			this.Menu = this.mainMenu1;
			this.MinimumSize = ((System.Drawing.Size)(resources.GetObject("$this.MinimumSize")));
			this.Name = "Paleta";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			this.toolTip1.SetToolTip(this, resources.GetString("$this.ToolTip"));
			this.Click += new System.EventHandler(this.Paleta_Click);
			this.Load += new System.EventHandler(this.Paleta_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Paleta_Paint);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		#endregion


		[STAThread]
		static void Main()
		{
			Application.Run(new Paleta());
		}




		/// cuando se minimiza la paleta todo se minimiza
		private void Redimensiona(object sender, EventArgs e)
		{
			 if (this.OwnedForms.Length>0)
			 {
				 for (int i = 0; i < this.OwnedForms.Length; i++)
				 {
                     this.OwnedForms[i].WindowState=this.WindowState;
                 }
             }
			 
		}

		/// muestra la forma de introducción
		private void DoSplash()
		{
			miIntro = new Intro();
			miIntro.ShowDialog();
		}


	/// regresa el frame buscado de entre el control de frames del
	/// proyecto actual como un OBJETO
	private object BuscaFrameDisenno(int idFrame, string nombreFrame)
	{
		object salida=null;
		int tam=nombresFrames.Count;

		controlFrame tempo;

		for (int i = 0; i < tam; i++)
		{
			tempo=(controlFrame)nombresFrames[i];
			if ((int.Parse(tempo.ordinalFrame)==idFrame)&&(tempo.nombreFrame==nombreFrame)) salida=todosFrames[i];
		}
		return salida;
	}


    /// Regresa el Frame de Diseño buscado de entre elcontrol de Frames del
	/// prouecto actual como un DISENNO
	private Disenno DameElFrame(int idFrame, string nombreFrame)
	{
		object fS=BuscaFrameDisenno(idFrame,nombreFrame);
		Disenno salida=new Disenno(this,this.inspector);
		if (fS!=null && fS is Disenno)
		{
			salida=(Disenno)fS;
		}
		return salida;
	}



    ///Me regresa los controles de in TabControl
	/// Nota: Un tab control está contenido en un CompoTabControl
	/// Y dentro del TabControl existen los PageControl, los cuales contienen
	/// los controles
	private ArrayList DameComposEnTabControl(CompoTabControl elTab)
	{
		System.Windows.Forms.Control.ControlCollection tempo= null;
		ArrayList salida= new ArrayList();

		tempo=elTab.Controls;

		TabControl tabContenido=(TabControl)tempo[0];
		System.Windows.Forms.TabControl.TabPageCollection paginas=tabContenido.TabPages;


		int noPags=paginas.Count;
		for (int i = 0; i < noPags; i++)
		{
			TabPage laPag=paginas[i];
			salida.Add(laPag);
			tempo=laPag.Controls;

			int noCompos=tempo.Count;
			for (int r = 0; r < noCompos; r++)
			{
			   Control ob=(Control)tempo[r];
			   if (ob!=null && !(ob is Marco))
			   {
				   salida.Add(ob);
			   }
			}
		}

		return salida;
	}




	/* Obtiene los controles contenidos en la forma de diseño como un Arraylist*/
	private ArrayList  DameObjetosFormaDisenio(int idFrame, string nombreFrame)
	{
		object frameSeleccionado=BuscaFrameDisenno(idFrame,nombreFrame);
		ArrayList tempo=null;
		ArrayList salida=new ArrayList();
		System.Windows.Forms.Control.ControlCollection aux=null;

		if (frameSeleccionado!=null && frameSeleccionado is Disenno)
		{
			Disenno copiaFrame=new Disenno(this, this.inspector);
			copiaFrame=(Disenno)frameSeleccionado;
			aux=copiaFrame.Controls;
			int tim=aux.Count;
			for (int e = 0; e < tim; e++)salida.Add(aux[e]);
		}

		int tam=salida.Count;
		for (int i = 0; i < tam; i++)
		{
			object obj=salida[i];
			if (obj is CompoTabControl)
			{
				CompoTabControl elTab=(CompoTabControl)obj;
				tempo=this.DameComposEnTabControl(elTab);

				int tam2=tempo.Count;
				for (int t = 0; t < tam2; t++) salida.Add((Control)tempo[t]);
			}
		}

		return salida;
	}




	///  busca el código asociado a un evento específico
    /// entra el "id" de un componente y el nombre de evento asociado
	/// el id es un entero que se asigna a un componente cuando es creado
	/// y puesto sobre la forma de diseño
  static public string[] DameCodigoAsociado(int idCompo,int idFrame,string evento)
  {
	  int tam		  =controlEventos.Count;
	  templateEstruct tempEst;
	  int 			  idEncCompo;
	  int             idEncFrame;
	  string 		  eventoEnc;
	  string[] 		  salida=new string[0];


	  for (int i = 0; i < tam; i++)
	  {
		 tempEst=(templateEstruct)controlEventos[i];
		 idEncCompo=tempEst.idCompo;
		 idEncFrame=tempEst.idFrame;
		 eventoEnc=tempEst.evento;

		 if ((idEncCompo==idCompo)&&(eventoEnc==evento)&&(idEncFrame==idFrame))
		 {
			salida=tempEst.codigo;
         }

	  }
	  codigoAsociado.idCompo=idCompo;
	  codigoAsociado.evento=evento;
	  codigoAsociado.codigo=salida;

	  return salida;
  }


  /// Dice si un evento en el control de eventos ya tiene codigo asociado
  public static bool DimeSiHayCoincidencia(int idCompo,int idFrame, string evento)
  {
	  int tam=controlEventos.Count;
	  templateEstruct temp;

	  int idEncCompo;
	  int idEncFrame;

	  string eventoEnc;
	  bool salida=false;

	  for (int i = 0; i < tam; i++)
	  {
		  temp=(templateEstruct)controlEventos[i];
		  idEncCompo=temp.idCompo;
		  idEncFrame=temp.idFrame;
		   eventoEnc=temp.evento;

		  if ((idEncCompo==idCompo)&&(eventoEnc==evento)&&(idEncFrame==idFrame))
		   {
			  salida=true;
			  break;
		   }

	  }
	  return salida;
  }


  /// Regresa la posición en el arreglo de eventos de un resgistro de un evento
  /// al que ya se le ha asociado codigo
  public static int DameIndiceDeCoincidencia(int idCompo,int idFrame,string evento)
  {
	  int tam=controlEventos.Count;
	  templateEstruct temp;

	  int idEncCompo;
	  int idEncFrame;
	  string eventoEnc;
	  int salida=0;

	  for (int i = 0; i < tam; i++)
	  {
		  temp=(templateEstruct)controlEventos[i];
		  idEncCompo=temp.idCompo;
		  idEncFrame=temp.idFrame;
		  eventoEnc=temp.evento;

		  if ((idEncCompo==idCompo)&&(eventoEnc==evento)&&(idEncFrame==idFrame))
          {
			  salida=i;
			  break;
		  }
	  }

	  return salida;

  }



  /// al asociar codigo a un evento mediante el editor de codigo se verifica
  /// se crea una estructura de información y se agrega a Control de eventos
  public static void PonCodigoAsociado(int idCompo,int idFrame,string evento, string[] codigo)
  {
	  bool op=DimeSiHayCoincidencia(idCompo,idFrame,evento);

	  if (op==false)
	  {
		  string[] asociado=DameCodigoAsociado(idCompo,idFrame,evento);
		  templateEstruct tempo=new templateEstruct();
		  tempo.idCompo=idCompo;
		  tempo.idFrame=idFrame;
		  tempo.evento=evento;
		  tempo.codigo=codigo;
		  controlEventos.Add(tempo);
	  }

	  if (op==true)
	  {
		  string[] asociado=DameCodigoAsociado(idCompo,idFrame,evento);
		  int indice=DameIndiceDeCoincidencia(idCompo,idFrame,evento);
		  templateEstruct tempo=new templateEstruct();
		  tempo.idCompo=idCompo;
		  tempo.idFrame=idFrame;
		  tempo.evento=evento;
		  tempo.codigo=codigo;
		  controlEventos[indice]=tempo;
	  }
  }




		/// adquiere el texto de los tabs en la paleta de componentes
		public string[] DameTextTabs()
		{
			int numero;
			numero=this.Tabs.TabCount;
			string[] salida;
			salida=new string[numero];

			if (numero==1)
			{
				salida[0]=this.Tabs.TabPages[0].Text;
			}

			if (numero>1)
			{
				for (int i = 0; i < numero; i++)
				{
					salida[i]=this.Tabs.TabPages[i].Text;
				}
			}

			return salida;
		}


		/// adquiere numero de tabs en la paleta de componentes
		public int DameNumeroTabs()
		{
			int salida;
			salida=this.Tabs.TabCount;
			return salida;
		}


		/// guarda una linea en el archivo "paleta.ini" donde se guarda el path
		/// de las dll de componentes que se cargan al iniciar "dinamica"
		private void GuardaItemIni(string item,string dllRela)
		{
			string listajunta=dllRela;

			StreamWriter w= File.AppendText(directorio+"\\paleta.ini");
			w.WriteLine(item+","+listajunta);
			w.Flush();
			w.Close();
		}


		/// Dice si existe un nuevo item (nombre de tab) en el arreglo que entra
		/// comparandolo con la lista actual de items (tabs)
		private bool NuevoItem(string paRevisar, string[] revisado)
		{
			bool salida=true;
			int tam=revisado.Length;

			if (tam>1)
			{
				for (int i = 0; i < tam; i++)
				{
					if (paRevisar==revisado[i])
					{
						salida=false;
						break;
					}
				}
			}


			if (tam==1)
			{
				if (paRevisar==revisado[0])
				{
					salida=false;
				}
			}

			return salida;
		}


		///  Adquiere la lista de los nombres de los tabs y agrega uno
		///  nuevo a ese arreglo

		private string[] AddNameTabsNamesArray(string nuevo)
		{
			string[] salida;
			int      nuTabs=this.Tabs.TabCount;

			salida=new string[nuTabs+1];

			for (int i = 0; i < nuTabs; i++)
			{
				salida[i]=this.Tabs.TabPages[i].Text;
			}

			salida[nuTabs]=nuevo;

			return salida;
		}


        /// hace todo el proceso de actualización de tabs. Recibe un arreglo
        /// de cadenas (nuevos tabs) y lo compara con el existente. Si son
		/// diferentes, actualiza.
		private void ActualizaTabs(string[] tabsRecibidos)
		{
			string[] oldTabs;
			int		 tamOld,tamNew;
			bool	 nuevo;

			tamOld=this.Tabs.TabCount;
			oldTabs=new string[tamOld];

			if (tamOld>1)

			{
				for (int i = 0; i < tamOld; i++)
				{
					oldTabs[i]=this.Tabs.TabPages[i].Text;
				}
			}

			if (tamOld==1)
			{
				oldTabs[0]=this.Tabs.TabPages[0].Text;
			}


			tamNew=tabsRecibidos.Length;

			if (tamNew>tamOld)
			{
				for (int i = 0; i < tamNew; i++)
				{
					nuevo=NuevoItem(tabsRecibidos[i],oldTabs);
					if (nuevo)
					{
						TabPage pagina=new TabPage();
						pagina.Text=tabsRecibidos[i];
						nuevaTab=tabsRecibidos[i];
						this.Tabs.TabPages.Add(pagina);
					}
				}

			}

		}


		/// entra un Typo explora hasta "System.Object"
		/// para saber si hereda de Base Dinamica;
		public bool HeredaDeBaseDinamica(Type tipo)
		{
			bool salida=false;
			Type[] tipos=new Type[1];
			Type[] copia=new Type[0];
			tipos[0]=tipo;
			string tipoCad="";
			int tam;
			int indRev=-1;

			string inicio=tipos[0].ToString();

			if (inicio.IndexOf("Object")==-1)
			{
				while (tipoCad != "System.Object")
				{
					indRev=indRev+1;
					try
					{
					   tipoCad=tipos[indRev].BaseType.ToString();
					   if (tipoCad != "System.Object")
					   {
						 tam=tipos.Length;
						 copia=new Type[tam];
						 for (int i = 0; i < tam; i++) copia[i]=tipos[i];

						 tipos=new Type[tam+1];
						 for (int i = 0; i < tam; i++) tipos[i]=copia[i];

						 tipos[tam]=tipos[indRev].BaseType;
					   }
					}
					catch  (System.NullReferenceException)
					{
						break;
					}


				}

				tam=tipos.Length;
				for (int i = 0; i < tam; i++)
				{
					try
					{
						tipoCad=tipos[i].BaseType.ToString();
						if (tipoCad.IndexOf("BaseDinamica")!=-1)
						{
							salida=true;
						}
					}
					catch (System.NullReferenceException)
					{
						break;
					}

				}
		   }
		   return salida;

		}




		/// dado el path de una dll para cargar sus componentes, revisa
		/// cuales heredan de la clase base. Los que heredan se consideran
		/// validos y regresa un arreglo (de Type) con los tipos validos
		private Type[] DameTiposValidosDll(string pathDll)
		{
			Assembly tempo;
			Type[]   tipos;
			int      tam;
			Type[]   salida;
			Type[]	 copia;
			int		 tam2;
			bool     esBaseDinamica=false;


			salida=new Type[0];
			copia=new  Type[0];

			tempo=Assembly.LoadFile(pathDll);
			tipos=tempo.GetTypes();


			tam=tipos.Length;

			for (int i = 0; i < tam; i++)
			{
			   esBaseDinamica=HeredaDeBaseDinamica(tipos[i]);

			   string cadTipo=tipos[i].ToString();

			   if (esBaseDinamica)
			   {
				   Dinamica.BaseDinamica objeto= (Dinamica.BaseDinamica)tempo.CreateInstance(cadTipo);
				   esBaseDinamica=objeto.EsComponente();
			   }
		   

			   if (esBaseDinamica)
			   {
				  esBaseDinamica=false;

				  tam2=salida.Length;
				  copia=salida;

				  tam2=tam2+1;
				  salida=new Type[tam2];


				  if (tam2==1)
				  {
					  salida[0]=tipos[i];
				  }


				  if (tam2>1)
				  {
					  for (int j = 0; j < tam2-1; j++)
					  {
						  salida[j]=copia[j];
					  }

				  salida[tam2-1]=tipos[i];
				  }


			   }

			}


		   return salida;
		}




		/// Entra el Path de la Dll que se esta dando de alta. Regresa
		/// el path de los icomos por componente conternido en la Dll
		private string[] DamePathsIconos(string pathDll)
		{
			Type[]    		tipos;
			int       		tam;
			string[]		salida;
			string[]		copia;
			Assembly		tempo;
			int				tamSalida;
			string[]		cadenasTipos;
			string			pathh;


			tempo=Assembly.LoadFile(pathDll);


			tipos=DameTiposValidosDll(pathDll);

			tam=tipos.Length;
			cadenasTipos=new string[tam];

			for (int i = 0; i < tam; i++)
			{
				cadenasTipos[i]=tipos[i].ToString();
			}



			salida=new string[0];
			copia=new  string[0];
			tamSalida=0;


			for (int i = 0; i < tam; i++)
			{

					pathh="";
					try
					{
						Dinamica.BaseDinamica objeto= (Dinamica.BaseDinamica)tempo.CreateInstance(cadenasTipos[i]);
						string rutaIcono=objeto.DameIcono();
						if (rutaIcono!=null) pathh=directorio+"\\iconos\\"+objeto.DameIcono();
					}
					catch
					{

                    }

					copia=salida;
					tamSalida=salida.Length;
					tamSalida=tamSalida+1;

					salida=new string[tamSalida];

					if (tamSalida==1)
					{
						salida[0]=pathh;
					}

					if (tamSalida>1)
					{
						for (int j = 0; j < tamSalida-1; j++)
						{
							salida[j]=copia[j];
						}
						salida[tamSalida-1]=pathh;
					}

			}

			return salida;
		}



        /// Entra el arreglo de tipos validos (tipo: Type) y regresa
		/// los mismos convertidos a cadena en un arreglo de strings
		private string[] ConvierteTipos_Cadenas(Type[] tipos)
		{
			int tama;
			string[] salida;

			tama=tipos.Length;
			salida=new string[tama];

			if (tama==1)
			{
				salida[0]=tipos[0].ToString();
			}

			if (tama>1)
			{
				for (int i = 0; i < tama; i++)
				{
					salida[i]=tipos[i].ToString();
				}
			}

			return salida;
		}



		/// al hacer click sobre un boton de la paleta de componentes (el cual)
        /// representa un componente, se carga la información de tipo y la dll donde
        /// esta contenido el componente elegido en las variables globales "aCrear" (tipo)
		/// y "dllOrigen" (path de la dll que contiene el componente elegido)
		private void ClickBotonPaleta(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (sender is CompoBoton)
			{
				CompoBoton botonTempo=new CompoBoton();
				botonTempo=(CompoBoton)sender;
				aCrear=botonTempo.TipoAsociado;
				dllOrigen=botonTempo.DllOrigen;
			}
		}



		public void PintaPageTab(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			 TabPage miTab=(TabPage)sender;
        }

        /// entran los tipos de los componentes validos (que heredan de la clase base) como cadena
        /// el nombre del tab donde se deben cargar, el path de los iconos relacionados con cada uno de ellos
		/// el path de la dll que contiene los compoentes, y la posición desde donde se tiene que empezar
        /// a construir los botones. Cuando es un nuevo tab, el inicio es 1, pero cuando ya existe el tab
		/// y ya tiene botones que representan compoentes, el inicio es el numero actual de componentes en el
		/// tab + 1
		private void ConstruyeBotones(string[] tipos,string tab,string[] pathsIconos,string pathDllOrigen,int inicio)
		{
			int nuComponentes;
			int nuTabs;
			string tabFounded;
			string PathIconoDefault=directorio+"\\iconos\\default.png";

			nuComponentes=tipos.Length;
			nuTabs=this.Tabs.TabCount;

			for (int i = 0; i < nuTabs; i++)
			{
				tabFounded=this.Tabs.TabPages[i].Text;
				if (tabFounded==tab)
				{
					TabPage tabTrabajo= new TabPage();
					tabTrabajo=(TabPage)this.Tabs.TabPages[i];
					tabTrabajo.Paint += new System.Windows.Forms.PaintEventHandler(this.PintaPageTab);
					tabTrabajo.AutoScroll=true;

					for (int j = inicio; j < nuComponentes+inicio; j++)
					{
						CompoBoton boton=new CompoBoton();
						boton.MouseDown += new System.Windows.Forms.MouseEventHandler(ClickBotonPaleta);
						boton.TipoAsociado=tipos[j];
						boton.DllOrigen=pathDllOrigen;
						boton.FlatStyle=FlatStyle.Flat;


						if (pathsIconos[j]!="")
						{
							string oo=pathsIconos[j];
                            try
                            {
								boton.IconoMostrado=oo;
							}
							catch (System.IO.FileNotFoundException fnf)
							{
							   boton.IconoMostrado=PathIconoDefault;
							   string mica=fnf.ToString();
							}

						}

						if (pathsIconos[j]=="")
						{
							string aa=PathIconoDefault;
							boton.IconoMostrado=aa;
						}


						boton.Height=32;
						boton.Width=32;
						boton.Left=35*j;
						boton.Top=2;
						boton.Tip=boton.TipoAsociado;
						tabTrabajo.Controls.Add(boton);



					}

				}
			}

		}


		/// Dado en nombre "texto" de un tab en la paleta de componentes, regresa el numero
		/// de botones que contiene ese tab
		private int DameNumeroBotonesTab(string tabBuscado)
		{
			int nuTabs;
			string nameEncontrado;
			int sali=0;

			nuTabs=this.Tabs.TabCount;

			for (int i = 0; i < nuTabs; i++)
			{
				nameEncontrado=this.Tabs.TabPages[i].Text;
				if (nameEncontrado==tabBuscado)
				{
					TabPage tabTempo=new TabPage();
					tabTempo=(TabPage)this.Tabs.TabPages[i];
					sali=tabTempo.Controls.Count;
				}

			}

			return sali;

		}


		/// Entra el path de una Dll que contiene los componentes a cargar
		/// y copia esta en el directorio de Dinamica
		private void CopiaArchivos(string origen,bool sobreescribir)
		{

			FileInfo infoOrigen;
			int indice=1;
			nuevoNombreDll=origen;

			while (indice!=-1)
			{
				indice=nuevoNombreDll.LastIndexOf(@"\");
				nuevoNombreDll=nuevoNombreDll.Remove(0,indice+1);
			}

			infoOrigen=new FileInfo(nuevoNombreDll);

			try
			{
			   infoOrigen.CopyTo(directorio+"\\"+nuevoNombreDll,true);
			}
			catch
			{

			}
			GuardaItemIni(nuevaTab,nuevoNombreDll);
			int comienzo=DameNumeroBotonesTab(nuevaTab);
			DaDeAltaNuevosComponentes(origen,nuevaTab,comienzo);

		}


		/// Entra el nombre de la dll (que existe en "bin") y el tab en la que se alojarán
		///  los compoenentes. Inicio es el ordinal del primer boton a construir en la nueva tab
		private void DaDeAltaNuevosComponentes(string origen,string tab,int inicio)
		{
			Type[]      tipos;
			string[]    tiposCadena;
			string[]	pathsIconos;

			tipos=DameTiposValidosDll(origen);
			tiposCadena=ConvierteTipos_Cadenas(tipos);
			pathsIconos=DamePathsIconos(origen);
			ConstruyeBotones(tiposCadena,tab,pathsIconos,origen,inicio);
		}


		// tab_Paleta,dll_1,dll_2,...,dll_n
		/* En el archivo de configuración me traigo las lista de las dll
		   relacionadas con un tab */
		private string[] ExtraeListaDllRela(string strLeidaCfgFile)
		{
			int posi;
			string[] salida;
			string[] copia;
			string	 tab;
			int      tam=0;
			string   copiaIn;

			salida=new string[0];
			posi=strLeidaCfgFile.IndexOf(",");
			if (posi>-1)
			{
					tab=strLeidaCfgFile.Substring(0,posi);

					copiaIn=strLeidaCfgFile.Substring(posi+1,strLeidaCfgFile.Length-(posi+1));

					copia=new string[0];
					salida=new string[0];

					while (copiaIn.Length>0)
					{
						copia=salida;
						tam=salida.Length;
						tam=tam+1;
						salida=new string[tam];

						posi=copiaIn.IndexOf(",");


						for (int i = 0; i < tam; i++)
						{
							int tam2=copia.Length;
							if (tam2==0) copia=new String[1];
							salida[i]=copia[i];
						}


						if (posi==-1 && copiaIn.Length>0)
						{
						   salida[tam-1]=copiaIn;
						   copiaIn="";
						}

						if (posi>-1)
						{
							tab=copiaIn.Substring(1,posi-1);
							copiaIn=copiaIn.Substring(posi);
							salida[tam-1]=tab;
						}

					}
			}

			return salida;
		}


		/* En el archivo de conficuración obtendo el tab de componentes*/
		private string ExtraeTabRela(string strLeidaCfgFile)
		{
			 string salida="";
			 if (strLeidaCfgFile!="")
			 {
					 int posi;
					 posi=strLeidaCfgFile.IndexOf(",");
					 salida=strLeidaCfgFile.Substring(0,posi);
			 }
			 return salida;
		}


		/*
			Cuando inicia Dinàmica carga todas las Dll's de componentes registrados
		*/
		private void CargaDllsCfgEnTab()
		{
			 StreamReader sr=File.OpenText(directorio+"\\paleta.ini");
			 string input;

			 string   tabla;
			 string[] dllss;
			 string[] tabs;

			 while ((input=sr.ReadLine())!=null)
			 {
				tabla=ExtraeTabRela(input);
				dllss=ExtraeListaDllRela(input);

				tabs= AddNameTabsNamesArray(tabla);
				ActualizaTabs(tabs);

				int cuantos=dllss.Length;

				for (int i = 0; i < cuantos; i++)
				{
					int ini=DameNumeroBotonesTab(tabla);
					DaDeAltaNuevosComponentes(directorio+"\\"+dllss[i],tabla,ini);
				}

			 }

			 sr.Close();


		}

        /////////////////////////////////////////////////////////////////////////
        /// proceso de compilación
		/// /////////////////////////////////////////////////////////////////////

		/*
		  Crea el texto para dar de alta como variables a los comnponentes contenidos
		  en el frame de diseño para crear la clase que se usa para la compilaciòn para
		  la verificaciòn de errores cuando el usuario agraga codigo a un evento
		*/
		private string CreaTextoVariables(int idFrame, string nombreFrame)
		{
			string salida="";
			int tam;
			string tipo;
			string nombre;
			ArrayList controles=DameObjetosFormaDisenio(idFrame,nombreFrame);

			tam=controles.Count;
			for (int i = 0; i < tam; i++)
			{

			   if (! (controles[i] is Marco) )
			   {
				   BaseDinamica temp=(BaseDinamica)controles[i];
				   tipo=temp.DameTipo().ToString();
				   nombre=temp.Nombre;
				   salida=salida+"\n"+tipo+ " " + nombre + "=("+tipo+")al["+i.ToString()+"];";
			   }
			}

			return salida;
		}


		/*
		  Extrae todas las Dll usadas en la paleta del componentes para
		  poder compilar
		*/
		private string[] DameListaTotalDllsPaleta()
		{
			StreamReader sr=File.OpenText(directorio+"\\paleta.ini");
			string input;
			string[] salida=new string[7];
			string[] extraida=new string[0];
			string[] copia=new string[0];
			int		 tam=0;

			salida[0]="System.dll";
			salida[1]="System.Drawing.dll";
			salida[2]="System.Windows.Forms.dll";
			salida[3]="System.Data.dll";
			salida[4]="base_dinamica.dll";
			salida[5]="ComponentesIDEdinamica.dll";
			salida[6]="eventos.dll";

			while ((input=sr.ReadLine())!=null)
			{
				 extraida=ExtraeListaDllRela(input);
				 copia=salida;

				 tam=salida.Length;
				 tam=tam+extraida.Length;
				 salida=new string[tam];

				 copia.CopyTo(salida,0);
				 extraida.CopyTo(salida,copia.Length);
			}
			return salida;
		}



		/* Compila */
		private CompilerResults Compila(CodeDomProvider pro, string codigo)
		{
			string cadena;
			string[] enlaces;

			ICodeCompiler comp=pro.CreateCompiler();
			CompilerParameters cp=new CompilerParameters();
			enlaces=DameListaTotalDllsPaleta();

			for (int i = 0; i < enlaces.Length; i++)
				cp.ReferencedAssemblies.Add(enlaces[i]);

			cadena = Assembly.GetAssembly(typeof(Paleta)).CodeBase;
			cadena = cadena.Substring(8);
			cp.ReferencedAssemblies.Add(cadena);

			cp.GenerateExecutable=false;
			cp.GenerateInMemory=true;

			CompilerResults cr=comp.CompileAssemblyFromSource(cp, codigo);

			return cr;
		}

        /////////////////////////////////////////////////////////////////////////
        /// fin sección de COMPILACIÓN
		/// /////////////////////////////////////////////////////////////////////


#region RUN





		///Crea el texto de configuración POR COMPONENTE, lo que sus dimenciónes
		/// y posición dentro del fram de diseño
		private string TextoConfiguracionCompo(BaseDinamica componente)
		{
		   string salida="";

		   string nombre="";
		   
		   if (componente is CompoTabControl)
		   {
			   CompoTabControl elTab=(CompoTabControl)componente;
			   nombre=elTab.Nombre;
		   }
		   else
		   {
			  nombre=componente.Nombre;
		   }

		   string iz=componente.Left.ToString();
		   string to=componente.Top.ToString();
		   string ancho=componente.Width.ToString();
		   string alto=componente.Height.ToString();
		   bool   visible=componente.EsVisual();

		  string aux="";
		  if (visible==false) aux="this."+nombre+".Hide()";
		  else aux="";



		   salida= "//"+"\n"+"//"+nombre+"\n"+"//"+"\n"+
				   "this."+nombre+".Nombre"+"="+"\""+nombre+"\""+";"+ "\n"+
				   "this."+nombre+".Left"+"="+iz+";"+"\n"+
				   "this."+nombre+".Top"+"="+to+";"+"\n"+
				   "this."+nombre+".Width="+ancho+";"+"\n"+
				   "this."+nombre+".Height="+alto+";" + "\n"+
				   aux+"\n"+"\n;";//+

				   //"this.Controls.Add(this."+nombre+");";

		   return salida;
		}


		/// Crea el texto de configuración (nobre, left, top, height, width) de todos
		/// los componenetes contenidos en la forma de diseño
		private string DameTextoConfiguracionCompos(int idFrame, string nombreFrame)
		{
			string salida="";
			string salidaAlt="";
			string tipo;
			ArrayList controles=DameObjetosFormaDisenio(idFrame, nombreFrame);
			salidaAlt=this.inspector.CadenasConfPropiedades(idFrame,nombreFrame);


			int tam=controles.Count;
			for (int i = 0; i < tam; i++)
			{
				BaseDinamica tempo=new BaseDinamica();

				if (controles[i] is BaseDinamica)
				{
					 tipo=controles[i].GetType().ToString();

					 //para cualquier control que sea base dinamica
					 if (tipo.IndexOf("CompoMenu")==-1)
					 {
						 tempo=(BaseDinamica)controles[i];
						 salida=salida+TextoConfiguracionCompo(tempo)+"\n";
						 salida=salida+tempo.DameCodigoConfiguracion();
						 salida=salida.Replace("<COMPO>",tempo.Nombre);


						 Control papa=tempo.Parent;
						 // si es un Marco
						 if (papa is Marco) papa=papa.Parent;

						 // si es un TabPage
						 if (papa is TabPage)
						 {
							 salida=salida+"this."+papa.Name+".Controls.Add(this."+tempo.Nombre+");"+"\n";
						 }

						 // para cualquier otro componente
						 if (papa is Disenno)
						 {
							   string nombre="";

							   if (tempo is CompoTabControl)
							   {
								   CompoTabControl elTab=(CompoTabControl)tempo;
								   nombre=elTab.Nombre;
							   }
							   else
							   {
								  nombre=tempo.Nombre;
							   }
							   salida=salida+"this.Controls.Add(this."+nombre+");";
						 }


					 }

					 else
					 {
					 }

				}


				if (controles[i] is TabPage)
				{
					TabPage laPag=(TabPage)controles[i];
					Control elTabPapa=laPag.Parent;
					elTabPapa=elTabPapa.Parent;
					string tip=elTabPapa.GetType().ToString();
					string nom=((CompoTabControl)elTabPapa).Nombre;
					string textoPag=laPag.Text;
					salida=salida+"this."+laPag.Name+".Text="+"\""+textoPag+"\""+";";
					salida=salida+"this."+nom+".AgregaPagina(this."+laPag.Name+");"+"\n";
				}



			}



             salida=salida+"\n"+salidaAlt+"\n";
			 salida=salida+"\n";




			return salida;
		}




		/// crea todo el texto que declara las variables (instancias de los componentes)
        /// necesarios para crear la clase creada dinámicamente para construir el
		/// ejecutable del poryecto diseñado por el usuario en Dinamica en la forma de diseño
		private string CreaVariablesRUN(int idFrame, string nombreFrame)
		{
			string salida="private System.ComponentModel.Container components = null;"+"\n";
			int tam;
			string tipo="";
			string nombre="";
			ArrayList controles=DameObjetosFormaDisenio(idFrame, nombreFrame);

			tam=controles.Count;
			for (int i = 0; i < tam; i++)
			{

			   if (! (controles[i] is Marco) )
			   {
				   Type tipi=controles[i].GetType();
				   bool here=this.HeredaDeBaseDinamica(tipi);

				   if (here==true)
				   {
					  BaseDinamica temp=(BaseDinamica)controles[i];
					  nombre=temp.Nombre;
					  tipo=temp.GetType().ToString();
				   }
				   else
				   {
					  Control temp2=(Control)controles[i];
					  if (temp2 is TabPage)
					  {
						  TabPage laPage=(TabPage)controles[i];
						  nombre=laPage.Name;
						  tipo=laPage.GetType().ToString();
					  }
				   }


               salida=salida+"public "+tipo+" "+nombre+"= new "+tipo+"();"+"\n";


			   }



			}

			return salida;
		}





		/// Crea el texto donde se inician los componentes en la clase creada dinámicamente
		/// para construir el ejecutable.
		/// Este texto direcciona el texto asociado por el usuario a un evento de un componente
		/// a métodos creados dinámicamente.
		private string CreaVariablesIniciaComponentes(int idFrame, string nombreFrame)
		{
			string salida="";
			int tam;
			string tipo="";
			string nombre="";
			ArrayList controles=DameObjetosFormaDisenio(idFrame, nombreFrame);

			tam=controles.Count;
			for (int i = 0; i < tam; i++)
			{

			   if (! (controles[i] is Marco) )
			   {
                   Type tipi=controles[i].GetType();
				   bool here=this.HeredaDeBaseDinamica(tipi);

				   if (here==true)
				   {
					  BaseDinamica temp=(BaseDinamica)controles[i];
					  nombre=temp.Nombre;
					  tipo=temp.GetType().ToString();
				   }
				   else
				   {
					  Control temp2=(Control)controles[i];
					  if (temp2 is TabPage)
					  {
						  TabPage laPage=(TabPage)controles[i];
						  nombre=laPage.Name;
						  string texTab=laPage.Text;
						  tipo=laPage.GetType().ToString();
					  }
				   }

			   }

			}

			return salida;
		}




		/*Aisla el nombre del evento asociado a un boton*/
		private string DameNombreEvento(string eventoCompleto)
		{
		   string salida;
		   int    posi;
		   salida=eventoCompleto;
		   posi=salida.IndexOf(" ");
		   salida=salida.Substring(posi+1);
		   return salida;
		}


		/*Entra un EventInfo y sale un array [nombreParametro, tipo de parametro, eventHandlerType]
		  se extrae la información necesaria del evento al que el usuario ha asociado código*/
		private string[,] DameParametrosDeEvento(EventInfo evento)
		{
			string[,] salida;
			ParameterInfo[] parametros=evento.EventHandlerType.GetMethod("Invoke").GetParameters();
			int tam=parametros.Length;

			salida=new string[tam,2];

			for (int i = 0; i < tam; i++)
			{
				string cad1=parametros[i].Name;
				string cad2=parametros[i].ParameterType.ToString();
				salida[i,0]=cad1;
				salida[i,1]=cad2;
			}
			return salida;
		}



		///
		/// regresa el indice del elemento del CONTROL_EVENTOS tal que coincida con el arreglo
        /// que entra como argumento.
		/// la coincidencia indica que, del arreglo de controles que entra (los controles en un frame específico)
		/// alguno de ellos tiene codigo asociado, por lo que existe en el control eventos.
		private int[] CoincidenciaIds(ArrayList compos,int idFrame)
		{
			int[] salida= new int[0];
			int[] copia = new int[0];
			int tam=compos.Count;
			int evDef=controlEventos.Count;

			int idBusCompo=-1;
			int idBusFrame=idFrame;

			int idEncCompo=-1;
			int idEncFrame=-1;


			for (int i = 0; i < tam; i++)
			{
			   if (compos[i] is BaseDinamica)
			   {
				   BaseDinamica tempo=(BaseDinamica)compos[i];
				   idBusCompo=tempo.id;

				   for (int j = 0; j < evDef; j++)
				   {
					  templateEstruct temporal;
					  temporal=(templateEstruct)controlEventos[j];
					  idEncCompo=temporal.idCompo;
					  idEncFrame=temporal.idFrame;

					  if ((idEncCompo==idBusCompo) && (idEncFrame==idBusFrame))
					  {
						 int tam1=salida.Length;
						 copia=new int[tam1];

						 for (int o = 0; o < tam1; o++) copia[o]=salida[o];

						 salida=new int[tam1+1];

						 for (int k = 0; k < tam1; k++) salida[k]=copia[k];

						 salida[tam1]=j;
					  }
				   }
				}

			}

			return salida;
		}




		/*
			Entra el indice de coincidencia de ControlEventos y los controles contenidos
			en la forma de diseño, sale el componente de correspondiente a la coincidencia
		*/
		private BaseDinamica DameComponenteCoincidencia(int coincidencia, int idFrame, string nombreFrame)
		{
			BaseDinamica salida=null;
			templateEstruct control=(templateEstruct)controlEventos[coincidencia];
			int idComp=control.idCompo;
			int idForma=control.idFrame;

			ArrayList compos=DameObjetosFormaDisenio(idForma, nombreFrame);
			int tam=compos.Count;
			for (int i = 0; i < tam; i++)
			{
			   if (compos[i] is BaseDinamica)
			   {
					BaseDinamica tempo=(BaseDinamica)compos[i];
					int id2=tempo.id;
					if ((id2==idComp)&&(idForma==idFrame))
					{
						salida=tempo;
						break;
					}
               }
			}
			return salida;
		}



		/// entra un eventInfo y regresa el tipo del evento como cadena
		private string DameTipoEventHandlerDeEvento(EventInfo evento)
		{
			string salida;
			salida=evento.EventHandlerType.ToString();
			return salida;
		}


		/// entre un eventInfo y regresa en un arreglo de cadenas con los parametros
		/// y su tipo

		private string[] DameParametrosEvento(EventInfo evento)
		{
			string[] salida;
			ParameterInfo[] parametros=evento.EventHandlerType.GetMethod("Invoke").GetParameters();

			int tam=parametros.Length;
			salida=new string[tam];

			for (int i = 0; i < tam; i++)
			{
				salida[i]=parametros[i].Name;
			}

			return salida;
		}


		/// entra un Event Info y regresa el numero de parámetros que usa
		public int DameNumeroParametros(EventInfo evento)
		{
			int salida;
			ParameterInfo[] parametros=evento.EventHandlerType.GetMethod("Invoke").GetParameters();
			salida=parametros.Length;
			return salida;
        }


		/// Regeresa el tipo de los parametros de un EnvetInfo
		public string[] DameTiposParametrosEvento(EventInfo evento)
		{
			string[] salida;
			ParameterInfo[] parametros=evento.EventHandlerType.GetMethod("Invoke").GetParameters();

			int tam=parametros.Length;
			salida=new string[tam];

			for (int i = 0; i < tam; i++)
			{
				salida[i]=parametros[i].ParameterType.ToString();
			}
			return salida;

		}


        /// dado un arreglo de EventInfo, y un nombre de un evento, se busca el nombre del
		/// evento dentro del arreglo y regresa la coincidencia como un eventInfo
		private EventInfo DameEventoCoincidencia(string eventoBuscado, EventInfo[] eventos)
		{
			 int tam=eventos.Length;
			 EventInfo salida=null;

			 for (int i = 0; i < tam; i++)
			 {
				 string cad=eventos[i].Name;
				 if (cad==eventoBuscado) salida=eventos[i];

			 }

			 return salida;
		}



		///  Construye la cadena de la sección de configuración de los componentes
		///  donde se especifica el el método que define el comportamiento cuando sucede
		///  un evento
		///  y el método asociado al evento.
		private string[,] DefineComportamientoEvento(int idFrame, string nombreFrame)
		{
			string[,] salida=new string[0,2];
			string[,] copia=new  string[0,2];

			int          idCompoEnc;
			int          idFrameEnc;
			string 		 eventEncontrado="";
			string[] 	 codigoEncontrado=new string[0];
			int[]  		 coincidencias;
			string 		 nombreCompo="";
			BaseDinamica compoRelacionado=null;

			// obtiene los controles de un frame definido
			ArrayList compos=DameObjetosFormaDisenio(idFrame,nombreFrame);

			int ttt=compos.Count;
			coincidencias=new int[ttt];

            /// en el control de eventos existe una relacion de [idControl,evento,idFrame]
			/// evento   = evento con codigo asociado
			/// idControl= Control al que perteneces el evento
			/// idFrame  = Frame donde se localiza el componente
			///
			/// aqui entra el arreglo de componente en un frame, y regresa el id de los componentes
			/// que pertenecen a ese frame y que tienen codigo asociado
			coincidencias=CoincidenciaIds(compos,idFrame);




			int tam=coincidencias.Length;

			 for (int r = 0; r < tam; r++)
			 {
				templateEstruct tempo=(templateEstruct)controlEventos[coincidencias[r]];
				idCompoEnc=tempo.idCompo;
				idFrameEnc=tempo.idFrame;
				eventEncontrado=tempo.evento;
				codigoEncontrado=tempo.codigo;

				compoRelacionado=DameComponenteCoincidencia(coincidencias[r],idFrame,nombreFrame);
				nombreCompo=compoRelacionado.Nombre;


				EventInfo[] eventos=compoRelacionado.DameEventos();

				eventEncontrado=DameNombreEvento(eventEncontrado);
				EventInfo eventoPro=DameEventoCoincidencia(eventEncontrado,eventos);
				string tipoEventHandler=DameTipoEventHandlerDeEvento(eventoPro);
				tipoEventHandler=tipoEventHandler.Replace('+','.');
				int tami=DameNumeroParametros(eventoPro);
				string[] parametros=new string[tami];
				string[] tiposParam=new string[tami];
				parametros=DameParametrosEvento(eventoPro);
				tiposParam=DameTiposParametrosEvento(eventoPro);

				string cadParametros="";
				for (int i = 0; i < tami; i++)
				{
					string sust=parametros[i];

					if (i==1) sust="eventos";
					

					cadParametros=cadParametros + tiposParam[i]+ " " + sust;

					if (i != tami-1)
					{
						cadParametros=cadParametros+", ";
					}
				}

				cadParametros="("+cadParametros+")";


				int tam2=salida.Length;
				if (tam2!=0) tam2=tam2/2;
				
				copia=new string[tam2,2];

				copia=salida;

				salida=new string[tam2+1,2];

				for (int s = 0; s < tam2; s++)
				{
					salida[s,0]=copia[s,0];
					salida[s,1]=copia[s,1];
				}

				string tempi="";
				for (int t = 0; t < codigoEncontrado.Length; t++)
				{
					tempi=tempi+codigoEncontrado[t]+"\n";
				}

				/// aqui se forma toda la linea de salida;

				salida[tam2,0]="this."+nombreCompo+"."+eventEncontrado+"+= new "+tipoEventHandler+"(this."+nombreCompo+"_"+eventEncontrado+");";

				salida[tam2,1]="private void " + nombreCompo+"_"+eventEncontrado+cadParametros+"\n" +
						  "{"+"\n"+
						  tempi+"\n"+
						  "}";
			}
			return salida;
		}



	   /// Crea la clase para ser compilada y crear el ejecutable del proyecto
	   /// generado por el usuario en DINAMICA
	   private string LlenaClaseRun()
		{
			/// hay que especificar de que frame
//			string misVariables=CreaVariablesRUN(idFrame, nombreFrame);
//			string varIniciaCompo=CreaVariablesIniciaComponentes();
//			string[,] metodos=DefineComportamientoEvento();
//			string configuracion=DameTextoConfiguracionCompos();

		   /// **************************   codigo de prueba
		   string misVariables="";
		   string varIniciaCompo="";
		   string[,] metodos=new string[0,0];
		   string configuracion="";
		   /// ***********************************************

			string lineaMetodos="";

			int tami=metodos.Length;
			if (tami!=0) tami=tami/2;

			for (int i = 0; i < tami; i++)
			{
			   lineaMetodos=lineaMetodos+"\n"+metodos[i,0];
			}

			lineaMetodos=lineaMetodos+"}/// cierra IncializaComponentes"+"\n"+"\n";

			for (int j = 0; j < tami; j++)
			{
				lineaMetodos=lineaMetodos+"\n"+metodos[j,1];
			}

			string cadenaFinal=Plantilla;
			cadenaFinal=cadenaFinal.Replace("<MIS VARIABLES>",misVariables);
			cadenaFinal=cadenaFinal.Replace("<VARIABLES RUN>",varIniciaCompo);
			cadenaFinal=cadenaFinal.Replace("<CONFIGURACION>",configuracion);
			cadenaFinal=cadenaFinal.Replace("<INICIA COMPONENTES>",lineaMetodos);

			StreamWriter sw=new StreamWriter("file.txt",true,System.Text.Encoding.ASCII);
			sw.WriteLine(cadenaFinal);
			sw.Flush();
			sw.Close();

			return cadenaFinal;

		}



		/// entra la clase para construir el ejecutable y crea el ejecutable en
		/// el directorio de dinamica con el nombre "salida.exe"
		public CompilerResults CreaEjecutable(CodeDomProvider prov, string codigo)
		{
		 string cadena;
		 string []enlaces;

		 ICodeCompiler comp = prov.CreateCompiler();


		 CompilerParameters cp = new CompilerParameters();
		  cp.OutputAssembly="salida.exe";


		  enlaces=DameListaTotalDllsPaleta();

			for (int i = 0; i < enlaces.Length; i++)
				cp.ReferencedAssemblies.Add(enlaces[i]);

			cadena = Assembly.GetAssembly(typeof(Paleta)).CodeBase;
			cadena = cadena.Substring(8);
			cp.ReferencedAssemblies.Add(cadena);


			cp.GenerateExecutable = true;


			cp.GenerateInMemory = false;

			CompilerResults cr = comp.CompileAssemblyFromSource(cp, codigo);

		 return(cr);
		}




		/// Engloba todo el proces para crear el ejecutable del proyecto hecho
		/// por el usuario
		private void Ejecuta()
		{
			CSharpCodeProvider prov = new CSharpCodeProvider();
			CompilerResults res;

			 string codigo=LlenaClaseRun();

			 res = CreaEjecutable(prov,codigo);
			 if(res.Errors.HasErrors)
			 {
				 System.Windows.Forms.MessageBox.Show("error");
				 foreach(CompilerError err in res.Errors)
					 System.Windows.Forms.MessageBox.Show(err.ErrorText);
			 }
			 else
			 {
				 System.Windows.Forms.MessageBox.Show("Código correcto");
			 }
		}


#endregion


#region GUARDAR PROYECTO


		private string DameDatosConfiCompo(BaseDinamica compo)
		{
			string salida="";;
			BaseDinamica tempo=(BaseDinamica)compo;
			salida=salida+"x:"+tempo.Left+"\n";
			salida=salida+"y:"+tempo.Top+"\n";
			salida=salida+"ancho:"+tempo.Width+"\n";
			salida=salida+"alto:"+tempo.Height+"\n";
			return salida;
		}



	   private TabPage DamePagDeTab(CompoTabControl miTab, int idPage)
	   {
		   System.Windows.Forms.TabControl.TabPageCollection pags=miTab.DamePaginas();
		   TabPage pagina =pags[idPage];
		   return pagina;
	   }

	   private System.Windows.Forms.Control.ControlCollection DameContPagTab(TabPage miPagina)
	   {
		   System.Windows.Forms.Control.ControlCollection salida=miPagina.Controls;
		   return salida;
	   }


	   private string[,] DameInfoCompoCollection(System.Windows.Forms.Control.ControlCollection coleccion)
	   {
			int tam=coleccion.Count;
			int tam2=0;
			Assembly ass;

			for (int i = 0; i < tam; i++)
			{
				if (!(coleccion[i] is Marco)) tam2=tam2+1;
			}

			string[,] salida= new string[tam2,6];
			string tipo;
			Type   tip;
			string nombre;
			string configuracion;
			string codigo;
			int control=-1;


			for (int i = 0; i < tam; i++)
			{

				if (! (coleccion[i] is Marco))
				{

					control=control+1;
					BaseDinamica temp=(BaseDinamica)coleccion[i];
					tipo=temp.DameTipo().ToString();
					tip=temp.DameTipo();
					ass=Assembly.GetAssembly(tip);
					dllOrigen=ass.CodeBase;
					int lastIndex=dllOrigen.LastIndexOf("/");
					dllOrigen=dllOrigen.Substring(lastIndex+1);
					int tamanio=dllOrigen.Length;
					//dllOrigen=dllOrigen.Substring(8,tamanio-8);

					codigo=temp.DameCodigoConfiguracion();

					int aux = temp.id;
					configuracion=DameDatosConfiCompo(temp);
					nombre=temp.Nombre;
					salida[control,0]=aux.ToString();  // es un entero transformado en cadena
					salida[control,1]="tipo:"+tipo;
					salida[control,2]="nombre:"+nombre;
					salida[control,3]=configuracion;
					salida[control,4]="origen:"+dllOrigen;
					salida[control,5]=codigo;

				}
			}

			return salida;
	   }






	   private string CreaLineaGuardaCoponentesColeccion(string[,] info)
	   {
		   string[,] even = new string[0,2];
		   int tam=info.GetLength(0);
		   string salida="";

		   for (int i = 0; i < tam; i++)
		   {

				//// se agrege el texto de posicionamiento del componente
				salida=salida+"<COMPONENTE>"+"\n";
				salida=salida+"ID:"+info[i,0]+"\n"; // numero ordinal del control
				salida=salida+info[i,1]+"\n";		// tipo del componente
				salida=salida+info[i,2]+"\n";       // nombre del componente
				salida=salida+info[i,4]+"\n";       // dll origen del componente
				salida=salida+info[i,3]+"\n"+"\n"+"\n";		// configuración del componente (texto de..)

				string[] contiene=new string[0];

				/// obtengo como cadena todos los cambios hechos en las propiedades de los componentes
				contiene=this.inspector.DameCadenasConfiguracionComoArregloCadenas();
				int tami=contiene.Length;


				/// AGREGO LOS CAMBIOS HECHOS A LAS PROPIEDADES DEL COMPONENTE QUE ESTOY TRATANDO
				salida=salida+"<Configuracion>"+"\n";

				for (int y = 0; y < tami; y++)
				{
					string cadi=contiene[y];
					string nom=info[i,2];
					nom=nom.Replace("nombre:","");
					 /// si contiene el nombre de lcompoentes
					if (cadi.IndexOf(nom+".")>-1)
					{
					   salida=salida+cadi+"\n";
					}
				}

				/// Guarda la configuración interna.
				string cod=info[i,5];
				if (cod!="")
				{
					salida=salida+"<Configuracion Interna>"+"\n";
					salida=salida+cod;
					salida=salida+"</Configuracion Interna>"+"\n";
					string nom=info[i,2];
					nom=nom.Replace("nombre:","");
					salida=salida.Replace("<COMPO>",nom);
				}

				salida=salida+"</Configuracion>"+"\n";


				/// se agregan la infomración de los EVENTOS
				even=DameEventosDeComponenteConCodigo(info[i,0]);
				int tam2=even.GetLength(0);
				if (tam2>0)
				{
					for (int d = 0; d < tam2; d++)
					{
						salida=salida+"<EVENTO>"+"\n";
						salida=salida+even[d,0]+"\n";
						salida=salida+even[d,1]+"\n";
						salida=salida+"</EVENTO>"+"\n"+"\n";
					}
				}


				salida=salida+ "</COMPONENTE>"+ "\n"+"\n"+"\n";

		   }

		   return salida;
	   }




       ///Regresa un arreglo con la información de los componentes en un Frame de Diseño
       /// Cada registro de componente contiene la siguiente información
	   /// 0. ID Compo
	   /// 1. Tipo Compo
	   /// 2. Nombre Compo
	   /// 3. Configuración
	   /// 4. Origen (DLL que lo contiene)
	   /// 5. Condigo de configuración


		private string [,] DameInfoComposEnDisenioFrame(int idFrame, string nombreFrame)
		{
			ArrayList controles=DameObjetosFormaDisenio(idFrame, nombreFrame);
			int tam = controles.Count;
			Assembly ass;
			string dllOrigen;


			int tam2=0;

			for (int z = 0; z < tam; z++)
			{
				if (!(controles[z] is Marco) && !(controles[z] is TabPage) &&
					!(controles[z] is CompoTabControl) &&
					!(((Control)controles[z]).Parent is TabPage) &&
					!(((Control)controles[z]).Parent is CompoTabControl)  )
				{
				   tam2=tam2+1;
				}
			}


			string[,] salida= new string[tam2,6];
			string tipo;
			string nombre;
			string configuracion;
			int control=-1;
			string codigo;
			BaseDinamica temp=new BaseDinamica();


			for (int i = 0; i < tam; i++)
			{

				if (!(controles[i] is Marco) && !(controles[i] is TabPage) &&
					!(controles[i] is CompoTabControl) &&
					!(((Control)controles[i]).Parent is TabPage) &&
					!(((Control)controles[i]).Parent is CompoTabControl))
				{

					control=control+1;
					Type tipi=controles[i].GetType();
					tipo=tipi.ToString();
					temp=(BaseDinamica)controles[i];
					nombre=temp.Nombre;

					ass=Assembly.GetAssembly(tipi);
					dllOrigen=ass.CodeBase;
					int tamanio=dllOrigen.Length;
					dllOrigen=dllOrigen.Substring(8,tamanio-8);
					int idic=dllOrigen.LastIndexOf("/");
					dllOrigen=dllOrigen.Substring(dllOrigen.LastIndexOf("/")+1);

					codigo=temp.DameCodigoConfiguracion();

					int aux=temp.id;
					configuracion=DameDatosConfiCompo(temp);
					salida[control,0]=aux.ToString();  // es un entero transformado en cadena
					salida[control,1]="tipo:"+tipo;
					salida[control,2]="nombre:"+nombre;
					salida[control,3]=configuracion;
					salida[control,4]="origen:"+dllOrigen;
					salida[control,5]=codigo;

				}
			}


			return salida;
		}




		/// entra el id de un coponente que existe en la forma de diseño y regresa
		/// una array bidimencional de cadendas con los eventos del componente al que pertence el
		/// id que entra y que se les ha asociado un codigo
		///
		/// [nombre eveto, codigo asociado]
		///
		///
		private string[,] DameEventosDeComponenteConCodigo(string idCompo)
		{
			int tam=controlEventos.Count;
			int encontrados=0;
			string idEnc;
			string[,] salida=new string[0,2];
			int control=-1;
			string total="";

			for (int i = 0; i < tam; i++)
			{
				templateEstruct est=(templateEstruct)controlEventos[i];
				idEnc=est.idCompo.ToString();
				int posi=idCompo.IndexOf(":");


				if (posi>-1)
				{
					int tami=idCompo.Length;
					idCompo=idCompo.Substring(posi+1);
				}

				

				if (idEnc==idCompo) encontrados=encontrados+1;
			}

			if (encontrados>0)
			{
				salida=new string[encontrados,2];
				for (int j = 0; j < tam; j++)
				{
					templateEstruct est=(templateEstruct)controlEventos[j];
					idEnc=est.idCompo.ToString();
					if (idEnc==idCompo)
					{
						control=control+1;
						salida[control,0]=est.evento;
						for (int p = 0; p < est.codigo.Length; p++)
						{
							total=total+est.codigo[p]+"\n";
						}
						salida[control,1]=total;
					}
				}
			}


			return salida;
		}


		/// se crea el archivo que guarda el proyecto actual.
		/// Entra el nombre del archivo donde se va a guardar
		private void CreaFileProyecto(string archivo)
		{
			string[,] info = new string[0,5];
			string[,] cIn  =  new string[1,5];
			string[,] even = new string[0,2];
			StreamWriter sw=new StreamWriter(archivo,false,System.Text.Encoding.ASCII);
			string salida="";


			for (int r = 0; r < noFrames; r++)
			{
			   Disenno tempDisenno=(Disenno)todosFrames[r];
			   string nomFrame=tempDisenno.Nombre;
			   int    idFrame =tempDisenno.ID;
			   int    copIds  =tempDisenno.ids;

			   // <FORMA>
			   salida=salida+"<FORMA>"+"\n";
			   salida=salida+"nombre forma:"+nomFrame+"\n";
			   salida=salida+"id forma:"+idFrame.ToString()+"\n";
			   salida=salida+"ancho:"+tempDisenno.Width.ToString()+"\n";
			   salida=salida+"alto:"+tempDisenno.Height.ToString()+"\n";
			   //salida=salida+"menu:"+tempDisenno.ContieneMenu.ToString()+"\n";
			   salida=salida+"ids:"+copIds.ToString()+"\n";
			   salida=salida+"text:"+tempDisenno.Text+"\n"+"\n"+"\n";



			   // <TABCONTROL>
			   int nuTabs=this.DimeCuantosTabControlFrame(idFrame,nomFrame);
			   string linTabs="";

			   for (int w = 1; w < nuTabs+1; w++)
			   {
				   CompoTabControl tabi=this.DameCompoTabControl(idFrame,nomFrame,w);
				   linTabs=linTabs+this.CreaLineasGuardarTabControl(tabi,idFrame,nomFrame)+"\n"+"\n";
			   }

			   salida=salida+linTabs;

			   /// --> definir de que frame para obtener la información de los componentes
			   /// 	que contiene los controles, omite todos los tabs, page Control
			   info = DameInfoComposEnDisenioFrame(idFrame,nomFrame);
			   int tam=info.GetLength(0);

					for (int i = 0; i < tam; i++)
					{
					  if (((string)info[i,1]).IndexOf("CompoTabControl")==-1)
					  {
						cIn[0,0]=info[i,0];
						cIn[0,1]=info[i,1];
						cIn[0,2]=info[i,2];
						cIn[0,3]=info[i,3];
						cIn[0,4]=info[i,4];

						//// se agrege el texto de posicionamiento del componente
						salida=salida+"<COMPONENTE>"+"\n";
						salida=salida+"ID:"+info[i,0]+"\n"; // numero ordinal del control
						salida=salida+info[i,1]+"\n";		// tipo del componente
						salida=salida+info[i,2]+"\n";       // nombre del componente
						salida=salida+info[i,4]+"\n";       // dll origen del componente
						salida=salida+info[i,3]+"\n"+"\n"+"\n";		// configuración del componente (texto de..)

						string[] contiene=new string[0];

						/// obtengo como cadena TODOS los cambios hechos en las propiedades de los componentes
						contiene=this.inspector.DameCadenasConfiguracionComoArregloCadenas();
						int tami=contiene.Length;


						/// Creo la sección de configuración (cambios hechos a las propiedades mediante el inspector)
						salida=salida+"<Configuracion>"+"\n";

						for (int y = 0; y < tami; y++)
						{
							string cadi=contiene[y];
							string nom=info[i,2];
							nom=nom.Replace("nombre:","");

							/// si contiene el nombre de lcompoentes
							if (cadi.IndexOf(nom+".")>-1)
							{
							   salida=salida+cadi+"\n";
							}


						 }


						/// Guarda la configuración interna.
							string cod=info[i,5];
							if (cod!="")
							{
								salida=salida+"<Configuracion Interna>"+"\n";
								salida=salida+cod;
								salida=salida+"</Configuracion Interna>"+"\n";
								string nom=info[i,2];
								nom=nom.Replace("nombre:","");
								salida=salida.Replace("<COMPO>",nom);
							}


						salida=salida+"</Configuracion>"+"\n";




						/// se agregan la infomración de los EVENTOS
						even=DameEventosDeComponenteConCodigo(info[i,0]);
						int tam2=even.GetLength(0);
						if (tam2>0)
						{
							for (int d = 0; d < tam2; d++)
							{
								salida=salida+"<EVENTO>"+"\n";
								salida=salida+even[d,0]+"\n";
								salida=salida+even[d,1]+"\n";
								salida=salida+"</EVENTO>"+"\n"+"\n";
							}
						}


						salida=salida+ "</COMPONENTE>"+ "\n"+"\n"+"\n";
					  }
					}

			   salida=salida+"</FORMA>"+"\n"+"\n"+"\n"+"\n"+"\n";
			}

			sw.Write(salida);
			sw.Flush();
			sw.Close();
		}



#endregion

#region CARGA PROYECTO


#region FRAMES


	private void cargaConf(string regCompo,string idFrame, string nomFrame)
	{
		string confi=DameConfDeCompo(regCompo);
		string linea="";
		int indice;
		string aux="";
		string[] lineas=confi.Split('\n');
		int tam2=lineas.Length;
		tam2=tam2;

		for (int p = 0; p < tam2; p++)
		{
		   cadConfiguracion conf1;
		   conf1.iDFrame= int.Parse(idFrame); 			// IDFrame
		   conf1.nombreFrame=nomFrame; 					// nombreFrame;
		   indice=lineas[p].IndexOf("=");

		   if (indice>-1)
		   {
			  aux=lineas[p].Substring(0,indice);
			  conf1.compoYProp=aux;                     // CompoYProp
			  conf1.valor=lineas[p].Substring(indice);  // Valor de Prop.
			  linea="REGISTRO CARGADO"+"\n"+"\n";
			  linea=linea+"idFrame: "   +conf1.iDFrame.ToString()+"\n";
			  linea=linea+"NomFrame: "  +conf1.nombreFrame+"\n";
			  linea=linea+"CompoYProp: "+conf1.compoYProp+"\n";
			  linea=linea+"valorProp: " +conf1.valor;
			  //MessageBox.Show(linea);                         
			  this.inspector.cadsConf.Add(conf1);
		   }
		}
    }



    /// DINAMICA tiene un orden especifico para definir propiedades
	 /// una antes que la otra. Aqui se revisa si se viola o no ese orden
	 /// si no se respeta el orden de asignación la salida es false
	private bool RespetaOrdenDeAsignacionProp(string clase,string prop1, string prop2)
	{
		string [] copia=clase.Split('\n');
		string enc="";
		bool salida=true;
		bool marca=false;

		int tam=copia.Length;

		for (int i = 0; i < tam; i++)
		{
		   enc=copia[i];
		   if (enc.IndexOf(prop2)>0) marca=true;
		   if ( (enc.IndexOf(prop1)>0) && (marca==true)) salida=false;
		   if (marca==true && salida==false) break;
		}

		return salida;
	}


	/// cambia los renglones de una cadena de texto, uno por el otro
	private string CambiaRenglones(string clase, string prop1, string prop2)
	{
		string [] copia=clase.Split('\n');
		string aux;
		int indice1=-1;
		int indice2=-1;
		string salida="";
		bool marca=false;

		int tam=copia.Length;

		for (int i = 0; i < tam; i++)
		{
			if (copia[i].IndexOf(prop2)>0)
			{
			   indice1=i;
			   marca=true;
			}
			if (copia[i].IndexOf(prop1)>0 && marca==true) indice2=i;
			if (indice1!= -1 && indice2!= -1) break;
		}

		if (indice1!= -1 && indice2!= -1)
		{
			aux=copia[indice1];
			copia[indice1]=copia[indice2];
			copia[indice2]=aux;
			for (int y = 0; y < tam; y++) salida=salida+copia[y]+"\n";
		}

		return salida;
	}


	/// dado una cadena que representa la clase que asigna propiedades y el orden
    /// de asignación (1.prop1 y 2 prop2) cambia el orden en el caso de que no se
	/// haga en el orden adecuado y regresa la cadena corregida
	private string RevisaCorrigeOrdenAsignaProps(string clase, string prop1, string prop2)
	{
		bool sigue=false;
		string copiaClase=clase;
		int limite=0;

		do
		{
			sigue=this.RespetaOrdenDeAsignacionProp(copiaClase,prop1,prop2);
			if (sigue==false)
			{
				copiaClase=this.CambiaRenglones(copiaClase,prop1,prop2);
				limite=limite+1;
				if (limite==35) break;

			}
		}
		while (sigue== false);

		return copiaClase;

	}




   /// Carga (crea) un frame desde un archivo de projecto
	 private void CreaFrame(string regFrame)
	 {
		 Assembly ensamblado;

		 Disenno miFrame=new Disenno(this,this.inspector);
		 string[] confFrame=DameConfFrame(regFrame);
		 miFrame.Nombre=confFrame[0];        		// NOMBRE
		 miFrame.ID=int.Parse(confFrame[1]);     	// idFrame
		 miFrame.Width=int.Parse(confFrame[2]); 	// ancho
		 miFrame.Height=int.Parse(confFrame[3]);	// alto
		 miFrame.ids=int.Parse(confFrame[4]);   	// id
		 miFrame.Text=confFrame[5];


		 string[] listaEvetVacia=new string[0];
		 EventInfo[] eventos2=new EventInfo[0];
		 string tipoVacio="";
		 int miId=0;
		 string[] listaVacia=new string[0];

		 miFrame.EnviaObjeto+=new  Dinamica.Eventos.EnviaObjetoEventHandler(inspector.PonPropiedades);
		 Dinamica.Eventos.ObjetoEventArgs eventoVacio=new Dinamica.Eventos.ObjetoEventArgs(miFrame,listaEvetVacia,eventos2,miFrame.ID,tipoVacio,miId,listaVacia);
		 miFrame.Click+=new System.EventHandler(miFrame.Disenno_Click);

		 VerificaAgregaNombresFrames(miFrame,eventoVacio);

		 
		 todosFrames.Add(miFrame);



//
//		 if (confFrame[4]=="True")
//		 {
//			 miFrame.ContieneMenu=true;
//		 }
//		 if (confFrame[4]=="False")
//		 {
//			 miFrame.ContieneMenu=false;
//		 }


		 //// CONSTRUYE EL MENU
		 BaseDinamica[] composEnFrame=new BaseDinamica[0];
		 bool bandera=false;
		 string codigo="";
		 ArrayList infoMenu=new ArrayList();


		 /// Construye TABS
		 int nuTabs=this.DimeCuantosTabRegFrame(regFrame);
		 for (int o = 1; o < nuTabs+1; o++)
		 {
			 string regTab=this.DameRegTabControl(regFrame,o);
			 CompoTabControl tabi=this.ConstruyeTabControl(regTab,miFrame);

			 tabi.Click+=new System.EventHandler(miFrame.ClickSobreComponente);
			 tabi.NuevaPagina += new Dinamica.Eventos.NuevaPaginaTabEventHandler(miFrame.RecibeSolicitudNewPagTab);

			 miFrame.Controls.Add(tabi);
		 }


		 /// QUITO EL REGISTRO DE LOS TABS DEL REGISTRO DE FRAMES
		 string regFrame2=regFrame;

		 for (int b = 1; b < nuTabs+1; b++)
		 {
			 string regT=this.DameRegTabControl(regFrame,b);
			 regFrame2=regFrame2.Replace(regT,"");
		 }
		 regFrame=regFrame2;

		 /// CONSTRUYO COMPONENTES
		 int noCompos=this.DimeCuantosComposRegFrame(regFrame);

		 for (int i = 1; i < noCompos+1; i++)
		 {
			 string regCompo=this.DameRegCompoRegFrame(regFrame,i);
			 string[] infoCompo=this.DameInfoComponente(regCompo);
			 int noEventos=this.DimeCuantosEventos(infoCompo[8]);
			 string[,] eventos=new string[noEventos,3];
			 eventos=ProcesaInfoEventos(infoCompo[8],infoCompo[0]);

			 string tex=infoCompo[2];
			 CreaComponente(infoCompo,miFrame);



			 CargaEventos(eventos,miFrame.ID);
		 }

		composEnFrame=PasaDeContrABaseDinamica(miFrame.Controls);

		/// carga configuracion
        /// aqui Configuración se refiere a los cambios hechos en las propiedades
        /// de un componente mediante el inspector de propiedades
        /// mientras que "Configuración Interna" se refiere al codigo interno de la
		/// configuración de un componente
		for (int u = 0; u < noCompos; u++)
		{
			/// obtengo el registro completo de un componente
			string registro=DameRegCompoArchivoPrj(u,regFrame);
			string[] infoCompo=this.DameInfoComponente(registro);
			string nombre=infoCompo[2];


			// carga a Dinamica toda la conf (cambios en propiedades) de compos
			string confi=DameConfDeCompo(registro);
			cargaConf(registro,confFrame[1],confFrame[0]);


			/// del regitro total de la configuración (conf + conf interna)
			/// quito la interna
			int pos1=registro.IndexOf("<Configuracion Interna>");
			int pos2=registro.IndexOf("</Configuracion Interna>");

			if (pos1>-1 && (pos2>-1 && pos2>pos1))
			{
				string pasus=registro.Substring(pos1,(pos2-pos1)+24);
				confi=confi.Replace(pasus,"");
			}

			/// adquiero por separado la configuración interna
			string confgInt=DameConfInternaCompo(registro);
			confgInt=confgInt.Replace("<Configuracion Interna>","");


			string[,] confSeparada=new string[0,3];

			if ((confi!="" && confi!= "\n") || confgInt!="")
			{
				confSeparada=SeparaCadenasConf(confi);
				codigo=codigo+TraduceLineasConf(confSeparada,composEnFrame,bandera,confgInt,nombre);
				bandera=true;
				/// la bandera determina si la declaración de variables se ha hecho
				/// o no dentro del codigo que asigna las propiedades y configuración
			}



		}



			string clase=miClasesita;
			clase=clase.Replace("<CODIGO>", codigo);
			clase=clase.Replace("().=;","");

			clase=RevisaCorrigeOrdenAsignaProps(clase,"Variables","CadenasEcuaciones");
			clase=RevisaCorrigeOrdenAsignaProps(clase,"Parametros","CadenasEcuaciones");
			clase=RevisaCorrigeOrdenAsignaProps(clase,"ValoresParametros","CadenasEcuaciones");
			clase=RevisaCorrigeOrdenAsignaProps(clase,"Metodos","Grafica3D");
			clase=RevisaCorrigeOrdenAsignaProps(clase,"string []","Lineas");

			StreamWriter sw=new StreamWriter("clasesita.txt",false,System.Text.Encoding.ASCII);
			sw.WriteLine(clase);
			sw.Flush();
			sw.Close();

			// el provider da acceso a una instancia de generador de codigo de C# y un compilador
			CSharpCodeProvider miProvider=new CSharpCodeProvider();
			CompilerResults misResultados;

			misResultados=this.Compila2(miProvider,clase);

			if (misResultados.Errors.HasErrors)
			{
				foreach(CompilerError err in misResultados.Errors)
				System.Windows.Forms.MessageBox.Show(err.ErrorText);
			}
			else
			{
				ensamblado=misResultados.CompiledAssembly;
				MiVirtual2 clasi=(MiVirtual2)ensamblado.CreateInstance("Carga_Dlls_Dinam.AplicaPropiedades");
				clasi.AsignaProps(composEnFrame);
			}

			miFrame.Show();

			noFrames=noFrames+1;

	 }









   /// dice cuantos frames estan registrados en un archivo de project
   private int DimeCuantosFrames(string nombreFile)
   {
	   int salida=0;
	   StreamReader sr=new StreamReader(nombreFile,System.Text.Encoding.ASCII,true);

	   string linea;

	   while ((linea=sr.ReadLine()) != null)
	   {
		   int posicion = linea.IndexOf("<FORMA>");
		   if (posicion>-1)salida=salida+1;

	   }

	   return salida;
   }


   /// regresa un regristro completo de una forma identificado por
   /// su ordinal (la posición que ocupa en el archivo)
   private string DameRegistroForma(string nomFile, int nuReg)
   {
	   string salida="";
	   StreamReader sr=new StreamReader(nomFile,System.Text.Encoding.ASCII,true);
	   int leido=0;

	   string linea;

	   while ((linea=sr.ReadLine())!=null)
	   {
		   int pos=linea.IndexOf("<FORMA>");
		   if (pos>-1)leido=leido+1;

		   string linea2="";
		   if (leido==nuReg)
		   {
			  while (linea2!= "</FORMA>")
			  {
				  linea2=sr.ReadLine();
				  salida=salida+linea2+"\n";
			  }
			  break;
		   }
	   }

	   return salida;
   }


   private int DimeCuantosComposRegFrame(string regFrame)
   {
		string[] lineas=regFrame.Split('\n');
		int tam=lineas.Length;
		int salida=0;

		for (int i = 0; i < tam; i++)
		{
			string linea=lineas[i];
			if (linea.IndexOf("<COMPONENTE>")>-1) salida=salida+1;
		}

		return salida;
   }


   private string DameNombrePageTabReg(string regPag)
   {
	   string[] lineas=regPag.Split('\n');
	   int tam=lineas.Length;
	   string salida="";

	   for (int i = 0; i < tam; i++)
	   {
		   string lin=lineas[i];
		   if (lin.IndexOf("nombre:")>-1)
		   {
			   salida=lin;
			   salida=salida.Replace("nombre:","");
			   break;
		   }

	   }
	   return salida;
   }


   private string DameTextoPageTabReg(string regPag)
   {
       string[] lineas=regPag.Split('\n');
	   int tam=lineas.Length;
	   string salida="";

	   for (int i = 0; i < tam; i++)
	   {
		   string lin=lineas[i];
		   if (lin.IndexOf("texto:")>-1)
		   {
			   salida=lin;
			   salida=salida.Replace("texto:","");
			   break;
		   }

	   }
	   return salida;
   }


   private string DameRegCompoRegFrame(string regFrame, int noCompo)
	 {
		 string[] lineas=regFrame.Split('\n');
		 int tam=lineas.Length;
		 string salida="";
		 bool   alto=false;
		 int    cont=-1;

		 int numActual=0;
		 string linea;

		 while (alto==false)
		 {
			 cont = cont+1;
			 linea=lineas[cont];
			 int pos=linea.IndexOf("<COMPONENTE>");
			 if (pos>-1) numActual=numActual+1;

			 if (numActual==noCompo)
			 {
				 do
				 {
					cont=cont+1;
					linea=lineas[cont];
					salida=salida+linea+"\n";
				 }
				 while (linea!="</COMPONENTE>");
				 alto = true;

			 }

		 }

		 return salida;
	 }



	 private BaseDinamica[] DameComposEnFrameDiseño()
	 {
		 System.Windows.Forms.Control.ControlCollection controles=this.disenno.Controls;
		 int tam=controles.Count;
		 object obj;
		 BaseDinamica[] salida=new BaseDinamica[tam];

		 for (int i = 0; i < tam; i++)
		 {
			obj=controles[i];
			salida[i]=(BaseDinamica)obj;
		 }

		 return salida;

	 }




	 	 /// Del registro de la co nfuguracuón del frame. Regresa las lineas
	 /// de configuración del frame
	 private string[] DameConfFrame(string regFrame)
	 {
		 string[] salida=new string[6];
		 string[] lineas=regFrame.Split('\n');

		 for (int i = 0; i < 6; i++)
		 {
			 salida[i]=lineas[i];
		 }

		 string cadi=salida[0];
		 cadi=cadi.Replace("nombre forma:","");
		 salida[0]=cadi;

		 cadi=salida[1];
		 cadi=cadi.Replace("id forma:","");
		 salida[1]=cadi;

		 cadi=salida[2];
		 cadi=cadi.Replace("ancho:","");
		 salida[2]=cadi;

		 cadi=salida[3];
		 cadi=cadi.Replace("alto:","");
		 salida[3]=cadi;

//		 cadi=salida[4];
//		 cadi=cadi.Replace("menu:","");
//		 salida[4]=cadi;

		 cadi=salida[4];
		 cadi=cadi.Replace("ids:","");
		 salida[4]=cadi;

		 cadi=salida[5];
		 cadi=cadi.Replace("text:","");
		 salida[5]=cadi;

		 return salida;
	 }



#endregion



#region COMPONENTE
   /// entra el registro de un componente en el archivo de proyecto
	 /// regresa la información de este registro organizada de la siguiente forma:
	 /// 1. id
	 /// 2. tipo
	 /// 3. Nombre
	 /// 4. dll origen}
	 /// 5. x
	 /// 6. y
	 /// 7. ancho
	 /// 8. alto
	 /// 9. eventos
	 private string[] DameInfoComponente(string registro)
	 {
		 string[] salida=new string[9];
		 string[] trabajo=registro.Split('\n');
		 int posEventos=0;
		 int tam=trabajo.Length;

		 for (int i = 0; i < tam; i++)
		 {
			 string leida=trabajo[i];
			 if (leida.IndexOf("ID:") > -1)   salida[0]=leida.Substring(3);
			 if (leida.IndexOf("tipo:")>-1)   salida[1]=leida.Substring(5);
			 if (leida.IndexOf("nombre:")>-1) salida[2]=leida.Substring(7);
			 if (leida.IndexOf("origen:")>-1) salida[3]=leida.Substring(7);
			 if (leida.IndexOf("x:")>-1)	 salida[4]=leida.Substring(2);
			 if (leida.IndexOf("y:")>-1)	 salida[5]=leida.Substring(2);
			 if (leida.IndexOf("ancho:")>-1)  salida[6]=leida.Substring(6);
			 if (leida.IndexOf("alto:")>-1)   salida[7]=leida.Substring(5);

			 if (leida.IndexOf("<EVENTO>")>-1) posEventos=i;

		 }
         salida[3]=this.directorio+"\\"+salida[3];

		 for (int j = posEventos; j < tam; j++)
		 {
			salida[8]=salida[8]+trabajo[j]+"\n";
		 }


		 return salida;
	 }


	 // DICE CUANTAS LINEAS DE CONFIGURACIÓN HAY EN EL ARCHIVO DE PROYECTO
	 /// GUARDADO
	 private int DimeCuantasLineasConf(string registro)
	 {
		 int salida=-1;
		 bool bandera=false;
		 string[] trabajo=registro.Split('\n');
		 int tam=trabajo.Length;

		 for (int i = 0; i < tam; i++)
		 {
			 string linea=trabajo[i];
			 if (linea.IndexOf("<Configuracion>")>-1) bandera =true; // activa la suma
			 if (linea.IndexOf("</Configuracion>")>-1) break;// desactiva la suma

			 if (bandera==true) salida=salida+1;
		 }

		 return salida;

	 }


	 /// REGRESA LAS CADENAS DE CONFIGURACIÓN DEL ARCHIVO QUE GUARDA U NPROYECTO
	 /// VALIDADAS
	 private string DameConfDeCompo(string registro)
	 {
		 string salida="";
		 string[] trabajo=registro.Split('\n');
		 int tamReg=trabajo.Length;
		 int nuLineasConf=DimeCuantasLineasConf(registro);
		 bool registra=false;
		 int conteo=-1;
		 string nombre="";

		 /// adquiero el nombre del componente
		 for (int k = 0; k < tamReg; k++)
		 {
			 string lin=trabajo[k];
			 if (lin.IndexOf("nombre:")>-1)
			 {
				nombre=lin.Substring(7);
                break;
			 }

		 }

		 /// traigo todas las lineas de configuracion
		 for (int i = 0; i < tamReg; i++)
		 {
			 string linea=trabajo[i];

			 int posi=linea.IndexOf("<Configuracion>");

			 if (posi > -1)
			 {
				registra=true;
			 }

			 posi=linea.IndexOf("</Configuracion>");

			 if (posi > -1)
			 {
			   registra=false;
			   break;
			 }

			 if (registra==true)conteo = conteo+1;

			 if (conteo>0 && registra==true) salida=salida+linea+"\n";
		 }

		 salida=salida.Replace("</Configuracion>","");
		 if (salida.Length>0) salida=salida.Remove(salida.Length-1,1);
		 return salida;
	 }


	 private string DameConfInternaCompo(string registro)
	 {
		 string salida="";
		 int pos=registro.IndexOf("<Configuracion Interna>");
		 int pos2=registro.IndexOf("</Configuracion Interna>");

		 if ((pos>-1 && pos2>-1) && (pos2>pos))
		 {
			salida=registro.Substring(pos,pos2-pos);
		 }
		 return salida;
     }



	 /// Dadas las cadenas de configuración de las propiedades de un componente
	 /// este procedimiento las separa en sus tres componentes principales:
	 /// [0] nombre componente
	 /// [1] nnombre de la propiedad;
	 /// [2] valor de la propiedad
	 /// Y las regresa en un arreglo de cadenas
	 private string[,] SeparaCadenasConf(string configuracion)
	 {
		 string[] trabajo=configuracion.Split('\n');
		 int tam=trabajo.Length;
		 string[,] salida=new string[tam,3]; /// FLIAS,COLUMNAS
		 string nomCompo="";
		 string propCompo="";
		 string valorProp="";

		 for (int i = 0; i < tam; i++)
		 {
			 string cadi=trabajo[i];
			 if (cadi!="")
			 {
				 int posi=cadi.IndexOf(".");
				 if (posi>-1)
				 {
					 nomCompo=cadi.Substring(0,posi);
					 cadi=cadi.Remove(0,posi+1);

					 posi=cadi.IndexOf("=");
					 propCompo=cadi.Substring(0,posi);
					 cadi=cadi.Remove(0,posi+1);

					 posi=cadi.IndexOf(";");
					 valorProp=cadi.Substring(0,posi);

					 salida[i,0]=nomCompo;
					 salida[i,1]=propCompo;
					 salida[i,2]=valorProp;
				 }
			 }
		 }

	   return salida;
	 }



	 /// Entran los componentes contenidos en un frame de diseño y los regresa
	 /// en un arreglo de bases dinamicas jajajaja
	 private BaseDinamica[] PasaDeContrABaseDinamica(System.Windows.Forms.Control.ControlCollection controles)
	 {
		int tam=controles.Count;
		BaseDinamica[] salida=new BaseDinamica[tam];


		for (int i = 0; i < tam; i++)
		{
			salida[i]=(BaseDinamica)controles[i];
		}

		return salida;

	 }




	 /// Entra el arreglo de componentes que estan contenidos en un frame y el mombre de un
	 /// componente buscado en este arreglo
	 /// Lo que regresa es la cadena "ArrayCompos[indiceEncontrado]"
	 private string DameCadenaIndiceArreglo(BaseDinamica[] compos, string nomBus)
	 {
		 int tam=compos.Length;
		 string salida="";

		 for (int i = 0; i < tam; i++)
		 {
			string nomEnc=compos[i].Nombre;
			if (nomEnc==nomBus)
			{
				salida="ArrayCompos["+i.ToString()+"]";
				break;
			}
		 }

		 return salida;

	 }


	 /// Me regresa el tipo (como cadena) de una propiedad buscada
	 /// como cadena tambien dentro de un arreglo de componentes
	 private Type DameTipoPropiedad(BaseDinamica[] compos, string nomCompo, string nomProp)
	 {
		  int tam=compos.Length;
		  Type salida=null;

		  for (int i = 0; i < tam; i++)
		  {
			  string nomEnc=compos[i].Nombre;
			  if (nomEnc==nomCompo)
			  {
				  PropertyDescriptor propi =TypeDescriptor.GetProperties(compos[i]).Find(nomProp,false);
				  if (propi!=null)
				  {
					  salida=propi.PropertyType;
					  break;
				  }

			  }
		  }

		  return salida;
	 }




	 private string DameTipoCompo(BaseDinamica[] compos, string nomBus)
	 {
		 int tam=compos.Length;
		 BaseDinamica bs=new BaseDinamica();
		 string salida="";

		 for (int i = 0; i < tam; i++)
		 {
			 bs=(BaseDinamica)compos[i];
			 string nom=bs.Nombre;
			 if (nom==nomBus)
			 {
				 salida=bs.GetType().ToString();
			 }
		 }

		 return salida;
	 }


	 /// entra la candena "ArrayCompos[#]" y regresa su correspondiente "temp#"
	 private string DameCorrespondiente(string buscado)
	 {
		 int tam=relacion.GetLength(0);
		 string noEnc="";
		 string salida="";

		 for (int i = 0; i < tam; i++)
		 {
			 noEnc=relacion[i,1];
			 if (buscado==noEnc)
			 {
				salida=relacion[i,0];
				break;
			 }
		 }
		return salida;
	 }



	 private string TraduceLineasConfTabPage(string confPag, TabPage pagina)
	 {
		  string salida="";

		  string nomPag=pagina.Name;

		  TabPage pageTempo=new TabPage();
		  pageTempo=pagina;

		  string cadTipo=pagina.GetType().ToString();
		  salida=cadTipo+ " temp0=("+cadTipo+")ArrayCompos[0];"+"\n";
		  salida=salida+confPag;
		  salida=salida.Replace(nomPag,"temp0");

          return salida;
	 }


     /// realacion es un arreglo de cadenas de esta forma: [0]"tempX" [1]"ArrayCompos[X]" [2]""Nombre"
     /// que es la relación entre un nombre real, un nombre asignado temporal y su ordinal en un arerglo
     /// de un componente.
     /// Este método regresa el nombre de un componente que esté en ese arreglo y que esté contenido en
	 /// una linea de texto
	 public string DameNomCompoEnLineaTexto(string[,] relacion, string texto)
	 {
		 int tam=relacion.Length;
		 string control;
		 string salida="";
		 for (int i = 0; i < tam; i++)
		 {
			  control=relacion[i,2];
			  if (texto.IndexOf(control)>-1)
			  {
				 salida=control;
				 break;
			  }

		 }
		 return salida;
	 }



	 /// De las cadenas de configuración de un proyecto guardado correspondientes
	 /// a un solo componente, las traduce en las lineas necesarias que se agregarn
	 /// a la Dll que se encarga de la asignación de propiedades cuando un proyecto
	 /// cargado. Entra el arreglo de cadenas de configuración separadas y sale u na
	 /// cadena que representa todo el código que hace el trabajo de asignación de
	 /// propiedades

	 private string TraduceLineasConf(string[,] cadConf, BaseDinamica[] compos,bool vars,string confInterna,string nombre)
	 {
		 int noFilas=cadConf.GetLength(0);
		 //string[,] copiaCadConf=new string[0,3];
		 string[,] copiaCadConf=cadConf;

		 BaseDinamica[] compos2=new BaseDinamica[0];
		 compos2=compos;

		 string nomCompo="";
		 string nomProp="";
		 string valorProp="";

		 string aux="";
		 string aux2="";
		 string salida="";
		 string variables="";

		 string confIntTemp="";
		 string nomb="";
		 int    indice2=-1;
		 int cuantosCompos=compos.Length;

		 //string lRefresh="";

		 if (vars==false)
		 {
			 relacion=new string[cuantosCompos,3];

			 for (int t = 0; t < cuantosCompos; t++)
			 {
				 BaseDinamica objBD=new BaseDinamica();
				 objBD=(BaseDinamica)compos[t];
				 string tipoo=objBD.GetType().ToString();
				 nomb=objBD.Nombre;
				 string gg=DameCadenaIndiceArreglo(compos2,nomb);
				 variables=variables+tipoo+ " "+nomb +"=("+tipoo+")"+gg+";\n";
				 relacion[t,0]=nomb;
				 relacion[t,1]=gg;
				 relacion[t,2]=nomb;
				 //lRefresh=lRefresh+nomb+".Refresh();"+"\n";
				 if (confInterna!="")indice2=t;
			 }
		  }


		  if (cuantosCompos==0) // si está vacio, lo que viene es un pagtab
		  {

          }


		  string enco="";
		  for (int n = 0; n < cuantosCompos; n++)
		  {
			  enco=relacion[n,2];
			  if (enco==nombre)
			  {
				  enco=relacion[n,0];
				  break;
			  }
		  }


		  if (confInterna!="")
		  {
			int ppp=confInterna.IndexOf(nombre);
			if (ppp>-1)
			{
				confIntTemp=confInterna.Replace(nombre,enco);
			}
		  }




		 for (int i = 0; i < noFilas; i++)
		 {
			bool hereda=false;
			nomCompo=copiaCadConf[i,0];
			nomProp=copiaCadConf[i,1];
			valorProp=copiaCadConf[i,2];
			string tipi="";

			if (((nomCompo!=null) && (nomProp!=null)) && (valorProp!=null ))
			{

				/// "ArrayCompos[indiceEncontrado].NombrePropiedad="
				aux= DameCadenaIndiceArreglo(compos2,nomCompo);
				aux=DameCorrespondiente(aux);
				aux=aux+".";
				tipi=DameTipoCompo(compos2,nomCompo);



				aux=aux+nomProp+"=";

				Type tipoProp=DameTipoPropiedad(compos2,nomCompo,nomProp);
				string tipoPropC=tipoProp.ToString();

				if (tipoProp!=null)	hereda=this.HeredaDeBaseDinamica(tipoProp);
				else hereda=false;


				if (hereda==true)
				{
				   tipi=DameTipoCompo(compos2,valorProp);
				   string sustituye=DameCorrespondiente(DameCadenaIndiceArreglo(compos2,valorProp));
				   aux2=sustituye;
				}
				if (hereda==false)
				{
					aux2=valorProp;





					if (valorProp.IndexOf("Dinamica.BaseDinamica[")>-1)
					{

					   string baseC=valorProp.Substring(0,valorProp.IndexOf("{")+1);
					   baseC=baseC+"#"+"}";
					   string base2="";


						valorProp=valorProp.Substring(valorProp.IndexOf("{")+1,valorProp.Length-valorProp.IndexOf("{")-2);
						string[] special= valorProp.Split(',');

						int tamSpecial=special.Length;
						for (int o = 0; o < tamSpecial; o++)
						{
							string temp=DameCorrespondiente(DameCadenaIndiceArreglo(compos2,special[o]));
							special[o]=temp;
							base2=base2+special[o]+",";
						}
						base2=base2.Substring(0,base2.Length-1);

						baseC=baseC.Replace("#",base2);

						aux2=baseC;
					}


				}

			 if (aux+aux2+";" != ".=;") salida=salida+aux+aux2+";"+"\n";
           }

		 }

		 salida=variables+salida;
		 salida=salida+confIntTemp;
		 //salida=salida+"MesageBox.Show("+ "\"" + salida + "\"" + ");";

		 //salida=salida+"\n";
		 //salida=salida+lRefresh;
		 return salida;


	 }





	 /// en un registro de un componente en el archivo de proyecto, dice cuantos
	 /// evetos de ese componente estan registrados
	 private int DimeCuantosEventos(string eventos)
	 {
		 int salida=0;
		 string[] trabajo=eventos.Split('\n');
		 int tam=trabajo.Length;

		 for (int i = 0; i < tam; i++)
		 {
			 string linea=trabajo[i];
			 if (linea.IndexOf("<EVENTO>")>-1) salida=salida+1;

		 }

		return salida;
	 }





	 /// entrada una linea que contenga el registro de los eventos guardados en el
	 /// archivo de proyecto, los separa en una estructura
	 private string[,] ProcesaInfoEventos(string eventos,string idCompo)
	 {
		 int nuEventos=DimeCuantosEventos(eventos);
		 string[,] salida=new string[nuEventos,3]; // [nombre, codigo]
		 string[] trabajo=eventos.Split('\n');
		 int tamTrabajo=trabajo.Length;
		 int posTrabajo=-1;
		 int posSalida=-1;
		 string linCodigo="";

		 while (posTrabajo<tamTrabajo-1)
		 {
			 posTrabajo=posTrabajo+1;
			 string leida=trabajo[posTrabajo];

			 if (leida.IndexOf("<EVENTO>")>-1)
			 {
				 posTrabajo=posTrabajo+1;
				 posSalida=posSalida+1;
				 salida[posSalida,0]=trabajo[posTrabajo];  // adquiero nombre del evento


				 while (leida!= "</EVENTO>")
				 {

					 posTrabajo=posTrabajo+1;
					 leida=trabajo[posTrabajo];
					 if (leida!= "</EVENTO>") linCodigo=linCodigo+leida+"\n";
				 }

				 salida[posSalida,1]=linCodigo;
				 salida[posSalida,2]=idCompo;
			 }
		 }

		return salida;
	 }



	 private void CreaComponente(string[] datos,Disenno frame)
	 {
		Assembly assem;
		assem=Assembly.LoadFile(datos[3]);

		try
		{
			Dinamica.BaseDinamica compo= (Dinamica.BaseDinamica)assem.CreateInstance(datos[1]);
			compo.Nombre=datos[2];
			compo.id=int.Parse(datos[0]);
			compo.Left=int.Parse(datos[4]);
			compo.Top=int.Parse(datos[5]);
			compo.Width=int.Parse(datos[6]);
			compo.Height=int.Parse(datos[7]);


			int indiceFrame=this.todosFrames.IndexOf(frame);
			Disenno copiaFrame=(Disenno)this.todosFrames[indiceFrame];
			compo.Click += new System.EventHandler(frame.ClickSobreComponente);
			compo.KeyDown += new System.Windows.Forms.KeyEventHandler(frame.TeclaOprimida);
			copiaFrame.Controls.Add(compo);

		}
		catch
		{

		}
	 }





#endregion



#region MENU
   /// Me dice si existe un MENU definido dentro del registro de una  forma
   private bool DimeMenuDefRegFrame(string regFrame)
   {
	   bool salida=false;
	   int pos=regFrame.IndexOf("<MENU>");
	   if (pos>-1) salida=true;

	   return salida;
   }


   /// Regresa el registro de menu dentro de un registro de una forma
   private string DameRegMenu(string regFrame)
   {
	   string salida="";
	   string[] lineas=regFrame.Split('\n');
	   int cont=-1;
	   string lin="";
	   bool alto=false;

	   do
	   {
		  cont=cont+1;
		  lin=lineas[cont];
		  if (lin.IndexOf("<MENU>")>-1)
		  {
			  alto=true;
			  do
			  {
				 cont=cont+1;
				 lin=lineas[cont];
				 salida=salida+lin+"\n";
			  }
			  while(lin!="</MENU>");
		  }
		  salida=salida.Replace("<MENU>","");

	   }
	   while(alto==false);

	   return salida;
   }

      /// Me dice cuantas catas categorías tiene un registro de menu
   /// estas se cuentan por en numero de marcasr del tipo "***"
   private int DimeCuantasCategorias(string regMenu)
   {
	   int salida=0;
	   string[] lineas=regMenu.Split('\n');

	   int tam=lineas.Length;

	   for (int i = 0; i < tam; i++)
	   {
		   string lin=lineas[i];
		   if (lin.IndexOf("***")>-1) salida=salida+1;
	   }

	   return salida;
   }


   /// Me regresa el registro de una categoria (junto con todos su menuItems)
   /// en un registro de un menu
   private string DameRegCategoriaMenu(string regMenu, int regBuscado)
   {
	   string salida="";
	   int regEnc=0;
	   bool segConteo=false;
	   int cont=0;
	   string[] registro=regMenu.Split('\n');

	   int tam=registro.Length;

	   for (int i = 0; i < tam; i++)
	   {
		   string linea=registro[i];
		   if (linea.IndexOf("***")>-1) regEnc=regEnc+1;

		   linea="";
		   if (regEnc==regBuscado)
		   {
			   segConteo=true;
			   cont=i;
			   do
			   {
				  cont=cont+1;
				  salida=salida+registro[cont]+"\n";
			   }
			   while (registro[cont]!="***" && registro[cont]!="</MENU>");
		   }

		   if (segConteo==true) break;

	   }

	   return salida;
   }



   /// Me dice cuantos ItemsMenu tiene una categoria de Menu
   private int DimeCuantasOpciones(string regCategoria)
   {
	   string[] lineas=regCategoria.Split('\n');
	   int tam=lineas.Length;
	   int salida=0;


	   for (int i = 0; i < tam; i++)
	   {
		   string lin=lineas[i];
		   if (lin.IndexOf("item:")>-1) salida=salida+1;
	   }

	   return salida;
   }


   /// Me regresa el registro de un ItemMenu contenido en una categoria
   /// de menu identificado por su ordinal
   private string DameRegOpcion(string regCategoria,int regOpcion)
   {
	   string salida="";
	   string[] lineas=regCategoria.Split('\n');
	   int tam=lineas.Length;
	   bool enc=false;
	   int cont=0;
	   int encon=0;

	   do
	   {
		  cont=cont+1;
		  string lin=lineas[cont];
		  if (lin.IndexOf("item:")>-1) encon=encon+1;

		  if (encon==regOpcion)
		  {
			 enc=true;
			 salida=salida+lineas[cont]+"\n";
			 salida=salida+lineas[cont+1];
		  }

	   }
	   while (enc==false);


	   return salida;

   }








   
#endregion




#region TABCONTROL

	   /// Este metodo construye la linea para guardar un TabControl
	   /// cunando se guarda el proyecto.
	   /// Sobreentiendo que entra un CompoTabControl
	   private string CreaLineasGuardarTabControl(CompoTabControl compoTab,int idFrame, string nomFrame)
	   {
		  string salida="";
		  CompoTabControl elTab=compoTab;
		  System.Windows.Forms.TabControl.TabPageCollection pags=elTab.DamePaginas();
		  string linTab="";

		  int tamPags=pags.Count;

		  salida=salida+"<TABCONTROL>"+"\n";

		  linTab=linTab+"nombre tab:"+elTab.Nombre+"\n";
		  int aux=elTab.id;
		  linTab=linTab+"ID:"+aux.ToString()+"\n";
		  linTab=linTab+"x:"+elTab.Left.ToString()+"\n";
		  linTab=linTab+"y:"+elTab.Top.ToString()+"\n";
		  linTab=linTab+"ancho:"+elTab.Width.ToString()+"\n";
		  linTab=linTab+"alto:"+elTab.Height.ToString()+"\n";

		  salida=salida+linTab+"\n";

		  for (int i = 0; i < tamPags; i++)
		  {
			  TabPage miPagina=new TabPage();
			  miPagina=DamePagDeTab(elTab,i);

			  salida=salida+"<PAGINATAB>"+"\n";
			  salida=salida+"nombre:"+miPagina.Name+"\n";
			  salida=salida+"texto:"+miPagina.Text+"\n";


			  string[] contiene=this.inspector.DameCadenasConfiguracionComoArregloCadenas();
			  int tami=contiene.Length;


			  salida=salida+"<Configuracion>"+"\n";

			  for (int y = 0; y < tami; y++)
			  {
				 string cadi=contiene[y];
				 string nom=miPagina.Name;

				 /// si contiene el nombre de lcompoentes
				 if (cadi.IndexOf(nom)>-1)
				 {
					salida=salida+cadi+"\n";
				 }
			  }




			  salida=salida+"</Configuracion>"+"\n";

			  System.Windows.Forms.Control.ControlCollection conts=this.DameContPagTab(miPagina);
			  string[,] infos=this.DameInfoCompoCollection(conts);
			  string linea=this.CreaLineaGuardaCoponentesColeccion(infos);
			  salida=salida+linea+"\n";
			  salida=salida+"</PAGINATAB>"+"\n"+"\n";
		  }

		  salida=salida+"</TABCONTROL>";

		  return salida;
	   }



	   /// Me dice cuantos TabControls existen en un frame de diseño
	   /// en el proyecto
	   private int DimeCuantosTabControlFrame(int idFrame,string nomFrame)
	   {
		  Disenno dis=this.DameElFrame(idFrame,nomFrame);
		  ArrayList contrls =this.DameObjetosFormaDisenio(idFrame,nomFrame);
		  int tamCtrls=contrls.Count;
		  int salida=0;

		  for (int i = 0; i < tamCtrls; i++)
		  {
			  object obj=contrls[i];
			  if (obj is CompoTabControl) salida=salida+1;
		  }

		  return salida;
	   }


	   /// Me dice cuantos reg de Tab Control existen en un registro de Frame
	   /// de un proyecto guardado
	   private int DimeCuantosTabRegFrame(string regFrame)
	   {
		   int salida=0;
		   string[] lineas=regFrame.Split('\n');
		   int tam=lineas.Length;

		   for (int i = 0; i < tam; i++)
		   {
			   string lin=lineas[i];
			   if (lin.IndexOf("<TABCONTROL>")>-1) salida=salida+1;
		   }

		   return salida;
	   }


	   /// Me da un TabControl contenido en un Frame de Diseño identificado
	   /// por su ordinal en el arreglo de controles con tenidos en el frame
	   private CompoTabControl DameCompoTabControl(int idFrame, string nomFrame,int idTab)
	   {
		   Disenno dis=this.DameElFrame(idFrame,nomFrame);
		   ArrayList ctrls=this.DameObjetosFormaDisenio(idFrame,nomFrame);
		   int tam=ctrls.Count;
		   int encon=0;
		   CompoTabControl salida=new CompoTabControl();

		   for (int i = 0; i < tam; i++)
		   {
			   if (!(ctrls[i] is Marco))
			   {
				   if (ctrls[i] is CompoTabControl)
				   {
					   encon=encon+1;

					   if (encon==idTab)
					   {
						   salida=(CompoTabControl)ctrls[i];
						   break;
					   }
				   }

			   }
		   }

		   return salida;
	   }





   	 /// Regresa las lineas de configuración de un Tab control contenido
	 /// en un registro de un Frame
	 private string[] DameConfTabControl(string regTab)
	 {
		 string[] salida=new string[6];
		 string[] lineas=regTab.Split('\n');

		 for (int i = 0; i < 6; i++)
		 {
			 salida[i]=lineas[i];
		 }

		 string cadi=salida[0];
		 cadi=cadi.Replace("nombre tab:","");
		 salida[0]=cadi;

		 cadi=salida[1];
		 cadi=cadi.Replace("ID:","");
		 salida[1]=cadi;

		 cadi=salida[2];
		 cadi=cadi.Replace("x:","");
		 salida[2]=cadi;

		 cadi=salida[3];
		 cadi=cadi.Replace("y:","");
		 salida[3]=cadi;

		 cadi=salida[4];
		 cadi=cadi.Replace("ancho:","");
		 salida[4]=cadi;

		 cadi=salida[5];
		 cadi=cadi.Replace("alto:","");
		 salida[5]=cadi;

		 return salida;

	 }

   ///Me dice cuantos registros de CompoTabControl existen en un
   /// registro de un Frame de diseño de un proyecto guardado
	private int DimeCuantosRegCompoTab(string regFrame)
	{
		string[] lineas=regFrame.Split('\n');
		int tam=lineas.Length;
		int salida=0;

		for (int i = 0; i < tam; i++)
		{
			string lin=lineas[i];
			if (lin.IndexOf("<TABCONTROL>")>-1) salida=salida+1;
		}

		return salida;
	}


    /// De un registro de un Frame en un proyecto guradado, recupero
   /// el regustro de un Tab por su ordinal
   private string DameRegTabControl(string regFrame, int regTab)
   {
	   string salida="";
	   int regEnc=0;
	   bool segConteo=false;
	   int cont=0;
	   string[] registro=regFrame.Split('\n');

	   int tam=registro.Length;

	   for (int i = 0; i < tam; i++)
	   {
		   string linea=registro[i];
		   if (linea.IndexOf("<TABCONTROL>")>-1) regEnc=regEnc+1;

		   linea="";
		   if (regEnc==regTab)
		   {
			   segConteo=true;
			   cont=i;
			   do
			   {
				   cont=cont+1;
				   salida=salida+registro[cont]+"\n";
			   }
			   while (registro[cont]!="</TABCONTROL>");
		   }

		   if (segConteo==true)break;
	   }

	   return salida;
   }


   /// Me dice cuantos registros de paginas existe en el registro de un
   /// tabControl
   private int DimeCuantasPagTabRegTabControl(string regTab)
   {
	   int salida=0;
	   string[] lineas=regTab.Split('\n');
	   int tam=lineas.Length;

	   for (int i = 0; i < tam; i++)
	   {
		   string lin=lineas[i];
		   if (lin.IndexOf("<PAGINATAB>")>-1) salida=salida+1;

	   }

	   return salida;
   }


   /// Obtiene el registro de una pagina contenida en un registro de un
   /// componente Tab, contenido en un archivo de proyecto
   private string DameRegPag(string regTab,int pagBus)
   {
	   string salida="";
	   int regEnc=0;
	   bool segConteo=false;
	   int cont=0;
	   string[] registro=regTab.Split('\n');

	   int tam=registro.Length;
	   for (int i = 0; i < tam; i++)
	   {
		   string linea=registro[i];
		   if (linea.IndexOf("<PAGINATAB>")>-1) regEnc=regEnc+1;

		   linea="";
		   if (regEnc==pagBus)
		   {
			   segConteo=true;
			   cont=i;
			   do
			   {
				   cont=cont+1;
				   if (registro[cont]!="</PAGINATAB>")salida=salida+registro[cont]+"\n";
			   }
			   while (registro[cont]!="</PAGINATAB>");
		   }

		   if (segConteo==true)break;
	   }

	   return salida;
   }



   /// Crea un CompoTabControl a partir de un registro de un Tab
	 private CompoTabControl ConstruyeTabControl(string regTab,Disenno frame)
	 {

		 string[] confTab=this.DameConfTabControl(regTab);
		 Assembly assem;
		 Assembly ensamblado;
		 string codigo="";
		 string regPag="";
		 string[,] eventos;
		 string[] infoCompo;
		 bool bandera=false;
		 Dinamica.BaseDinamica compo=new Dinamica.BaseDinamica();

		 CompoTabControl salida=new CompoTabControl();
		 salida.Nombre=confTab[0];
		 salida.id=int.Parse(confTab[1]);
		 salida.Left=int.Parse(confTab[2]);
		 salida.Top=int.Parse(confTab[3]);
		 salida.Width=int.Parse(confTab[4]);
		 salida.Height=int.Parse(confTab[5]);
		 salida.Click+= new System.EventHandler(frame.ClickSobreComponente);

		 int nuPags=this.DimeCuantasPagTabRegTabControl(regTab);

		 for (int i = 1; i < nuPags+1; i++)
		 {

			 regPag=this.DameRegPag(regTab,i);

			 int nuCompos=this.DimeCuantosComposRegFrame(regPag);

			 TabPage miPagina=new TabPage();
			 string noPag=this.DameNombrePageTabReg(regPag);
			 string textoPag=this.DameTextoPageTabReg(regPag);
			 miPagina.Name=noPag;
			 miPagina.Text=textoPag;

			 miPagina.Click+=new System.EventHandler(frame.ClickSobreTabPage);

			 for (int j = 1; j < nuCompos+1; j++)
			 {
				 codigo="";
				 string regCompo=this.DameRegCompoRegFrame(regPag,j);
				 infoCompo=this.DameInfoComponente(regCompo);
				 int noEventos=this.DimeCuantosEventos(infoCompo[8]);
				 eventos=new string[noEventos,3];
				 eventos=ProcesaInfoEventos(infoCompo[8],infoCompo[0]);

				 string tex=infoCompo[2];
				 if (tex.IndexOf("CompoMenu")>-1)
				 {
					 
				 }
				 else
				 {
                     assem=Assembly.LoadFile(infoCompo[3]);
					 compo=(BaseDinamica)assem.CreateInstance(infoCompo[1]);
					 compo.Nombre=infoCompo[2];
					 compo.id=int.Parse(infoCompo[0]);
					 compo.Left=int.Parse(infoCompo[4]);
					 compo.Top=int.Parse(infoCompo[5]);
					 compo.Width=int.Parse(infoCompo[6]);
					 compo.Height=int.Parse(infoCompo[7]);
					 compo.Click+=new System.EventHandler(frame.ClickSobreComponente);
					 compo.KeyDown += new System.Windows.Forms.KeyEventHandler(frame.TeclaOprimida);
					 miPagina.Controls.Add(compo);
				 }

				 CargaEventos(eventos,frame.ID);
				 BaseDinamica[] composEnFrame=PasaDeContrABaseDinamica(miPagina.Controls);

				for (int u = 1; u < nuCompos+1; u++)
				{
					/// obtengo el registro completo de un componente
					string registro=this.DameRegCompoRegFrame(regPag,u);
					infoCompo=this.DameInfoComponente(registro);
					string nombre=infoCompo[2];


					string confi=DameConfDeCompo(registro);
					cargaConf(registro,frame.ID.ToString(),frame.Nombre);  // carga a Dinamica toda la conf de compos


					/// del regitro total de la configuración (conf + conf interna)
					/// quito la interna
					int pos1=registro.IndexOf("<Configuracion Interna>");
					int pos2=registro.IndexOf("</Configuracion Interna>");

					if (pos1>-1 && (pos2>-1 && pos2>pos1))
					{
						string pasus=registro.Substring(pos1,(pos2-pos1)+24);
						confi=confi.Replace(pasus,"");
					}

					/// adquiero por separado la configuración interna
					string confgInt=DameConfInternaCompo(registro);
					confgInt=confgInt.Replace("<Configuracion Interna>","");


					string[,] confSeparada=new string[0,3];

					if ((confi!="" && confi!= "\n") || confgInt!="")
					{
						bandera=false;
						confSeparada=SeparaCadenasConf(confi);
						codigo=codigo+TraduceLineasConf(confSeparada,composEnFrame,bandera,confgInt,nombre);
						bandera=true;
						/// la bandera determina si la declaración de variables se ha hecho
						/// o no dentro del codigo que asigna las propiedades y configuración
					}


					string clase=miClasesita;
					clase=clase.Replace("<CODIGO>", codigo);
					clase=clase.Replace("().=;","");

					StreamWriter sw=new StreamWriter("clasesita.txt",true,System.Text.Encoding.ASCII);
					sw.WriteLine(clase);
					sw.Flush();
					sw.Close();

					CSharpCodeProvider miProvider=new CSharpCodeProvider();
					CompilerResults misResultados;

					misResultados=this.Compila2(miProvider,clase);

					if (misResultados.Errors.HasErrors)
					{
						foreach(CompilerError err in misResultados.Errors)
						System.Windows.Forms.MessageBox.Show(err.ErrorText);
					}
					else
					{
						ensamblado=misResultados.CompiledAssembly;
						MiVirtual2 clasi=(MiVirtual2)ensamblado.CreateInstance("Carga_Dlls_Dinam.AplicaPropiedades");
						clasi.AsignaProps(composEnFrame);
						//System.Windows.Forms.MessageBox.Show("Asignación de Propiedades realizada");
					}







				}

			 }


			 string confPag=this.DameConfDeCompo(regPag);
             codigo="";
			 if ((confPag!="" && confPag!= "\n"))
			 {
				codigo=codigo+TraduceLineasConfTabPage(confPag,miPagina);
			 }


			 object[] paginas=new object[1];
			 paginas[0]=miPagina;

			 string clase2=ClasesitaTabs;
			 clase2=clase2.Replace("<CODIGO>", codigo);
			 clase2=clase2.Replace("().=;","");

			 StreamWriter sw2=new StreamWriter("clasesitaTab.txt");
			 sw2.WriteLine(clase2);
			 sw2.Flush();
			 sw2.Close();

			 CSharpCodeProvider miProvider2=new CSharpCodeProvider();
			 CompilerResults misResultados2;

			 misResultados2=this.Compila2(miProvider2,clase2);

			 if (misResultados2.Errors.HasErrors)
			 {
				foreach(CompilerError err in misResultados2.Errors)
				System.Windows.Forms.MessageBox.Show(err.ErrorText);
			 }
			 else
			 {
				ensamblado=misResultados2.CompiledAssembly;
				MiVirtualTabs clasi=(MiVirtualTabs)ensamblado.CreateInstance("Carga_Dlls_Dinam.AplicaPropiedades");
				clasi.AsignaTabs(paginas);
				//System.Windows.Forms.MessageBox.Show("Asignación de Propiedades realizada");
			 }














			 salida.AgregaPagina(miPagina);

		 }
		 return salida;
	 }


#endregion





	 /// regresa el numero registros de componentes en un archivo de proyecto
	 /// de dinamica. Entra el path del archivo del proyecto.
	 private int DameNumeroCompoArchivoPrj(string nombreFile)
	 {
		 int salida=0;
		 StreamReader sr=new StreamReader(nombreFile,System.Text.Encoding.ASCII,true);

		 string linea;

		 while ((linea=sr.ReadLine()) != null)
		 {
			int posicion = linea.IndexOf("<COMPONENTE>");
			if (posicion>-1) salida=salida+1;
		 }


		 return salida;
	 }








	 /// dado un numero ordinal de un componente, regresa la información  el registro
	 /// de este componente en una cadena
	 private string DameRegCompoArchivoPrj(int numeroCompo, string regFrame)
	 {
		 string salida="";
		 bool	alto=false;
		 int    cont=-1;

		 int numActual=-1;
		 string[] lineas=regFrame.Split('\n');

		 string linea;

		 while(alto==false)
		 {
			 cont=cont+1;
			 linea=lineas[cont];

			 int posicion=linea.IndexOf("<COMPONENTE>");
			 if (posicion>-1) numActual=numActual+1;

			 if (numActual==numeroCompo)
			 {
				 string lin="";
				 do
				 {
					cont=cont+1;
					lin=lineas[cont];
					salida=salida+lin+"\n";
				 }
				 while(lin!= "</COMPONENTE>");

				 alto=true;
			 }

		 }

		 return salida;
	 }




	 private void CargaEventos(string[,] eventos, int idFrame)
	 {
		int tam=eventos.GetLength(0);
		string[,] copia=new string[tam,3];

		copia=eventos;

		//controlEventos.Clear();

		for (int i = 0; i < tam; i++)
		{
			templateEstruct tempo=new templateEstruct();
			tempo.idCompo=int.Parse(copia[i,2]);
			tempo.idFrame=idFrame;
			tempo.evento=copia[i,0];
			tempo.codigo=copia[i,1].Split('\n');
			controlEventos.Add(tempo);
		}


	 }






#endregion

#region ADMINISTRA FRAMES EN PROYECTO


   /// verifica si existe un id de un frame Diseño en el arreglo "nombresFrames"
   private bool existeIdFrames(int idBuscado)
   {
	   int tam=nombresFrames.Count;
	   controlFrame tempo;
	   int idEnc;
	   bool salida=false;

	   for (int i = 0; i < tam; i++)
	   {
		   tempo=(controlFrame)nombresFrames[i];
		   idEnc=int.Parse(tempo.ordinalFrame);
		   if (idEnc==idBuscado) salida=true;
	   }

	   return salida;
   }

   /// agrega un item al control de formas de diseño.
   private void addControlDisenno(int id, string nombre)
   {
	   controlFrame tempo;
	   tempo.ordinalFrame=id.ToString();
	   tempo.nombreFrame=nombre;

	   nombresFrames.Add(tempo);
   }



   /// ve si la forma que entra como paramentros ya existe en el control de frames
   /// de tipo "Dinsenno"
   public void VerificaAgregaNombresFrames(object o, Dinamica.Eventos.ObjetoEventArgs OEA)
   {
	   bool yaExisteId=false;

	   if (o is Disenno)
	   {
		  Disenno copiaDisenno=new Disenno(this,this.inspector);
		  copiaDisenno=(Disenno)o;

		  int aydi=copiaDisenno.ID;
		  string nombre=copiaDisenno.Nombre;
		  yaExisteId=existeIdFrames(aydi);

		  if (yaExisteId==false)
		  {
			  addControlDisenno(aydi,nombre);
		  }
	   }
   }


   public void CambiaNombreFrame(int idViejo,string viejoNombre, string nuevoNombre)
   {
	   controlFrame miControl;
	   int tam=nombresFrames.Count;

	   for (int i = 0; i < tam; i++)
	   {
		   miControl=(controlFrame)nombresFrames[i];
		   if ((idViejo.ToString()==miControl.ordinalFrame) /*&& (viejoNombre==miControl.nombreFrame)*/)
		   {
			   miControl.nombreFrame=nuevoNombre;
			   nombresFrames[i]=miControl;
           }
		   
       }
   }


   public void CambiaNombreComponente(int idViejo, string viejoNombre, string nuevoNombre)
   {
	   cadConfiguracion copiaConf;
	   int tam=inspector.cadsConf.Count;

	   for (int i = 0; i < tam; i++)
	   {
		   copiaConf=(cadConfiguracion)inspector.cadsConf[i];

		   if ((idViejo.ToString())==copiaConf.iDFrame.ToString()&& (copiaConf.compoYProp.IndexOf(viejoNombre)>-1))
		   {
			   copiaConf.compoYProp=copiaConf.compoYProp.Replace(viejoNombre,nuevoNombre);
			   inspector.cadsConf[i]=copiaConf;
           }
       }
   }



   /// Dice cuantas formas existen el el proyecto
   ///
   public int CuantasFormasProyecto()
   {
	   int salida =nombresFrames.Count;
	   return salida;
   }


   /// construye la linea para declarar las variables que representan
   /// a todas los "frames" instanciados en el proyecto
   ///
   public string DeclaraVarTipoFrameDisenno()
   {
	   string salida="";
	   int tam=nombresFrames.Count;
	   controlFrame tempo;

	   for (int i = 1; i < tam; i++)
	   {
		   tempo=(controlFrame)nombresFrames[i];
		   salida=salida+"public " + "instancia_"+tempo.nombreFrame+" "+ tempo.nombreFrame+";"+"\n";
	   }
	   return salida;
   }


   /// Construye las lineas para construir instancias de todas la formas
   /// en el proyecto, las cuales son agregadas en el constructor de la forma
   /// principal
   public string NewsFramesTipoDisenno()
   {
	  string salida="";
	  int tam=nombresFrames.Count;
	  controlFrame tempo;

	  for (int i = 1; i < tam; i++)
	  {
		  tempo=(controlFrame)nombresFrames[i];
		  salida=salida+tempo.nombreFrame+ " =new "+"instancia_"+tempo.nombreFrame+"(this);"+"\n";
	  }

	  return salida;
   }





   /// Crea un clase para un frame instanciado en el Frame principal de un
   /// proyecto
	private string CreaClaseFrameInstanciado(int idFrame, string nombreFrame)
	{
		string clase=ClaseInstanciada;
		int tam=todosFrames.Count;
		int idCopia=0;
		string nombreCopia="";

		Disenno copiaDisenno=new Disenno(this,this.inspector);
		string confCad="\n";
		int alto=copiaDisenno.Height;
		int ancho=copiaDisenno.Width;
		int equis=copiaDisenno.Left;
		int ye   =copiaDisenno.Top;

		confCad=confCad+"this.Height="+alto.ToString()+";"+"\n";
		confCad=confCad+"this.Width="+ancho.ToString()+";"+"\n";
		confCad=confCad+"this.Left="+equis.ToString()+";"+"\n";
		confCad=confCad+"this.Top="+ye.ToString()+";"+"\n";

		for (int i = 0; i < tam; i++)
		{
			copiaDisenno=(Disenno)todosFrames[i];
			idCopia=copiaDisenno.ID;
			nombreCopia=copiaDisenno.Nombre;
			if ((idCopia==idFrame )&&(nombreCopia==nombreFrame)) break;
		}

		string declaracionCompos=CreaVariablesRUN(idCopia,nombreCopia);
		string inicioComponentes=CreaVariablesIniciaComponentes(idCopia,nombreCopia);
//		string[,] comportamientoEventos=DefineComportamientoEvento(idCopia,nombreCopia);
		string confCompos=DameTextoConfiguracionCompos(idCopia,nombreCopia);


		Disenno tempPrinci=(Disenno)todosFrames[0];
		string nomPrinc=tempPrinci.Nombre;

		string nombreClase="instancia_"+nombreCopia;

		clase=clase.Replace("<NOMBRE CLASE PRINCIPAL>",nomPrinc);
		clase=clase.Replace("<NOMBRE CLASE INSTANCIADA>",nombreClase);
		clase=clase.Replace("<DECLARACION VAR COMPONENTES>",declaracionCompos);
		clase=clase.Replace("<CREACION DE VAR COMPONENTES>",inicioComponentes);
		clase=clase.Replace("<CONFIGURACION INICIAL COMPONENTES>",confCompos);
		clase=clase.Replace("<CONFIGURACION>",confCad);

		return clase;
	}




	private string ActualizaVariables(string linea,string actualizacion)
	{
		string copia1=linea;
		string copia2="";
		string salida="";

		int indice=copia1.IndexOf("+=");
		copia1=copia1.Substring(0,indice);
		copia2=linea.Replace(copia1,"");
		copia1=copia1.Replace("this.","this."+actualizacion+".");
		copia2=copia2.Replace("this.","this."+actualizacion);


		salida=copia1+copia2;
		return salida;
	}




   /// Crea la clase para ser compilada y crear el ejecutable del proyecto
   /// generado por el usuario en DINAMICA

	   private string LlenaClaseRun2()
		{

			// el primer registro es el frame principal
			controlFrame tempo;
			tempo=(controlFrame)nombresFrames[0];
			int idPrinc=int.Parse(tempo.ordinalFrame);
			string nomPrinc=tempo.nombreFrame;
			Disenno miFra=(Disenno)(this.BuscaFrameDisenno(idPrinc,nomPrinc));

			string confCad="\n";
			int equis=miFra.Left;
			int ye=miFra.Top;
			int alto=miFra.Height;
			int ancho=miFra.Width;

			confCad=confCad+"this.Left="+equis.ToString()+";"+"\n";
			confCad=confCad+"this.Top=" +ye.ToString()+";"+"\n";
			confCad=confCad+"this.Height="+alto.ToString()+";"+"\n";
			confCad=confCad+"this.Width="+ancho.ToString()+";"+"\n";

			/// Pone todos los componentes en diseño a falso para crear
			/// el ejecutable
			int numeroFram=this.todosFrames.Count;
			for (int x = 0; x < numeroFram; x++)
			{
				Disenno miFrameTempo=(Disenno)this.todosFrames[x];
				miFrameTempo.PonEnDisenio(false);
			}







			///  { ***   PARA LA FORMA PRINCIPAL ***    }
			/// 1. Se crean las lineas que declaran los componentes dentro de la forma
			/// 2. Se crean las lineas que hacen los new de cada componentes
			/// 3. crea las lineas que declara los eventos
			///    tanto la linea de declaración del evento como aquella que sección
			///    qie contienen el codigo asiciado al evento
			string declCompos=CreaVariablesRUN(idPrinc,nomPrinc);
			string creaCompos=CreaVariablesIniciaComponentes(idPrinc,nomPrinc);
			string[,] metodos=DefineComportamientoEvento(idPrinc,nomPrinc);
			string conf=DameTextoConfiguracionCompos(idPrinc,nomPrinc);


			string declaraInstanciasFrames="";
			string newsInstanciasFrames="";

			int noFrames=CuantasFormasProyecto();

			if (noFrames>1)
			{
				// hace la declaración de cada una de las formas hijas
				declaraInstanciasFrames=DeclaraVarTipoFrameDisenno();
				// hace la linea que crea las intancias de las clases hijas
				newsInstanciasFrames=NewsFramesTipoDisenno();
			}

			string lineaEventos="";

			int tami=metodos.Length;
			if (tami!=0) tami=tami/2;

			/// para cada uno de los eventos para la clase principal adquiero
			/// las lineas que declaran el evento
			for (int i = 0; i < tami; i++)
			{
			   lineaEventos=lineaEventos+"\n"+metodos[i,0];
			}


/// creo las lineas de declaración de los eventos para las formas hijas
			string cadenita="";
			int aux1=todosFrames.Count;
			string[,] cadAux1=new string[0,2];


			if (aux1>1)
			{
				for (int y = 1; y < aux1; y++)
				{
					tempo=(controlFrame)nombresFrames[y]; // tempo es un controlFrame
					cadAux1=DefineComportamientoEvento(int.Parse(tempo.ordinalFrame),tempo.nombreFrame);

					int longi=cadAux1.GetLength(0);
					if (longi>0)
					{
						for (int u = 0; u < longi; u++)
						{
							cadenita=cadenita+"\n"+cadAux1[u,0];
							cadenita=ActualizaVariables(cadenita,tempo.nombreFrame);
						}
						lineaEventos=lineaEventos+cadenita+"\n";
					}

				}
			}
/// cierro la sección de declaración de eventos
			lineaEventos=lineaEventos+"}/// cierra IncializaComponentes"+"\n"+"\n";


// SE CREA EL TEXTO QUE CONTIENE EL CODIGO ASOCIADO al evento para la forma principal
			for (int j = 0; j < tami; j++)
			{
				lineaEventos=lineaEventos+"\n"+metodos[j,1];
			}

			Disenno copia=(Disenno)this.todosFrames[0];

			string codigoMenu="";
			string nomMenu="";
			Dinamica.MenuPrin menuTemp = null;

			foreach(Control ctrl in copia.Controls)
			{
			  if(ctrl.GetType() == typeof(Dinamica.MenuPrin))
			  {
				menuTemp = (Dinamica.MenuPrin)ctrl;
				break;
			  }
			}

			if (menuTemp != null)
			{
				 nomMenu=menuTemp.Nombre;
				 menuTemp.PonEnDisenio(false);
				 codigoMenu=menuTemp.DameMetodosOpcs();
				 codigoMenu=codigoMenu.Replace("<COMPO>",nomMenu);
				 menuTemp.PonEnDisenio(true);
				 lineaEventos=lineaEventos+codigoMenu+"\n";
            }



/// SE CREA EL TEXTO QUE CONTIENE EL CODIGO ASOCIADO PARA LOS EVENTSO DE LOS FRAMES HIJOS
			cadAux1=new string[0,2];
			cadenita="";
			if (aux1>1)
			{
				for (int y = 1; y < aux1; y++)
				{
					tempo=(controlFrame)nombresFrames[y];

					cadAux1=DefineComportamientoEvento(int.Parse(tempo.ordinalFrame),tempo.nombreFrame);
					int longi=cadAux1.GetLength(0);
					if (longi>0)
					{
						for (int r = 0; r < longi; r++)
						{
							string ttt=cadAux1[r,1];
							ttt=ttt.Replace("private void ","private void "+tempo.nombreFrame);
							ttt=ttt.Replace(nomPrinc,"this");
							cadenita=cadenita+"\n"+ttt;
						}
						lineaEventos=lineaEventos+cadenita+"\n";


					}
				}
			}


/// SE CREA EL TEXTP DEL FRAME PRINCIPAL (LA CLASE COMPLETA)
			string cadenaFinal=Plantilla;
			cadenaFinal=cadenaFinal.Replace("<DECLARACION VAR COMPONENTES>",declCompos);
			cadenaFinal=cadenaFinal.Replace("//<DECLARACION DE FRAMES INSTANCIADOS>",declaraInstanciasFrames);
			cadenaFinal=cadenaFinal.Replace("<CREACION DE VAR COMPONENTES>",creaCompos);
			cadenaFinal=cadenaFinal.Replace("//<CONSTRUCCION DE FRAMES INSTANCIADOS>",newsInstanciasFrames);
			cadenaFinal=cadenaFinal.Replace("<CONFIGURACION INICIAL COMPONENTES>",conf);
			cadenaFinal=cadenaFinal.Replace("<CODIGO EVENTOS>",lineaEventos);
			cadenaFinal=cadenaFinal.Replace("<CONFIGURACION>",confCad);


/// SE CREA EL TEXTO PARA CADA UNA DE LAS CLASES HIJAS Y SE AGREGA AL DE LA CLASE
/// PRINCIPAL
			int noInst=todosFrames.Count;
			for (int h = 1; h < noInst; h++)
			{
				tempo=(controlFrame)nombresFrames[h];
				string claseInst=CreaClaseFrameInstanciado(int.Parse(tempo.ordinalFrame),tempo.nombreFrame);
				cadenaFinal=cadenaFinal.Replace("///<CLASE INSTANCIADA>",claseInst);
			}


/// SE CREA EL ARCHIVO DE TEXTO PARA SU REVISIÓN.
			StreamWriter sw=new StreamWriter("file.txt");
			sw.WriteLine(cadenaFinal);
			sw.Flush();
			sw.Close();




            /// Regresa todo al estado de diseño
			for (int b = 0; b < numeroFram; b++)
			{
				Disenno miFrameTempo=(Disenno)this.todosFrames[b];
				miFrameTempo.PonEnDisenio(true);
			}

            return cadenaFinal;
		}



		/// Solo Compila no crea ejecutable
		private CompilerResults Compila2(CodeDomProvider pro, string codigo)
		{
			string cadena;
			string[] enlaces;

			ICodeCompiler comp=pro.CreateCompiler();
			CompilerParameters cp=new CompilerParameters();
			enlaces=DameListaTotalDllsPaleta();

			for (int i = 0; i <4; i++)
				cp.ReferencedAssemblies.Add(enlaces[i]);

				/// ---> unica diferencia para crear ejecutable
				///cp.OutputAssembly="salida.exe";

			cadena = Assembly.GetAssembly(typeof(Paleta)).CodeBase;
			cadena = cadena.Substring(8);
			cp.ReferencedAssemblies.Add(cadena);

			cadena=cadena.Substring(0,cadena.LastIndexOf('/')+1);

			for (int u = 4; u < enlaces.Length; u++)
			{
				cp.ReferencedAssemblies.Add(cadena+enlaces[u]);
			}

			   /// ---> Diferencia para crear ejecutalble
			   /// false--> true --> false
			cp.GenerateExecutable=false;
			cp.GenerateInMemory=true;



			CompilerResults cr=comp.CompileAssemblyFromSource(cp, codigo);


			return cr;
		}




				/// Crea ejecutable
		private CompilerResults CreaExe(CodeDomProvider pro, string codigo, string nombreProj, bool creaExe)
		{
			string cadena;
			string[] enlaces;

			System.IO.Directory.SetCurrentDirectory(directorio);

			ICodeCompiler comp=pro.CreateCompiler();
			CompilerParameters cp=new CompilerParameters();
			enlaces=DameListaTotalDllsPaleta();

			for (int i = 0; i < enlaces.Length; i++)
				cp.ReferencedAssemblies.Add(enlaces[i]);

				/// ---> unica diferencia para crear ejecutable
				if (nombreProj!="" && creaExe== true)
				{
					cp.OutputAssembly=directorio+"\\"+nombreProj;
					cp.GenerateExecutable=true;
					cp.GenerateInMemory=false;
				}

				if (nombreProj=="" && creaExe==true)
				{
					cp.OutputAssembly=directorio+"\\"+"salida.exe";
					cp.GenerateExecutable=true;
					cp.GenerateInMemory=false;
				}

				if (creaExe==false)
				{
					cp.GenerateExecutable=false;
					cp.GenerateInMemory=true;
				}

			cadena = Assembly.GetAssembly(typeof(Paleta)).CodeBase;
			cadena = cadena.Substring(8);
			cp.ReferencedAssemblies.Add(cadena);



			   /// ---> Diferencia para crear ejecutalble
			   /// false--> true --> false


			CompilerResults cr=comp.CompileAssemblyFromSource(cp, codigo);

			return cr;
		}














        /// Crea una clase de las que se instancían en la principal
		/// del proyecto
		private string CreaClaseInstanciada(string id, string nombre)
		{
			string salida="";
			return salida;

        }






		/// Engloba todo el proces para crear el ejecutable del proyecto hecho
		/// por el usuario
		public void Ejecuta2(string nombreProjecto, bool crearEjecutable)
		{
			CSharpCodeProvider prov = new CSharpCodeProvider();
			CompilerResults res;

			 string codigo=LlenaClaseRun2();

			 StreamWriter s=new StreamWriter("salidaExe.txt",false,System.Text.Encoding.ASCII);
			 s.Write(codigo);
			 s.Flush();
			 s.Close();

			 res = CreaExe(prov,codigo,nombreProjecto,crearEjecutable);
			 if(res.Errors.HasErrors)
			 {
				 System.Windows.Forms.MessageBox.Show("error");
				 foreach(CompilerError err in res.Errors)
					 resulCompilacion=System.Windows.Forms.MessageBox.Show(err.ErrorText,"MENSAJE DE COMPILACION",MessageBoxButtons.OK);
			 }
			 else
			 {
				 resulCompilacion=System.Windows.Forms.MessageBox.Show("Código correcto","MENSAJE DE COMPLIACION",MessageBoxButtons.YesNo);
			 }
		}





#endregion

#region Click Sobre Menú principal


		/*
			Cargar componente
		*/
		private void menuItemCargar_Click(object sender, System.EventArgs e)
		{
			cargaCompo=new CargaCompo(this);
			int tam;

			tam=DameNumeroTabs();
			string[] nombres;
			nombres=new string[tam];
			nombres=DameTextTabs();

			cargaCompo.Opciones=nombres;
			cargaCompo.Show();
		}

		/*
			Ejecutar proyecto (RUN)
		*/
		private void menuItem2_Click(object sender, System.EventArgs e)
		{

			creaExe.Show();

		}


#endregion



		private void bitButton2_Click(object sender, System.EventArgs e)
		{
			aCrear="Malla";
		}


		///
		/// "GUARDAR PROYECTO"
		///
		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			 if (GuardaProyecto.ShowDialog()==System.Windows.Forms.DialogResult.OK)
			 {
				 CreaFileProyecto(GuardaProyecto.FileName);
			 }

		}



		///
		/// Se crea una nueva forma de diseño, se verifica si esta ya existe en el control
		///
		private void menuItem6_Click(object sender, System.EventArgs e)
		{
			Disenno forma;
			forma=new Disenno(this,this.inspector);
			forma.EnviaObjeto+=new  Dinamica.Eventos.EnviaObjetoEventHandler(inspector.PonPropiedades);

			noFrames=noFrames+1;
			forma.Nombre="Forma"+noFrames;
			forma.ID=noFrames;

			string[] listaEvetVacia=new string[0];
			EventInfo[] eventos=new EventInfo[0];
			string tipoVacio="";
			int miId=0;
			string[] listaVacia=new string[0];

			Dinamica.Eventos.ObjetoEventArgs eventoVacio=new Dinamica.Eventos.ObjetoEventArgs(forma, listaEvetVacia,eventos,forma.ID,tipoVacio,miId,listaVacia);
			VerificaAgregaNombresFrames(forma,eventoVacio);

			int noFormas=todosFrames.Count;

			todosFrames.Add(forma);

			forma.Show();
		}


		///
		/// Del control de nombres y ordinales de los frames que existen actualmente
		/// en el proyecto se borra aquel de la forma que se remueve del proyecto
		///
		private void BorraNombreFrameLista(int IDFrame, string nombreFrame)
		{
			int tami=nombresFrames.Count;
			controlFrame buscado;
			buscado.ordinalFrame=IDFrame.ToString();
			buscado.nombreFrame=nombreFrame;
			bool existe=false;

			for (int i = 0; i < tami; i++)
			{
				existe=nombresFrames.Contains(buscado);

				if (existe)
				{
					nombresFrames.Remove(buscado);
					break;
				}

			}


		}


		public void BorraComposFrameBorrado(Disenno frame)
		{
			BaseDinamica obj=new BaseDinamica();
			int tam=frame.Controls.Count;

			for (int i = 0; i < tam; i++)
			{
				if (frame.Controls[i] is BaseDinamica)
				{
					obj=(BaseDinamica)frame.Controls[i];
					obj.BringToFront();
					obj.Capture=false;

					string nombre=obj.Nombre;
					int tami=this.inspector.cadsConf.Count;
					if (tami>0) tami=tami-1;
					
					int idi=-1;

					for (int y = 0; y < tami; y++)
					{
						 idi=-1;
						 idi=this.disenno.IndNomEncontrado(nombre);
						 if (idi>-1) this.disenno. BorraRegistro(idi);
					}

					/// BORRO EL COMPONENTE
					if ((this.Controls.Contains(this.disenno.marco)))
					{
						this.Controls.Remove(this.disenno.marco);
						this.Controls.Remove(obj);
					}
				}

			}


		}



        ///
        /// Del arreglo que contiene todas las formas que constituyen el actual proyecto
		/// se borra aquella que ha sido quitada del proyecto
		///
		public void BorraFormaDisenno(int IDFrame, string nombreFrame)
		{
			int idEnc=-1;
			string nombreEnc="";

			int tam=todosFrames.Count;

//			if (tam>1)
			{
				for (int i = 0; i < tam; i++)
				{
					Disenno tempo=(Disenno)todosFrames[i];
					idEnc=tempo.ID;
					nombreEnc=tempo.Nombre;

					if ((idEnc==IDFrame) && (nombreEnc==nombreFrame))
					{
						BorraComposFrameBorrado((Disenno)todosFrames[i]);
						todosFrames.Remove(todosFrames[i]);
						noFrames=noFrames-1;
						BorraNombreFrameLista(IDFrame,nombreFrame);
						this.RemoveOwnedForm(tempo);
					}
				}
			}
		}







		private void button1_Click(object sender, System.EventArgs e)
		{
			aCrear="Boton Paleta";
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			aCrear="Cuadro Texto";
		}

		private void menuItemCerrar_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void menuItemNuevo_Click(object sender, System.EventArgs e)
		{
			DialogResult resp;
			 resp= MessageBox.Show("El Actual proyecto será cerrado.. ¿Deseas continuar?", "Advertencia",MessageBoxButtons.YesNo);

			 if (resp==DialogResult.Yes)
			 {

				int cuantasFormas=this.todosFrames.Count;

				for (int i = 0; i < cuantasFormas; i++)
				{
					Disenno dis=(Disenno)todosFrames[i];
					int id=dis.ID;
					string nom=dis.Nombre;
					BorraFormaDisenno(id,nom);
					dis.Close();
				}

				this.todosFrames.Clear();
				this.inspector.cadsConf.Clear();

				if (AbreProyecto.ShowDialog()== System.Windows.Forms.DialogResult.OK)
				{
					 int noFrames=this.DimeCuantosFrames(AbreProyecto.FileName);
					 for (int g = 1; g < noFrames+1; g++)
					 {
						string regFrame=this.DameRegistroForma(AbreProyecto.FileName,g);
						this.CreaFrame(regFrame);
					 }


				}

			 }
			 if (resp==DialogResult.No)
			 {

			 }

		}

		private void menuItem6_Click1(object sender, System.EventArgs e)
		{
			Disenno forma;
			forma=new Disenno(this,this.inspector);
			forma.EnviaObjeto+=new  Dinamica.Eventos.EnviaObjetoEventHandler(inspector.PonPropiedades);

			noFrames=noFrames+1;
			forma.Nombre="Forma"+noFrames;
			forma.ID=noFrames;

			string[] listaEvetVacia=new string[0];
			EventInfo[] eventos=new EventInfo[0];
			string tipoVacio="";
			int miId=0;
			string[] listaVacia=new string[0];

			Dinamica.Eventos.ObjetoEventArgs eventoVacio=new Dinamica.Eventos.ObjetoEventArgs(forma, listaEvetVacia,eventos,forma.ID,tipoVacio,miId,listaVacia);
			VerificaAgregaNombresFrames(forma,eventoVacio);

			int noFormas=todosFrames.Count;

			todosFrames.Add(forma);
			this.AddOwnedForm(forma);

			forma.Show();
		}
		
		private void menuItem7_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		
		private void BotonEliminar_Click(object sender, System.EventArgs e)
		{
			
		}
		
		private void Paleta_Load(object sender, System.EventArgs e)
		{

		}
		
		private void Paleta_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{

		}
		
		private void Paleta_Click(object sender, System.EventArgs e)
		{
			FormWindowState miEstado=this.WindowState;
			if (miEstado==FormWindowState.Maximized)
			{
                 this.inspector.WindowState=FormWindowState.Minimized;
			}
		}
		
		private void menuItem11_Click(object sender, System.EventArgs e)
		{
            this.miIntro.Show();
		}
		
		private void menuItem9_Click(object sender, System.EventArgs e)
		{
			this.panel1.Visible=!this.panel1.Visible;

			if (this.panel1.Visible==true)
			{
				this.Tabs.Left=94;
				this.Tabs.Width=this.Width-94;
			}
			if (this.panel1.Visible==false)
			{
				this.Tabs.Left=5;
				this.Tabs.Width=this.Width-5;
			}
			
			
		}
		
		private void BotonAddCompo_Click(object sender, System.EventArgs e)
		{

		}
		

		





	}
}
