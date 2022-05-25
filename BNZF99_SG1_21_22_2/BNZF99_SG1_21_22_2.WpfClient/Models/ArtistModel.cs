using BNZF99_SG1_21_22_2.Models.Enums;
using GalaSoft.MvvmLight;
using System;

namespace BNZF99_SG1_21_22_2.WpfClient.Models
{
    public class ArtistModel : ObservableObject
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { Set(ref id, value); }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { Set(ref name, value); }
        }

        private DateTime born;

        public DateTime Born
        {
            get { return born; }
            set { Set(ref born, value); }
        }

        private string recordLabel;

        public string RecordLabel
        {
            get { return recordLabel; }
            set { Set(ref recordLabel, value); }
        }

        private Instruments instrument;

        public Instruments Instrument
        {
            get { return instrument; }
            set { Set(ref instrument, value); }
        }

        private bool isOnRehab;

        public bool IsOnRehab
        {
            get { return isOnRehab; }
            set { Set(ref isOnRehab, value); }
        }

        private DateTime endOfContract;

        public DateTime EndOfContract
        {
            get { return endOfContract; }
            set { Set(ref endOfContract, value); }
        }

        public ArtistModel()
        {
        }

        public ArtistModel(int id, string name, DateTime born, string recordLabel, Instruments instrument, bool isOnRehab, DateTime endOfContract)
        {
            this.id = id;
            this.name = name;
            this.born = born;
            this.recordLabel = recordLabel;
            this.instrument = instrument;
            this.isOnRehab = isOnRehab;
            this.endOfContract = endOfContract;
        }

        public ArtistModel(ArtistModel other)
        {
            this.id = other.id;
            this.name = other.name;
            this.born = other.born;
            this.recordLabel = other.recordLabel;
            this.instrument = other.instrument;
            this.isOnRehab = other.isOnRehab;
            this.endOfContract = other.endOfContract;
        }
    }
}
