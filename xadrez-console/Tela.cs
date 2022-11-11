﻿using System;
using Tabuleiros;
using Xadrez;

namespace xadrez_console
{
    internal class Tela
    {
        // Imprime a matriz na tela. Onde tem peça coloca a letra representativa do método ToString()
        // Onde não tem peça coloca um hífen -
        public static void ImprimeTabuleiro(Tabuleiro tabuleiro)
        {
            for(int x = 0; x < tabuleiro.Linhas; x++)
            {
                Console.Write(8 - x + " ");

                for (int y = 0; y < tabuleiro.Colunas; y++)
                {
                    Peca peca = tabuleiro.RetornaPeca(x, y);

                    ImprimePeca(peca);
                }

                Console.WriteLine();
            }

            Console.WriteLine("  a b c d e f g h");
        }

        public static void ImprimeTabuleiro(Tabuleiro tabuleiro, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int x = 0; x < tabuleiro.Linhas; x++)
            {
                Console.Write(8 - x + " ");

                for (int y = 0; y < tabuleiro.Colunas; y++)
                {
                    Peca peca = tabuleiro.RetornaPeca(x, y);

                    if (posicoesPossiveis[x, y])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }

                    ImprimePeca(peca);
                    Console.BackgroundColor = fundoOriginal;
                }

                Console.WriteLine();
            }

            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;
        }

        // Imprime a peça na posição definida com a cor definida
        public static void ImprimePeca(Peca peca)
        {
            if(peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.Cor == Cor.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }

                Console.Write(" ");
            }
        }

        // Lê uma posição no formato do xadrez e retorna essa posição
        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string str = Console.ReadLine();
            char linha = str[0];
            int coluna = int.Parse($"{str[1]}");
            return new PosicaoXadrez(linha, coluna);
        }
    }
}
