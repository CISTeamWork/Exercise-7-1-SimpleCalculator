using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //*****************************************************************
        //Tonya Martinez, George Gachoki, Travis Johnson, Jason Thomas
        //May 12, 2020
        //CIS 123
        //Week 5 Murach Coding Assignments
        //Extra exercises 7-1, Simple Calculator    Exception Handling
        //*****************************************************************

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                decimal operand1 = Convert.ToDecimal(txtOperand1.Text);
                string operator1 = txtOperator.Text;
                decimal operand2 = Convert.ToDecimal(txtOperand2.Text);
                decimal result = Calculate(operand1, operator1, operand2);

                result = Math.Round(result, 4);
                this.txtResult.Text = result.ToString();
                txtOperand1.Focus();
            }
            //catch block that handles FormatException
            catch (FormatException )
            {
                //message box shows non-numeric entry error
                MessageBox.Show("Format error. Please enter numeric values for operands", "Entry Error");
                //message box shows entry error stack trace
                //MessageBox.Show("Format error. Please enter numeric values for operands" + "\n\n" + ex.StackTrace, "Entry Error");
            }
            //catch block that handles OverflowException
            catch (OverflowException )
            {
                //message box shows overflow exception
                MessageBox.Show("Overflow error. Please enter smaller Operand1 and/or larger Operand2.", "Memory Overflow Error");

            }
            //catch block that handles DivisionByZeroException
            catch (DivideByZeroException )
            {
                //message box shows division by zero error
                MessageBox.Show("Division-by-Zero error. Please enter a non-zero value for operand2.", "Division by 0 Error");
               
            }
            //catch block that handles any  type of uncatched exceptions
            catch (Exception ex)
            {
                //message box shows error when any other type of exception occurs
                MessageBox.Show(ex.Message + "\n\n" + ex.GetType().ToString() + "\n" +
             ex.StackTrace, "Unexpexted Runtime Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private decimal Calculate(decimal operand1, string operator1,
            decimal operand2)
        {
            decimal result =  0;

            if (operator1 == "+")
                result = operand1 + operand2;
            else if (operator1 == "-")
                result = operand1 - operand2;
            else if (operator1 == "*")
                result = operand1 * operand2;
            else if (operator1 == "/")
                result = operand1 / operand2;
            else if (operator1 == "**" || operator1 == "^")
                result = (decimal)Math.Pow((double)operand1, (double)operand2);
            else
                throw new Exception("Unknown Operator1!");
            return result;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ClearResult(object sender, EventArgs e)
        {
            this.txtResult.Text = "";
        }
    }
}