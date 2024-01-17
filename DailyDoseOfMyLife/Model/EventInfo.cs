using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyDoseOfMyLife.Model
{
    class EventInfo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string  Name { get; set; }
        public bool isChecked {  get; set; }
        public string userName { get; set; }
        public DateTime Date { get; set; }
    }
}
