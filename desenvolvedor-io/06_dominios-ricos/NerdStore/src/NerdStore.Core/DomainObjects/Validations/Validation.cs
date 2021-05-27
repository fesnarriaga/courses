using NerdStore.Core.DomainObjects.Exceptions;
using System.Text.RegularExpressions;

namespace NerdStore.Core.DomainObjects.Validations
{
    public class Validation
    {
        public static void Equal(object object1, object object2, string message)
        {
            if (!object1.Equals(object2))
                throw new DomainException(message);
        }

        public static void NotEqual(object object1, object object2, string message)
        {
            if (object1.Equals(object2))
                throw new DomainException(message);
        }

        public static void NotMatches(string pattern, string value, string message)
        {
            var regex = new Regex(pattern);

            if (!regex.IsMatch(value))
                throw new DomainException(message);
        }

        public static void Length(string value, int maximum, string message)
        {
            var length = value.Trim().Length;

            if (length > maximum)
                throw new DomainException(message);
        }

        public static void Length(string value, int minimum, int maximum, string message)
        {
            var length = value.Trim().Length;

            if (length < minimum || length > maximum)
                throw new DomainException(message);
        }

        public static void NotEmpty(string value, string message)
        {
            if (value == null || value.Trim().Length == 0)
                throw new DomainException(message);
        }

        public static void NotNull(string value, string message)
        {
            if (value == null)
                throw new DomainException(message);
        }

        public static void Range(double value, double minimum, double maximum, string message)
        {
            if (value < minimum || value > maximum)
                throw new DomainException(message);
        }

        public static void Range(float value, float minimum, float maximum, string message)
        {
            if (value < minimum || value > maximum)
                throw new DomainException(message);
        }

        public static void Range(long value, long minimum, long maximum, string message)
        {
            if (value < minimum || value > maximum)
                throw new DomainException(message);
        }

        public static void Range(int value, int minimum, int maximum, string message)
        {
            if (value < minimum || value > maximum)
                throw new DomainException(message);
        }

        public static void Range(decimal value, decimal minimum, decimal maximum, string message)
        {
            if (value < minimum || value > maximum)
                throw new DomainException(message);
        }

        public static void GreaterThan(double value, double minimum, string message)
        {
            if (value < minimum)
                throw new DomainException(message);
        }

        public static void GreaterThan(float value, float minimum, string message)
        {
            if (value < minimum)
                throw new DomainException(message);
        }

        public static void GreaterThan(long value, long minimum, string message)
        {
            if (value < minimum)
                throw new DomainException(message);
        }

        public static void GreaterThan(int value, int minimum, string message)
        {
            if (value < minimum)
                throw new DomainException(message);
        }

        public static void GreaterThan(decimal value, decimal minimum, string message)
        {
            if (value < minimum)
                throw new DomainException(message);
        }

        public static void False(bool value, string message)
        {
            if (value)
                throw new DomainException(message);
        }

        public static void True(bool value, string message)
        {
            if (!value)
                throw new DomainException(message);
        }
    }
}
