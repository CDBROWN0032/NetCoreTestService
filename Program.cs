using System;
using System.ServiceProcess;
using Topshelf;


namespace NetCoreTestService
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Hello World

            Console.WriteLine("Hello World");

            #endregion

            #region Topshelf
            //Topshelf dependancy             
            //var exitCode = HostFactory.Run(x =>
            //{
            //    x.Service<Heartbeat>(s =>
            //    {
            //        s.ConstructUsing(heartbeat => new Heartbeat());
            //        s.WhenStarted(heartbeat => heartbeat.Start());
            //        s.WhenStopped(heartbeat => heartbeat.Stop());
            //    });

            //    x.RunAsLocalSystem();
            //    x.SetServiceName("HeartbeatService");
            //    x.SetDisplayName("Heartbeat Service");
            //    x.SetDescription("Totally not a key logger.");

            //});

            //int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            //Environment.ExitCode = exitCodeValue;            
            #endregion

            #region .net Core Webhost                        
            HeartbeatTwo service = new HeartbeatTwo();

            if (!Environment.UserInteractive)
            {
                ServiceBase.Run(service);
            }
            else
            {
                service.Start(args);

                Console.WriteLine("Press 'P' to pause or any other key to stop...");
                Console.ReadKey(true);

                //IO exception, need to find way to release file or alter what is being written to file
                //var keyPress = Console.ReadKey(true);
                //if (keyPress.Key == ConsoleKey.P)
                //{
                //    service.Pause();
                //}
                //else
                //{
                //    service.Stop();
                //}

                service.Stop();
                                    
            }
            #endregion
        }
    }
}
