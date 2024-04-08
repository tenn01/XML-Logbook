using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogBook.Lib;

public class EntryMap : ClassMap<Entry>
{
    public EntryMap()
    {
        Map(m => m.Id).Index(0).Name("id");
        Map(m => m.Start).Index(1).Name("start");
        Map(m => m.End).Index(2).Name("end");
        Map(m => m.StartKM).Index(3).Name("startkm");
        Map(m => m.EndKM).Index(4).Name("endkm");
        Map(m => m.NumberPlate).Index(5).Name("numberplate");
        Map(m => m.From).Index(6).Name("from");
        Map(m => m.To).Index(7).Name("to");
        Map(m => m.Favorite).Index(8).Name("favorite");
        Map(m => m.Description).Index(9).Name("description");
        
        
    }
}
