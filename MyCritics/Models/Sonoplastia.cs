using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCritics.Models {
    public class Sonoplastia {
        public Sonoplastia() {
        }

        public int ID { get; set; }
        public string Descricao { get; set; }
        public Filme Filme { get; set; }

        public Sonoplastia(int iD, string descricao, Filme filme) {
            ID = iD;
            Descricao = descricao;
            Filme = filme;
        }
    }
}
