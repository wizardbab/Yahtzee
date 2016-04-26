using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*************************************************************************************************/
/*                                                                                               */
/* Specifications of the dice which contain information about the current number of the dice and */
/*                                        its current state                                      */
/*                                                                                               */
/*************************************************************************************************/

namespace Yahtzee
{
    class Dice
    {
        private bool holdState = false; /* State of the dice whether it is being held or not     */
        private int  diceNumber;        /* Current value of the dice                             */

        Random number = new Random();

        // Properties
        public bool HoldState
        {
            get { return holdState; }
            set { holdState = value; }
        }
        public int DiceNumber
        {
            get { return diceNumber; }
            set { diceNumber = value; }
        }
    
    }
}
