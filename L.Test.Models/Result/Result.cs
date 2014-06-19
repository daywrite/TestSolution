using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.Test.Models
{
    public class Result<TEntity>
    {
        public string State { get; set; }
        public string Msg { get; set; }
        public TEntity Content { get; set; }
    }
}
