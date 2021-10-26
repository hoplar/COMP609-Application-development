using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApplication
{
    class Sheep : livestock
    {

        public double amtWool;
        public Sheep(int id, double amtWater, double dailyCost, double weight, int age, string colour, double amtWool) : base(id, amtWater, dailyCost, weight, age, colour)
        {
            this.id = id;
            this.amtWater = amtWater;
            this.dailyCost = dailyCost;
            this.weight = weight;
            this.age = age;
            this.colour = colour;
            this.amtWool = amtWool;
        }

        override public string getInfo()
        {
            string info = "Sheep    " + "ID: " + id + " Water: " + amtWater + " Daily Cost: " + dailyCost + " Weight: " + weight + " Age: " + age + " Colour: " + colour + " Wool Amount: " + amtWool;
            return info;
        }

        override public double getProduct()
        {
            return this.amtWool;
        }
        override public double getCost()
        {
            double cost;
            cost = (this.amtWater * Prices.waterPrice) + this.dailyCost + getTax();
            return cost;
        }
        override public double getTax()
        {
            double tax;
            tax = (this.weight * Prices.taxPerKg);
            return tax;
        }
        override public double getProfitability()
        {
            double profit;
            profit = (this.amtWool * Prices.sheepWoolPrice) - getCost();
            return profit;
        }
    }
}
