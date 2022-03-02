﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagement.Data.Data;
using SystemManagement.Data.Entities;

namespace SystemManagement.Service
{
    public class CarService
    {
        private readonly SystemManagementDbContext _context;
        public CarService(SystemManagementDbContext systemManagementSystemDbContext)
        {
            _context = systemManagementSystemDbContext;
        }
        
        public Car GetCarByID(Guid id)
        {
            return _context.Cars.Find(id);
        }
      
    }
}
