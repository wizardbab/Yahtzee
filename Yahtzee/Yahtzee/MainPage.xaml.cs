using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

/*********************************************************************************************/
/*                                                                                           */
/* This program is a yahtzee game, YAYZEE!!! The user rolls the dice, and the game will take */
/* the current value of the dice that is(are) being held by the user. Then the game will     */
/* calculate each of the scoreboard's category and show the user*/
/*                                                                                           */
/*********************************************************************************************/

namespace Yahtzee
{
    public sealed partial class MainPage : Page
    {
        Score scoreboard = new Score();
        int digitScore = 0; // Stores the score for the single digits
        int totalScore = 0; // Stores the score for the entire game
        public MainPage()
        {
            this.InitializeComponent();
            holdDice1.IsEnabled = holdDice2.IsEnabled = holdDice3.IsEnabled =
            holdDice4.IsEnabled = holdDice5.IsEnabled = rollDiceBtn.IsEnabled = false;

        }

        // Symbolic Constant
        const int MAXIMUM_DICE = 5;  /* Maximum number of dices                               */
        const int MAXIMUM_ROLL = 13; /* Maximum number of rolls per game                      */

        // Global Variable
        Dice[] dices = new Dice[MAXIMUM_DICE]; /* Array of dice                               */
        int click_number = 0;                 /* Keep track of number of button click(s)     */

        // Controls' Event Handler
        private void startGame_Click(object sender, RoutedEventArgs e) // Start YAHTZEE button
        {
            /* Create multiple dice                                                          */
            initialDice();

            rollDiceBtn.IsEnabled = true;
            startGameBtn.IsEnabled = false;
            startGameBtn.Opacity = 0;
            resetScoreboard();
        }

