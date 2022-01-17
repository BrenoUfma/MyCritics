using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCritics.Models {
    public class Avaliacao {
        public int ID { get; set; }
        public Usuario Usuario { get; set; }
        public int UsuarioID { get; set; }
        public Filme Filme { get; set; }
        public int FilmeID { get; set; }
        public int NotaFilme { get; set; }
        public int NotaDiretor { get; set; }
        public int NotaFigurino { get; set; }
        public int NotaRoteiro { get; set; }
        public int NotaSonoplastia { get; set; }
        public string Comentario { get; set; }

        public Avaliacao() {
        }

        public Avaliacao(int iD, int usuario, int filme, int notaFilme, int notaDiretor, int notaFigurino, int notaRoteiro, int notaSonoplastia) {
            ID = iD;
            UsuarioID = usuario;
            FilmeID = filme;
            NotaFilme = notaFilme;
            NotaDiretor = notaDiretor;
            NotaFigurino = notaFigurino;
            NotaRoteiro = notaRoteiro;
            NotaSonoplastia = notaSonoplastia;
        }
    }
}
