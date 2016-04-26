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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Yahtzee
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            holdDice1.IsEnabled = holdDice2.IsEnabled = holdDice3.IsEnabled =
            holdDice4.IsEnabled = holdDice5.IsEnabled = holdDice6.IsEnabled = rollDiceBtn.IsEnabled = false;

        }

        // Global Variable
        Dice[] dices = new Dice[maximumDice];

        // Symbolic Constant
        const int maximumDice = 6; /* Maximum number of dices                                */

        #region Controls' Event Handler
        // Start the game
        private void startGame_Click(object sender, RoutedEventArgs e)
        {
            initialDice();
            rollDiceBtn.IsEnabled = true;
            startGameBtn.IsEnabled = false;
            startGameBtn.Opacity = 0;
        }

        // Roll the dice
        private void rollDiceBtn_Click(object sender, RoutedEventArgs e)
        {
            Random number = new Random();
            int index;

            /* Enable (Un)Hold button of each dice                                           */
            holdDice1.IsEnabled = holdDice2.IsEnabled = holdDice3.IsEnabled =
            holdDice4.IsEnabled = holdDice5.IsEnabled = holdDice6.IsEnabled = true;

            for (index = 0; index < maximumDice; index++)
            {
                if (dices[index].HoldState == false)
                    dices[index].DiceNumber = number.Next(1, 7);
            }

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

            switch (dices[5].DiceNumber)
            {
                case 1:
                    dice6_1.Opacity = 1;
                    dice6_2.Opacity = 0;
                    dice6_3.Opacity = 0;
                    dice6_4.Opacity = 0;
                    dice6_5.Opacity = 0;
                    dice6_6.Opacity = 0;
                    break;
                case 2:
                    dice6_1.Opacity = 0;
                    dice6_2.Opacity = 1;
                    dice6_3.Opacity = 0;
                    dice6_4.Opacity = 0;
                    dice6_5.Opacity = 0;
                    dice6_6.Opacity = 0;
                    break;
                case 3:
                    dice6_1.Opacity = 0;
                    dice6_2.Opacity = 0;
                    dice6_3.Opacity = 1;
                    dice6_4.Opacity = 0;
                    dice6_5.Opacity = 0;
                    dice6_6.Opacity = 0;
                    break;
                case 4:
                    dice6_1.Opacity = 0;
                    dice6_2.Opacity = 0;
                    dice6_3.Opacity = 0;
                    dice6_4.Opacity = 1;
                    dice6_5.Opacity = 0;
                    dice6_6.Opacity = 0;
                    break;
                case 5:
                    dice6_1.Opacity = 0;
                    dice6_2.Opacity = 0;
                    dice6_3.Opacity = 0;
                    dice6_4.Opacity = 0;
                    dice6_5.Opacity = 1;
                    dice6_6.Opacity = 0;
                    break;
                case 6:
                    dice6_1.Opacity = 0;
                    dice6_2.Opacity = 0;
                    dice6_3.Opacity = 0;
                    dice6_4.Opacity = 0;
                    dice6_5.Opacity = 0;
                    dice6_6.Opacity = 1;
                    break;
            }
        }
        #endregion

        // Hold the dice buttons
        private void holdDice1Btn(object sender, RoutedEventArgs e)
        {
            if (dices[0].HoldState == false)
            {
                dices[0].HoldState = true;
                dices[0].holdValue(dices[0].DiceNumber);
                markDice1.Opacity  = 1;
                holdDice1.Content  = "Unhold";
            }
            else
            {
                dices[0].HoldState = false;
                markDice1.Opacity  = 0;
                holdDice1.Content  = "Hold";
            }
        }
        private void holdDice2Btn(object sender, RoutedEventArgs e)
        {
            if (dices[1].HoldState == false)
            {
                dices[1].HoldState = true;
                dices[1].holdValue(dices[1].DiceNumber);
                markDice2.Opacity  = 1;
                holdDice2.Content  = "Unhold";
            }
            else
            {
                dices[1].HoldState = false;
                markDice2.Opacity  = 0;
                holdDice2.Content  = "Hold";
            }
        }
        private void holdDice3Btn(object sender, RoutedEventArgs e)
        {
            if (dices[2].HoldState == false)
            {
                dices[2].HoldState = true;
                dices[2].holdValue(dices[2].DiceNumber);
                markDice3.Opacity  = 1;
                holdDice3.Content  = "Unhold";
            }
            else
            {
                dices[2].HoldState = false;
                markDice3.Opacity  = 0;
                holdDice3.Content  = "Hold";
            }
        }
        private void holdDice4Btn(object sender, RoutedEventArgs e)
        {
            if (dices[3].HoldState == false)
            {
                dices[3].HoldState = true;
                dices[3].holdValue(dices[3].DiceNumber);
                markDice4.Opacity  = 1;
                holdDice4.Content  = "Unhold";
            }
            else
            {
                dices[3].HoldState = false;
                markDice4.Opacity  = 0;
                holdDice4.Content  = "Hold";
            }
        }
        private void holdDice5Btn(object sender, RoutedEventArgs e)
        {
            if (dices[4].HoldState == false)
            {
                dices[4].HoldState = true;
                dices[4].holdValue(dices[4].DiceNumber);
                markDice5.Opacity  = 1;
                holdDice5.Content  = "Hold";
            }
            else
            {
                dices[4].HoldState = false;
                markDice5.Opacity  = 0;
                holdDice5.Content  = "Unhold";
            }
        }
        private void holdDice6Btn(object sender, RoutedEventArgs e)
        {
            if (dices[5].HoldState == false)
            {
                dices[5].HoldState = true;
                dices[5].holdValue(dices[5].DiceNumber);
                markDice6.Opacity  = 1;
                holdDice6.Content  = "Unhold";
            }
            else
            {
                dices[5].HoldState = false;
                markDice6.Opacity  = 0;
                holdDice6.Content  = "Hold";
            }
        }

        // Program Functions
        public void initialDice()
        {
            int diceIndex;                       /* Index of every dice in the list          */

            for (diceIndex = 0; diceIndex < maximumDice; diceIndex++)
                dices[diceIndex] = new Dice();
        }
    }
}