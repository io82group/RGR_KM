using System;

namespace Components
{
    public class Report
    {
        int generated, left, right, processed, refuesed;
        private readonly double time;
        double refuseProbability;

        public Report(int generated, int left, int right, int processed, int refuesed, double time)
        {
            this.generated = generated;
            this.left = left;
            this.right = right;
            this.processed = processed;
            this.refuesed = refuesed;
            this.time = time;
            refuseProbability = (double)refuesed / generated;
        }

        public override string ToString()
        {
            return $"Сгенерировано заявок {generated}\n" +
                $"Левосторонних {left}\n" +
                $"Правосторонних {right}\n" +
                $"Отказов {refuesed}\n" +
                $"Вероятность отказа {String.Format("{0:f3}", refuseProbability)}\n" +
                $"Время моделирования {String.Format("{0:f3}", time)}";
        }
    }
}