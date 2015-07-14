using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mansi_Flowers
{
    
        public class StringValue
        {
            //string _value;
            public StringValue(string s)
            {
                _value = s;
            }
            public string Value
            {
                get
                {
                    return _value;
                }
                set
                {
                    _value = value;
                }
            }
            string _value;
        }
    
}
