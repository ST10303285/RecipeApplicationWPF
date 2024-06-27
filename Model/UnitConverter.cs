using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApplication.Model
{
    public static class UnitConverter
    {
        public static (double, string) Convert(double quantity, string unit)
        {
            // Example conversion logic
            if (unit == "grams" && quantity >= 1000)
            {
                return (quantity / 1000, "kilograms");
            }
            // Add more conversion logic as needed

            // Return the original values if no conversion is performed
            return (quantity, unit);
        }
    }
}
