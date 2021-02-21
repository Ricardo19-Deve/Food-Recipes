using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAL
{
    public class LinhaIngrediente
    {
        private int _id;
        private double _quantidade;
        private Ingrediente _ingrediente;
        private int _idReceita;
        private Unidade _unidade;


        public int Id { get => _id; set => _id = value; }
        public double Quantidade { get => _quantidade; set => _quantidade = value; }
        public Ingrediente Ingrediente { get => _ingrediente; set => _ingrediente = value; }
        public Unidade Unidade { get => _unidade; set => _unidade = value; }
        public int IdReceita { get => _idReceita; set => _idReceita = value; }


       
    }
}






