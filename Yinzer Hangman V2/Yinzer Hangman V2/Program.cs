using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using Yinzer_Hangman_V2;
namespace YinzerHangman
{

    class Program
    {
        static void Main()
        {
            YinzerApp app = new YinzerApp();
            app.Run();
        }
    }
}