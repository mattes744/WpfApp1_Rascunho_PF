using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WpfApp1
{
    class NModelo
    {
        private static List<Modelo> modelos = new List<Modelo>();
        public static void Inserir(Modelo t)
        {
            Abrir();
            int id = 0;
            foreach (Modelo obj in modelos)
                if (obj.Id > id) id = obj.Id;
            t.Id = id + 1;
            modelos.Add(t);
            Salvar();

        }
        public static List<Modelo> Listar()
        {
            Abrir();
            return modelos;
        }
        public static void Atualizar(Modelo t)
        {
            Abrir();
            foreach (Modelo obj in modelos)
                if (obj.Id == t.Id)
                {
                    obj.modelo = t.modelo;
                    obj.Preco = t.Preco;
                    obj.IdVeiculo = t.IdVeiculo;
                }
            Salvar();
        }
        public static void Excluir(Modelo m)
        {
            Abrir();
            Modelo x = null;
            foreach (Modelo obj in modelos)
                if (obj.Id == x.Id) x = obj;
            if (x != null) modelos.Remove(x);
            Salvar();
        }
        public static void Abrir()
        {
            StreamReader f = null;
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Modelo>));
                f = new StreamReader("./modelo.xml");
                modelos = (List<Modelo>)xml.Deserialize(f);
            }
            catch
            {
                modelos = new List<Modelo>();
            }
            if (f != null) f.Close();
        }
        public static void Salvar()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Modelo>));
            StreamWriter f = new StreamWriter("./modelos.xml", false);
            xml.Serialize(f, modelos);
            f.Close();
        }
        public static void Cadastrar(Modelo a, Veiculo t)
        {
            a.IdVeiculo = t.Id;
            Atualizar(a);
        }
        public static List<Modelo> Listar(Veiculo v)
        {
            Abrir();
            List<Modelo> registrados = new List<Modelo>();
            foreach (Modelo obj in modelos)
                if (obj.IdVeiculo == v.Id) registrados.Add(obj);
            return registrados;
        }

    }
}

