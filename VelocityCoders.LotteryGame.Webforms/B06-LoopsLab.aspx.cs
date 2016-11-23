using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VelocityCoders.LotteryGame.Webforms
{
    public partial class B06_LoopsLab : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)

        {
            this.ForLoopLab();
            this.ForEachLoop();
            this.WhileLoopLab();
            this.DoLoopLab();
        }

        private void ForLoopLab()
        {
            StringBuilder sb = new StringBuilder();

            #region FOR LOOP
            for (int x = 0; x <= 8; x++)

                sb.Append(x.ToString() + " ");

            Loop1.Text = sb.ToString();

            #endregion
        }



        private void ForEachLoop()
        {
            #region FOR EACH LOOP
            StringBuilder sb = new StringBuilder();

            string[] stringArray = new string[] { "Cats", "Dogs", "Rabbits", "Snakes" };

            sb = new StringBuilder();

            foreach (string item in stringArray)

                sb.Append(item + "</br>");

            Loop2.Text = sb.ToString();

            #endregion
        }

        private void WhileLoopLab()
        {
            #region WHILE LOOP
            StringBuilder sb = new StringBuilder();
            int[] intArray = new int[] { 2, 4, 6, 0, 8, 10, 12, 20, 30, 40, 50 };
            bool keepGoing = true;
            int count = 5;

            sb = new StringBuilder();

            while (keepGoing)
            {
                sb.Append(intArray[count].ToString() + "<br>");
                keepGoing = (intArray[count] == 12) ? false : true;

                count++;
            }
            #endregion

            Loop3.Text = sb.ToString();
        }

        private void DoLoopLab()
        {
            #region DO LOOP
            StringBuilder sb = new StringBuilder();

            int y = 5;
            sb = new StringBuilder();

            do
            {
                sb.Append(y.ToString() + "<br>");
                y++;
            } while (y < 25);

            #endregion

            Loop4.Text = sb.ToString(); 
        }
  
      }
}
    

