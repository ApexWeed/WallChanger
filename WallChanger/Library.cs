using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WallChanger
{
    public static class Library
    {
        public static void Save()
        {
            using (FileStream stream = File.Open(GlobalVars.ApplicationPath + "\\library.cfg", FileMode.Create))
            {
                using (StreamWriter write = new StreamWriter(stream))
                {
                    write.Write(Newtonsoft.Json.JsonConvert.SerializeObject(GlobalVars.LibraryItems));
                }
            }
            using (FileStream stream = File.Open(GlobalVars.ApplicationPath + "\\sizecache.cfg", FileMode.Create))
            {
                using (StreamWriter write = new StreamWriter(stream))
                {
                    write.Write(Newtonsoft.Json.JsonConvert.SerializeObject(GlobalVars.ImageSizeCache));
                }
            }
        }

        public static void Load()
        {
            GlobalVars.LibraryItems = new List<LibraryItem>();

            if (File.Exists(GlobalVars.ApplicationPath + "\\library.cfg"))
            {
                using (StreamReader read = new StreamReader(GlobalVars.ApplicationPath + "\\library.cfg"))
                {
                    GlobalVars.LibraryItems = Newtonsoft.Json.JsonConvert.DeserializeObject<List<LibraryItem>>(read.ReadLine());
                }
            }

            GlobalVars.ImageSizeCache = new Dictionary<string, System.Drawing.Size>();

            if (File.Exists(GlobalVars.ApplicationPath + "\\sizecache.cfg"))
            {
                using (StreamReader read = new StreamReader(GlobalVars.ApplicationPath + "\\sizecache.cfg"))
                {
                    GlobalVars.ImageSizeCache = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, System.Drawing.Size>>(read.ReadLine());
                }
            }

            if (GlobalVars.LibraryForm != null)
            {
                GlobalVars.LibraryForm.UpdateList();
            }
        }
    }
}
