using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using ComponentesIDEdinamica;
using RectTrackerSharp;
using Dinamica;
using Dinamica.Eventos;

namespace Carga_Dlls_Dinam
{

	public class Disenno : System.Windows.Forms.Form
	{



		///componente para manipulación de los componentes en la forma de diseño
		public Marco marco;
		private Paleta paleta;
		private Inspector inspector;
		public  Advertencia advertencia;
		private System.Windows.Forms.Control.ControlCollection componentesEnDisenno;

		private System.ComponentModel.Container components = null;


		/// evento que manda como argumentos el componente sobre el que se hizo
		/// click a el inspector de propiedades

		public  event EnviaObjetoEventHandler EnviaObjeto;

		///posición del raton sobre la forma de diseño
		int xRaton=0;
		int yRaton=0;

		// entero para generar el ID de los componentes
		public int ids=0;

		/// variabel asociada a la propiedad Nombre
		private string nombre;

		/// variable asociada a la propiedad ID
		private int id=1;
//		private bool contieneMenu=false;


		/////////////////////
		/// propiedades
		/////////////////////

//		public bool ContieneMenu
//		{
//			get
//			{
//				contieneMenu=this.DimeSiExisteMenuPPal();
//				return contieneMenu;
//			}
//			set
//			{
//
//			}
//		}



		public string Nombre
		{
			get
			{
				return nombre;
			}
			set
			{
				nombre=value;
			}
		}


		public int ID
		{
			get
			{
				return id;
			}
			set
			{
				id=value;
			}

		}

		public System.Windows.Forms.Control.ControlCollection ComponentesEnDiseno
		{
			get
			{
				componentesEnDisenno=this.Controls;
				return componentesEnDisenno;
			}

		}



//		public MenuPrin DameMenuPrincipal()
//		{
//			MenuPrin salida=null;
//			System.Windows.Forms.Control.ControlCollection compos=this.Controls;
//			int tam=compos.Count;
//			for (int i = 0; i < tam; i++)
//			{
//				Control contri=compos[i];
//				if (contri is MenuPrin)
//				{
//				   salida=(MenuPrin)contri;
//				   break;
//				}
//			}
//			return salida;
//		}
//
//
//		public bool DimeSiExisteMenuPPal()
//		{
//			bool salida=false;
//			MenuPrin men=this.DameMenuPrincipal();
//			if (men==null) salida=false;
//			if (men!=null) salida=true;
//			
//			return salida;
//        }


		public void PonEnDisenio(bool valor)
		{
			System.Windows.Forms.Control.ControlCollection compos=this.Controls;
			int tam=compos.Count;

			for (int i = 0; i < tam; i++)
			{
				Control contri=compos[i];
				Type tipi=contri.GetType();
				bool esBase=this.paleta.HeredaDeBaseDinamica(tipi);
				if (esBase==true)
				{
					BaseDinamica baseD=(BaseDinamica)contri;
					baseD.PonEnDisenio(valor);
				}
			}
		}










