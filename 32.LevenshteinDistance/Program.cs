using System;

namespace _32.LevenshteinDistance
{
    class Program
    {
        static void Main(string[] args)
        {
			LevenshteinDistance("gumbo", "gambol");			
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

		
		
	}
}
