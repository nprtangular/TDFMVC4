﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDFMVC4.Common.Models;

namespace TDFMVC4.DALC.Mapping
{
    public class AsignarTableMapping : EntityTypeConfiguration<AsignarTable >
    {
        public AsignarTableMapping()
        {
            ToTable("AsignarTables");
        }
    }
}