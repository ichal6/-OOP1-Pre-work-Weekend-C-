using System;

public class Kata
{

  public static void Main(string[] args)
  {
    Console.WriteLine(DuplicateCount("184194175187193184182198177185200178169203190177201184204165"));
  }
  public static int DuplicateCount(string str)
  {
    if(str.Length == 0)
    {
      return 0;
    }
    str = str.ToLower();
    char checkChar = str[0];
    str = str.Remove(0, 1); //Remove a check char from the string
    int index = 0;
    int countDuplicate = 0;
    bool foundDuplicate = false;

    while(str.Length > 0) //Cotinue util the string is not empty
    {
      while(str.Length > index) //Search char until end of string
      {
        if(checkChar == str[index]) 
        {
          if(foundDuplicate == false)
          {
            countDuplicate++;
            foundDuplicate = true;
            str = str.Remove(index, 1); //Remove found a char from the string
          }
          else
          {
          str = str.Remove(index, 1); //Remove found a char from the string
          }
        }
        else
        {
          index++;
        }
      }
      if(str.Length > 0)
      {
        checkChar = str[0]; 
        str = str.Remove(0, 1); //Remove a check char from the string 
        foundDuplicate = false;
        index = 0;
      }
       
    }

    return countDuplicate;
  }
}