using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Save1.Models
{
    public class bal
    {
        public string save(Class1 c)
        {
            dal obj = new dal();
            return obj.save(c);
        }
        public string update(Class1 u)
        {
            dal s = new dal();
            return s.update(u);
        }
        public string delete(Class1 s)
        {
            dal del = new dal();
            return del.delete(s);
        }
    }
}