using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace WOTVCalc
{
    class Dmg
    {
        public void TheDmg(double dmg, double resist, double mitigate, double status, double element)
        {
            double finalDmg = Math.Floor(dmg);
            // dmg is the total attack after multipliers, etc.
            finalDmg = Math.Floor(finalDmg * ((100 - resist) / 100));
            // resist here is the resist to the attack.
            finalDmg = Math.Floor(finalDmg * ((100 - mitigate) / 100));
            // mitigate here is the def/spr.
            finalDmg = Math.Floor(finalDmg * (status / 100));
            // element is element advantage or not.
            finalDmg = Math.Floor(finalDmg * ((100 - element) / 100));

            Console.WriteLine("Thank you for the numbers. The total damage the target should take is: " + finalDmg);
        }
    }
}
