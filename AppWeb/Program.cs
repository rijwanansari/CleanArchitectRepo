using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;

namespace UserSelfDesk.AppWeb
{
    public class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
        .Build();


        public static void Main(string[] args)
        {
            //Serilog
           

            //SeriLog with DB
            string connectionString = Configuration.GetConnectionString("UserSelfDeskDatabase");
          
            var columnOptions = new ColumnOptions
            {
                AdditionalColumns = new Collection<SqlColumn>
                {
                    new SqlColumn("UserName", SqlDbType.NVarChar),
                     new SqlColumn("LogEvent", SqlDbType.VarChar)
                    
                }
            };
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.MSSqlServer(connectionString, sinkOptions: new MSSqlServerSinkOptions { TableName = "Log" }
                , null, null, LogEventLevel.Information, null, columnOptions: columnOptions, null, null)
                .CreateLogger();

            //
            //Log.Logger = new LoggerConfiguration()
            //   .WriteTo.MSSqlServer(
            //       connectionString: connectionString,
            //       tableName: "Log",
            //       appConfiguration: Configuration,
            //       autoCreateSqlTable: true,
            //       columnOptionsSection: serilogColumns,
            //       schemaName: "Serilog SchemaName")
            //   .CreateLogger();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).UseSerilog();//serilog;
    }
}