		public Disenno(Paleta paleta, Inspector inspector)
		{
			this.Nombre="Forma1";
			this.paleta=paleta;
			this.inspector=inspector;
			this.advertencia=new Advertencia(this.paleta,this);


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
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(662, 450);
			this.Location = new System.Drawing.Point(420, 250);
			this.Name = "Disenno";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Forma de Diseño";
			this.Click += new System.EventHandler(this.Disenno_Click);
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Disenno_Closing);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Disenno_MouseMove);
		}
		#endregion


		/// ME DICE SI EL NOMBRE DE UN COMPONENTE SE ENCUENTRA EL LA ESTRUCTURA
        /// DE CONTROL QUE GUARDA LOS CAMBIOS HECHOS DE PROPIEDADES DESDE EL
		/// INSPECTOR
		public int IndNomEncontrado(string nombreBuscado)
		{
			int tam=this.inspector.cadsConf.Count;
			cadConfiguracion miCad;
			string nomGuardado="";
			int salida=0;

			for (int i = 0; i < tam; i++)
			{
			   miCad=(cadConfiguracion)this.inspector.cadsConf[i];
			   nomGuardado=miCad.compoYProp;
			   int inx=nomGuardado.IndexOf(nombreBuscado);
			   if (inx>-1)
			   {
				   salida=i;
				   break;
			   }
			}
			return salida;
		}

        /// BORRA UN REGSITRO DE CAMBIOS DE LAS PROPIEDADES DE UN COMPONENTE
        /// DE LA ESTRUCTURA DE CONTROL DONDE SE ALMACENAN LOS CAMBIOS
		/// HECHOS MEDIANTE EL INSPECTOR
		public void BorraRegistro(int indiceRegistro)
		{
			cadConfiguracion cadConf=(cadConfiguracion)this.inspector.cadsConf[indiceRegistro];
			this.inspector.cadsConf.Remove(cadConf);
		}




		/// Una vez que el usuario da click a un componente este preserva el focus
		/// y si se oprime la tecla "suprimir" entonces se borra el componente
		public void TeclaOprimida(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			Dinamica.BaseDinamica objeto=new Dinamica.BaseDinamica();

			if (sender is Dinamica.BaseDinamica)
			{
				/// CAPTURO EL OBJETO QUE SE HA DE BORRAR
				if (this.inspector.propertyGrid1.SelectedObject is Dinamica.BaseDinamica)
				{
					objeto=(Dinamica.BaseDinamica)this.inspector.propertyGrid1.SelectedObject;
					objeto.BringToFront();
					objeto.Capture=false;
                    string papa=objeto.Parent.GetType().ToString();

					/// BORRO TODO REGISTRO DEL COMPONENTE BORRADO
					string nombre=objeto.Nombre;
					int tami=this.inspector.cadsConf.Count;
					int idi=-1;

					for (int i = 0; i < tami; i++)
					{
						 idi=-1;
						 idi=this.IndNomEncontrado(nombre);
						 if (idi>-1) this.BorraRegistro(idi);
					}

					/// BORRO EL COMPONENTE
					if (/*(this.Controls.Contains(marco))&&*/(e.KeyCode.ToString()=="Delete"))
					{
						this.EliminaMarcos(objeto);
						this.Controls.Remove(marco);
						this.Controls.Remove(objeto);
					}

					if (objeto.Parent is TabPage)
					{
						TabPage papa2=(TabPage)objeto.Parent;
						papa2.Controls.Remove(objeto);
						papa2.Controls.Remove(marco);
                    }
					
				}
			}
		}

        private void BorraTodosMarcosTabControl(Control miControl)
	   {
			if (miControl is TabPage)
			{
				// nivel pagina
				TabPage laPag=(TabPage)miControl;
				do
				{
					if (laPag.Controls.Contains(marco))
						laPag.Controls.Remove(marco);
				}
				while(laPag.Controls.Contains(marco));

				// nivel tabControl
				TabControl elPapa=(TabControl)laPag.Parent;
				System.Windows.Forms.TabControl.TabPageCollection paginas=elPapa.TabPages;
				int tam=paginas.Count;
				for (int i = 0; i < tam; i++)
				{
					TabPage pag2=paginas[i];
					do
                    {
						if (pag2.Controls.Contains(marco))
							pag2.Controls.Remove(marco);
					}
					while (pag2.Controls.Contains(marco));

				}



				// nivel CompoTabControl
				CompoTabControl elPapa2=(CompoTabControl)elPapa.Parent;
				do
				{
				   if (elPapa2.Controls.Contains(marco))
					   elPapa2.Controls.Remove(marco);

				}
				while (elPapa2.Controls.Contains(marco));
			}


	   }

	   public void CambiaEnabeled(object sender, System.EventArgs e)
       {
		   Dinamica.BaseDinamica objeto=new Dinamica.BaseDinamica();
		   if (sender is Dinamica.BaseDinamica)
		   {
			   objeto=(Dinamica.BaseDinamica)sender;
			   if (objeto.EstaEnDisenio()) objeto.Enabled=true;
		   }
	   }

		/// cuando se hace click sobre un componente que está en la forma de diseño
		/// este mismo se envia como argumento en el evento "Objeto enviado" para que
		/// el inspector de propiedades actualice muestre pripiedades y eventos de este
		/// componente
		public void ClickSobreComponente(object sender, System.EventArgs e)
		{
			Dinamica.BaseDinamica objeto=new Dinamica.BaseDinamica();
			EventInfo[] metodos;

			if (sender is Dinamica.BaseDinamica)
			{
				 objeto=(Dinamica.BaseDinamica)sender;

				if (objeto.Parent is TabPage)
                {
                    this.BorraTodosMarcosTabControl(objeto.Parent);
				}

                this.EliminaMarcos(this);

				 objeto.BringToFront();
				 objeto.Capture=false;
				 //if (objeto.Parent.Controls.Contains(marco))
				 objeto.Parent.Controls.Remove(marco);
				 marco=new Marco((System.Windows.Forms.Control)objeto);
				 marco.Dimensionar=objeto.EsDimensionable();
				 objeto.Parent.Controls.Add(marco);

				 marco.BringToFront();
				 marco.Draw();
				 objeto.Refresh();
				 objeto.Focus();

				 metodos=objeto.DameEventos();

				 int len=metodos.Length;
				 string[] cad=new string[len];

				 for (int i = 0; i < len; i++)
				 {
					cad[i]=metodos[i].ToString();
				 }


				 string tp=objeto.DameTipo().ToString();

				 if (tp.IndexOf("CompoTabControl")>-1)
				 {
					 CompoTabControl miTab=(CompoTabControl)objeto;

                 }

				 EventInfo[] eventos=objeto.DameEventos();

				 if (EnviaObjeto != null)
				 {
					 string[] lv=new string[0];
					 Dinamica.Eventos.ObjetoEventArgs ObjetoEnviado = new Dinamica.Eventos.ObjetoEventArgs(sender,cad,eventos,objeto.id,tp,this.ID,lv);
					 EnviaObjeto(this,ObjetoEnviado);
				 }


			}


		}



		/// cada vez que se mueve el raton se actualiza su posición en estas variables
		private void Disenno_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			xRaton=e.X;
			yRaton=e.Y;
		}



	   /// yo quiero saber el tipo de donde hereda un componente que recide en una dll
	   /// yo se el tipo de este componente como cadena y donde se alberga
	   /// así que abro la dll, saco el tipo (tipo Type) y a este le obtengo el tipoBase
	   /// que es lo que regreso;
	   private Type DameElTipoBase(string dllOrigen, string instancia)
	   {
		   Type salida=null;
		   Assembly assem=Assembly.LoadFile(dllOrigen);
		   Type[] tipos=assem.GetTypes();

		   string tipoBaseCad="";
		   int tam=tipos.Length;

		   for (int i = 0; i < tam; i++)
		   {
			   tipoBaseCad=tipos[i].ToString();
			   if (tipoBaseCad==instancia)
			   {
				  salida=tipos[i];
				  break;
			   }
		   }

		   salida=salida.BaseType;

		   return salida;
	   }










	   public void ClickSobreTabPage(object o,System.EventArgs e)
	   {
		   string copia=Paleta.aCrear;

		   string[] cad=new string[0];
		   EventInfo[] eventos=new EventInfo[0];
		   int id=1;
		   string tp="";


		   if (EnviaObjeto != null)
		   {
			 string[] lv=new string[0];
			 ObjetoEventArgs ObjetoEnviado = new ObjetoEventArgs(o,cad,eventos,id,tp,this.ID,lv);
			 EnviaObjeto(this,ObjetoEnviado);
		   }

		   this.EliminaMarcos(this);

		   if (copia!="")
		   {
				Assembly assem;
				System.IO.Directory.SetCurrentDirectory(paleta.directorio);
				string d=paleta.directorio;
				string dd=Paleta.dllOrigen;
				assem=Assembly.LoadFile(Paleta.dllOrigen);

				Dinamica.BaseDinamica objeto=new Dinamica.BaseDinamica();

				copia=Paleta.aCrear;

				ids=ids+1;
				string ac=Paleta.aCrear;

				try
				{
				objeto= (Dinamica.BaseDinamica)assem.CreateInstance(Paleta.aCrear);
				objeto.Left=xRaton;
				objeto.Top=yRaton;
				objeto.BringToFront();
				objeto.Capture=false;
				objeto.id=ids;


				string cadenita=objeto.DameTipo().ToString();

				int posi=cadenita.LastIndexOf(".");
				cadenita=cadenita.Substring(posi+1);
				objeto.Nombre=cadenita+ids;
				objeto.Refresh();

				string tipo=o.GetType().ToString();

				TabPage pagina=(TabPage)o;
				pagina.Controls.Add(objeto);
				objeto.Click += new System.EventHandler(ClickSobreComponente);
				objeto.KeyDown += new System.Windows.Forms.KeyEventHandler(TeclaOprimida);

				marco=new Marco((System.Windows.Forms.Control)objeto);
				marco.Dimensionar=true;/*objeto.Dimensionable;*/



				pagina.Controls.Add(marco);
				marco.BringToFront();
				marco.Draw();
				Paleta.aCrear="";
				}
				catch   (TargetInvocationException fe)
				{
					 MessageBox.Show(fe+"\n"+fe.StackTrace);
				}

		   }
	   }



	   private void RatonSobrePagina(object sender, System.Windows.Forms.MouseEventArgs e)
	   {
		   xRaton=e.X;
		   yRaton=e.Y;
       }



	   public void CambiaTextoTabPage(object o,System.EventArgs e)
	   {
		   if (o is TabPage)
		   {
			  TabPage miPag=(TabPage)o;
              miPag.Text=((TabPage)o).Text;
//			  MessageBox.Show("Cabió mi nombre "+miPag.Text);
		   }
	   }

	   public void RecibeSolicitudNewPagTab(object o, NuevaPaginaTabEventArgs npea)
	   {
		   TabPage pagina=new TabPage();
		   pagina.Click+=new System.EventHandler(ClickSobreTabPage);
		   pagina.TextChanged+= new System.EventHandler(CambiaTextoTabPage);
		   pagina.MouseMove+= new System.Windows.Forms.MouseEventHandler(RatonSobrePagina);
		   ids=ids+1;
		   TabControl elTab=npea.padre;
		   elTab.TabPages.Add(pagina);
		   pagina.Name="Pagina"+elTab.TabCount.ToString();
		   pagina.Text=pagina.Name;
	   }



		/// cuando se hace clic sobre la forma de diseño, se construye el control que se
		/// ha seleccionado de la paleta de componentes en la posición donde se hixo clic
		public void Disenno_Click(object sender, System.EventArgs e)
		{

		   string cadenita="";
		   int    posi=0;

		  if (Paleta.aCrear =="")
		  {
			  string[] cad=new string[0];
			  EventInfo[] eventos=new EventInfo[0];
			  int id=1;
			  string tp="";

			  if (EnviaObjeto != null)
			  {
				  string[] lv=new string[0];
				   ObjetoEventArgs ObjetoEnviado = new ObjetoEventArgs(sender,cad,eventos,id,tp,this.ID,lv);
				   EnviaObjeto(this,ObjetoEnviado);
			  }
		  }


		  this.EliminaMarcos(this);

		   if (Paleta.aCrear!="")
		   {
				Assembly assem;
				assem=Assembly.LoadFile(Paleta.dllOrigen);
				Dinamica.BaseDinamica objeto=new Dinamica.BaseDinamica();

				string copia=Paleta.aCrear;

				ids=ids+1;
				string ac=Paleta.aCrear;

				try
				{
				objeto= (Dinamica.BaseDinamica)assem.CreateInstance(Paleta.aCrear);
				objeto.Left=xRaton;
				objeto.Top=yRaton;
				objeto.BringToFront();
				objeto.Capture=false;
				objeto.id=ids;
				objeto.PonEnDisenio(true);



				cadenita=objeto.DameTipo().ToString();

				if (cadenita.IndexOf("CompoTabControl")>-1)
				{
					CompoTabControl miTab=(CompoTabControl)objeto;
					miTab.NuevaPagina += new Dinamica.Eventos.NuevaPaginaTabEventHandler(RecibeSolicitudNewPagTab);
				}


				posi=cadenita.LastIndexOf(".");
				cadenita=cadenita.Substring(posi+1);
				objeto.Nombre=cadenita+ids;
				objeto.id=ids;
				objeto.Name=objeto.Nombre;
				objeto.Refresh();

				this.Controls.Add(objeto);
				objeto.Click += new System.EventHandler(ClickSobreComponente);
				objeto.EnabledChanged += new System.EventHandler(CambiaEnabeled);
				objeto.KeyDown += new System.Windows.Forms.KeyEventHandler(TeclaOprimida);


				if (this.Controls.Contains(marco))
					this.Controls.Remove(marco);
				marco=new Marco((System.Windows.Forms.Control)objeto);
				marco.Dimensionar=objeto.EsDimensionable();

				this.Controls.Add(marco);
				marco.BringToFront();
				marco.Draw();
				Paleta.aCrear="";
				}
				catch   (TargetInvocationException fe)
				{
					 MessageBox.Show(fe+"\n"+fe.StackTrace);
				}

				string[] cad=new string[0];
				EventInfo[] eventos=new EventInfo[0];
				int id=1;
				string tp="";

				if (EnviaObjeto != null)
				{
					string[] lv=new string[0];
					ObjetoEventArgs ObjetoEnviado = new ObjetoEventArgs(objeto,cad,eventos,id,tp,this.ID,lv);
					EnviaObjeto(this,ObjetoEnviado);
		   		}





		   }








		}


