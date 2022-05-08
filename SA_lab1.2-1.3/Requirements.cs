using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA_lab1._2_1._3
{
    sealed class Requirements
    {
        private int hddUsage, ramUsage;
        private float graphCardUsage, processorUsage;

        private static Requirements _instance;

        private Requirements()
        {
            this.hddUsage = 50;
            this.ramUsage = 2;
            this.graphCardUsage = 1.2f;
            this.processorUsage = 1.6f;
        }

        private Requirements(int hddUsage, int ramUsage, float graphCardUsage, float processorUsage)
        {
            this.hddUsage = hddUsage;
            this.ramUsage = ramUsage;
            this.graphCardUsage = graphCardUsage;
            this.processorUsage = processorUsage;
        }

        public static Requirements GetInstance()
        {
            _instance = new Requirements();
            return _instance;
        }

        public static Requirements GetInstance(int hddUsage, int ramUsage, float graphCardUsage, float processorUsage)
        {
            _instance = new Requirements(hddUsage, ramUsage, graphCardUsage, processorUsage);
            return _instance;
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
