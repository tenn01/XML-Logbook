using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LogBook.Lib
{
    public class xmlRepository : Irepository
    {
        XElement _root;
        

        public bool Add(Entry entry)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Entry entry)
        {
            throw new NotImplementedException();
        }

        public List<Entry> GetAll()
        {
            var entries = from entry in _root.Descendants("entry")
                          select entry;
            // TODO 
            // - Objekt erstellen
            // - Liste zurückgeben
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(Entry entry)
        {
            throw new NotImplementedException();
        }

        public xmlRepository(string path)
        {
         if (File.Exists(path))
            {
                _root = XElement.Load(path);
            }
         else
            {
                _root = new XElement("root");
            }
        }
    }
}
