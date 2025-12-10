using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Prático_Snake
{
    internal class Tabuleiro
    {
        private int linhas;
        private int colunas;
        private char[,] grade;
        private int alimentoLinha;
        private int alimentoColuna;
        Random rnd = new Random();

        public int Linhas
        {
            get { return linhas; }
            set { linhas = value; }
        }

        public int Colunas
        {
            get { return colunas; }
            set { colunas = value; }
        }

        public char[,] Grade
        {
            get { return grade; }
            set { grade = value; }
        }

        public int AlimentoLinha
        {
            get { return alimentoLinha; }
            set { alimentoLinha = value; }
        }

        public int AlimentoColuna
        {
            get { return alimentoColuna; }
            set { alimentoColuna = value; }
        }

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            Grade = new char[linhas, colunas];
            Limpar();
        }

        public void Limpar()
        {
            for (int i = 0; i < Linhas; i++)
                for (int j = 0; j < Colunas; j++)
                    Grade[i, j] = ' ';
        }

        public bool TemEspacoLivre()
        {
            for (int i = 0; i < Linhas; i++)
                for (int j = 0; j < Colunas; j++)
                    if (Grade[i, j] == ' ') return true;
            return false;
        }

        public bool ColocarAlimento()
        {
            if (!TemEspacoLivre()) return false;

            int linha, coluna;

            do
            {
                linha = rnd.Next(0, Linhas);
                coluna = rnd.Next(0, Colunas);
            }
            while (Grade[linha, coluna] != ' ');

            AlimentoLinha = linha;
            AlimentoColuna = coluna;
            return true;
        }

        public void Atualizar(int[,] cobraMatriz, int tamanho)
        {
            Limpar();

            for (int i = 0; i < tamanho; i++)
            {
                int l = cobraMatriz[0, i];
                int c = cobraMatriz[1, i];
                Grade[l, c] = i == 0 ? 'O' : 'o';
            }

            Grade[AlimentoLinha, AlimentoColuna] = '$';
        }

        public void Desenhar(int pontuacao)
        {
            Console.Clear();
            for (int i = 0; i < Colunas + 2; i++) Console.Write('#');
            Console.WriteLine();

            for (int i = 0; i < Linhas; i++)
            {
                Console.Write('#');
                for (int j = 0; j < Colunas; j++)
                    Console.Write(Grade[i, j]);
                Console.Write('#');
                Console.WriteLine();
            }

            for (int i = 0; i < Colunas + 2; i++) Console.Write('#');
            Console.WriteLine();

            Console.WriteLine("Pontos: " + pontuacao);
        }
    }
}
