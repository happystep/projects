using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EVIC_MVC
{
    public partial class Gui : Form
    {
        EVIC_Model _model = new EVIC_Model();
        GUI_VIEW _view = new GUI_VIEW();

        bool _run = false;
        bool _edited = false;
        public Gui()
        {
            //sets random numbers for the fields in the model
            _model.SetRandomValues();

            InitializeComponent();
            RunAlone();
            
        }

        public void RunAlone()
        {

            if (_run == false)
            {
                //setting all readonly
                _view.TextBoxDisabled(uxOdometerText, uxNextOilChangeInText, uxDoorAjarTextbox, uxCheckEngineSoonText, uxOilChangeText, uxInsideTemperatureText, uxOutsideTemperatureText, uxTripAText, uxTripBText);

                //setting reset buttons to invisible
                _view.ResetButtonVisibility(uxResetButton, uxResetOil, uxResetTripA, uxResetTripB);

                //setting toggle buttons to invisible
                _view.ResetToggle(uxDoorToggle, uxEngineToggle);

                //setting the odometer
                _view.OdometerSetting(_model, uxOdometerText);

                //setting the oil change
                _view.NextOilChangeSetting(_model, uxNextOilChangeInText);

                //setting the door ajar
                _view.DoorAjarSetting(_model, uxDoorAjarTextbox);

                //setting the check engine
                _view.CheckEngineSetting(_model, uxCheckEngineSoonText);

                //setting the oil change 
                _view.OilChangeSetting(_model, uxOilChangeText);

                //setting insidetemprature text
                _view.InsideTemperatureSetting(_model, uxInsideTemperatureText);

                //setting outisde tempreature text
                _view.OutsideTemperatureSetting(_model, uxOutsideTemperatureText);
                //setting trip a text
                _view.TripASetting(_model, uxTripAText);

                //setting trip b text
                _view.TripBSetting(_model, uxTripBText);
            }
            else if (_run == true)
            {
                _model.Odometer = Convert.ToInt32(uxOdometerText.Text);
                //setting the odometer
                _view.OdometerSetting(_model, uxOdometerText);

                _model.MilesToOilChange = Convert.ToInt32(uxNextOilChangeInText.Text);
                //setting the oil change
                _view.NextOilChangeSetting(_model, uxNextOilChangeInText);

                
                //setting the door ajar
                _view.DoorAjarSetting(_model, uxDoorAjarTextbox);

                //setting the check engine
                _view.CheckEngineSetting(_model, uxCheckEngineSoonText);

                //no needing to change, as it is always contingent on how many miles until oilchange
                //setting the oil change 
                _view.OilChangeSetting(_model, uxOilChangeText);

                _model.InsideTemp = Convert.ToInt32(uxInsideTemperatureText.Text);
                //setting insidetemprature text
                _view.InsideTemperatureSetting(_model, uxInsideTemperatureText);

                _model.OutsideTemp = Convert.ToInt32(uxOutsideTemperatureText.Text);
                //setting outisde tempreature text
                _view.OutsideTemperatureSetting(_model, uxOutsideTemperatureText);

                _model.TripA = Convert.ToDouble(uxTripAText.Text);
                //setting trip a text
                _view.TripASetting(_model, uxTripAText);

                _model.TripB = Convert.ToDouble(uxTripBText.Text);
                //setting trip b text
                _view.TripBSetting(_model, uxTripBText);




            }
        }
        /// <summary>
        /// event handler for radio buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxUSUnitRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            _model.Toggle();
            _model.ToggleSystem();
            _model.changeUnit();
           
          RunAlone();



        }
        /// <summary>
        /// event handler for edit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxEditButton_Click(object sender, EventArgs e)
        {
            if (_edited == false)
            {
                _edited = true;
                _run = true;
                
                _view.TextBoxEnabled(uxOdometerText, uxNextOilChangeInText, uxDoorAjarTextbox, uxCheckEngineSoonText, uxOilChangeText, uxInsideTemperatureText, uxOutsideTemperatureText, uxTripAText, uxTripBText);
                _view.ResetButtonVisibilityTrue(uxResetButton, uxResetOil, uxResetTripA, uxResetTripB);
                _view.ResetToggleTrue(uxDoorToggle, uxEngineToggle);


            }
            else if (_edited == true)

            {
                _edited = false;
                _view.TextBoxDisabled(uxOdometerText, uxNextOilChangeInText, uxDoorAjarTextbox, uxCheckEngineSoonText, uxOilChangeText, uxInsideTemperatureText, uxOutsideTemperatureText, uxTripAText, uxTripBText);
                _view.ResetButtonVisibility(uxResetButton, uxResetOil, uxResetTripA, uxResetTripB);
                _view.ResetToggle(uxDoorToggle, uxEngineToggle);

            }
        }
        /// <summary>
        /// odometer reset button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxResetButton_Click(object sender, EventArgs e)
        {
            _view.ResetOdometer(uxOdometerText);
            
        }
        /// <summary>
        /// oilchange reset button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxResetOil_Click(object sender, EventArgs e)
        {
            _view.ResetNextOilChange(_model, uxNextOilChangeInText);
        }

        /// <summary>
        /// trip A reset button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxResetTripA_Click(object sender, EventArgs e)
        {
            _view.ResetTripA(uxTripAText);
        }
        /// <summary>
        /// trip B reset button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxResetTripB_Click(object sender, EventArgs e)
        {
            _view.ResetTripB(uxTripBText);
        }
        /// <summary>
        /// door toggle method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxDoorToggle_Click(object sender, EventArgs e)
        {
            if (_model.DoorAjar == false)
            {
                _model.DoorAjar = true;
            }
            else if (_model.DoorAjar == true)
            {
                _model.DoorAjar = false;
            }
            _view.DoorAjarSetting(_model, uxDoorAjarTextbox);
        }
        /// <summary>
        /// engine toggle method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxEngineToggle_Click(object sender, EventArgs e)
        {
            if (_model.CheckEngine == false)
            {
                _model.CheckEngine = true;
            }
            else if (_model.CheckEngine == true)
            {
                _model.CheckEngine = false;
            }
            _view.CheckEngineSetting(_model, uxCheckEngineSoonText);

        }
    }
}
