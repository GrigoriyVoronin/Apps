using System;
using System.Windows.Forms;
using System.Drawing;
namespace DURAK
{
    partial class TableForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.player1Label = new System.Windows.Forms.Label();
            this.player2Label = new System.Windows.Forms.Label();
            this.endOfTurn = new System.Windows.Forms.Button();
            this.trumpCard = new System.Windows.Forms.Label();
            this.Player1Cards = new System.Windows.Forms.Panel();
            this.Player2Cards = new System.Windows.Forms.Panel();
            this.AtackCardsOnTable = new System.Windows.Forms.Panel();
            this.AtackCardsLabel = new System.Windows.Forms.Label();
            this.StartOfTurn = new System.Windows.Forms.Button();
            this.PlayerMove = new System.Windows.Forms.Label();
            this.DeffendCardsOnTable = new System.Windows.Forms.Panel();
            this.DeffendCardsLabel = new System.Windows.Forms.Label();
            this.CountOfCards = new System.Windows.Forms.Label();
            this.BitaButton = new System.Windows.Forms.Button();
            this.TakeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // player1Label
            // 
            this.player1Label.AutoSize = true;
            this.player1Label.Location = new System.Drawing.Point(12, 78);
            this.player1Label.Name = "player1Label";
            this.player1Label.Size = new System.Drawing.Size(42, 13);
            this.player1Label.TabIndex = 0;
            this.player1Label.Text = "Player1";
            // 
            // player2Label
            // 
            this.player2Label.AutoSize = true;
            this.player2Label.Location = new System.Drawing.Point(12, 440);
            this.player2Label.Name = "player2Label";
            this.player2Label.Size = new System.Drawing.Size(42, 13);
            this.player2Label.TabIndex = 1;
            this.player2Label.Text = "Player2";
            // 
            // endOfTurn
            // 
            this.endOfTurn.Enabled = false;
            this.endOfTurn.Location = new System.Drawing.Point(713, 205);
            this.endOfTurn.Name = "endOfTurn";
            this.endOfTurn.Size = new System.Drawing.Size(75, 23);
            this.endOfTurn.TabIndex = 2;
            this.endOfTurn.Text = "Закончить ход";
            this.endOfTurn.UseVisualStyleBackColor = true;
            this.endOfTurn.Click += new System.EventHandler(this.EndOfTurn_Click);
            // 
            // trumpCard
            // 
            this.trumpCard.AutoSize = true;
            this.trumpCard.Location = new System.Drawing.Point(680, 9);
            this.trumpCard.Name = "trumpCard";
            this.trumpCard.Size = new System.Drawing.Size(46, 13);
            this.trumpCard.TabIndex = 3;
            this.trumpCard.Text = "Козырь";
            // 
            // Player1Cards
            // 
            this.Player1Cards.AutoScroll = true;
            this.Player1Cards.Location = new System.Drawing.Point(60, 15);
            this.Player1Cards.Name = "Player1Cards";
            this.Player1Cards.Size = new System.Drawing.Size(620, 76);
            this.Player1Cards.TabIndex = 4;
            // 
            // Player2Cards
            // 
            this.Player2Cards.Location = new System.Drawing.Point(60, 352);
            this.Player2Cards.Name = "Player2Cards";
            this.Player2Cards.Size = new System.Drawing.Size(620, 98);
            this.Player2Cards.TabIndex = 5;
            // 
            // AtackCardsOnTable
            // 
            this.AtackCardsOnTable.AutoScroll = true;
            this.AtackCardsOnTable.Location = new System.Drawing.Point(98, 143);
            this.AtackCardsOnTable.Name = "AtackCardsOnTable";
            this.AtackCardsOnTable.Size = new System.Drawing.Size(582, 100);
            this.AtackCardsOnTable.TabIndex = 6;
            // 
            // AtackCardsLabel
            // 
            this.AtackCardsLabel.AutoSize = true;
            this.AtackCardsLabel.Location = new System.Drawing.Point(5, 217);
            this.AtackCardsLabel.Name = "AtackCardsLabel";
            this.AtackCardsLabel.Size = new System.Drawing.Size(80, 26);
            this.AtackCardsLabel.TabIndex = 0;
            this.AtackCardsLabel.Text = "Карты \n нападающего";
            // 
            // StartOfTurn
            // 
            this.StartOfTurn.Location = new System.Drawing.Point(713, 165);
            this.StartOfTurn.Name = "StartOfTurn";
            this.StartOfTurn.Size = new System.Drawing.Size(75, 23);
            this.StartOfTurn.TabIndex = 7;
            this.StartOfTurn.Text = "Начать ход";
            this.StartOfTurn.UseVisualStyleBackColor = true;
            this.StartOfTurn.Click += new System.EventHandler(this.StartOfTurn_Click);
            // 
            // PlayerMove
            // 
            this.PlayerMove.AutoSize = true;
            this.PlayerMove.Location = new System.Drawing.Point(680, 134);
            this.PlayerMove.Name = "PlayerMove";
            this.PlayerMove.Size = new System.Drawing.Size(0, 13);
            this.PlayerMove.TabIndex = 8;
            // 
            // DeffendCardsOnTable
            // 
            this.DeffendCardsOnTable.AutoScroll = true;
            this.DeffendCardsOnTable.Location = new System.Drawing.Point(98, 249);
            this.DeffendCardsOnTable.Name = "DeffendCardsOnTable";
            this.DeffendCardsOnTable.Size = new System.Drawing.Size(582, 83);
            this.DeffendCardsOnTable.TabIndex = 9;
            // 
            // DeffendCardsLabel
            // 
            this.DeffendCardsLabel.AutoSize = true;
            this.DeffendCardsLabel.Location = new System.Drawing.Point(5, 306);
            this.DeffendCardsLabel.Name = "DeffendCardsLabel";
            this.DeffendCardsLabel.Size = new System.Drawing.Size(86, 26);
            this.DeffendCardsLabel.TabIndex = 0;
            this.DeffendCardsLabel.Text = "Карты \n защищающего";
            // 
            // CountOfCards
            // 
            this.CountOfCards.AutoSize = true;
            this.CountOfCards.Location = new System.Drawing.Point(680, 55);
            this.CountOfCards.Name = "CountOfCards";
            this.CountOfCards.Size = new System.Drawing.Size(0, 13);
            this.CountOfCards.TabIndex = 10;
            // 
            // BitaButton
            // 
            this.BitaButton.Enabled = false;
            this.BitaButton.Location = new System.Drawing.Point(713, 249);
            this.BitaButton.Name = "BitaButton";
            this.BitaButton.Size = new System.Drawing.Size(75, 23);
            this.BitaButton.TabIndex = 11;
            this.BitaButton.Text = "Бита";
            this.BitaButton.UseVisualStyleBackColor = true;
            this.BitaButton.Click += new System.EventHandler(this.BitaButton_Click);
            // 
            // TakeButton
            // 
            this.TakeButton.Enabled = false;
            this.TakeButton.Location = new System.Drawing.Point(713, 290);
            this.TakeButton.Name = "TakeButton";
            this.TakeButton.Size = new System.Drawing.Size(75, 23);
            this.TakeButton.TabIndex = 12;
            this.TakeButton.Text = "Взять карты";
            this.TakeButton.UseVisualStyleBackColor = true;
            this.TakeButton.Click += new System.EventHandler(this.TakeButton_Click);
            // 
            // TableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 462);
            this.Controls.Add(this.DeffendCardsLabel);
            this.Controls.Add(this.AtackCardsLabel);
            this.Controls.Add(this.TakeButton);
            this.Controls.Add(this.BitaButton);
            this.Controls.Add(this.player2Label);
            this.Controls.Add(this.player1Label);
            this.Controls.Add(this.CountOfCards);
            this.Controls.Add(this.DeffendCardsOnTable);
            this.Controls.Add(this.PlayerMove);
            this.Controls.Add(this.StartOfTurn);
            this.Controls.Add(this.AtackCardsOnTable);
            this.Controls.Add(this.Player2Cards);
            this.Controls.Add(this.Player1Cards);
            this.Controls.Add(this.trumpCard);
            this.Controls.Add(this.endOfTurn);
            this.Name = "TableForm";
            this.Text = "TableForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        public Button Card (Card card, int indexOfCard, Panel panel)
        {
            var cardForm = new Button();
            cardForm.Location = new Point(50+70 * (indexOfCard) ,5);
            cardForm.Name = "Card";
            cardForm.Size = new Size(70, 35);
            cardForm.Text = card.Mast.ToString()+"\n"+card.Rank.ToString();
            cardForm.UseVisualStyleBackColor = true;
            cardForm.Tag = card;
            cardForm.Click += new System.EventHandler(this.AddCardToTable);
            cardForm.Visible = false;
            return cardForm;
        }
        #endregion

        private Label player1Label;
        private Label player2Label;
        private Button endOfTurn;
        private Label trumpCard;
        private Panel Player1Cards;
        private Panel Player2Cards;
        private Panel AtackCardsOnTable;
        private Button StartOfTurn;
        private Label PlayerMove;
        private Panel DeffendCardsOnTable;
        private Label AtackCardsLabel;
        private Label DeffendCardsLabel;
        private Label CountOfCards;
        private Button BitaButton;
        private Button TakeButton;
    }
}

