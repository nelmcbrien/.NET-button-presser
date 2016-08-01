using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace BPTest
{
    public partial class Form1 : Form
    {
        private string key;
        private bool run;
        
        public Form1()
        {
            InitializeComponent();
        }
        
        private void btnToggle_Click(object sender, EventArgs e)
        {   
            if (btnToggle.Text == "Start")
            {
                btnToggle.Text = "Stop";
                run = true;
                doPresses();
            }
            else
            {
                btnToggle.Text = "Start";
                run = false;
            }
        
        }

        async void doPresses()
        {
            try
            {
                string key = getKey();
                await Task.Delay(2000);//Wait before hitting key first time
                while (run)
                {
                    SendKeys.Send(key);
                    await Task.Delay(2000); //Two seconds for testing
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please select a key.", "Error", MessageBoxButtons.OK);
            }         
        }

        private string getKey()
        {
            string key = cbKey.SelectedItem.ToString();

            switch(key)
            {
                case "E":
                    return "E";   
                case "K"  :
                    return "K";                                
                default:
                    return "{ENTER}";
            }                
        }
    }
}
