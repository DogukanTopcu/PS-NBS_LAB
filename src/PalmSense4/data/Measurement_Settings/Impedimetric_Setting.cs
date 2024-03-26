using PalmSens.Techniques;
using PalmSens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalmSense4.data.Measurement_Settings
{
    public class Impedimetric_Setting : SettingsData
    {
        private ImpedimetricMethod _method;

        public Impedimetric_Setting(string name, Method method) : base(name)
        {
            _method = (ImpedimetricMethod) method;
        }
        public Impedimetric_Setting(string name, int value, Method method) : base(name, value)
        {
            _method = (ImpedimetricMethod) method;
        }

        public ImpedimetricMethod Method { get { return _method; } }
    }
}
