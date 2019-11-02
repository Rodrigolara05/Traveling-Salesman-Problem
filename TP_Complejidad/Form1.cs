using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.IO;
using Newtonsoft.Json;
using GeoJSON.Net.Geometry;
using System.Diagnostics;
using GeoJSON.Net.Feature;
using System.Globalization;

namespace TP_Complejidad
{
    public partial class Form1 : Form
    {
        ArrCoordenadas objArrCoordenadas = new ArrCoordenadas();
        List<PointLatLng> lista;

        //Lista de puntos de mi clase
        List<Coordenadas> lstCoordenadas = new List<Coordenadas>();
        string UNO_CERO = "";
        List<double> LON = new List<double>();
        List<double> LAT = new List<double>();

        GMarkerGoogle marker;
        GMapOverlay markerOverlay;
        DataTable dt;
        double x = -77.0282400;//Longitud
        double y = -12.0431800;//Latitud

        public Form1()
        {
            InitializeComponent();
        }
        List<PointLatLng> leer_capitales(string numero)
        {
            StreamReader file = new StreamReader(@"Centros_Poblados.json");
            string content = file.ReadToEnd();
            file.Close();

            dynamic deserialized = JsonConvert.DeserializeObject(content);
            short cont = 0;
            int cont2 = 0;
            double X = 0;
            double Y = 0;
            string nombre = "";
            string s = "";
            //Lista de puntos para poder dibujar
            List<PointLatLng> lstPuntos = new List<PointLatLng>();
            PointLatLng puntos;
           
            bool validador=false;
            foreach (var item in deserialized.features)
            {
                cont = 0;
                X = 0;
                Y = 0;
                validador = false;

                foreach (var i in item.properties)
                {
                    foreach (var j in i)
                    {
                        if (cont == 0)
                        {
                            nombre = j;
                        }
                        if (cont == 7) //Si le toca a capitales
                        {
                            if (j == numero) //Si es capital
                            {
                                validador = true;
                            }
                        }
                        if (validador == true)
                        {
                           
                            if (cont == 15)
                            {
                                X = j;
                            }
                            if (cont == 16)
                            {
                                Y = j;
                            }
                        }
                        cont++;

                    }
                }
                if (X != 0)
                {
                    //Añadir a la lista existente
                    puntos = new PointLatLng(Y, X);
                    lstPuntos.Add(puntos);
                    objArrCoordenadas.agregar(X, Y, nombre);
                    //Marcador
                    s = "";
                    s += "Marcador " + cont2;
                    markerOverlay = new GMapOverlay(s);
                    marker = new GMarkerGoogle(new PointLatLng(Y, X), GMarkerGoogleType.red_small);
                    markerOverlay.Markers.Add(marker);
                    //Agregar el overlay en el mapa
                    gMapControl1.Overlays.Add(markerOverlay);
                }
            }
            return lstPuntos;
        }
      
