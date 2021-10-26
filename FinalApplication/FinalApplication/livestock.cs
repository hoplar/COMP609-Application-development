using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalApplication
{
    abstract class livestock
    {
        public int id;
        public double amtWater;
        public double dailyCost;
        public double weight;
        public int age;
        public string colour;

        public livestock(int id, double amtWater, double dailyCost, double weight, int age, string colour)
        {
            this.id = id;
            this.amtWater = amtWater;
            this.dailyCost = dailyCost;
            this.weight = weight;
            this.age = age;
            this.colour = colour;
        }

        public abstract string getInfo();
        public abstract double getProduct();
        public abstract double getTax();
        public abstract double getCost();
        public abstract double getProfitability();

    }
}
