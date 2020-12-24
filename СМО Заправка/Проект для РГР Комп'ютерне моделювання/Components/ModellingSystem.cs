using System;
using System.Collections.Generic;
using System.Text;

namespace Components
{
    public class ModellingSystem
    {
        private readonly double timeStep;
        Queue q1, q2, q3, q4, q5;
        Processor s1, s2, s3, s4, s5, s6, oper;
        Generator generator;
        IDecrease[] components;
        Processor[] processors;
        int generatedLeft = 0, generatedRight = 0;
        int processedRequests = 0;
        int refuesedRequests = 0;
        double modellingTime = 0;

        public ModellingSystem(
            double genMinTime, double genMaxTime, double genProbability,
            int qProcessor,
            double sMin, double sMax, double operMin, double operMax,
            double timeStep)
        {
            generator = new Generator(genMinTime, genMaxTime, genProbability);
            q1 = new Queue(qProcessor);
            q2 = new Queue(qProcessor);
            q3 = new Queue(qProcessor);
            q4 = new Queue(qProcessor);

            s1 = new Processor(sMin, sMax, q1);
            s2 = new Processor(sMin, sMax, q2);
            s3 = new Processor(sMin, sMax, q3);
            s4 = new Processor(sMin, sMax, q4);
            processors = new Processor[] { s1, s2, s3, s4 };

            q5 = new Queue();
            oper = new Processor(operMin, operMax, q5);

            components = new IDecrease[] {
                s1, s2, s3, s4, oper,
                generator
            };
            this.timeStep = timeStep;
        }

        private void getLeftOperator()
        {
            bool res = false;

            if (q1.Count <= q2.Count)
                res = q1.Push();
            else
                res = q2.Push();

            if (res == false)
                refuesedRequests++;
        }

        private void getRightOperator()
        {
            bool res = false;

            if (q3.Count <= q4.Count)
                res = q3.Push();
            else
                res = q4.Push();

            if (res == false)
                refuesedRequests++;
        }

        public Report Modelling(int modellingRequestsAmount)
        {
            while (processedRequests < modellingRequestsAmount)
            {
                modellingTime += timeStep;
                foreach (IDecrease component in components)
                {
                    if (component.RemainingTime != null)
                        component.Decrease(timeStep);
                }
                if (generator.RemainingTime == null || generator.RemainingTime <= 0)
                {
                    generator.GenerateRequest();
                    if (generator.ifLeft())
                    {
                        getLeftOperator();
                        generatedLeft += 1;
                    }
                    else
                    {
                        getRightOperator();
                        generatedRight += 1;
                    }
                }
                foreach (Processor processor in processors)
                {
                    if (processor.RemainingTime == null)
                    {
                        processor.StartProcessing();
                    }
                    else if (processor.RemainingTime <= 0)
                    {
                        processor.EndProcessing();
                        q5.Count++;
                    }
                }
                if (oper.RemainingTime == null)
                {
                    oper.StartProcessing();
                }
                else if (oper.RemainingTime <= 0)
                {
                    oper.EndProcessing();
                    processedRequests++;
                }
            }
            return new Report(generator.GeneratedRequests, generatedLeft, generatedRight,
                processedRequests, refuesedRequests, modellingTime);
        }
    }
}
