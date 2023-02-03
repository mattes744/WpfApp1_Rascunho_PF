﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdFabricante { get; set; }
        public override string ToString()
        {
            return $"{Id} - {Nome} - {IdFabricante}";
        }
    }

}
