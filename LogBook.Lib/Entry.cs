namespace LogBook.Lib
{
    /// <summary>
    /// Creates an entry for the log book
    /// </summary>
    public class Entry
    {
        public string Description { get; set; } = string.Empty;

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public int StartKM { get; set; }

        public int EndKM { get; set; }

        public string NumberPlate { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        /// <summary>
        /// Id of an entry
        /// </summary>
        public string ID { get; set; }

        public Entry(DateTime start, DateTime end, int startkm, int endkm, string numberplate, string from, string to, string id)
        {
            this.ID = id;
            this.Start = start;
            this.End = end;
            this.StartKM = startkm;
            this.EndKM = endkm;
            this.NumberPlate = numberplate;
            this.From = from;
            this.To = to;
        }
        public Entry( DateTime start, DateTime end, int startkm, int endkm, string numberplate, string from, string to)
        {
            this.ID = Guid.NewGuid().ToString();
            this.Start = start;
            this.End = end;
            this.StartKM = startkm;
            this.EndKM = endkm;
            this.NumberPlate = numberplate;
            this.From = from;
            this.To = to;
        }
    }
}