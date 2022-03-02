﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagement.Data.Entities;

namespace SystemManagement.Data.Data
{
    public partial class SystemManagementDbContext : IdentityDbContext
    {
        public SystemManagementDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<SubModel> SubModels { get; set; }
        public virtual DbSet<Images> Images { get; set; } 

    }
}