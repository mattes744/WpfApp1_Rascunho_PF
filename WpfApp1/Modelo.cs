using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Modelo
    {
        public int Id { get; set; }
        public string modelo { get; set; }
        public int Preco { get; set; }
        public int IdVeiculo { get; set; }
        public override string ToString()
        {
            if (IdVeiculo == 0)
                return $"{Id} - {modelo} - {Preco}";
            else
                return $"{Id} - {modelo} - {Preco} - Veiculo: {IdVeiculo}";
        }
    }
}

