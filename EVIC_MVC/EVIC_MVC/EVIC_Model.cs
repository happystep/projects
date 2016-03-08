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
            get { return _isMetric; }
            set { _isMetric = value; }
        }








   
        




    }
}
