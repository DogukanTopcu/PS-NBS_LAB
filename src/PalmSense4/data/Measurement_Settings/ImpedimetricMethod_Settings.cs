using PalmSens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalmSense4.data.Measurement_Settings
{
    public class ImpedimetricMethod_Settings
    {
        private List<Impedimetric_Setting> _settings;
        
        private Impedimetric_Setting _timeEquilibrium;
        private Impedimetric_Setting _potential;
        private Impedimetric_Setting _eAC;
        private Impedimetric_Setting _scanType;
        private Impedimetric_Setting _frequencyType;
        private Impedimetric_Setting _maxFrequency;
        private Impedimetric_Setting _minFrequency;
        private Impedimetric_Setting _nFrequencies;

        private Impedimetric_Setting _eCondition;
        private Impedimetric_Setting _tCondition;
        private Impedimetric_Setting _eDeposition;
        private Impedimetric_Setting _tDeposition;

        private Impedimetric_Setting _eBegin;
        private Impedimetric_Setting _eStep;
        private Impedimetric_Setting _eEnd;

        private Impedimetric_Setting _startCurrent;
        private Impedimetric_Setting _maxCurrent;
        private Impedimetric_Setting _minCurrent;


        public ImpedimetricMethod_Settings(Method _method)
        {
            _settings = new List<Impedimetric_Setting>();

            _timeEquilibrium = new Impedimetric_Setting("Time Equilibrium", _method);
            _potential = new Impedimetric_Setting("Potential / DC (V)", _method);
            _eAC = new Impedimetric_Setting("E ac (V)", _method);
            _scanType = new Impedimetric_Setting("Scan Type", 1, _method);
            _frequencyType = new Impedimetric_Setting("Frequency Type", 1, _method);
            _maxFrequency = new Impedimetric_Setting("Max Frequency", _method);
            _minFrequency = new Impedimetric_Setting("Min Frequency", _method);
            _nFrequencies = new Impedimetric_Setting("n Frequencies", _method);

            _eCondition = new Impedimetric_Setting("E Condition", _method);
            _tCondition = new Impedimetric_Setting("T Condition", _method);
            _eDeposition = new Impedimetric_Setting("E Deposition", _method);
            _tDeposition = new Impedimetric_Setting("T Deposition", _method);

            _eBegin = new Impedimetric_Setting("E Begin", _method);
            _eStep = new Impedimetric_Setting("E Step", _method);
            _eEnd = new Impedimetric_Setting("E End", _method);

            _startCurrent = new Impedimetric_Setting("Start Current", 1, _method);
            _maxCurrent = new Impedimetric_Setting("Max Current", 7, _method);
            _minCurrent = new Impedimetric_Setting("Min Current", 5, _method);

            _settings.Add(_timeEquilibrium);
            _settings.Add(_potential);
            _settings.Add(_eAC);
            _settings.Add(_scanType);
            _settings.Add(_frequencyType);
            _settings.Add(_maxFrequency);
            _settings.Add(_minFrequency);
            _settings.Add(_nFrequencies);
            
            _settings.Add(_eCondition);
            _settings.Add(_eDeposition);
            _settings.Add(_tCondition);
            _settings.Add(_tDeposition);
            
            _settings.Add(_eBegin);
            _settings.Add(_eStep);
            _settings.Add(_eEnd);

            _settings.Add(_startCurrent);
            _settings.Add(_maxCurrent);
            _settings.Add(_minCurrent);

        }

        public Impedimetric_Setting TimeEquilibrium { get { return _timeEquilibrium; } set { _timeEquilibrium = value; } }
        public Impedimetric_Setting Potential { get { return _potential; } set { _potential = value; } }
        public Impedimetric_Setting EAC { get { return _eAC; } set { _eAC = value; } }
        public Impedimetric_Setting ScanType { get { return _scanType; } set { _scanType = value; } }
        public Impedimetric_Setting FrequencyType { get { return _frequencyType; } set { _frequencyType = value; } }
        public Impedimetric_Setting MaxFrequency { get { return _maxFrequency; } set { _maxFrequency = value; } }
        public Impedimetric_Setting MinFrequency { get { return _minFrequency; } set { _minFrequency = value; } }
        public Impedimetric_Setting NFrequencies { get { return _nFrequencies; } set { _nFrequencies = value; } }
        
        public Impedimetric_Setting ECondition { get { return _eCondition; } set { _eCondition = value; } }
        public Impedimetric_Setting TCondition { get { return _tCondition; } set { _tCondition = value; } }
        public Impedimetric_Setting EDeposition { get { return _eDeposition; } set { _eDeposition = value; } }
        public Impedimetric_Setting TDeposition { get { return _tDeposition; } set { _tDeposition = value; } }

        public Impedimetric_Setting EBegin { get { return _eBegin; } set { _eBegin = value; } }
        public Impedimetric_Setting EStep { get { return _eStep; } set { _eStep = value; } }
        public Impedimetric_Setting EEnd { get { return _eEnd; } set { _eEnd = value; } }

        public Impedimetric_Setting StartCurrent { get { return _startCurrent; } set { _startCurrent = value; } }
        public Impedimetric_Setting MaxCurrent { get { return _maxCurrent; } set { _maxCurrent = value; } }
        public Impedimetric_Setting MinCurrent { get { return _minCurrent; } set { _minCurrent = value; } }
    }
}
