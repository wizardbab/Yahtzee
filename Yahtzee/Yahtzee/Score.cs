using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahtzee
{
    class Score
    {
        int digitsCount = 0; // Counts the number of digit scores filled in
        int totalCount = 0;  // Counts the number of scores filled in

        public int DigitsCount
        {
            get;
            set;
        }

        public int TotalCount
        {
            get;
            set;
        }

        // Calculates the number of points for a given number on the dice
        // and returns the number of points
        public int calculateDigits(int targetNumber, Dice[] dice)
        {
            int sum = 0;

            for(int i = 0; i < 5; i++)
            {
                if(dice[i].DiceNumber == targetNumber)
                    sum += targetNumber;
            }

            return sum;
        }

        // Calculates whether there is a three of a kind and returns the number of points
        public int calculateThreeOfAKind(Dice[] dice)
        {
            int sum = 0;

            bool isThreeOfAKind = false;

            for(int i = 1; i <= 6; i++)
            {
                int count = 0;
                for(int j = 0; j < 5; j++)
                {
                    if(dice[j].DiceNumber == i)
                        count++;

                    if(count > 2)
                        isThreeOfAKind = true;
                }
            }

            if(isThreeOfAKind)
            {
                for(int k = 0; k < 5; k++)
                {
                    sum += dice[k].DiceNumber;
                }
            }

            return sum;
        }

        // Calculates whether there is a four of a kind and return the number of points
        public int calculateFourOfAKind(Dice[] dice)
        {
            int sum = 0;

            bool isFourOfAKind = false;

            for(int i = 1; i <= 6; i++)
            {
                int count = 0;
                for(int j = 0; j < 5; j++)
                {
                    if(dice[j].DiceNumber == i)
                        count++;

                    if(count > 3)
                        isFourOfAKind = true;
                }
            }

            if(isFourOfAKind)
            {
                for(int k = 0; k < 5; k++)
                {
                    sum += dice[k].DiceNumber;
                }
            }

            return sum;
        }

        // Calculates whether two of one number and three of another exist
        // and return the number of points
        public int calculateFullHouse(Dice[] dice)
        {
            int sum = 0;

            int[] i = new int[5];

            for (int j = 0; j < 5; j++)
                i[j] = dice[j].DiceNumber;

            Array.Sort(i);

            if ((((i[0] == i[1]) && (i[1] == i[2])) && (i[3] == i[4]) && (i[2] != i[3])) ||
                ((i[0] == i[1]) && ((i[2] == i[3]) && (i[3] == i[4])) && (i[1] != i[2])))
            {
                sum = 25;
            }

            return sum;
        }

        // Check if there are four numbers in sequential order and return the number of points
        public int calculateSmallStraight(Dice[] dice)
        {
            int sum = 0;

            int[] i = new int[5];

            for(int j = 0; j < 5; j++)
            {
                i[j] = dice[j].DiceNumber;
            }

            Array.Sort(i);

            for(int j = 0; j < 4; j++)
            {
                int temp = 0;
                if(i[j] == i[j + 1])
                {
                    temp = i[j];

                    for(int k = j; k < 4; k++)
                        i[k] = i[k + 1];
                    i[4] = temp;
                }
            }

            if(((i[0] == 1) && (i[1] == 2) && (i[2] == 3) && (i[3] == 4)) ||
               ((i[0] == 2) && (i[1] == 3) && (i[2] == 4) && (i[3] == 5)) ||
               ((i[0] == 3) && (i[1] == 4) && (i[2] == 5) && (i[3] == 6)) ||
               ((i[1] == 1) && (i[2] == 2) && (i[3] == 3) && (i[4] == 4)) ||
               ((i[1] == 2) && (i[2] == 3) && (i[3] == 4) && (i[4] == 5)) ||
               ((i[1] == 3) && (i[2] == 4) && (i[3] == 5) && (i[4] == 6)))
                sum = 30;

            return sum;
        }

        // Check if all five numbers are in sequential order and return the number of points
        public int calculateLargeStraight(Dice[] dice)
        {
            int Sum = 0;

            int[] i = new int[5];

            for (int j = 0; j < 5; j++)
            {
                i[j] = dice[j].DiceNumber;
            }

            Array.Sort(i);

            if (((i[0] == 1) && (i[1] == 2) && (i[2] == 3) && (i[3] == 4) && (i[4] == 5)) ||
                ((i[0] == 2) && (i[1] == 3) && (i[2] == 4) && (i[3] == 5) && (i[4] == 6)))
                Sum = 40;

            return Sum;
        }

        // Return the sum of the five dice
        public int calculateChance(Dice[] dice)
        {
            int sum = 0;

            for(int i = 0; i < 5; i++)
                sum += dice[i].DiceNumber;

            return sum;
        }

        // Check if all five dice have the same number
        public int calculateYahtzee(Dice[] dice)
        {
            int sum = 0;

            for(int i = 1; i <= 6; i++)
            {
                int count = 0;

                for(int j = 0; j < 5; j++)
                {
                    if(dice[j].DiceNumber == i)
                        count++;

                    if(count == 5)
                        sum = 50;
                }
            }

            return sum;
        }
    }
}
