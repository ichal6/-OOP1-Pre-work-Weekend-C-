using System;

namespace Character_Counter
{
  public class CharacterCounter 
  {
    public static void Main(string[] args)
    {
      Console.WriteLine(ValidateWord("abcab??!cdd??"));
    }

    public static bool ValidateWord(string word) 
    {
      bool isNotEnd = true;
      word = word.ToLower();
      char[] wordAsChar = word.ToCharArray();
      int indexChar = 0;
      while(isNotEnd){
        char firstChar = wordAsChar[indexChar];
        char secondChar = wordAsChar[0];
        int countFirstChar = 0;
        int countSecondChar = 0;
        foreach(char oneChar in word.ToCharArray() )
        {
          if(oneChar == firstChar){
            countFirstChar++;
          }
          else{
            secondChar = oneChar;
          }
        }

        foreach(char oneChar in word.ToCharArray() )
        {
          if(oneChar == secondChar){
            countSecondChar++;
          }
        }

        if(countFirstChar != countSecondChar)
        {
          return false;
        }
        else{
          indexChar++;
          if(word.Length <= indexChar)
          {
            isNotEnd = false;
          }
        }
      }
      return true;
    }
  }
}