        private void rollDiceBtn_Click(object sender, RoutedEventArgs e) // Roll the dice button
        {
            Random number = new Random();
            int dice_index;               /* Index of every dice                             */

            /* Enable (Un)Hold button of each dice                                           */
            holdDice1.IsEnabled = holdDice2.IsEnabled = holdDice3.IsEnabled =
            holdDice4.IsEnabled = holdDice5.IsEnabled = true;

            /* The dice are (or is) rolling if it is not held                                */
            for (dice_index = 0; dice_index < MAXIMUM_DICE; dice_index++)
            {
                if (dices[dice_index].HoldState == false)
                    dices[dice_index].DiceNumber = number.Next(1, 7);
            }

            /* Rolling the dice                                                              */
            #region Rolling dice
            switch (dices[0].DiceNumber)
            {
                case 1:
                    dice1_1.Opacity = 1;
                    dice1_2.Opacity = 0;
                    dice1_3.Opacity = 0;
                    dice1_4.Opacity = 0;
                    dice1_5.Opacity = 0;
                    dice1_6.Opacity = 0;
                    break;
                case 2:
                    dice1_1.Opacity = 0;
                    dice1_2.Opacity = 1;
                    dice1_3.Opacity = 0;
                    dice1_4.Opacity = 0;
                    dice1_5.Opacity = 0;
                    dice1_6.Opacity = 0;
                    break;
                case 3:
                    dice1_1.Opacity = 0;
                    dice1_2.Opacity = 0;
                    dice1_3.Opacity = 1;
                    dice1_4.Opacity = 0;
                    dice1_5.Opacity = 0;
                    dice1_6.Opacity = 0;
                    break;
                case 4:
                    dice1_1.Opacity = 0;
                    dice1_2.Opacity = 0;
                    dice1_3.Opacity = 0;
                    dice1_4.Opacity = 1;
                    dice1_5.Opacity = 0;
                    dice1_6.Opacity = 0;
                    break;
                case 5:
                    dice1_1.Opacity = 0;
                    dice1_2.Opacity = 0;
                    dice1_3.Opacity = 0;
                    dice1_4.Opacity = 0;
                    dice1_5.Opacity = 1;
                    dice1_6.Opacity = 0;
                    break;
                case 6:
                    dice1_1.Opacity = 0;
                    dice1_2.Opacity = 0;
                    dice1_3.Opacity = 0;
                    dice1_4.Opacity = 0;
                    dice1_5.Opacity = 0;
                    dice1_6.Opacity = 1;
                    break;
            }

            switch (dices[1].DiceNumber)
            {
                case 1:
                    dice2_1.Opacity = 1;
                    dice2_2.Opacity = 0;
                    dice2_3.Opacity = 0;
                    dice2_4.Opacity = 0;
                    dice2_5.Opacity = 0;
                    dice2_6.Opacity = 0;
                    break;
                case 2:
                    dice2_1.Opacity = 0;
                    dice2_2.Opacity = 1;
                    dice2_3.Opacity = 0;
                    dice2_4.Opacity = 0;
                    dice2_5.Opacity = 0;
                    dice2_6.Opacity = 0;
                    break;
                case 3:
                    dice2_1.Opacity = 0;
                    dice2_2.Opacity = 0;
                    dice2_3.Opacity = 1;
                    dice2_4.Opacity = 0;
                    dice2_5.Opacity = 0;
                    dice2_6.Opacity = 0;
                    break;
                case 4:
                    dice2_1.Opacity = 0;
                    dice2_2.Opacity = 0;
                    dice2_3.Opacity = 0;
                    dice2_4.Opacity = 1;
                    dice2_5.Opacity = 0;
                    dice2_6.Opacity = 0;
                    break;
                case 5:
                    dice2_1.Opacity = 0;
                    dice2_2.Opacity = 0;
                    dice2_3.Opacity = 0;
                    dice2_4.Opacity = 0;
                    dice2_5.Opacity = 1;
                    dice2_6.Opacity = 0;
                    break;
                case 6:
                    dice2_1.Opacity = 0;
                    dice2_2.Opacity = 0;
                    dice2_3.Opacity = 0;
                    dice2_4.Opacity = 0;
                    dice2_5.Opacity = 0;
                    dice2_6.Opacity = 1;
                    break;
            }

            switch (dices[2].DiceNumber)
            {
                case 1:
                    dice3_1.Opacity = 1;
                    dice3_2.Opacity = 0;
                    dice3_3.Opacity = 0;
                    dice3_4.Opacity = 0;
                    dice3_5.Opacity = 0;
                    dice3_6.Opacity = 0;
                    break;
                case 2:
                    dice3_1.Opacity = 0;
                    dice3_2.Opacity = 1;
                    dice3_3.Opacity = 0;
                    dice3_4.Opacity = 0;
                    dice3_5.Opacity = 0;
                    dice3_6.Opacity = 0;
                    break;
                case 3:
                    dice3_1.Opacity = 0;
                    dice3_2.Opacity = 0;
                    dice3_3.Opacity = 1;
                    dice3_4.Opacity = 0;
                    dice3_5.Opacity = 0;
                    dice3_6.Opacity = 0;
                    break;
                case 4:
                    dice3_1.Opacity = 0;
                    dice3_2.Opacity = 0;
                    dice3_3.Opacity = 0;
                    dice3_4.Opacity = 1;
                    dice3_5.Opacity = 0;
                    dice3_6.Opacity = 0;
                    break;
                case 5:
                    dice3_1.Opacity = 0;
                    dice3_2.Opacity = 0;
                    dice3_3.Opacity = 0;
                    dice3_4.Opacity = 0;
                    dice3_5.Opacity = 1;
                    dice3_6.Opacity = 0;
                    break;
                case 6:
                    dice3_1.Opacity = 0;
                    dice3_2.Opacity = 0;
                    dice3_3.Opacity = 0;
                    dice3_4.Opacity = 0;
                    dice3_5.Opacity = 0;
                    dice3_6.Opacity = 1;
                    break;
            }

            switch (dices[3].DiceNumber)
            {
                case 1:
                    dice4_1.Opacity = 1;
                    dice4_2.Opacity = 0;
                    dice4_3.Opacity = 0;
                    dice4_4.Opacity = 0;
                    dice4_5.Opacity = 0;
                    dice4_6.Opacity = 0;
                    break;
                case 2:
                    dice4_1.Opacity = 0;
                    dice4_2.Opacity = 1;
                    dice4_3.Opacity = 0;
                    dice4_4.Opacity = 0;
                    dice4_5.Opacity = 0;
                    dice4_6.Opacity = 0;
                    break;
                case 3:
                    dice4_1.Opacity = 0;
                    dice4_2.Opacity = 0;
                    dice4_3.Opacity = 1;
                    dice4_4.Opacity = 0;
                    dice4_5.Opacity = 0;
                    dice4_6.Opacity = 0;
                    break;
                case 4:
                    dice4_1.Opacity = 0;
                    dice4_2.Opacity = 0;
                    dice4_3.Opacity = 0;
                    dice4_4.Opacity = 1;
                    dice4_5.Opacity = 0;
                    dice4_6.Opacity = 0;
                    break;
                case 5:
                    dice4_1.Opacity = 0;
                    dice4_2.Opacity = 0;
                    dice4_3.Opacity = 0;
                    dice4_4.Opacity = 0;
                    dice4_5.Opacity = 1;
                    dice4_6.Opacity = 0;
                    break;
                case 6:
                    dice4_1.Opacity = 0;
                    dice4_2.Opacity = 0;
                    dice4_3.Opacity = 0;
                    dice4_4.Opacity = 0;
                    dice4_5.Opacity = 0;
                    dice4_6.Opacity = 1;
                    break;
            }

            switch (dices[4].DiceNumber)
            {
                case 1:
                    dice5_1.Opacity = 1;
                    dice5_2.Opacity = 0;
                    dice5_3.Opacity = 0;
                    dice5_4.Opacity = 0;
                    dice5_5.Opacity = 0;
                    dice5_6.Opacity = 0;
                    break;
                case 2:
                    dice5_1.Opacity = 0;
                    dice5_2.Opacity = 1;
                    dice5_3.Opacity = 0;
                    dice5_4.Opacity = 0;
                    dice5_5.Opacity = 0;
                    dice5_6.Opacity = 0;
                    break;
                case 3:
                    dice5_1.Opacity = 0;
                    dice5_2.Opacity = 0;
                    dice5_3.Opacity = 1;
                    dice5_4.Opacity = 0;
                    dice5_5.Opacity = 0;
                    dice5_6.Opacity = 0;
                    break;
                case 4:
                    dice5_1.Opacity = 0;
                    dice5_2.Opacity = 0;
                    dice5_3.Opacity = 0;
                    dice5_4.Opacity = 1;
                    dice5_5.Opacity = 0;
                    dice5_6.Opacity = 0;
                    break;
                case 5:
                    dice5_1.Opacity = 0;
                    dice5_2.Opacity = 0;
                    dice5_3.Opacity = 0;
                    dice5_4.Opacity = 0;
                    dice5_5.Opacity = 1;
                    dice5_6.Opacity = 0;
                    break;
                case 6:
                    dice5_1.Opacity = 0;
                    dice5_2.Opacity = 0;
                    dice5_3.Opacity = 0;
                    dice5_4.Opacity = 0;
                    dice5_5.Opacity = 0;
                    dice5_6.Opacity = 1;
                    break;
            }
            #endregion

            /* If the number of button clicks reach its maximum value, restart the game      */
            click_number++;
            if (click_number == MAXIMUM_ROLL)
            {
                rollDiceBtn.IsEnabled = false;
                startGameBtn.IsEnabled = true;
                startGameBtn.Opacity = 1;
                startGameBtn.Content = "Restart";
                click_number = 0;
                markDice1.Opacity = markDice2.Opacity = markDice3.Opacity = markDice4.Opacity
                                       = markDice5.Opacity = 0;
                holdDice1.Content = holdDice2.Content = holdDice3.Content = holdDice4.Content
                                       = holdDice5.Content = "Hold";
                holdDice1.IsEnabled = holdDice2.IsEnabled = holdDice3.IsEnabled
                                       = holdDice4.IsEnabled = holdDice5.IsEnabled = false;
            }
        }

