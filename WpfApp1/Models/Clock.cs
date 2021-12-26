using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WpfApp1
{
    public class Clock
    {
        public DateTime dateTime 
        {
            get { return DateTime.Now; }
            private set { } //  Convert.ToString(dateTime.Now);
        }
        public string hour
        {
            get { return Convert.ToString( dateTime.Hour); }
        }
        public string minute
        { get { return Convert.ToString(dateTime.Minute); } }
        public string seconds
        { get { return Convert.ToString(dateTime.Second); } }
        public Clock()
        {
            dateTime = DateTime.Now;
        }
    }
}
