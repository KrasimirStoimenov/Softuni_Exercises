using System;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {

            var type = typeof(Person);
            var properties = type.GetProperties();

            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes(false);
                foreach (MyValidationAttribute attribute in attributes)
                {
                    if (!attribute.IsValid(property.GetValue(obj)))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
