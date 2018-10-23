using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TexasHoldem.Library.Classes;
using TexasHoldem.Library.Enums;
using TexasHoldem.Library.Structs;

namespace TexasHoldem.UI
{
    // TODO! If player1 name is empty, the display of cards is not ok.

    public partial class Form1 : Form
    {

        private List<Label> _playerCardLabels;
        private List<Label> _dealerCardLabels;

        private Table _table;

        private Point[] _playerLblPos;
        private Point[] _dealerLblPos;

        List<string> names = new List<string>();

        public Form1()
        {
            InitializeComponent();
            _playerCardLabels = new List<Label>();
            _dealerCardLabels = new List<Label>();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            try
            {
                #region Initialize the player and dealer card label positions
                _playerLblPos = new Point[]
                {
                    new Point(900,280), new Point(950,280),
                    new Point(720,510), new Point(770,510),
                    new Point(290,510), new Point(340,510),
                    new Point(80,280), new Point(130,280),
                };
                _dealerLblPos = new Point[]
                {
                new Point(390,287), new Point(450,287),
                new Point(510,287), new Point(570,287),
                new Point(630,287)
                };
                #endregion
				
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(String.Format($"ArgumentException: {ex.Message}"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format($"Exception: {ex.Message}"));
            }
        }

        private void btnNewTable_Click(object sender, EventArgs e)
        {
            try
            {
                #region Set Player names
                // Clear the _names
                names.Clear();
                if (!txtPlayerName1.Text.Equals(""))
                {
                    names.Add(txtPlayerName1.Text);
                    lblPlayerName1.Text = txtPlayerName1.Text;
                }
                else
                {
                    lblPlayerName1.Text = "";
                }


                if (!txtPlayerName2.Text.Equals(""))
                {
                    names.Add(txtPlayerName2.Text);
                    lblPlayerName2.Text = txtPlayerName2.Text;
                }
                else
                {
                    lblPlayerName2.Text = "";
                }


                if (!txtPlayerName3.Text.Equals(""))
                {
                    names.Add(txtPlayerName3.Text);
                    lblPlayerName3.Text = txtPlayerName3.Text;
                }
                else
                {
                    lblPlayerName3.Text = "";
                }


                if (!txtPlayerName4.Text.Equals(""))
                {
                    names.Add(txtPlayerName4.Text);
                    lblPlayerName4.Text = txtPlayerName4.Text;
                }
                else
                {
                    lblPlayerName4.Text = "";
                }
                #endregion

                btnDrawCard.Enabled = false;
                btnNewHand.Enabled = true;
				//lblWinner.Visible = true;
				lblWinner.Visible = false;

				ClearHandLabels();
                ClearDealerCardsFromTable();
                ClearPlayerCardsFromTable();

                _table = new Table(names.ToArray());
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error in application");
            }
            catch
            {

            }
        }

        private void ClearHandLabels()
        {
            lblHand1.Text = "";
            lblHand2.Text = "";
            lblHand3.Text = "";
            lblHand4.Text = "";
        }

        private Label CreateCardLabel(int x, int y, Card card)
        {
            Label lbl = new Label();
            lbl.Text = card.Output;
            lbl.Size = new Size(45, 60);
            lbl.Location = new Point(x, y);
            lbl.BorderStyle = BorderStyle.FixedSingle;
            lbl.Font = new Font("Consolas", 15);
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.BackColor = Color.White;
            if ((card.Suit == Suits.Hearts) || (card.Suit == Suits.Diamonds))
            {
                lbl.ForeColor = Color.Red;
            }
            else
            {
                lbl.ForeColor = Color.Black;
            }
            return lbl;
        }

        /// <summary>
        /// Removes the player cards from the table and the collection
        /// </summary>
        private void ClearPlayerCardsFromTable()
        {
            foreach (var label in _playerCardLabels)
            {
                this.Controls.Remove(label);
            }
            _playerCardLabels.Clear();
        }

        private void ClearDealerCardsFromTable()
        {
            foreach (var label in _dealerCardLabels)
            {
                this.Controls.Remove(label);
            }
            _dealerCardLabels.Clear();
        }

        private void btnNewHand_Click(object sender, EventArgs e)
        {
            if (_table == null)
            {
                return;
            }

            ClearHandLabels();
            ClearPlayerCardsFromTable();
            _table.DealNewHand();
            DisplayPlayerHands();
            ClearDealerCardsFromTable();
            _table.EvaluatePlayerHands();
            FillHandValueLabels();
            btnDrawCard.Enabled = true;
            lblWinner.Visible = false;
        }

        private void DisplayPlayerHands()
        {
            for (int ii = 0; ii < _table.Players.Count * 2; ii++)
            {
                var card = CreateCardLabel(
                    _playerLblPos[ii].X,
                    _playerLblPos[ii].Y,
                    _table.Players[ii / 2].PlayerCards[ii % 2]
                    );
                _playerCardLabels.Add(card);
            }
            this.Controls.AddRange(_playerCardLabels.ToArray());
        }

        private void btnDrawCard_Click(object sender, EventArgs e)
        {
            if (_table.Dealer.CardCount == 0)
            {
                _table.DealerDrawsCard(3);
            }
            else if (_table.Dealer.CardCount >= 3)
            {
                _table.DealerDrawsCard();
            }
            DisplayDealerCards();
            _table.EvaluatePlayerHands();
            FillHandValueLabels();
            if (_table.Dealer.Cards.Count == 5)
            {
                btnDrawCard.Enabled = false;
				DisplayWinners();
            }
        }

        private void DisplayDealerCards()
        {
            ClearDealerCardsFromTable();

            //foreach (var card in _table.Dealer.Cards)
            for (int ii = 0; ii < _table.Dealer.Cards.Count; ii++)
            {
                var card = CreateCardLabel(
                    _dealerLblPos[ii].X,
                    _dealerLblPos[ii].Y,
                    _table.Dealer.Cards[ii]);

                _dealerCardLabels.Add(card);
            }
            this.Controls.AddRange(_dealerCardLabels.ToArray());
        }

        private void FillHandValueLabels()
        {
            lblHand1.Text = _table.Players[0].HandValue.ToString();
            lblHand2.Text = _table.Players[1].HandValue.ToString();
            if (_table.Players.Count >= 3)
            {
                lblHand3.Text = _table.Players[2].HandValue.ToString();
            }
            if (_table.Players.Count == 4)
            {
                lblHand4.Text = _table.Players[3].HandValue.ToString();
            }
        }

		private void DisplayWinners()
		{
			List<Player> winners = _table.DetermineWinner();
			String winnerLabel = "";
			winners.ForEach(w =>
			{
				winnerLabel += w.Name + " ";
			});
			winnerLabel += " Wins!";
			lblWinner.Visible = true;
			lblWinner.Text = winnerLabel;
		}
    }
}
