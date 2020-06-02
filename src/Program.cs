using System;
using System.Text;
using System.Threading;

namespace BouncingBall
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Console.OutputEncoding = Encoding.GetEncoding(65001);

            var game = new Game();
            game.Run();
        }
    }
}
