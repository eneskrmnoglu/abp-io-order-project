using System;
using System.ComponentModel.DataAnnotations;

namespace OrderProject.Customers
{
    public class CreateUpdateCustomerDto
    {
        [Required]
        [StringLength(256)]
        public string CustomerName { get; set; }

        [Required]
        public decimal RiskLimit { get; set; }

        [Required]
        [StringLength(500)]
        public string BillingAddress { get; set; }

       
    }
}
