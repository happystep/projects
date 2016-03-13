using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVIC_MVC
{
    /// <summary>
    /// This is the controller class for the console EVIC app
    /// </summary>
    class CONSOLE_CONTROLLER
    {
        /// <summary>
        /// this keeps track of what index in the program we are in
        /// </summary>
        private static int index = 0;
        //creation of view object
        private static CONSOLE_VIEW _view = new CONSOLE_VIEW();
        //creation of model object
       private static  EVIC_Model _model = new EVIC_Model();
        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            _view.Start();
            try {
                int answer = Convert.ToInt32(Console.ReadLine());
                if (answer == 1)
                {
                    _view.SimulatorMenu();
                   Simulator();
                }
                else if (answer == 2)
                {
                    _view.ConsoleClear();
                    _view.MenuStart();
                    _model.SetRandomValues();
                    while (true)
                    {
                        MainMenu();
                    }
                }
            }
            catch (Exception ex)
            {
                _view.ExceptionCatching(ex);
            }

        }
        /// <summary>
        /// This method takes care of the main menu
        /// </summary>
        public static void MainMenu()
        {
           
            ConsoleKeyInfo keypress = Console.ReadKey();

            switch (keypress.Key)
            {
                case ConsoleKey.LeftArrow:
                    MoveLeft();
                    break;
                case ConsoleKey.RightArrow:
                    MoveRight();
                    break;
                case ConsoleKey.UpArrow:
                    MoveUpDown();
                    break;
                case ConsoleKey.DownArrow:
                    MoveUpDown();
                    break;
                case ConsoleKey.Spacebar:
                    BarSpace();
                    break;
                default:
                    break;
            }

        }//end mainmenu
        // <summary>
        /// Moves and displays the main menu to the option to the left
        /// </summary>
        public static void MoveLeft()
        {
            _view.ConsoleClear();
            if (index == 0)
            {
                index = 4;
                
            }
            else
            {
                index--;
               
            }
            _model.changeState(index);
            _view.IndexChange = index;
            _view.Run(_model);
        }//end moveleft
        /// <summary>
        /// Moves and displays the main menu to the option to the right
        /// </summary>
        public static void MoveRight()
        {
            _view.ConsoleClear();
            if (index == 4)
            {
                index = 0;
              
            }
            else
            {
                index++;
                
            }
            _model.changeState(index);
            _view.IndexChange = index;
            _view.Run(_model);
        }


        public static void MoveUpDown()
        {
            switch (index)
            {
                case 0:
                    //systemtstatus

                    _model.ToggleSystem();
                    _view.RunInside(_model);
                    break;
                case 1:
                    //warning messages
                    _view.RunInside(_model);
                    break;
                case 2:
                    _view.RunInside(_model);
                    break;
                case 3:
                    _model.ToggleTemp();
                    _view.RunInside(_model);
                    break;
                case 4:
                    _model.ToggleTrip();
                    _view.RunInside(_model);
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// this method takes care of the spacebar use in the console app
        /// </summary>
        public static void BarSpace()
        {
            switch (index)
            {
                case 0:
                    _model.MilesToOilChange = 3000;
                    _view.RunInside(_model);
                    break;
                case 1:
                    //empty no functionality for it here
                    break;
                case 2:
                    _model.Toggle();
                    _model.changeUnit();
                    _model.SetOdometer();
                    _model.SetOilChange();
                    _model.SetOusideTemp();
                    _model.SetInsideTemp();
                    _model.SetTripA();
                    _model.SetTripB();
                    _view.RunInside(_model);
                    break;
                case 3:
                    //empty no functionality for it here
                    break;
                case 4:
                    _model.ResetTrip();
                    _view.RunInside(_model);
                    break;
            }
        }
        /// <summary>
        /// This method takes care of the simulator
        /// </summary>
        public static void Simulator()
        {
            int answer = Convert.ToInt32(Console.ReadLine());

            if (answer == 1)
            {
                option1();
            }
            else if (answer == 2)
            {
              option2();
            }
            else if (answer == 3)
            {
               option3();
            }
        }
        /// <summary>
        /// option 1 for the simulator
        /// </summary>
        public static void option1()
        {
            _view.ConsoleClear();
            _model.SetRandomValues();
            while (true)
            {
                
                index = 0;
                _model.changeState(index);
                _view.IndexChange = index;
                _view.RunInside(_model);
                ConsoleKeyInfo keypress = Console.ReadKey();
               
                switch (keypress.Key)
                {
                    case ConsoleKey.Enter:
                        _model.StatusIncrement();
                        _view.RunInside(_model);
                        break;
                    case ConsoleKey.UpArrow:
                        MoveUpDown();
                        break;
                    case ConsoleKey.DownArrow:
                        MoveUpDown();
                        break;
                    default:
                        break;
                }
            }
        }
        /// <summary>
        /// option 2 for the simulator
        /// </summary>
        public static void option2()
        {
            _view.ConsoleClear();
            _model.SetRandomValues();
            
            index = 1;
            _model.changeState(index);
            _view.IndexChange = index;
            

            _view.SimOp2Show();

            while (true)
            {
                bool a = false;
                bool b = false;
                bool c = false;
                
                char answer = Convert.ToChar(Console.ReadLine());

                if (answer == 'a')
                {
                    a = true;
                }
                else if (answer == 'b')
                {
                    b = true;
                }
                else if (answer == 'c')
                {
                    c = true;
                }

                _model.SetWarningSimulator(a, b, c);
                _view.RunInside(_model);

            }

        }
        /// <summary>
        /// option 3 for the simulator
        /// </summary>
        public static void option3()
        {
            _view.ConsoleClear();
            _model.SetRandomValues();

            index = 3;
            _model.changeState(index);
            _view.IndexChange = index;

            _view.SimOp3Show();
            char answer = Convert.ToChar(Console.ReadLine());
            
            while(true)
            {
                if (answer == 'a')
                {
                    Console.WriteLine("Please enter a value in F"
                        + "ahrenheit for the Inside temperature:");
                    int insideTemp = Convert.ToInt32(Console.ReadLine());

                    _model.InsideTemp = insideTemp;

                    _view.RunInside(_model);

                }
                else if (answer == 'b')
                {
                    Console.WriteLine("Please enter a value in F"
                        + "ahrenheit for the Outside temperature:");


                    int OutsideTemp = Convert.ToInt32(Console.ReadLine());
                    _model.OutsideTemp = OutsideTemp;

                    _model.ToggleTemp();
                    _view.RunInside(_model);
                }
            }
        }
    }//end class
}//end namsepace
