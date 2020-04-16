namespace FileReader
{
    public class Computer
    {
        public string Model { get; }

        public string Ram { get; }

        public string Hdd { get; }

        public string Video { get; }

        public string CdRom {get;}

        public string Sound { get; }

        public string Notes { get; }

        public string Price { get; }

        public string Firm { get; }

        public string Telephone { get; }

        public string MetroStation { get; }

        public override string ToString() =>
            $"{Model}\t{Ram}\t{Hdd}\t{Video}\t{CdRom}\t{Sound}\t{Notes}\t{Price}\t{Firm}\t{Telephone}\t{MetroStation}";

        public Computer(string model, string ram, string hdd, string video, string cdRom, string sound,
            string notes, string price,string firm, string telephone, string metroStation)
        {
            Model = model;
            Ram = ram;
            Hdd = hdd;
            Video = video;
            CdRom = cdRom;
            Sound = sound;
            Notes = notes;
            Price = price;
            Firm = firm;
            Telephone = telephone;
            MetroStation = metroStation;
        }
    }
}
