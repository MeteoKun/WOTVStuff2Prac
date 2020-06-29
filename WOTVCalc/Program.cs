using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace WOTVCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string yesOrNo;
            Console.WriteLine("Hello and welcome to the damage calculator.");
            Console.WriteLine("Just to say, this program is in extreme Alpha/Beta since I am bad at coding.");
            Console.WriteLine("Please keep in mind, this will not include damage done with crits, variance, nor chains. For now.");
            Console.WriteLine("Have fun using it, and I hope it works well for ya!");
            Console.WriteLine();
            Thread.Sleep(6000);
            Console.WriteLine();


            Console.WriteLine("Do you know the class attack multiplier?");
            Console.WriteLine("Y or N");
            yesOrNo = Console.ReadLine();
            yesOrNo = yesOrNo.ToLower();
            Console.WriteLine();

            if(yesOrNo == "n")
            {
                Console.WriteLine("Sorry I'm bad at coding so go look it up and then return!");
                System.Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("If you do, add up the correct stats and type in the value below.");
                Console.WriteLine("For example, if the multiplier is JUST 120% attack, you would only input 120% attack of the stat.");
                Console.WriteLine("Another example, if the multiplier is 100% attack, and 20% dex, you would add the two togeher.");
                Console.WriteLine("I.E: 100% attack, 20% dex, Attack is at 500, Dex is at 200. The number you input would be 700.");
                Console.WriteLine();
                Console.WriteLine("Input the value below:");

                double atkPower = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine();
                Console.WriteLine("Next, we need to know the total skill/dmg modifier.");
                Console.WriteLine("An example of this would be like so:");
                Console.WriteLine("Armor Crush = 121%, and you have 30 slash attack. The total number you would input is 151.");
                Console.WriteLine("For elemental attacks, for example a lightning attack, and you have Lighting Attack 30, you would add 30 to your input.");
                Console.WriteLine("Please input the total skill/dmg modifier below without the %, that includes:");
                Console.WriteLine("Skill dmg% + Attack Type + Element + Killers + any other bonuses.");
                Console.WriteLine("Input the value below:");

                double atkMulti = Convert.ToInt32(Console.ReadLine());
                double atkTotal = atkPower * (atkMulti / 100);

                Console.WriteLine();
                Console.WriteLine("Now, please tell me the target's resistance value that you are attacking with.");
                Console.WriteLine("For example, if the target you are hitting has 25% Slash attack and you are hitting with");
                Console.WriteLine("a Slash attack, you would input 25. Vice via, if you were hitting with a Magic attack, and");
                Console.WriteLine("their Magic attack resist is -10%, you would input -10.");
                Console.WriteLine("Input the value below:");

                double atkResist = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine("The next step, please tell me the target's DEF and/or SPR value depending on what damage");
                Console.WriteLine("the skill or attack is doing. For example, Ramza's Taunting Spell indeed scales off Slash");
                Console.WriteLine("and and light attribute, the attack type is done to the target's SPR stat instead of DEF.");
                Console.WriteLine("This would mean you would input the SPR stat, if it was 20 SPR, you would input 20.");
                Console.WriteLine("Input the value below:");

                double atkMitigation = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine("Next up, please tell me if the attack is using Bravery(Phys dmg) or Faith(Magic dmg)");
                Console.WriteLine("For Phys/Bravery, please input P or B. For Magic/Faith, please input M or F.");
                Console.WriteLine("Input the letter below:");

                char atkAnswer = Convert.ToChar(Console.ReadLine());
                atkAnswer = Char.ToUpper(atkAnswer);
                Console.WriteLine();
                double atkStatus;

                if(atkAnswer == 'P')
                {
                    Console.WriteLine("Please enter the Bravery value on the user of the attack. Additionally, there is a base");
                    Console.WriteLine("50 to add onto your bravery. For example, if you are at 97 bravery, you would input 147.");
                    Console.WriteLine("Input the value below:");
                    atkStatus = Convert.ToInt32(Console.ReadLine());
                    // return Bravery
                }
                else if(atkAnswer == 'B')
                {
                    Console.WriteLine("Please enter the Bravery value on the user of the attack. Additionally, there is a base");
                    Console.WriteLine("50 to add onto your bravery. For example, if you are at 97 bravery, you would input 147.");
                    Console.WriteLine("Input the value below:");
                    atkStatus = Convert.ToInt32(Console.ReadLine());
                    // return Bravery
                }
                else
                {
                    Console.WriteLine("Please enter the total Faith value of both the user, and the target of the attack.");
                    Console.WriteLine("For example, if the user using magic has 75 faith, and the target that is being hit");
                    Console.WriteLine("also has 75 faith, the total faith is 150, and you would input 150.");
                    Console.WriteLine("Input the value below:");
                    atkStatus = Convert.ToInt32(Console.ReadLine());
                    // return Faith
                }

                Console.WriteLine();
                Console.WriteLine("Lastly. If the attack/ability/magic you are using is affected by element, is there an");
                Console.WriteLine("elemental advantage for you? If yes, subtract 25 to your input, and if it is an elemental");
                Console.WriteLine("disadvantage, add 25 to your input. For example, lets use a water attack.");
                Console.WriteLine("If you are using a water element onto a fire target, who has 0% water element resistance,");
                Console.WriteLine("the value you would input would be -25. If the target has -20% water resistance, then the");
                Console.WriteLine("input would be -45. Now on the contrary, if you use a lightning element attack onto an earth target,");
                Console.WriteLine("and the target has 20% lightning resistance, you would input 45.");
                Console.WriteLine("Input the value below:");
                double atkElement = Convert.ToInt32(Console.ReadLine());

                
                Console.WriteLine();
                Console.WriteLine();
                Dmg dmgResult = new Dmg();
                dmgResult.TheDmg(atkTotal, atkResist, atkMitigation, atkStatus, atkElement);
            }


            




        }

        public void 
    }
}
