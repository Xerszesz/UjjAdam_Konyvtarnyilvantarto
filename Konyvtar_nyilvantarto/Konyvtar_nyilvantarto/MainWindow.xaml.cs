using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;

namespace Konyvtar_nyilvantarto
{
   public class Konyvadatok
    {
        uint getID;
        public uint ID { get => getID; }
        public string getszerzo;
        public string szerzo { get => getszerzo; }
        public string getcim;
        public string cim { get => getcim; }
        public string getev;
        public string ev { get => getev; }
        public string getkiado;
        public string kiado { get => getkiado; }
        public bool getkolcson;
        public bool kolcson { get => getkolcson; }

        public Konyvadatok(string sor)
        {
            string[] sorElemek = sor.Split(';');

            getID = Convert.ToUInt32(sorElemek[0]);
            getszerzo = sorElemek[1];
            getcim = sorElemek[2];
            getev = sorElemek[3];
            getkiado = sorElemek[4];
            getkolcson = Convert.ToBoolean(sorElemek[5]);

        }
    }

    public class Tagadatok
    {
        public uint ID;
        public string nev;
        public string lakcim;
    }

    public class Kolcsonadatok
    {
        public uint tagID;
        public uint konyvID;
        public DateTime Datum;
    }
    public partial class MainWindow : Window
    {
        void Feltoltes (int index)
        {
            if (!Szerzodisplay.IsEnabled)
            {
                Szerzodisplay.IsEnabled = true;
                Kiadodisplay.IsEnabled = true;
                Evdisplay.IsEnabled = true;
                Cimdisplay.IsEnabled = true;
                Kolcsoncheck.IsEnabled = true;
            }

            IDdisplay.Text = Konyvek[index].ID.ToString();
            Szerzodisplay.Text = Konyvek[index].szerzo;
            Kiadodisplay.Text = Konyvek[index].kiado;
            Evdisplay.Text = Konyvek[index].ev;
            Cimdisplay.Text = Konyvek[index].cim;
            Kolcsoncheck.IsChecked = Konyvek[index].kolcson;
        }
        public string[] fajlhely = new string[3];

        public List<Konyvadatok> Konyvek = new List<Konyvadatok>();
        public List<Tagadatok> Tagok = new List<Tagadatok>();
        public List<Kolcsonadatok> Kolcsonadat = new List<Kolcsonadatok>();
        public MainWindow()
        {
            InitializeComponent();

            OpenFileDialog beolvaso = new OpenFileDialog()
            {
                Filter = "txt files (*.txt|*txt)",
                RestoreDirectory=true
            };

            beolvaso.Title = "Könyvtári adatok beolvasása";
            beolvaso.ShowDialog();
            fajlhely[0] = beolvaso.FileName;

            string[] verybeolvaso = File.ReadAllLines(fajlhely[0]);

            foreach (string item in verybeolvaso)
            {
                Konyvek.Add(new Konyvadatok(item));
            }
        }
    }
}
