using PalmSens.Techniques;
using PalmSens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalmSense4.data.Measurement_Settings
{
    public class DP_Setting : SettingsData
    {
        private DifferentialPulse _method;

        public DP_Setting(string name, Method method) : base(name)
        {
            _method = (DifferentialPulse) method;
        }
        public DP_Setting(string name, int value, Method method) : base(name, value)
        {
            _method = (DifferentialPulse)method;
        }

        public DifferentialPulse Method { get { return _method; } }
    }
}
