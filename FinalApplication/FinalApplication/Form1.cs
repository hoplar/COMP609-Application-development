using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace FinalApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static int GCD(int a, int b)
        {
            return b == 0 ? Math.Abs(a) : GCD(b, a % b);
        }

        //Reads the database into appropriate objects and stores in a dictionary
        private void readDatabase(string tables, Dictionary<int, livestock> myAnimals)
        {
            String ConnStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = C:\Users\monke\Desktop\FarmInfomation.accdb; Persist Security Info = False";
            OleDbConnection conn = null;
            try
            {
                conn = new OleDbConnection(ConnStr);
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(tables, conn);
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    int count = 0;
                    while (reader.Read())
                    {

                        if (tables == Tables.cowsTable && Convert.ToBoolean(reader.GetValue(7)) == false)
                        {
                            myAnimals.Add(Convert.ToInt32(reader.GetValue(0)), new Cow(Convert.ToInt32(reader.GetValue(0)), Convert.ToDouble(reader.GetValue(1)), Convert.ToDouble(reader.GetValue(2)), Convert.ToDouble(reader.GetValue(3)), Convert.ToInt32(reader.GetValue(4)), Convert.ToString(reader.GetValue(5)), Convert.ToDouble(reader.GetValue(6))));
                        }
                        else if (tables == Tables.cowsTable && Convert.ToBoolean(reader.GetValue(7)) == true)
                        {
                            myAnimals.Add(Convert.ToInt32(reader.GetValue(0)), new CowJersey(Convert.ToInt32(reader.GetValue(0)), Convert.ToDouble(reader.GetValue(1)), Convert.ToDouble(reader.GetValue(2)), Convert.ToDouble(reader.GetValue(3)), Convert.ToInt32(reader.GetValue(4)), Convert.ToString(reader.GetValue(5)), Convert.ToDouble(reader.GetValue(6))));
                        }
                        else if (tables == Tables.goatsTable)
                        {
                            myAnimals.Add(Convert.ToInt32(reader.GetValue(0)), new Goat(Convert.ToInt32(reader.GetValue(0)), Convert.ToDouble(reader.GetValue(1)), Convert.ToDouble(reader.GetValue(2)), Convert.ToDouble(reader.GetValue(3)), Convert.ToInt32(reader.GetValue(4)), Convert.ToString(reader.GetValue(5)), Convert.ToDouble(reader.GetValue(6))));
                        }
                        else if (tables == Tables.sheepTable)
                        {
                            myAnimals.Add(Convert.ToInt32(reader.GetValue(0)), new Sheep(Convert.ToInt32(reader.GetValue(0)), Convert.ToDouble(reader.GetValue(1)), Convert.ToDouble(reader.GetValue(2)), Convert.ToDouble(reader.GetValue(3)), Convert.ToInt32(reader.GetValue(4)), Convert.ToString(reader.GetValue(5)), Convert.ToDouble(reader.GetValue(6))));
                        }
                        else if (tables == Tables.dogsTable)
                        {
                            myAnimals.Add(Convert.ToInt32(reader.GetValue(0)), new Dog(Convert.ToInt32(reader.GetValue(0)), Convert.ToDouble(reader.GetValue(1)), Convert.ToDouble(reader.GetValue(5)), Convert.ToDouble(reader.GetValue(2)), Convert.ToInt32(reader.GetValue(3)), Convert.ToString(reader.GetValue(4))));
                        }
                        //sets prices
                        else if (tables == Tables.priceTable)
                        {
                            if (count == 0)
                            {
                                Prices.milkPriceGoat = Convert.ToDouble(reader.GetValue(1));
                            }
                            else if (count == 1)
                            {
                                Prices.sheepWoolPrice = Convert.ToDouble(reader.GetValue(1));
                            }
                            else if (count == 2)
                            {
                                Prices.waterPrice = Convert.ToDouble(reader.GetValue(1));
                            }
                            else if (count == 3)
                            {
                                Prices.taxPerKg = Convert.ToDouble(reader.GetValue(1));
                            }
                            else if (count == 4)
                            {
                                Prices.jCowTax = Convert.ToDouble(reader.GetValue(1));
                            }
                            else if (count == 5)
                            {
                                Prices.milkPriceCow = Convert.ToDouble(reader.GetValue(1));
                            }
                        }
                        count++;

                    }

                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void genRepoBtn_Click(object sender, EventArgs e)
        {
            outputText.Clear();
            Dictionary<int, livestock> myAnimals = new Dictionary<int, livestock>();

            readDatabase(Tables.priceTable, myAnimals);
            readDatabase(Tables.cowsTable, myAnimals);
            readDatabase(Tables.goatsTable, myAnimals);
            readDatabase(Tables.sheepTable, myAnimals);
            readDatabase(Tables.dogsTable, myAnimals);

            string input = inputText.Text;
            string[] words = input.Split(' ');
            string report = words[0];
            string report2 = "";
            try
            {
                report2 = words[1];
            }
            catch
            {
            }

            try
            {
                //Display the total profitability/loose of the farm per day
                if (report == "2")
                {
                    double profit = 0;
                    foreach (var anim in myAnimals)
                    {
                        profit += anim.Value.getProfitability();
                    }
                    outputText.Text = "Total Profitability Per Day: $" + profit;
                }
                //Display the total tax paid to the government per month
                else if (report == "3")
                {
                    double tax = 0;
                    foreach (var anim in myAnimals)
                    {
                        tax += anim.Value.getTax();
                    }
                    outputText.Text = "Total Tax Paid: $" + tax;
                }
                //Display the total amount of milk per day for goats and cows
                else if (report == "4")
                {
                    double totalMilk = 0;
                    foreach (var anim in myAnimals)
                    {
                        if (anim.Value is Cow || anim.Value is CowJersey || anim.Value is Goat)
                        {
                            totalMilk += anim.Value.getProduct();
                        }
                    }
                    outputText.Text += "Total Milk Per Day: " + totalMilk;
                }
                //Display the average age of all animal farms (dog excluded) 
                else if (report == "5")
                {
                    int count = 0;
                    double ageTotal = 0;
                    double ageAverage = 0;
                    foreach (var anim in myAnimals)
                    {
                        if(!(anim.Value is Dog))
                        {
                            ageTotal += anim.Value.age;
                            count++;
                        }
                    }
                    ageAverage = ageTotal / count;
                    outputText.Text += "Average Age: " + ageAverage;
                }
                //Display the average profitability of “Goats and Cow” Vs. Sheep 
                else if (report == "6")
                {
                    int cowGoatCount = 0;
                    int sheepCount = 0;
                    double cowGoatTotal = 0;
                    double cowGoatAverage = 0;
                    double sheepTotal = 0;
                    double sheepAverage = 0;
                    foreach (var anim in myAnimals)
                    {
                        if (anim.Value is Cow || anim.Value is CowJersey || anim.Value is Goat)
                        {
                            cowGoatTotal += anim.Value.getProfitability();
                            cowGoatCount++;
                        }
                        else if (anim.Value is Sheep)
                        {
                            sheepTotal += anim.Value.getProfitability();
                            sheepCount++;
                        }
                    }
                    cowGoatAverage = cowGoatTotal / cowGoatCount;
                    sheepAverage = sheepTotal / sheepCount;

                    outputText.Text += "Profit of Cows/Goats vs Sheep: " + cowGoatAverage + " vs " + sheepAverage;
                }
                //Display the ratio of Dogs’ cost compared to the total cost
                else if (report == "7")
                {
                    double dogCostTotal = 0;
                    double costTotal = 0;
                    foreach (var anim in myAnimals)
                    {
                        if (anim.Value is Dog)
                        {
                            dogCostTotal += anim.Value.getCost();
                        }
                        costTotal += anim.Value.getCost();
                    }
                    int gcd = GCD((int)dogCostTotal, (int)costTotal);
                    outputText.Text += "Ratio Of Dogs vs Total: " + dogCostTotal/gcd + " : " + costTotal/gcd; //make 2 sf
                }
                //Generate a file that contains the ID of all animal ordered by their 
                //profitability(You are not allowed to use built -in sorting algorithm – Your
                //code must do the sorting). Dogs are excluded
                else if (report == "8")
                {
                    List<livestock> sortedAnimals = new List<livestock>();
                    List<livestock> animals = new List<livestock>();
                    string fileName = @"../../report8.txt";
                    FileInfo fi = new FileInfo(fileName);
                    foreach (var anim in myAnimals)
                    {
                        if (!(anim.Value is Dog))
                        {
                            animals.Add(anim.Value);

                        }
                    }
                    //loops through list until empty... checks for lowest profitability then adds to 2nd list
                    while (animals.Count != 0)
                    {
                        livestock minimum = animals[0];
                        foreach (livestock anim in animals)
                        {
                            if (anim.getProfitability() < minimum.getProfitability())
                            {
                                minimum = anim;
                            }
                        }
                        sortedAnimals.Add(minimum);
                        animals.Remove(minimum);
                    }

                    // Check if file already exists. If yes, delete it.     
                    if (fi.Exists)
                        {
                            fi.Delete();
                        }
                    using (StreamWriter sw = fi.CreateText())
                    {
                        for (int i = 0; i < sortedAnimals.Count; i++)
                        {
                            sw.WriteLine("ID: {0} {1}", sortedAnimals[i].id, sortedAnimals[i].getProfitability());
                        }
                    }
                    outputText.Text += "Report Text File Generated";


                }
                //Display the ratio of livestock with the color red
                else if (report == "9")
                {
                    int count = 0;
                    int redCount = 0;
                    foreach (var anim in myAnimals)
                    {
                        if (anim.Value.colour == "Red")
                        {
                            redCount++;
                        }
                        count++;
                    }
                    int gcd = GCD(redCount, count);
                    outputText.Text += "Ratio Of Red Livestock: " + redCount / gcd + " : " + count / gcd;
                }
                //Display the total tax paid for Jersey Cows
                else if (report == "10")
                {
                    double totalTax = 0;
                    foreach (var anim in myAnimals)
                    {
                        if (anim.Value is CowJersey)
                        {
                            totalTax += anim.Value.getTax();
                        }
                    }
                    outputText.Text += "Tax for Jersey Cows: $" + totalTax;
                }
                //The user enter a threshold (number of years), and the program displays the 
                //ratio of the number of animal farm where the age is above this threshold.
                else if (report == "11")
                {
                    double age = double.Parse(report2);
                    int ageAbove = 0;
                    int count = 0;
                    foreach (var anim in myAnimals)
                    {
                        if (anim.Value.age > age)
                        {
                            ageAbove ++;
                        }
                        count++;
                    }
                    int gcd = GCD(ageAbove, count);
                    outputText.Text += "Ratio Above The Age: " + age + "    " + ageAbove / gcd + " : " + count / gcd;
                }
                //Display the total profitability of all Jersey Cows. 
                else if (report == "12")
                {
                    double jCowProfit = 0;
                    foreach (var anim in myAnimals)
                    {
                        if (anim.Value is CowJersey)
                        {
                            jCowProfit += anim.Value.getProfitability();
                        }
                    }
                    outputText.Text += "Jersey Cow Profits: $" + jCowProfit;
                }
                ///The user enter an ID and the program displays the information associated
                ///with this animal farm. In addition to the basic information, a string will be
                ///added to state the type of the animal(Dog, Cow, Jersey Cow, Sheep or Goat)
                else
                {
                    bool found = false;
                    foreach (var anim in myAnimals)
                    {
                        if (int.Parse(report) == anim.Value.id)
                        {
                            outputText.Text += anim.Value.getInfo();
                            return;
                        }
                    }
                    if (!found)
                    {
                        MessageBox.Show("No animal or report with id " + report + " found");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
