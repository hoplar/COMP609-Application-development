using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inheritance
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private double totProf(Dictionary<int, Animal> myAnimals)
        {
            double profit = 0;
            foreach(var anim in myAnimals)
            {
                profit += anim.Value.getProf();
            }
            return profit;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                Prices.milkPriceCow = double.Parse(textBoxCowMlk.Text);
                Prices.milkPriceGoat = double.Parse(textBoxGoatMlk.Text);
                Prices.vacPriceCow = double.Parse(textBoxCowVac.Text);
                Prices.vacPriceCowJ = double.Parse(textBoxJCowVac.Text);
                Prices.vacPriceGoat = double.Parse(textBoxGoatVac.Text);
            }
            catch
            {
                MessageBox.Show("Enter Only Numbers For Prices");
            }

            try
            {
                Dictionary<int, Animal> myAnimals = new Dictionary<int, Animal>();
                string line;
                System.IO.StreamReader file = new System.IO.StreamReader(@textBoxBrowse.Text);
                int i = 0;
                while ((line = file.ReadLine()) != null)
                {
                    string[] values = line.Split(',');
                    if (values[2] == "Cow")
                    {
                        myAnimals.Add(i, new Cow(int.Parse(values[0]), double.Parse(values[1])));
                    }
                    else if (values[2] == "Jersey_Cow")
                    {
                        myAnimals.Add(i, new Jersey_cow(int.Parse(values[0]), double.Parse(values[1])));
                    }
                    else if (values[2] == "Goat")
                    {
                        myAnimals.Add(i, new Goat(int.Parse(values[0]), double.Parse(values[1])));
                    }
                    i++;
                }
                file.Close();
                textBoxProfit.Text = "$" + totProf(myAnimals).ToString();
            }
            catch
            {
                MessageBox.Show("Text File Error");
            }

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();

            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
                textBoxBrowse.Text = fdlg.FileName;
            }
        }
    }
}
