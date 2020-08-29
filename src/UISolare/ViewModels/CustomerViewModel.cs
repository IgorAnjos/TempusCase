using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UI.ViewModels
{
    public class CustomerViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(150, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        [DisplayName("Nome")]
        public string FullName { get; set; }
        
        [DisplayName("CPF")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(11, ErrorMessage = "O campo {0} precisa ter {1} caracteres")]
        public string CPF { get; set; }

        [DisplayName("Data de nascimento")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [DisplayName("Data de cadastro")]
        [ScaffoldColumn(false)]
        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }

        [DisplayName("Renda familiar")]
        public decimal FamilyIncome { get; set; }
    }
}