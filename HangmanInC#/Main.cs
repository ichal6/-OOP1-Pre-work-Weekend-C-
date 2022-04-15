using System;
using System.IO;


namespace HangmanInC_
{
    public class Menu 
    {
        public static void Main(string[] args) 
        {
            Console.WriteLine("Welcome to Hangman! Save the world from SKYNET!");
            mainMenu();
        }

        public static void mainMenu()
        {
            bool IsRun = true;
            while (IsRun)
            {
                Console.WriteLine("(S)tart\n(H)igh scores\n(E)xit");
                string ChooseUser = Console.ReadLine();  // Read user input
                ChooseUser = ChooseUser.ToUpper();
                switch(ChooseUser[0])
                {
                    case 'S':
                        PlayGame.initGame();
                        break;
                    case 'H':
                        StreamReader dataFromListWin = FileOperation.OpenFile("win_list.txt");  
                        Console.Write(FileOperation.ArrayToString(FileOperation.ScannertoArray(dataFromListWin, true)));
                        break;
                    case 'E':
                        IsRun = false;
                        break;
                    default:
                        Console.WriteLine("You press wrong input. Please try again");
                        break;
                }
            }

        }


    }

}