using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VelocityCoders.LotteryGame.Webforms
{
    public partial class B03 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)

        {
            this.StringExample();
        }

        private void StringExample()
        {
            string firstName = "Susie";
            string lastName;

            firstName = "Susie";
            lastName = "Douang";

            string firstLetter = firstName.Substring(0, 1);

            int myAge = 30;
            int myfavoriteAge = 22;
            DateTime myBirthdate = new DateTime(1990, 4, 1);
            DateTime todaysDate = new DateTime(2016, 8, 8);

            string allInfo = firstName + "," + lastName + "," + myAge.ToString();

            line1.Text = "Name: " + firstLetter + " " + lastName; 
            line2.Text = "Name: " + myAge + " and " + myfavoriteAge;
            line3.Text = "Name: " + myBirthdate.ToShortDateString() + " " + todaysDate.ToShortDateString();


            //notes: StringBuilder

            StringBuilder sbLoopString = new StringBuilder();
            sbLoopString.Append("Count: ");

            for (int x = 1; x <= 20; x++)
            {
            //notes: this line appends the values to StringBuilder object
                sbLoopString.Append(x.ToString());
            }

            //notes: output as string
            sbLoopString.ToString();

            line4.Text = sbLoopString.ToString();

            StringBuilder sb = new StringBuilder();
            sb.Append("My Name");
            sb.Append("Hello");

            line4.Text = sb.ToString(); 
            
            string hey = "myName";
            hey = "Hello";
            line3.Text = hey;




        }
    }
}
