﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SensorApi.Infrastructure.Handler
{
    public interface IHandler<T>
    {
        Task Handle(T command);
    }
}
