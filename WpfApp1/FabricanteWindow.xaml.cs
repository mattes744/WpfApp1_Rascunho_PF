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
    /// Lógica interna para FabricanteWindow.xaml
    /// </summary>
    public partial class FabricanteWindow : Window
    {
        public FabricanteWindow()
        {
            InitializeComponent();
        }

        private void InserirClick(object sender, RoutedEventArgs e)
        {
            // Novo objeto com os dados da turma que será inserida
            Fabricante t = new Fabricante();
            t.Id = int.Parse(txtId.Text);
            t.Sigla = txtSigla.Text;
            t.Nome = txtFabricante.Text;
            // Inserir a turma na lista de turmas
            NFabricante.Inserir(t);
            // Lista a turma inserida
            ListarClick(sender, e);
        }

        private void ListarClick(object sender, RoutedEventArgs e)
        {
            listFabricantes.ItemsSource = null;
            listFabricantes.ItemsSource = NFabricante.Listar();
        }

        private void AtualizarClick(object sender, RoutedEventArgs e)
        {
            // Novo objeto com os dados da turma que será inserida
            Fabricante t = new Fabricante();
            t.Id = int.Parse(txtId.Text);
            t.Sigla = txtSigla.Text;
            t.Nome = txtFabricante.Text;
            // Inserir a turma na lista de turmas
            NFabricante.Atualizar(t);
            // Lista as turmas cadastradas
            ListarClick(sender, e);
        }

        private void ExcluirClick(object sender, RoutedEventArgs e)
        {
            // Novo objeto com os dados da turma que será inserida
            Fabricante t = new Fabricante();
            t.Id = int.Parse(txtId.Text);
            // Inserir a turma na lista de turmas
            NFabricante.Excluir(t);
            // Lista as turmas cadastradas
            ListarClick(sender, e);
        }

        private void listTurmas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listFabricantes.SelectedItem != null)
            {
                Fabricante obj = (Fabricante)listFabricantes.SelectedItem;
                txtId.Text = obj.Id.ToString();
                txtSigla.Text = obj.Sigla;
                txtFabricante.Text = obj.Nome;
            }
        }
    }
}
