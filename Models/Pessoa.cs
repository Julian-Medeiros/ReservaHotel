using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservaHotel.Models
{
    public class Pessoa
    {
        public Pessoa(string nome, string sobrenome)
        {
            Nome = nome;
            Sobrenome = sobrenome;
        }
       
        private string _nome;
        private string _sobrenome;
        public string Nome
        {
            get => _nome;
            set
            {
                while (value == "")
                {
                    throw new ArgumentException("Nome não pode ser vazio, digite um nome");
                }
                _nome = value.ToUpper();
            }
        }
        public string Sobrenome
        {
            get => _sobrenome;
            set
            {
                while (value == "")
                {
                    throw new ArgumentException("Sobrenome não pode ser vazio, digite um sobrenome");
                }
                _sobrenome = value.ToUpper();
            }
        }
    }   
}