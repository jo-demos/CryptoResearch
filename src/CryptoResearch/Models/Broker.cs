using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CryptoResearch.Validations;

namespace CryptoResearch.Models
{
    [Table("Broker")]
    public class Broker
    {
        [Key]
        [Column("Id", TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("Name")]
        [MaxLength(60)]
        public string Name { get; set; }

        [NotNewBrokersAccepted]
        [Column("Foundation")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyy}")]
        public DateTime Foundation { get; set; }
    }
}