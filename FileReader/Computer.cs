using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReader
{
    public class Computer
    {
        public string Model { get; }

        public string RAM { get; }

        public string HDD { get; }

        public string Video { get; }

        public string CD_ROM {get;}

        public string Sound { get; }

        public string Notes { get; }

        public string Price { get; }

        public string Firm { get; }

        public string Telephone { get; }

        public string MetroStation { get; }

        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}\t{9}\t{10}",
                Model,RAM,HDD,Video,CD_ROM,Sound,Notes,Price,Firm,Telephone,MetroStation);
        }

        public Computer (string model, string ram, string hdd,string video,string cd_rom,string sound,
            string notes, string price,string firm, string telephone, string metroStation)
        {
            Model = model;
            RAM = ram;
            HDD = hdd;
            Video = video;
            CD_ROM = cd_rom;
            Sound = sound;
            Notes = notes;
            Price = price;
            Firm = firm;
            Telephone = telephone;
            MetroStation = metroStation;
        }
    }
}
