namespace MooGame.DataAccess;

public class HighscoreManager
{


    public void GetHighscore()
    {
        // implementation here, maybe rename to ReadHighscore
    }

    public void AddHighscore()
    {
        //implementation here
    }


}

//public static void DisplayHighscore()
//{

//    StreamReader input = new StreamReader("result.txt"); //store as json instead
//    List<PlayerData> results = new List<PlayerData>();
//    string line;
//    while ((line = input.ReadLine()) != null)
//    {

//        string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None); //weird to store name and score as array and not separate datatypes
//        string name = nameAndScore[0];
//        int guesses = Convert.ToInt32(nameAndScore[1]);

//        PlayerData pd = new PlayerData(name, guesses);
//        int pos = results.IndexOf(pd);
//        if (pos < 0)
//        {
//            results.Add(pd);
//        }
//        else
//        {
//            results[pos].Update(guesses);
//        }


//    }


//    results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
//    Console.WriteLine("Player   games average");
//    foreach (PlayerData p in results)
//    {
//        Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.GamesPlayed, p.Average()));
//    }
//    input.Close();
//}
//}
