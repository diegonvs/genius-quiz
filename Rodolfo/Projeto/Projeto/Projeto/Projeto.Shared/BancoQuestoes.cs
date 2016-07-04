using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto
{
    public class BancoQuestoes
    {


        private List<Questao> questoes;
        private List<Questao> questoesM;

        public List<Questao> QuestoesM
        {
            get { return questoesM; }
            set { questoesM = value; }
        }
        private List<Questao> questoesP;

        public List<Questao> QuestoesP
        {
            get { return questoesP; }
            set { questoesP = value; }
        }
        private List<Questao> questoesV;

        public List<Questao> QuestoesV
        {
            get { return questoesV; }
            set { questoesV = value; }
        }

        public List<Questao> Questoes
        {
            get { return questoes; }
            set { questoes = value; }
        }


        public BancoQuestoes()
        {
            questoes = new List<Questao>();
            questoesM = new List<Questao>();
            questoesP = new List<Questao>();
            questoesV = new List<Questao>();

            questoes.Add(new Questao("Quanto é 2+2?", "4", "M", "2", "7"));
            questoes.Add(new Questao("A crase é a combinação de:", "Preposição + artigo", "P", "artigo + artigo", "artigo + vogal"));
            questoes.Add(new Questao("Qual a raíz quadrada de 64?", "8", "M", "10", "9"));
            questoes.Add(new Questao("Qual oceano banha o Brasil?", "Atlântido", "V", "Pacífico", "Morto"));
            questoes.Add(new Questao("Qual é o maior continente?", "Ásia", "V", "América", "Indonésia"));
            SepararEmListas(questoes);
            
        }
        public void SepararEmListas(List<Questao> questoes)
        {
            foreach (var item in questoes)
            {
                if (item.Id == "M")
                {
                    this.questoesM.Add(item);
                }
                else if (item.Id == "V")
                {
                    this.questoesM.Add(item);
                }
                else if (item.Id == "P")
                {
                    this.questoesP.Add(item);
                }
            }


        }

    }
}
