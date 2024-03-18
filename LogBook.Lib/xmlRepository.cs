using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LogBook.Lib;

public class xmlRepository : Irepository
{
    XElement _rootElement;

    private string _path;

    public xmlRepository(string path)
    {
        _path = path;
        if (File.Exists(path))
        {
            _rootElement = XElement.Load(path);
        }
        else
        {
            _rootElement = new XElement("root");
        }
    }

    public bool Add(Entry entry)
    {
        XElement node = new XElement("entry");

        var idAtrib = new XAttribute("id", entry.ID.ToString());
        node.Add(idAtrib);

        var startAtrib = new XAttribute("start", entry.Start.ToString());
        node.Add(startAtrib);

        var endAtrib = new XAttribute("end", entry.End.ToString());
        node.Add(endAtrib);

        var startkmAtrib = new XAttribute("startkm", entry.StartKM.ToString());
        node.Add(startkmAtrib);

        var endkmAtrib = new XAttribute("endkm", entry.EndKM.ToString());
        node.Add(endkmAtrib);

        var numberplateAtrib = new XAttribute("numberplate", entry.NumberPlate.ToString());
        node.Add(numberplateAtrib);

        var fromAtrib = new XAttribute("from", entry.From.ToString());
        node.Add(fromAtrib);

        var toAtrib = new XAttribute("to", entry.To.ToString());
        node.Add(toAtrib);

        node.Add(entry.Description.ToString());

        _rootElement.Add(node);

        return this.Save();

    }

    public bool Delete(Entry entry)
    {
        var itemsDel = from i in _rootElement.Descendants("entry")
                       where (string)i.Attribute("id") == entry.ID
                       select i;
        itemsDel.Remove();
        return this.Save();
    }

    public Entry? Find(string id)
    {
        var item = (from entry in _rootElement.Descendants("entry")
                    where (string)entry.Attribute("id") == id
                    select new Entry(
                        Convert.ToDateTime(entry.Attribute("start").Value),
                          Convert.ToDateTime(entry.Attribute("end").Value),
                          (int)entry.Attribute("startkm"),
                          (int)entry.Attribute("endkm"),
                          entry.Attribute("numberplate").Value,
                          entry.Attribute("from").Value,
                          entry.Attribute("to").Value,
                          entry.Attribute("id").Value
                        )
                    {
                        Description = entry.Value
                    }
                    ).FirstOrDefault();


        return item;
    }

    public List<Entry> GetAll()
    {
        var entries = from entry in this._rootElement.Descendants("entry")
                      select new Entry(
                          Convert.ToDateTime(entry.Attribute("start").Value),
                          Convert.ToDateTime(entry.Attribute("end").Value),
                          (int)entry.Attribute("startkm"),
                          (int)entry.Attribute("endkm"),
                          entry.Attribute("numberplate").Value,
                          entry.Attribute("from").Value,
                          entry.Attribute("to").Value,
                          entry.Attribute("id").Value
                          )
                      {
                          Description = entry.Value
                      };
        // TODO
        // Objekt Entry erstellen
        // Liste zurückgeben
        //return entries;
        //throw new NotImplementedException();
        return entries.ToList<Entry>();
    }

    public bool Save()
    {
        try
        {
            _rootElement.Save(_path);
            return true;
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public bool Update(Entry entry)
    {
        var item = (from e in _rootElement.Descendants("entry")
                    where (string)e.Attribute("id") == entry.ID
                    select e).FirstOrDefault();

        if (item != null)
        {
            item.SetAttributeValue("start", entry.Start.ToString());
            item.SetAttributeValue("end", entry.End.ToString());
            item.SetAttributeValue("startkm", entry.StartKM.ToString());
            item.SetAttributeValue("endkm", entry.EndKM.ToString());
            item.SetAttributeValue("numberplate", entry.NumberPlate.ToString());
            item.SetAttributeValue("to", entry.To.ToString());
            item.SetAttributeValue("from", entry.From.ToString());

            // id nicht, da sonst das Elemtn nicht mehr gefunden wird

            return this.Save();
        }
        else
        {
            return false;
        }
    }

    
}
