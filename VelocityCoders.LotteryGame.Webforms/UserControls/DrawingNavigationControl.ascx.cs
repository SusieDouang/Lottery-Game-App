using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VelocityCoders.LotteryGame.Webforms.UserControls
{
    public partial class DrawingNavigationControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindDrawingNavigation();
        }

        #region PROPERTIES
        public DrawingNavigation DrawingNavigationLink { get; set; }

        public int DrawingId { get; set; }

        #endregion

        #region #BIND CONTROLS

        private void BindDrawingNavigation()
        {
            ListItemCollection navigationList = new ListItemCollection();

            Array navigationValues = Enum.GetValues(typeof(DrawingNavigation));

            string drawingIdQueryString = "DrawingId=" + this.DrawingId.ToString();

            if (this.DrawingId > 0)
            {
                foreach (DrawingNavigation item in navigationValues)
                {
                    if (item != DrawingNavigation.None)
                    {
                        string displayValue = item.ToString();

                        if (item == this.DrawingNavigationLink)
                            navigationList.Add(new ListItem { Text = displayValue, Value = "", Enabled = false });
                        else
                            navigationList.Add(new ListItem
                            {
                                Text = displayValue,
                                Value = "~/Admin/Lottery/" + item.ToString() + ".aspx?" + drawingIdQueryString,
                                Enabled = true
                            });

                        DrawingNavigationList.DataSource = navigationList;
                        DrawingNavigationList.DataBind();
                    }

                }
            }
        }
        #endregion

    }
}