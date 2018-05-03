using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entities
{
    public class Package : BasicEntity
    {
        public State State { get; set; }

        public string Time { get; set; }
    }
}