        #region Hold or unhold
        private void holdDice1Btn(object sender, RoutedEventArgs e) // Hold or unhold dice number 1
        {
            if (dices[0].HoldState == false)
            {
                dices[0].HoldState = true;
                dices[0].holdValue(dices[0].DiceNumber);
                markDice1.Opacity = 1;
                holdDice1.Content = "Unhold";
            }
            else
            {
                dices[0].HoldState = false;
                markDice1.Opacity = 0;
                holdDice1.Content = "Hold";
            }
            checkHoldButton();
        }
        private void holdDice2Btn(object sender, RoutedEventArgs e) // Hold or unhold dice number 2
        {
            if (dices[1].HoldState == false)
            {
                dices[1].HoldState = true;
                dices[1].holdValue(dices[1].DiceNumber);
                markDice2.Opacity = 1;
                holdDice2.Content = "Unhold";
            }
            else
            {
                dices[1].HoldState = false;
                markDice2.Opacity = 0;
                holdDice2.Content = "Hold";
            }
            checkHoldButton();
        }
        private void holdDice3Btn(object sender, RoutedEventArgs e) // Hold or unhold dice number 3
        {
            if (dices[2].HoldState == false)
            {
                dices[2].HoldState = true;
                dices[2].holdValue(dices[2].DiceNumber);
                markDice3.Opacity = 1;
                holdDice3.Content = "Unhold";
            }
            else
            {
                dices[2].HoldState = false;
                markDice3.Opacity = 0;
                holdDice3.Content = "Hold";
            }
            checkHoldButton();
        }
        private void holdDice4Btn(object sender, RoutedEventArgs e) // Hold or unhold dice number 4
        {
            if (dices[3].HoldState == false)
            {
                dices[3].HoldState = true;
                dices[3].holdValue(dices[3].DiceNumber);
                markDice4.Opacity = 1;
                holdDice4.Content = "Unhold";
            }
            else
            {
                dices[3].HoldState = false;
                markDice4.Opacity = 0;
                holdDice4.Content = "Hold";
            }
            checkHoldButton();
        }
        private void holdDice5Btn(object sender, RoutedEventArgs e) // Hold or unhold dice number 5
        {
            if (dices[4].HoldState == false)
            {
                dices[4].HoldState = true;
                dices[4].holdValue(dices[4].DiceNumber);
                markDice5.Opacity = 1;
                holdDice5.Content = "Unhold";
            }
            else
            {
                dices[4].HoldState = false;
                markDice5.Opacity = 0;
                holdDice5.Content = "Hold";
            }
            checkHoldButton();
        }
        #endregion

