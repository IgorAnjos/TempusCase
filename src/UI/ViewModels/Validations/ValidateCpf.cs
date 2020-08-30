using System.Collections.Generic;
using System.Linq;

namespace UI.ViewModels.Validations
{
    public class Validations
    {
        public static bool VerificationCpf(string cpf)
        {
            return ValidationsCPF.ValidateCpf(cpf);
        }
    }
}
