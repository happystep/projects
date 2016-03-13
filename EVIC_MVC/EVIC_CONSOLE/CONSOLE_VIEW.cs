using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVIC_MVC
{
    /// <summary>
    /// this is the view class for the console EVIC app
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
       /// <summary>
       /// This method displays the main menu
       /// </summary>
       /// <param name="model"></param>
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
        /// <summary>
        /// this method takes displaying of running the program in each menu
        /// </summary>
        /// <param name="model"></param>
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
        /// <summary>
        /// this method displays the menu start
        /// </summary>
        public void MenuStart()
        {
            Console.WriteLine("You chose the Regular Run. Use the <- -> arrows to navigate through the Main Menu");
        }
        /// <summary>
        /// this method clears the console
        /// </summary>
        public void ConsoleClear()
        {
            Console.Clear();
        }
        /// <summary>
        /// this method displays option 2 from the simulator
        /// </summary>
        public void SimOp2Show()
        {
            Console.WriteLine("Toggle Warning Messages");
            Console.WriteLine("a) Door ajar");
            Console.WriteLine("b) Check Engine Soon");
            Console.WriteLine("c) Oil Change");
        }
        /// <summary>
        /// this method displays option 3 from the simulator
        /// </summary>
        public void SimOp3Show()
        {
            Console.WriteLine("a) Inside Temperature");
            Console.WriteLine("b) Outside Temperature");
        }
        /// <summary>
        /// this displays the start menu
        /// </summary>
        public void Start()
        {
            Console.WriteLine("Which mode would you like to enter?");
            Console.WriteLine("1) Simulation");
            Console.WriteLine("2) Regular Run");
        }
        /// <summary>
        /// this displays an exception 
        /// </summary>
        /// <param name="ex"></param>
        public void ExceptionCatching(Exception ex)
        {
            ex.ToString();
            
        }
        /// <summary>
        /// this displays the simulator menu
        /// </summary>
        public  void SimulatorMenu()
        {
            Console.Clear();
            Console.WriteLine("1) System Status");
            Console.WriteLine("2) Warning Messages");
            Console.WriteLine("3) Temperature"); 
        }
    }//end class
}//end namespace
