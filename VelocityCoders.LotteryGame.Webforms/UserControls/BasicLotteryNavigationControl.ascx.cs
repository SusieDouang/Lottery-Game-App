using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VelocityCoders.LotteryGame.Webforms.UserControls
{
    public partial class BasicLotteryNavigationControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindBasicLotteryNavigation();
        }

        #region PROPERTIES

        public BasicLotteryNavigation BasicNavigationLink { get; set; }

        public int LotteryId { get; set; }
        public int DrawingId { get; set; }
        public int WinningNumberId { get; set; }

        #endregion

        #region BIND CONTROLS

        private void BindBasicLotteryNavigation()
        {
            ListItemCollection navigationList = new ListItemCollection();

            Array navigationValues = Enum.GetValues(typeof(BasicLotteryNavigation));
               
            string lotteryIdQueryString = "LotteryId=" + this.LotteryId.ToString();
            string drawingIdQueryString = "DrawingId=" + this.DrawingId.ToString();
            string winningNumberIdQueryString = "WinningNumberId=" + this.WinningNumberId.ToString();

            #region Single ID for Multiple Webforms

            //if (this.LotteryId > 0)
            //{
            //    foreach (BasicLotteryNavigation item in navigationValues)
            //    {
            //        if (item != BasicLotteryNavigation.None)
            //        {
            //            string displayValue = item.ToString();
            //            if (item == BasicLotteryNavigation.Lottery)
            //            {
            //                basicnavigationList.Add(new ListItem
            //                {
            //                    Text = displayValue,
            //                    Value = "~/Admin/BasicLottery/" + displayValue.ToString() + ".aspx?" + lotteryIdQueryString,
            //                    Enabled = true
            //                });
            //            }

            //            if (this.DrawingId > 0)
            //            { 
            //            else if (item == BasicLotteryNavigation.Drawing)
            //                {
            //                    basicnavigationList.Add(new ListItem
            //                    {
            //                        Text = displayValue,
            //                        Value = "~/Admin/BasicLottery/" + displayValue.ToString() + ".aspx?" + drawingIdQueryString,
            //                        Enabled = true
            //                    });
            //                }
            //            }

            //            if (item == BasicLotteryNavigation.Number)
            //            {
            //                basicnavigationList.Add(new ListItem
            //                {
            //                    Text = displayValue,
            //                    Value = "~/Admin/BasicLottery/" + displayValue.ToString() + ".aspx?" + winningNumberIdQueryString,
            //                    Enabled = true
            //                });

            //                //else
            //                //navigationList.Add(new ListItem { Text = displayValue, Value = "", Enabled = false });
            //            }
            //        }
            //    }
            //    BasicLotteryNavigationList.DataSource = basicnavigationList;
            //    BasicLotteryNavigationList.DataBind();

            #endregion

            #region Multiple Id for Multiple Webforms
            if (this.LotteryId > 0)
            {
                //iterate over enum values
                foreach (BasicLotteryNavigation item in navigationValues)
                {
                    if (item != BasicLotteryNavigation.None)
                    {
                        string displayValue = item.ToString();

                        if (item == BasicLotteryNavigation.Lottery)
                        {
                            navigationList.Add(new ListItem
                            {
                                Text = displayValue,
                                Value = "~/Admin/BasicLottery/BasicLotteryForm" + ".aspx?" + lotteryIdQueryString,
                                Enabled = true
                            });
                        }

                            if (item == BasicLotteryNavigation.Drawing)
                            {
                                navigationList.Add(new ListItem
                                {
                                    Text = displayValue,
                                    Value = "~/Admin/BasicLottery/BasicDrawingForm" + ".aspx?" + drawingIdQueryString,
                                    Enabled = true
                                });
                           }

                        if (item == BasicLotteryNavigation.Number)
                        {
                            navigationList.Add(new ListItem
                            {
                                Text = displayValue,
                                Value = "~/Admin/BasicLottery/BasicWinningForm" + ".aspx?" + winningNumberIdQueryString,
                                Enabled = true
                            });
                        }

                        if (item == BasicLotteryNavigation.Results)
                        {
                            navigationList.Add(new ListItem
                            {
                                Text = displayValue,
                                Value = "~/Admin/BasicLottery/BasicWinningResults" + ".aspx?" + drawingIdQueryString + "&" + lotteryIdQueryString,
                                Enabled = true
                            });
                        }
                        
                    }
                }
            }
          
            //bind list object to front-end control
            BasicLotteryNavigationList.DataSource = navigationList;
            BasicLotteryNavigationList.DataBind();

            #endregion

        }
    }
        #endregion
}