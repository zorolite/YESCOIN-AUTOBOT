using DevExpress.Xpf.Core;
using DevExpress.Xpf.Grid;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for User_controler.xaml
    /// </summary>
    public partial class User_controler : ThemedWindow
    {
        private CGCI_dbEntities cgciDbEntities = new CGCI_dbEntities();

        public User_controler()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            //var data = cgciDbEntities.Users.ToList();
            //GridControl.ItemsSource = data;

            GridControl.ItemsSource = GetData();
            ChangeSelection();
        }

        private DataTable GetData()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("User Name", typeof(string));
            dataTable.Columns.Add("Matricule", typeof(string));
            dataTable.Columns.Add("First Name", typeof(string));
            dataTable.Columns.Add("Last Name", typeof(string));
            dataTable.Columns.Add("Fonction", typeof(string));

            //IQueryable<User> query = from p in cgciDbEntities.Users
            //    where p.id >= 3
            //    select p;

            var query = from p in cgciDbEntities.Users
                        select p;

            foreach (var VARIABLE in query)
            {
                var row = dataTable.NewRow();
                row["Id"] = VARIABLE.id.ToString();
                row["User Name"] = VARIABLE.user_name;
                row["Matricule"] = VARIABLE.matricule;
                row["First Name"] = VARIABLE.first_name;
                row["Last Name"] = VARIABLE.last_name;
                //row["Fonction"] = VARIABLE.fonction.fonction1;

                dataTable.Rows.Add(row);
            }
            return dataTable;
        }

        private void BarButtonItem_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            GridControl.View.MoveFirstRow();
        }

        private void BarButtonItem_ItemClick_1(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            GridControl.View.MovePrevRow();
        }

        private void BarButtonItem_ItemClick_2(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            GridControl.View.MoveNextRow();
        }

        private void BarButtonItem_ItemClick_3(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            GridControl.View.MoveLastRow();
        }

        private async void BarButtonItem_ItemClick_4(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            User user = new User();

            Charging(user);

            cgciDbEntities.Users.Add(user);
            await cgciDbEntities.SaveChangesAsync();

            LoadData();
            Descharging();
        }

        private void Charging(User user)
        {
            user.user_name = userName_txt.Text;
            user.first_name = firstName_txt.Text;
            user.last_name = lastName_txt.Text;
            user.matricule = matricule_txt.Text;
        }

        private void Descharging()
        {
            userName_txt.Clear();
            firstName_txt.Clear();
            lastName_txt.Clear();
            matricule_txt.Clear();
        }

        private async void BarButtonItem_ItemClick_5(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            var selRow = GridControl.View.FocusedRowHandle;

            if (selRow > 0)
            {
                int id = Convert.ToInt32(GridControl.GetFocusedRowCellValue("Id").ToString());
                var query = from p in cgciDbEntities.Users
                    where p.id == id
                    select p;
                if (query.Any())
                {
                    Charging(query.FirstOrDefault());
                    await cgciDbEntities.SaveChangesAsync();
                    LoadData();
                }
            }
        }

        private void ChargingInv(User user)
        {
            userName_txt.Text = user.user_name;
            firstName_txt.Text = user.first_name;
            lastName_txt.Text = user.last_name;
            matricule_txt.Text = user.matricule;
        }

        private void TableView_FocusedRowChanged(object sender, DevExpress.Xpf.Grid.FocusedRowChangedEventArgs e)
        {
            ChangeSelection();
        }

        private void ChangeSelection()
        {
            var selRow = GridControl.View.FocusedRowHandle;
            if (selRow > 0)
            {
                int id = Convert.ToInt32(GridControl.GetFocusedRowCellValue("Id").ToString());
                var query = from p in cgciDbEntities.Users
                    where p.id == id
                    select p;
                if (query.Any())
                {
                    ChargingInv(query.FirstOrDefault());
                }
            }
        }
    }
}
