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
using CGCI_WPF_APP;
using DevExpress.Xpf.Grid;
using Microsoft.Win32;

namespace CGCI_WPF_APP.Windows
{
    /// <summary>
    /// Interaction logic for User_wind.xaml
    /// </summary>
    public partial class User_wind : ThemedWindow
    {
        public User_wind()
        {
            InitializeComponent();
            LoadData();
        }
        CGCI_dbEntities _Context;

        void LoadData()
        {
            _Context = new CGCI_dbEntities();
            gridControl.ItemsSource = _Context.Users.ToList();
            LookUpEditSettings.ItemsSource = _Context.fonctions.ToList();
            LookUpEditSettings.ValueMember = "id";
            LookUpEditSettings.DisplayMember = "fonction1";

            LookUpEditSettingsCode.ItemsSource = _Context.fonctions.ToList();
            LookUpEditSettingsCode.ValueMember = "id";
            LookUpEditSettingsCode.DisplayMember = "code";
        }

        void OnValidateRow(object sender, GridRowValidationEventArgs e)
        {
            var row = (User)e.Row;
            if (e.IsNewItem)
                _Context.Users.Add(row);
            _Context.SaveChanges();
        }

        void OnValidateRowDeletion(object sender, GridValidateRowDeletionEventArgs e)
        {
            var row = (User)e.Rows.Single();
            _Context.Users.Remove(row);
            _Context.SaveChanges();
        }

        void OnDataSourceRefresh(object sender, DataSourceRefreshEventArgs e) { LoadData(); }

        private void PDF_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Document Pdf (*.pdf)|*.pdf";
            if (saveFileDialog.ShowDialog() == true)
            {
                gridControl.View.ExportToPdf(saveFileDialog.FileName);
            }
        }
        private void XLSX_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Document Excel (*.xlsx)|*.xlsx";
            if (saveFileDialog.ShowDialog() == true)
            {
                gridControl.View.ExportToXlsx(saveFileDialog.FileName);
            }
        }
        private void Preview_Click(object sender, RoutedEventArgs e)
        {
            gridControl.View.ShowPrintPreview(this);
        }
        private void Print_Click(object sender, RoutedEventArgs e)
        {
            gridControl.View.Print();
        }
    }
}
