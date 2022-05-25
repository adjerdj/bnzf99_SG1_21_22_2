using BNZF99_SG1_21_22_2.Models.Enums;
using System;

namespace BNZF99_SG1_21_22_2.Models.DTOs
{
    public class ArtistDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Born { get; set; }
        public string RecordLabel { get; set; }
        public Instruments Instrument { get; set; }
        public bool IsOnRehab { get; set; }
        public DateTime EndOfContract { get; set; }
    }
}
