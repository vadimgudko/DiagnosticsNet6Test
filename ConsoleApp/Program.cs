using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace ConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //var tracerProvider = Sdk.CreateTracerProviderBuilder()
            //    .AddSource("*")
            //    .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("Console"));
            //tracerProvider.Build();

            Activity.DefaultIdFormat = ActivityIdFormat.W3C;
            ActivitySource MyActivitySource = new ActivitySource("ActivitySource");

            var httpClient = new HttpClient() { BaseAddress = new Uri("http://localhost:41121") };
            var httpClient5 = new HttpClient() { BaseAddress = new Uri("http://localhost:36962") }; 
            using (var activity = new Activity("console job"))
            {
                activity.Start();
                var traceID = activity.TraceId;
                using (var activity2 = new Activity("console job2"))
                {
                    activity2.Start();
                }

                var res  = await httpClient.GetAsync("/service");
                //var res5 = await httpClient5.GetAsync("/service");
            }
        }
    }
}
