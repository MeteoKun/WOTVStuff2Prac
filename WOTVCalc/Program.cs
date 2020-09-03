using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace WOTVCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            //These properties are made for the damage values with differing steps due to truncating
            //the damage, or property at very certain intervals.
            double calcDmg;
            double theBraveFaith;
            double finalResultDmg;

            //These are the methods called in the order they are prompted for the user to input
            //int values or answer Y/N.
            intro();
            calcDmg = Math.Floor(jobMulti() * skillMod());
            calcDmg = Math.Floor(calcDmg * typeResist());
            calcDmg = Math.Floor(calcDmg * odinMachine());
            calcDmg = Math.Floor(calcDmg * defSpirit());
            calcDmg = Math.Floor(calcDmg * elemResist());
            if (multiHits() == true)
            {
                Console.WriteLine("Please know the amount of hits the ability is doing.");
                Console.WriteLine();
                Console.WriteLine("Input the value below:");
                int amtHits = Convert.ToInt32(Console.ReadLine());
                if (amtHits > 1)
                {
                    theMultiHits(calcDmg, amtHits);
                }
                else
                {
                    theBraveFaith = (braveFaith() + chainMulti()) / 100;
                    finalResultDmg = Math.Floor(calcDmg * theBraveFaith);
                    finalResultDmg *= elementAdvantage();
                    Console.WriteLine("The total estimated damage dealt will be: " + finalResultDmg);
                    Console.WriteLine("Thanks for using this tool!");
                }
            }
            else
            {
                theBraveFaith = (braveFaith() + chainMulti()) / 100;
                finalResultDmg = Math.Floor(calcDmg * theBraveFaith);
                finalResultDmg *= elementAdvantage();
                Console.WriteLine("The total estimated damage dealt will be: " + finalResultDmg);
                Console.WriteLine("Thanks for using this tool!");

            }

        }

        static void intro()
        {
            Console.WriteLine("Hello and welcome to the damage calculator.");
            Console.WriteLine("Just to say, this program is in extreme Alpha/Beta since I am bad at coding.");
            Console.WriteLine("Please keep in mind, this will not include damage done with crits, variance, nor chains.");
            Console.WriteLine("Have fun using it, and I hope it works well for ya!");
            Console.WriteLine();
            Thread.Sleep(5000);
            Console.WriteLine();
        }

        public static double jobMulti()
        {
            Console.WriteLine("First off, we need to know the class multiplier and stat for the attack/ability you are using.");
            Console.WriteLine("For example, if the multiplier is JUST 120% attack, you would input 120% attack of the stat.");
            Console.WriteLine("Another example, if the multiplier is 100% attack, and 20% dex, you would add the two togeher.");
            Console.WriteLine("I.E: 100% attack, 10% dex, Attack is at 500, Dex is at 200. The number you input would be 520.");
            Console.WriteLine();
            Console.WriteLine("Input the value below:");

            return Convert.ToInt32(Console.ReadLine());
        }

        public static double skillMod()
        {
            Console.WriteLine();
            Console.WriteLine("Next, we need to know the total skill/dmg modifier.");
            Console.WriteLine("An example of this would be like so:");
            Console.WriteLine("Armor Crush = 121%, and you have 30 slash attack. The total number you would input is 151.");
            Console.WriteLine("For elemental attacks, for example a lightning attack, and you have Lighting Attack 30, you would add 30 to your input.");
            Console.WriteLine("Please input the total skill/dmg modifier below without the %, that includes:");
            Console.WriteLine("Skill dmg% + Attack Type + Element + Killers + any other bonuses.");
            Console.WriteLine("In terms of other bonuses, an example can be critical hits. If a critical hit does occur, add an additional 25 to your input.");
            Console.WriteLine("Additionally, if the skill/ability is a multi hit, please only include the modifier of the hit, not the total, such as for");
            Console.WriteLine("Ramza's Triple Blow, each hit is 40%, so you would input 40 for that instead of the total.");
            Console.WriteLine("This would be the same for Shadowlynx's Dream Within a Dream, which is 21% per hit, so you would input 21.");
            Console.WriteLine();
            Console.WriteLine("Input the value below:");
            decimal skillPercent = Convert.ToDecimal(Console.ReadLine());
            return Decimal.ToDouble(skillPercent / 100);
        }

        public static double typeResist()
        {
            Console.WriteLine();
            Console.WriteLine("Now, please tell me the target's resistance value that you are attacking with.");
            Console.WriteLine("For example, if the target you are hitting has 25% Slash attack and you are hitting with");
            Console.WriteLine("a Slash attack, you would input 25. Vice via, if you were hitting with a Magic attack, and");
            Console.WriteLine("their Magic attack resist is -10%, you would input -10.");
            Console.WriteLine();
            Console.WriteLine("Input the value below:");
            double typeAtkResist = Convert.ToInt32(Console.ReadLine());
            return (100 - typeAtkResist) / 100;
        }

        public static double odinMachine()
        {
            Console.WriteLine();
            Console.WriteLine("If using any specific resistance such as Odin or Death Machine,");
            Console.WriteLine("Please input the amount that is being resisted.");
            Console.WriteLine("For example, an MLB Odin/Death Machine would be 20%, so you would input 20.");
            Console.WriteLine("If you are not using one, or do not have one, simply input 0.");
            Console.WriteLine();
            Console.WriteLine("Input the value below:");
            double typeSpecialResist = Convert.ToInt32(Console.ReadLine());
            return (100 - typeSpecialResist) / 100;
        }

        public static double defSpirit()
        {
            Console.WriteLine();
            Console.WriteLine("The next step, please tell me the target's DEF and/or SPR value depending on what damage");
            Console.WriteLine("the skill or attack is doing. For example, Ramza's Taunting Spell indeed scales off Slash");
            Console.WriteLine("and and light attribute, the attack type is done to the target's SPR stat instead of DEF.");
            Console.WriteLine("This would mean you would input the SPR stat, if it was 20 SPR, you would input 20.");
            Console.WriteLine();
            Console.WriteLine("Input the value below:");
            double defSprResist = Convert.ToInt32(Console.ReadLine());
            return (100 - defSprResist) / 100;
        }

        public static double elemResist()
        {
            Console.WriteLine();
            Console.WriteLine("Another step, please tell me if you are using an elemental ability. If yes, enter the targets");
            Console.WriteLine("elemental resistance that will be targetted with your elemental ability.");
            Console.WriteLine("For example, you are using Holy, and the target has -10% to Light element,");
            Console.WriteLine("you would input -10.");
            Console.WriteLine();
            Console.WriteLine("Input the value below:");
            double elemRes = Convert.ToInt32(Console.ReadLine());
            return (100 - elemRes) / 100;
        }

        //The reason there is a separate math calculation apart from the other methods, is that
        //for each hit in a multi hit, the math needs to be truncated that includes all the
        //previous inputs and requires special treatment.
        public static bool multiHits()
        {
            Console.WriteLine();
            Console.WriteLine("Before we go any further, is your ability/hit/skill a multi hit? Enter Y or N");
            Console.WriteLine();
            Console.WriteLine("Input the letter below:");
            char multiHit = Convert.ToChar(Console.ReadLine());
            multiHit = Char.ToUpper(multiHit);
            Console.WriteLine();

            if (multiHit == 'Y')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static double braveFaith()
        {
            Console.WriteLine();
            Console.WriteLine("Next up, please tell me if the attack is using Bravery(Phys dmg) or Faith(Magic dmg)");
            Console.WriteLine("For Phys/Bravery, please input P or B. For Magic/Faith, please input M or F.");
            Console.WriteLine();
            Console.WriteLine("Input the letter below:");

            char atkAnswer = Convert.ToChar(Console.ReadLine());
            atkAnswer = Char.ToUpper(atkAnswer);
            Console.WriteLine();

            if (atkAnswer == 'P')
            {
                Console.WriteLine("Please enter the Bravery value on the user of the attack. Additionally, there is a base");
                Console.WriteLine("50 to add onto your bravery. For example, if you are at 97 bravery, you would input 147.");
                Console.WriteLine();
                Console.WriteLine("Input the value below:");
                return Convert.ToInt32(Console.ReadLine());
                // return Bravery
            }
            else if (atkAnswer == 'B')
            {
                Console.WriteLine("Please enter the Bravery value on the user of the attack. Additionally, there is a base");
                Console.WriteLine("50 to add onto your bravery. For example, if you are at 97 bravery, you would input 147.");
                Console.WriteLine();
                Console.WriteLine("Input the value below:");
                return Convert.ToInt32(Console.ReadLine());
                // return Bravery
            }
            else
            {
                Console.WriteLine("Please enter the total Faith value of both the user, and the target of the attack.");
                Console.WriteLine("For example, if the user using magic has 75 faith, and the target that is being hit");
                Console.WriteLine("also has 75 faith, the total faith is 150, and you would input 150.");
                Console.WriteLine();
                Console.WriteLine("Input the value below:");
                return Convert.ToInt32(Console.ReadLine());
                // return Faith
            }
        }

        public static double chainMulti()
        {
            Console.WriteLine("Next step, please tell me if there is a chain or not.");
            Console.WriteLine("If there is a single chain, you would input 20.");
            Console.WriteLine("If there is a single chain, and single elemental chain, you would input 40.");
            Console.WriteLine();
            Console.WriteLine("Input the value below:");
            return Convert.ToInt32(Console.ReadLine());
        }

        public static double elementAdvantage()
        {
            Console.WriteLine("This is the last step. Is there an elemental advantage your unit has onto the");
            Console.WriteLine("target? For example, if Ramza is targetting a Sterne or any dark unit, he will");
            Console.WriteLine("always have an elemental advantage in damage against them, and you would input Y.");
            Console.WriteLine("Please input Y or N.");
            Console.WriteLine();
            Console.WriteLine("Input the value below:");
            

            char elemAnswer = Convert.ToChar(Console.ReadLine());
            elemAnswer = Char.ToUpper(elemAnswer);
            Console.WriteLine();

            if (elemAnswer == 'Y')
            {
                return (100 + 25) / 100;
            }
            else
            {
                return 1;
            }

            
            
        }

        public static void theMultiHits(double theDmg, int numHits)
        {
            int howManyHits = numHits;
            int chainingHit = 0;
            double finalResult = 0;
            double theMultiplier;
            double theBraveFaith = braveFaith(); // + chainMulti()) / 100;
            double theChainMulti = chainMulti();
            double theElemAdv = elementAdvantage();

            for (int i = 0; i < howManyHits; i++)
            {
                theMultiplier = Math.Floor((theBraveFaith + theChainMulti + chainingHit) / 100);
                chainingHit += 40;
                finalResult += Math.Floor(theDmg * theMultiplier);
                finalResult *= theElemAdv;
            }
            Console.WriteLine("The total estimated damage dealt will be: " + finalResult);
            Console.WriteLine("Thanks for using this tool!");
        }
    }
}
