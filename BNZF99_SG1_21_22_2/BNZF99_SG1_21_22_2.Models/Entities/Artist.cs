using BNZF99_SG1_21_22_2.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BNZF99_SG1_21_22_2.Models.Entities
{
    [Table("Artists")]
    public class Artist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public String Name { get; set; }

        [Required]
        public DateTime Born { get; set; }

        [Required]
        [MaxLength(50)]
        public String RecordLabel { get; set; }

        public Instruments Instrument { get; set; }

        [Required]
        public bool IsOnRehab { get; set; }

        [Required]
        public DateTime EndOfContract { get; set; }

    }
}
