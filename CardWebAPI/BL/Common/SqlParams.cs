using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CardWebAPI.BL.Common
{
    public class SqlParams
    {
        public string name { get; set; }
        public string value { get; set; }
        public SqlDbType type { get; set; }

        public SqlParams(string name, string value, SqlDbType type)
        {
            this.name = name;
            this.value = value;
            this.type = type;
        }
    }
}
