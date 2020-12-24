using System;
using System.Collections.Generic;
using System.Text;

namespace Components
{
    interface IDecrease
    {
        double? RemainingTime { get; set; }

        void Decrease(double timeStep);
    }
}
