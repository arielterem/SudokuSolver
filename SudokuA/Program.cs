using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SudokuA
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int[,] grid = { { 3, 0, 6, 5, 0, 8, 4, 0, 0 }, //REAL
                            { 5, 2, 0, 0, 0, 0, 0, 0, 0 },
                            { 0, 8, 7, 0, 0, 0, 0, 3, 1 },
                            { 0, 0, 3, 0, 1, 0, 0, 8, 0 },
                            { 9, 0, 0, 8, 6, 3, 0, 0, 5 },
                            { 0, 5, 0, 0, 9, 0, 6, 0, 0 },
                            { 1, 3, 0, 0, 0, 0, 2, 5, 0 },
                            { 0, 0, 0, 0, 0, 0, 0, 7, 4 },
                            { 0, 0, 5, 2, 0, 6, 3, 0, 0 } };
           int[,] grid1 = { { 0, 0, 0, 0, 9, 0, 1, 0, 6 }, //REAL
                            { 3, 1, 0, 0, 0, 5, 0, 0, 0 },
                            { 0, 0, 5, 0, 0, 0, 0, 7, 0 },
                            { 6, 0, 0, 0, 0, 0, 2, 4, 0 },
                            { 0, 9, 0, 0, 7, 0, 0, 6, 8 },
                            { 0, 3, 2, 0, 0, 0, 0, 0, 1 },
                            { 0, 5, 0, 0, 0, 0, 4, 1, 0 },
                            { 0, 6, 0, 5, 0, 0, 0, 8, 2 },
                            { 4, 0, 1, 0, 8, 0, 0, 0, 0 } };
            Board B1 = new Board();
            B1.SetBoard(grid1);
            B1.Print();
            Console.WriteLine("Sudoku solution:");

            if(Solve(B1) == true)
                B1.Print();
            else
                Console.WriteLine("Fail");

            Console.ReadKey();
        }
        
        public static void SetBoardPointers(Board b)
        {
            int index = 0;
            for(int r = 0; r < 9; r++)
            {
                for(int c = 0; c < 9; c++)
                {
                    if (b.Bboard[r, c] > 0)
                    {
                        b.SetOnePointer(index, r, c);
                        index++;

                    }
                }
            }
        }
        public static bool IfBoardValid(Board b)
        {
            for(int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    if (b.Bboard[i,j] != 0)
                    {
                        if (IfBoardValidHelper(b, j, i) == false)
                            return false;
                    }
                }
            }
            return true;
        }

        public static bool IfBoardValidHelper(Board b, int c, int r)
        {
            for (int i = 0; i < 9; i++) //scan cols
                if (i != r)
                    if (b.Bboard[i, c] == b.Bboard[r, c])
                        return false;
            for (int i = 0; i < 9; i++) //scan rows
                if (i != c)
                    if (b.Bboard[r, i] == b.Bboard[r, c])
                        return false;

            for (int i = c - (c % 3); i < (3 + c - (c % 3)); i++)  //scan sq
            {
                for (int j = r - (r % 3); j < (3 + r - (r % 3)); j++)
                {
                    if (i != c && j != r)
                        if (b.Bboard[j, i] == b.Bboard[r, c])
                            return false;
                }
            }
            return true;
        }

        public static bool Solve(Board B)
        {
            if(B.counter == 0)
                return true;
            int count = B.counter;
            SolveA(B);
            if (count == B.counter)
                return false;
            else
                Solve(B);

            return true;
        }
        public static bool SolveA(Board B)
        {
            if (B.counter == 0)
                return true;
            int row = B.GetPointerByIndex(B.counter - 1).row;
            int col = B.GetPointerByIndex(B.counter - 1).col;
            B.pointer[B.counter - 1] = null;
            B.counter--;
            for (int i = 1; i <= 9; i++)
            {
                if (B.counter >= 0)
                {
                    B.Bboard[row, col] = i;
                    if (IfBoardValid(B) == true)
                    {
                        if (SolveA(B) == true)
                        {
                            return true;
                        }
                    }

                }
                else
                    return true;
            }
            B.Bboard[row, col] = 0;
            B.counter++;
            B.SetOnePointer(B.counter - 1, row, col);
            return false;

        }

    }
}
