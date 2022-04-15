using System;

namespace InParts
{
    public class InParts 
    {
        public static void Main(String[] args)
        {
            Console.WriteLine(SplitInParts("supercalifragilisticexpialidocious", 3));
        }

        public static String SplitInParts(String s, int partLength) 
        {
            int lengthString = s.Length;
            for(int cutPosition = partLength; cutPosition < lengthString; cutPosition += partLength)
            {
                s = s.Insert(cutPosition, " ");
                cutPosition++;
                lengthString = s.Length;
            }
            
            return s;
        }
    }
}
