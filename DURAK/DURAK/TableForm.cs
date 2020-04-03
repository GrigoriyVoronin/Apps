using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DURAK
{
    partial class TableForm : Form
    {
        private Player Player1 { get; set; }
        private Player Player2 { get; set; }
        private Coloda Coloda { get; set; }
        private Table Table { get; set; }
        public TableForm()
        {
            InitializeComponent();
            Coloda = new Coloda();
            trumpCard.Text = "Козырь: " + Coloda.Kozir.ToString();
            Player1 = new Player
            {
                Name = "Player1"
            };
            Player1.PopRuku(Coloda);
            AddCardsToPanel(Player1.Ruka, Player1Cards);
            Player2 = new Player
            {
                Name = "Player2"
            };
            Player2.PopRuku(Coloda);
            AddCardsToPanel(Player2.Ruka, Player2Cards);
            Table = new Table();
            CountOfCards.Text = "Карт в колоде: " + Coloda.ColodaCard.Count;
            IdentifyFirst();

        }

        void IdentifyFirst()
        {
            var kozirsCardsPlayer1 = new List<int>();
            var kozirsCardsPlayer2 = new List<int>();
            for (int i = 0; i < 6; i++)
            {
                if (Player1.Ruka[i].Mast == Coloda.Kozir)
                    kozirsCardsPlayer1.Add((int)Player1.Ruka[i].Rank);
                if (Player2.Ruka[i].Mast == Coloda.Kozir)
                    kozirsCardsPlayer2.Add((int)Player2.Ruka[i].Rank);
            }
            if (kozirsCardsPlayer1.Count > 0)
            {
                if (kozirsCardsPlayer2.Count > 0)
                {
                    var min1 = kozirsCardsPlayer1.Min();
                    var min2 = kozirsCardsPlayer2.Min();
                    if (min1 < min2)
                    {
                        SwapPlayer(Player1, Player2, true);
                        return;
                    }
                    else
                    {
                        SwapPlayer(Player2, Player1, true);
                        return;
                    }
                }
            }
            else if (kozirsCardsPlayer2.Count > 0)
            {
                SwapPlayer(Player2, Player1, true);
                return;
            }
            SwapPlayer(Player1, Player2, true);
        }

        void SwapPlayer(Player movePlayer, Player waitPlayer, bool isAtacker)
        {
            PlayerMove.Text = (isAtacker ? "Атакует: " : "Защищается: ") + movePlayer.Name;
            if (isAtacker)
            {
                movePlayer.Atacker = true;
                movePlayer.Deffender = false;
                waitPlayer.Deffender = false;
                waitPlayer.Atacker = false;
            }
            else
            {
                movePlayer.Deffender = true;
                waitPlayer.Atacker = false;
                movePlayer.Atacker = false;
                waitPlayer.Deffender = false;
            }
        }

        void AddCardsToPanel(List<Card> cards, Panel panel)
        {
            for (int i = 0; i < cards.Count; i++)
                panel.Controls.Add(Card(cards[i], i, panel));
        }

        void DrawCardsAtPanel(Panel panel)
        {
            foreach (Button contr in panel.Controls)
                contr.Visible = true;
        }

        void AccessChangesForButtons(bool isTurnNow, bool isAtack, bool isCardAdd = false)
        {
            if (isCardAdd)
            {
                endOfTurn.Enabled = true;
                return;
            }

            if (isTurnNow)
            {
                StartOfTurn.Enabled = false;
                endOfTurn.Enabled = false;
                if (isAtack)
                {
                    BitaButton.Enabled = true;
                    TakeButton.Enabled = false;
                }
                else
                {
                    BitaButton.Enabled = false;
                    TakeButton.Enabled = true;
                }
            }
            else
            {
                StartOfTurn.Enabled = true;
                endOfTurn.Enabled = false;
                TakeButton.Enabled = false;
                BitaButton.Enabled = false;
            }
        }

        void StartOfTurn_Click(object sender, EventArgs e)
        {
            if (Player1.Atacker)
            {
                DrawCardsAtPanel(Player1Cards);
                AccessChangesForButtons(true, true);
            }
            else if (Player2.Atacker)
            {
                DrawCardsAtPanel(Player2Cards);
                AccessChangesForButtons(true, true);
            }
            else if (Player2.Deffender)
            {
                DrawCardsAtPanel(Player2Cards);
                AccessChangesForButtons(true, false);
            }
            else if (Player1.Deffender)
            {
                DrawCardsAtPanel(Player1Cards);
                AccessChangesForButtons(true, false);
            }
        }

        void HideCardsOnPanel(Panel panel)
        {
            foreach (Button contr in panel.Controls)
                contr.Visible = false;
        }

        void EndOfTurn_Click(object sender, EventArgs e)
        {
            EndOfTurnUsual();
        }

        void EndOfTurnUsual()
        {
            if (Player1.Atacker && Table.AtackCards.Count>Table.DefendCards.Count)
            {
                HideCardsOnPanel(Player1Cards);
                SwapPlayer(Player2, Player1, false);
            }
            else if (Player2.Atacker && Table.AtackCards.Count > Table.DefendCards.Count)
            {
                HideCardsOnPanel(Player2Cards);
                SwapPlayer(Player1, Player2, false);
            }
            else if (Player2.Deffender && Table.AtackCards.Count == Table.DefendCards.Count)
            {
                HideCardsOnPanel(Player2Cards);
                SwapPlayer(Player1, Player2, true);
            }
            else if (Player1.Deffender && Table.AtackCards.Count == Table.DefendCards.Count)
            {
                HideCardsOnPanel(Player1Cards);
                SwapPlayer(Player2, Player1, true);
            }
            AccessChangesForButtons(false, false);
            CheckWin();
        }

        void EndOfTurnBita()
        {
            if (Player1.Atacker)
            {
                HideCardsOnPanel(Player1Cards);
                SwapPlayer(Player2, Player1, true);
            }
            else if (Player2.Atacker)
            {
                HideCardsOnPanel(Player2Cards);
                SwapPlayer(Player1, Player2, true);
            }
            AccessChangesForButtons(false, false);
            CheckWin();
        }

        void CheckWin()
        {
            if (Coloda.ColodaCard.Count == 0)
            {
                if (Player1.Ruka.Count == 0)
                {
                    ShowWinner(Player1);
                }
                else if (Player2.Ruka.Count == 0)
                {
                    ShowWinner(Player2);
                }
            }
        }

        void ShowWinner(Player player)
        {
            var winnerForm = new WinnerForm(player);
            ShowDialog(winnerForm);
            StartOfTurn.Enabled = false;
            winnerForm.Dispose();
        }

        void ClearTable()
        {
            AtackCardsOnTable.Controls.Clear();
            DeffendCardsOnTable.Controls.Clear();
        }

        void AddCardToTable(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var card = (Card)((Button)sender).Tag;
            if (Player1.Atacker && Player1.CanAtack(card, Table))
            {
                MoveCardToControl(button, AtackCardsOnTable);
                AccessChangesForButtons(true, true, true);
            }
            else if (Player1.Deffender && Player1.CanDeffend(card, Table.AtackCards.Count - 1, Coloda.Kozir, Table))
            {
                MoveCardToControl(button, DeffendCardsOnTable);
                AccessChangesForButtons(true, false, true);
            }
            else if (Player2.Deffender && Player2.CanDeffend(card, Table.AtackCards.Count - 1, Coloda.Kozir, Table))
            {
                MoveCardToControl(button, DeffendCardsOnTable);
                AccessChangesForButtons(true, false, true);
            }
            else if (Player2.Atacker && Player2.CanAtack(card, Table))
            {
                MoveCardToControl(button, AtackCardsOnTable);
                AccessChangesForButtons(true, true, true);
            }
        }

        void MoveCardToControl(Button button, Control control)
        {
            button.Parent = control;
            button.Enabled = false;
        }

        void BitaButton_Click(object sender, EventArgs e)
        {
            if (Table.AtackCards.Count > Table.DefendCards.Count || Table.AtackCards.Count == 0)
                return;
            Table.Bita();
            ClearTable();
            if (Player1.Atacker)
            {
                Player1.PopRuku(Coloda);
                Player2.PopRuku(Coloda);
            }
            else if (Player2.Atacker)
            {
                Player2.PopRuku(Coloda);
                Player1.PopRuku(Coloda);
            }
            CountOfCards.Text = "Карт в колоде: " + Coloda.ColodaCard.Count;
            UpdateCardsInArms();
            EndOfTurnBita();
        }

        void TakeButton_Click(object sender, EventArgs e)
        {
            if (Player1.Deffender)
            {
                Player1.Take(Table);
                Player2.PopRuku(Coloda);
            }
            else if (Player2.Deffender)
            {
                Player2.Take(Table);
                Player1.PopRuku(Coloda);
            }
            ClearTable();
            CountOfCards.Text = "Карт в колоде: " + Coloda.ColodaCard.Count;
            UpdateCardsInArms();
            EndOfTurnUsual();
        }

        void UpdateCardsInArms()
        {
            Player1Cards.Controls.Clear();
            AddCardsToPanel(Player1.Ruka, Player1Cards);
            Player2Cards.Controls.Clear();
            AddCardsToPanel(Player2.Ruka, Player2Cards);
        }
    }
}
