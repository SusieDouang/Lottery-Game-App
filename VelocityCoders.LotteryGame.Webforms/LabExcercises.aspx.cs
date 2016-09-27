using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VelocityCoders.LotteryGame.Webforms
{
    public partial class LabExcercises : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
         
        {
            string fullName = this.GetFullName("Susie", "Douang");

            lblDisplayMessage.Text = fullName;
            this.DisplayName(lblDisplayMessage, "Name: " + fullName);

            int numbers = this.GetNumber(15);
            this.DisplayName(lblDisplayMessage02, numbers);

        }
        private void DisplayName(Label labelControl, string DisplayMessage)
        {
            labelControl.Text = DisplayMessage;
        }
        
       private void DisplayName(Label labelControl, int displayMessage)
       {
           labelControl.Text = displayMessage.ToString();
       } 

        private string GetFullName(string firstName, string lastName)
        {
        //    string fullName = firstName + " " + lastName;

            return firstName + " " + lastName;
        }

        private int GetNumber(int number)
        {
            int numberTwo = 2;
            return numberTwo * number;
        }
                
    }
}