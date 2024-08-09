using PalmSens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalmSense4.data.Measurement_Settings
{
    public class SettingsData
    {
        private string name;
        private int value;

        public SettingsData(string name)
        {
            this.name = name;
        }

        public SettingsData(string name, int value)
        {
            this.name = name;
            this.value = value;
        }

        public string GetFrequencyValue(int _v)
        {
            switch (_v)
            {
                case 1:
                    return "100pA";
                case 2:
                    return "1nA";
                case 3:
                    return "10nA";
                case 4:
                    return "100nA";
                case 5:
                    return "1uA";
                case 6:
                    return "10uA";
                case 7:
                    return "100uA";
                case 8:
                    return "1mA";
                case 9:
                    return "10mA";
                case 10:
                    return "100mA";
                default:
                    return "";

            }
        }
        //public float GetFrequency()
        //{
        //    // pA / 100  değerinde veri
        //    switch (this.value)
        //    {
        //        case 1:
        //            return 0.0001f;
        //        case 2:
        //            return 0.001f;
        //        case 3:
        //            return 0.01f;
        //        case 4:
        //            return 0.1f;
        //        case 5:
        //            return 1f;
        //        case 6:
        //            return 10f;
        //        case 7:
        //            return 100f;
        //        case 8:
        //            return 1000f;
        //        case 9:
        //            return 10000f;
        //        case 10:
        //            return 100000f;
        //        default:
        //            return 1f;
        //    }
        //}

        public CurrentRanges GetFrequency()
        {
            // pA / 100  değerinde veri
            switch (this.value)
            {
                case 1:
                    return CurrentRanges.cr100pA;
                case 2:
                    return CurrentRanges.cr1nA;
                case 3:
                    return CurrentRanges.cr10nA;
                case 4:
                    return CurrentRanges.cr100nA;
                case 5:
                    return CurrentRanges.cr1uA;
                case 6:
                    return CurrentRanges.cr10uA;
                case 7:
                    return CurrentRanges.cr100uA;
                case 8:
                    return CurrentRanges.cr1mA;
                case 9:
                    return CurrentRanges.cr10mA;
                case 10:
                    return CurrentRanges.cr100mA;
                default:
                    return CurrentRanges.cr100pA;
            }
        }

        public int GetPositionByCurrentRanges(string c)
        {
            Console.WriteLine(c);
            switch (c)
            {
                case "100 pA":
                    return 1;
                case "1 nA":
                    return 2;
                case "10 nA":
                    return 3;
                case "100 nA":
                    return 4;
                case "1 uA":
                    return 5;
                case "10 uA":
                    return 6;
                case "100 uA":
                    return 7;
                case "1 mA":
                    return 8;
                case "10 mA":
                    return 9;
                case "100 mA":
                    return 10;
                default:
                    return 1;
            }
        }

        public int GetPositionByFrequency(float freq)
        {
            switch(freq)
            {
                case 0.0001f:
                    return 1;
                case 0.001f:
                    return 2;
                case 0.01f:
                    return 3;
                case 0.1f:
                    return 4;
                case 1f:
                    return 5;
                case 10f:
                    return 6;
                case 100f:
                    return 7;
                case 1000f:
                    return 8;
                case 10000f:
                    return 9;
                case 100000f:
                    return 10;
                default:
                    return 1;
            }
        }

        // Getters and Setters:
        public string Name { get { return name; } set { this.name = value; } }
        public int Value { get { return value; } set { this.value = value; } }
    }
}
