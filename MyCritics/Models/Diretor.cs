using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCritics.Models {
    public class Diretor {
        public Diretor() {
        }

        public int ID { get; set; }
        public string Nome { get; set; }
        public DateTime DataNasc { get; set; }

        public Diretor(int iD, string nome, DateTime dataNasc) {
            ID = iD;
            Nome = nome;
            DataNasc = dataNasc;
        }
    }
}
