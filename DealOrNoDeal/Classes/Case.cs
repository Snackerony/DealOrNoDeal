using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealOrNoDeal.Classes
{
    public class Case
    {
        public bool IsOpen { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        private string _moneyReadable;
        public string MoneyReadable { get { return _moneyReadable; } }
        private int _money;
        public int Money { 
            get {
                return _money;
            }
            set {
                _money = value;
                _moneyReadable = value.ToString() + "€";
            } 
        }
        public bool IsSelected { get; set; }
        public int Counter { get; set; }
    }
}
