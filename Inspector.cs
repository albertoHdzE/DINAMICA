using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using ComponentesIDEdinamica;
using System.Reflection;
using Dinamica;
using Dinamica.Eventos;

namespace Carga_Dlls_Dinam
{
	public struct cadConfiguracion
		{
			public int    iDFrame;
			public string nombreFrame;
			public string compoYProp;
			public string valor;
        }


	public class Inspector : System.Windows.Forms.Form
	{

		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage PropiedadesTab;
		private System.Windows.Forms.TabPage EventosTab;
		public System.Windows.Forms.PropertyGrid propertyGrid1;
		private Paleta paleta;
		private Disenno disenno;

		/// instancia del editor de codigo
		public EditorCodigo	 Editor;

        /// Para almacenar las cadenas de configuración cuando una
		/// propiedad de tipo BaseDinamcica Cmabia
		public ArrayList cadsConf=new ArrayList();
		private System.Windows.Forms.TabPage TabMetodos;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.ListBox listaMetodos;

		public event Dinamica.Eventos.EnviaMetodoEventHandler MetodoEnviado;







		public struct unEvento
		{
			public int ID;
			public string nombreEvento;
			public string codigo;
		}


		public Inspector(Paleta paleta, Disenno disenno)
		{
			this.paleta=paleta;
			this.disenno=disenno;
			InitializeComponent();
			Editor=new EditorCodigo(paleta);
            this.MetodoEnviado+= new EnviaMetodoEventHandler(Editor.InsertaMetodo);
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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.PropiedadesTab = new System.Windows.Forms.TabPage();
			this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
			this.EventosTab = new System.Windows.Forms.TabPage();
			this.TabMetodos = new System.Windows.Forms.TabPage();
			this.listaMetodos = new System.Windows.Forms.ListBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.tabControl1.SuspendLayout();
			this.PropiedadesTab.SuspendLayout();
			this.TabMetodos.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
						| System.Windows.Forms.AnchorStyles.Left) 
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.PropiedadesTab);
			this.tabControl1.Controls.Add(this.EventosTab);
			this.tabControl1.Controls.Add(this.TabMetodos);
			this.tabControl1.Location = new System.Drawing.Point(4, 36);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(194, 378);
			this.tabControl1.TabIndex = 0;
			// 
			// PropiedadesTab
			// 
			this.PropiedadesTab.Controls.Add(this.propertyGrid1);
			this.PropiedadesTab.Location = new System.Drawing.Point(4, 22);
			this.PropiedadesTab.Name = "PropiedadesTab";
			this.PropiedadesTab.Size = new System.Drawing.Size(186, 352);
			this.PropiedadesTab.TabIndex = 0;
			this.PropiedadesTab.Text = "Propiedades";
			// 
			// propertyGrid1
			// 
			this.propertyGrid1.CommandsVisibleIfAvailable = true;
			this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.propertyGrid1.HelpVisible = false;
			this.propertyGrid1.LargeButtons = false;
			this.propertyGrid1.LineColor = System.Drawing.SystemColors.ScrollBar;
			this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
			this.propertyGrid1.Name = "propertyGrid1";
			this.propertyGrid1.Size = new System.Drawing.Size(186, 352);
			this.propertyGrid1.TabIndex = 0;
			this.propertyGrid1.Text = "propertyGrid1";
			this.propertyGrid1.ToolbarVisible = false;
			this.propertyGrid1.ViewBackColor = System.Drawing.SystemColors.Window;
			this.propertyGrid1.ViewForeColor = System.Drawing.SystemColors.WindowText;
			this.propertyGrid1.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid1_PropertyValueChanged1);
			this.propertyGrid1.SelectedGridItemChanged += new System.Windows.Forms.SelectedGridItemChangedEventHandler(this.propertyGrid1_SelectedGridItemChanged);
			// 
			// EventosTab
			// 
			this.EventosTab.Location = new System.Drawing.Point(4, 22);
			this.EventosTab.Name = "EventosTab";
			this.EventosTab.Size = new System.Drawing.Size(186, 352);
			this.EventosTab.TabIndex = 1;
			this.EventosTab.Text = "Eventos";
			// 
			// TabMetodos
			// 
			this.TabMetodos.Controls.Add(this.listaMetodos);
			this.TabMetodos.Location = new System.Drawing.Point(4, 22);
			this.TabMetodos.Name = "TabMetodos";
			this.TabMetodos.Size = new System.Drawing.Size(186, 352);
			this.TabMetodos.TabIndex = 2;
			this.TabMetodos.Text = "Metodos";
			// 
			// listaMetodos
			// 
			this.listaMetodos.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listaMetodos.Location = new System.Drawing.Point(0, 0);
			this.listaMetodos.Name = "listaMetodos";
			this.listaMetodos.Size = new System.Drawing.Size(186, 352);
			this.listaMetodos.TabIndex = 0;
			this.listaMetodos.SelectedIndexChanged += new System.EventHandler(this.listaMetodos_SelectedIndexChanged);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.checkBox1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(202, 36);
			this.panel1.TabIndex = 1;
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(6, 6);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(188, 24);
			this.checkBox1.TabIndex = 0;
			this.checkBox1.Text = "Resumen de Propiedades";
			this.checkBox1.Click += new System.EventHandler(this.checkBox1_Click);
			// 
			// Inspector
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(202, 416);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.tabControl1);
			this.Location = new System.Drawing.Point(200, 250);
			this.Name = "Inspector";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "INSPECTOR";
			this.tabControl1.ResumeLayout(false);
			this.PropiedadesTab.ResumeLayout(false);
			this.TabMetodos.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		#endregion



		/// "cadsConf" guarda la info de las propiedades que cambian
        /// mediante el inspector de propiedades.
		/// Este método regresa ese arreglo como cadenas de Texto
		/// La info es guardada en estructuras "cadCOnfiguracio" con dos
		/// campos: "Compo", y valor de la propiedad
		public string[] DameCadenasConfiguracionComoArregloCadenas()
		{
		   int tami=this.cadsConf.Count;
		   string[] salida=new string[tami];
		   for (int i = 0; i < tami; i++)
		   {
			   cadConfiguracion tempi=(cadConfiguracion)this.cadsConf[i];
			   string conti=tempi.compoYProp+tempi.valor;
			   salida[i]=conti;
		   }

		   return salida;
        }




        /// Cada vez que se hace click sobre un boton que representa el evento de un componente
        /// se recupera toda la información que recide en el boton para pasarla al editor de
		/// codigo
		private void ClikBotonEvento(object sender, System.EventArgs e)
		{
			BotonEvento boton = new BotonEvento();
			boton=(BotonEvento)sender;

			// info dentro del boton de evento
			int idCompo=boton.IDComponente;        								    // Id del componente
			int idFrame=boton.IDFrame;							                    // id Frame
			string evento=boton.NombreEvento;										// nombre del evento
			string[] codigo=Paleta.DameCodigoAsociado(idCompo,idFrame,evento);		// el código asociado al evento

			string tipEvento=boton.TipoEventHandler;								// el tipo del evento
			string tipCompo=boton.TipoComponente;									// el tipo del componente
			string[] metodos=boton.ListaMetodos;
			EventInfo eventoRela=boton.EventoRelacionado;							// el evento como tal


			// toda la anterior información se pasa el Editor de codigo

			string tit="";
			for (int i = 0; i < codigo.Length; i++)
			{
				tit=tit+codigo[i]+"\n";
			}

			Editor.CodigoAsociado=tit;
			Editor.IdComponente=idCompo;
			Editor.IdFrame=idFrame;
			Editor.EventoActual=evento;
			Editor.TipoEvento=tipEvento;
			Editor.TipoComponente=tipCompo;
			Editor.EventoRelacionado=eventoRela;
			Editor.ListaMetodos=metodos;
			Editor.Viendose=true;


			Editor.Show();

		}




		/// entran
		/// 1. la lista de eventos contenidos en un componente como cadena
        /// 2. Los eventos como tales (EventInfo[])
		/// 3. El ID del componente
        /// 4. El tipo de Componente
        /// Y crea un botonEvento por cada evento en este componente agregandole toda la
		/// información necesaria para ejecutar el "ClikBotonEvento"
		private void CreaBotonesEventos(string[] eventosList,EventInfo[] eventos,int idComponente,string tipoCompo, int idForma, string[] listaMetodos)
		{
			int nuEventos=eventosList.Length;
			int nuBotHoy=this.EventosTab.Controls.Count;

			if (nuBotHoy>0)
			{
				this.EventosTab.Controls.Clear();
			}

			for (int i = 0; i < nuEventos; i++)
			{
				BotonEvento boton=new BotonEvento();
				boton.Width=this.EventosTab.Width;
				boton.Height=23;
				boton.Top=23*i;
				boton.IDComponente=idComponente;

				boton.Text=eventosList[i];             // --> solo nombre del evento
				boton.EventoRelacionado=eventos[i];	   // --> el evento como tal

				string cadi="";
				int posi;
				posi=eventosList[i].IndexOf(" ");
				cadi=eventosList[i].Substring(0,posi);
				boton.TipoEventHandler=cadi;
				boton.NombreEvento=boton.Text;
				boton.TipoComponente=tipoCompo;
				boton.IDFrame=idForma;
				boton.ListaMetodos=listaMetodos;


				boton.Click+=new System.EventHandler(ClikBotonEvento);
				this.EventosTab.Controls.Add(boton);
			}
		}


		/// actualiza el codigo asociado al evento
		private void AgregaCodigoAsociadoEvento(int id, string eventoIn,string codigoIn)
		{
			unEvento evento;
			evento.ID=id;
			evento.nombreEvento=eventoIn;
			evento.codigo=codigoIn;

			Paleta.controlEventos.Add(evento);
		}


		private bool DimeSiEsta(string buscado, ArrayList lista)
		{
			int tam=lista.Count;
			string linea="";

			bool salida=false;

			for (int i = 0; i < tam; i++)
			{
				linea=lista[i].ToString();
				if (linea==buscado)
				{
					salida=true;
					break;
				}
			}

			return salida;
		}


		/// muestra las propiedades del componente seleccionado que se encuentra
		/// en la forma de diseño y crea los botones de sus eventos
		public void PonPropiedades(object o, Dinamica.Eventos.ObjetoEventArgs OEA)
		{

			propertyGrid1.SelectedObject = OEA.Componente;

			Type tipo=OEA.Componente.GetType();

			MethodInfo[] infoMetodos=tipo.GetMethods(BindingFlags.CreateInstance|BindingFlags.Public|BindingFlags.Instance|BindingFlags.DeclaredOnly);


			int tam=infoMetodos.Length;
			this.listaMetodos.Items.Clear();
			string cadena="";
			string nombre="";
			int indi;
			int indi2;
			ArrayList nombres=new ArrayList();

			for (int i = 0; i < tam; i++)
			{
				cadena=infoMetodos[i].ToString();
				if (cadena.IndexOf("add_")>-1 || cadena.IndexOf("remove_")>-1)
				{
					indi2=cadena.IndexOf("(");
					indi=cadena.IndexOf("add_");
					if (indi>-1)
					{
					   nombre=cadena.Substring(indi+4,(indi2-(indi+4)));
					}
					indi=cadena.IndexOf("remove_");
					if (indi>-1)
					{
					   nombre=cadena.Substring(indi+7,(indi2-(indi+7)));
					}

				}

				if (cadena.IndexOf("add_")==-1 && cadena.IndexOf("remove_")==-1 && cadena.IndexOf("System.EventArgs")==-1
					&& cadena.IndexOf("get")==-1 && cadena.IndexOf("set")==-1) this.listaMetodos.Items.Add(cadena);

			}


			int tamItems=this.listaMetodos.Items.Count;
			string[] listaMetodos=new string[tamItems];

			for (int y = 0; y < tamItems; y++)
			{
                listaMetodos[y]=this.listaMetodos.Items[y].ToString();
            }

			this.Update();
			CreaBotonesEventos(OEA.ListaEventos,OEA.eventos,OEA.idCompo,OEA.tipo,OEA.idFrame,listaMetodos);
		}



	#region actualiza cadenas de configuración al cambio de propiedades


		/// entra una cadena que es la que se busca en el ArrayList
		/// que contiene todas las cadenas de la sección de connfiguración
		/// que representan el ligado de componentes, y dice si la
		/// cadena buscada ya existe en el arreglo
		private bool YaExisteCad(string cadBuscada)
		{
			bool salida=false;
			string cadEncon="";
			int tam=this.cadsConf.Count;
			cadConfiguracion copia;

			if (tam>0)
			{
				for (int i = 0; i < tam; i++)
				{
					copia=(cadConfiguracion)this.cadsConf[i];
					cadEncon=copia.compoYProp;
					if (cadEncon==cadBuscada)
					{
						salida=true;
						break;
					}
				}
			}

			return salida;
		}

       /// dada una cadena de entrada, dice si esta ya existe
       /// dentro del Array list que contiene todas las cadenas
       /// de la sección de configuración que representa el ligado
	   /// de componentes
	   private int DameIndiceDeEncontrado(string cadBus)
	   {
		   int salida=0;
		   int tam=this.cadsConf.Count;
		   for (int i = 0; i < tam; i++)
		   {
			   cadConfiguracion cadTempo=(cadConfiguracion)this.cadsConf[i];
			   string cadEnc=cadTempo.compoYProp;
			   if (cadEnc==cadBus)
			   {
				   salida=i;
				   break;
			   }
		   }
		   return salida;
	   }


       /// dada una estructura del tipo cadConfiguracion que tiene dos campos
       /// 1. "nombreComponente.PropiedadModificada."
       /// 2. "=ValorDado a la propiedad"
	   /// verifica si esta ya existe en el arreglo que contiene las cadenas
       /// de la sección de configuración. Si así es, entonces actualiza
	   /// si no, entonces la da de alta en el arreglo
		private void ActualizaListaCadenasConfiguracion(cadConfiguracion conf)
		{
			string cadBus=conf.compoYProp;
			bool existe=YaExisteCad(cadBus);

			if (existe)
			{
				int indice=DameIndiceDeEncontrado(cadBus);
				this.cadsConf[indice]=conf;
			}
			else
			{
				cadsConf.Add(conf);
			}
		}

	#endregion


        /// dados un ID de un frame y sy nombre, este metiodo regresa los cambios
        /// efectuados en las propiedades de los componentes que pernetencen a este
        /// frame. Esta información la obtiene del arrego "cadsConf" que es el contenedor
		/// universal de cambios en las propiedades de los componentens en un porject
		public string CadenasConfPropiedades(int idFrame, string nomFrame)
		{
			int tam=this.cadsConf.Count;
			string salida="";
			cadConfiguracion copia;

			if (tam>0)
			{
				for (int i = 0; i < tam; i++)
				{
					copia=(cadConfiguracion)this.cadsConf[i];
					int id=copia.iDFrame;
					string nom=copia.nombreFrame;
					if (id==idFrame && nom==nomFrame)
					{
					   salida=salida+"this."+copia.compoYProp+copia.valor+"\n";
					}

				}
			}

			return salida;

		}




