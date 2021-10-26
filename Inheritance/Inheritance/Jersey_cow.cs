using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Jersey_cow : Cow
    {

        public Jersey_cow(int id, double milkAmount) : base(id, milkAmount)
        {
        }

        override public double getProf()
        {
            double profit;
            profit = (this.milkAmount * Prices.milkPriceCow) - Prices.vacPriceCowJ;
            return profit;
        }

    }
}
