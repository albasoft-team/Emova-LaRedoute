using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace safeprojectname
{
    public abstract class ThreadController
    {
        private static Thread threadProducts;
        private static Thread threadOffers;
        private static Thread threadCommands;

        
        public static void initThread() {
             MainInterface ig = (MainInterface)Application.OpenForms["MainInterface"];
            threadProducts = new Thread(new ThreadStart(ThreadProducts.ThreadLoop));
            threadOffers = new Thread(new ThreadStart(ThreadOffers.ThreadLoop));
            threadCommands = new Thread(new ThreadStart(ThreadCommands.ThreadLoop));

        }
        internal static void startThreadProduct() {
            
            if (threadProducts.IsAlive)
                threadProducts.Resume();
            else
            threadProducts.Start();
        }

        internal static void stopThreadProduct()
        {
            threadProducts.Suspend();

        }
        internal static void startThreadOffers()
        {
            if (threadOffers.IsAlive)
                threadOffers.Resume();
            else
                threadOffers.Start();

        }

        internal static void stopThreadOffers()
        {
            threadOffers.Suspend();

        }
        internal static void startThreadCommands()
        {
            if (threadCommands.IsAlive)
                threadCommands.Resume();
            else
                threadCommands.Start();
        }

        internal static void stopThreadCommands()
        {
            threadCommands.Suspend();

        }
    }
}
