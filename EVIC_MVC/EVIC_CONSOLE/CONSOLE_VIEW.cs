using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVIC_MVC
{
    class CONSOLE_VIEW
    {
        /// <summary>
        /// this is a field that corresponds to where the user is in the console application
        /// </summary>
        private static int index = 0;

        /// <summary>
        /// get/set for the index field
        /// </summary>
        public int IndexChange
        {
            get { return index; }
            set { index = value; }
        }

        // switch case will handle the differing index values

       public void Run(EVIC_Model model)
        {
            switch (index)
            {
                case 0:
                    Console.WriteLine(model.ToString());
                    break;



            }


        }







    }
}
