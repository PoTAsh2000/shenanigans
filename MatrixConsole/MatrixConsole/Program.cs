using System;
using System.Text;
using System.Threading;

namespace MatrixConsole
{
    class Program
    {
        const string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890><{}[]*&^%$#@+_-/";

        static void Main(string[] args)
        {
            int width = Console.WindowWidth;
            Console.ForegroundColor = ConsoleColor.Green;

            // infinite loop
            while (true)
            {
                // create and display rows with random characters
                string row = "";
                for (int i = 0; i < width / 2; i++)
                {
                    row += CharPicker() + " ";
                }
                Console.WriteLine(row);
                Thread.Sleep(100);
            }
        }

        static char CharPicker()
        {
            // generete a random number between 0 and 101
            Random rnd = new Random();
            int chance = rnd.Next(0, 101);

            // there is 20% chance that a character will be picked.
            if (chance >= 0 && chance <= 20)
            {
                // return a random character from the characters string
                int charIndex = rnd.Next(0, characters.Length);
                return characters[charIndex];
            }
            // if the chance is not between 0 and 20 a whitespace will be returned
            return ' ';
        }

    }
}
