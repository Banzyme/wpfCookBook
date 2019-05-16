using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCookBook.Common
{
    public class WpfCookBookUtils
    {
        public static void RemoveEntryFromCollection<T>(ObservableCollection<T> collection, Func<T, bool> condition)
        {
            try
            {
                collection.Remove(collection.Where(condition).Single());
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
