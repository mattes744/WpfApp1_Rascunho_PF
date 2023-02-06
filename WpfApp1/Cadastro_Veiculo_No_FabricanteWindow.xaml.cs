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

namespace WpfApp1
{
    /// <summary>
    /// Lógica interna para Cadastro_Veiculo_No_FabricanteWindow.xaml
    /// </summary>
    public partial class Cadastro_Veiculo_No_FabricanteWindow : Window
    {
        public Cadastro_Veiculo_No_FabricanteWindow()
        {
            InitializeComponent();
        }

        private void ListarClick(object sender, RoutedEventArgs e)
        {
            listFabricantes.ItemsSource = null;
            listFabricantes.ItemsSource = NFabricante.Listar();
            listVeiculos.ItemsSource = null;
            listVeiculos.ItemsSource = NVeiculo.Listar();
        }

        private void CadastrarClick(object sender, RoutedEventArgs e)
        {
            if (listFabricantes.SelectedItem != null &&
                listVeiculos.SelectedItem != null)
            {
                Veiculo a = (Veiculo)listVeiculos.SelectedItem;
                Fabricante t = (Fabricante)listFabricantes.SelectedItem;
                NVeiculo.Cadastrar(a, t);
                ListarClick(sender, e);
            }
            else
            {
                MessageBox.Show("É preciso selecionar um veículo e um fabricante");
            }
        }
        private void listFabricantes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
