using System;
using System.Collections.Generic;
using System.Text;

namespace Components
{
    public class Queue
    {
        public int Count { get; set; }
        private int length;
        public int RefusedRequests { get; set; }
        public int AddedRequests { get; set; }

        public Queue(int length = -1)
        {
            Count = 0;
            this.length = length;
        }

        public bool Push()
        {
            if (length < 0)
                return true;
            if (Count < length)
            {
                AddedRequests++;
                Count++;
                return true;
            }
            else
            {
                RefusedRequests++;
                return false;
            }
        }

        public bool Pop()
        {
            if (Count > 0)
            {
                Count--;
                return true;
            }
            return false;
        }
    }
}
