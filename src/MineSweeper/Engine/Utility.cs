using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MineSweeper.Engine
{
    public static class Utility
    {
        public static int[,] GenerateMines(int numberofmines, int bombHeight, int bombWidth)
        {
            int[,] mines = new int[bombHeight, bombWidth];
            var rand = new Random();
            while (numberofmines != 0)
            {
                var i = rand.Next(bombHeight);
                var j = rand.Next(bombWidth);
                if (mines[i, j] != 10)
                {
                    mines[i, j] = 10;
                    numberofmines--;
                }
            }
            for (int i = 0; i < bombHeight; i++)
            {
                for (int j = 0; j < bombWidth; j++)
                {
                    if (mines[i, j] != 10)
                        mines[i, j] = CheckType(mines, i, j);
                }
            }
            return mines;
        }
        static int CheckType(int[,] minefield, int column, int row)
        {
            int type = 0;
            if (CheckIfMines(minefield, column + 1, row)) type++;
            if (CheckIfMines(minefield, column - 1, row)) type++;
            if (CheckIfMines(minefield, column, row + 1)) type++;
            if (CheckIfMines(minefield, column, row - 1)) type++;
            if (CheckIfMines(minefield, column + 1, row - 1)) type++;
            if (CheckIfMines(minefield, column + 1, row + 1)) type++;
            if (CheckIfMines(minefield, column - 1, row + 1)) type++;
            if (CheckIfMines(minefield, column - 1, row - 1)) type++;
            return type;
        }
        public static bool CheckIfMines(int[,] minefiled, int column, int row)
        {
            try
            {
                if (minefiled[column, row] == 10) return true;
                else return false;
            }
            catch (Exception x)
            {
                return false;
            }
        }
       
    }
}