        static NumberFormatInfo ni = null;
        private void leer_Lista()
        {

            PointLatLng nuevo;
            int cont = 0;
            decimal x, y;
            CultureInfo ci = CultureInfo.InstalledUICulture;
            ni = (NumberFormatInfo)ci.NumberFormat.Clone();
            ni.NumberDecimalSeparator = ".";
            try
            {
                using (StreamReader sr = new StreamReader("Ciudades.txt", false))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (cont % 2 == 0)
                        {
                            LON.Add(double.Parse(line,ni));
                        }
                        else
                        {
                            LAT.Add(Convert.ToDouble(line, ni));
                        }
                        cont++;
                        
                    }
                }
            }
            catch (Exception)
            {
                //Console.WriteLine("El archivo no se puede leer");
            }
        }
        List<PointLatLng> leer_CEducativos_distrito(string nombre_parametro) //Surco
        {
            StreamReader file = new StreamReader(@"Centros_Educativos.json");
            string content = file.ReadToEnd();
            file.Close();

            dynamic deserialized = JsonConvert.DeserializeObject(content);
            short cont = 0;
            int cont2 = 0;
            double X = 0;
            double Y = 0;
            string nombre = "";
            string s = "";
            //Lista de puntos para poder dibujar
            List<PointLatLng> lstPuntos = new List<PointLatLng>();
            PointLatLng puntos;

            bool validador = false;
            foreach (var item in deserialized.features)
            {
                cont = 0;
                X = 0;
                Y = 0;
                validador = false;

                foreach (var i in item.properties)
                {
                    foreach (var j in i)
                    {
                        if (cont == 2)
                        {
                            nombre = j;
                        }
                        if (cont == 20) //NOMCPSIG
                        {
                            if (j == nombre_parametro) //Si es de surco
                            {
                                validador = true;
                            }
                        }
                        if (validador == true)
                        {

                            if (cont == 26)
                            {
                                X = j;
                            }
                            if (cont == 27)
                            {
                                Y = j;
                            }
                        }
                        cont++;

                    }
                }
                if (X != 0)
                {
                    //Añadir a la lista existente
                    puntos = new PointLatLng(Y, X);
                    lstPuntos.Add(puntos);
                    objArrCoordenadas.agregar(X, Y, nombre);
                    //Marcador
                    s = "";
                    s += "Marcador " + cont2;
                    markerOverlay = new GMapOverlay(s);
                    marker = new GMarkerGoogle(new PointLatLng(Y, X), GMarkerGoogleType.red_small);
                    markerOverlay.Markers.Add(marker);
                    //Agregar el overlay en el mapa
                    gMapControl1.Overlays.Add(markerOverlay);
                }
            }
            return lstPuntos;
        }
        List<PointLatLng> leer_CEducativos_region_lima() //Lima
        {
            StreamReader file = new StreamReader(@"Centros_Educativos.json");
            string content = file.ReadToEnd();
            file.Close();

            dynamic deserialized = JsonConvert.DeserializeObject(content);
            short cont = 0;
            int cont2 = 0;
            double X = 0;
            double Y = 0;
            string nombre = "";
            string s = "";
            //Lista de puntos para poder dibujar
            List<PointLatLng> lstPuntos = new List<PointLatLng>();
            PointLatLng puntos;

            bool validador = false;
            foreach (var item in deserialized.features)
            {
                cont = 0;
                X = 0;
                Y = 0;
                validador = false;

                foreach (var i in item.properties)
                {
                    foreach (var j in i)
                    {
                        if (cont == 2)
                        {
                            nombre = j;
                        }
                        if (cont == 17) //DRE_UGEL
                        {
                            if (j == "DRE LIMA PROVINCIAS" || j == "DRE LIMA METROPOLITANA") //Si es de lima
                            {
                                validador = true;
                            }
                        }
                        if (validador == true)
                        {

                            if (cont == 26)
                            {
                                X = j;
                            }
                            if (cont == 27)
                            {
                                Y = j;
                            }
                        }
                        cont++;

                    }
                }
                if (X != 0)
                {
                    //Añadir a la lista existente
                    puntos = new PointLatLng(Y, X);
                    lstPuntos.Add(puntos);
                    objArrCoordenadas.agregar(X, Y, nombre);
                    //Marcador
                    s = "";
                    s += "Marcador " + cont2;
                    markerOverlay = new GMapOverlay(s);
                    marker = new GMarkerGoogle(new PointLatLng(Y, X), GMarkerGoogleType.red_small);
                    markerOverlay.Markers.Add(marker);
                    //Agregar el overlay en el mapa
                    gMapControl1.Overlays.Add(markerOverlay);
                }
            }
            return lstPuntos;
        }
        List<PointLatLng> leer_CEducativos_region_piura() //Piura
        {
            StreamReader file = new StreamReader(@"Centros_Educativos.json");
            string content = file.ReadToEnd();
            file.Close();

            dynamic deserialized = JsonConvert.DeserializeObject(content);
            short cont = 0;
            int cont2 = 0;
            double X = 0;
            double Y = 0;
            string nombre = "";
            string s = "";
            //Lista de puntos para poder dibujar
            List<PointLatLng> lstPuntos = new List<PointLatLng>();
            PointLatLng puntos;

            bool validador = false;
            foreach (var item in deserialized.features)
            {
                cont = 0;
                X = 0;
                Y = 0;
                validador = false;

                foreach (var i in item.properties)
                {
                    foreach (var j in i)
                    {
                        if (cont == 2)
                        {
                            nombre = j;
                        }
                        if (cont == 17) //DRE_UGEL
                        {
                            if (j == "PIURA") //Si es de piura
                            {
                                validador = true;
                            }
                        }
                        if (validador == true)
                        {

                            if (cont == 26)
                            {
                                X = j;
                            }
                            if (cont == 27)
                            {
                                Y = j;
                            }
                        }
                        cont++;

                    }
                }
                if (X != 0)
                {
                    //Añadir a la lista existente
                    puntos = new PointLatLng(Y, X);
                    lstPuntos.Add(puntos);
                    objArrCoordenadas.agregar(X, Y, nombre);
                    //Marcador
                    s = "";
                    s += "Marcador " + cont2;
                    markerOverlay = new GMapOverlay(s);
                    marker = new GMarkerGoogle(new PointLatLng(Y, X), GMarkerGoogleType.red_small);
                    markerOverlay.Markers.Add(marker);
                    //Agregar el overlay en el mapa
                    gMapControl1.Overlays.Add(markerOverlay);
                }
            }
            return lstPuntos;
        }


        List<PointLatLng> leer_CEducativos(int numero)
        {
            switch (numero)
            {
                case 1:
                    return leer_CEducativos_distrito("SANTIAGO DE SURCO");
                case 2:
                    return leer_CEducativos_region_lima();
                case 3:
                    return leer_CEducativos_region_piura();
            }
            return new List<PointLatLng>();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //this.Text = "Software-Centros Poblados";
            //cbMapas.DataSource = GMapProviders.List;
            //Iniciar mapa
            this.Text = "Traveling Salesman Problem";
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.CanDragMap = true;
            gMapControl1.MapProvider =GMapProviders.GoogleMap;
            gMapControl1.Position= new PointLatLng(y,x);
            gMapControl1.MinZoom = 0;
            gMapControl1.MaxZoom = 24;
            gMapControl1.Zoom = 5;
            gMapControl1.AutoScroll = true;

            cbDataSet.SelectedIndex = 0;
            cbOpciones.SelectedIndex = 0;
            cbMapas.SelectedIndex = 0;
            rbProgramacionDinamica.Select();
        }
        private void guardar_Dato(string dato)
        {
            try
            {

                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter("Text.txt");
                //Write a line of text
                sw.WriteLine(dato);
                //Close the file
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
        
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            
            if (cbDataSet.SelectedIndex == 0)
            {
                switch(cbOpciones.SelectedIndex)
                {
                    case 0:
                        lista = leer_capitales("1");
                        guardar_Dato("1");
                        break;
                    case 1:
                        lista = leer_capitales("2");
                        guardar_Dato("2");
                        break;
                    case 2:
                        lista = leer_capitales("3");
                        guardar_Dato("3");
                        break;
                    case 3:
                        lista = leer_capitales("0");
                        guardar_Dato("4");
                        break;
                    default:
                        break;
                } 
            }

            if (cbDataSet.SelectedIndex == 1)
            {
                switch (cbOpciones.SelectedIndex)
                {
                    case 0:
                        lista = leer_CEducativos(1);
                        guardar_Dato("1");
                        break;
                    case 1:
                        lista = leer_CEducativos(2);
                        guardar_Dato("2");
                        break;
                    case 2:
                        lista = leer_CEducativos(3);
                        guardar_Dato("3");
                        break;
                    default:
                        break;
                }
            }

            gMapControl1.Zoom = gMapControl1.Zoom + 1;
            gMapControl1.Zoom = gMapControl1.Zoom - 1;
            btnDibujar.Enabled = true;

        }


        private void btnDibujar_Click(object sender, EventArgs e)
        {
            if (rbProgramacionDinamica.Checked == true)
            {
                if (cbDataSet.SelectedIndex == 0) //Centros poblados
                {
                    Process.Start("TF_Programacion_Dinamica_CP.py");
                }
                else
                {
                    if(cbDataSet.SelectedIndex == 1) //Centros educativos
                    {
                        Process.Start("TF_Programacion_Dinamica_CE.py");
                    }
                }
            }
            else
            {
                if (rbConstraintPrograming.Checked == true)
                {
                    if (cbDataSet.SelectedIndex == 0) //Centros poblados
                    {
                        Process.Start("TF_Constrant_Programing_CP.py");
                    }
                    else
                    {
                        if (cbDataSet.SelectedIndex == 1) //Centros educativos
                        {
                            Process.Start("TF_Constrant_Programing_CE.py");
                        }
                    }
                }
            }
            btnDibujarCamino.Enabled = true;
        }
        
        private void btnDibujarCamino_Click(object sender, EventArgs e)
        {
            gMapControl1.Refresh();
            leer_Lista();
            int tamaño = LON.Count();
            this.Text = "Traveling Salesman Problem || Tamaño: " + tamaño;
            double lat,lon = 0;
            GMapOverlay Poligono = new GMapOverlay("Poligono");
            List<PointLatLng> puntos = new List<PointLatLng>();
            for (int i = 0; i < tamaño-1; i++)
            {
                Poligono = new GMapOverlay("Poligono" + i);
                puntos = new List<PointLatLng>();
                lat = LAT[i];
                lon = LON[i];
                puntos.Add(new PointLatLng(lat, lon));
                lat = LAT[i + 1];
                lon = LON[i + 1];
                puntos.Add(new PointLatLng(lat, lon));
                GMapPolygon poligonoPuntos = new GMapPolygon(puntos, "Poligono" + i);
                
                Poligono.Polygons.Add(poligonoPuntos);
                
                gMapControl1.Overlays.Add(Poligono);
            }
            gMapControl1.Zoom = gMapControl1.Zoom + 1;
            gMapControl1.Zoom = gMapControl1.Zoom - 1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //progressBar1.Increment(1);
            //if (progressBar1.Value == 100)
            //{
              //  progressBar1.Value = 0;
                //timer1.Enabled = false;
            //}
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMapas.Text == "Google Maps Terraneo")
                gMapControl1.MapProvider = GMapProviders.GoogleTerrainMap;
            if (cbMapas.Text == "Google Maps Callejero")
                gMapControl1.MapProvider = GMapProviders.GoogleMap;
            if (cbMapas.Text == "Google Maps Híbrido")
                gMapControl1.MapProvider = GMapProviders.GoogleHybridMap;
            if (cbMapas.Text == "World Street Map")
                gMapControl1.MapProvider = GMapProviders.ArcGIS_World_Street_Map;
            if (cbMapas.Text == "Open Clycle Map")
                gMapControl1.MapProvider = GMapProviders.OpenCycleMap;
            gMapControl1.Refresh();
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
           // btnDibujarCamino.Enabled = true;
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbMapas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMapas.Text == "Google Maps Terraneo")
                gMapControl1.MapProvider = GMapProviders.GoogleTerrainMap;
            if (cbMapas.Text == "Google Maps Callejero")
                gMapControl1.MapProvider = GMapProviders.GoogleMap;
            if (cbMapas.Text == "Google Maps Híbrido")
                gMapControl1.MapProvider = GMapProviders.GoogleHybridMap;
            if (cbMapas.Text == "World Street Map")
                gMapControl1.MapProvider = GMapProviders.ArcGIS_World_Street_Map;
            if (cbMapas.Text == "Open Clycle Map")
                gMapControl1.MapProvider = GMapProviders.OpenCycleMap;
            gMapControl1.Refresh();
        }

        private void cbDataSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> opciones;
            if (cbDataSet.SelectedIndex == 0)
            {
                opciones = new List<string>();
                opciones.Add("Capitales Regionales");
                opciones.Add("Capitales Provinciales");
                opciones.Add("Capitales Distritales");
                opciones.Add("Capitales Restantes");
                cbOpciones.DataSource = opciones;
            }
            else
            {
                if (cbDataSet.SelectedIndex == 1)
                {
                    opciones = new List<string>();
                    opciones.Add("Region Lima-SURCO");
                    opciones.Add("Region Lima");
                    opciones.Add("Region Piura");
                    cbOpciones.DataSource = opciones;
                }
            }
        }
    }
}
