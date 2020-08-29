using System;

namespace BusinessTempus.Models
{
    public class Customer : Entity
    {
        public string FullName { get; set; }
        public string Cpf { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal FamilyIncome  { get; set; }
    }
}