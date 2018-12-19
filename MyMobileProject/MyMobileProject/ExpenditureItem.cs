using SQLite;
using System;

namespace MyMobileProjec
{
    public class ExpenditureItem
    {
        [PrimaryKey, AutoIncrement]

        public int ID { get; set; }

        public string Name { get; set; }

        public double Notes { get; set; }

        public bool Done { get; set; }

        public string FormattedPrice
        {
            get
            {
                return "$ " + Math.Round(Notes, 2).ToString("#.00");
            }
        }

    }
}


