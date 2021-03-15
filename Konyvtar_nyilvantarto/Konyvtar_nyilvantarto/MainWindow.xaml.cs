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

namespace Konyvtar_nyilvantarto
{
   public class Konyvadatok
    {
        public int ID;
        public string szerzo;
        public string cim;
        public string ev;
        public string kiado;
        public bool kolcson;

    }

    public class Tagadatok
    {
        public int ID;
        public string nev;
        public string lakcim;
    }

    public class Kolcsonadatok
    {
        public int tagID;
        public int konyvID;
        public string Datum;
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            OpenFileDialog beolvaso = new OpenFileDialog()
            {
                Filter = "txt files (*.txt|*txt)",
                RestoreDirectory=true
            };

        }
    }
}
