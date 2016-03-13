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
