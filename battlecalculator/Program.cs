using System;

namespace battlecalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of non artillery forces for side A");
            Double forceA = Convert.ToDouble(Console.ReadLine());
            //this is equivalent to variable R in the linked pdf
            Console.WriteLine("Enter number of non artillery forces for side B");
            Double forceB = Convert.ToDouble(Console.ReadLine());
            //this is equivalent to variable B in the linked pdf

            Console.WriteLine("Enter the organic detection effectiveness (%) of side A");
            Double deteffectivenessA = Convert.ToDouble(Console.ReadLine());
            //this is equivalent to variable dr in the linked pdf
            Console.WriteLine("Enter the organic detection effectiveness (%) of side B");
            Double deteffectivenessB = Convert.ToDouble(Console.ReadLine());
            //this is equivalent to variable db in the linked pdf

            Console.WriteLine("Enter the destruction effectiveness (%) of side A");
            Double deseffectivenessA = Convert.ToDouble(Console.ReadLine());
            //this is equivalent to variable er in the linked pdf
            Console.WriteLine("Enter the destruction effectiveness (%) of side B");
            Double deseffectivenessB = Convert.ToDouble(Console.ReadLine());
            //this is equivalent to variable eb in the linked pdf

            Console.WriteLine("Enter the max number of side b's units side a can encounter (higher intelligence. set to 1 for none)");
            Double encounterA = Convert.ToDouble(Console.ReadLine());
            //this is equivalent to variable cr in the linked pdf
            Console.WriteLine("Enter the max number of side a's units side b can encounter (higher intelligence. set to 1 for none)");
            Double encounterB = Convert.ToDouble(Console.ReadLine());
            //this is equivalent to variable cb in the linked pdf

            Console.WriteLine("Enter side a's capitulation percent");
            Double capitulateA = Convert.ToDouble(Console.ReadLine());
            //how low can the percantage of the original remaining go before this side retreats
            Console.WriteLine("Enter side b's capitulation percent");
            Double capitulateB = Convert.ToDouble(Console.ReadLine());
            //how low can the percantage of the original remaining go before this side retreats

            Double combatA = deteffectivenessA * deseffectivenessA;
            //N=dr*er
            Double combatB = deteffectivenessB * deseffectivenessB;
            //M=db*eb
            Double remainingA = forceA;
            //r(t)
            Double remainingB = forceB;
            //b(t)
            Double t = 0;
            //this is equivalent to variable time in the linked pdf
            String linsqr = "";
            //for use predicting actual causalties
            String winner = "";

            //for the inequalities used see page 11 of https://www.rand.org/content/dam/rand/pubs/monograph_reports/MR1155/MR1155.ch4.pdf
            if (encounterA==1&&encounterB==1) //if cr=1 and cb=1
            {
                if ((combatB/combatA)>Math.Pow((forceA / forceB),2))
                {
                    Console.WriteLine("Side B wins");
                    winner = "b";
                    Console.WriteLine("Side A has "+(forceA*capitulateA)+" combat units remaining");
                    double loseremaining = Math.Sqrt((combatA/combatB)*(Math.Pow((forceA * capitulateA),2)-Math.Pow(forceA,2))+Math.Pow(forceB,2));
                    Console.WriteLine("Side B has "+loseremaining+" combat units remaining");
                }
                else{
                    Console.WriteLine("Side B loses");
                    winner = "a";
                    Console.WriteLine("swap the sides and run it again to get the casualty report (I can't be bothered to change the entire equation like 8 times just to solve for the other variable)");
                }
                linsqr = "squ";
            }
            else if (encounterA==1&& encounterB != forceA && encounterB != 1) //if cr=1 and cb=g (a variable)
            {
                if(((combatB*encounterB) / combatA) >Math.Pow((forceA / forceB), 2))
                {
                    Console.WriteLine("Side B wins");
                    winner = "b";
                    Console.WriteLine("Side A has " + (forceA * capitulateA) + " combat units remaining");
                    double loseremaining = Math.Sqrt((combatA / (combatB*encounterB)) * (Math.Pow((forceA * capitulateA), 2) - Math.Pow(forceA, 2)) + Math.Pow(forceB, 2));
                    Console.WriteLine("Side B has " + loseremaining + " combat units remaining");
                }
                else{
                    Console.WriteLine("Side B loses");
                    winner = "a";
                    Console.WriteLine("swap the sides and run it again to get the casualty report (I can't be bothered to change the entire equation like 8 times just to solve for the other variable)");
                }
                linsqr = "squ";
            }
            else if (encounterA != 1 && encounterA != forceB && encounterB == 1) //if cr=h (a variable) and cb=1
            {
                if ((combatB / (combatA*encounterA)) > Math.Pow((forceA / forceB), 2))
                {
                    Console.WriteLine("Side B wins");
                    winner = "b";
                    Console.WriteLine("Side A has " + (forceA * capitulateA) + " combat units remaining");
                    double loseremaining = Math.Sqrt(((combatA*encounterA) / combatB) * (Math.Pow((forceA * capitulateA), 2) - Math.Pow(forceA, 2)) + Math.Pow(forceB, 2));
                    Console.WriteLine("Side B has " + loseremaining + " combat units remaining");
                }
                else
                {
                    Console.WriteLine("Side B loses");
                    winner = "a";
                    Console.WriteLine("swap the sides and run it again to get the casualty report (I can't be bothered to change the entire equation like 8 times just to solve for the other variable)");
                }
                linsqr = "squ";
            }
            else if (encounterA == forceB && encounterB == forceA) //if cr=B (total force of side B) and cb=R (total force of side A)
            {
                if ((combatB / combatA) > (forceA / forceB))
                {
                    Console.WriteLine("Side B wins");
                    winner = "b";
                    Console.WriteLine("Side A has " + (forceA * capitulateA) + " combat units remaining");
                    double loseremaining = (combatA / combatB) * ((forceA * capitulateA) - forceA) + forceB;
                    Console.WriteLine("Side B has " + loseremaining + " combat units remaining");
                }
                else
                {
                    Console.WriteLine("Side B loses");
                    winner = "a";
                    Console.WriteLine("swap the sides and run it again to get the casualty report (I can't be bothered to change the entire equation like 8 times just to solve for the other variable)");
                }
                linsqr = "lin";
            }
            else if (encounterA == forceB && encounterB != forceA && encounterB != 1) //if cr=B (total force of side B) and cb=g (a variable)
            {
                if (((combatB*encounterB) / combatA) > (Math.Pow(forceA,2) / forceB))
                {
                    Console.WriteLine("Side B wins");
                    winner = "b";
                    Console.WriteLine("Side A has " + (forceA * capitulateA) + " combat units remaining");
                    double loseremaining = (combatA / (combatB*encounterB)) * (Math.Pow((forceA * capitulateA), 2) - Math.Pow(forceA, 2)) + forceB;//I don't know if this is necessarily right...
                    Console.WriteLine("Side B has " + loseremaining + " combat units remaining");
                }
                else
                {
                    Console.WriteLine("Side B loses");
                    winner = "a";
                    Console.WriteLine("swap the sides and run it again to get the casualty report (I can't be bothered to change the entire equation like 8 times just to solve for the other variable)");
                }
                linsqr = "mix";
            }
            else if (encounterA != forceB && encounterA != 1 && encounterB == forceA) //if cr=h (a variable) and cb=R (total force of side A)
            {
                if ((combatB / (combatA*encounterA)) > (forceA / Math.Pow(forceB,2)))
                {
                    Console.WriteLine("Side B wins");
                    winner = "b";
                    Console.WriteLine("Side A has " + (forceA * capitulateA) + " combat units remaining");
                    double loseremaining =Math.Sqrt(((combatA * encounterA) / combatB) * ((forceA * capitulateA) - forceA) + Math.Pow(forceB, 2));//I don't know if this is necessarily right...
                    Console.WriteLine("Side B has " + loseremaining + " combat units remaining");
                }
                else
                {
                    Console.WriteLine("Side B loses");
                    winner = "a";
                    Console.WriteLine("swap the sides and run it again to get the casualty report (I can't be bothered to change the entire equation like 8 times just to solve for the other variable)");
                }
                linsqr = "mix";
            }
            else if (encounterA==forceB&&encounterB==1) //if cr=B (total force of side B) and cb=1
            {
                if ((combatB / combatA) > (Math.Pow(forceA, 2) / forceB))
                {
                    Console.WriteLine("Side B wins");
                    winner = "b";
                    Console.WriteLine("Side A has " + (forceA * capitulateA) + " combat units remaining");
                    double loseremaining = (combatA / combatB) * (Math.Pow((forceA * capitulateA), 2) - Math.Pow(forceA, 2)) + forceB;//I don't know if this is necessarily right...
                    Console.WriteLine("Side B has " + loseremaining + " combat units remaining");
                }
                else
                {
                    Console.WriteLine("Side B loses");
                    winner = "a";
                    Console.WriteLine("swap the sides and run it again to get the casualty report (I can't be bothered to change the entire equation like 8 times just to solve for the other variable)");
                }
                linsqr = "mix";
            }
            else if (encounterA == 1 && encounterB == forceA) //if cr=1 and cb=R (total force of side A)
            {
                if ((combatB / combatA) > (forceA / Math.Pow(forceB, 2)))
                {
                    Console.WriteLine("Side B wins");
                    winner = "b";
                    Console.WriteLine("Side A has " + (forceA * capitulateA) + " combat units remaining");
                    double loseremaining =Math.Sqrt((combatA / combatB) * ((forceA * capitulateA) - forceA) + Math.Pow(forceB, 2));//I don't know if this is necessarily right...
                    Console.WriteLine("Side B has " + loseremaining + " combat units remaining");
                }
                else
                {
                    Console.WriteLine("Side B loses");
                    winner = "a";
                    Console.WriteLine("swap the sides and run it again to get the casualty report (I can't be bothered to change the entire equation like 8 times just to solve for the other variable)");
                }
                linsqr = "mix";
            }
        }
    }
}
