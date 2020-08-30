using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.ViewModels.Validations
{
    public class Badge
    {
        public static string CalculateFamilyIncome(decimal familyIncome)
        {
            string result = string.Empty;
            string income = familyIncome.ToString();
            try
            {
                if (string.IsNullOrWhiteSpace(income))
                    return result = string.Empty;


                var _familyIncome = income.Split(",");


                result = String.Format($"R$ {_familyIncome[0].ToString()}");
            }
            catch (Exception err)
            {
                throw new Exception($"Error: Erro no try do cálculo da renda familiar{0}", err);
            }
            return result;
        }
    }
}