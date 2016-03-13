using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVIC_MVC
{
    class CONSOLE_CONTROLLER
    {
        

        static void Main(string[] args)
        {
            //creation of view object
            CONSOLE_VIEW _view = new CONSOLE_VIEW();

            //creation of model object
            EVIC_Model _model = new EVIC_Model();


            _view.Run(_model);
            _model.changeState(2);
            _view.Run(_model);
          




            //so it doesn't quit on it's own 
            Console.ReadLine();




        }
    }
}
