﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using CityModelCommon;

namespace CityModel
{
    public class CityModelModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<City>().As<ICity>();
            builder.RegisterType<Residents>().As<IResidents>();
        }
    }
}
