using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2labac_
{
    internal class Osnova
    {
    }
    class MyMatrix
    {
        public static int col = 5;
        public static int row = 5;
        public int[,] matrix = new int[row, col];
        public int RowCount { get; set; } = row;
        public int ColCount { get; set; } = col;
        public void FillMatrix()
        {
            Random random = new Random();
            for(int i = 0; i < RowCount; i++)
            {
                for(int j = 0; j < ColCount; j++)
                {
                    matrix[i,j]=random.Next(0,10);
                }
            }
        }
    }
}
