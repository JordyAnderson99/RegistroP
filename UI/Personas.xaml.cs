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
using RegistroP.DAL;

namespace RegistroP.UI
{
    /// <summary>
    /// Interaction logic for Personas.xaml
    /// </summary>
    public partial class Personas : Window
    {
        public Personas()
        {
            InitializeComponent();
            IdTextBox.Text = "0";
            FechaDatePicker.SelectedDate = DateTime.Now;
            BalanceTextBlock.Text = "0";
        }

        private void Limpiar()
        {
            IdTextBox.Text = "0";
            FechaDatePicker.SelectedDate = DateTime.Now;
            NombreTextBox.Text = string.Empty;
            ComentarioTextBox.Text = string.Empty;
            MontoTextBox.Text = string.Empty;
            PagoTextBox.Text = string.Empty;
            BalanceTextBlock.Text = "0";

        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private Persona LlenaClase()
        {
            Persona persona = new Persona();
            persona.Id = Convert.ToInt32(IdTextBox.Text);
            persona.Fecha = Convert.ToDateTime(FechaDatePicker.SelectedDate);
            persona.Nombre = NombreTextBox.Text;
            persona.Comentario = ComentarioTextBox.Text;
            persona.Monto = Convert.ToInt32(MontoTextBox.Text);
            persona.Pago = Convert.ToInt32(PagoTextBox.Text);
            persona.Balance = (persona.Monto-persona.Pago);

            return persona;
        }

        private void LlenaCampo(Persona persona)
        {
            IdTextBox.Text = Convert.ToString(persona.Id);
            FechaDatePicker.SelectedDate = Convert.ToDateTime(persona.Fecha);
            NombreTextBox.Text = persona.Nombre;
            ComentarioTextBox.Text = persona.Comentario;
            MontoTextBox.Text = Convert.ToString(persona.Monto);
            PagoTextBox.Text = Convert.ToString(persona.Pago);
            BalanceTextBlock.Text = Convert.ToString(persona.Balance); 
        }

        private bool Validar()
        {
            bool paso = true;
            if (string.IsNullOrWhiteSpace(IdTextBox.Text))
            {
                MessageBox.Show("No puedes dejar el campo del Id vacio");
                IdTextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(NombreTextBox.Text))
            {
                MessageBox.Show("No puedes dejar el campo del Nombre vacio");
                NombreTextBox.Focus();
                paso = false;
            }
            if(string.IsNullOrWhiteSpace(MontoTextBox.Text))
            {
                MessageBox.Show("No puedes dejar el campo del Monto vacio");
                MontoTextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(PagoTextBox.Text))
            {
                MessageBox.Show("No puedes dejar el campo del Pago vacio");
                PagoTextBox.Focus();
                paso = false;
            }
            return paso;

        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Persona persona = PersonasBLL.Buscar(Convert.ToInt32(IdTextBox.Text));
            return (persona != null);
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            Persona persona;
            bool paso = false;
            if (!Validar())
                return;
            persona = LlenaClase();

            //Determinar si es Guardar o Modificar 
            if (IdTextBox.Text == "0")
                paso = PersonasBLL.Guardar(persona);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se Puede Modificar una persona que no existe");
                    return;
                }
            }

            //Informar el resultado
            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado");
            }
            else
            {
                MessageBox.Show("No fue pasible Guardar");
            }
            
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            Persona persona = new Persona();
            int.TryParse(IdTextBox.Text, out id);
            Limpiar();

            persona = PersonasBLL.Buscar(id);

            if(persona != null)
            {
                MessageBox.Show("Persona encontrada");
                LlenaCampo(persona);
            }
            else
            {
                MessageBox.Show("Persona no encontrada");
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            int.TryParse(IdTextBox.Text, out id);
            Limpiar();

            if (PersonasBLL.Eliminar(id))
            {
                MessageBox.Show("Persona eliminada");
            }
            else
            {
                MessageBox.Show("no se puede eliminar a una prsona que no existe");
            }
        }
    }
}
