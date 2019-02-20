using System;
using System.Collections.Generic;
using System.Linq;
using CookbookApi.Models;

namespace CookbookApi.Utils
{
    public static class IngredientFormatter
    {
        public static string FormatIngredient(double quantity, string unit, string food)
        {
            string quantityString;
            var threshold = 0.0001;

            if (Math.Abs(quantity - (int)quantity) < threshold)
            {
                quantityString = ((int)quantity).ToString();
            }
            else
            {
                quantityString = FormatFraction(ConvertToFraction(quantity));
            }

            return $"{quantityString} {unit} {food}";
        }

        private static string FormatFraction(MixedFraction frac)
        {
            if (frac.IntegerPart == 0)
            {
                if (frac.Numerator == 0)
                {
                    return "0";
                }
                else
                {
                    return $"{frac.Numerator}/{frac.Denominator}";
                }
            }
            else
            {
                if (frac.Numerator == 0)
                {
                    return frac.IntegerPart.ToString();
                }
                else
                {
                    return $"{frac.IntegerPart} {frac.Numerator}/{frac.Denominator}";
                }
            }
        }

        private static MixedFraction ConvertToFraction(double x)
        {
            var denoms = new List<int>() { 2, 3, 4, 5, 6, 8, 16 };

            var integerPart = (int)x;
            var numerator = 0;
            var denominator = 0;

            x -= (double)integerPart;
            var minDiff = x;

            foreach (var denom in denoms)
            {
                foreach (var num in Enumerable.Range((int)(x * denom), (int)(x * denom) + 2))
                {
                    var diff = Math.Abs((double)num / (double)denom - x);
                    if (diff < minDiff)
                    {
                        minDiff = diff;
                        numerator = num;
                        denominator = denom;
                    }
                }
            }

            return new MixedFraction(integerPart, numerator, denominator);
        }

        private class MixedFraction
        {
            public int IntegerPart { get; private set; }
            public int Numerator { get; private set; }
            public int Denominator { get; private set; }

            public MixedFraction(int integerPart, int numerator, int denominator)
            {
                IntegerPart = integerPart;
                Numerator = numerator;
                Denominator = denominator;
            }
        }
    }
}
