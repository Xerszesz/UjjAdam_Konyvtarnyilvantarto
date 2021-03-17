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
using System.ComponentModel;

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
        public uint getID;
        public uint ID { get => getID; }
        public string getnev;
        public string nev { get => getnev; }
        public string getlakcim;
        public string lakcím { get => getlakcim; }

        public Tagadatok(string sor)
        {
            string[] sorElemek = sor.Split(';');

            getID = Convert.ToUInt32(sorElemek[0]);
            getnev = sorElemek[1];
            getlakcim = string.Join(", ",sorElemek.Skip(2));
        }
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
            if (!Szerzodisplaykonyvek.IsEnabled)
            {
                Szerzodisplaykonyvek.IsEnabled = true;
                Kiadodisplaykonyvek.IsEnabled = true;
                Evdisplaykonyvek.IsEnabled = true;
                Cimdisplaykonyvek.IsEnabled = true;
                Kolcsoncheckkonyvek.IsEnabled = true;
            }

            IDdisplaykonyvek.Text = Konyvek[index].ID.ToString();
            Szerzodisplaykonyvek.Text = Konyvek[index].szerzo;
            Kiadodisplaykonyvek.Text = Konyvek[index].kiado;
            Evdisplaykonyvek.Text = Konyvek[index].ev;
            Cimdisplaykonyvek.Text = Konyvek[index].cim;
            Kolcsoncheckkonyvek.IsChecked = Konyvek[index].kolcson;
        }

        void TagFeltoltes(int index)
        {
            if (index ==-1)
            {
                return;
            }
            if (!Nevdisplaytagok.IsEnabled)
            {
                Nevdisplaytagok.IsEnabled = true;
                Lakcimdisplaytagok.IsEnabled = true;
            }

            IDdisplaytagok.Text = Tagok[index].ID.ToString();
            Nevdisplaytagok.Text = Tagok[index].nev;
            Lakcimdisplaytagok.Text = Tagok[index].lakcím;
            
        }
        public string[] fajlhely = new string[3];

        public BindingList<Konyvadatok> Konyvek = new BindingList<Konyvadatok>();
        public BindingList<Tagadatok> Tagok = new BindingList<Tagadatok>();
        public List<Kolcsonadatok> Kolcsonadat = new List<Kolcsonadatok>();
        public MainWindow()
        {
            InitializeComponent();

            OpenFileDialog beolvaso = new OpenFileDialog()
            {
                Filter = "txt files (*.txt|*txt)",
                RestoreDirectory=true
            };

            beolvaso.Title = "Könyvtári könyvek beolvasása";
            beolvaso.ShowDialog();
            fajlhely[0] = beolvaso.FileName;

            string[] verybeolvaso = File.ReadAllLines(fajlhely[0]);

            foreach (string item in verybeolvaso)
            {
                if (item.Trim()=="")
                {
                    continue;
                }
                Konyvek.Add(new Konyvadatok(item));
            }

            KonyvekDisplay.ItemsSource = Konyvek;

            beolvaso.Title = "Könyvtári tagok beolvasása";
            beolvaso.ShowDialog();
            fajlhely[1] = beolvaso.FileName;

            verybeolvaso = File.ReadAllLines(fajlhely[1]);
            foreach (string item in verybeolvaso)
            {
                if (item.Trim() == "")
                {
                    continue;
                }
                Tagok.Add(new Tagadatok(item));
            }

            Tagdisplay.ItemsSource = Tagok;
        }

        private void KonyvekDisplay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Feltoltes(KonyvekDisplay.SelectedIndex);
        }
    }
}
