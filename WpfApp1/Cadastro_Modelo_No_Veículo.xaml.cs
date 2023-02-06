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

namespace WpfApp8
{
    /// <summary>
    /// Lógica interna para Cadastro_Modelo_No_Veículo.xaml
    /// </summary>
    public partial class Cadastro_Modelo_No_Veículo : Window
    {
        public Cadastro_Modelo_No_Veículo()
        {
            InitializeComponent();
        }

        private void ListarClick(object sender, RoutedEventArgs e)
        {
            listVeiculos.ItemsSource = null;
            listVeiculos.ItemsSource = NVeiculo.Listar();
            listModelos.ItemsSource = null;
            listModelos.ItemsSource = NModelo.Listar();
        }

        private void CadastroClick(object sender, RoutedEventArgs e)
        {
            if (listVeiculos.SelectedItem != null &&
                listModelos.SelectedItem != null)
            {
                Modelo a = (Modelo)listModelos.SelectedItem;
                Fabricante t = (Fabricante)listVeiculos.SelectedItem;
                NModelo.Atualizar(a, t);
                ListarClick(sender, e);
            }
            else
            {
                MessageBox.Show("É preciso selecionar um modelo e um fabricante");
            }
        }
    }
}
