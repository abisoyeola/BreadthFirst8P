using System;
using System.Collections.Generic;
using System.Text;

namespace DPS
{
    class UninformedSearch
    {
        public UninformedSearch()
        {

        }

        public List<Node> BreadthFirstSearch(Node root)
        {
            List<Node> PathToSolution = new List<Node>();
            List<Node> OpenList = new List<Node>();
            List<Node> ClosedList = new List<Node>();


            OpenList.Add(root);
            bool goalFound = false;

            while(OpenList.Count > 0 && !goalFound)
            {
                Node currentNode = OpenList[0];
                ClosedList.Add(currentNode);
                OpenList.RemoveAt(0);

                currentNode.ExpandNode();
               //currentNode.printPuzzle();

                for (int i=0; i < currentNode.children.Count; i++ )
                {
                    Node currentChild = currentNode.children[i];
                    if (currentChild.goalTest())
                    {
                        Console.WriteLine("Goal Found!..");
                        goalFound = true;
                        //Trace path to root node
                        PathTrace(PathToSolution, currentChild);
                    }

                    if (!Contains(OpenList,currentChild) && !Contains(ClosedList, currentChild))
                    {
                        OpenList.Add(currentChild);
                    }
                }
            }

            return PathToSolution;
        }
        public void PathTrace(List<Node> path, Node n)
        {
            Console.WriteLine("Tracing Path...");
            Node current = n;
            path.Add(current);
            while (current.parent !=null)
            {
                current = current.parent;
                path.Add(current);
            }
        }
        public static bool Contains(List<Node> list, Node c)
        {
            bool contains = false;

            for(int i=0; i < list.Count; i++)
            {
                if(list[i].isSamePuzzle(c.puzzle))
                {
                    contains = true;
                }
            }
                
            return contains;
        }
    }
}
