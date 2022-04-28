using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arch_lab1._2_1._3
{
    class Requirements
    {
        private int hddUsage, ramUsage;
        private float graphCardUsage, processorUsage;

        public Requirements()
        {
            this.hddUsage = 50;
            this.ramUsage = 2;
            this.graphCardUsage = 1.2f;
            this.processorUsage = 1.6f;
        }

        public Requirements(int hddUsage, int ramUsage, float graphCardUsage, float processorUsage)
        {
            this.hddUsage = hddUsage;
            this.ramUsage = ramUsage;
            this.graphCardUsage = graphCardUsage;
            this.processorUsage = processorUsage;
        }

        public int HDDUsage
        {
            get
            {
                return hddUsage;
            }
        }

        public int RAMUsage
        {
            get
            {
                return ramUsage;
            }
        }

        public float GraphCardUsage
        {
            get
            {
                return graphCardUsage;
            }
        }

        public float ProcessorUsage
        {
            get
            {
                return processorUsage;
            }
        }
    }
}
