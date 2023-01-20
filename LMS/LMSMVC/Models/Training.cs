using System;
using System.Collections.Generic;

#nullable disable

namespace LMSMVC.Models
{
    public partial class Training
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public string Descriptions { get; set; }
        public string Faculty { get; set; }
        public string Location { get; set; }
    }
}
