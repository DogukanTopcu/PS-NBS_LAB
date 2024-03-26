using PalmSens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalmSense4.data.Measurement_Settings
{
    public class CyclicVoltammetry_Settings
    {
        private List<CV_Setting> _settings;

        private CV_Setting _timeEquilibrium;
        private CV_Setting _eBegin;
        private CV_Setting _eVertex1;
        private CV_Setting _eVertex2;
        private CV_Setting _eStep;
        private CV_Setting _scanRate;
        private CV_Setting _numbersOfScan;

        private CV_Setting _eCondition;
        private CV_Setting _tCondition;
        private CV_Setting _eDeposition;
        private CV_Setting _tDeposition;

        private CV_Setting _startCurrent;
        private CV_Setting _maxCurrent;
        private CV_Setting _minCurrent;


        public CyclicVoltammetry_Settings(Method _method)
        {
            _settings = new List<CV_Setting>();

            _timeEquilibrium = new CV_Setting("Time Equilibrium", _method);
            _eBegin = new CV_Setting("E Begin (V)", _method);
            _eVertex1 = new CV_Setting("E Vertex 1 (V)", _method);
            _eVertex2 = new CV_Setting("E Vertex 2 (V)", _method);
            _eStep = new CV_Setting("E Step", _method);
            _scanRate = new CV_Setting("Scan Rate", _method);
            _numbersOfScan = new CV_Setting("Number of Scans", _method);

            _eCondition = new CV_Setting("E Condition", _method);
            _tCondition = new CV_Setting("T Condition", _method);
            _eDeposition = new CV_Setting("E Deposition", _method);
            _tDeposition = new CV_Setting("T Deposition", _method);

            _eBegin = new CV_Setting("E Begin", _method);
            _eStep = new CV_Setting("E Step", _method);

            _startCurrent = new CV_Setting("Start Current", 6, _method);
            _maxCurrent = new CV_Setting("Max Current", 2, _method);
            _minCurrent = new CV_Setting("Min Current", 4, _method);

            _settings.Add(_timeEquilibrium);
            _settings.Add(_eBegin);
            _settings.Add(_eVertex1);
            _settings.Add(_eVertex2);
            _settings.Add(_eStep);
            _settings.Add(_scanRate);
            _settings.Add(_numbersOfScan);

            _settings.Add(_eCondition);
            _settings.Add(_eDeposition);
            _settings.Add(_tCondition);
            _settings.Add(_tDeposition);

            _settings.Add(_startCurrent);
            _settings.Add(_maxCurrent);
            _settings.Add(_minCurrent);

        }

        public CV_Setting TimeEquilibrium { get { return _timeEquilibrium; } set { _timeEquilibrium = value; } }
        public CV_Setting EBegin { get { return _eBegin; } set { _eBegin = value; } }
        public CV_Setting EVertex1 { get { return _eVertex1; } set { _eVertex1 = value; } }
        public CV_Setting EVertex2 { get { return _eVertex2; } set { _eVertex2 = value; } }
        public CV_Setting EStep { get { return _eStep; } set { _eStep = value; } }
        public CV_Setting ScanRate { get { return _scanRate; } set { _scanRate = value; } }
        public CV_Setting NumbersOfScan { get { return _numbersOfScan; } set { _numbersOfScan = value; } }

        public CV_Setting ECondition { get { return _eCondition; } set { _eCondition = value; } }
        public CV_Setting TCondition { get { return _tCondition; } set { _tCondition = value; } }
        public CV_Setting EDeposition { get { return _eDeposition; } set { _eDeposition = value; } }
        public CV_Setting TDeposition { get { return _tDeposition; } set { _tDeposition = value; } }

        public CV_Setting StartCurrent { get { return _startCurrent; } set { _startCurrent = value; } }
        public CV_Setting MaxCurrent { get { return _maxCurrent; } set { _maxCurrent = value; } }
        public CV_Setting MinCurrent { get { return _minCurrent; } set { _minCurrent = value; } }
    }
}
