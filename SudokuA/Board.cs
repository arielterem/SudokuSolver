using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SudokuA
{
    public class Board
    {
        public int[,] Bboard = new int[9, 9];
        public int counter; //count amount of 0(numbers) in array
        public PointerNode[] pointer = new PointerNode[81];

        public void SetBoard(int[,] b)
        {
            Bboard = b; //insert array to array
            int index = 0; //insert indexs to pointers array
            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    if (Bboard[r, c] == 0)
                    {
                        SetOnePointer(index, r, c);
                        index++;
                    }
                }
            }
            SetCounter(index); //set counter
        }

        public int SetCounter(int num)
        {
            counter = num;
            return counter;
        }
        public int CounterAdd1()
        {
            counter++;
            return counter;
        }
        public int GetCounter()
        {
            counter++;
            return counter;
        }
        public void ResetPointer()
        {
            for(int i = 0; i < pointer.Length; i++)
                pointer[i] = null;
        }
        public void SetOnePointer(int index, int r, int c)
        {
            PointerNode pn = new PointerNode();
            pn.SetPointer(r, c);
            pointer[index] = pn;
        }
        public PointerNode[] GetPointer()
        {
            return pointer;
        }
        public PointerNode GetPointerByIndex(int index)
        {
            return pointer[index];
        }
        
        public void Print()
        {

            int[,] grid = { { 0, 0, 0, 0, 9, 0, 1, 0, 6 }, //REAL
                            { 3, 1, 0, 0, 0, 5, 0, 0, 0 },
                            { 0, 0, 5, 0, 0, 0, 0, 7, 0 },
                            { 6, 0, 0, 0, 0, 0, 2, 4, 0 },
                            { 0, 9, 0, 0, 7, 0, 0, 6, 8 },
                            { 0, 3, 2, 0, 0, 0, 0, 0, 1 },
                            { 0, 5, 0, 0, 0, 0, 4, 1, 0 },
                            { 0, 6, 0, 5, 0, 0, 0, 8, 2 },
                            { 4, 0, 1, 0, 8, 0, 0, 0, 0 } };

            //{ { 3, 0, 6, 5, 0, 8, 4, 0, 0 }, //REAL
            //            { 5, 2, 0, 0, 0, 0, 0, 0, 0 },
            //            { 0, 8, 7, 0, 0, 0, 0, 3, 1 },
            //            { 0, 0, 3, 0, 1, 0, 0, 8, 0 },
            //            { 9, 0, 0, 8, 6, 3, 0, 0, 5 },
            //            { 0, 5, 0, 0, 9, 0, 6, 0, 0 },
            //            { 1, 3, 0, 0, 0, 0, 2, 5, 0 },
            //            { 0, 0, 0, 0, 0, 0, 0, 7, 4 },
            //            { 0, 0, 5, 2, 0, 6, 3, 0, 0 }
        //};

            for (int i = 0; i < 9; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    if (Bboard[i, j] != 0 )
                    {
                        if(grid[i, j] != 0)
                            Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(String.Format("{0,-2}", Bboard[i, j]));
                    }
                    else
                        Console.Write(String.Format("{0,-2}", " "));
                    Console.ResetColor();
                    if ((j + 1) % 3 == 0 && j != 8)
                        Console.Write(String.Format("{0,-2}", "| "));
                }
                Console.WriteLine();
                if ((i + 1) % 3 == 0 && i != 8)
                    Console.WriteLine("----------------------");
            }
        }

        public void PrintPointers()
        {
            for(int i = 0; i < counter; i++)
            {
                Console.Write(i + " > " + pointer[i].row + "," + pointer[i].col + " | ");
            }
            Console.WriteLine();
        }
    }

    public class PointerNode
    {
        public int row;
        public int col;

        public void SetRow(int r)
        {
            row = r;
        }
        public void SetCol(int c)
        {
            col = c;
        }
        public int GetRow()
        {
            return row;
        }
        public int GetCol()
        {
            return col;
        }
        public void SetPointer(int r, int c)
        {
            row = r;
            col = c;
        }
        public PointerNode GetPointer()
        {
            PointerNode p = new PointerNode();
            p.SetRow(GetRow());
            p.SetCol(GetCol());
            return p;
        }
    }

    
}
