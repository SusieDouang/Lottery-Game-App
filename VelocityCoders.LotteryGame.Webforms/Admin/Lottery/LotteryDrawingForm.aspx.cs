using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using VelocityCoders.LotteryGame.Models;
using VelocityCoders.LotteryGame.Models.Collections;
using VelocityCoders.LotteryGame.Models.Enums;
using VelocityCoders.LotteryGame.BLL;
using Susie.Common.Extensions;


namespace VelocityCoders.LotteryGame.Webforms.Admin.Lottery
{
    public partial class LotteryDrawingForm : BasePage 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindDrawingNavigation();
            lblFormMessage.Text = DateTime.Now.ToShortDateString();
            this.BindLotteryDrawing();
            this.BindLotteryName();
            this.CheckUpdate();

            int queryStringValue = base.DrawingId;
        }

        private void CheckUpdate()
        {
            if (base.DrawingId > 0)
            {
                //notes:   in update mode with existence of instructor id
                //         check to see if record exists in the database
                VelocityCoders.LotteryGame.Models.Drawing drawingToUpdate =
                DrawingBLL.GetDrawing(base.DrawingId);

                if (drawingToUpdate != null)
                {
                    this.BindUpdateInfo(drawingToUpdate);
                    this.SetButtons(true);
                }
                else
                    this.SetButtons(false);
            }
            else
                this.SetButtons(false);
        }

        private void ProcessForm()
        {
            StringBuilder formValues = new StringBuilder();

            string drawingDate = drpDrawingDate.Text;
            string jackpotAmount = txtJackpotAmount.Text;
//          string cashOptionsAmount = txtCashOptionAmount.Text;
//            string multiplier = txtMultiplier.Text;

            formValues.Append("Drawing Date: " + drawingDate);
            formValues.Append("<br />");
            formValues.Append("Jackpot Amount: " + jackpotAmount);
            formValues.Append("<br />");
//          formValues.Append("Cash Options Amount: " + cashOptionsAmount);
//          formValues.Append("<br />");
//          formValues.Append("Any Multipliers?: " + multiplier);
//          formValues.Append("<br />");

            VelocityCoders.LotteryGame.Models.Drawing drawingToSave 
                = new VelocityCoders.LotteryGame.Models.Drawing();

            //notes: set Id's from hidden fields to determine insert/update
            drawingToSave.DrawingId = hidDrawingId.Value.ToInt();
            drawingToSave.LotteryId = hidLotteryId.Value.ToInt();

            lblFormMessage.Text = formValues.ToString();
        }

        #region BIND CONTROLS

        private void BindDrawingNavigation()
        {

            drawingNavigation.DrawingNavigationLink = DrawingNavigation.LotteryDrawingForm;
            drawingNavigation.DrawingId = 1;
        }

        private void BindLotteryName()
        {
            LotteryCollection lotteryNameList = LotteryBLL.GetCollection(LotteryEnum.GetItemLotteryName);

            drpGameNameDraw.DataSource = lotteryNameList;
            drpGameNameDraw.DataBind();

            drpGameNameDraw.Items.Insert(0, new ListItem { Text = "(Select Lottery Game)", Value = "0" });
        }

        private void BindLotteryDrawing()
        {
            DrawingCollection drawingList = DrawingBLL.GetCollection(LotteryDrawingEnum.GetItemOrderByDate);
            drpDrawingDate.DataSource = drawingList;
            drpDrawingDate.DataBind();

            drpDrawingDate.Items.Insert(0, new ListItem { Text="(Select Date)", Value="0"});
        }

        private void BindUpdateInfo(VelocityCoders.LotteryGame.Models.Drawing drawingToUpdate)
        {
            //notes: populate form fields for update

            if (drawingToUpdate.LotteryName != null)
                drpGameNameDraw.SelectedValue = drawingToUpdate.LotteryName;

            if (drawingToUpdate.DrawingDate != DateTime.MinValue)
                drpDrawingDate.SelectedValue = drawingToUpdate.DrawingDate.ToShortDateString();

            if (drawingToUpdate.Jackpot != 0)
                txtJackpotAmount.Text = drawingToUpdate.Jackpot.ToString();

//            if (drawingToUpdate.SpecialBall != 0)
//                txtMultiplier.Text = drawingToUpdate.SpecialBall.ToString();

            //notes: update the text of the button
            btnSave.Text = "Update Lottery Drawing";
        }

        #endregion

        #region BUTTONS

        private void SetButtons(bool isUpdate)
        {
            if (isUpdate)
            {
                //notes: update the text of the button
                btnSave.Text = "Update Lottery Drawing";
                btnCancel.Visible = true;
            }
            else
            {
                btnSave.Text = "Add Lottery Drawing";
                btnCancel.Visible = false;
            }
        }
        #endregion

        #region EVENT HANDLERS

        protected void Save_Click(object sender, EventArgs e)
        {
            this.ProcessForm();
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("LotteryDrawingForm.aspx");
        }
        #endregion
    }
}
