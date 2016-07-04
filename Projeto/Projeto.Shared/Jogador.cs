using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto
{
    class Jogador
    {
        private string nome;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        private int rodada;

        public int Rodada
        {
            get { return rodada; }
            set { rodada = value; }
        }

        public Jogador(string nome, int rodada)
        {

            this.nome = nome;
            this.rodada = rodada;

        }
    }
}
