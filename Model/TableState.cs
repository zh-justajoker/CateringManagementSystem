using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TableState
    {
        public int State { get; set; }
        public string Title { get; set; }
        public TableState(int srate,string title)
        {
            State = srate;
            Title = title;
        }
    }
}
