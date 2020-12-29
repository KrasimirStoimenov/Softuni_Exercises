using System;

namespace ValidationAttributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;
        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override bool IsValid(object obj)
        {
            if (!(obj is int))
            {
                throw new ArgumentException("Object must be integer");
            }

            int casted = (int)obj;
            if (casted < minValue || casted > maxValue)
            {
                return false;
            }

            return true;
        }
    }
}
