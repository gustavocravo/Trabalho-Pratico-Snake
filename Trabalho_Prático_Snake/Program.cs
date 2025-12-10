using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Trabalho_Prático_Snake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int linhas = 20;
            int colunas = 30;

            Console.Write("Nome do jogador: ");
            string nome = Console.ReadLine();
            Jogador jogador = new Jogador(nome);


            Tabuleiro tab = new Tabuleiro(linhas, colunas);
            Cobra cobra = new Cobra(linhas / 2, colunas / 2);


            tab.ColocarAlimento();
            tab.Atualizar(cobra.Corpo, cobra.Tamanho);
            tab.DesenharTab(jogador.Pontuacao);

            bool jogoAtivo = true;

            while (jogoAtivo)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKey tecla = Console.ReadKey(true).Key;
                    cobra.MudarDirecao(tecla);
                }

                cobra.Mover();

                if (cobra.BateuParede(linhas, colunas) || cobra.BateuCorpo())
                {
                    jogoAtivo = false;
                    break;
                }

                if (cobra.Comer(tab.AlimentoLinha, tab.AlimentoColuna))
                {
                    cobra.Crescer();
                    jogador.AddPontos(10);
                    tab.ColocarAlimento();
                }

                tab.Atualizar(cobra.Corpo, cobra.Tamanho);
                tab.DesenharTab(jogador.Pontuacao);

                Thread.Sleep(150);
            }

            Console.WriteLine("Fim de jogo!");
            Console.WriteLine("Pontuação final: " + jogador.Pontuacao);

            try
            {
                jogador.SalvarPontuacao();
                Console.WriteLine("Pontuação salva!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }
        }
    }
}
