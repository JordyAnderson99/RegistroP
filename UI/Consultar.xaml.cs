using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RegistroP.Entidades;
using RegistroP.BLL;
using System.Linq;

namespace RegistroP.UI
{
    /// <summary>
    /// Interaction logic for Consultar.xaml
    /// </summary>
    public partial class Consultar : Window
    {
        public Consultar()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Persona>();
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroCombox.SelectedIndex)
                {
                    //Todo
                    case 0:
                        listado = PersonasBLL.GetList(p=> true);
                        break;
                    //Id
                    case 1:
                        int id = Convert.ToInt32(CriterioTextBox.Text);
                        listado = PersonasBLL.GetList(p => p.Id == id);                 
                        break;
                    //Nombre
                    case 2:
                        listado = PersonasBLL.GetList(p => p.Nombre.Contains(CriterioTextBox.Text));
                        break;
                }
                listado = listado.Where(c => c.Fecha.Date >= DesdeDatePicker.SelectedDate && c.Fecha.Date <= HastaDatePicker.SelectedDate).ToList();
            }
            else
            {
                listado = PersonasBLL.GetList(p => true);
            }

            ConsultaDataGrid.ItemsSource = null;
            ConsultaDataGrid.ItemsSource = listado; 
        }
    }
}
