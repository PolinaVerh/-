using System;
using System.Drawing;
using System.Collections.Generic;

namespace board_NETcore
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] board = new char[,]
                {
                    { 'a','b','c' },
                    {'d','e','f' },
                    {'g','h','i' }
                };
            while (true)
            {
                Console.WriteLine(Search(board, Console.ReadLine()));
                Console.ReadKey();
            }
        }

        static string S;
        static Stack<Point> storage = new Stack<Point>();
        static char[,] Board;
        static bool Search(char[,] board, string str)
        {
            storage = new Stack<Point>();
            Board = board;
            S = str;
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    if (Board[i, j] == S[0])
                        if (research(new Point(i, j)))
                            return true;
                }

            }
            return false;
        }
        
        static bool research(Point p)
        {
            if ((p.X < 0 || p.X >= Board.GetLength(0)) || (p.Y < 0 || p.Y >= Board.GetLength(1)))
                return false;
            if (storage.Contains(p))
                return false;
            storage.Push(p);
            if (Board[p.X, p.Y] != S[storage.Count - 1]) { storage.Pop(); return false; }
            if (storage.Count == S.Length)
                return true;
            if (research(new Point(p.X, p.Y + 1)))
                return true;
            if (research(new Point(p.X, p.Y - 1)))
                return true;
            if (research(new Point(p.X + 1, p.Y)))
                return true;
            if (research(new Point(p.X - 1, p.Y)))
                return true;
            storage.Pop();
            return false;
        }
    }
}
