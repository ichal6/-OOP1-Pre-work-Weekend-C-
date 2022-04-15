using System;

namespace HangmanInC_
{

    public class FindLetter 
    {

        public static bool CheckWordInText(String capital, String letterOrWord)
        {
            if (capital == letterOrWord)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static char[] CheckLetterInText(String capital, char[] capitalDash, String letterOrWord)
        {
            char[] capital_array = capital.ToCharArray();
            int index = 0;
            if (letterOrWord.Length <= 0)
            {
                return capitalDash;
            }
            foreach (char charInCapital in capital_array)
            {
                if (charInCapital == letterOrWord[0])
                {
                    capitalDash[index] = letterOrWord[0];
                }
                index += 1;
            }
            return capitalDash;
        }

        public static bool CheckLetterInText(String capital, String letterOrWord)
        {
            char[] capital_array = capital.ToCharArray();
            if (letterOrWord.Length <= 0)
            {
                return false;
            }
            foreach (char charInCapital in capital_array)
            {
                if (charInCapital == letterOrWord[0])
                {
                    return true;
                }
            }
            return false;
        }
    }

}