using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace CryptoResearch.Models
{
    [Table("Currency")]
    public class Currency
    {
        [Key]
        [Column("Id", TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Remote(action: "CurrencyExists", controller: "Currencys")]
        [Column("Name")]
        [Display(Name = "Coin Name")]
        [MaxLength(60)]
        public string Name { get; set; }

        public int Quantity { get; set; }

        [NotMapped]
        public bool Checked { get; set; }
    }
}