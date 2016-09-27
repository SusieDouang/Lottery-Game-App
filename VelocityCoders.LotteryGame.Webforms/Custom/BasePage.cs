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
        
         public int DrawingId
        {
            get
            {
                return this.GetQueryStringNumber("DrawingId");
            }
        }

        public int LotteryId
        {
            get
            {
                return this.GetQueryStringNumber("LotteryId");
            }
        }
        
        #region

        #endregion


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
    }
}