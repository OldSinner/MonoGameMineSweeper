using System;

namespace MineSweeper.Engine
{
    public static class Generator
    {
        public static int[,] GenerateMines(int[,] mines, int numberofmines)
        {
            var rand = new Random();
            while(numberofmines != 0)
            {
                var i = rand.Next(10);
                var j = rand.Next(10);
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