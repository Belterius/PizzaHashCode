using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaHashCode
{
    public class Pizza
    {
        //ROW,COLUMN
        Char[,] PizzaContent;

        public int NumberOfRow
        {
            get
            {
                return PizzaContent.GetLength(0);
            }
        }
        public int NumberOfColumn
        {
            get
            {
                return PizzaContent.GetLength(1);
            }
        }

        public Pizza(String[] inputPizza, int numberOfRow, int numberOfColumn)
        {

            PizzaContent = new Char[numberOfRow, numberOfColumn];
            int i = 0;
            foreach (String s in inputPizza)
            {
                char[] RowIngredient = s.ToCharArray();
                int j = 0;
                foreach (char c in RowIngredient)
                {
                    PizzaContent[i, j] = c;
                    j++;
                }
                i++;
            }
        }

        public int TomatoesInRow(int rowIndex)
        {
            int nbTomatoes = 0;
            for (int i = 0; i < NumberOfColumn; i++)
            {
                if (PizzaContent[rowIndex, i].Equals('T'))
                {
                    nbTomatoes++;
                }
            }
            return nbTomatoes;
        }
        public int MushroomInRow(int rowIndex)
        {
            int nbTomatoes = 0;
            for (int i = 0; i < NumberOfColumn; i++)
            {
                if (PizzaContent[rowIndex, i].Equals('M'))
                {
                    nbTomatoes++;
                }
            }
            return nbTomatoes;
        }
        public int TomatoesInColumn(int columnIndex)
        {
            int nbTomatoes = 0;
            for (int i = 0; i < NumberOfRow; i++)
            {
                if (PizzaContent[i, columnIndex].Equals('T'))
                {
                    nbTomatoes++;
                }
            }
            return nbTomatoes;
        }
        public int MushroomInColumn(int columnIndex)
        {
            int nbMushrooms = 0;
            for (int i = 0; i < NumberOfRow; i++)
            {
                if (PizzaContent[i, columnIndex].Equals('M'))
                {
                    nbMushrooms++;
                }
            }
            return nbMushrooms;
        }

    }
}
