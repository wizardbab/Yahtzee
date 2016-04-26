using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yahtzee
{
    class Score
    {
        public int CalculateThreeOfAKind(Dice[] dice)
        {
            int sum = 0;

            bool isThreeOfAKind = false;

            for (int i = 1; i <= 6; i++)
            {
                int count = 0;
                for (int j = 0; j < 5; j++)
                {
                    if (dice[j].DiceNumber == i)
                        count++;

                    if (count > 2)
                        isThreeOfAKind = true;
                }
            }

            if (isThreeOfAKind)
            {
                for (int k = 0; k < 5; k++)
                {
                    sum += dice[k].DiceNumber;
                }
            }

            return sum;
        }

        public int CalculateFourOfAKind(Dice[] dice)
        {
            int sum = 0;

            bool isFourOfAKind = false;

            for (int i = 1; i <= 6; i++)
            {
                int count = 0;
                for (int j = 0; j < 5; j++)
                {
                    if (dice[j].DiceNumber == i)
                        count++;

                    if (count > 3)
                        isFourOfAKind = true;
                }
            }

            if (isFourOfAKind)
            {
                for (int k = 0; k < 5; k++)
                {
                    sum += dice[k].DiceNumber;
                }
            }

            return sum;
        }
    }
}
