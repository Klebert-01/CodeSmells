namespace MooGame;

using GameResources;
using System;
using System.Collections.Generic;
using System.IO;

class MainClass
{

    public static void Main(string[] args)
        {

        bool playOn = true;

        #region TakeUserInput
            Console.WriteLine("Enter your user name:\n"); //extract to method returning string
            string name = Console.ReadLine();
        #endregion

        while (playOn)
            {
                
                string goal = MooGameLogic.makeGoal();


                Console.WriteLine("New game:\n");
                //comment out or remove next line to play real games!
                Console.WriteLine("For practice, number is: " + goal + "\n");
                string guess = Console.ReadLine();  // TODO parse to int directly

                int nGuess = 1;
                string bbcc = MooGameLogic.checkBC(goal, guess);
                Console.WriteLine(bbcc + "\n");
                while (bbcc != "BBBB,")
                {
                    nGuess++;
                    guess = Console.ReadLine();
                    Console.WriteLine(guess + "\n");
                    bbcc = MooGameLogic.checkBC(goal, guess);
                    Console.WriteLine(bbcc + "\n");
                }
                StreamWriter output = new StreamWriter("result.txt", append: true);
                output.WriteLine(name + "#&#" + nGuess);
                output.Close();
                showTopList();
                Console.WriteLine("Correct, it took " + nGuess + " guesses\nContinue?");
                string answer = Console.ReadLine();
                if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
                {
                    playOn = false;
                }
            }
        }


        static void showTopList() //method for getting and writing highscores
    {

        StreamReader input = new StreamReader("result.txt");
            List<PlayerData> results = new List<PlayerData>();
            string line;
            while ((line = input.ReadLine()) != null)   
            {

                string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None); //weird to store name and score as array and not separate datatypes
                string name = nameAndScore[0];
                int guesses = Convert.ToInt32(nameAndScore[1]);

                PlayerData pd = new PlayerData(name, guesses);
                int pos = results.IndexOf(pd);
                if (pos < 0)
                {
                    results.Add(pd);
                }
                else
                {
                    results[pos].Update(guesses);
                }


            }


        results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
            Console.WriteLine("Player   games average");
            foreach (PlayerData p in results)
            {
                Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NGames, p.Average()));
            }
            input.Close();
        }
    }