#region Administrador Objetos en forma de diseño
/// Regresa todas las propiedades de un componente
private PropertyDescriptorCollection DamePropiedadesCompo(object componente)
{
return TypeDescriptor.GetProperties(componente);
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
private ArrayList ComposDisenoCiertoTipo(string tipoBuscado)
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
		string tipoC=tempo.GetType().ToString();
		bool heredaBD=paleta.HeredaDeBaseDinamica(tipo);
		if (heredaBD && (tipoC==tipoBuscado))
		{
			bdTempo=(BaseDinamica)controles[i];
			salida.Add(bdTempo);
		}

	}
	return salida;
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



//private void PonOpYRefDeProp(Object compo)
//{
//	int noProCompo=CuantasPropHeredanBDContiene(compo);
//	string[] tiposDePropCad = new string[noProCompo];
//	tiposDePropCad=DameTiposPropHerednaBD(compo,noProCompo);
//	string[] nomDeProp= new string[noProCompo];
//	nomDeProp=DameNombresPropHeredanBD(compo,noProCompo);
//
//	for (int i = 0; i < noProCompo; i++)
//	{
//		ArrayList compos=new ArrayList();
//		compos=ComposDisenoCiertoTipo(tiposDePropCad[i]);
//		int noCompos=compos.Count;
//		string[] opciones=new string[noCompos];
//		opciones=DameNombresCompos(compos);
//
//		if (noCompos>0)
//		{
//			Type tipoOrig=compo.GetType();
//			bool origHeredaBD=paleta.HeredaDeBaseDinamica(tipoOrig);
//			if (origHeredaBD)
//			{
//			   BaseDinamica miCompo=new BaseDinamica();
//			   miCompo=(BaseDinamica)compo;
//               // los itreadores no estan definidos con estas propiedaes
//			   string nim=miCompo.Nombre;
//			   if (nim.IndexOf("Iterador")==-1)
//			   {
//				   PropertyDescriptorCollection propis=TypeDescriptor.GetProperties(miCompo);
//				   PropertyDescriptor propOpciones=propis.Find("Opciones"+nomDeProp[i],false);
//
//
//				   int tam=att.Count;
//				   string[] nombresAtt=new string[tam];
//				   string cadena="";
//
//				   for (int d = 0; d < tam; d++)
//				   {
//					   Attribute ati= att[i];
//					   nombresAtt[i]=ati.ToString();
//					   cadena=cadena+nombresAtt[i]+"\n";
//				   }
//
//
//
//
//
////                   UITypeEditor
//                   
//				   TypeConverter conv=propOpciones.Converter;
//				   string convC=conv.GetType().ToString();
//				   propOpciones.SetValue(miCompo,opciones);
//
//				   propOpciones=propis.Find("Referencia"+nomDeProp[i],false);
//                   propOpciones.SetValue(miCompo,compos);
//			   }
//
//			}
//        }
//	}

