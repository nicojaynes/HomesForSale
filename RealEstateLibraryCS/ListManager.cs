using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealEstateLibraryCS
{
    [Serializable]
    public class ListManager<T> : IListManager<T>
    {
        private List<T> list;

        public ListManager()
        {
            list = new List<T>();
        }

        public int Count => list.Count;

        public bool Add(T aType)
        {
            try
            {
                list.Add(aType);
            } catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public bool BinaryDeSerialize(string fileName)
        {
            list = Serializer.BinaryFileDeSerialize<List<T>>(fileName);
            return true;
        }

        public bool BinarySerialize(string fileName)
        {
            Serializer.BinaryFileSerialize(list, fileName);
            return true;
        }

        public bool ChangeAt(T aType, int anIndex)
        {
            try
            {
                list.RemoveAt(anIndex);
                list.Insert(anIndex, aType);
            } catch (Exception e)
            {
               MessageBox.Show(e.Message);
            }
            return true;
        }

        public bool CheckIndex(int index)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            list.Clear();
        }

        public bool DeleteAt(int anIndex)
        {
            try
            {
                list.RemoveAt(anIndex);
            } catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public T GetAt(int anIndex)
        {
            try
            {
                return list[anIndex];
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return list[anIndex];
        }

        public string[] ToStringArray()
        {
            string[] array = new string[Count];
            for (int i = 0; i < Count; i++)
            {
                array[i] = list[i].ToString();
            }
            return array;
        }

        public List<string> ToStringList()
        {
            List<string> stringList = new List<string>();
            for (int i = 0; i < Count; i++)
            {
                stringList.Add(list[i].ToString());
            }
            return stringList;
        }

        public bool XMLSerialize(string fileName)
        {
            throw new NotImplementedException();
        }
    }
}
