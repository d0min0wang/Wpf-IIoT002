using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OPCAutomation;

namespace Wpf_IIoT002
{
    public class OPCChangeModel
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private object value;

        public object Value
        {
            get { return this.value; }
            set { this.value = value; }
        }
        private TagQuality quality;

        public TagQuality Quality
        {
            get { return quality; }
            set { quality = value; }
        }

        private DateTime timeStamp;

        public DateTime TimeStamp
        {
            get { return timeStamp; }
            set { timeStamp = value; }
        }
    }
}
