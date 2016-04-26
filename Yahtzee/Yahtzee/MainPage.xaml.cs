﻿using System;
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
        public MainPage()
        {
            this.InitializeComponent();
            holdDice1.IsEnabled = holdDice2.IsEnabled = holdDice3.IsEnabled =
            holdDice4.IsEnabled = holdDice5.IsEnabled = rollDiceBtn.IsEnabled = false;

            if (grandTotalTextBox.Text != string.Empty)
            {
                startGameBtn.IsEnabled = true;
                startGameBtn.Opacity = 1;
                startGameBtn.Content = "Restart";
            }
        }

        // Symbolic Constant
        const int MAXIMUM_DICE = 5;  /* Maximum number of dices                               */
        const int MAXIMUM_ROLL = 3;  /* Maximum number of rolls per game                      */

        // Global Variable
        Dice[] dices = new Dice[MAXIMUM_DICE]; /* Array of dice                               */
        Score scoreboard = new Score();
        int count_roll = 0,                    /* Keep track of number of dice is roll        */
            digitScore = 0,                    /* Stores the score for the single digits      */
            totalScore = 0;                    /* Stores the score for the entire game        */

        // Controls' Event Handler
        private void gameTitle_SelectionChanged(object sender, RoutedEventArgs e) // Title of the program
        { }

        private void startGame_Click(object sender, RoutedEventArgs e) // Start YAHTZEE button
        {
            /* Create multiple dice                                                           */
            initialDice();

            rollDiceBtn.IsEnabled = true;
            startGameBtn.IsEnabled = false;
            startGameBtn.Opacity = 0;
            resetScoreboard();
        }

        private void rollDiceBtn_Click(object sender, RoutedEventArgs e) // Roll the dice button
        {
            Random number = new Random();
            int dice_index;               /* Index of every dice                              */

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

            /* Enable Scoreboard Buttons                                                      */
            if (onesButton.Content as string != string.Empty)
               onesButton.IsEnabled = false;
            if (twosButton.Content as string != string.Empty)
               twosButton.IsEnabled = false;
            if (threesButton.Content as string != string.Empty)
               threesButton.IsEnabled = false;
            if (foursButton.Content as string != string.Empty)
               foursButton.IsEnabled = false;
            if (fivesButton.Content as string != string.Empty)
                fivesButton.IsEnabled = false;
            if (sixesButton.Content as string != string.Empty)
                sixesButton.IsEnabled = false;
            if (threeOfAKindButton.Content as string != string.Empty)
                threeOfAKindButton.IsEnabled = false;
            if (fourOfAKindButton.Content as string != string.Empty)
                fourOfAKindButton.IsEnabled = false;
            if (fullHouseButton.Content as string != string.Empty)
                fullHouseButton.IsEnabled = false;
            if (smallStraightButton.Content as string != string.Empty)
                smallStraightButton.IsEnabled = false;
            if (largeStraightButton.Content as string != string.Empty)
                largeStraightButton.IsEnabled = false;
            if (chanceButton.Content as string != string.Empty)
                chanceButton.IsEnabled = false;
            if (yahtzeeButton.Content as string != string.Empty)
                yahtzeeButton.IsEnabled = false;

            /* Enable (Un)Hold button of each dice                                            */
            holdDice1.IsEnabled = holdDice2.IsEnabled = holdDice3.IsEnabled =
            holdDice4.IsEnabled = holdDice5.IsEnabled = true;

            /* The dice are (or is) rolling if it is not held                                 */
            for (dice_index = 0; dice_index < MAXIMUM_DICE; dice_index++)
            {
                if (dices[dice_index].HoldState == false)
                    dices[dice_index].DiceNumber = number.Next(1, 7);
            }

            /* Rolling the dice                                                               */
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

            /* If the number of button clicks reach its maximum value, restart the game       */
            count_roll++;
            if (count_roll == MAXIMUM_ROLL)
            {
                rollDiceBtn.IsEnabled = false;
                count_roll = 0;
                markDice1.Opacity = markDice2.Opacity = markDice3.Opacity = markDice4.Opacity = markDice5.Opacity = 0;
                holdDice1.IsEnabled = holdDice2.IsEnabled = holdDice3.IsEnabled = holdDice4.IsEnabled = holdDice5.IsEnabled = false;
                holdDice1.Content = holdDice2.Content = holdDice3.Content = holdDice4.Content = holdDice5.Content = "Hold";

            }
        }

        #region Hold or unhold
        private void holdDice1Btn(object sender, RoutedEventArgs e) // Hold or unhold dice number 1
        {
            if (dices[0].HoldState == false)
            {
                dices[0].HoldState = true;
                //dices[0].holdValue(dices[0].DiceNumber);
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
                //dices[1].holdValue(dices[1].DiceNumber);
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
                //dices[2].holdValue(dices[2].DiceNumber);
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
                //dices[3].holdValue(dices[3].DiceNumber);
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
                //dices[4].holdValue(dices[4].DiceNumber);
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
        #region ScoreBoard button

        // Digits buttons score
        private void digitButton_Clicked(object sender, RoutedEventArgs e)
        {
            ((Button)sender).Content = scoreboard.calculateDigits(int.Parse(((Button)sender).Tag.ToString()), dices);
            ((Button)sender).IsEnabled = false;
            scoreboard.DigitsCount++;
            digitScore += scoreboard.calculateDigits(int.Parse(((Button)sender).Tag.ToString()), dices);
            totalScore += scoreboard.calculateDigits(int.Parse(((Button)sender).Tag.ToString()), dices);
            scoreboard.TotalCount++;
            checkDigitScore();
            checkTotalScore();
            resetTurn();
        }

        // Three of a kind button score
        private void threeOfAKindButton_Clicked(object sender, RoutedEventArgs e)
        {
            ((Button)sender).Content = scoreboard.calculateThreeOfAKind(dices);
            ((Button)sender).IsEnabled = false;
            totalScore += scoreboard.calculateThreeOfAKind(dices);
            scoreboard.TotalCount++;
            checkTotalScore();
            resetTurn();
        }

        // Four of a kind button score
        private void fourOfAKindButton_Clicked(object sender, RoutedEventArgs e)
        {
            ((Button)sender).Content = scoreboard.calculateFourOfAKind(dices);
            ((Button)sender).IsEnabled = false;
            totalScore += scoreboard.calculateFourOfAKind(dices);
            scoreboard.TotalCount++;
            checkTotalScore();
            resetTurn();
        }

        // Full house button score
        private void fullHouseButton_Clicked(object sender, RoutedEventArgs e)
        {
            ((Button)sender).Content = scoreboard.calculateFullHouse(dices);
            ((Button)sender).IsEnabled = false;
            totalScore += scoreboard.calculateFullHouse(dices);
            scoreboard.TotalCount++;
            checkTotalScore();
            resetTurn();
        }

        //Small straight button score
        private void smallStraightButton_Clicked(object sender, RoutedEventArgs e)
        {
            ((Button)sender).Content = scoreboard.calculateSmallStraight(dices);
            ((Button)sender).IsEnabled = false;
            totalScore += scoreboard.calculateSmallStraight(dices);
            scoreboard.TotalCount++;
            checkTotalScore();
            resetTurn();
        }

        // Large straight button score
        private void largeStraightButton_Clicked(object sender, RoutedEventArgs e)
        {
            ((Button)sender).Content = scoreboard.calculateLargeStraight(dices);
            ((Button)sender).IsEnabled = false;
            totalScore += scoreboard.calculateLargeStraight(dices);
            scoreboard.TotalCount++;
            checkTotalScore();
            resetTurn();
        }

        // Chance button score
        private void chanceButton_Clicked(object sender, RoutedEventArgs e)
        {
            ((Button)sender).Content = scoreboard.calculateChance(dices);
            ((Button)sender).IsEnabled = false;
            totalScore += scoreboard.calculateChance(dices);
            scoreboard.TotalCount++;
            checkTotalScore();
            resetTurn();
        }

        // Yahtzee button score
        private void yahtzeeButton_Clicked(object sender, RoutedEventArgs e)
        {
            ((Button)sender).Content = scoreboard.calculateYahtzee(dices);
            ((Button)sender).IsEnabled = false;
            totalScore += scoreboard.calculateYahtzee(dices);
            scoreboard.TotalCount++;
            checkTotalScore();
            resetTurn();
        }

        // Checks if all six digit scores have been entered
        private void checkDigitScore()
        {
            if(scoreboard.DigitsCount == 6)
            {
                numbersTotalTextBox.Text = digitScore.ToString();
                if(digitScore >= 63)
                {
                    totalScore += 35;
                    numbersBonusTextBox.Text = "35";
                }
                else
                {
                    numbersBonusTextBox.Text = "0";
                }
            }
        }

        // Checks if all thirteen scores have been entered and restarts the game
        private void checkTotalScore()
        {
            if(scoreboard.TotalCount == 13)
            {
                grandTotalTextBox.Text = totalScore.ToString();

                startGameBtn.IsEnabled = true;
                startGameBtn.Opacity = 1;
                startGameBtn.Content = "Restart";
            }
        }
        #endregion

        // Program Functions
        public void initialDice() // Create an object of dice
        {
            int diceIndex; /* Index of every dice in the list           */

            for (diceIndex = 0; diceIndex < MAXIMUM_DICE; diceIndex++)
                dices[diceIndex] = new Dice();
        }

        // Disable roll button if all dice are held
        public void checkHoldButton()
        {
            if (dices[0].HoldState == true && dices[1].HoldState == true && dices[2].HoldState == true
                                           && dices[3].HoldState == true && dices[4].HoldState == true)
            {
                rollDiceBtn.IsEnabled = false;
            }
            else
                rollDiceBtn.IsEnabled = true;

        }

        // Reset the scoreboard back to default value
        private void resetScoreboard()
        {
            onesButton.Content            = "";
            twosButton.Content            = "";
            threesButton.Content          = "";
            foursButton.Content           = "";
            fivesButton.Content           = "";
            sixesButton.Content           = "";
            threeOfAKindButton.Content    = "";
            fourOfAKindButton.Content     = "";
            fullHouseButton.Content       = "";
            smallStraightButton.Content   = "";
            largeStraightButton.Content   = "";
            chanceButton.Content          = "";
            yahtzeeButton.Content         = "";
            numbersTotalTextBox.Text      = "";
            numbersBonusTextBox.Text      = "";
            grandTotalTextBox.Text        = "";
        }

        // Changes the controls for the start of a new turn
        private void resetTurn()
        {
            count_roll = 0;
            markDice1.Opacity = markDice2.Opacity = markDice3.Opacity = markDice4.Opacity = markDice5.Opacity = 0;
            holdDice1.IsEnabled = holdDice2.IsEnabled = holdDice3.IsEnabled = holdDice4.IsEnabled = holdDice5.IsEnabled = false;
            dices[0].HoldState = dices[1].HoldState = dices[2].HoldState = dices[3].HoldState = dices[4].HoldState = false;
            holdDice1.Content = holdDice2.Content = holdDice3.Content = holdDice4.Content = holdDice5.Content = "Hold";
            rollDiceBtn.IsEnabled = true;
            onesButton.IsEnabled = twosButton.IsEnabled = threesButton.IsEnabled = foursButton.IsEnabled = fivesButton.IsEnabled =
                sixesButton.IsEnabled = threeOfAKindButton.IsEnabled = fourOfAKindButton.IsEnabled = fullHouseButton.IsEnabled =
                smallStraightButton.IsEnabled = largeStraightButton.IsEnabled = chanceButton.IsEnabled = yahtzeeButton.IsEnabled = false;
        }
    }
}