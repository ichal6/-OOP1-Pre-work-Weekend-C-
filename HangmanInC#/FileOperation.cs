using System;
using System.IO;
using System.Collections.Generic;

namespace HangmanInC_
{

    public class FileOperation
    {
        public static StreamReader OpenFile(string filename)
        {
            StreamReader data = null;

            try 
            {
                data = new StreamReader(filename);
            }
            catch ( IOException e) 
            {
                Console.WriteLine("Sorry but I was unable to open your data file");
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }
            return data;
        }

        public static void SaveToFile(String dataToSave, String filename)
        {
            
            File.WriteAllText(filename, dataToSave);
            
        }

        public static List<List<String>> ScannertoArray(StreamReader dataFromFile, bool listWin)
        {
            List<List<String>> arrayCountriesAndCapitals = new List<List<String>>();
            String newRow = "";
            String country, capitals;
            while(dataFromFile.Peek() > -1) 
            {
                List<String> ArrayRow = new List<String>();
                newRow = dataFromFile.ReadLine();
                newRow = newRow.ToUpper();
                String[] parts = newRow.Split("|");
                if(listWin)
                {
                    ArrayRow.Add(parts[0].Substring(0, parts[0].Length - 1)); //remove last char
                    ArrayRow.Add(parts[1].Substring(1, parts[1].Length - 2)); //remove first and last char
                    ArrayRow.Add(parts[2].Substring(1, parts[2].Length - 2)); //remove first and last char
                    ArrayRow.Add(parts[3].Substring(1, parts[3].Length - 2)); //remove first and last char
                    ArrayRow.Add(parts[4].Substring(1, parts[4].Length - 1)); //remove first char
                }
                else
                {
                    country = parts[0].Substring(0, parts[0].Length - 1); //remove last char
                    capitals = parts[1].Substring(1, parts[1].Length - 1); //remove first char
                    ArrayRow.Add(country);
                    ArrayRow.Add(capitals);
                }
                arrayCountriesAndCapitals.Add(ArrayRow);
            
            }
            return arrayCountriesAndCapitals;
        }

        public static String ArrayToString(List<List<String>> listWin)
        {
            String formatData = "";
            foreach(List<String> user in listWin)
            {
                formatData += String.Format("{0} | {1} | {2} | {3} | {4}\n", user[0], user[1], user[2], user[3], user[4]);
            }
            return formatData;
        }

        public static List <String> Draw(StreamReader dataFromFile)
        {
            List<String> arrayDraw = new List<String>();
            String newRow = "";
            String newDraw = "";
            while(dataFromFile.Peek() > -1) 
            {
                newRow = dataFromFile.ReadLine();
                if(newRow == "?")
                {
                    arrayDraw.Add(newDraw);
                    newRow = "";
                    newDraw = "";
                }
                newDraw += newRow + "\n";
            
            }
            return arrayDraw;
        }
    }

}