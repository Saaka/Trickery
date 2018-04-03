﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Trickery.Configuration;

namespace Trickery.DAL.Store
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(GetConnectionString(),
                opt =>
                {
                    opt.MigrationsHistoryTable("MHWCompanionMigrations");
                });

            return new AppDbContext(optionsBuilder.Options);
        }

        private string GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false)
                .AddJsonFile("appsettings.Development.json", true);


            var config = builder.Build();
            return config[ConfigurationProperties.DbSettings.ConnectionString].ToString();
        }
    }
}
