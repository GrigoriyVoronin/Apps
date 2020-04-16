using System.IO;

namespace MARSH
{
    public class FileWorker
    {
        public string[] ReadData(string path)
        {
            string[] data;
            try
            {
                data = File.ReadAllLines(path);
            }
            catch
            {
                data = null;
            }

            return data;
        }

        public bool WriteData(string path, string[] data)
        {
            bool isSuccess;
            try
            {
                File.WriteAllLines(path, data);
                isSuccess = true;
            }
            catch
            {
                isSuccess = false;
            }

            return isSuccess;
        }
    }
}
