using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVIC_MVC
{
    /// <summary>
    /// this is the model class for the console EVIC app
    /// </summary>
    public class EVIC_Model
    {
        ///random numbers for running solo
        private static Random r = new Random();
        /// <summary>
        /// array of ints that hold the random numbers for the regular run
        /// </summary>
        private static int[] randomNumbers = { r.Next(1, 100000), r.Next(1, 3000), r.Next(2), r.Next(2), r.Next(20, 112), r.Next(32, 112), r.Next(1, 20000), r.Next(1, 5000) };
        /// <summary>
        /// this method sets random values for the fields
        /// </summary>
        public void SetRandomValues()
        {
            Odometer = randomNumbers[0];
            MilesToOilChange = randomNumbers[1];
            if (randomNumbers[2] == 1)
            {
                DoorAjar = true;
            }
            if (randomNumbers[3] == 1)
            {
                CheckEngine = true;
            }
            if (randomNumbers[2] < 1500)
            {
                OilChange = true;
            }

            InsideTemp = randomNumbers[4];
            OutsideTemp = randomNumbers[5];
            TripA = randomNumbers[6];
            TripB = randomNumbers[7];            
            
        }
        /// <summary>
        /// enumeration of which state we are in
        /// </summary>
        public enum State {SystemStatus, WarningMessages, PersonalSettings, TempInfo, TripInfo };
        /// <summary>
        /// variable for the state
        /// </summary>
        public State current;
        /// <summary>
        /// this method changes the state, depending on index
        /// </summary>
        /// <param name="index"></param>
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
        /// <summary>
        /// enumeration of units
        /// </summary>
        public enum Units { us, metric }
        /// <summary>
        /// unit variable
        /// </summary>
        public Units unit;
        /// <summary>
        /// changing the enumeration of units
        /// </summary>
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
        /// <summary>
        /// This returns the string of the corresponding unit that we are in
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// this returns the string for the corresponding units in temperature
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// this method sets the odometer depending on the units
        /// </summary>
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
        /// this method increments the system status during simulation
        /// </summary>
        public void StatusIncrement()
        {
            Odometer++;
            MilesToOilChange--;
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
        /// <summary>
        /// this method sets the oil change depending on which unit we are currently in
        /// </summary>
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
        /// <summary>
        /// field for knowing if we have toggled the system or not
        /// </summary>
        private bool _systemToggle = false;
        /// <summary>
        /// get/set for the field
        /// </summary>
        public bool SystemToggle
        {
            get { return _systemToggle; }
        }
        /// <summary>
        /// this actually toggles the system toggle
        /// </summary>
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
        /// <summary>
        /// field for the door ajar warning
        /// </summary>
        private bool _doorAjar = false; 
        /// <summary>
        /// get/set for the door ajar
        /// </summary>
        public bool DoorAjar
        {
            get { return _doorAjar; }
            set { _doorAjar = value;  }

           
        }
        /// <summary>
        /// field for the check engine warning
        /// </summary>
        private bool _checkEngine = false;
        /// <summary>
        /// get/set for the check engine warning
        /// </summary>
        public bool CheckEngine
        {
            get { return _checkEngine; }
            set { _checkEngine = value; }
        }
        /// <summary>
        /// field for the oil change warning
        /// </summary>
        private bool _oilChange = false;
        /// <summary>
        /// get/set for the oil change warning
        /// </summary>
        public bool OilChange
        {
            get { return _oilChange; }
            set { _oilChange = value; }
         }


        //start string returns for warning messages 
        /// <summary>
        /// field containing the allowable strings for the warning messages
        /// </summary>
        private string[] warningMessages = { "Door Ajar!", "Check Engine Soon", "Oil Change Soon!" };
        /// <summary>
        /// this checks if we need to return the door ajar warning
        /// </summary>
        /// <returns></returns>
        public string CheckDoor()
        {
            if (_doorAjar == true)
            {
              return  warningMessages[0];
            }


            return "";

        }
        /// <summary>
        /// this method checks if we need to return the check engine soon warning
        /// </summary>
        /// <returns></returns>
        public string CheckEngineString()
        {
            if (_checkEngine == true)
            {
                return warningMessages[1];
            }


            return "";

        }
        /// <summary>
        /// this method checks if we need to return the check oil soon warning
        /// </summary>
        /// <returns></returns>
        public string CheckOilString()
        {
            if (_oilChange == true)
            {
                return warningMessages[2];
            }


            return "";

        }

        
        ///simulator for warning messages
        
        ///this method sets the simulator settings for the warning messages
       public void SetWarningSimulator(bool a, bool b, bool c)
        {
            if (DoorAjar == false && a == true)
            {
                DoorAjar = true;
            }
            else if (DoorAjar == true && a == true)
            {
                DoorAjar = false;
            }
            //enginee settings
            else if (CheckEngine == false && b == true)
            {
                CheckEngine = true;
            }
            else if (CheckEngine == true && b == true)
            {
                CheckEngine = false;
            }
            // oil settings
            else if (OilChange == false && c == true)
            {
                OilChange = true;
            }
            else if (OilChange == true && c == true)
            {
                OilChange = false;
            }

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
        /// <summary>
        /// this is a field containing the strings for the units
        /// </summary>
        private string[] personalSettings = { "US Units", "Metric Units" };
        //this method checks which unit we need to return
        public string CheckPersonalSettings()
        {
            if (_isMetric == true)
            {
                return personalSettings[1];
            }


            return personalSettings[0];

        }

        /// <summary>
        /// field for the inside temperature
        /// </summary>
        private int _insideTemp = 0; // testing inside
        /// <summary>
        /// get/set for  inside temp field
        /// </summary>
        public int InsideTemp
        {
            get { return _insideTemp; }
            set { _insideTemp = value; }
            
        }
        /// <summary>
        /// field for the ouside tempearature
        /// </summary>
        private int _outsideTemp = 0;
        /// <summary>
        /// get/set for the outside temp field
        /// </summary>
        public int OutsideTemp
        {
            get { return _outsideTemp; }
            set { _outsideTemp = value; }
        }

        /// <summary>
        /// boolean field to know if temperature has been toggled
        /// </summary>
        private static bool _isToggledTemp = false;
        /// <summary>
        /// get/set for the toggled temp field
        /// </summary>
        public bool isToggledTemp
        {
            get { return _isToggledTemp; }
            set { _isToggledTemp = value; }
        }
        /// <summary>
        /// method that actually toggles the temp field
        /// </summary>
        public void ToggleTemp()
        {
            if (isToggledTemp == true)
            {
                isToggledTemp = false;
            }
            else if (isToggledTemp == false)
            { isToggledTemp = true; }
        }
        /// <summary>
        /// this method returns the appropriate temperature looking at the toggled field
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// this sets the inside temperature depending on the unit
        /// </summary>
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
        /// <summary>
        /// this method sets the outside temperature depending on the unit
        /// </summary>
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
        /// <summary>
        /// field for trip A
        /// </summary>
        private static double _tripA = 0;
        /// <summary>
        /// get/set for trip A field
        /// </summary>
        public double TripA
        {
            get { return _tripA;    }
            set
            {
                _tripA = value;
            }
        }
        /// <summary>
        /// field for trip B
        /// </summary>
        private static double _tripB = 0;
        /// <summary>
        /// get/set for trip b
        /// </summary>
        public double TripB
        {
            get { return _tripB; }
            set { _tripB = value; }
        }
        /// <summary>
        /// boolean field to know if the trip has been toggled
        /// </summary>
        private static bool _isToggledTrip = false;
        /// <summary>
        /// get/set for the boolean field for toggled trip
        /// </summary>
        public bool isToggledTrip
        {
            get { return _isToggledTrip; }
            set { _isToggledTrip = value; }
        }
        /// <summary>
        ///  acutal method to toggle the trip
        /// </summary>
        public void ToggleTrip()
        {
            if (isToggledTrip == true)
            {
                isToggledTrip = false;
            }
            else if (isToggledTrip == false)
            { isToggledTrip = true; }
        }
        /// <summary>
        /// field that decides which of the trips to returned contingent on which has been toggled
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// this method resents the trips
        /// </summary>
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
        /// <summary>
        /// this method sets the value for Trip A 
        /// </summary>
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
        /// <summary>
        /// this method sets the value for Trip B
        /// </summary>
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
        /// <summary>
        /// this method actually toggles the fields
        /// </summary>
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


        /// <summary>
        /// string array of the different menu options
        /// </summary>
        private  string[] options = { "System Status", "Warning Messages", "Personal Settings", "Temperature Information", "Trip Information" };
        /// <summary>
        /// override of the ToString() method for displaying the correct menu that we are in
        /// </summary>
        /// <returns></returns>
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
