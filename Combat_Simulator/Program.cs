 
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatSimulator
{
    class Program
    {
        //creating global variables
        static bool gamePlay = true;
        static string playersChoice = string.Empty;
        static int playersHP = 100;
        static int pandasHP = 200;
        static Random rng = new Random();
        static int pandasTurn = 0;
        static int numberOfTickles = 0;
        static int timesBambooWasGiven = 0;
        static int pandaCubHubs = 0;
        static int escapeAttempts = 0;

        static void Main(string[] args)
        {
            //calls Combat Simulator
            CombatSimulator();
        }

        /// <summary>
        /// Battle with an intimidating foe
        /// </summary>
        static void CombatSimulator()
        {
            //keeps game open
            while (gamePlay)
            {
                //prints game name
                gameName();

                //introduces game to player
                oldTimeyTextPrinter(@"
        You are visiting a local zoo and find your way to the panda bears.
        While you strain for a better look, you fall into their habitat.

        As you check for broken bones and dust yourself off,
        You realize a fully grown panda has moseyed over to where you fell.

        You begin to panic, unsure of what is going to happen next.
        Before you know it, the seemingly cuddly panda has tried to
        Steal your Snacky Cakes from your bag.

        You now have to battle the panda in order to retrieve your
        delicious Snacky Cakes!", 40);

            //continue reading about the game
            Console.ReadLine();
            //clears the console
            Console.Clear();
            //prints game name
            gameName();
            
            oldTimeyTextPrinter(@"
        Press 1 to tickle the panda for a 70% chance to distract
        the panda for longer periods of time.

        Press 2 to give the panda bamboo and distract the panda 
        everytime, but for much smaller periods of time.

        Press 3 to hug a panda cub and heal yourself from any damage
        from the theiving panda bear. 
        (Plus, who doesn't want to hug a panda cub?)

        Press 4 to try and escape the habitat. It's not certain you
        will succeed, but if you do, you will win a lifetime supply
        of Snacky Cakes and save your life.", 40);

            //allows them to start playing the game
            Console.ReadLine();
            //clears the console
            Console.Clear();
            //prints game name
            gameName();

            oldTimeyTextPrinter(@"
        BUT BE CAREFUL!

        The panda can cause damage to you by farting, rolling over you,
        and tickling you back. HOWEVER, it is a panda, so his attacks
        only succeed 80% of the time.", 40);

            //allows them to start playing the game
            Console.ReadLine();
            //clears the console
            Console.Clear();

                //tracks moves during the battle
                while (playersHP > 0 && pandasHP > 0)
                {
                    
                    //calls greeting 
                    gameHeading();
                    if (playersHP > 0)
                    {
                        //calls player's combat
                        playerCombat(playersInput());
                    }
                    

                    if (pandasHP > 0)
                    {
                        //calls foe's combat
                        foesCombat();
                    }

                    //checks if player wins
                    if (playersHP > 0 && pandasHP <= 0)
                    {
                        gameName();
                        //prints congrats message
                        Console.WriteLine("\n             You managed to save your Snacky Cakes and fight a panda!");
                    }

                    //checks if foe wins
                    if (pandasHP > 0 && playersHP <= 0)
                    {
                        gameName();
                        //prints losing message
                        Console.WriteLine(@"
         You lost your Snacky Cakes, but you did get to fight a panda bear.
                        Kind of a win/win, right?");
                    }
                }

                //ends the game loop
                gamePlay = false;
                //asks player if they want to play again
                playAgain();
            }
        }

        /// <summary>
        /// Greets the user and prints game title
        /// </summary>
        static void gameHeading()
        {
            //prints game name
            gameName();

            //sets text color to green
            Console.ForegroundColor = ConsoleColor.Green;

            //prints game options and HP levels
            Console.WriteLine(@"
Player's HP: {0}                                                 Panda's HP: {1}", playersHP, pandasHP);
            //resets text color
            Console.ResetColor();

            //prints fighting options
            Console.WriteLine(@"
                        Choose one of the three options:
                            1) Tickle
                            2) Give Bamboo
                            3) Hug a Cub
                            4) Try to Escape
");

        }

        /// <summary>
        /// Validates players input
        /// </summary>
        /// <returns>Players input if valid</returns>
        static string playersInput()
        {
            //stores players choice
            string playersChoice = Console.ReadLine();

            //checks if its a valid choice
            if (playersChoice != "1" && playersChoice != "2" && playersChoice != "3" && playersChoice != "4")
            {

                //prints error message if not valid
                Console.WriteLine("\n                        Not a valid input. Try again!");
                //times the message
                System.Threading.Thread.Sleep(1000);
                //clears console
                Console.Clear();
                //calls game info 
                gameHeading();  
                //asks for users input again
                playersChoice = Console.ReadLine();

                if (playersChoice != "1" && playersChoice != "2" && playersChoice != "3" && playersChoice != "4")
                {
                    //prints error message
                    Console.WriteLine("\n             You didn't even TRY to distract the panda! Turn forfeited");
                }
            }
            //otherwise, returns valid choice
            return playersChoice;
        }

        /// <summary>
        /// Loops through the game play options for the player
        /// </summary>
        /// <param name="choice">The fighting choice of the player</param>
        static void playerCombat(string choice)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            //creating player's options
            string tickle = "1";
            string magic = "2";
            string heal = "3";
            string escape = "4";

            if (choice == tickle)
            {   
                //randomly generates chance of hit and sword damage
                int chance = rng.Next(1, 11);
                int tickleDamage = rng.Next(20, 36);
                //hits 70% of the time
                if (chance <= 7)
                {
                    //counts number of successful tickle attempts
                    numberOfTickles++;
                    //subtracts damage to foe's HP
                    pandasHP -= tickleDamage;
                    //clears players input
                    Console.Clear();
                    gameHeading();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    //prints congrats message
                    Console.WriteLine("                 Pandas are incredibly ticklish! Don't hold back!");
                }
                else
                { 
                    //clears players input
                    Console.Clear();
                    gameHeading();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    //otherwise, player missed
                    Console.WriteLine("                      Oh no! Your tickles weren't successful!");
                }
            }
            //if player chooses magic
            else if (choice == magic)
            {
                //counts number of bamboo shoots thrown
                timesBambooWasGiven++;
                //randomly chooses damage amount between 10 and 15
                int bambooDamage = rng.Next(10, 16);
                //subtracts damage to foe's HP
                pandasHP -= bambooDamage;
                //clears players input
                Console.Clear();
                gameHeading();
                Console.ForegroundColor = ConsoleColor.Yellow;
                //prints congrats message
                Console.WriteLine(@"                 Pandas will eat bamboo for hours on end if given enough
                                Keep distracting him!");
               
            }
            //choose to heal
            else if (choice == heal)
            {
                //counts number of panda hugs
                pandaCubHubs++;
                //randomly picks a health amount between 10 and 20
                int increaseHP = rng.Next(10, 21);
                //adds heal amount to players HP
                playersHP += increaseHP;
                //clears players input
                Console.Clear();
                gameHeading();
                Console.ForegroundColor = ConsoleColor.Yellow;
                //prints heal message
                Console.WriteLine("                    A hug from a panda cub can heal anything!");
               
            }
            else if (choice == escape)
            {
                //counts escape attempts
                escapeAttempts++;
                //randomly selects when escape attempt is successful
                int escapeChance = rng.Next(1, 11);
                if(escapeChance.ToString() == "1")
                {
                    //clears players input
                    Console.Clear();
                    gameHeading();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    //prints congrats message
                    Console.WriteLine(@"
                    Congratulations! You escaped the habitat
                    and won a lifetime supply of Snacky Cakes!");
                    //sets panda HP to 0 to end game
                    gamePlay = false;
                    pandasHP = 0;
                }
                else
                {
                    //clears players input
                    Console.Clear();
                    gameHeading();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("                  I told you it would be tricky to escape!");
                }
            }
            //times message
            System.Threading.Thread.Sleep(2500);
            //clears console
            Console.Clear();
        }

        /// <summary>
        /// Tracks the attack of the AI foe
        /// </summary>
        static void foesCombat()
        {
            
            pandasTurn = rng.Next(1,4);
            //calls game info
            gameHeading();

            //string to store damage done to player
            string pandaDamage = string.Empty;

            switch (pandasTurn)
            {

                case 1:
                    pandaDamage = "                Oh god! The panda farted! The smell! It burns!!!";
                    break;
                case 2:
                    pandaDamage = "                   Watch out! He's going to roll on top of you!";
                    break;
                case 3:
                    pandaDamage = "    He tickled you! You've taught a panda how to tickle! What have you done?!";
                    break;
            }

            //randomly generates foe's damage amount and chance of hit
            int foesDamageAttack = rng.Next(5, 16);
            int foesDamageChance = rng.Next(1, 6);

            //if he successfully attacks

            if (foesDamageChance <= 4)
            {
                //subtracts damage amount from players HP
                playersHP -= foesDamageAttack;
                Console.ForegroundColor = ConsoleColor.Red;
                //prints hit message
                Console.WriteLine(pandaDamage);
            }
           
            //otherwise,
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                //prints failed attack message
                Console.WriteLine("  He missed this time, but he's still eating your Snacky Cakes! Don't let up!");
            }
            //times message
            System.Threading.Thread.Sleep(2500);
            //clears console
            Console.Clear();
        }

        /// <summary>
        /// Asks the user to play again
        /// </summary>
        static void playAgain()
        {
         
            Console.WriteLine(@"
                        You tickled the panda {0} times
                        You fed bamboo to him {1} times
                        You hugged a panda cub {2} times
                        You tried to escape {3} times", numberOfTickles, timesBambooWasGiven, pandaCubHubs, escapeAttempts);
            Console.ForegroundColor = ConsoleColor.Green;
            //play again message
            Console.Write(@"
                            Want to play again?
                            Yes/No: ");
            //players answer
            string playersAnswer = Console.ReadLine();
            gamePlay = true;
            //checks players answer
            if (playersAnswer.ToLower() == "yes")
            {
                //if yes, clear console, 
                Console.Clear();            
                //reset HP levels
                playersHP = 100;
                pandasHP = 200;
                //calls Combat Simulator
                CombatSimulator();
            }
            //otherwise
            else if(playersAnswer.ToLower() == "no")
            {
                //end game loop
                gamePlay = false;
            }
            else
            {
                //prints error message
                Console.Write("Sorry, not a valid answer");
                System.Threading.Thread.Sleep(2500);
                Console.Clear();

                //asks player if they want to play again
                playAgain();
            }
           
        }

        static void gameName()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
                         ______                 __        
                        |   __ \.---.-.-----.--|  |.---.-.
                        |    __/|  _  |     |  _  ||  _  |
                        |___|   |___._|__|__|_____||___._|
                                          
                  _______               __                    __ 
                 |   |   |.---.-.--.--.|  |--.-----.--------.|  |
                 |       ||  _  |  |  ||     |  -__|        ||__|
                 |__|_|__||___._|___  ||__|__|_____|__|__|__||__|
                                |_____|                          ");

            Console.ResetColor();
        }

        /// <summary>
        /// prints text to the screen like an old timey text printer
        /// </summary>
        /// <param name="inputText">text to print</param>
        /// <param name="pauseDuration">break between the characters in milliseconds</param>
        static void oldTimeyTextPrinter(string inputText, int pauseDuration)
        {
            //loop over each character
            for (int i = 0; i < inputText.Length; i++)
            {
                //get a letter
                char letter = inputText[i];
                //print the letter to the screen
                Console.Write(letter);
                //create a pause
                System.Threading.Thread.Sleep(pauseDuration);
            }

            //after the text is complete, write a line break
            Console.WriteLine();
        }

    }
}
