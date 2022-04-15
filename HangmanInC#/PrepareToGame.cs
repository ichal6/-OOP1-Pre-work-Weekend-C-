using System;
using System.Collections.Generic;

namespace HangmanInC_
{

    public class PrepareToGame 
    {

        public static List<String> RandomCapitalsAndCountry(List<List<String>> arrayCountriesAndCapitals)
        {
            List<String> arrayRow = new List<String>();

            Random rand = new Random();

            int lengthList = arrayCountriesAndCapitals.Count;
            int index = rand.Next(lengthList);

            arrayRow = arrayCountriesAndCapitals[index];
            return arrayRow;
        }

        public static char[] MakeDashWord(String capital)
        {
            String capitalDash = "";
            foreach(char sign in capital)
            {
                if(sign == ' ')
                {
                    capitalDash = String.Concat(capitalDash, " ");
                }
                else
                {
                    capitalDash = String.Concat(capitalDash, "_");
                }
                
            }
            
            char[] capitalDashArray = capitalDash.ToCharArray();

            return capitalDashArray;
        }
    }
}