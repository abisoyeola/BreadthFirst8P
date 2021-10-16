using System;
using System.Collections.Generic;
using System.Text;

namespace DPS
{
    class Node
    {
        public List<Node> children = new List<Node>();
        public Node parent;
        public int[] puzzle = new int[9];
        int x = 0;
        int col = 3;

        public Node (int [] p)
        {
            setPuzzle(p);
        }

        public void setPuzzle(int[] p)
        {
            for(int i=0; i < puzzle.Length; i++)
            {
                this.puzzle[i] = p[i];
            }
        }

        public bool goalTest()
        {
            bool isGoal = true;
            int m = puzzle[0];

            for(int i=1; i < puzzle.Length; i++)
            {
                if(m > puzzle[i])
                {
                    isGoal = false;
                }
                m = puzzle[i];
            }

            return isGoal;

        }

        public void ExpandNode()
        {
            for(int i=0; i < puzzle.Length; i++)
            {
                if (puzzle[i] == 0)
                {
                    x = i;
                }

            }
                MoveRight(puzzle, x);
                MoveLeft(puzzle, x);
                MoveUp(puzzle, x);
                MoveButtom(puzzle, x);
        }

        public void MoveRight(int[] p, int i)
        {
            if (i%col < col-1)
            {
                int[] pc = new int[9];
                copyPuzzle(pc, p);

                int temp = pc[i  + 1];
                pc[i + 1] = p[i];
                pc[i] = temp;

                Node child = new Node(pc);

                children.Add(child);
                child.parent = this;
            }
        }
        public void MoveLeft(int[] p, int i)
        {
            if (i % col > 0)
            {
                int[] pc = new int[9];
                copyPuzzle(pc, p);

                int temp = pc[i - 1];
                pc[i - 1] = pc[i];
                pc[i] = temp;

                Node child = new Node(pc);
                children.Add(child);
                child.parent = this;

            }
        }
        public void MoveUp(int[] p, int i)
        {
            if (i-col >=0)
            {
                int[] pc = new int[9];
                copyPuzzle(pc, p);

                int temp = pc[i - 3];
                pc[i - 3] = pc[i];
                pc[i] = temp;

                Node child = new Node(pc);
                children.Add(child);
                child.parent = this;
            }

        }
        public void MoveButtom(int[] p, int i)
        {
            if (i + col <puzzle.Length)
            {
                int[] pc = new int[9];
                copyPuzzle(pc, p);

                int temp = pc[i + 3];
                pc[i + 3] = pc[i];
                pc[i] = temp;

                Node child = new Node(pc);
                children.Add(child);
                child.parent = this;
            }
        }

        public void printPuzzle()
        {
            Console.WriteLine();
            int m = 0;
            for (int i = 0; i < col; i++)
            {
                for(int j = 0; j < col; j++)
                {
                    Console.Write(puzzle[m] + " ");
                    m++;
                }
                Console.WriteLine();
            }
        }

        public bool isSamePuzzle(int[] p)
        {
            bool samePuzzle = true;
            for(int i = 0; i < p.Length; i++)
            {
                if(puzzle[i] != p[i])
                {
                    samePuzzle = false;
                }
            }
            return samePuzzle;
        }

        public void copyPuzzle(int [] a, int[] b)
        {
            for (int i = 0; i < b.Length; i ++)
            {
                a[i] = b[i];
            }
        }
    }
}
 