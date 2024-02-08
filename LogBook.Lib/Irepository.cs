using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogBook.Lib;

public interface Irepository
{
    bool Add(Entry entry);

    bool Delete(Entry entry);

    bool Update(Entry entry);

    bool Save();
    /// <summary>
    /// Search for an Entry
    /// </summary>
    /// <param name="id">the id to search</param>
    /// <returns></returns>

    Entry Find(string id);

    List<Entry> GetAll();
}

