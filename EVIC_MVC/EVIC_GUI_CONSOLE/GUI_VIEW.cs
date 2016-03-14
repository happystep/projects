using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVIC_MVC
{
    class GUI_VIEW
    {
        /// <summary>
        /// this method enables all of the textboxes
        /// </summary>
        public void TextBoxDisabled(System.Windows.Forms.TextBox s, System.Windows.Forms.TextBox s2, System.Windows.Forms.TextBox s3, System.Windows.Forms.TextBox s4, System.Windows.Forms.TextBox s5, System.Windows.Forms.TextBox s6, System.Windows.Forms.TextBox s7, System.Windows.Forms.TextBox s8, System.Windows.Forms.TextBox s9)
        {
            s.ReadOnly = s2.ReadOnly = s3.ReadOnly = s4.ReadOnly = s5.ReadOnly = s6.ReadOnly = s7.ReadOnly = s8.ReadOnly = s9.ReadOnly = true;
        }
        /// <summary>
        /// this memethod enables all of the textboxes
        /// </summary>
        public void TextBoxEnabled(System.Windows.Forms.TextBox s, System.Windows.Forms.TextBox s2, System.Windows.Forms.TextBox s3, System.Windows.Forms.TextBox s4, System.Windows.Forms.TextBox s5, System.Windows.Forms.TextBox s6, System.Windows.Forms.TextBox s7, System.Windows.Forms.TextBox s8, System.Windows.Forms.TextBox s9)
        {
            s.ReadOnly = s2.ReadOnly = s3.ReadOnly = s4.ReadOnly = s5.ReadOnly = s6.ReadOnly = s7.ReadOnly = s8.ReadOnly = s9.ReadOnly = false;
        }
        /// <summary>
        /// setting the buttons to false reset
        /// </summary>
       
        public void ResetButtonVisibility(System.Windows.Forms.Button b , System.Windows.Forms.Button b2, System.Windows.Forms.Button b3, System.Windows.Forms.Button b4)
        {
            b.Visible = b2.Visible = b3.Visible = b4.Visible = false;
        }
        /// <summary>
        /// setting reset buttons to true
        /// </summary>
       
        public void ResetButtonVisibilityTrue(System.Windows.Forms.Button b, System.Windows.Forms.Button b2, System.Windows.Forms.Button b3, System.Windows.Forms.Button b4)
        {
            b.Visible = b2.Visible = b3.Visible = b4.Visible = true;
        }
        /// <summary>
        /// sets toggles button visibility to false
        /// </summary>
        
        public void ResetToggle(System.Windows.Forms.Button b, System.Windows.Forms.Button b2)
        {
            b.Visible = b2.Visible =  false;
        }
        /// <summary>
        /// sets toggle buttons visibilty to true
        /// </summary>
       
        public void ResetToggleTrue(System.Windows.Forms.Button b, System.Windows.Forms.Button b2)
        {
            b.Visible = b2.Visible = true;
        }



        /// <summary>
        /// this method resets the odometer
        /// </summary>
        /// <param name="s"></param>
        public void ResetOdometer(System.Windows.Forms.TextBox s)
        {

            s.Text = "0";


        }
        /// <summary>
        /// this method resets the oil change in 
        /// </summary>
        /// <param name="m"></param>
        /// <param name="s"></param>
        public void ResetNextOilChange(EVIC_Model m, System.Windows.Forms.TextBox s)
        {
            if (m.isMetric == true)
                        {
                         s.Text = "4828";
                        }
                        else if (m.isMetric == false)
                        {
                            s.Text = "3000";
                        }
        }
        /// <summary>
        /// resets trip A
        /// </summary>
        /// <param name="s"></param>
        public void ResetTripA(System.Windows.Forms.TextBox s)
        {

            s.Text = "0";


        }

        /// <summary>
        /// resets trip B
        /// </summary>
        /// <param name="s"></param>
        public void ResetTripB(System.Windows.Forms.TextBox s)
        {

            s.Text = "0";


        }




        /// <summary>
        /// method for setting the odometer in gui
        /// </summary>
        /// <param name="m"></param>
        /// <param name="s"></param>
        public void OdometerSetting(EVIC_Model m, System.Windows.Forms.TextBox s)
        {
            
              if (m.isMetric == false )
            {
                m.SetOdometer();
                s.Text = m.Odometer.ToString();

            }
            else if (m.isMetric == true)
            {
                m.SetOdometer();
                    s.Text = m.Odometer.ToString();

            }
              

        }

        /// <summary>
        /// method for setting the oil change in gui
        /// </summary>
        /// <param name="m"></param>
        /// <param name="s"></param>
        public void NextOilChangeSetting(EVIC_Model m, System.Windows.Forms.TextBox s)
        {
            if (m.isMetric == false)
            {
                m.SetOilChange();
                s.Text = m.MilesToOilChange.ToString();
            }
            else if (m.isMetric == true)
            {
                m.SetOilChange();
                s.Text = m.MilesToOilChange.ToString();
            }
                
        }
        /// <summary>
        /// method for setting the door ajar in gui
        /// </summary>
        /// <param name="m"></param>
        /// <param name="s"></param>
        public void DoorAjarSetting (EVIC_Model m, System.Windows.Forms.TextBox s)
        {
            if (m.DoorAjar == true)
            {
                s.Text = "On!";
            }
            else { s.Text = ""; }
        }
        /// <summary>
        /// method for setting the check engine soon
        /// </summary>
        /// <param name="m"></param>
        /// <param name="s"></param>
        public void CheckEngineSetting(EVIC_Model m, System.Windows.Forms.TextBox s)
        {
           if (m.CheckEngine == true)
            {
                s.Text = "On!";
            }
           else { s.Text = ""; }

        }
        /// <summary>
        /// method for setting the oilchange soon
        /// </summary>
        /// <param name="m"></param>
        /// <param name="s"></param>
        public void OilChangeSetting(EVIC_Model m, System.Windows.Forms.TextBox s)
        {
            if (m.OilChange == true)
            {
                s.Text = "On!";
            }
            else { s.Text = ""; }
        }
        /// <summary>
        /// method for setting the inside temperature
        /// </summary>
        /// <param name="m"></param>
        /// <param name="s"></param>
        public void InsideTemperatureSetting(EVIC_Model m , System.Windows.Forms.TextBox s)
        {
            if (m.isMetric == false)
            {
                m.SetInsideTemp();
                s.Text = m.InsideTemp.ToString();
            }
           else if (m.isMetric == true)
            {
                m.SetInsideTemp();
                s.Text = m.InsideTemp.ToString();
            }

        }
        /// <summary>
        /// method for setting the outside temperature
        /// </summary>
        /// <param name="m"></param>
        /// <param name="s"></param>
        public void OutsideTemperatureSetting(EVIC_Model m, System.Windows.Forms.TextBox s)
        {
            if (m.isMetric == false)
            {
                m.SetOusideTemp();
                s.Text = m.OutsideTemp.ToString();
            }
          else  if (m.isMetric == true)
            {
                m.SetOusideTemp();
                s.Text = m.OutsideTemp.ToString();
            }

        }
        /// <summary>
        /// method for setting TripA
        /// </summary>
        /// <param name="m"></param>
        /// <param name="s"></param>
        public void TripASetting(EVIC_Model m, System.Windows.Forms.TextBox s)
        {
            if (m.isMetric == false)
            {
                m.SetTripA();
                s.Text = m.TripA.ToString();
            }
          else  if (m.isMetric == true)
            {
                m.SetTripA();
                s.Text = m.TripA.ToString();
            }

        }
        /// <summary>
        /// method for setting TripB
        /// </summary>
        /// <param name="m"></param>
        /// <param name="s"></param>
        public void TripBSetting(EVIC_Model m, System.Windows.Forms.TextBox s)
        {
            if (m.isMetric == false)
            {
                m.SetTripB();
                s.Text = m.TripB.ToString();
            }
           else if (m.isMetric == true)
            {
                m.SetTripB();
                s.Text = m.TripB.ToString();
            }

        }

    }
}
