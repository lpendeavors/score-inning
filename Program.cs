using System;
using score_inning.Helpers;

namespace score_inning
{
  class Program
  {
    static void Main(string[] args)
    {
      var loop = 1;
      while (loop > 0)
      {
        GameHelper.StartInning();
      }
    }
  }
}