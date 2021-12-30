using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCritics.Models {
    public class Filme {
        public Filme() {
        }

        public int ID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime Ano { get; set; }

        public Filme(int iD, string nome, string descricao, DateTime ano) {
            ID = iD;
            Nome = nome;
            Descricao = descricao;
            Ano = ano;
        }
    }
}
