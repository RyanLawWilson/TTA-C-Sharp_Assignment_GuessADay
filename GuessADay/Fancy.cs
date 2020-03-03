using System;
using System.Text;

// This class contains all of the cool formatting stuff that I've made.
public static class Fancy
{
    private static Random rand = new Random();

    // Dramatically displays ..... 
    public static void DotDotDot(int numOfDots = 10, int baseDelay = 500, int maxDelay = 100, int randomDots = 0)
    {
        numOfDots = numOfDots > 0 ? numOfDots : 5;
        numOfDots += rand.Next(0, randomDots);

        for (int i = 0; i < numOfDots; i++)
        {
            Console.Write(".");
            System.Threading.Thread.Sleep(baseDelay + rand.Next(0, maxDelay));
        }
    }

    /****************************************************************
     * Updated awesomeWrite.  Better overloading.  Simpler code.
    *****************************************************************/

    // The classic awesomeWrite renamed to Write to make typing faster.
    public static void Write(string text, int speed = 15, int afterPause = 50, bool ddd = false, ConsoleColor color = ConsoleColor.White)
    {
        speed = speed >= 5 && speed <= 100 ? speed : 15;    // Accept only speeds of between 5 and 100
        Console.ForegroundColor = color;

        foreach (char letter in text.ToCharArray())     // Convert text to char array to display each letter one at a time.
        {
            System.Threading.Thread.Sleep(speed);
            Console.Write(letter);
        }

        if (ddd) { DotDotDot(3); }

        System.Threading.Thread.Sleep(afterPause);
        Console.ForegroundColor = ConsoleColor.White;
    }

    // Now works with int
    public static void Write(int text, int speed = 15, int afterPause = 50)
    {
        speed = speed >= 5 && speed <= 100 ? speed : 15;

        foreach (char letter in text.ToString().ToCharArray())
        {
            System.Threading.Thread.Sleep(speed);
            Console.Write(letter);
        }

        System.Threading.Thread.Sleep(afterPause);
    }

    // Now works with double
    public static void Write(double text, int speed = 15, int afterPause = 50)
    {
        speed = speed >= 5 && speed <= 100 ? speed : 15;

        foreach (char letter in text.ToString().ToCharArray())
        {
            System.Threading.Thread.Sleep(speed);
            Console.Write(letter);
        }

        System.Threading.Thread.Sleep(afterPause);
    }

    // awesomeWrite built for StringBuilder
    public static void Write(StringBuilder text, int speed = 15, int afterPause = 50)
    {
        speed = speed >= 5 && speed <= 100 ? speed : 15;

        foreach (char letter in text.ToString().ToCharArray())
        {
            System.Threading.Thread.Sleep(speed);
            Console.Write(letter);
        }

        System.Threading.Thread.Sleep(afterPause);
    }

    // I often want to slow down in the middle of a sentence.  This method does that.
    public static void Write(string first, string mid, string last, int speed1 = 15, int speed2 = 75, int speed3 = 15, int pause = 333, int afterPause = 50)
    {
        speed1 = speed1 >= 5 && speed1 <= 100 ? speed1 : 15;    // Accept only speeds of between 5 and 100
        speed2 = speed2 >= 5 && speed2 <= 100 ? speed2 : 15;    // Accept only speeds of between 5 and 100
        speed3 = speed3 >= 5 && speed3 <= 100 ? speed3 : 15;    // Accept only speeds of between 5 and 100

        foreach (char letter in first.ToCharArray())
        {
            System.Threading.Thread.Sleep(speed1);
            Console.Write(letter);
        }

        System.Threading.Thread.Sleep(pause);

        foreach (char letter in mid.ToCharArray())
        {
            System.Threading.Thread.Sleep(speed2);
            Console.Write(letter);
        }

        System.Threading.Thread.Sleep(pause);

        foreach (char letter in last.ToCharArray())
        {
            System.Threading.Thread.Sleep(speed3);
            Console.Write(letter);
        }

        System.Threading.Thread.Sleep(afterPause);
    }

    // Method pauses in the middle of a string.
    public static void Write(string text1, string text2, int speed1 = 15, int speed2 = 15, int pause = 333, int afterPause = 50)
    {
        speed1 = speed1 >= 5 && speed1 <= 100 ? speed1 : 15;    // Accept only speeds of between 5 and 100
        speed2 = speed2 >= 5 && speed2 <= 100 ? speed2 : 15;    // Accept only speeds of between 5 and 100

        foreach (char letter in text1.ToCharArray())
        {
            System.Threading.Thread.Sleep(speed1);
            Console.Write(letter);
        }

        System.Threading.Thread.Sleep(pause);

        foreach (char letter in text2.ToCharArray())
        {
            System.Threading.Thread.Sleep(speed2);
            Console.Write(letter);
        }

        System.Threading.Thread.Sleep(afterPause);
    }
}