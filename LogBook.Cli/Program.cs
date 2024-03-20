using LogBook.Lib;

Console.WriteLine("Wilkommen beim Fahrtenbuch");

string path = "logbook.xml";

Irepository repository = new xmlRepository(path);

repository.Add(new Entry(DateTime.Now,DateTime.Now.AddHours(2).AddMinutes(22), 25000,25180,"ZE-XY123", "Zell am See", "München", false));

Entry entrySaalfelden = new Entry(DateTime.Now.AddDays(2), DateTime.Now.AddDays(2).AddMinutes(20), 25500, 25514, "ZE-XY123", "Zell am See", "Saalfelden", false) 
{ 
    Description = "Fahrt nach Saalfelden"
};



repository.Add(entrySaalfelden);



List<Entry> entries = repository.GetAll();

foreach (Entry entry in entries )
{
    Console.WriteLine(entry.From);
}