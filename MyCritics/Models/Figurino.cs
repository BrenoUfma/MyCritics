using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCritics.Models {
    public class Figurino {
        public Figurino() {
        }

        public int ID { get; set; }
        public string Descricao { get; set; }
        public Filme Filme { get; set; }

        public Figurino(int iD, string descricao, Filme filme) {
            ID = iD;
            Descricao = descricao;
            Filme = filme;
        }
    }
}
