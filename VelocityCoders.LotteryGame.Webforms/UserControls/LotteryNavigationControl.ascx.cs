using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VelocityCoders.LotteryGame.Webforms.UserControls;

namespace VelocityCoders.LotteryGame.Webforms.UserControls
{
    public partial class LotteryNavigationControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindLotteryNavigation();
        }

        #region PROPERTIES
        public LotteryNavigation CurrentNavigationLink { get; set; }

        public int LotteryId { get; set; }

        #endregion

        #region #BIND CONTROLS

        private void BindLotteryNavigation()
        {
            ListItemCollection navigationList = new ListItemCollection();

            Array navigationValues = Enum.GetValues(typeof(LotteryNavigation));

            string lotteryIdQueryString = "LotteryId=" + this.LotteryId.ToString();
            
            if (this.LotteryId > 0)
            {
                foreach (LotteryNavigation item in navigationValues)
                {
                    if (item !=LotteryNavigation.None)
                    {
                        string displayValue = item.ToString();

                        if (item == this.CurrentNavigationLink)
                            navigationList.Add(new ListItem { Text = displayValue, Value = "", Enabled = false });
                        else
                            navigationList.Add(new ListItem
                            {
                                Text = displayValue,
                                Value = "~/Admin/Lottery" + item.ToString() + ".aspx?" + lotteryIdQueryString,
                                Enabled = true});

                        LotteryNavigationList.DataSource = navigationList;
                        LotteryNavigationList.DataBind();
                    }
                    

                }
            } 
        }
        #endregion

    }
}