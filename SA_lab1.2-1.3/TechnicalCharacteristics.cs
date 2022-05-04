using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SA_lab1._2_1._3
{
    class TechnicalCharacteristics
    {
        private int hddCapacity, hddUsage, ramCapacity;
        private float graphCardSpeed, processorSpeed;

        public TechnicalCharacteristics()
        {
            this.hddCapacity = 500;
            this.hddUsage = 0;
            this.ramCapacity = 4;
            this.graphCardSpeed = 1.6f;
            this.processorSpeed = 2.4f;
        }

        public TechnicalCharacteristics(int hddCapacity, int hddUsage, int ramCapacity, float graphCardSpeed, float processorSpeed)
        {
            this.hddCapacity = hddCapacity;
            this.hddUsage = hddUsage;
            this.ramCapacity = ramCapacity;
            this.graphCardSpeed = graphCardSpeed;
            this.processorSpeed = processorSpeed;
        }

        public int HDDCapacity
        {
            get
            {
                return hddCapacity;
            }
        }

        public int HDDUsage
        {
            set
            {
                this.hddUsage = value;
            }

            get
            {
                return hddUsage;
            }
        }

        public int RAMCapacity
        {
            get
            {
                return ramCapacity;
            }
        }

        public float GraphCardSpeed
        {
            get
            {
                return graphCardSpeed;
            }
        }

        public float ProcessorSpeed
        {
            get
            {
                return processorSpeed;
            }
        }

    }
}
