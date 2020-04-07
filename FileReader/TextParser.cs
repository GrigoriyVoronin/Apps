using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileReader
{
    public static class TextParser
    {
        public static List<Computer> CreateData (string fileName)
        {
            var strData = File.ReadAllLines(fileName,Encoding.GetEncoding(1251));
            var computerData = new List<Computer>();
            foreach(var str in strData)
            {
                if (str.StartsWith("#"))
                    continue;
                var computerInfo = str.Split(new[] { "\t" }, StringSplitOptions.None);
                computerData.Add(new Computer(
                    computerInfo[0], computerInfo[1], computerInfo[2], computerInfo[3],
                    computerInfo[4], computerInfo[5], computerInfo[6], computerInfo[7],
                    computerInfo[8], computerInfo[9], computerInfo[10]));

            }
            return computerData;
        }
    }
}
