using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace HangmanInC_
{
    public class PlayGame 
    {
        static readonly int INDEX_OF_COUNTRY = 0;
        static readonly int INDEX_OF_CAPITAL = 1;
        static readonly int INDEX_OF_GUESSING_COUNT = 3;
        static int lifeCount = 10;
        static int indexOfDraw = 0;
        static Stopwatch timeBegin;
        static int guessingCount = 0; 
        static HashSet<String> notInWord = new HashSet<String>();

        public static void main(String[] args) 
        {
            
        }

        public static void initGame()
        {
            clearScreen();
            notInWord.Clear();
            lifeCount = 10;
            indexOfDraw = 0;
            
            List<String> countryAndCapital = new List<String>();
            List<List<String>> listCountrysAndCapitals = new List<List<String>>();
            List<List<String>> listWin = new List<List<String>>();
            String capital = "";

            List<String> draws = new List<String>();
            draws = drawToArray();
            
            StreamReader dataFromFile = FileOperation.OpenFile("countries_and_capitals.txt");
            listCountrysAndCapitals = FileOperation.ScannertoArray(dataFromFile, false);
            countryAndCapital = PrepareToGame.RandomCapitalsAndCountry(listCountrysAndCapitals);
            capital = countryAndCapital[INDEX_OF_CAPITAL];
            char[] capitalDash = PrepareToGame.MakeDashWord(capital);

            StreamReader dataFromListWin = FileOperation.OpenFile("win_list.txt");
            listWin = FileOperation.ScannertoArray(dataFromListWin, true);

            startGame(countryAndCapital, capitalDash, listWin, draws);
        }

        public static void winGame(List<String> countryAndCapital, List<List <String>> listWin)
        {
            long timeEnd = stopTime(timeBegin);
            gameWinScreen(timeEnd, guessingCount);

            String name = insertName();

            DateTime actualDate = DateTime.Now;
            String date = actualDate.ToString();
            String stringTimeEnd = timeEnd.ToString();
            String stringGuessingCount = guessingCount.ToString();
            String capital = countryAndCapital[INDEX_OF_CAPITAL];

            List<String> newScoreUser = new List<String>();
            newScoreUser.Add(name);
            newScoreUser.Add(date);
            newScoreUser.Add(stringTimeEnd);
            newScoreUser.Add(stringGuessingCount);
            newScoreUser.Add(capital);

            listWin = newHighScore(listWin, newScoreUser);
            FileOperation.SaveToFile(FileOperation.ArrayToString(listWin), "win_list.txt");

            displayHighscores();
        }

        public static void startGame(List<String> countryAndCapital, char[] capitalDash, List<List <String>> listWin, List<String> draws)
        {
            timeBegin = startTime();
            bool gameWin = true;
            bool isRun = true;
            while (isRun)
            {
                gameWin = playGame(countryAndCapital, capitalDash, draws);
                if (gameWin)
                {
                    winGame(countryAndCapital, listWin);
                    isRun = false;
                }
                if (lifeCount <= 0)
                {
                    isRun = false;
                }
                
            }
            if (!gameWin)
            {
                displayHighscores();
                gameLoseScreen();
            }
            
        }

        public static bool playGame(List<String> countryAndCapital, char[] dashedWord, List<String> draws)
        {
            bool foundLetter = false;
            bool foundWord = false;

            String letterOrWord;

            String capital = countryAndCapital[INDEX_OF_CAPITAL];
            capital = capital.ToUpper();

            displayUser(countryAndCapital, dashedWord, lifeCount);

            letterOrWord = insertLetterOrWord();

            guessingCount += 1;

            if (letterOrWord.Length > 2)
            {
                foundWord = FindLetter.CheckWordInText(capital, letterOrWord);
                foundLetter = true;
                if (!foundWord)
                {
                    lifeCount -= 2;
                    indexOfDraw++;
                    notInWord.Add(letterOrWord);
                    displayDraw(draws);
                }
                else
                {
                    return true;
                }
            }
            else
            {
                foundLetter = FindLetter.CheckLetterInText(capital, letterOrWord);
                dashedWord = FindLetter.CheckLetterInText(capital, dashedWord, letterOrWord);
                foundWord = hasWord(dashedWord);

                clearScreen();
                
                if (foundWord)
                {
                    return true;
                }
            }


            if(foundLetter == false)
            {
                if (!(notInWord.Contains(letterOrWord)))
                {
                    displayDraw(draws);
                    lifeCount -= 1;
                    notInWord.Add(letterOrWord);
                }
                else
                {
                    clearScreen();
                }
            }

            return false;
            //inputUser.close();
        }

        public static bool hasWord(char[] checkWord)
        {
            foreach(char sign in checkWord)
            {
                if(sign == '_')
                {
                    return false;
                }
            }
            return true;
        }

        public static Stopwatch startTime()
        {
            Stopwatch sw = Stopwatch.StartNew();
            return sw;
        }

        public static long stopTime(Stopwatch sw)
        {
            sw.Stop();
            TimeSpan ts = sw.Elapsed;

            return Convert.ToInt64(ts.TotalSeconds);
        }

        public static List<List<String>> newHighScore(List<List<String>> listWin, List <String> newTheBestUser)
        {
            int countGessing = Int16.Parse(newTheBestUser[INDEX_OF_GUESSING_COUNT]);
            int checkCount;
            int index = 0;

            foreach (List<String> row in listWin)
            {
                checkCount = Int16.Parse(row[INDEX_OF_GUESSING_COUNT]);
                if (countGessing < checkCount)
                {
                    listWin.Insert(index, newTheBestUser);
                    break;
                }
                index++;
            }
            if (listWin.Count > 10)
            {
                listWin.RemoveAt(10); //remove excess element
            }

            
            return listWin;

        }
        public static String insertLetterOrWord()
        {
            Console.WriteLine("Please insert word or leter: ");
            string letterOrWord = Console.ReadLine();  // Read user input
            letterOrWord = letterOrWord.ToUpper();

            return letterOrWord;
        }

        public static String insertName()
        {
            Console.WriteLine("Please insert your name: ");
            string name = Console.ReadLine(); // Read user input
            return name;
        }

        public static List<String> drawToArray()
        {
            StreamReader drawFile = FileOperation.OpenFile("draws.txt");
            List<String> draws = new List<String>();
            draws = FileOperation.Draw(drawFile);
            return draws;
        }

        public static void displayHint(List<String> arrayCapitalCountry)
        {
            Console.WriteLine("It's the capital of: ");
            Console.WriteLine(arrayCapitalCountry[INDEX_OF_COUNTRY]);
        }

        public static void displayUser(List<String> arrayCapitalCountry, char[] dashedWord, int lifeCount)
        {
            String dashedString = new String(dashedWord);
            Console.WriteLine("Wrong word:");
            foreach(String notIn in notInWord)
            {
                Console.Write(" " + notIn);
            }
            Console.WriteLine("\nCapital - " + dashedString + "\tlife - " + lifeCount);
            if (lifeCount == 1)
            {
                displayHint(arrayCapitalCountry);
            }
        }


        public static void gameWinScreen(long timeEnd, int guessingCount)
        {
            Console.WriteLine("Congratulations! You Win! Your time is " + timeEnd 
                                + " second and you guessed after " + guessingCount + " attempts" );
        }

        public static void gameLoseScreen()
        {
            Console.WriteLine("I\'m so sorry, but you died... Try in next life." );
        }

        public static void clearScreen() {  
            Console.Clear(); 
        }
        
        public static void displayHighscores()
        {
            clearScreen();
            StreamReader dataFromListWin = FileOperation.OpenFile("win_list.txt");  
            Console.WriteLine(FileOperation.ArrayToString(FileOperation.ScannertoArray(dataFromListWin, true)));
        }

        public static void displayDraw(List<String> draws)
        {
            clearScreen();
            Console.WriteLine(draws[indexOfDraw]);
            indexOfDraw++;
        }
    }
}
