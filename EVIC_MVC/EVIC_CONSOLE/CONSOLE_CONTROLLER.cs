using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVIC_MVC
{
    class CONSOLE_CONTROLLER
    {
        private static int index = 0;

        //creation of view object
        private static CONSOLE_VIEW _view = new CONSOLE_VIEW();

        //creation of model object
       private static  EVIC_Model _model = new EVIC_Model();

        static void Main(string[] args)
        {

            _view.Start();
            try {
                int answer = Convert.ToInt32(Console.ReadLine());
                if (answer == 1)
                {

                }
                else if (answer == 2)
                {
                    Console.Clear();
                    Console.WriteLine("You chose the Regular Run. Use the <- -> arrows to navigate through the Main Menu");
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



    }
}
