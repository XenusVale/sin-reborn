using System;
using System.Threading;
using System.Windows.Forms;

namespace Sin_Reborn
{
    static class Launcher
    {
        [STAThread]
        static void Main()
        {
            using (Mutex sinRebornMutex = new Mutex(false, "sinRebornMutex"))
            {
                if (!sinRebornMutex.WaitOne(0, false))
                {
                    return;
                }
                else
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Dashboard());
                }
            }
        }
    }
}
