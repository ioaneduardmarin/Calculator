using System;
using System.IO;
using System.Windows.Forms;

namespace GettingStartedWithCSharp
{
    
    
    class CalculatorModel
    {
        public decimal _value;
        public string _operation;
        public string _memoryClick;
        public bool _isMemoryStored;
        public decimal _memory;
        public bool _operationPressed;
        public bool _resultObtained;
        public string _resultBox;
        public string _historyBox;
        public string _equation;

        /*public decimal Adunare(decimal leftArgument, decimal rightArgument)
        {
            return leftArgument + rightArgument;
        }

        public decimal Scadere(decimal leftArgument, decimal rightArgument)
        {
            return leftArgument - rightArgument;
        }

        public decimal Inmultire(decimal leftArgument, decimal rightArgument)
        {
            return leftArgument * rightArgument;
        }

        public decimal Impartire(decimal leftArgument, decimal rightArgument)
        {
            return leftArgument / rightArgument;
        }

        public decimal Radical(decimal leftArgument)
        {
            return (decimal)Math.Sqrt((double)leftArgument);
        }

        public string Rezult(string operation, decimal leftArgument, decimal rightArgument)
        {
            switch (operation)
            {
                case "+":
                    return Adunare(leftArgument, rightArgument).ToString("0.000");

                case "-":
                    return Scadere(leftArgument, rightArgument).ToString("0.000"); ;

                case "*":
                    return Inmultire(leftArgument, rightArgument).ToString("0.000"); ;

                case "/":
                    try
                    {
                        return Inmultire(leftArgument, rightArgument).ToString("0.000");
                    }
                    catch (DivideByZeroException)
                    {
                        MessageBox.Show("Impartirea la 0 nu este o operatie valida");
                    }
                    break;
                case "sqrt":
                    if (leftArgument < 0)
                    {
                        try { throw new Exception("Radacina patrata a numerelor negative nu este posibila"); }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Radacina patrata a numerelor negative nu este posibila");
                        }

                    }
                    else
                    {
                        rightArgument = 0;
                        return  (Math.Sqrt((double)leftArgument)).ToString("0.000");
                    }
                    break;
                default:
                    break;
            }


            return null;
        }

        public string StergeTot()
        {
            return "";
        }
        private string Sterge()
        {
            return  "0";
        }

        public void SalveazaIstoric(string istoric)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text File|*";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = sfd.FileName;
                using (var sw = new StreamWriter(File.Create(path)))
                {
                    sw.Write(istoric.Remove((istoric.Length - 2), 1));
                    sw.Dispose();
                }
            }
        }

        private Tuple<bool,> MemoryClick(string memoryClick, decimal leftArgument)
        {
            if (!_isMemoryStored)
            {
                return _isMemoryStored;
            }

            switch (memoryClick)
            {
                case "MC":
                    string mesaj = "Do you want to clear the memory?";
                    string titlu = "Memory Clear";
                    MessageBoxButtons butoane = MessageBoxButtons.YesNo;
                    DialogResult rezultat = MessageBox.Show(mesaj, titlu, butoane);
                    if (rezultat == DialogResult.Yes)
                    {
                        _isMemoryStored = false;
                        MClear.Enabled = false;
                        MRestore.Enabled = false;
                        MInfo.Enabled = false;
                    }
                    break;
                case "MR":
                    ResultBox.Text = memory.ToString();
                    break;
                case "MS":
                    memory = (decimal)Double.Parse(ResultBox.Text);
                    isMemoryStored = true;
                    MClear.Enabled = true;
                    MRestore.Enabled = true;
                    MInfo.Enabled = true;
                    break;
                case "M+":
                    memory += (decimal)(Double.Parse(ResultBox.Text));
                    break;
                case "M-":
                    memory -= (decimal)Double.Parse(ResultBox.Text);
                    break;
                case "M":
                    MemoryShow.SetToolTip(MInfo, memory.ToString());
                    break;
                default:
                    break;
            }
        }*/
    }
}
