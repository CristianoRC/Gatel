using System;
using System.Text.RegularExpressions;
using Exceptions;

namespace Model.ValueObjects
{
    public class Email
    {
        public Email(string address)
        {
            var emailRegex = new Regex(GetEmailPattern());
            if (emailRegex.IsMatch(address))
                Address = address;
            else
                throw new InvalidEmailException($"O email ${address} não é válido");
        }

        public string Address { get; private set; }

        private static string GetEmailPattern()
        {
            return
                "^(?(\")(\".+?(?<!\\\\)\"@)|(([0-9a-z]((\\.(?!\\.))|[-!#\\$%&'\\*\\+/=\\?\\^`\\{\\}\\|~\\w])*)(?<=[0-9a-z])@))(?(\\[)(\\[(\\d{1,3}\\.){3}\\d{1,3}\\])|(([0-9a-z][-\\w]*[0-9a-z]*\\.)+[a-z0-9][\\-a-z0-9]{0,22}[a-z0-9]))$";
        }

        public override string ToString()
        {
            return Address;
        }
    }
}