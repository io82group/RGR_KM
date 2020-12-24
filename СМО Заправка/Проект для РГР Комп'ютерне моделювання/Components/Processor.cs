using System;
using System.Collections.Generic;
using System.Text;

namespace Components
{
    public class Processor : IDecrease
    {
        Random random = new Random();
        double maxTime, minTime, range;
        Queue queue;
        int processedRequests = 0;

        private double? remainingTime = null;

        public double? RemainingTime { get => remainingTime; set => remainingTime = value; }

        public void Decrease(double timeStep)
        {
            remainingTime -= timeStep;
        }

        public Processor(double maxTime, double minTime, Queue queue)
        {
            this.maxTime = maxTime;
            this.minTime = minTime;
            range = maxTime - minTime + 1;
            this.queue = queue;
        }

        private void GenerateDelay()
        {
            RemainingTime = random.NextDouble() * range + minTime;
        }

        public void StartProcessing()
        {
            if (queue.Pop())
            {
                GenerateDelay();
            }
        }

        public void EndProcessing()
        {
            processedRequests++;
            RemainingTime = null;
        }
    }
}