#region Crea lista de componentes para opciones de propiedades
    


/// devuelve todos los componentes en la forma de diseño
private System.Windows.Forms.Control.ControlCollection DameControlesEnDiseno()
{
   BaseDinamica obj=(BaseDinamica)this.propertyGrid1.SelectedObject;
   Control miControl=obj.Parent;
   Disenno dis=(Disenno)miControl;
   return miControl.Controls;
}


/// Dice cuantas propiedades de tipo componente tiene un componente
private int CuantasPropHeredanBDContiene(object compo)
{
	PropertyDescriptorCollection props=TypeDescriptor.GetProperties(compo);
	int tam=props.Count;
	int salida=0;

	for (int i = 0; i < tam; i++)
	{
		PropertyDescriptor propi=props[i];
		string tipoCad=propi.PropertyType.ToString();
		Type tipo=propi.PropertyType;
		string nomProp=propi.PropertyType.Name;
		//string tipoCad=tipo.ToString();
		//MessageBox.Show("Prop. "+nomProp+". Tipo: "+tipoCad);
		bool heredaBD=paleta.HeredaDeBaseDinamica(tipo);
		if (heredaBD) salida=salida+1;
	}
	return salida;
}


/// Extrae el tipo de las propiedades contenidas en un compoennte
/// que hereden de Base Diinamica (es diferente clase base que tipo)
private string[] DameTiposPropHerednaBD(object compo, int detected)
{
	string[] salida=new string[detected];
	PropertyDescriptorCollection props=TypeDescriptor.GetProperties(compo);
	int tam=props.Count;
	int indice=-1;

	for (int i = 0; i < tam; i++)
	{
		PropertyDescriptor propi=props[i];
		Type tipo=propi.PropertyType;
		bool heredaBD=paleta.HeredaDeBaseDinamica(tipo);
		if (heredaBD)
		{
			indice=indice+1;
			salida[indice]=propi.PropertyType.ToString();
		}
	}
	return salida;
}


