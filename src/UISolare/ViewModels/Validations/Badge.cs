using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.ViewModels.Validations
{
    public class Badge
    {

        /// <summary>
        /// Exibir o campo 'Expira em' de acordo com a regra de dias e horas ('2 dias || -1 dia || 01:15:20 || -23:45:01') 
        /// </summary>
        /// <param name="_expiresOn">Dado do tipo DateTime</param>
        /// <exception cref="Util.GenerateErrorLog">description</exception>
        public static string CalculateFamilyIncome(decimal familyIncome)
        {
            string result = string.Empty;
            string teste = familyIncome.ToString();
            try
            {
                if (string.IsNullOrWhiteSpace(teste))
                    return result = string.Empty;


                var teste2 = teste.Split(",");


                result = String.Format($"R$ {teste2[0].ToString()}");
            }
            catch (Exception err)
            {
                throw new Exception($"{0}", err);
            }
            return result;
        }
    }
}