using SQLite;

namespace MyMobileProjec
{
    public class ExpenditureItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; }

        public decimal Notes { get; set; }

        public bool Done { get; set; }
    }
}


