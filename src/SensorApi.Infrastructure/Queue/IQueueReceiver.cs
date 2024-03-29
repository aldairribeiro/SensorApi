﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SensorApi.Infrastructure.Queue
{
    public interface IQueueReceiver<T>
    {
        void OnReceiver(Func<T, Task> action);
        void Start();
    }
}
