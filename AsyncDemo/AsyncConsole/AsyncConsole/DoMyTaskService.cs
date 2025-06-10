using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncConsole
{
    public class DoMyTaskService
    {

        public async Task Run(int testId)
        {
            var start = DateTime.Now;
            Console.WriteLine("[{0}] DEBUT", start);
            string result = string.Empty;
            switch (testId)
            {
                case 0: result = DoMyTasksV0("test0"); break;
                case 1: result = await DoMyTasksV1("test1"); break;
                case 2: result = await DoMyTasksV2("test2"); break;
                case 3: result = await DoMyTasksV3("test3"); break;
                case 4: result = await DoMyTasksV4("test4"); break;
                case 5: result = await DoMyTasksV5("test5"); break;
            }
            var end = DateTime.Now;
            Console.WriteLine("[{0}] Sortie: {1}", end, result);
            Console.WriteLine("[{0}] TOUTES LES TACHES SONT TERMINEES - Temps global: {1}", end, end - start);
        }

        public string DoMyTasksV0(string message)
        {
            Console.WriteLine("[{0}] Entrée dans la méthode DoMyTasksV0...", DateTime.Now);
            var resource = new DummyDelayResource();
            resource.SendEmail();
            var number = resource.GetRandomNumber();
            var upper = resource.GetSpecialString(message);
            Console.WriteLine("[{0}] Sortie de la méthode DoMyTasksV0.", DateTime.Now);
            return string.Format("{0}-{1}", number, upper);
        }

        public async Task<string> DoMyTasksV1(string message)
        {
            Console.WriteLine("[{0}] Entrée dans la méthode DoMyTasksV1...", DateTime.Now);
            var resource = new DummyDelayResource();
            await resource.SendEmailAsync();
            var number = await resource.GetRandomNumberAsync();
            var upper = await resource.GetSpecialStringAsync(message);
            Console.WriteLine("[{0}] Sortie de la méthode DoMyTasksV1.", DateTime.Now);
            return string.Format("{0}-{1}", number, upper);
        }

        public async Task<string> DoMyTasksV2(string message)
        {
            Console.WriteLine("[{0}] Entrée dans la méthode DoMyTasksV2...", DateTime.Now);
            var resource = new DummyDelayResource();
            var emailTask = resource.SendEmailAsync();
            var number = await resource.GetRandomNumberAsync();
            var upper = await resource.GetSpecialStringAsync(message);
            await emailTask;
            Console.WriteLine("[{0}] Sortie de la méthode DoMyTasksV2.", DateTime.Now);
            return string.Format("{0}-{1}", number, upper);
        }

        public async Task<string> DoMyTasksV3(string message)
        {
            Console.WriteLine("[{0}] Entrée dans la méthode DoMyTasksV3...", DateTime.Now);
            var resource = new DummyDelayResource();
            var emailTask = resource.SendEmailAsync();
            var numberTask = resource.GetRandomNumberAsync();
            var upperTask = resource.GetSpecialStringAsync(message);
            var number = await numberTask;
            var upper = await upperTask;
            await emailTask;
            Console.WriteLine("[{0}] Sortie de la méthode DoMyTasksV3.", DateTime.Now);
            return string.Format("{0}-{1}", number, upper);
        }

        public async Task<string> DoMyTasksV4(string message)
        {
            Console.WriteLine("[{0}] Entrée dans la méthode DoMyTasksV4...", DateTime.Now);
            var resource = new DummyDelayResource();
            var emailTask = Task.Run(() => { resource.SendEmail(); });
            var numberTask = Task.Run(() => { return resource.GetRandomNumberAsync(); });
            var upperTask = Task.Run(() => { return resource.GetSpecialStringAsync(message); });
            var number = await numberTask;
            var upper = await upperTask;
            await emailTask;
            Console.WriteLine("[{0}] Sortie de la méthode DoMyTasksV4.", DateTime.Now);
            return string.Format("{0}-{1}", number, upper);
        }

        public async Task<string> DoMyTasksV5(string message)
        {
            Console.WriteLine("[{0}] Entrée dans la méthode DoMyTasksV5...", DateTime.Now);
            var resource = new DummyDelayResource();
            var emailTask = Task.Run(async () => { await resource.SendEmailAsync(); });
            var numberTask = Task.Run(async () => { return await resource.GetRandomNumberAsync(); });
            var upperTask = Task.Run(async () => { return await resource.GetSpecialStringAsync(message); });
            var number = await numberTask;
            var upper = await upperTask;
            await emailTask;
            
            Console.WriteLine("[{0}] Sortie de la méthode DoMyTasksV5.", DateTime.Now);
            return string.Format("{0}-{1}", number, upper);
        }
    }
}
