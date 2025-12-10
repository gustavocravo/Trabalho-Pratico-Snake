using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Prático_Snake
{
    internal class Jogador
    {
        private string nome;
        private int pontuacao;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public int Pontuacao
        {
            get { return pontuacao; }
            set { pontuacao = value; }
        }

        public Jogador(string nome)
        {
            Nome = nome;
            Pontuacao = 0;
        }


        public void AddPontos(int pontos)
        {
            Pontuacao += pontos;
        }


        public void SalvarPontuacao()
        {
            StreamWriter arqEsc = new StreamWriter("scores.txt", false, Encoding.UTF8);

            arqEsc.WriteLine("Nome: " + nome);
            arqEsc.WriteLine("Pontuação: " + pontuacao);
            arqEsc.Close();
        }
    }
}
