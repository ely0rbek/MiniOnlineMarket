﻿using CustomerManagement.Domain.Entities.Models;
using CustomerManagement.Infrastructure.Repositories.BaseRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Infrastructure.Repositories.OrderRepositories
{
    public interface IOrderRepository:IBaseRepository<Order>
    {
    }
}
