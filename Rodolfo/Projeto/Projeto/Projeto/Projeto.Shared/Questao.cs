using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto
{
    public class Questao
    {
        private string pergunta;

        public string Pergunta
        {
            get { return pergunta; }
            set { pergunta = value; }
        }
        private string respostaCerta;

        public string RespostaCerta
        {
            get { return respostaCerta; }
            set { respostaCerta = value; }
        }
        private string id;

        public string Id
        {
            get { return id; }
            set { id = value; }
        }
        private List<string> respostas;

        public List<string> Respostas
        {
            get { return respostas; }
            set { respostas = value; }
        }
        public Questao(string pergunta, string respostaCerta, string id, string errada1, string errada2)
        {
            respostas = new List<string>();
            this.pergunta = pergunta;
            this.respostaCerta = respostaCerta;
            this.id = id;
            respostas.Add(respostaCerta);
            respostas.Add(errada1);
            respostas.Add(errada2);
            


        }
    }
}
