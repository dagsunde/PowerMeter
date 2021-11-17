using System;
using System.IO;
using System.Runtime.Serialization;


namespace Power.Models
{
    [Serializable()]
    public class PowerModel
    {
        public int averagePower { get; set; }
        public int power { get; set; }
        public decimal consumption { get; set; }
        public decimal cost { get; set; }

    }
}
