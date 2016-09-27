using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using VelocityCoders.LotteryGame.BLL;
using VelocityCoders.LotteryGame.Models.Collections;
using VelocityCoders.LotteryGame.Models.Enums;
using VelocityCoders.LotteryGame.Models;
using Susie.Common.Extensions;

namespace VelocityCoders.LotteryGame.Webforms
{
    public partial class LotteryForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblFormMessage.Text = DateTime.Now.ToShortDateString(); 
            this.BindLotteryNavigation();
            this.BindLotteryName();
        }
        private void LotteryPageForm()
        {
            StringBuilder formValues = new StringBuilder();

            string lotteryName = drpLotteryName.Text;
            string lotteryNameAbbreviation = txtLotteryNameAbbreviation.Text;
            string howToPlay = txtHowToPlay.Text;
            string description = txtDescription.Text;

            //            formValues.Append("Game Name: " + gameName);
            //            formValues.Append("<br />");
            //            formValues.Append("Game Name Abbreviation: " + gameNameAbbreviation);
            //            formValues.Append("<br />");
            //            formValues.Append("How to Play: " + howToPlay);
            //            formValues.Append("<br />");
            //            formValues.Append("<Description: " + description);

            VelocityCoders.LotteryGame.Models.Lottery lotteryToSave 
                = new VelocityCoders.LotteryGame.Models.Lottery();

            //notes: specify lottery properties

            lotteryToSave.LotteryName = lotteryName;
            lotteryToSave.LotteryNameAbbreviation = lotteryNameAbbreviation;
            lotteryToSave.HowToPlay = howToPlay;
            lotteryToSave.Description = description;

            //notes: set Id's from hidden fields to determine insert/update
//            lotteryToSave.DrawingId = hidDrawingId.Value.ToInt();
            lotteryToSave.LotteryId = hidLotteryId.Value.ToInt();

            lblFormMessage.Text = formValues.ToString();
        }

        #region BIND CONTROLS

        private void BindLotteryNavigation()
        {
            lotteryNavigation.CurrentNavigationLink = LotteryNavigation.LotteryForm;
            lotteryNavigation.LotteryId = 1;
        }
        private void BindLotteryName()
        {
            LotteryCollection lotteryNameList = LotteryBLL.GetCollection(LotteryEnum.GetItemLotteryName);

            drpLotteryName.DataSource = lotteryNameList;
            drpLotteryName.DataBind();

            drpLotteryName.Items.Insert(0, new ListItem { Text="(Select Lottery Game)", Value ="0"});
        }
         
        #endregion

        #region EVENT HANDLERS
        protected void Save_Click(object sender, EventArgs e)
        {
            this.LotteryPageForm();
        }
        #endregion
    }
}