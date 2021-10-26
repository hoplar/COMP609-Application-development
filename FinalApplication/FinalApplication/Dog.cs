using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApplication
{
    class Dog : livestock
    {


        public Dog(int id, double amtWater, double dailyCost, double weight, int age, string colour) : base(id, amtWater, dailyCost, weight, age, colour)
        {
            this.id = id;
            this.amtWater = amtWater;
            this.dailyCost = dailyCost;
            this.weight = weight;
            this.age = age;
            this.colour = colour;
        }

        override public double getTax()
        {
            return 0;
        }
        override public double getCost()
        {
            double cost;
            cost = (this.amtWater * Prices.waterPrice) + this.dailyCost;
            return cost;
        }
        override public double getProduct()
        {
            return 0;
        }
        override public string getInfo()
        {
            string info ="Dog   " + "ID: " + id + " Water: " + amtWater + " Daily Cost: " + dailyCost + " Weight: " + weight + " Age: " + age + " Colour: " + colour;
            return info;
        }
        override public double getProfitability()
        {
            double profit = 0;
            profit -= getCost();
            return profit;
        }
    }
}
