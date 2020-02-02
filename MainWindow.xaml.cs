using RegistroP.Entidades;
using RegistroP.BLL;
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


namespace RegistroP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Limpiar()
        {
            IdTextBox.Text = string.Empty;
            FechaDatePicker.Text = string.Empty;
            IdPersonaTextBox.Text = string.Empty;
            ComentarioTextBox.Text = string.Empty;
            MontoTextBox.Text = string.Empty;
            BalancTextBox.Text = string.Empty; 
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private Persona LLenaClase()
        {
            Persona persona = new Persona();
            persona.Id = Convert.ToInt32(IdTextBox.Text);
            persona.Fecha = Convert.ToDateTime(FechaDatePicker.Text);
            persona.PersonaId = Convert.ToInt32(IdPersonaTextBox.Text);
            persona.Comentario = ComentarioTextBox.Text;
            persona.Monto = Convert.ToInt32(MontoTextBox.Text);
            persona.Balance = Convert.ToInt32(BalancTextBox.Text);

            return persona;
        }

        private void LLenaCampo(Persona persona)
        {
            int id = Convert.ToInt32(IdTextBox.Text);
            DateTime fecha = Convert.ToDateTime(FechaDatePicker.Text);
            int personaId = Convert.ToInt32(IdPersonaTextBox.Text);
            int monto = Convert.ToInt32(MontoTextBox.Text);
            int balance = Convert.ToInt32(BalancTextBox.Text);

            id = persona.Id;
            fecha = persona.Fecha;
            personaId = persona.PersonaId;
            ComentarioTextBox.Text = persona.Comentario;
            monto = persona.Monto;
            balance = persona.Balance;
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Persona persona = PersonasBLL.Buscar((int)Convert.ToInt32(IdTextBox.Text));
            return (persona != null);
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            Persona persona;
            bool paso = false;

           //if (!Validar())
              //  return;
            persona = LLenaClase();

            if(IdTextBox.Text == string.Empty)
                paso = PersonasBLL.Guardar(persona);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("no se puede madificar la persona que no existe", "Fallo",  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                      
            }

        }
    }
}
