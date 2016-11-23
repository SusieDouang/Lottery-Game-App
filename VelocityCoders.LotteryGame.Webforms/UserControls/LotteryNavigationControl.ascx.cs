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
        public int DrawingId { get; set; }
        public int WinningNumberId { get; set; }

        #endregion

        #region #BIND CONTROLS

        private void BindLotteryNavigation()
        {
            ListItemCollection navigationList = new ListItemCollection();

            Array navigationValues = Enum.GetValues(typeof(LotteryNavigation));

            string lotteryIdQueryString = "LotteryId=" + this.LotteryId.ToString();
            string drawingIdQueryString = "DrawingId=" + this.DrawingId.ToString();
            string winningNumberIdQueryString = "LotteryId=" + this.LotteryId.ToString();

            if (this.LotteryId > 0)
            {
                foreach (LotteryNavigation item in navigationValues)
                {
                    if (item != LotteryNavigation.None)
                    {
                        string displayValue = item.ToString();

                        if (item == LotteryNavigation.LotteryForm)
                        {
                            navigationList.Add(new ListItem
                            {
                                Text = displayValue,
                                Value = "~/Admin/Lottery/" + displayValue.ToString() + ".aspx?" + lotteryIdQueryString,
                                Enabled = true
                            });
                        }
                        
                        else if (item == LotteryNavigation.LotteryDrawingForm)
                        {
                            navigationList.Add(new ListItem
                            {
                                Text = displayValue,
                                Value = "~/Admin/Lottery/" + displayValue.ToString() + ".aspx?" + drawingIdQueryString,
                                Enabled = true
                            });
                        }

                        if (item == LotteryNavigation.WinningNumberForm)
                        {
                            navigationList.Add(new ListItem
                            {
                                Text = displayValue,
                                Value = "~/Admin/Lottery/" + displayValue.ToString() + ".aspx?" + winningNumberIdQueryString,
                                Enabled = true
                            });

                            //else
                            //navigationList.Add(new ListItem { Text = displayValue, Value = "", Enabled = false });
                        }
                    }                    
                }
                LotteryNavigationList.DataSource = navigationList;
                LotteryNavigationList.DataBind();
            }
        }
        #endregion

    }
}