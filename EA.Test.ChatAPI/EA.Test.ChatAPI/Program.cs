using System;
using System.Configuration;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.SelfHost;
using Autofac;
using Autofac.Integration.WebApi;
using EA.Challenge.ChatAPI.Contracts;
using EA.Challenge.ChatAPI.Controllers;
using EA.Challenge.ChatAPI.Service;
using NLog;
using ILogger = EA.Challenge.ChatAPI.Contracts.ILogger;
using Logger = NLog.Logger;

namespace EA.Challenge.ChatAPI
{
    public class Program
    {
        static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        
        /// <summary>
        /// Main method
        /// </summary>
        static void Main()
        {
            ServerInitialize();
        }

        /// <summary>
        /// Initialize the API
        /// </summary>
        static void ServerInitialize()
        {
            try
            {
                var serverAddressIp = ConfigurationManager.AppSettings["HostAddress"];
                var port = ConfigurationManager.AppSettings["HostPort"];

                var config = new HttpSelfHostConfiguration(string.Format("http://{0}:{1}", serverAddressIp, port));

                var builder = new ContainerBuilder();

                // Register API controllers using assembly scanning.
                builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

                // Register API controller dependencies per request.
                builder.RegisterType<Configurator>().As<IConfigurator>().InstancePerRequest();
                builder.RegisterType<Service.Logger>().As<ILogger>().InstancePerRequest();
                builder.RegisterType<UserConnection>().As<IUserConnection>().InstancePerRequest();
                builder.RegisterType<Messaging>().As<IMessaging>().InstancePerRequest();

                // Register Controllers
                builder.RegisterType<MessagesController>().InstancePerRequest();
                builder.RegisterType<UserController>().InstancePerRequest();

                var container = builder.Build();

                // Set the dependency resolver implementation.
                var resolver = new AutofacWebApiDependencyResolver(container);
                config.DependencyResolver = resolver;

                config.Routes.MapHttpRoute(
                    "API", "api/{controller}/{action}/{id}",
                    new { id = RouteParameter.Optional });

                config.Routes.MapHttpRoute(
                    "GetMessageRoute", "api/{controller}/{action}/fromId/{fromId}/toId/{toId}",
                    new { id = RouteParameter.Optional });


                using (var server = new HttpSelfHostServer(config))
                {
                    server.OpenAsync().Wait();
                    Console.WriteLine("Server started at port {0}", port);
                    Console.WriteLine("You can change the server port in the App.Config file in the project directory");
                    Console.WriteLine();
                    Console.WriteLine("Press \"Enter\" to quit.");
                    Console.ReadLine();
                }
                
            }
            catch (Exception ex)
            {
                Logger.Error("Error: {0}",ex.Message);
                Logger.Error("Stacktrace: {0}", ex.StackTrace);
                Console.WriteLine("Error occurred while trying to initialize server. You may try the following:");
                Console.WriteLine("1. Restarting the application in Administrator mode.");
                Console.WriteLine("2. Changing the port in the app.config file in the project directory.");
                Console.WriteLine("3. You may restart your computer (don't format it for god's sake!). Most Microsoft products' issues fix itself on a restart :-)");
                Console.WriteLine("4. Try again later");
                Console.WriteLine();
                Console.WriteLine("Press \"Enter\" to Exit");
                Console.ReadLine();
            }
        }
    }
}

