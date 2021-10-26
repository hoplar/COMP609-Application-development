using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Cow : Animal
    {
        public double milkAmount;

        public Cow(int id, double milkAmount) : base(id)
        {
            this.milkAmount = milkAmount;
        }

        override public double getProf()
        {
            double profit;
            profit = (this.milkAmount * Prices.milkPriceCow) - Prices.vacPriceCow;
            return profit;
        }

    }
}
