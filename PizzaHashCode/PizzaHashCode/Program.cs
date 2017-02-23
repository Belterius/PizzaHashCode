using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaHashCode
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader;
            int minIngredient;
            int maxIngredient;
            int numberOfColumns;
            int numberOfRows;

            String[] pizzaInput;

            reader = new StreamReader(@"c:\users\belterius\documents\visual studio 2015\Projects\PizzaHashCode\PizzaHashCode\Example\small.in");
            string line;
            line = reader.ReadLine();
            string[] inputParameter = line.Split(' ');
            numberOfRows = Convert.ToInt32(inputParameter[0]);
            numberOfColumns = Convert.ToInt32(inputParameter[1]);
            minIngredient = Convert.ToInt32(inputParameter[2]);
            maxIngredient = Convert.ToInt32(inputParameter[3]);

            pizzaInput = new String[numberOfRows];
            int i = 0;
            while ((line = reader.ReadLine()) != null)
            {
                pizzaInput[i] = line;
                i++;
                Console.WriteLine(line);
            }
            Pizza myPizza = new Pizza(pizzaInput, numberOfRows, numberOfColumns);
            reader.Close();

            using (StreamWriter outputFile = new StreamWriter(@"c:\users\belterius\documents\visual studio 2015\Projects\PizzaHashCode\PizzaHashCode\Example\small.out"))
            {
                for (int j = 0; j < numberOfRows; j++)
                {

                    outputFile.WriteLine("Lignes   Tomates : " + myPizza.TomatoesInRow(j) + " Champignons : " + myPizza.MushroomInRow(j));
                    Console.WriteLine("Lignes   Tomates : " + myPizza.TomatoesInRow(j) + " Champignons : " + myPizza.MushroomInRow(j));
                }
                for (int j = 0; j < numberOfColumns; j++)
                {
                    outputFile.WriteLine("Colonne Tomates : " + myPizza.TomatoesInColumn(j) + " Champignons : " + myPizza.MushroomInColumn(j));
                    Console.WriteLine("Colonne Tomates : " + myPizza.TomatoesInColumn(j) + " Champignons : " + myPizza.MushroomInColumn(j));
                }
            }

            Console.ReadLine();
        }
    }
}
