using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCritics.Models {
    public class Ator {
        public Ator() {
        }

        public int ID { get; set; }
        public string Nome { get; set; }
        public Filme Filme { get; set; }
        public string Descricao { get; set; }

        public Ator(int iD, string nome, Filme filme, string descricao) {
            ID = iD;
            Nome = nome;
            Filme = filme;
            Descricao = descricao;
        }
    }
}
