using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAMStreetView.Properties
{
   
        internal sealed partial class Settings
        {

            public Settings()
            {
                if (UpgradeNeeded)
                {
                    UpgradeNeeded = false;
                    Save();
                    Upgrade();
                }
            }
        }
    
}
