using LogBook.Lib;

Console.WriteLine("Wilkommen beim Fahrtenbuch");

Irepository repository = new MemoryRepository("logbook.xml");
List<Entry> entries = repository.GetAll();

foreach (Entry entry in entries )
{
    Console.WriteLine(entry.From);
}