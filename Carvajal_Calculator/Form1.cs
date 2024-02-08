using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Carvajal_Calculator
{
    public partial class Calculator : Form
    {
        double inputNum = 0;
        double result = 0;
        string opeCmd = "";
        bool start = true;
        double exp = 0;

        void input(double value)
        {   
            if (inputNum == 0)
            {
                if(OutputBox.Text != "0" && opeCmd != "")
                {
                    OutputBox.Text += value.ToString();
                    inputNum = Convert.ToDouble(OutputBox.Text);
                }
                else
                {
                    inputNum = value;
                    OutputBox.Text = value.ToString();
                }
            }
            else
            {
                OutputBox.Text += value.ToString();
                inputNum = Convert.ToDouble(OutputBox.Text);
            }
        }

        double sqrt(double value)
        {
            double error = 0.00001;
            double s = value;

            while ((s - value / s) > error)
            {
                s = (s + value / s) / 2;
            }
            return s;
        }

        void solve(String ope, String input)
        {
            inputNum = Convert.ToDouble(OutputBox.Text);

            if(ope == "=")
            {
                switch (opeCmd)
                {
                    case "+":
                        result += inputNum;
                        OutputBox.Text = result.ToString();
                        break;
                    case "-":
                        result -= inputNum;
                        OutputBox.Text = result.ToString();
                        break;
                    case "*":
                        result *= inputNum;
                        OutputBox.Text = result.ToString();
                        break;
                    case "/":
                        result /= inputNum;
                        OutputBox.Text = result.ToString();
                        break;
                    case "^":
                        if(inputNum == 0) {
                            result = 1;
                        }
                        else
                        {
                            exp = result;
                            for (int i = 1; i < inputNum; i++)
                            {
                                result *= exp;
                            }
                        }
                        OutputBox.Text = result.ToString();
                        break;
                    case "%":
                        result %= inputNum;
                        OutputBox.Text = result.ToString();
                        break;
                    default:
                        result = inputNum;
                        OutputBox.Text = result.ToString();
                        break;
                }
            }
            else
            {
                switch (ope)
                {
                    case "+":
                        result += inputNum;
                        OutputBox.Text = "0";
                        break;
                    case "-":
                        result -= inputNum;
                        OutputBox.Text = "0";
                        break;
                    case "*":
                        result *= inputNum;
                        OutputBox.Text = "0";
                        break;
                    case "/":
                        result /= inputNum;
                        OutputBox.Text = "0";
                        break;
                    case "^":
                        if (inputNum == 0)
                        {
                            result = 1;
                        }
                        else
                        {
                            exp = result;
                            for (int i = 1; i < inputNum; i++)
                            {
                                result *= exp;
                            }
                        }
                        OutputBox.Text = "0";
                        break;
                    case "%":
                        result %= inputNum;
                        OutputBox.Text = "0";
                        break;

                }
            }
            ResultBox.Text = result.ToString();
            inputNum = 0;
            OperatorBox.Text = "";
        }

        public Calculator()
        {
            InitializeComponent();

        }

        private void Num0Button_Click(object sender, EventArgs e)
        {
            input(0);
        }

        private void Num1Button_Click(object sender, EventArgs e)
        {
            input(1);
        }

        private void Num2Button_Click(object sender, EventArgs e)
        {
            input(2);
        }

        private void Num3Button_Click(object sender, EventArgs e)
        {
            input(3);
        }

        private void Num4Button_Click(object sender, EventArgs e)
        {
            input(4);
        }

        private void Num5Button_Click(object sender, EventArgs e)
        {
            input(5);
        }

        private void Num6Button_Click(object sender, EventArgs e)
        {
            input(6);
        }

        private void Num7Button_Click(object sender, EventArgs e)
        {
            input(7);
        }

        private void Num8Button_Click(object sender, EventArgs e)
        {
            input(8);
        }

        private void Num9Button_Click(object sender, EventArgs e)
        {
            input(9);
        }

        private void BackspaceButton_Click(object sender, EventArgs e)
        {
            if (!(OutputBox.Text.Length <= 1))
            {
                OutputBox.Text = OutputBox.Text.Substring(0, OutputBox.Text.Length - 1);
            }
            else
            {
                OutputBox.Text = "0";
                inputNum = 0;
            }
        }

        private void DecimalButton_Click(object sender, EventArgs e)
        {
            if(inputNum == 0)
            {
                OutputBox.Text = "0.";
            }
            if (!OutputBox.Text.Contains("."))
            {
                OutputBox.Text += ".";
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            inputNum = 0;
            result = 0;
            opeCmd = "";
            start = true;
            exp = 0;
            OutputBox.Text = "0";
            OperatorBox.Text = "";
            ResultBox.Text = "";
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (start)
            {
                result = Convert.ToDouble(OutputBox.Text);
                start = false;
                OutputBox.Text = "0";
                opeCmd = "+";
                inputNum = 0;
            }
            else
            {
                solve(opeCmd, OutputBox.Text);
                opeCmd = "+";
            }
            OperatorBox.Text = opeCmd;
        }

        private void MinusButton_Click(object sender, EventArgs e)
        {
            if (start)
            {
                result = Convert.ToDouble(OutputBox.Text);
                start = false;
                OutputBox.Text = "0";
                opeCmd = "-";
                inputNum = 0;
            }
            else
            {
                solve(opeCmd, OutputBox.Text);
                opeCmd = "-";
            }
            OperatorBox.Text = opeCmd;
        }

        private void EqualButton_Click(object sender, EventArgs e)
        {
            solve("=", OutputBox.Text);
            inputNum = 0;
            result = 0;
            opeCmd = "";
            start = true;
            exp = 0;
            OperatorBox.Text = "";
        }

        private void MultiplyButton_Click(object sender, EventArgs e)
        {
            if (start)
            {
                result = Convert.ToDouble(OutputBox.Text);
                start = false;
                OutputBox.Text = "0";
                opeCmd = "*";
                inputNum = 0;
            }
            else
            {
                solve(opeCmd, OutputBox.Text);
                opeCmd = "*";
            }
            OperatorBox.Text = opeCmd;
        }

        private void DIvideButton_Click(object sender, EventArgs e)
        {
            if (start)
            {
                result = Convert.ToDouble(OutputBox.Text);
                start = false;
                OutputBox.Text = "0";
                opeCmd = "/";
                inputNum = 0;
            }
            else
            {
                solve(opeCmd, OutputBox.Text);
                opeCmd = "/";
            }
            OperatorBox.Text = opeCmd;
        }

        private void ExponentButton_Click(object sender, EventArgs e)
        {
            if (start)
            {
                result = Convert.ToDouble(OutputBox.Text);
                start = false;
                OutputBox.Text = "0";
                opeCmd = "^";
                inputNum = 0;
            }
            else
            {
                solve(opeCmd, OutputBox.Text);
                opeCmd = "";
            }
            OperatorBox.Text = opeCmd;
            exp = 0;
        }

        private void ModuloButton_Click(object sender, EventArgs e)
        {
            if (start)
            {
                result = Convert.ToDouble(OutputBox.Text);
                start = false;
                OutputBox.Text = "0";
                opeCmd = "%";
                inputNum = 0;
            }
            else
            {
                solve(opeCmd, OutputBox.Text);
                opeCmd = "%";
            }
            OperatorBox.Text = "mod";
        }

        private void PercentButton_Click(object sender, EventArgs e)
        {
            if(opeCmd != "")
            {
                switch (opeCmd)
                {
                    case "+":
                    case "-":
                        OutputBox.Text = ((Convert.ToDouble(OutputBox.Text) / inputNum) * 100).ToString();
                        break;
                    case "*":
                    case "/":
                    case "%":
                        OutputBox.Text = (Convert.ToDouble(OutputBox.Text) / 100).ToString();
                        break;
                }
            }
        }

        private void PositiveNegativeButton_Click(object sender, EventArgs e)
        {
            if (inputNum != 0)
            {
                if (!OutputBox.Text.Contains("-"))
                {
                    OutputBox.Text = "-" + OutputBox.Text;
                    inputNum = -inputNum;
                }
                else
                {
                    inputNum *= -1;
                    OutputBox.Text = inputNum.ToString();
                }
                
            }
        }

        private void SquareRootButton_Click(object sender, EventArgs e)
        {
            OutputBox.Text = Convert.ToDouble(sqrt(inputNum)).ToString();
            inputNum = 0;
            result = 0;
            opeCmd = "";
            start = true;
            exp = 0;
            OperatorBox.Text = "";
        }

        private void Calculator_Load(object sender, EventArgs e)
        {

        }
    }
}
