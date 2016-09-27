using System;
using System.Text; 
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VelocityCoders.LotteryGame.Webforms
{
    public partial class B05 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.numbers();
            this.characters();
            this.dates();
            this.February();
            this.SwitchLab();
        }

        private void numbers()
        {
            string outputMessage = string.Empty;
            int myAge = 30;

            if (myAge > 70)
                outputMessage = "I'm a grandma.";
            else
            {
                if (myAge >= 11 && myAge <= 21)
                    outputMessage = "YOLO?";
                else
                    outputMessage = "Do you even know what YOLO means?";
            }


            condition1.Text = outputMessage;
        }

        private void characters()
        {
            string outputMessage = string.Empty;

            string myCatsName = "Cosmo";
            string yourCatsName = "Something else";

            if (myCatsName == yourCatsName)
                outputMessage = "Cute!!!!";
            else

            if (myCatsName != yourCatsName)
                outputMessage = "Hi, my kitty's name is Cosmo";

            condition2.Text = outputMessage;
        }

        #region CONDITIONAL OPERATOR
        private void dates()
        {
            string outputMessage = string.Empty;

            DateTime todaysDate = new DateTime(2016, 08, 09);
            DateTime newYearsDay = new DateTime(2017, 01, 01);

            if (todaysDate == newYearsDay)
                outputMessage = "Everyday is a party!";
            else
            {
                if (newYearsDay != todaysDate)
                    outputMessage = "New Year's Day is special";
                #endregion
                condition3.Text = outputMessage;
            }
        }

        #region FEBRUARY IF/ELSE
        private void February()
        {
            string outputMessage = string.Empty;

            DateTime catsBirthday = new DateTime(2008, 02, 01);
            string myCat = "Cosmo";
            string yourCat = "Something else";

            if (myCat != catsBirthday.ToShortDateString())
            {
                outputMessage = catsBirthday.ToShortDateString();

                condition4.Text = outputMessage;
            }
            else
            {
                if (yourCat != "Something else")
                    outputMessage = "Does your cat have a February Birthday?";

                condition4.Text = outputMessage;
            }
            #endregion

            #region NULL COALESCING OPERATOR
            string nullVariable = null;

            outputMessage = nullVariable ?? "Value is null.";
        }
        #endregion

        #region SWITCH 

        private void SwitchLab()
        {
            string userInput = txtRestFood.Text;
            string outputMessage = string.Empty;
          {
                switch (userInput)
                {
                    case "Subway":
                    case "Jimmy John's":
                    case "Milo's":
                        outputMessage = "Sandwiches";
                        break;

                    case "Burger King":
                    case "McDonald's":
                    case "Wendy's":
                        outputMessage = "Burgers";
                        break;

                    case "Dairy Queen":
                    case "Jamba Juice":
                        outputMessage = "Frozen Treats";
                        break;

                    case "Taco Bell":
                    case "Taco John's":
                        outputMessage = "Mexican";
                        break;

                    default:
                        outputMessage = "I don't know what you're eating anymore.";
                        break;
                }
                        condition5.Text = "You're eating: " + userInput + " - " + outputMessage;
             }
        }

        #endregion



    }
}

    




    