//}







/// devuelve todos los componentes en la forma de diseño
private System.Windows.Forms.Control.ControlCollection DameControlesEnDiseno()
{
	return this.Controls;
}


/// pasa el controlCollection donde estan contenidos todos los componentes
/// en la forma de diseño a un ArrayList
private ArrayList PasaControlCollection_ArrayList(System.Windows.Forms.Control.ControlCollection coleccion)
{
	int tam=coleccion.Count;
	ArrayList salida=new ArrayList();
	for (int i = 0; i < tam; i++)
	{
		salida.Add(coleccion[i]);
	}
	return salida;
}




/// verifica si un componente dado (que entra como object) tiene una
/// propiedad determinada, la cual entra como argumento como cadena
private bool TieneCiertaPropiedad(string propBuscada, object componente)
{
	PropertyDescriptorCollection props=DamePropiedadesCompo(componente);
	int tam=props.Count;
	string nombreProp;
	bool salida=false;

	for (int i = 0; i < tam; i++)
	{
		PropertyDescriptor propiedad=props[i];
		nombreProp=propiedad.Name;
		if (propBuscada==nombreProp)
		{
			salida=true;
			break;
		}
	}
	return salida;

}

private void PonOpcionesPropiedad(string propBuscada, string[] opciones, int indice)
{
	PropertyDescriptorCollection props=DamePropiedadesCompo(this.Controls[indice]);

	int tam=props.Count;
	string nombreProp;

	for (int i = 0; i < tam; i++)
	{
		PropertyDescriptor propiedad=props[i];
		nombreProp=propiedad.Name;
		if (propBuscada==nombreProp)
		{
			int indix=TypeDescriptor.GetProperties(this.Controls[indice]).IndexOf(propiedad);
			TypeDescriptor.GetProperties(this.Controls[indice])[indix].SetValue(this.Controls[indice],opciones);
			propiedad.SetValue(this.Controls[indice],opciones);
		}
	}

}


