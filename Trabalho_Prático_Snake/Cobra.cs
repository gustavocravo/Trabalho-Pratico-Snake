using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Prático_Snake
{
    internal class Cobra
    {
        private string direcao;
        private int tamanho;
        private int[,] corpo;

        public string Direcao
        {
            get { return direcao; }
            set { direcao = value; }
        }

        public int Tamanho
        {
            get { return tamanho; }
            set { tamanho = value; }
        }

        public int[,] Corpo
        {
            get { return corpo; }
            set { corpo = value; }
        }

        public Cobra(int linhaInicial, int colunaInicial)
        {
            Corpo = new int[2, 600];
            Corpo[0, 0] = linhaInicial;
            Corpo[1, 0] = colunaInicial;
            Tamanho = 1;
            Direcao = "DIREITA";
        }


        public void MudarDirecao(ConsoleKey tecla)
        {
            if (tecla == ConsoleKey.UpArrow && Direcao != "BAIXO")
            {
                Direcao = "CIMA";
            }
            else if (tecla == ConsoleKey.DownArrow && Direcao != "CIMA")
            {
                Direcao = "BAIXO";
            }
            else if (tecla == ConsoleKey.LeftArrow && Direcao != "DIREITA")
            {
                Direcao = "ESQUERDA";
            }
            else if (tecla == ConsoleKey.RightArrow && Direcao != "ESQUERDA")
            {
                Direcao = "DIREITA";
            }
        }


        public void Mover()
        {
            for (int i = Tamanho; i > 0; i--)
            {
                Corpo[0, i] = Corpo[0, i - 1];
                Corpo[1, i] = Corpo[1, i - 1];
            }


            if (Direcao == "CIMA")
            {
                Corpo[0, 0]--;
            }
            else if (Direcao == "BAIXO")
            {
                Corpo[0, 0]++;
            }
            else if (Direcao == "ESQUERDA")
            {
                Corpo[1, 0]--;
            }
            else if (Direcao == "DIREITA")
            {
                Corpo[1, 0]++;
            }
        }


        public bool Comeu(int alimentoLinha, int alimentoColuna)
        {
            return Corpo[0, 0] == alimentoLinha && Corpo[1, 0] == alimentoColuna;
        }


        public void Crescer()
        {
            if (Tamanho < 600)
            {
                Tamanho++;
            }
        }


        public bool ColisaoParede(int maxLinhas, int maxColunas)
        {
            return Corpo[0, 0] < 0 || Corpo[0, 0] >= maxLinhas ||
            Corpo[1, 0] < 0 || Corpo[1, 0] >= maxColunas;
        }


        public bool ColisaoCorpo()
        {
            for (int i = 1; i < Tamanho; i++)
            {
                if (Corpo[0, 0] == Corpo[0, i] && Corpo[1, 0] == Corpo[1, i])
                {
                    return true;
                }
            }
                    
            return false;
        }
    }
}
