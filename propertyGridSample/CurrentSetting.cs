using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace propertyGridSample
{
    static class CurrentSetting
    {
        static  CurrentSetting()
        {
            //todo logging
            propertySettings = new PropertySettings();
            propertySettings.Load();
        }

        public static PropertySettings propertySettings;

    }
}
