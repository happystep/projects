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
                case 1:
                    Console.WriteLine(model.ToString());
                    break;
                case 2:
                    Console.WriteLine(model.ToString());
                    break;
                case 3:
                    Console.WriteLine(model.ToString());
                    break;
                case 4:
                    Console.WriteLine(model.ToString());
                    break;
                default:
                    break;






            }


        }

        public void RunInside (EVIC_Model model)
        {
            Console.Clear();
            Console.WriteLine(model.ToString());
            switch (index)
            {
                case 0:
                    if (model.SystemToggle == false )
                    {
                        Console.WriteLine(model.Odometer.ToString() + model.UnitStringDistance());
                    }
                    else if (model.SystemToggle == true )
                    {
                        Console.WriteLine(model.MilesToOilChange.ToString() + model.UnitStringDistance());
                    }
                    break;
                case 1:
                    Console.WriteLine(model.CheckDoor());
                    Console.WriteLine(model.CheckEngineString());
                    Console.WriteLine(model.CheckOilString());
                    break;
                case 2:
                    Console.WriteLine(model.CheckPersonalSettings());
                    break;
                case 3:
                    Console.WriteLine(model.TemperatureChoose() + model.UnitStringTemp());
                    break;
                case 4:
                    Console.WriteLine(model.TripChoose() + model.UnitStringDistance());
                    break;
                default:
                    break;


            }



        }

        public void ConsoleClear()
        {
            Console.Clear();
        }
            

        public void Start()
        {
            Console.WriteLine("Which mode would you like to enter?");
            Console.WriteLine("1) Simulation");
            Console.WriteLine("2) Regular Run");
        }

        public void ExceptionCatching(Exception ex)
        {
            ex.ToString();
            
        }

        


    }
}