/// Extrae el nombre de las propiedades contenidas en un componente
/// que heredende BaseDinamica.
private string[] DameNombresPropHeredanBD(object compo, int detected)
{
	string[] salida=new string[detected];
	PropertyDescriptorCollection props=TypeDescriptor.GetProperties(compo);
	int tam=props.Count;
	int indice=-1;

	for (int i = 0; i < tam; i++)
	{
		PropertyDescriptor propi=props[i];
		Type tipo=propi.PropertyType;
		bool heredaBD=paleta.HeredaDeBaseDinamica(tipo);
		if (heredaBD)
		{
			indice=indice+1;
			salida[indice]=propi.Name;
		}
	}
	return salida;
}


/// Estrae todos los componentes contenidos en la forma de diseño
/// tales que sean de un tipo determinado
private BaseDinamica[] ComposDisenoCiertoTipo(Type tipoBuscado)
{

	ArrayList salida=new ArrayList();
	System.Windows.Forms.Control.ControlCollection controles=DameControlesEnDiseno();
	int tam=controles.Count;
	object tempo;
	BaseDinamica bdTempo=new BaseDinamica();

	for (int i = 0; i < tam; i++)
	{
		tempo=controles[i];
		Type tipo=tempo.GetType();
		string tipoBase=tipo.BaseType.ToString();



		bool heredaBD=paleta.HeredaDeBaseDinamica(tipo);
		if ((heredaBD && (tipo==tipoBuscado)) || tipo.IsSubclassOf(tipoBuscado))
		{
			bdTempo=(BaseDinamica)controles[i];
			salida.Add(bdTempo);
		}

	}

	tam=salida.Count;
	BaseDinamica[] salida2=new BaseDinamica[tam];
	for (int h = 0; h < tam; h++)
	{
		salida2[h]=(BaseDinamica)salida[h];
	}
	return salida2;
}


