using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Text;
using XamarinStarter.Abstractions;

namespace XamarinStarter.Helpers
{
    public class Connectivity : IConnectivity
    {
        public bool IsConnected()
        {
            return CrossConnectivity.Current.IsConnected;
        }
    }
}
