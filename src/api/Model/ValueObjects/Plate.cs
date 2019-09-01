using System.Text.RegularExpressions;
using Exceptions;

namespace Model.ValueObjects
{
    public class Plate
    {
        public Plate(string value)
        {
            value = value.ToUpper();
            
            var plateRegex = new Regex(GetPlatePattern());
            var mercosulPlateRegex = new Regex(GetPlateMercosulPattern());

            if (plateRegex.IsMatch(value) || mercosulPlateRegex.IsMatch(value))
                Value = value;
            else
                throw new InvalidPlateException($"A placa {value} é inválida!");
        }

        public string Value { get; private set; }

        private static string GetPlateMercosulPattern()
        {
            return
                "[A-Z]{3}[0-9][A-Z][0-9]{2}";
        }

        private static string GetPlatePattern()
        {
            return
                "^[a-zA-Z]{3}\\-\\d{4}$";
        }

        public override string ToString()
        {
            return Value;
        }
    }
}