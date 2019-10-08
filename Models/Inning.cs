using System;

namespace score_inning.Models
{
  public class Inning
  {
    private string Bases;
    private int Outs;
    private int Runs;

    public Inning()
    {
      this.Bases = "000";
      this.Outs = 0;
      this.Runs = 0;
    }

    public override string ToString()
    {
      return String.Format(
        "Bases: {0}, Outs: {1}, Runs: {2}",
        this.Bases,
        this.Outs,
        this.Runs
      );
    }

    public void AddOut()
    {
      this.Outs++;

      if (this.Outs < 3)
      {
        this.AdvanceRunners(false);
      }
    }

    public void AddK()
    {
      this.Outs++;
    }

    public void AddHit(int bases)
    {
      switch (bases)
      {
        case 1:
          if (this.OnFirst())
          {
            if (this.OnSecond())
            {
              if (this.OnThird())
              {
                // 111
                this.Runs++;
              }

              // 110
              this.Bases = "111";
            }
            else
            {
              // 100
              this.Bases = "110";
            }
            break;
          }
          else if (this.OnSecond())
          {
            if (this.OnThird())
            {
              // 011
              this.Runs++;
              this.Bases = "101";
            }
            else
            {
              // 010
              this.Bases = "101";
            }
            break;
          }
          else if (this.OnThird())
          {
            // 001
            this.Runs++;
            this.Bases = "100";
            break;
          }
          else 
          {
            // 000
            this.Bases = "100";
            break;
          }
        case 2:
          if (this.OnFirst())
          {
            if (this.OnSecond())
            {
              if (this.OnThird())
              {
                // 111
                this.Runs++;
                this.Runs++;
                this.Bases = "011";
              }

              // 110
              this.Runs++;
              this.Bases = "011";
            }
            else
            {
              // 100
              this.Bases = "011";
            }
            break;
          }
          else if (this.OnSecond())
          {
            if (this.OnThird())
            {
              // 011
              this.Runs++;
              this.Runs++;
              this.Bases = "010";
            }
            else
            {
              // 010
              this.Runs++;
            }
            break;
          }
          else if (this.OnThird())
          {
            // 001
            this.Runs++;
            this.Bases = "010";
            break;
          }
          else 
          {
            // 000
            this.Bases = "010";
            break;
          }
        case 3:
          if (this.OnFirst())
          {
            if (this.OnSecond())
            {
              if (this.OnThird())
              {
                // 111
                this.Runs++;
                this.Runs++;
                this.Runs++;
                this.Bases = "001";
              }

              // 110
              this.Runs++;
              this.Runs++;
              this.Bases = "001";
            }
            else
            {
              // 100
              this.Runs++;
              this.Bases = "001";
            }
            break;
          }
          else if (this.OnSecond())
          {
            if (this.OnThird())
            {
              // 011
              this.Runs++;
              this.Runs++;
              this.Bases = "001";
            }
            else
            {
              // 010
              this.Runs++;
              this.Bases = "001";
            }
            break;
          }
          else if (this.OnThird())
          {
            // 001
            this.Runs++;
            break;
          }
          else 
          {
            // 000
            this.Bases = "001";
            break;
          }
        default:
          break;
      }
    }

    public void AddHR()
    {
      if (this.OnFirst())
      {
        if (this.OnSecond())
        {
          if (this.OnThird())
          {
            // 111
            this.Runs++;
            this.Runs++;
            this.Runs++;
            this.Runs++;
          }
          else
          {
            // 110
            this.Runs++;
            this.Runs++;
            this.Runs++;
          }
        }

        if (this.OnThird())
        {
          // 101
          this.Runs++;
          this.Runs++;
          this.Runs++;
        }
        else
        {
          // 100
          this.Runs++;
          this.Runs++;
        }
      }
      else if (this.OnSecond())
      {
        if (this.OnThird())
        {
          // 011
          this.Runs++;
          this.Runs++;
          this.Runs++;
        }
        else
        {
          // 010
          this.Runs++;
          this.Runs++;
        }
      }
      else if (this.OnThird())
      {
        // 001
        this.Runs++;
        this.Runs++;
      }
      else
      {
        // 000
        this.Runs++;
      }

      this.Bases = "000";
    }

    public void AddE()
    {
      this.AdvanceRunners(false);
    }

    public void AddBB()
    {
      this.AdvanceRunners(true);
    }

    public void AddHBP()
    {
      this.AdvanceRunners(true);
    }

    private void AdvanceRunners(bool toFirst)
    {
      if (toFirst)
      {
        if (this.OnFirst())
        {
          if (this.OnSecond())
          {
            if (this.OnThird())
            {
              // 111
              this.Runs += 1;
              this.Bases = "111";
            }
            else
            {
              // 110
              this.Bases = "111";
            }
          }

          if (this.OnThird())
          {
            // 101
            this.Bases = "111";
          }
          else
          {
            // 100
            this.Bases = "110";
          }
        }
        else if (this.OnSecond())
        {
          if (this.OnThird())
          {
            // 011
            this.Bases = "111";
          }
          else
          {
            // 010
            this.Bases = "110";
          }
        }
        else if (this.OnThird())
        {
          // 001
          this.Bases = "101";
        }
        else
        {
          this.Bases = "100";
        }
      }
      else
      {
        if (this.OnFirst())
        {
          if (this.OnSecond())
          {
            if (this.OnThird())
            {
              // 111
              this.Runs += 1;
              this.Bases = "011";
            }
            else
            {
              // 110
              this.Bases = "011";
            }
          }

          if (this.OnThird())
          {
            // 101
            this.Runs += 1;
            this.Bases = "010";
          }
          else
          {
            // 100
            this.Bases = "010";
          }
        }
        else if (this.OnSecond())
        {
          if (this.OnThird())
          {
            // 011
            this.Runs += 1;
            this.Bases = "001";
          }
          else
          {
            // 010
            this.Bases = "001";
          }
        }
        else if (this.OnThird())
        {
          // 001
          this.Runs += 1;
          this.Bases = "000";
        }
      }
    }

    private bool OnBase(char baseChar)
    {
      return baseChar.Equals('1');
    }

    private bool OnFirst()
    {
      return this.OnBase(this.Bases[0]);
    }

    private bool OnSecond()
    {
      return this.OnBase(this.Bases[1]);
    }

    private bool OnThird()
    {
      return this.OnBase(this.Bases[2]);
    }
  }
}