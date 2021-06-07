using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storm.Base.Helpers
{

    public class FileLogger
    {
        public static string _filePath = Environment.CurrentDirectory + @"\log.txt";

        public static void Log(string str)
        {
            if (File.Exists(_filePath))
            {
                string texts = File.ReadAllText(_filePath);
                var usernames = texts.Split(';');
                if (!usernames.Any(x => x == Convert.ToBase64String(Encoding.UTF8.GetBytes(str))))
                {
                    using (StreamWriter sw = File.AppendText(_filePath))
                    {
                        sw.Write(Convert.ToBase64String(Encoding.UTF8.GetBytes(str)) + ";");
                        sw.Close();
                    }
                }
                return;
            }
            using (StreamWriter streamWriter = new StreamWriter(_filePath))
            {
                streamWriter.Write(Convert.ToBase64String(Encoding.UTF8.GetBytes(str)) + ";");
                streamWriter.Close();
            }
        }

        public static string[] UserLogged()
        {
            List<string> names = new List<string>();

            if (!File.Exists(_filePath))
            {
                return null;
            }
            string text = File.ReadAllText(_filePath);
            var usernames = text.Split(';');
            if(!usernames.Any())
            {
                return null;
            }
            foreach (var uname in usernames)
            {
                byte[] data = Convert.FromBase64String(uname);
                names.Add(Encoding.UTF8.GetString(data));
            }

            return names.ToArray();
        }
    }

}
