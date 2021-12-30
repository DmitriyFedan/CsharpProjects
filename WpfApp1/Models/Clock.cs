using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WpfApp1
{
    public class Clock
    {
        public DateTime DateTime 
        {
            get { return DateTime.Now; }
            private set { } //  Convert.ToString(dateTime.Now);
        }
        public string Hour
        {
            get { return Convert.ToString( DateTime.Hour); }
        }
        public string Minute
        { get { return Convert.ToString(DateTime.Minute); } }
        public string Seconds
        { get { return Convert.ToString(DateTime.Second); } }
        public Clock()
        {
            DateTime = DateTime.Now;
        }
    }
}