        // Program Functions
        public void initialDice() // Create an object of dice
        {
            int diceIndex;                       /* Index of every dice in the list          */

            for (diceIndex = 0; diceIndex < MAXIMUM_DICE; diceIndex++)
                dices[diceIndex] = new Dice();
        }

        public void checkHoldButton() // Disable roll button if all dice are held
        {
            if (dices[0].HoldState == true && dices[1].HoldState == true && dices[2].HoldState == true
                                           && dices[3].HoldState == true && dices[4].HoldState == true)
            {
                rollDiceBtn.IsEnabled = false;
            }
            else
                rollDiceBtn.IsEnabled = true;

        }

        private void digitButton_Clicked(object sender, RoutedEventArgs e)
        {
            ((Button)sender).Content = scoreboard.calculateDigits(int.Parse(((Button)sender).Tag.ToString()), dices);
            ((Button)sender).IsEnabled = false;
        }

        private void threeOfAKindButton_Clicked(object sender, RoutedEventArgs e)
        {
            ((Button)sender).Content = scoreboard.calculateThreeOfAKind(dices);
            ((Button)sender).IsEnabled = false;
        }

        private void fourOfAKindButton_Clicked(object sender, RoutedEventArgs e)
        {
            ((Button)sender).Content = scoreboard.calculateFourOfAKind(dices);
            ((Button)sender).IsEnabled = false;
        }

        private void fullHouseButton_Clicked(object sender, RoutedEventArgs e)
        {
            ((Button)sender).Content = scoreboard.calculateFullHouse(dices);
            ((Button)sender).IsEnabled = false;
        }

        private void smallStraightButton_Clicked(object sender, RoutedEventArgs e)
        {
            ((Button)sender).Content = scoreboard.calculateSmallStraight(dices);
            ((Button)sender).IsEnabled = false;
        }

        private void largeStraightButton_Clicked(object sender, RoutedEventArgs e)
        {
            ((Button)sender).Content = scoreboard.calculateLargeStraight(dices);
            ((Button)sender).IsEnabled = false;
        }

        private void chanceButton_Clicked(object sender, RoutedEventArgs e)
        {
            ((Button)sender).Content = scoreboard.calculateChance(dices);
            ((Button)sender).IsEnabled = false;
        }

        private void yahtzeeButton_Clicked(object sender, RoutedEventArgs e)
        {
            ((Button)sender).Content = scoreboard.calculateYahtzee(dices);
            ((Button)sender).IsEnabled = false;
        }

        private void numbersBonusTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(digitScore >= 63)
            {
                totalScore += 35;
                numbersBonusTextBox.Text = "35";
            }
        }

        private void resetScoreboard()
        {
            onesButton.IsEnabled = true;
            twosButton.IsEnabled = true;
            threesButton.IsEnabled = true;
            foursButton.IsEnabled = true;
            fivesButton.IsEnabled = true;
            sixesButton.IsEnabled = true;
            threeOfAKindButton.IsEnabled = true;
            fourOfAKindButton.IsEnabled = true;
            fullHouseButton.IsEnabled = true;
            smallStraightButton.IsEnabled = true;
            largeStraightButton.IsEnabled = true;
            chanceButton.IsEnabled = true;
            yahtzeeButton.IsEnabled = true;

            onesButton.Content = "";
            twosButton.Content = "";
            threesButton.Content = "";
            foursButton.Content = "";
            fivesButton.Content = "";
            sixesButton.Content = "";
            threeOfAKindButton.Content = "";
            fourOfAKindButton.Content = "";
            fullHouseButton.Content = "";
            smallStraightButton.Content = "";
            largeStraightButton.Content = "";
            chanceButton.Content = "";
            yahtzeeButton.Content = "";
        }
    }
}