using PalmSens;
using PalmSens.Techniques;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalmSense4.data.Measurement_Settings
{
    public class CV_Setting : SettingsData
    {
        private CyclicVoltammetry _method;

        public CV_Setting(string name, Method method) : base(name)
        {
            _method = (CyclicVoltammetry) method;
        }
        public CV_Setting(string name, int value, Method method) : base(name, value)
        {
            _method = (CyclicVoltammetry) method;
        }

        public CyclicVoltammetry Method { get { return _method; } }
    }
}
