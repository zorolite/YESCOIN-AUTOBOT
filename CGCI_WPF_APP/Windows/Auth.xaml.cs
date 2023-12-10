using DevExpress.Xpf.Core;
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
using System.Windows.Shapes;


namespace CGCI_WPF_APP.Windows
{
    /// <summary>
    /// Interaction logic for Auth.xaml
    /// </summary>
    public partial class Auth : ThemedWindow
    {
        public CGCI_dbEntities CgciDbEntities = new CGCI_dbEntities();


        public Auth()
        {
            InitializeComponent();
        }

        private void cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private async void Validate_btn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Visibility = Visibility.Collapsed;
            mainWindow.ShowDialog();
            //this.Close();




            ///
            //User user = new User();
            //user.user_name = userName_txt.Text;
            //user.password = password_txt.Text;

            //CgciDbEntities.Users.Add(user);
            //await CgciDbEntities.SaveChangesAsync();
        }
    }
}
