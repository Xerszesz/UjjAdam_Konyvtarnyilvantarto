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
        public uint getID;
        public uint ID { get => getID; }
        public uint gettagID;
        public uint tagID { get => gettagID; }
        public uint getkonyvID;
        public uint konyvID { get => getkonyvID; }
        
        public DateTime getdatumki;
        public DateTime datumki { get => getdatumki; }
        public DateTime? getdatumvissza;
        public DateTime? datumvissza { get => getdatumvissza; }

        public Kolcsonadatok(string sor)
        {
            string[] sorElemei = sor.Split(';');

            getID = Convert.ToUInt32(sorElemei[0]);
            gettagID = Convert.ToUInt32(sorElemei[1]);
            getkonyvID = Convert.ToUInt32(sorElemei[2]);
            getdatumki = DateTime.ParseExact(sorElemei[3], "yyyy.MM.dd.", null);
            if (sorElemei[4] != "")
            {
                getdatumvissza = DateTime.ParseExact(sorElemei[4], "yyyy.MM.dd", null);
            }
            else { getdatumvissza = null; }
        }
    }
    public partial class MainWindow : Window
    {
        void Feltoltes (int index)
        {
            if (index == -1)
            {
                return;
            }
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
        public BindingList<Kolcsonadatok> KolcsonadatokDisplay = new BindingList<Kolcsonadatok>();
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

            beolvaso.Title = "Könyvtári kölcsönök beolvasása";
            beolvaso.ShowDialog();
            fajlhely[2] = beolvaso.FileName;

            verybeolvaso = File.ReadAllLines(fajlhely[2]);
            foreach (string item in verybeolvaso)
            {
                if (item.Trim() == "")
                {
                    continue;
                }
                Kolcsonadat.Add(new Kolcsonadatok(item));
            }
        }

        private void KonyvekDisplay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Feltoltes(KonyvekDisplay.SelectedIndex);
        }

        private void Tagdisplay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TagFeltoltes(Tagdisplay.SelectedIndex);
        }

        private void Könyvekmentés_Click(object sender, RoutedEventArgs e)
        {
            int konybeirtID = Konyvek.ToList().FindIndex(x => x.ID == Convert.ToInt32(IDdisplaykonyvek.Text));
            string kolcsonozhetoe = Kolcsoncheckkonyvek.IsChecked.ToString().ToUpper()[0] + Kolcsoncheckkonyvek.IsChecked.ToString().Substring(1);
            string ujsor = $"{IDdisplaykonyvek.Text};{Szerzodisplaykonyvek};{Cimdisplaykonyvek.Text};{Evdisplaykonyvek.Text};{Kiadodisplaykonyvek.Text};{kolcsonozhetoe}";
            if (konybeirtID == -1)
            {
                File.AppendAllText(fajlhely[0], ujsor);
                Konyvek.Add(new Konyvadatok(ujsor));
            }
            else { Konyvek[konybeirtID] = new Konyvadatok(ujsor); }
        }

        private void KönyvekTörlés_Click(object sender, RoutedEventArgs e)
        {
            int konyvbeirtID = Konyvek.ToList().FindIndex(x => x.ID == Convert.ToInt32(IDdisplaytagok.Text));
            if (konyvbeirtID != -1)
            {
                Konyvek.RemoveAt(konyvbeirtID);
                List<string> kivalasztottfajl = File.ReadAllLines(fajlhely[0]).ToList();
                kivalasztottfajl.RemoveAt(konyvbeirtID);
                File.WriteAllLines(fajlhely[0], kivalasztottfajl);
            }
        }

        private void KönyvekÚj_Click(object sender, RoutedEventArgs e)
        {
            if (!Szerzodisplaykonyvek.IsEnabled && !Cimdisplaykonyvek.IsEnabled && !Evdisplaykonyvek.IsEnabled && !Kiadodisplaykonyvek.IsEnabled && !Kolcsoncheckkonyvek.IsEnabled)
            {
                Kolcsoncheckkonyvek.IsEnabled = true;
                Kiadodisplaykonyvek.IsEnabled = true;
                Evdisplaykonyvek.IsEnabled = true;
                Cimdisplaykonyvek.IsEnabled = true;
                Szerzodisplaykonyvek.IsEnabled = true;
                
            }
            IDdisplaykonyvek.Text = (Konyvek[Konyvek.Count - 1].ID + 1).ToString();
            Szerzodisplaykonyvek.Text = "";
            Cimdisplaykonyvek.Text = "";
            Evdisplaykonyvek.Text = "";
            Kiadodisplaykonyvek.Text = "";
            Kolcsoncheckkonyvek.IsChecked = false;
        }

        private void TagMentés_Click(object sender, RoutedEventArgs e)
        {
            int tagbeirtID = Tagok.ToList().FindIndex(x => x.ID == Convert.ToInt32(IDdisplaytagok.Text));
            string ujsor = $"\n{IDdisplaytagok.Text};{Nevdisplaytagok.Text};{Lakcimdisplaytagok.Text.Replace(", ",";")}";
            if (tagbeirtID == -1)
            {
                File.AppendAllText(fajlhely[1], ujsor);
                Tagok.Add(new Tagadatok(ujsor));
            }
            else { Tagok[tagbeirtID] = new Tagadatok(ujsor); }
        }

        private void TagTörlés_Click(object sender, RoutedEventArgs e)
        {
            int tagbeirtID = Tagok.ToList().FindIndex(x => x.ID == Convert.ToInt32(IDdisplaytagok.Text));
            if (tagbeirtID == -1)
            {
                Tagok.RemoveAt(tagbeirtID);
                List<string> kivalasztottfajl = File.ReadAllLines(fajlhely[1]).ToList();
                kivalasztottfajl.RemoveAt(tagbeirtID);
                File.WriteAllLines(fajlhely[1], kivalasztottfajl);
            }
            
        }

        private void TagÚj_Click(object sender, RoutedEventArgs e)
        {
            if (!Nevdisplaytagok.IsEnabled && !Lakcimdisplaytagok.IsEnabled)
            {
                Nevdisplaytagok.IsEnabled = true;
                Lakcimdisplaytagok.IsEnabled = true;
            }

            IDdisplaytagok.Text = (Tagok[Tagok.Count - 1].ID + 1).ToString();
            Nevdisplaytagok.Text = "";
            Lakcimdisplaytagok.Text = "";
        }

        private void Kolcsonzesdisplay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TagFeltoltes(Kolcsonzesdisplay.SelectedIndex);
        }

        private void Kolcsonkeres_Click(object sender, RoutedEventArgs e)
        {
            List<Kolcsonadatok> talalat = new List<Kolcsonadatok>();
            List<Konyvadatok> keresettkonyv = Konyvek.Where(x => x.szerzo.ToLower().StartsWith(szerzodisplaykolcson.Text.ToLower())).ToList();
            keresettkonyv = keresettkonyv.Intersect(Konyvek.Where(x => x.cim.ToLower().StartsWith(cimdisplaykolcson.Text.ToLower())), new Hashelőscucc()).ToList();
            List<Tagadatok> keresetttag = Tagok.Where(x => x.nev.ToLower().StartsWith(tagdisplaykolcson.Text.ToLower())).ToList();
            talalat = Kolcsonadat.Where(x => keresettkonyv.Exists(letezik => letezik.ID == x.konyvID)).ToList();
            talalat = talalat.Where(x => x.datumvissza == null && (DateTime.Now - x.datumki).TotalDays > 30).ToList();

        }

        class Hashelőscucc : IEqualityComparer<Konyvadatok>
        {
            public bool megegyez(Konyvadatok b1, Konyvadatok b2) => b1.ID == b2.ID;

            public int hashcodegyujto(Konyvadatok konyv) => konyv.GetHashCode();

            public bool Equals(Konyvadatok x, Konyvadatok y)
            {
                throw new NotImplementedException();
            }

            public int GetHashCode(Konyvadatok obj)
            {
                throw new NotImplementedException();
            }
        }
    }
}
