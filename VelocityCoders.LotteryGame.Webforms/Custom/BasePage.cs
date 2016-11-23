using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Susie.Common;
using Susie.Common.Extensions;

namespace VelocityCoders.LotteryGame.Webforms
{
    public class BasePage : System.Web.UI.Page
    {
        ///<summary>
        /// Gets Id from DrawingId QueryString. If not found, returns 0.
        ///</summary>

        #region GET QUERY STRING NUMBER

        ///<summary>
        /// Attemp to retrieve a numeric value from the querystring.
        /// If invaild querystring name or value is not an integer, returns 0.
        ///</summary>
        ///<param name="queryStringName">Name of the QueryString name/value pair.</param>
        ///<returns> Integer Value</returns>

        public int GetQueryStringNumber(string queryStringName)
        {
            if (Request.QueryString[queryStringName] == null)
            {
                //notes: return 0 if invaild query string
                return 0;
            }
            else
            {
                //notes: call extension method to check for vaild integer value
                return Request.QueryString[queryStringName].ToInt();
            }
        }
        #endregion

        #region GET QUERY STRING NUMBER - DRAWING ID
        public int DrawingId
        {
            get
            {
                return this.GetQueryStringNumber("DrawingId");
            }
        }
        #endregion

        #region GET QUERY STRING NUMBER - LOTTERY ID
        public int LotteryId
        {
            get
            {
                return this.GetQueryStringNumber("LotteryId");
            }
        }
        #endregion

        #region GET QUERY STRING NUMBER - WINNING NUMBER ID

        public int WinningNumberId
        {
            get
            {
                return this.GetQueryStringNumber("WinningNumberId");
            }
        }

        #endregion

        #region GET QUERY STRING - BALL TYPE ID

        public int BallTypeId
        {
            get
            {
                return this.GetQueryStringNumber("BallTypeId");
            }
        } 

        #endregion


        ///<summary>
        /// Pass in the <asp:Label> control to set its text property. Set isAppend to true if you want the message to be concatenated.
        /// </summary>
        /// <param name="labelControl"></param>
        /// <param name="messageToDisplay"/</param>
        /// <param name="isAppend"></param>

        #region DISPLAY PAGE MESSAGE CONTROL

        public void DisplayPageMessage(Label labelControl, string messageToDisplay)
        {
            this.DisplayPageMessage(labelControl, messageToDisplay, false);
        }

        public void DisplayPageMessage(Label labelControl, string messageToDisplay, bool isAppend)
        {
            if (isAppend)
                labelControl.Text = messageToDisplay;
            else
                labelControl.Text = messageToDisplay;
        }

        #endregion
    }

}