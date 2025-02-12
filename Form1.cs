﻿using System;
using System.IO;
using System.Windows.Forms;
using static GettingStartedWithCSharp.Calculator;


namespace GettingStartedWithCSharp
{

    public partial class Calculator : Form,ICalculatorView
    {
        
        public Calculator()
        {
            InitializeComponent();
           
        }
        
        public interface ICalculatorView
        {
            event EventHandler DigitClicked;
            event EventHandler OperatorClicked;
            event EventHandler MemoryClicked;
            event EventHandler ClearEntryClicked;
            event EventHandler ClearAllClicked;
            event EventHandler SaveHistoryClicked;
            event EventHandler ResultClicked;
            string ResultBox { get; set; }
            string HistoryBox { get; set; }
        }

        public event EventHandler DigitClicked
        {
            add
            {
                Digit0.Click += value;
                Digit1.Click += value;
                Digit2.Click += value;
                Digit3.Click += value;
                Digit4.Click += value;
                Digit5.Click += value;
                Digit6.Click += value;
                Digit7.Click += value;
                Digit8.Click += value;
                Digit9.Click += value;
                Dot.Click += value;
            }
            remove
            {
                Digit0.Click -= value;
                Digit1.Click -= value;
                Digit2.Click -= value;
                Digit3.Click -= value;
                Digit4.Click -= value;
                Digit5.Click -= value;
                Digit6.Click -= value;
                Digit7.Click -= value;
                Digit8.Click -= value;
                Digit9.Click -= value;
                Dot.Click -= value;
            }
        }

        public event EventHandler OperatorClicked
        {
            add
            {
                Substraction.Click += value;
                Addition.Click += value;
                Multiplication.Click += value;
                Division.Click += value;
                SquareRoot.Click += value;
            }
            remove
            {
                Substraction.Click -= value;
                Addition.Click -= value;
                Multiplication.Click -= value;
                Division.Click -= value;
                SquareRoot.Click -= value;
            }
        }

        public event EventHandler MemoryClicked
        {
            add
            {
                MClear.Click += value;
                MRestore.Click += value;
                MPlus.Click += value;
                MMinus.Click += value; ;
                MStore.Click += value;
                MInfo.Click += value;
            }
            remove
            {
                MClear.Click -= value;
                MRestore.Click -= value;
                MPlus.Click -= value;
                MMinus.Click -= value; ;
                MStore.Click -= value;
                MInfo.Click -= value;
            }
        }

        public event EventHandler ClearEntryClicked
        {
            add
            {
                ClearEntry.Click += value;
            }
            remove
            {
                ClearEntry.Click -= value;
            }
        }

        public event EventHandler ClearAllClicked
        {
            add
            {
                ClearAll.Click += value;
            }
            remove
            {
                ClearAll.Click -= value;
            }
        }

        public event EventHandler SaveHistoryClicked
        {
            add
            {
                SaveHistory.Click += value;
            }
            remove
            {
                SaveHistory.Click -= value;
            }
        }

        public event EventHandler ResultClicked
        {
            add
            {
                Rezulta.Click += value;
            }
            remove
            {
                Rezulta.Click -= value;
            }
        }

        public string TxtResultBox
        {
            get => txtResultBox.Text;
            set => txtResultBox.Text = value;
        }

        public string TxtHistoryBox
        {
            get => txtHistoryBox.Text;
            set => txtHistoryBox.Text = value;
        }

    }
}
