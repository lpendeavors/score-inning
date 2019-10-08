using score_inning.Models;

namespace score_inning.Helpers
{
  public static class ScoreHelper
  {
    public static Inning ScorePlay(string play, Inning inning)
    {
      var scoredInning = inning;

      switch (play) {
        case "out":
          scoredInning.AddOut();
          break;
        case "k":
          scoredInning.AddK();
          break;
        case "1b":
          scoredInning.AddHit(1);
          break;
        case "2b":
          scoredInning.AddHit(2);
          break;
        case "3b":
          scoredInning.AddHit(3);
          break;
        case "hr":
          scoredInning.AddHR();
          break;
        case "e":
          scoredInning.AddE();
          break;
        case "bb":
          scoredInning.AddBB();
          break;
        case "hbp":
          scoredInning.AddHBP();
          break;
        default:
          break;
      }

      return scoredInning;
    }
  }
}