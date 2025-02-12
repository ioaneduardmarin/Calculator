﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GettingStartedWithCSharp.Calculator;
using  GettingStartedWithCSharp.CalculatorModel;

namespace GettingStartedWithCSharp
{
    class CalculatorPresenter
    {
        private readonly ICalculatorView calculatorView;
        CalculatorModel _calculatorModel = new CalculatorModel;

        public CalculatorPresenter(ICalculatorView calculatorView)
        {
            this.calculatorView = calculatorView;
            calculatorView.DigitClicked += DigitClick;
            calculatorView.OperatorClicked += OperatorClick;
            calculatorView.ResultClicked += ResultClick;
            calculatorView.SaveHistoryClicked += SaveHistoryClick;
            calculatorView.MemoryClicked += MemoryClick;
            calculatorView.ClearAllClicked += ClearAllClick;
            calculatorView.ClearEntryClicked += ClearEntryClick;
            calculatorView.ResultBox = "";
            calculatorView.HistoryBox = "";
        }
        

        private void DigitClick(object sender, EventArgs e)
        {
            if (_calculatorModel._resultBox == "0" || (_calculatorModel._operationPressed))
                _calculatorModel._resultBox = "";

            if (_calculatorModel._resultObtained)
            {
                _calculatorModel._resultBox = "";
            }
            _calculatorModel._resultObtained = false;
            _calculatorModel._operationPressed = false;
            Button b = (Button)sender;
            _calculatorModel._resultBox += b.Text;

        }

        private void ClearEntryClick(object sender, EventArgs e)
        {
            _calculatorModel._resultBox = "0";
        }

        private void OperatorClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            _calculatorModel._operation = b.Text;
            try
            {
                _calculatorModel._value = (decimal)(Double.Parse(_calculatorModel._resultBox));
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Introduceti o valoare valida");
                _calculatorModel._resultBox= "0";
                _calculatorModel._equation = "0";
            }
           _calculatorModel._operationPressed = true;
            _calculatorModel._equation = _calculatorModel._value + " " + _calculatorModel._operation;
        }

        private void ResultClick(object sender, EventArgs e)
        {
            _calculatorModel._operationPressed = false;
            _calculatorModel._equation = "";
            switch (_calculatorModel._operation)
            {
                case "+":
                    _calculatorModel._resultBox = (_calculatorModel._value + (decimal)Double.Parse(_calculatorModel._resultBox)).ToString("0.000");
                    break;
                case "-":
                    _calculatorModel._resultBox = (_calculatorModel._value - (decimal)Double.Parse(_calculatorModel._resultBox)).ToString("0.000");
                    break;
                case "*":
                    _calculatorModel._resultBox = (_calculatorModel._value * (decimal)Double.Parse(_calculatorModel._resultBox)).ToString("0.000");
                    break;
                case "/":
                    try
                    {
                        _calculatorModel._resultBox = (_calculatorModel._value / (decimal)Double.Parse(_calculatorModel._resultBox)).ToString("0.000");
                    }
                    catch (DivideByZeroException)
                    {
                        MessageBox.Show("Impartirea la 0 nu este o operatie valida");
                        _calculatorModel._resultBox = "operatie nevalida";
                    }
                    break;
                case "sqrt":
                    if (_calculatorModel._value < 0)
                    {
                        try { throw new Exception("Radacina patrata a numerelor negative nu este posibila"); }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Radacina patrata a numerelor negative nu este posibila");
                        }
                        _calculatorModel._resultBox = "operatie nevalida";
                    }
                    else
                    {
                        _calculatorModel._resultBox = (Math.Sqrt((double)_calculatorModel._value)).ToString("0.000");
                    }
                    break;
                default:
                    break;
            }
            _calculatorModel._resultObtained = true;
            _calculatorModel._historyBox += (_calculatorModel._resultBox + ", ");
        }

        private void ClearAllClick(object sender, EventArgs e)
        {
            _calculatorModel._resultBox = "";
            _calculatorModel._historyBox = "";
            _calculatorModel._value = 0;
        }

        private void SaveHistoryClick(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text File|*";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = sfd.FileName;
                using (var sw = new StreamWriter(File.Create(path)))
                {
                    sw.Write(_calculatorModel._historyBox.Remove((_calculatorModel._historyBox.Length - 2), 1));
                    sw.Dispose();
                }
            }
        }

        private void MemoryClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            _calculatorModel._memoryClick = b.Text;

            if (!_calculatorModel._isMemoryStored)
            {
                MClear.Enabled = false;
                MRestore.Enabled = false;
                MInfo.Enabled = false;
            }

            switch (_calculatorModel._memoryClick)
            {
                case "MC":
                    string mesaj = "Do you want to clear the memory?";
                    string titlu = "Memory Clear";
                    MessageBoxButtons butoane = MessageBoxButtons.YesNo;
                    DialogResult rezultat = MessageBox.Show(mesaj, titlu, butoane);
                    if (rezultat == DialogResult.Yes)
                    {
                        _calculatorModel._isMemoryStored = false;
                        MClear.Enabled = false;
                        MRestore.Enabled = false;
                        MInfo.Enabled = false;
                    }
                    break;
                case "MR":
                    ResultBox.Text = _calculatorModel._memory.ToString();
                    break;
                case "MS":
                    _calculatorModel._memory = (decimal)Double.Parse(_calculatorModel._resultBox);
                    isMemoryStored = true;
                    MClear.Enabled = true;
                    MRestore.Enabled = true;
                    MInfo.Enabled = true;
                    break;
                case "M+":
                    _calculatorModel._memory += (decimal)(Double.Parse(_calculatorModel._resultBox));
                    break;
                case "M-":
                    _calculatorModel._memory -= (decimal)Double.Parse(_calculatorModel._resultBox);
                    break;
                case "M":
                    MemoryShow.SetToolTip(MInfo, _calculatorModel._memory.ToString());
                    break;
                default:
                    break;
            }
        }

    }
}
