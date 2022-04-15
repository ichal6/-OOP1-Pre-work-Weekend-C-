using System;

namespace TwoFightersOneWinner
{
    public class Kata 
    {
      public static String declareWinner(Fighter fighter1, Fighter fighter2, String firstAttacker) 
      {
        bool firstFighterAttack = fighter1.Name == firstAttacker ? true : false;
        while(true)
        {
          if(fighter1.Health <= 0)
          {
              return fighter2.Name;
          }
          else if(fighter2.Health <= 0)
          {
              return fighter1.Name;
          }
          if(firstFighterAttack == true)
          {
              fighter2.Health -= fighter1.DamagePerAttack;
              firstFighterAttack = false;
          }
          else
          {
              fighter1.Health -= fighter2.DamagePerAttack;
              firstFighterAttack = true;
          }
        }
      }

  }
}
