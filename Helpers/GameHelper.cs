using System;
using score_inning.Models;

namespace score_inning.Helpers
{
  public static class GameHelper
  {
    public static void StartInning()
    {
      Inning inning = new Inning();

      Console.WriteLine("Play ball!");
      
      var playsString = Console.ReadLine();
      if (String.IsNullOrEmpty(playsString))
      {
        Console.WriteLine("You must enter comma separated plays");
        return;
      }

      String[] plays = playsString.Split(',');
      foreach (string play in plays)
      {
        inning = ScoreHelper.ScorePlay(play, inning);
      }

      Console.WriteLine(inning.ToString());
    }
  }
}