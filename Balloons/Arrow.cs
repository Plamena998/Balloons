using Balloons.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balloons
{
    public class Arrow : IProperty
    {
        public string Color { get; set; }
        public int Size {  get; set; }
        public Arrow(string color, int size)
        {
            this.Color = color;
            this.Size = size;
        }
    }
}
