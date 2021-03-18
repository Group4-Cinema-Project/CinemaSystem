using System;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;

namespace Kaleidoscope
{
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        //writeToJson();
        //readFromJson();
      }
      catch (Exception e)
      {
        Console.WriteLine("ERROR: " + e.Message);
      }

      drawStartScreen();
      askUserInput();
    }


    static void askUserInput()
    {
      Console.WriteLine("Vul het nummer in van het scherm die u wilt bereiken en druk op ENTER.");
      int input = Int32.Parse(Console.ReadLine());
      Debug.WriteLine(input);

      int switchCase = input;
      switch (switchCase)
      {
        case 1:
          Console.WriteLine("Case 1");
          Console.Clear();
          drawOptionScreen(switchCase);
          break;
        case 2:
          Console.WriteLine("Case 2");
          Console.Clear();
          drawOptionScreen(switchCase);
          break;
        case 3:
          Console.WriteLine("Case 3");
          Console.Clear();
          drawOptionScreen(switchCase);
          break;
        default:
          Console.WriteLine("Sorry, deze optie bestaat niet! Probeer het opnieuw.\n\n");
          askUserInput();
          break;
      }
    }

    static void drawStartScreen()
    {
      drawLogo();
      Console.WriteLine("1) Derp\n" +
                        "2) Dorp\n" +
                        "3) Darp");
    }

    static void drawLogo() 
    {
      Console.WriteLine("==================================================================");
      Console.WriteLine(@"||   _  __     _      _     _                                   ||");
      Console.WriteLine(@"||  | |/ /    | |    (_)   | |                                  ||");
      Console.WriteLine(@"||  | ' / __ _| | ___ _  __| | ___  ___  ___ ___  _ __   ___    ||");
      Console.WriteLine(@"||  |  < / _` | |/ _ \ |/ _` |/ _ \/ __|/ __/ _ \| '_ \ / _ \   ||");
      Console.WriteLine(@"||  | . \ (_| | |  __/ | (_| | (_) \__ \ (_| (_) | |_) |  __/   ||");
      Console.WriteLine(@"||  |_|\_\__,_|_|\___|_|\__,_|\___/|___/\___\___/| .__/ \___|   ||");
      Console.WriteLine(@"||                                               | |            ||");
      Console.WriteLine(@"||                                               |_|            ||");
      Console.WriteLine("==================================================================");
      Console.WriteLine(" ");
      Console.WriteLine(" ");
      Console.WriteLine(" ");
    }

    static void drawOptionScreen(int screenIndex) 
    {
      drawLogo();
      Console.WriteLine($"Welcome to screen {screenIndex}!");
      Console.ReadLine();
    }

    static void writeToJson()
    {
      //TODO: Make the path string universal
      //Overwrites the item when you use the ID of the item you want to overwrite!

      UserInfo userInfo = new UserInfo { ID = 1, UserName = "Iemand" };

      File.WriteAllText(@"D:\Hogeschool Rotterdam\Project\Project B\Kaleidoscope\Kaleidoscope\Kaleidoscope\jsonTest.json", JsonConvert.SerializeObject(userInfo, Formatting.Indented));

      using (StreamWriter file = File.CreateText(@"D:\Hogeschool Rotterdam\Project\Project B\Kaleidoscope\Kaleidoscope\Kaleidoscope\jsonTest.json"))
      {
        JsonSerializer serializer = new JsonSerializer();
        serializer.Serialize(file, userInfo);
      }
    }

    static void readFromJson()
    {
      UserInfo userInfo1 = JsonConvert.DeserializeObject<UserInfo>(File.ReadAllText(@"D:\Hogeschool Rotterdam\Project\Project B\Kaleidoscope\Kaleidoscope\Kaleidoscope\jsonTest.json"));
      using (StreamReader file = File.OpenText(@"D:\Hogeschool Rotterdam\Project\Project B\Kaleidoscope\Kaleidoscope\Kaleidoscope\jsonTest.json"))
      {
        JsonSerializer serializer = new JsonSerializer();
        UserInfo userInfo2 = (UserInfo)serializer.Deserialize(file, typeof(UserInfo));
        Console.WriteLine(userInfo2.ID);
        Console.WriteLine(userInfo2.UserName);
      }
    }
  }

  class UserInfo
  {
    //TODO: Add more items for the Json
    public int ID { get; set; }
    public string UserName { get; set; }
  }
}
