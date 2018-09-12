using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TexasHoldem.Library.Classes;
using TexasHoldem.Library.Enums;
using TexasHoldem.Library.Structs;

namespace TexasHoldem.UI
{
    public partial class Form1 : Form
    {

        private List<Label> _playerCardLabels;
        private List<Label> _dealerCardLabels;

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

            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format($"Something happened: {ex.Message}"));
            }
        }

        private void btnNewTable_Click(object sender, EventArgs e)
        {
            try
            {
                #region Set Player names
                if (!txtPlayerName1.Text.Equals(""))
                {
                    names.Add(txtPlayerName1.Text);
                    lblPlayerName1.Text = txtPlayerName1.Text;
                }


                if (!txtPlayerName2.Text.Equals(""))
                {
                    names.Add(txtPlayerName2.Text);
                    lblPlayerName2.Text = txtPlayerName2.Text;
                }


                if (!txtPlayerName3.Text.Equals(""))
                {
                    names.Add(txtPlayerName3.Text);
                    lblPlayerName3.Text = txtPlayerName3.Text;
                }


                if (!txtPlayerName4.Text.Equals(""))
                {
                    names.Add(txtPlayerName4.Text);
                    lblPlayerName4.Text = txtPlayerName4.Text;
                }
                #endregion

                ClearLabelHands();
                ClearDealerCardsFromTable();
                ClearPlayerCardsFromTable();
                btnDrawCard.Enabled = false;
                btnNewHand.Enabled = true;
                lblWinner.Visible = false;

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch
            {

            }
        }

        private void ClearLabelHands()
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
            foreach(var label in _playerCardLabels)
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
    }
}
