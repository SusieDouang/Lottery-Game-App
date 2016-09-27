using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VelocityCoders.LotteryGame.Webforms
{
    public partial class B04_ArraysLab : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ArrayLab();
        }

        private void ArrayLab()
        {
            string[] friendsList = new string [10];
            friendsList[0] = "Sonja";
            friendsList[1] = "Andy";
            friendsList[2] = "NickyT";
            friendsList[3] = "Darryl";
            friendsList[4] = "Shereen";
            friendsList[5] = "Ren";
            friendsList[6] = "Langen";
            friendsList[7] = "Holly";
            friendsList[8] = "Brianna";
            friendsList[9] = "Shane";

            array1.Text = string.Join(", ", friendsList);

            int[] ages = new int[] { 35, 28, 31, 31, 30, 29, 27, 36, 29, 40 };

            array2.Text = string.Join(", ", ages);
        }

    }
}
