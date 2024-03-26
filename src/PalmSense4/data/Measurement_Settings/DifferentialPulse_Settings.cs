using PalmSens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalmSense4.data.Measurement_Settings
{
    public class DifferentialPulse_Settings
    {
        private List<DP_Setting> _settings;

        private DP_Setting _timeEquilibrium;
        private DP_Setting _eBegin;
        private DP_Setting _eEnd;
        private DP_Setting _eStep;
        private DP_Setting _scanRate;
        private DP_Setting _ePulse;
        private DP_Setting _tPulse;

        private DP_Setting _eCondition;
        private DP_Setting _tCondition;
        private DP_Setting _eDeposition;
        private DP_Setting _tDeposition;

        private DP_Setting _startCurrent;
        private DP_Setting _maxCurrent;
        private DP_Setting _minCurrent;


        public DifferentialPulse_Settings(Method _method)
        {
            _settings = new List<DP_Setting>();

            _timeEquilibrium = new DP_Setting("Time Equilibrium", _method);
            _eBegin = new DP_Setting("E Begin", _method);
            _eEnd = new DP_Setting("E End (V)", _method);
            _eStep = new DP_Setting("E Step (V)", _method);
            _scanRate = new DP_Setting("Scan Rate", _method);
            _ePulse = new DP_Setting("E Pulse (V)", _method);
            _tPulse = new DP_Setting("T Pulse (V)", _method);

            _eCondition = new DP_Setting("E Condition", _method);
            _tCondition = new DP_Setting("T Condition", _method);
            _eDeposition = new DP_Setting("E Deposition", _method);
            _tDeposition = new DP_Setting("T Deposition", _method);

            _startCurrent = new DP_Setting("Start Current", 2, _method);
            _maxCurrent = new DP_Setting("Max Current", 4, _method);
            _minCurrent = new DP_Setting("Min Current", 5, _method);

            _settings.Add(_timeEquilibrium);
            _settings.Add(_eBegin);
            _settings.Add(_eEnd);
            _settings.Add(_eStep);
            _settings.Add(_scanRate);
            _settings.Add(_ePulse);
            _settings.Add(_tPulse);

            _settings.Add(_eCondition);
            _settings.Add(_eDeposition);
            _settings.Add(_tCondition);
            _settings.Add(_tDeposition);

            _settings.Add(_startCurrent);
            _settings.Add(_maxCurrent);
            _settings.Add(_minCurrent);

        }

        public DP_Setting TimeEquilibrium { get { return _timeEquilibrium; } set { _timeEquilibrium = value; } }
        public DP_Setting EBegin { get { return _eBegin; } set { _eBegin = value; } }
        public DP_Setting EEnd { get { return _eEnd; } set { _eEnd = value; } }
        public DP_Setting EStep { get { return _eStep; } set { _eStep = value; } }
        public DP_Setting ScanRate { get { return _scanRate; } set { _scanRate = value; } }
        public DP_Setting EPulse { get { return _ePulse; } set { _ePulse = value; } }
        public DP_Setting TPulse { get { return _tPulse; } set { _tPulse = value; } }

        public DP_Setting ECondition { get { return _eCondition; } set { _eCondition = value; } }
        public DP_Setting TCondition { get { return _tCondition; } set { _tCondition = value; } }
        public DP_Setting EDeposition { get { return _eDeposition; } set { _eDeposition = value; } }
        public DP_Setting TDeposition { get { return _tDeposition; } set { _tDeposition = value; } }

        public DP_Setting StartCurrent { get { return _startCurrent; } set { _startCurrent = value; } }
        public DP_Setting MaxCurrent { get { return _maxCurrent; } set { _maxCurrent = value; } }
        public DP_Setting MinCurrent { get { return _minCurrent; } set { _minCurrent = value; } }
    }
}
