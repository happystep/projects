using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVIC_MVC
{
    public class EVIC_Model
    {
        /// <summary>
        /// enumeration of which state we are in
        /// </summary>
        public enum State {SystemStatus, WarningMessages, PersonalSettings, TempInfo, TripInfo };

        public State current;

       


       public void changeState (int index)
        {
            switch (index)
            {
                case 0:
                    current = State.SystemStatus;
                    break;
                case 1:
                    current = State.WarningMessages;
                    break;
                case 2:
                    current = State.PersonalSettings;
                    break;
                case 3:
                    current = State.TempInfo;
                    break;
                case 4:
                    current = State.TripInfo;
                    break;
                default:
                    break;


            }



        }

        public enum Units { us, metric }

        public Units unit;

        public void changeUnit()
        {
            if (isMetric == true )
            {
                unit = Units.metric;
            }
            else if (isMetric == false)
            {
                unit = Units.us;
            }

        }
        public string UnitStringDistance()
        {

            string s = "";
            switch (unit)
            {
                case Units.us:
              s = " mi";
                    break;
                case Units.metric:
                   s  =  " km";
                    break;
                default:
                    break;
            }
                    return s;

            }

        public string UnitStringTemp()
        {

            string s = "";
            switch (unit)
            {
                case Units.us:
                    s = "°F";
                    break;
                case Units.metric:
                    s = "°C";
                    break;
                default:
                    break;
            }
            return s;

        }


        /// <summary>
        /// Field for the odometer
        /// </summary>
        private static int _odometer = 0;

        /// <summary>
        /// Get/Set for odometer
        /// </summary>
        public int Odometer
        {
            get { return _odometer; }
            set { _odometer = value; }
        }

        public void SetOdometer()
        {
            switch (unit)
            {
                case Units.us:
                    Odometer = Convert.ToInt32(ConvertToMI(Odometer));
                    break;
                case Units.metric:
                    Odometer = Convert.ToInt32(ConvertToKM(Odometer));
                    break;
                default:
                    break;



            }
        }
        
        /// <summary>
        /// Field for miles until oil change
        /// </summary>
        private static int _milesToOilChange = 3000;

        /// <summary>
        /// Get/Set for miles until oil change
        /// </summary>
        public int MilesToOilChange
        {
            get { return _milesToOilChange; }
            set { _milesToOilChange = value;  }
        }

        public void SetOilChange()
        {
            switch (unit)
            {
                case Units.us:
                    MilesToOilChange = Convert.ToInt32(ConvertToMI(MilesToOilChange));
                    break;
                case Units.metric:
                    MilesToOilChange = Convert.ToInt32(ConvertToKM(MilesToOilChange));
                    break;
                default:
                    break;



            }
        }


        private bool _systemToggle = false;

        public bool SystemToggle
        {
            get { return _systemToggle; }
        }

        public void ToggleSystem()
        {
            if (_systemToggle == false)
                {
                _systemToggle = true;

            }
            else if (_systemToggle == true)
            {
                _systemToggle = false;
            }

        }


        //warning messagesfields start here 
        private bool _doorAjar = true; //testing door ajar

        public bool DoorAjar
        {
            get { return _doorAjar; }
            set { _doorAjar = value;  }

           
        }

        private bool _checkEngine = true;

        public bool CheckEngine
        {
            get { return _checkEngine; }
            set { _checkEngine = value; }
        }

        private bool _oilChange = true;

        public bool OilChange
        {
            get { return _oilChange; }
            set { _oilChange = value; }
         }


        //start string returns for warning messages 

        private string[] warningMessages = { "Door Ajar!", "Check Engine Soon", "Oil Change Soon!" };

        public string CheckDoor()
        {
            if (_doorAjar == true)
            {
              return  warningMessages[0];
            }


            return "";

        }
        public string CheckEngineString()
        {
            if (_checkEngine == true)
            {
                return warningMessages[1];
            }


            return "";

        }
        public string CheckOilString()
        {
            if (_oilChange == true)
            {
                return warningMessages[2];
            }


            return "";

        }







        /// <summary>
        /// Field for checking which mode we are in
        /// </summary>
        private static bool _isMetric = false;

        /// <summary>
        /// Get/Set for isMetric field
        /// </summary>
        public bool isMetric
        {
            get { return _isMetric; }
            set { _isMetric = value; }
        }

        private string[] personalSettings = { "US Units", "Metric Units" };

        public string CheckPersonalSettings()
        {
            if (_isMetric == true)
            {
                return personalSettings[1];
            }


            return personalSettings[0];

        }

        /// <summary>
        /// temperatures start here
        /// </summary>
        private int _insideTemp = 0; // testing inside

        public int InsideTemp
        {
            get { return _insideTemp; }
            set { _insideTemp = value; }
            
        }

        private int _outsideTemp = 0;

        public int OutsideTemp
        {
            get { return _outsideTemp; }
            set { _outsideTemp = value; }
        }


        private static bool _isToggledTemp = false;
        
        public bool isToggledTemp
        {
            get { return _isToggledTemp; }
            set { _isToggledTemp = value; }
        }

        public void ToggleTemp()
        {
            if (isToggledTemp == true)
            {
                isToggledTemp = false;
            }
            else if (isToggledTemp == false)
            { isToggledTemp = true; }
        }

        public string TemperatureChoose ()
        {
            if (isToggledTemp == true)
            {
                return "Outside Temperature: " + OutsideTemp.ToString();
            }
            else if (isToggledTemp == false)

            {
                return "Inside Temperature: " + InsideTemp.ToString();

            }

            return " ";

        }
        public void SetInsideTemp()
        {
            switch (unit)
            {
                case Units.us:
                    InsideTemp = Convert.ToInt32(ConvertToFarhenheit(InsideTemp));
                    break;
                case Units.metric:
                    InsideTemp = Convert.ToInt32(ConvertToCelsius(InsideTemp));
                    break;
                default:
                    break;



            }
        }
        public void SetOusideTemp()
        {
            switch (unit)
            {
                case Units.us:
                    OutsideTemp = Convert.ToInt32(ConvertToFarhenheit(OutsideTemp));
                    break;
                case Units.metric:
                    OutsideTemp = Convert.ToInt32(ConvertToCelsius(OutsideTemp));
                    break;
                default:
                    break;



            }
        }





        //start trips here

        private static double _tripA = 0;

        public double TripA
        {
            get { return _tripA;    }
            set
            {
                _tripA = value;
            }
        }

        private static double _tripB = 0;
        
        public double TripB
        {
            get { return _tripB; }
            set { _tripB = value; }
        }

        private static bool _isToggledTrip = false;

        public bool isToggledTrip
        {
            get { return _isToggledTrip; }
            set { _isToggledTrip = value; }
        }

        public void ToggleTrip()
        {
            if (isToggledTrip == true)
            {
                isToggledTrip = false;
            }
            else if (isToggledTrip == false)
            { isToggledTrip = true; }
        }
        public string TripChoose()
        {
            if (isToggledTrip == true)
            {
                return "Trip B: " + TripB.ToString();
            }
            else if (isToggledTrip == false)

            {
                return "Trip A: " + TripA.ToString();

            }

            return " ";

        }

        public void ResetTrip()
        {
            if (isToggledTrip == true)
            {
                TripB = 0;
            }
            else if (isToggledTrip == false)

            {
                TripA = 0;

            }
        }

        public void SetTripA()
        {
            switch (unit)
            {
                case Units.us:
                    TripA = Convert.ToInt32(ConvertToMI(TripA));
                    break;
                case Units.metric:
                    TripA = Convert.ToInt32(ConvertToKM(TripA));
                    break;
                default:
                    break;



            }
        }

        public void SetTripB()
        {
            switch (unit)
            {
                case Units.us:
                    TripB = Convert.ToInt32(ConvertToMI(TripB));
                    break;
                case Units.metric:
                    TripB = Convert.ToInt32(ConvertToKM(TripB));
                    break;
                default:
                    break;



            }
        }






        /////complete system change starts here... from MEtric to US Control 

        /// <summary>
        /// field for the toggled condition for the probram
        /// </summary>
        private static bool _isToggled = false;
        /// <summary>
        /// get/set for isToggled field
        /// </summary>
        public bool isToggled
        {
            get { return _isToggled; }
            set { _isToggled = value; }
        }

        public void Toggle (  )
        {
            if (_isMetric == false)
            {
                _isMetric = true;
                _isToggled = true;
            }
            else if (_isMetric == true)
            {
                _isMetric = false;
                _isToggled = false;
            }
        }


        /// <summary>
        /// unit conversions start here!!!!!
        /// </summary>
        

        /// <summary>
        /// this method converts miles to kilometers
        /// </summary>
        /// <param name="mi"></param>
        /// <returns>returns the value in km calculated</returns>
        public static double ConvertToKM(double mi)
        {
            double km = mi * 1.609344;
            return km;
        }
        /// <summary>
        /// this method converts kilometers to miles
        /// </summary>
        /// <param name="km"></param>
        /// <returnsreturns>the value in miles calculated</returnsreturns>
        public static double ConvertToMI(double km)
        {
            double mi = km / 1.609344;
            return mi;

        }
        /// <summary>
        /// converts parameter (farhernheit to celsius)
        /// </summary>
        /// <param name="f">farenheit number</param>
        /// <returns>new number in celsius units</returns>
        public double ConvertToCelsius(double f)
        {
            double c = (5.0 / 9.0) * (f - 32);
            return c;
        }

        /// <summary>
        /// Converts parameter to farhenheit
        /// </summary>
        /// <param name="c">celsius number</param>
        /// <returns>resulting farhenheit number</returns>
        public double ConvertToFarhenheit(double c)
        {
            double f = ((c * 9) / 5) + 32;
            return f;
        }



        private  string[] options = { "System Status", "Warning Messages", "Personal Settings", "Temperature Information", "Trip Information" };

        public override string ToString()
        {
            string s = "";

            switch (current)
            {
                case State.SystemStatus:
                  s  = options[0];
                    break;
                case State.WarningMessages:
                    s = options[1];
                    break;
                case State.PersonalSettings:
                    s = options[2];
                    break;
                case State.TempInfo:
                    s = options[3];
                    break;
                case State.TripInfo:
                    s = options[4];
                    break;
                default:
                    break;
                 
                    



            }


            return s;
                




        }























    }
}
