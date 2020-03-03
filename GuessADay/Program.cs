using System;

class Program
{
    static void Main(string[] args)
    {
        // This part is to satisfy step 2. of the Assignment.
        bool wrongDay = true;
        while (wrongDay)
        {
            Fancy.Write("What day is it today?  ");

            Days today;
            try
            {
                bool isValidDay = Enum.TryParse(Console.ReadLine(), out today);
                if (isValidDay)
                {
                    if (today.ToString().Equals(DateTime.Today.DayOfWeek.ToString()))
                    {
                        wrongDay = false;
                        Fancy.Write("Yes it is!!!\n", color: ConsoleColor.Green, afterPause: 500);
                        Fancy.Write("\nNow let's play a game!\n", color: ConsoleColor.White, afterPause: 1000);
                    }
                    else
                    {
                        Fancy.Write("No it's not...  Check your calendar\n", color: ConsoleColor.Yellow, afterPause: 500);
                    }
                }
                else
                {
                    throw new FormatException();
                }
            }
            catch (FormatException)
            {
                Fancy.Write("Please enter an actual day of the week.\n", 50, afterPause: 333, color: ConsoleColor.Yellow);
            }
            catch (Exception ex)
            {
                Fancy.Write("An error occured | error: " + ex.GetType() + "\n", 5, color: ConsoleColor.Red);
            }
        }
        
        // The Guess-a-Day game starts here.

        Fancy.Write("\nWelcome to Guess-a-Day", color: ConsoleColor.Yellow);
        Fancy.DotDotDot(3);

        int plays = 1;                  // The number of times the player played the game.
        int win = 0;                    // The number of wins
        int loss = 0;                   // The number of losses
        bool playAgain = true;          // false when the user doesn't want to play anymore.
        while (playAgain)
        {
            Fancy.Write("\nTry to guess the day of the week I'm thinking of\n\n", color: ConsoleColor.DarkCyan, afterPause: 1000);

            Random rand = new Random();
            Days answer = (Days)rand.Next(0, 7);

            // Keep asking for a valid day until the user gives it.
            bool invalidAnswer = true;
            while (invalidAnswer)
            {
                Fancy.Write("\tWhat is your guess: ");
                Console.ForegroundColor = ConsoleColor.Green;

                // Determine if the guess is in the enumeration and return the Day corresponding to the input.
                Days guess;
                try
                {
                    bool isGuessValid = Enum.TryParse(Console.ReadLine(), out guess);
                    if (isGuessValid)
                    {
                        invalidAnswer = false;
                        Fancy.Write("\tThat is");
                        Fancy.DotDotDot(3, randomDots: 5);

                        // If correct, increment wins, else incremenet losses.
                        if (answer == guess)
                        {
                            Fancy.Write("  Correct!!  ", afterPause: 333, color: ConsoleColor.Green);
                            Fancy.Write("it was " + answer, afterPause: 500);
                            win++;
                        }
                        else
                        {
                            Fancy.Write("  Incorrect...  ", afterPause: 333, color: ConsoleColor.Red);
                            Fancy.Write("it was " + answer, afterPause: 500);
                            loss++;
                        }
                    }
                    else
                    {
                        throw new FormatException();
                    }
                }
                catch (FormatException)
                {
                    Fancy.Write("\tPlease enter an actual day of the week.\n", 50, afterPause: 333, color: ConsoleColor.Yellow);
                }
                catch (Exception ex)
                {
                    Fancy.Write("An error occured | error: " + ex.GetType() + "\n", 5, color: ConsoleColor.Red);
                }
            }

            Score(win, loss, plays);

            // Ask to play again
            Fancy.Write("\nDo you want to play again? (y or n) ", color: ConsoleColor.Yellow);
            string playAgainChoice = Console.ReadLine();
            if (playAgainChoice != "y")
            {
                playAgain = false;
            }
            plays++;
        }
        
        Fancy.Write($"\n\nHave a nice {DateTime.Today.DayOfWeek}!");
        Console.ReadLine();
    }

    // Show the score of the player
    public static void Score(int win, int loss, int plays)
    {
        Fancy.Write($"\n\nWins: {win}", afterPause: 0, color: ConsoleColor.Green);
        Fancy.Write("  |  ", afterPause: 0);
        Fancy.Write($"Losses: {loss}", afterPause: 0, color: ConsoleColor.Red);
        Fancy.Write("  |  ", afterPause: 0);

        // Change the color of your win ratio based on the ratio itself
        double winRate = (double)win / plays * 100;
        ConsoleColor color;
        if (winRate > 13)
        {
            color = ConsoleColor.Green;
        }
        else if (winRate < 6)
        {
            color = ConsoleColor.Red;
        }
        else
        {
            color = ConsoleColor.Yellow;
        }
        Fancy.Write(String.Format("Win Rate: {0:F2}%", winRate), afterPause: 750, color: color);
    }
}

public enum Days
{
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
}