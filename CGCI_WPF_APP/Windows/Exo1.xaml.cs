using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace CGCI_WPF_APP.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Exo1 : ThemedWindow
    {
        public Exo1()
        {
            InitializeComponent();
            afficher_entier();
            int x = 7;
            int y = calcule_sqr(x);
        }

        void afficher_entier()
        {
            //traitement
        }

        int calcule_sqr(int a)
        {
            int sqr = a * a;
            return sqr;
        }

        int calcule_sqr(float a)
        {
            int sqr = (int)(a * a);
            return sqr;
        }

        int calcule_sqr(int a, int b)
        {
            int sqr = a * b;
            return sqr;
        }


        //cas 1
        //private void SimpleButton_Click(object sender, RoutedEventArgs e)
        //{
        //    vehicule audi = new vehicule();

        //    int d = int.Parse(dist_txt.Text);
        //    int v = int.Parse(vitesse_txt.Text);
        //    DateTime td = deppart_tp.DateTime;

        //    arrive_txt.Text = audi.calcule_temps_arriver(d, v, td);
        //}

        //cas é
        private void SimpleButton_Click(object sender, RoutedEventArgs e)
        {
            

            int d = int.Parse(dist_txt.Text);
            int v = int.Parse(vitesse_txt.Text);
            DateTime td = deppart_tp.DateTime;

            vehicule audi = new vehicule(d, v, td);
            arrive_txt.Text = audi.calcule_temps_arriver();

            voiture volksvagen = new voiture();
            volksvagen.calcule_temps_arriver();
        }
    }


    //cas 1
    //public class vehicule
    //{
    //    private int dist;
    //    private int vitesse;
    //    private DateTime temps_depart;

    //    public string calcule_temps_arriver( int d, int v, DateTime td)
    //    {
    //        dist = d;
    //        vitesse = v;
    //        temps_depart = td;
    //        DateTime temps_arriver = temps_depart.AddHours(Convert.ToDouble(dist/vitesse)) ;
    //        return temps_arriver.ToShortTimeString();
    //    }
    //}


    //cas 2
    public class vehicule
    {
        private int dist;
        private int vitesse;
        private DateTime temps_depart;


        //constructor : function qui porte le mm nom de la class, sans un type
        public vehicule (int dist, int vitesse, DateTime temps_depart)
        {
            this.dist = dist;
            this.vitesse = vitesse;
            this.temps_depart = temps_depart;

        }

        public vehicule(){}

        public string calcule_temps_arriver()
        {
            DateTime temps_arriver = temps_depart.AddHours(Convert.ToDouble(dist / vitesse));
            return temps_arriver.ToShortTimeString();
        }
    }

    class voiture : vehicule
    {
        private int nbr_roux = 4;
        private int nbr_passagers = 4;
    }
}
