// See https://aka.ms/new-console-template for more information
using AsyncConsole;

object o = null;
var i = 1;
o = i;

Console.WriteLine("Hello, World!");
var service = new DoMyTaskService();
var task = service.Run(0);
task.Wait();
task = service.Run(1); // Si absence de Task et Wait => Fire & Forget
task.Wait();
task = service.Run(2);
task.Wait();
task = service.Run(3);
task.Wait();
task = service.Run(4);
task.Wait();
task = service.Run(5);
task.Wait();


