using System;
using System.Collections.Generic;
using System.Linq;

namespace UI.ViewModels.Validations
{
    public class ValidationsCPF
    {
        public const int LengthCpf = 11;

        public static bool ValidateCpf(string cpf)
        {
            var _cpf = Utils.Number(cpf);
            if (!Lengthvalid(_cpf)) return false;
            return !HasRepeatedDigits(_cpf) && HasValidDigits(_cpf);
        }

        private static bool Lengthvalid(string value)
        {
            return value.Length == LengthCpf;
        }

        private static bool HasRepeatedDigits(string value)
        {
            string[] invalidNumbers =
            {
                "00000000000",
                "11111111111",
                "22222222222",
                "33333333333",
                "44444444444",
                "55555555555",
                "66666666666",
                "77777777777",
                "88888888888",
                "99999999999"
            };
            return invalidNumbers.Contains(value);
        }
        private static bool HasValidDigits(string value)
        {
            var number = value.Substring(0, LengthCpf - 2);

            var verifyingDigit = new VerifyingDigit(number)
                .WithUntilMultipliers(2, 11)
                .Replacing("0", 10, 11);

            var firstDigit = verifyingDigit.CalculatesDigit();
            verifyingDigit.AddDigit(firstDigit);

            var secondDigit = verifyingDigit.CalculatesDigit();

            return string.Concat(firstDigit, secondDigit) == value.Substring(LengthCpf - 2, 2);
        }
    }

    public class VerifyingDigit
    {
        private string _number;
        private const int Module = 11;
        private readonly List<int> _multipliers = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9 };
        private readonly IDictionary<int, string> _replacing = new Dictionary<int, string>();
        private bool _complementaryModule = true;

        public VerifyingDigit(string numeric)
        {
            _number = numeric;
        }

        public VerifyingDigit WithUntilMultipliers(int firstMultiplier, int lastMultiplier)
        {
            _multipliers.Clear();
            for (var i = firstMultiplier; i <= lastMultiplier; i++)
                _multipliers.Add(i);

            return this;
        }

        public VerifyingDigit Replacing(string substitute, params int[] digits)
        {
            foreach (var i in digits)
            {
                _replacing[i] = substitute;
            }
            return this;
        }

        public void AddDigit(string digit)
        {
            _number = string.Concat(_number, digit);
        }

        public string CalculatesDigit()
        {
            return !(_number.Length > 0) ? "" : GetDigitSum();
        }

        private string GetDigitSum()
        {
            var sum = 0;
            for (int i = _number.Length - 1, m = 0; i >= 0; i--)
            {
                var produt = (int)char.GetNumericValue(_number[i]) * _multipliers[m];
                sum += produt;

                if (++m >= _multipliers.Count) m = 0;
            }

            var mod = (sum % Module);
            var result = _complementaryModule ? Module - mod : mod;

            return _replacing.ContainsKey(result) ? _replacing[result] : result.ToString();
        }
    }

    public class Utils
    {
        public static string Number(string value)
        {
            var onlyNumber = "";
            foreach (var s in value)
            {
                if (char.IsDigit(s))
                {
                    onlyNumber += s;
                }
            }
            return onlyNumber.Trim();
        }
    }
}