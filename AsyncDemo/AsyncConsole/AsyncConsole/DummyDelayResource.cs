using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncConsole
{
    public class DummyDelayResource
    {
        public void SendEmail()
        {
            Console.WriteLine("[{0}] SendMail (fake)", DateTime.Now);
            Thread.Sleep(2000);
        }

        public int GetRandomNumber()
        {
            Console.WriteLine("[{0}] GetRandomNumber", DateTime.Now);
            Thread.Sleep(1000);
            return (new Random()).Next();
        }

        public string GetSpecialString(string message)
        {
            Console.WriteLine("[{0}] GetSpecialString", DateTime.Now);
            Thread.Sleep(1500);
            return string.IsNullOrEmpty(message) ? "<RIEN>" : message.ToUpper();
        }

        public Task SendEmailAsync()
        {
            Console.WriteLine("[{0}] SendMail (fake)", DateTime.Now);
            return Task.Delay(2000);
        }

        public async Task<int> GetRandomNumberAsync()
        {
            Console.WriteLine("[{0}] GetRandomNumber", DateTime.Now);
            await Task.Delay(1000);
            return (new Random()).Next();
        }

        public async Task<string> GetSpecialStringAsync(string message)
        {
            Console.WriteLine("[{0}] GetSpecialString", DateTime.Now);
            await Task.Delay(1500);
            return string.IsNullOrEmpty(message) ? "<RIEN>" : message.ToUpper();
        }
    }
}
