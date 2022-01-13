﻿using MyCritics.Data;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MyCritics.Models {
    public class Usuario {

        public int ID { get; set; }
        public string Password { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public DateTime DataNascimento { get; set; }
        

        public Usuario() {
        }

        public Usuario(int iD, string password, string nome, string sobrenome, string email, string cidade, string estado, DateTime dataNascimento, string file) {
            ID = iD;
            Password = password;
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            Cidade = cidade;
            Estado = estado;
            DataNascimento = dataNascimento.Date;
            
        }

        public bool ValidarLogin() {

            return true;
        }

        
        }
    }
