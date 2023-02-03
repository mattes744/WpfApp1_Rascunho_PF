using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WpfApp1
{
    static class NFabricante
    {
        private static List<Fabricante> fabricantes = new List<Fabricante>();
        public static void Inserir(Fabricante t)
        { // C - Create
            Abrir();
            fabricantes.Add(t);
            Salvar();
        }
        public static List<Fabricante> Listar()
        { // R - Read
            Abrir();
            return fabricantes;
        }
        public static Fabricante Listar(int id)
        {
            // Encontra, se existir, uma turma com o id
            foreach (Fabricante obj in fabricantes)
                if (obj.Id == id) return obj;
            return null;
        }
        public static void Atualizar(Fabricante t)
        { // U - Update
            Abrir();
            Fabricante obj = Listar(t.Id);
            obj.Nome = t.Nome;
            obj.Sigla = t.Sigla;
            Salvar();
        }
        public static void Excluir(Fabricante t)
        { // D - Delete
            Abrir();
            fabricantes.Remove(Listar(t.Id));
            Salvar();
        }
        public static void Abrir()
        {
            StreamReader f = null;
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Fabricante>));
                f = new StreamReader("./fabricante.xml");
                fabricantes = (List<Fabricante>)xml.Deserialize(f);
            }
            catch
            {
                fabricantes = new List<Fabricante>();
            }
            if (f != null) f.Close();
        }
        public static void Salvar()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Fabricante>));
            StreamWriter f = new StreamWriter("./fabricante.xml", false);
            xml.Serialize(f, fabricantes);
            f.Close();
        }
    }

}