/// Determina si cierto componente es de un tipo determinado
private bool EsDeCiertoTipo(string tipoBus, object componente)
{
	bool salida=false;
	string tipo=componente.GetType().ToString();
	int indice =tipo.IndexOf(tipoBus);
	if (indice!=-1) salida=true;
	return salida;
}


/// En este método entra un tipo de propiedad determinado como cadena
/// esta propiedad debe ser un componente. Es decir, pretendo que para
/// aquellos componentes que tengan propiedades de tipo objeto, se  haga
/// una lista (string[]) que contenga todos los controles contenidos
/// en la forma de diseño que sean del tipo de la propiedad de tipo control
/// de otros componentes.
private string[] DameListaOpciones(string tipoPropiedad)
{
	 System.Windows.Forms.Control.ControlCollection todosControles=DameControlesEnDiseno();
	 ArrayList compos=PasaControlCollection_ArrayList(todosControles);
	 ArrayList control=new ArrayList();
	 ArrayList indicesDeControl=new ArrayList();

	 int tam=compos.Count;
	 bool tienePropBuscada;
	 bool esBaseDinamica;
	 Type tipoControl;

	 for (int i = 0; i < tam; i++)
	 {
		 tienePropBuscada=TieneCiertaPropiedad(tipoPropiedad,compos[i]);
		 tipoControl=compos[i].GetType();
		 esBaseDinamica=this.paleta.HeredaDeBaseDinamica(tipoControl);
		 if (tienePropBuscada && esBaseDinamica)
		 {
			control.Add(compos[i]);
			indicesDeControl.Add(i);
		 }

	 }

	 tam=control.Count;
	 string[] salida=new string[tam];
	 for (int i = 0; i < tam; i++)
	 {
		 BaseDinamica tempo=new BaseDinamica();
		 tempo=(Dinamica.BaseDinamica)control[i];
		 salida[i]=tempo.Nombre;
	 }


//	 tam=indicesDeControl.Count;
//	 for (int j = 0; j < tam; j++)
//	 {
//		 PonOpcionesPropiedad(tipoPropiedad,salida,this.Controls[(int)indicesDeControl[j]]);
//     }

	 return salida;
}

#endregion
		

		private void Disenno_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			 DialogResult resp;
			 resp= MessageBox.Show("¿Desea remover esta forma del proyecto actual?", "Advertencia",MessageBoxButtons.YesNo);
			 if (resp==DialogResult.Yes)
			 {
                this.paleta.BorraFormaDisenno(this.id,this.nombre);
			 }
			 if (resp==DialogResult.No)
			 {
                 e.Cancel=true; 
             }
		}

		private void EliminaMarcos(Control ctrl)
		{
		 if(ctrl == null)
		   return;

		 if(ctrl.GetType() == typeof(Marco))
         {
		   ctrl.Parent.Controls.Remove(ctrl);
		   return;
		 }
		 foreach(Control c in ctrl.Controls)
           EliminaMarcos(c);
        }


		

	}
}
