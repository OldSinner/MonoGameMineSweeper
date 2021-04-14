using System;

namespace MineSweeper.Engine
{
    public static class Generator
    {
        public static int[,] GenerateMines(int[,] mines, int numberofmines, int bombHeight, int bombWidth)
        {
            var rand = new Random();
            while(numberofmines != 0)
            {
                var i = rand.Next(bombHeight);
                var j = rand.Next(bombWidth);
                if(mines[i,j]!=1)
                {
                    mines[i,j]=1;
                    numberofmines--;
                }
            }
            return mines;
        }
    }
}