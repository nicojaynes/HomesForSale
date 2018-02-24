using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace RealEstateLibraryCS
{
    public class Serializer
    {
        public static void BinaryFileSerialize(Object obj, string filePath)
        {
            try
            {
                using (Stream stream = File.Open(filePath, FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, obj);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static T BinaryFileDeSerialize<T>(string filePath)
        {
            Object obj = null;
            try
            {
                using (Stream stream = File.Open(filePath, FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    obj = bin.Deserialize(stream);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return (T)obj;
        }
    }
}
