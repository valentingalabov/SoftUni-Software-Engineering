using SIS.MvcFramework;
using System.Threading.Tasks;

namespace IRunesApp
{
    public static class Program
    {
        public static async Task Main()
        {
            await WebHost.StartAsync(new Startup());
        }
    }
}