/// Dado un arreglo de componentes contenidos en un Array List
/// estrae solo los nombres. La salida de este método representa
/// las opciones para una propiedad determinada
private string[] DameNombresCompos(ArrayList listaCompos)
{
	int tam=listaCompos.Count;
	string[] salida=new string[tam];
	int indice=-1;
	BaseDinamica bdTempo=new BaseDinamica();

	for (int i = 0; i < tam; i++)
	{
		bdTempo=(BaseDinamica)listaCompos[i];
		string nombre=bdTempo.Nombre;
		indice=indice+1;
		salida[indice]=nombre;
	}
	return salida;
}

#endregion


	   private string ConvirtiendoTipos(object valorPropiedad)
	   {
		   string aux="";
		   Type tipo=valorPropiedad.GetType();
		   string tipoCad=tipo.ToString();

		   /// si es un arreglo de cadenas;
		   if (tipoCad.IndexOf("String[]")>-1)
		   {
			  string[] tempo=new string[0];
			  tempo=(string[])valorPropiedad;

			  int tam=tempo.Length;
			  aux="new string["+tam.ToString()+"]{";

			  for (int i = 0; i < tam; i++)
			  {
				  aux=aux+"\""+tempo[i]+"\"";
				  if (i<(tam-1))aux=aux+",";
			  }

			  aux=aux+"}";
		   }


		   /// si es una cadena
		   else if (tipoCad.IndexOf("String")>-1)
		   {
			  string tempo;
			  tempo=(string)valorPropiedad;
			  aux="\""+tempo+"\"";
		   }


           ///arreglo de dobles
		   else if (tipoCad.IndexOf("Double[]")>-1)
		   {
			   double[] tempoObj;
			   tempoObj=(double[])(valorPropiedad);

			   int tamObj=tempoObj.Length;
			   tipoCad=tipoCad.Replace("[]","");
			   aux="new " +tipoCad+"["+tamObj.ToString()+"]{";

			   for (int i = 0; i < tamObj; i++)
			   {
				   if (tipoCad.IndexOf("Bool")>-1)
					   aux=aux+tempoObj[i].ToString().ToLower();
				   else
				   aux=aux+tempoObj[i].ToString();

				   if (i<(tamObj-1))aux=aux+",";
			   }
			   aux=aux+"}";
		   }



           /// Si es un arreglo de BasesDinamica
		   else if (tipoCad.IndexOf("BaseDinamica[]")>-1)
           {
			   object[] tempoObj;
			   tempoObj=(object[])(valorPropiedad);
			   BaseDinamica tempBD=new BaseDinamica();

			   int tamObj=tempoObj.Length;

			   if (tipoCad.IndexOf("[]")>-1) tipoCad=tipoCad.Replace("[]","");


			   aux="new " +tipoCad+"["+tamObj.ToString()+"]{";

			   for (int i = 0; i < tamObj; i++)
			   {
				   if (tipoCad.IndexOf("Bool")>-1)
					   aux=aux+tempoObj[i].ToString().ToLower();
				   else
				   tempBD=(BaseDinamica)tempoObj[i];
				   aux=aux+tempBD.Nombre;

				   if (i<(tamObj-1))aux=aux+",";
			   }


			   aux=aux+"}";
           }	



		   /// Si es un arreglo de cualquier tipo
		   else if (tipoCad.IndexOf("[]")>-1)
		   {
			   object[] tempoObj;
			   tempoObj=(object[])(valorPropiedad);

			   int tamObj=tempoObj.Length;

			   if (tipoCad.IndexOf("[]")>-1) tipoCad=tipoCad.Replace("[]","");


			   aux="new " +tipoCad+"["+tamObj.ToString()+"]{";

			   for (int i = 0; i < tamObj; i++)
			   {
				   if (tipoCad.IndexOf("Bool")>-1)
					   aux=aux+tempoObj[i].ToString().ToLower();
				   else
				   aux=aux+tempoObj[i].ToString();

				   if (i<(tamObj-1))aux=aux+",";
			   }


			   aux=aux+"}";
		   }


		   else if (tipoCad.IndexOf("Color")>-1)
		   {
			   Color miColor=new Color();
			   miColor=(Color)valorPropiedad;

              aux="Color.FromArgb(255,"+miColor.R.ToString()+","+miColor.G.ToString()+","+miColor.B.ToString()+")";

           }
				


		   else if (tipoCad.IndexOf("Dock")>-1)
           {
               aux="System.Windows.Forms.DockStyle."+valorPropiedad.ToString();
		   }

		   else if (tipoCad.IndexOf("Point")>-1)
		   {
			  aux="new Point"+valorPropiedad.ToString();
			  aux=aux.Replace("{","(");
			  aux=aux.Replace("}",")");
			  aux=aux.Replace("X=","");
			  aux=aux.Replace("Y=","");
		   }

		   else if (tipoCad.IndexOf("Size")>-1)
           {
			   aux="new Size"+valorPropiedad.ToString();
               aux=aux.Replace("{","(");
			   aux=aux.Replace("}",")");
			   aux=aux.Replace("Width=","");
			   aux=aux.Replace("Height=","");
           }


		   // cualquier otro tipo que no sea arreglo
		   else
		   {
			   if (tipoCad.IndexOf("Bool")>-1) aux=valorPropiedad.ToString().ToLower();
			   else  aux=valorPropiedad.ToString();
		   }




		   return aux;
	   }



		///
		/// Cada vez que se selecciona un item en el inspector de propiedades se determina si la
		/// propiedad es de tipo base dinamica, Si así es entonces se crea la lista de los componentes
		/// en el frame de diseño de los que se pueden mostrar en esta propiedad como opciones para su
		/// valor
		private void propertyGrid1_SelectedGridItemChanged(object sender, System.Windows.Forms.SelectedGridItemChangedEventArgs e)
		{
			// tipo de propiedad seleccionada
			Type tipoProp=e.NewSelection.PropertyDescriptor.PropertyType;
			string tipc=tipoProp.ToString();


			string tipoPropCad=tipoProp.ToString();
			BaseDinamica[] todos=new BaseDinamica[0];

			// se busca en el frame de diseño todos los controles del tipo de la
			// propiedad que a sido seleccionada
			todos=ComposDisenoCiertoTipo(tipoProp);
			Dinamica.EdiPropDinamica.PonValor(todos);
			todos=new BaseDinamica[0];


		}


		///
		/// Este método hace el registro de los cambios hechos en las propiedades.
		/// En el caso de ser una propiedad de tipo BaseDinamica el registro del cambio tiene la forma:
		/// 	"NombreComponente.NombrePropiedad=NombreComponenteQueDaValorAPeopiedad;"
		///
		/// En el caso de que sea una propiedad de tipo Array el registro es de la sig Forma:
		///     "NombreComponente.NombrePorpiedad=new TipoArreglo[numeroComponentes]{elem1,elem2...elemn};"
		///
		/// En el caso de que sea una propiedad de cualquier otro tipo la lienea de registro es así:
		/// 	"NombreComponente.NombrePropiedad=Valor;"
		///
		private void propertyGrid1_PropertyValueChanged1(object s, System.Windows.Forms.PropertyValueChangedEventArgs e)
		{
			BaseDinamica compoSelecTemp=new BaseDinamica();
			Disenno FormSelected = new Disenno(null,null);
			string nomAnteriorForm="";
			int    idAnteriorForm=0;
			string nomCompoSelec="";
			string nomPadre="";
			int    idPadre=-1;
			string nomProp="";
			string valor="";
			object valorObj=new object();
			Type tipoObj;
			Disenno padre;
			bool her;
			Type tipoProp;
			string tipoPropCad="";
			string tipoObjCad="";



			// verifico si el componente seleccionado y del que se estan mostrando sus prop es BaseDonamica
			bool heredaCompoSelecBD=this.paleta.HeredaDeBaseDinamica(this.propertyGrid1.SelectedObject.GetType());
			Type tip= this.propertyGrid1.SelectedObject.GetType();
			bool hereda=paleta.HeredaDeBaseDinamica(tip);


			/// Si si hereda obtengo su nombre como una cadena
			if (hereda)
			{
				compoSelecTemp=(BaseDinamica)this.propertyGrid1.SelectedObject;
				nomCompoSelec=compoSelecTemp.Nombre;							// nombre del compo seleccionado
			}

			// si el seleccionado es la forma de diseño obtengo nombre y ID
			if (this.propertyGrid1.SelectedObject is Disenno)
			{
				compoSelecTemp=null;
				FormSelected = (Disenno)this.propertyGrid1.SelectedObject;
				nomAnteriorForm=FormSelected.Nombre;
				idAnteriorForm=FormSelected.ID;
				idPadre=FormSelected.ID;
				nomPadre=FormSelected.Nombre;
			}

			if (this.propertyGrid1.SelectedObject is TabPage)
			{
				TabPage laPagina=(TabPage)this.propertyGrid1.SelectedObject;
				object miObj=(object)laPagina.Parent.Parent;
				CompoTabControl elTab=(CompoTabControl)miObj;
				nomPadre=elTab.Name;
				idPadre=elTab.id;
			}

			/// SI ES CUALQUIER OTRO COMPONENTE QUE NO SEA UNA FORMA DE DISEÑO, ENTONCES
			/// OBTENGO DATOS DEL PADRE
		  if (!(this.propertyGrid1.SelectedObject is Disenno)&& !(this.propertyGrid1.SelectedObject is TabPage))
		  {
				/// Obtengo el padre del componente, ya sea forma de diseño o cualquier otro

				Component compoPapa=compoSelecTemp.Parent;
				string cadena=compoPapa.GetType().ToString();

				if (compoPapa is Disenno)
				{
				   padre=(Disenno)compoSelecTemp.Parent;
				   nomPadre=padre.Nombre;
				   idPadre=padre.ID;
				}

				else if (compoPapa is  CompoTabControl)
				{
				   ComponentesIDEdinamica.CompoTabControl tabPapa=(ComponentesIDEdinamica.CompoTabControl)compoSelecTemp.Parent;
				   nomPadre=tabPapa.Nombre;
				   idPadre=tabPapa.id;

                }
					 
				else
				{
					padre=(Disenno)(compoSelecTemp.Parent.Parent.Parent.Parent);
					nomPadre=padre.Nombre;
					idPadre=padre.ID;
				}
				/// Obtengo el nombre del padre

		   }


			///  DE LA PROPIEDAD QUE ESTA CAMBIANDO. OBTENGO:
			nomProp=e.ChangedItem.PropertyDescriptor.Name;	 // nombre prop. seleccionada
			valorObj=e.ChangedItem.Value;					 // valor dado a la prop
			tipoObj=valorObj.GetType();						 // tipo del valor dado a la prop
			string tipoObjStr=tipoObj.ToString();


			/// VERIFICO SI HEREDA DE BASEDINAMICA LA PROP, QUE ESTA CAMBIANDO
			her=this.paleta.HeredaDeBaseDinamica(tipoObj);
//			if (tipoObj==Dinamica.BaseDinamica[]) her=true;
			

			/// SI SI HEREDA, OBTENGO EL NOMBRE DEL COMPONENTE QUE LE DA VALOR A LA PROPIEDAD
			if (her==true)
			{
				BaseDinamica c2=new BaseDinamica();
				c2=(BaseDinamica)valorObj;
				valor=c2.Nombre;
			}

			/// SI NO HEREDA QUIERE DECIR QUE ES EL VALOR DE LA PROPIEDAD NO ES UN COMPONENTE
			/// POR LO QUE TOMO TODOS LOS DATOS DEL VALOR DE LA PROPIEDAD
			if (her==false)
			{

			   // PROPIEDAD
			   nomProp=e.ChangedItem.PropertyDescriptor.Name;             // nombre de la propiedad
			   tipoProp=e.ChangedItem.PropertyDescriptor.PropertyType;    // tipo de la propiedad
			   tipoPropCad=tipoProp.ToString();

			   // VALOR DE LA PROPIEDAD
			   valorObj=e.ChangedItem.Value;            				  // valor de la propiedad
			   tipoObj=valorObj.GetType();                                // tipo de la propiedad
			   tipoObjCad=tipoObj.ToString();


			   /// SI EL TIPO DEL VALOR DE LA PROPIEDAD ES IGUAL AL TIPO DE LA PROPIEDAD
			   if (tipoPropCad==tipoObjCad)
			   {
				   /// TRANSFORMO SU VALOR A UNA CADENA PARA LLENAR EL ARCHIVO DE COMPILACIÓN
				   if (compoSelecTemp != null)
				   valor=ConvirtiendoTipos(TypeDescriptor.GetProperties(compoSelecTemp)[nomProp].GetValue(compoSelecTemp));
				   if (compoSelecTemp== null)
				   valor=ConvirtiendoTipos(TypeDescriptor.GetProperties(FormSelected)[nomProp].GetValue(FormSelected));

			   }

			}

			/// AI LA PROPIEDAD QUE ESTÁ CAMBIANDO ES EL NOMBRE DE UNA FORMA DE DISEÑO
			/// ENTONCES SE EACTUALIZA EL NUEVO NOMBRE EN LA RELACIÓN COMPLETA DE CAMBIOS DE PROPIEDADES
			 if ((this.propertyGrid1.SelectedObject is Disenno) && (nomProp=="Nombre"))
			 {
				   valor=valor.Replace("\"","");
				   this.paleta.CambiaNombreFrame(idAnteriorForm,nomAnteriorForm,valor);
			 }


			TabPage miTabTempo;
			if (heredaCompoSelecBD==false)
			{
			   string tipo=this.propertyGrid1.SelectedObject.GetType().ToString();
			   if (this.propertyGrid1.SelectedObject is TabPage)
			   {

					miTabTempo=(TabPage)this.propertyGrid1.SelectedObject;
					nomCompoSelec=miTabTempo.Name;

					padre=(Disenno)(miTabTempo.Parent.Parent.Parent);
					nomPadre=padre.Nombre;											// nombre de la forma padre;
					idPadre=padre.ID;

					// LA PROPIEDAD QUE CAMBIA
					nomProp=e.ChangedItem.PropertyDescriptor.Name;					// nombre prop. seleccionada
					valorObj=e.ChangedItem.Value;									// valor dado a la prop
					tipoObj=valorObj.GetType();

					her=this.paleta.HeredaDeBaseDinamica(tipoObj);					// tipo del valor dado a la prop

					if (her==true)
					{
						BaseDinamica c2=new BaseDinamica();
						c2=(BaseDinamica)valorObj;
						valor=c2.Nombre;
					}


				if (her==false)
				{
				   // NOMBRE COMPO
				   miTabTempo=(TabPage)this.propertyGrid1.SelectedObject;
				   nomCompoSelec=miTabTempo.Name;

				   // PROPIEDAD QUE CAMBIA
				   nomProp=e.ChangedItem.PropertyDescriptor.Name;
				   tipoProp=e.ChangedItem.PropertyDescriptor.PropertyType;
				   tipoPropCad=tipoProp.ToString();

				   // VALOR DE LA PROPIEDAD  QUE CAMBIA
				   valorObj=e.ChangedItem.Value;
				   tipoObj=valorObj.GetType();
				   tipoObjCad=tipoObj.ToString();

				   if (tipoPropCad==tipoObjCad)
				   {
					   valor=ConvirtiendoTipos(e.ChangedItem.Value/*TypeDescriptor.GetProperties(compoSelecTemp)[nomProp].GetValue(compoSelecTemp)*/);
				   }

				}



			   }

			}

			//////////////////////////////////////////////
			/// esta parte trabaja para propiedades de tipo baseDinamoca
			/// hay que hacer que trabaje para cualquier propiedad

			cadConfiguracion conf1;
			conf1.compoYProp=nomCompoSelec+"."+nomProp;  // "ComponenteSeleccionado.Propiedad"
			conf1.valor="="+valor+";";					 // "=ValorPropiedad;"
			conf1.iDFrame=idPadre;
			conf1.nombreFrame=nomPadre;

			if (nomCompoSelec!="" && nomProp!="" && valor!="")
			{
			   ActualizaListaCadenasConfiguracion(conf1);
			}

			// SI LA PROPIEDAD QUE CAMBIA ES EL NOMBRE DE UN COMPONENTE
			// SE ACUTALIZA ESTE NOMBRE EN EL CONTROL DE CAMBIOS DE PROPIEDADES
			if (hereda && nomProp=="Nombre")
			{
//				bool exis=YaExisteCad(compoSelecTemp.Name+"."+nomProp);
				valor=valor.Replace("\"","");
				this.paleta.CambiaNombreComponente(conf1.iDFrame,compoSelecTemp.Name,valor);
				compoSelecTemp.Name=valor;
			}


		}






		
		private void checkBox1_Click(object sender, System.EventArgs e)
		{

			if (this.checkBox1.Checked== true)
			{
				Attribute myfilterattribute = new CategoryAttribute("Appearance");
				Attribute filtro = new CategoryAttribute("Misc");
				this.propertyGrid1.BrowsableAttributes = new  AttributeCollection(new Attribute[] { filtro });
			}
			else
			{
				this.propertyGrid1.BrowsableAttributes=null;
            }
		}
		


		private void listaMetodos_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.Editor.Viendose==true)
			{
				if (this.MetodoEnviado!=null)
				{
					string mensaje=this.listaMetodos.SelectedItems[0].ToString();
					EnviaMetodoEventArgs me=new Dinamica.Eventos.EnviaMetodoEventArgs(mensaje);
					MetodoEnviado(this,me);

				}
            }
		}
		

	}
}
