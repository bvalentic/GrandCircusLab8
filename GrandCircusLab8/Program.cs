using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandCircusLab8
{
    class Program
    {
        static void Main(string[] args)
        {
            /* provide information about students in class
             * prompt user to ask about particular student (by number)
             * give proper responses according to user-provided info
             * ask if user would like to learn about another student
             */

            //array of team member names, favorite foods, and hometowns
            string[,] nameArray = { {"Nana Banahene", "bananas", "Ghana" },
                                    {"Tim Broughton", "chicken parmesan", "Detroit, MI" },
                                    {"Lin-Z Chang", "ice cream", "Toledo, OH" },
                                    {"Taylor Everts", "chicken Cordon Bleu", "Caro, MI" },
                                    {"Michael Hern", "chicken wings", "Canton, MI" },
                                    {"Madelyn Hilty", "croissants", "Oxford, MI" },                                    
                                    {"Jordan Owiesny", "burgers", "Warren, MI" },
                                    {"Shah Shahid", "chicken wings", "Newark, NJ" },
                                    {"Blake Shaw", "cannolis", "Los Angeles, CA" },                                    
                                    {"John Shaw", "ribs", "Huntington Woods, MI" },                                        
                                    {"Jay Stiles", "pickles", "Macomb, MI" },
                                    {"Rochelle \"Roach\" Toles", "space cheese", "Mars" },
                                    {"Bob Valentic", "pizza", "St. Clair Shores, MI" },
                                    {"Abby Wessels", "soup", "Traverse City, MI" },
                                    {"Joshua Zimmerman", "turkey", "Taylor, MI" }};
            
            Console.WriteLine("Hello, and welcome to the Dev.Build(2.0) database!");
            bool goAgain = true;
            //allows looping until user decides to quit
            while (goAgain)
            {
                FindInfo(nameArray);
                goAgain = KeepGoing("Would you like to continue? (y/n) ");
            }


        }
        static bool KeepGoing(string message)
        {//method to check if user wants to continue, returns boolean used as check
            bool correctInput = true; //makes sure user puts in a variation of "yes" or "no"
            bool continuer = true; //eventual returned boolean
            do
            {
                Console.Write("\n" + message);
                string confirm = Console.ReadLine().ToLower();
                if (confirm == "n" || confirm == "no")
                {
                    Console.WriteLine("Come back soon!");
                    continuer = false;
                    correctInput = true;
                    Console.ReadKey();
                }
                else if (confirm == "y" || confirm == "yes")
                {
                    Console.WriteLine("\nOkay!\n");
                    continuer = true;
                    correctInput = true;
                }
                else
                {
                    Console.WriteLine("Sorry, I didn't understand.");
                    correctInput = false;
                }
            } while (!correctInput);
            return continuer;
        }
        static void FindInfo(string[,] nameArray)
        {//runs database and returns info
            Console.WriteLine("Enter the number that corresponds to the team member you wish to look up. \n" +
                    "For a list of team members, enter \"0\".");
            int inputName;
            bool loopChoice = true;
            while (!int.TryParse(Console.ReadLine(), out inputName)) 
                //catches exceptions if input isn't an int
            {
                Console.Write("I'm sorry, I didn't understand. Please try again: ");
            }
            if (inputName == 0)
            {
                //print list of names and corresponding inputs
                for (int i = 0; i < nameArray.GetLength(0); i++)
                {
                    Console.WriteLine($"{i + 1,2}: {nameArray[i, 0]}"); //formatted for easier readability
                }

            }
            else
            {
                try
                {
                    Console.WriteLine("\n" + inputName + " is " + nameArray[inputName - 1, 0] + ". Would you like to know more?");
                    do
                    {
                        loopChoice = true; //loops for current user selection
                        Console.WriteLine("(Press \"0\" to skip, \"1\" for favorite food, or \"2\" for hometown)\n");
                        try
                        { 
                            int inputNum = int.Parse(Console.ReadLine());
                            var test = nameArray[inputName, inputNum]; //this tests to see if input is correct
                            if (inputNum == 0)
                            {
                                //option to "quit" and go back to the list of names
                                Console.WriteLine("Going back to the main database. . .");
                                loopChoice = false;
                            }
                            else if (inputNum == 1)
                            {
                                //show food
                                Console.WriteLine(nameArray[inputName - 1, 0] + "'s favorite food is " + nameArray[inputName - 1, inputNum] + ".");
                                Console.WriteLine("Would you like to know more?");
                            }
                            else if (inputNum == 2)
                            {
                                //show hometown
                                Console.WriteLine(nameArray[inputName - 1, 0] + "'s hometown is " + nameArray[inputName - 1, inputNum] + ".");
                                Console.WriteLine("Would you like to know more?");
                            }
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("I'm sorry, that input is not in the acceptable range.");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("I'm sorry, I don't understand. Please input a number corresponding to your selection.");
                        }
                    } while (loopChoice);
                } //two sets of exception catches for each nested loop
                  //otherwise it will catch the exception but also exit the loop
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("I'm sorry, that input is not in the acceptable range.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("I'm sorry, I don't understand. Please input a number corresponding to your selection.");
                }
                
            }

        }
    }
}
