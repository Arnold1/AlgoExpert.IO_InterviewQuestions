using System;

namespace _32.LevenshteinDistance
{
    class Program
    {
        static void Main(string[] args)
        {
			//LevenshteinDistance("gumbo", "gambol");
			LevenshteinDistanceExpertSolution("gumbo", "gambol");

		}

		public static int LevenshteinDistance(string str1, string str2)
		{
			int changes = 0;

			if (str1 == str2) { return 0; }

			if (str1.Length == 0) { return str2.Length; }

			for (int i = 0; i < str2.Length; i++)
			{
				if (i < str1.Length && str1[i] == str2[i]) { continue; }

				if (str1.Length < str2.Length)
				{
					str1 = str1.Insert(i, str2[i].ToString());
					changes++;
				}
				else if (str1.Length > str2.Length)
				{
					str1 = str1.Remove(i, 1);
					changes++;
				}
				else if (str1.Length == str2.Length)
				{
					char[] temp = str1.ToCharArray();
					temp[i] = str2[i];
					str1 = new string(temp);
					//str1 = str1.Replace(str1[i], str2[i]);
					changes++;
				}



			}
			return changes;
		}

		public static int LevenshteinDistanceExpertSolution(string str1, string str2)
        {
			// Time O(nm) where is is the lenght on str1 and m is the length of str2
			// Space O(nm)

			// Still not 100% on this need to revisit

			int[,] edits = new int[str2.Length + 1, str1.Length + 1];
            for (int i = 0; i < str2.Length + 1; i++)
            {
                for (int j = 0; j < str1.Length + 1; j++)
                {
					edits[i, j] = j;
                }
				edits[i, 0] = i;
            }

            for (int i = 1; i < str2.Length + 1; i++)
            {
                for (int j = 1; j < str1.Length + 1; j++)
                {
					if(str2[i -1] == str1[j - 1])
                    {
						edits[i, j] = edits[i - 1, j - 1];
                    }
                    else
                    {
						edits[i, j] = 1 + Math.Min(edits[i - 1, j - 1], 
							Math.Min(edits[i - 1, j], 
							edits[i, j - 1]));
                    }
                }
            }
            

            
			return edits[str2.Length, str1.Length];
        }


	}
}
