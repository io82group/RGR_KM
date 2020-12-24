using System;
using System.Collections.Generic;
using System.Text;

namespace Components
{
    class Generator: IDecrease
    {
        double minTime, maxTime, range;
        private readonly double probaility;
        Random random = new Random();
        public int GeneratedRequests { get; private set; }

        private double? remainingTime = null;

        public double? RemainingTime { get => remainingTime; set => remainingTime = value; }

        public void Decrease(double timeStep)
        {
            remainingTime -= timeStep;
        }

        public Generator(double minTime, double maxTime, double probaility)
        {
            this.minTime = minTime;
            this.maxTime = maxTime;
            range = maxTime - minTime + 1;
            this.probaility = probaility;
            GeneratedRequests = 0;
        }

        public bool ifLeft()
        {
            if (random.NextDouble() > probaility)
                return false;
            return true;
        }

        public void GenerateRequest()
        {
            RemainingTime = random.NextDouble() * range + minTime;
            GeneratedRequests++;
        }
    }
}
