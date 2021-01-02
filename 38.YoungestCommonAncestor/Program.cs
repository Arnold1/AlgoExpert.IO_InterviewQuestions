using System;
using System.Collections.Generic;

namespace _38.YoungestCommonAncestor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Time O(D) where D is the depth
            // Space O(1)

            // Code works but have not created the ancestaral tree to test it here. Works on Algoexpert.
            
        }
        public static AncestralTree GetYoungestCommonAncestor(AncestralTree topAncestor, AncestralTree descendantOne, AncestralTree descendantTwo)
        {
            int depthOne = GetDescendantDepth(descendantOne, topAncestor);
            int depthTwo = GetDescendantDepth(descendantTwo, topAncestor);

            if(depthOne > depthTwo)
            {
                return BackTrackAncestralTree(descendantOne, descendantTwo, depthOne - depthTwo);
            }
            else
            {
                return BackTrackAncestralTree(descendantTwo, descendantOne, depthTwo - depthOne);
            }
        }

        public static AncestralTree BackTrackAncestralTree(AncestralTree lowerDescendant, AncestralTree higherDescendant, int diff)
        {
            while(diff > 0)
            {
                lowerDescendant = lowerDescendant.ancestor;
                diff--;
            }

            while(lowerDescendant != higherDescendant)
            {
                lowerDescendant = lowerDescendant.ancestor;
                higherDescendant = higherDescendant.ancestor;
            }

            return lowerDescendant;
        }

        public static int GetDescendantDepth(AncestralTree descendant, AncestralTree topAncestor)
        {
            int depth = 0;
            while(descendant != topAncestor)
            {
                depth++;
                descendant = descendant.ancestor;
            }
            return depth;
        }
     }

    public class AncestralTree
    {
        public char name;
        public AncestralTree ancestor;

        public AncestralTree(char name)
        {
            this.name = name;
            this.ancestor = null;
        }


    }
}
