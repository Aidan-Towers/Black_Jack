using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJack
{
    public partial class Form1 : Form
    {
        int bet, money = 50, drawNumber, playerValue, dealerValue, dealerHiddenValue, deckCount, playerAceCount, dealerAceCount, dealerHiddenValueCheck, count = 5;
        string cardDrawn, dealerHidden, dealerHiddenCard, value, currentCard;
        List<string> deck = new List<string> {"AS", "AH", "AD", "AC", "2S", "2H", "2D", "2C", "3S", "3H", "3D", "3C", "4S", "4H", "4D", "4C", "5S", "5H", "5D", "5C", "6S", "6H", "6D", "6C", "7S", "7H", "7D", "7C", "8S", "8H", "8D", "8C", "9S", "9H", "9D", "9C", "10S", "10H", "10D", "10C", "JS", "JH", "JD", "JC", "QS", "QH", "QD", "QC", "KS", "KH", "KD", "KC" };
        List<string> played = new List<string>();
        
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        

        //Adds one to the bet
        private void onePlus_Click(object sender, EventArgs e)
        {
            bet = bet + 1;
            //checks if your bet count is more than you have and if it goes over sets it to your max bet
            if (bet > money)
            {
                bet = money;
                betDisplay.Text = "Bet: " + Convert.ToString(bet);
            }
            //runs if your bet won't go over how much money you have and adds the appropiate amount
            else
            {
                betDisplay.Text = "Bet: " + Convert.ToString(bet);
            }
            //makes it so you can place a bet now that your bet is more than 0
            placeBet.Enabled = true;
        }

        //Adds ten to the bet
        private void tenPlus_Click(object sender, EventArgs e)
        {
            bet = bet + 10;
            if (bet > money)
            {
                bet = money;
                betDisplay.Text = "Bet: " + Convert.ToString(bet);
            }
            else
            {
                betDisplay.Text = "Bet: " + Convert.ToString(bet);
            }
            placeBet.Enabled = true;
        }

        //Adds a hundred to the bet
        private void hundredPlus_Click(object sender, EventArgs e)
        {
            bet = bet + 100;
            if (bet > money)
            {
                bet = money;
                betDisplay.Text = "Bet: " + Convert.ToString(bet);
            }
            else
            {
                betDisplay.Text = "Bet: " + Convert.ToString(bet);
            }
            placeBet.Enabled = true;
        }

        //Adds a thousand to the bet
        private void thousandPlus_Click(object sender, EventArgs e)
        {
            bet = bet + 1000;
            if (bet > money)
            {
                bet = money;
                betDisplay.Text = "Bet: " + Convert.ToString(bet);
            }
            else
            {
                betDisplay.Text = "Bet: " + Convert.ToString(bet);
            }
            placeBet.Enabled = true;
        }

        //Maxs out your bet
        private void maxPlus_Click(object sender, EventArgs e)
        {
            bet = money;
            betDisplay.Text = "Bet: " + Convert.ToString(bet);
            placeBet.Enabled = true;
        }

        //Removes one from the bet
        private void oneMinus_Click(object sender, EventArgs e)
        {
            bet = bet - 1;
            //Checks if your bet will go under or equal zero and makes it always zero and disables you from betting
            if (bet < 1)
            {
                bet = 0;
                betDisplay.Text = "Bet: " + Convert.ToString(bet);
                placeBet.Enabled = false;
            }
            //If you bet doesn't go below or equal to zero shows what it will be instead
            else
            {
                betDisplay.Text = "Bet: " + Convert.ToString(bet);
            }
        }

        //Removes ten from the bet
        private void tenMinus_Click(object sender, EventArgs e)
        {
            bet = bet - 10;
            if (bet < 1)
            {
                bet = 0;
                betDisplay.Text = "Bet: " + Convert.ToString(bet);
                placeBet.Enabled = false;
            }
            else
            {
                betDisplay.Text = "Bet: " + Convert.ToString(bet);
            }
        }

        //Removes a hundred from the bet
        private void hundredMinus_Click(object sender, EventArgs e)
        {
            bet = bet - 100;
            if (bet < 1)
            {
                bet = 0;
                betDisplay.Text = "Bet: " + Convert.ToString(bet);
                placeBet.Enabled = false;
            }
            else
            {
                betDisplay.Text = "Bet: " + Convert.ToString(bet);
            }
        }

        //Removes a thousand from the bet
        private void thousandMinus_Click(object sender, EventArgs e)
        {
            bet = bet - 1000;
            if (bet < 1)
            {
                bet = 0;
                betDisplay.Text = "Bet: " + Convert.ToString(bet);
                placeBet.Enabled = false;
            }
            else
            {
                betDisplay.Text = "Bet: " + Convert.ToString(bet);
            }
        }

        //Resets you bet counter to 0
        private void maxMinus_Click(object sender, EventArgs e)
        {
            bet = 0;
            betDisplay.Text = "Bet: " + Convert.ToString(bet);
            placeBet.Enabled = false;
        }

        private void placeBet_Click(object sender, EventArgs e)
        {

            //Disables the changing of the Bet
            onePlus.Enabled = false;
            tenPlus.Enabled = false;
            hundredPlus.Enabled = false;
            thousandPlus.Enabled = false;
            maxPlus.Enabled = false;
            oneMinus.Enabled = false;
            tenMinus.Enabled = false;
            hundredMinus.Enabled = false;
            thousandMinus.Enabled = false;
            maxMinus.Enabled = false;

            //Hides old cards if you played before
            cardFive.Visible = false;
            cardSix.Visible = false;
            cardSeven.Visible = false;
            cardEight.Visible = false;
            cardNine.Visible = false;
            cardTen.Visible = false;
            cardEleven.Visible = false;
            cardTwelve.Visible = false;

            //Hides old statement
            resultDisplay.Visible = false;

            //Generates card one

            //Counts how many cards are in the deck so the randomizer doesn't generate a number out of the lists range
            deckCount = deck.Count;
            //Rolls a random number to pull a item out of the list to represent a card
            drawNumber = rnd.Next(0, deckCount);
            //Sets a string to equal what card is drawn
            cardDrawn = deck[drawNumber];
            //Sets the image of the apropiate card and it's apropiate image
            cardOne.Image = new Bitmap("C:\\Users\\aidan\\source\\repos\\BlackJack\\BlackJack\\Resources\\" + cardDrawn + ".png");
            //Makes the card visable now that it has the right image
            cardOne.Visible = true;
            //Puts the card that was played into a new list for later use
            played.Add(cardDrawn);
            //Removes the card from the deck so it can't be played again
            deck.Remove(cardDrawn);
            //Figures out what the card is worth and adds it to the players value
            value = cardDrawn.Substring(0, 1);
            if (value == "A")
            {
                playerValue = playerValue + 11;
                //Uses this to determine later if the player should bust if they drew an ace
                playerAceCount = playerAceCount + 1;
            }
            else if (value == "K")
            {
                playerValue = playerValue + 10;
            }
            else if (value == "Q")
            {
                playerValue = playerValue + 10;
            }
            else if (value == "J")
            {
                playerValue = playerValue + 10;
            }
            else if (value == "1")
            {
                playerValue = playerValue + 10;
            }
            else
            {
                playerValue = playerValue + Convert.ToInt32(value);
            }

            //Runs everything again for the players second card
            deckCount = deck.Count;
            drawNumber = rnd.Next(0, deckCount);
            cardDrawn = deck[drawNumber];
            cardTwo.Image = new Bitmap("C:\\Users\\aidan\\source\\repos\\BlackJack\\BlackJack\\Resources\\" + cardDrawn + ".png");
            played.Add(cardDrawn);
            cardTwo.Visible = true;
            deck.Remove(cardDrawn);
            value = cardDrawn.Substring(0, 1);
            if (value == "A")
            {
                playerValue = playerValue + 11;
                playerAceCount = playerAceCount + 1;
            }
            else if (value == "K")
            {
                playerValue = playerValue + 10;
            }
            else if (value == "Q")
            {
                playerValue = playerValue + 10;
            }
            else if (value == "J")
            {
                playerValue = playerValue + 10;
            }
            else if (value == "1")
            {
                playerValue = playerValue + 10;
            }
            else
            {
                playerValue = playerValue + Convert.ToInt32(value);
            }
            //Displays the players combined value of cards
            playerValueDisplay.Text = "Player Value: " + playerValue;
            playerValueDisplay.Visible = true;


            //Runs everything again for the dealers first card
            deckCount = deck.Count;
            drawNumber = rnd.Next(0, deckCount);
            cardDrawn = deck[drawNumber];
            cardThree.Image = new Bitmap("C:\\Users\\aidan\\source\\repos\\BlackJack\\BlackJack\\Resources\\" + cardDrawn + ".png");
            played.Add(cardDrawn);
            cardThree.Visible = true;
            deck.Remove(cardDrawn);
            value = cardDrawn.Substring(0, 1);
            if (value == "A")
            {
                dealerValue = dealerValue + 11;
                dealerAceCount = dealerAceCount + 1;
            }
            else if (value == "K")
            {
                dealerValue = dealerValue + 10;
            }
            else if (value == "Q")
            {
                dealerValue = dealerValue + 10;
            }
            else if (value == "J")
            {
                dealerValue = dealerValue + 10;
            }
            else if (value == "1")
            {
                dealerValue = dealerValue + 10;
            }
            else
            {
                dealerValue = dealerValue + Convert.ToInt32(value);
            }


            //Runs everything again for the dealers second card and keeps it hidden
            deckCount = deck.Count;
            drawNumber = rnd.Next(0, deckCount);
            cardDrawn = deck[drawNumber];
            played.Add(cardDrawn);
            dealerHiddenCard = cardDrawn;
            cardFour.Image = new Bitmap("C:\\Users\\aidan\\source\\repos\\BlackJack\\BlackJack\\Resources\\cardBack.png");
            cardFour.Visible = true;
            deck.Remove(cardDrawn);
            dealerHidden = cardDrawn.Substring(0, 1);
            if (dealerHidden == "A")
            {
                dealerHiddenValue = 11;
                dealerAceCount = dealerAceCount + 1;
            }
            else if (dealerHidden == "K")
            {
                dealerHiddenValue = 10;
            }
            else if (dealerHidden == "Q")
            {
                dealerHiddenValue = 10;
            }
            else if (dealerHidden == "J")
            {
                dealerHiddenValue = 10;
            }
            else if (value == "1")
            {
                dealerHiddenValue = 10;
            }
            else
            {
                dealerHiddenValue = Convert.ToInt32(dealerHidden);
            }
            //Displays the delaers value of the cards shown
            dealerValueDisplay.Text = "Dealer Value: " + dealerValue;
            dealerValueDisplay.Visible = true;
            dealerHiddenValueCheck = dealerValue + dealerHiddenValue;

            //Takes your money out for the current round and updates the text
            money = money - bet;
            moneyDisplay.Text = Convert.ToString("Money: " + money);

            //checks if it's a tie
            if (playerValue == 21 & dealerHiddenValueCheck == 21)
            {
                //tells you the result and deals with you money apropiately
                resultDisplay.Text = "It's a Tie";
                resultDisplay.Visible = true;
                money = money + bet;

                //Displays all the dealers hidden stuff
                cardFour.Image = new Bitmap("C:\\Users\\aidan\\source\\repos\\BlackJack\\BlackJack\\Resources\\" + dealerHiddenCard + ".png");
                dealerValueDisplay.Text = "Dealer Value: " + Convert.ToString(dealerHiddenValueCheck);

                //Resets functions so you can play again
                deck.AddRange(played);
                played.Clear();
                bet = 0;
                betDisplay.Text = "Bet: 0";
                moneyDisplay.Text = "Money: " + Convert.ToString(money);
                playerValue = 0;
                playerAceCount = 0;
                dealerValue = 0;
                dealerHiddenValue = 0;
                dealerHiddenValueCheck = 0;
                dealerAceCount = 0;
                onePlus.Enabled = true;
                tenPlus.Enabled = true;
                hundredPlus.Enabled = true;
                thousandPlus.Enabled = true;
                maxPlus.Enabled = true;
                oneMinus.Enabled = true;
                tenMinus.Enabled = true;
                hundredMinus.Enabled = true;
                thousandMinus.Enabled = true;
                maxMinus.Enabled = true;
            }
            else if (playerValue == 21)
            {
                resultDisplay.Text = "You Win!";
                resultDisplay.Visible = true;
                money = money + bet + bet;

                cardFour.Image = new Bitmap("C:\\Users\\aidan\\source\\repos\\BlackJack\\BlackJack\\Resources\\" + dealerHiddenCard + ".png");
                dealerValueDisplay.Text = "Dealer Value: " + Convert.ToString(dealerHiddenValueCheck);

                deck.AddRange(played);
                played.Clear();
                bet = 0;
                betDisplay.Text = "Bet: 0";
                moneyDisplay.Text = "Money: " + Convert.ToString(money);
                playerValue = 0;
                playerAceCount = 0;
                dealerValue = 0;
                dealerHiddenValue = 0;
                dealerHiddenValueCheck = 0;
                dealerAceCount = 0;
                onePlus.Enabled = true;
                tenPlus.Enabled = true;
                hundredPlus.Enabled = true;
                thousandPlus.Enabled = true;
                maxPlus.Enabled = true;
                oneMinus.Enabled = true;
                tenMinus.Enabled = true;
                hundredMinus.Enabled = true;
                thousandMinus.Enabled = true;
                maxMinus.Enabled = true;
            }
            else if (dealerHiddenValueCheck == 21)
            {
                resultDisplay.Text = "You Lost";
                resultDisplay.Visible = true;

                cardFour.Image = new Bitmap("C:\\Users\\aidan\\source\\repos\\BlackJack\\BlackJack\\Resources\\" + dealerHiddenCard + ".png");
                dealerValueDisplay.Text = "Dealer Value: " + Convert.ToString(dealerHiddenValueCheck);

                deck.AddRange(played);
                played.Clear();
                bet = 0;
                betDisplay.Text = "Bet: 0";
                moneyDisplay.Text = "Money: " + Convert.ToString(money);
                playerValue = 0;
                playerAceCount = 0;
                dealerValue = 0;
                dealerHiddenValue = 0;
                dealerHiddenValueCheck = 0;
                dealerAceCount = 0;
                onePlus.Enabled = true;
                tenPlus.Enabled = true;
                hundredPlus.Enabled = true;
                thousandPlus.Enabled = true;
                maxPlus.Enabled = true;
                oneMinus.Enabled = true;
                tenMinus.Enabled = true;
                hundredMinus.Enabled = true;
                thousandMinus.Enabled = true;
                maxMinus.Enabled = true;
            }
            else
            {
                //Stops you from being able to place another bet while the current round is going
                placeBet.Enabled = false;
                //Enables the other buttons for you to keep playing this round
                hit.Enabled = true;
                stand.Enabled = true;
            }
        }
        private void hit_Click(object sender, EventArgs e)
        {
             
            deckCount = deck.Count;
            drawNumber = rnd.Next(0, deckCount);
            cardDrawn = deck[drawNumber];
            if (count == 5)
            {
                cardFive.Image = new Bitmap("C:\\Users\\aidan\\source\\repos\\BlackJack\\BlackJack\\Resources\\" + cardDrawn + ".png");
                cardFive.Visible = true;
                count = count + 1;
            }
            else if (count == 6)
            {
                cardSix.Image = new Bitmap("C:\\Users\\aidan\\source\\repos\\BlackJack\\BlackJack\\Resources\\" + cardDrawn + ".png");
                cardSix.Visible = true;
                count = count + 1;
            }
            else if (count == 7)
            {
                cardSeven.Image = new Bitmap("C:\\Users\\aidan\\source\\repos\\BlackJack\\BlackJack\\Resources\\" + cardDrawn + ".png");
                cardSeven.Visible = true;
                count = count + 1;
            }
            else
            {
                cardEight.Image = new Bitmap("C:\\Users\\aidan\\source\\repos\\BlackJack\\BlackJack\\Resources\\" + cardDrawn + ".png");
                cardEight.Visible = true;
                count = count + 1;
            }
            played.Add(cardDrawn);
            deck.Remove(cardDrawn);
            value = cardDrawn.Substring(0, 1);
            if (value == "A")
            {
                playerValue = playerValue + 11;
                playerAceCount = playerAceCount + 1;
            }
            else if (value == "K")
            {
                playerValue = playerValue + 10;
            }
            else if (value == "Q")
            {
                playerValue = playerValue + 10;
            }
            else if (value == "J")
            {
                playerValue = playerValue + 10;
            }
            else if (value == "1")
            {
                playerValue = playerValue + 10;
            }
            else
            {
                playerValue = playerValue + Convert.ToInt32(value);
              
            }
            playerValueDisplay.Text = "Player Value: " + playerValue;

            if (playerValue > 21 & playerAceCount > 0)
            {
                playerValue = playerValue - 10;
                playerAceCount = playerAceCount - 1;
                playerValueDisplay.Text = "Player Value: " + Convert.ToString(playerValue);
            }
            else if (playerValue == 21)
            {
                hit.Enabled = false;
                
            }
            else if (playerValue > 21)
            {
                resultDisplay.Text = "You Lost";
                resultDisplay.Visible = true;

                cardFour.Image = new Bitmap("C:\\Users\\aidan\\source\\repos\\BlackJack\\BlackJack\\Resources\\" + dealerHiddenCard + ".png");
                dealerValueDisplay.Text = "Dealer Value: " + Convert.ToString(dealerHiddenValueCheck);

                deck.AddRange(played);
                played.Clear();
                bet = 0;
                count = 5;
                betDisplay.Text = "Bet: 0";
                moneyDisplay.Text = "Money: " + Convert.ToString(money);
                playerValue = 0;
                playerAceCount = 0;
                dealerValue = 0;
                dealerHiddenValue = 0;
                dealerHiddenValueCheck = 0;
                dealerAceCount = 0;
                hit.Enabled = false;
                stand.Enabled = false;
                onePlus.Enabled = true;
                tenPlus.Enabled = true;
                hundredPlus.Enabled = true;
                thousandPlus.Enabled = true;
                maxPlus.Enabled = true;
                oneMinus.Enabled = true;
                tenMinus.Enabled = true;
                hundredMinus.Enabled = true;
                thousandMinus.Enabled = true;
                maxMinus.Enabled = true;
            }
        }
        private void stand_Click(object sender, EventArgs e)
        {
            hit.Enabled = false;
            stand.Enabled = false;
            dealerValue = dealerValue + dealerHiddenValue;
            dealerValueDisplay.Text = "Dealer Value: " + Convert.ToString(dealerValue);
            cardFour.Image = new Bitmap("C:\\Users\\aidan\\source\\repos\\BlackJack\\BlackJack\\Resources\\" + dealerHiddenCard + ".png");
            count = 9;
            while (dealerValue <= playerValue)
            {


                deckCount = deck.Count;
                drawNumber = rnd.Next(0, deckCount);
                cardDrawn = deck[drawNumber];
                if (count == 9)
                {
                    cardNine.Image = new Bitmap("C:\\Users\\aidan\\source\\repos\\BlackJack\\BlackJack\\Resources\\" + cardDrawn + ".png");
                    cardNine.Visible = true;
                    count = count + 1;
                }
                else if (count == 10)
                {
                    cardTen.Image = new Bitmap("C:\\Users\\aidan\\source\\repos\\BlackJack\\BlackJack\\Resources\\" + cardDrawn + ".png");
                    cardTen.Visible = true;
                    count = count + 1;
                }
                else if (count == 11)
                {
                    cardEleven.Image = new Bitmap("C:\\Users\\aidan\\source\\repos\\BlackJack\\BlackJack\\Resources\\" + cardDrawn + ".png");
                    cardEleven.Visible = true;
                    count = count + 1;
                }
                else
                {
                    cardTwelve.Image = new Bitmap("C:\\Users\\aidan\\source\\repos\\BlackJack\\BlackJack\\Resources\\" + cardDrawn + ".png");
                    cardTwelve.Visible = true;
                    count = count + 1;
                }
                played.Add(cardDrawn);
                deck.Remove(cardDrawn);
                value = cardDrawn.Substring(0, 1);
                if (value == "A")
                {
                    dealerValue = dealerValue + 11;
                    dealerAceCount = dealerAceCount + 1;
                }
                else if (value == "K")
                {
                    dealerValue = dealerValue + 10;
                }
                else if (value == "Q")
                {
                    dealerValue = dealerValue + 10;
                }
                else if (value == "J")
                {
                    dealerValue = dealerValue + 10;
                }
                else if (value == "1")
                {
                    dealerValue = dealerValue + 10;
                }
                else
                {
                    dealerValue = dealerValue + Convert.ToInt32(value);

                }
                dealerValueDisplay.Text = "Dealer Value: " + dealerValue;


                if (dealerValue > 21 & dealerAceCount > 0)
                {
                    dealerValue = dealerValue - 10;
                    dealerAceCount = dealerAceCount - 1;
                    dealerValueDisplay.Text = "Dealer Value: " + Convert.ToString(dealerValue);
                }
                else if (dealerValue > 21)
                {
                    resultDisplay.Text = "You Win!";
                    resultDisplay.Visible = true;
                    money = money + bet + bet;
                    dealerValueDisplay.Text = "Dealer Value: " + Convert.ToString(dealerValue);

                    playerValue = 0;
                }
                else if (dealerValue > playerValue)
                {
                    resultDisplay.Text = "You Lost";
                    resultDisplay.Visible = true;

                    dealerValueDisplay.Text = "Dealer Value: " + Convert.ToString(dealerValue);

                    playerValue = 0;
                }
            }
            if (playerValue == 0)
            {
                deck.AddRange(played);
                played.Clear();
                bet = 0;
                count = 5;
                betDisplay.Text = "Bet: 0";
                moneyDisplay.Text = "Money: " + Convert.ToString(money);
                playerValue = 0;
                playerAceCount = 0;
                dealerValue = 0;
                dealerHiddenValue = 0;
                dealerHiddenValueCheck = 0;
                dealerAceCount = 0;
                hit.Enabled = false;
                stand.Enabled = false;
                onePlus.Enabled = true;
                tenPlus.Enabled = true;
                hundredPlus.Enabled = true;
                thousandPlus.Enabled = true;
                maxPlus.Enabled = true;
                oneMinus.Enabled = true;
                tenMinus.Enabled = true;
                hundredMinus.Enabled = true;
                thousandMinus.Enabled = true;
                maxMinus.Enabled = true;
            }
            else if (dealerValue == playerValue)
            {
          
                resultDisplay.Text = "It's a Tie";
                resultDisplay.Visible = true;
                money = money + bet;

                dealerValueDisplay.Text = "Dealer Value: " + Convert.ToString(dealerValue);

                deck.AddRange(played);
                played.Clear();
                bet = 0;
                count = 5;
                betDisplay.Text = "Bet: 0";
                moneyDisplay.Text = "Money: " + Convert.ToString(money);
                playerValue = 0;
                playerAceCount = 0;
                dealerValue = 0;
                dealerHiddenValue = 0;
                dealerHiddenValueCheck = 0;
                dealerAceCount = 0;
                hit.Enabled = false;
                stand.Enabled = false;
                onePlus.Enabled = true;
                tenPlus.Enabled = true;
                hundredPlus.Enabled = true;
                thousandPlus.Enabled = true;
                maxPlus.Enabled = true;
                oneMinus.Enabled = true;
                tenMinus.Enabled = true;
                hundredMinus.Enabled = true;
                thousandMinus.Enabled = true;
                maxMinus.Enabled = true;
            }
            else if (dealerValue > playerValue)
            {
                resultDisplay.Text = "You Lost";
                resultDisplay.Visible = true;

                dealerValueDisplay.Text = "Dealer Value: " + Convert.ToString(dealerValue);

                deck.AddRange(played);
                played.Clear();
                bet = 0;
                count = 5;
                betDisplay.Text = "Bet: 0";
                moneyDisplay.Text = "Money: " + Convert.ToString(money);
                playerValue = 0;
                playerAceCount = 0;
                dealerValue = 0;
                dealerHiddenValue = 0;
                dealerHiddenValueCheck = 0;
                dealerAceCount = 0;
                hit.Enabled = false;
                stand.Enabled = false;
                onePlus.Enabled = true;
                tenPlus.Enabled = true;
                hundredPlus.Enabled = true;
                thousandPlus.Enabled = true;
                maxPlus.Enabled = true;
                oneMinus.Enabled = true;
                tenMinus.Enabled = true;
                hundredMinus.Enabled = true;
                thousandMinus.Enabled = true;
                maxMinus.Enabled = true;
            }
        }
    }
}

