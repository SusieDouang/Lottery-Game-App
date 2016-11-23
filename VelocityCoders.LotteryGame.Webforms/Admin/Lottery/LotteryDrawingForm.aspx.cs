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
            int queryStringValue = base.DrawingId;
            // this.BindDrawingNavigation();

            this.CheckUpdate();
            this.BindLotteryNavigation();


            if (!IsPostBack)
            {
                lblFormMessage.Text = DateTime.Now.ToShortDateString();

                this.BindLotteryName();
                this.BindLotteryDrawing();
                this.BindDrawingList();
            }
        }

        #region CHECK UPDATE
        private void CheckUpdate()
        {
            if (base.DrawingId > 0)
            {
                //notes:   in update mode with existence of drawing id
                //         check to see if record exists in the database
                VelocityCoders.LotteryGame.Models.Drawing drawingToUpdate = DrawingBLL.GetDrawing(base.DrawingId);

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
        #endregion

        #region PROCESS FORM
        private void ProcessForm()
        {
            StringBuilder formValues = new StringBuilder();

            string lotteryName = drpGameNameDraw.Text;
            string drawingDate = txtDrawingDate.Text;
            //string drawingId = txtDrawingId.Text;
            string jackpot = txtJackpotAmount.Text;
            //string cashOptionsAmount = txtCashOptionAmount.Text;
            //string multiplier = txtMultiplier.Text;
            string number = txtNumber.Text;
            //string number2 = txtWinningNumber2.Text;
            //string number3 = txtWinningNumber3.Text;
            //string number4 = txtWinningNumber4.Text;
            //string number5 = txtWinningNumber5.Text;
            //string specialBall = txtWinningNumber6.Text;

            formValues.Append("Lottery Name: " + lotteryName);
            formValues.Append("<br />");
            //formValues.Append("Drawing Id: " + drawingId);
            formValues.Append("Drawing Date: " + drawingDate);
            formValues.Append("<br />");
            formValues.Append("Jackpot Amount: " + jackpot);
            formValues.Append("<br />");
            //formValues.Append("Cash Options Amount: " + cashOptionsAmount);
            //formValues.Append("<br />");
            //formValues.Append("Any Multipliers?: " + multiplier);
            //formValues.Append("<br />");
            formValues.Append("Number: " + number);
            formValues.Append("<br />");
            //formValues.Append("Number: " + number2);
            //formValues.Append("<br />");
            //formValues.Append("Number: " + number3);
            //formValues.Append("<br />");
            //formValues.Append("Number: " + number4);
            //formValues.Append("<br />");
            //formValues.Append("Number: " + number5);
            //formValues.Append("<br />");
            //formValues.Append("Number: " + specialBall);
            //formValues.Append("<br />");

            VelocityCoders.LotteryGame.Models.Drawing drawingToSave 
                = new VelocityCoders.LotteryGame.Models.Drawing();

            VelocityCoders.LotteryGame.Models.WinningNumber drawingToSaveNumber
                = new VelocityCoders.LotteryGame.Models.WinningNumber();

            //notes: specify lotterydrawing properties
            drawingToSave.LotteryName = lotteryName;
            drawingToSave.DrawingDate = drawingDate.ToDate();
            /*drawingToSave.DrawingId = drawingId.ToInt()*/;
            drawingToSave.Jackpot = jackpot.ToInt();
            drawingToSaveNumber.Number = number.ToInt();


            //notes: set Id's from hidden fields to determine insert/update
            drawingToSave.DrawingId = hidDrawingId.Value.ToInt();
            drawingToSave.LotteryId = hidLotteryId.Value.ToInt();

            //notes: call the manager class to save drawing
            drawingToSave.DrawingId = DrawingBLL.Save(drawingToSave);

            if (drawingToSave.DrawingId > 0)
                base.DisplayPageMessage(lblPageMessage, "Update was successful.");
            else
            {
                // notes: insert was successful - redirect to the instructor list
                Response.Redirect("LotteryDrawingForm.aspx");
            }

            DrawingBLL.Save(drawingToSave);

            lblFormMessage.Text = formValues.ToString();
        }
        #endregion

        #region BIND CONTROLS

        private void BindLotteryNavigation()
        {
            lotteryNavigation.CurrentNavigationLink = LotteryNavigation.LotteryDrawingForm;
            lotteryNavigation.LotteryId = 1;

            //drawingNavigation.DrawingNavigationLink = DrawingNavigation.LotteryDrawingForm;
            //drawingNavigation.DrawingId = 1;
        }

        private void BindDrawingList()
        {
            DrawingCollection drawingList = DrawingBLL.GetCollectionDraw();

            rptLotteryDrawing.DataSource = drawingList;
            rptLotteryDrawing.DataBind();
        }

        private void BindLotteryName()
        {
            LotteryCollection lotteryNameList = LotteryBLL.GetCollection(LotteryEnum.GetItemLotteryName);
            drpGameNameDraw.DataSource = lotteryNameList;
            drpGameNameDraw.DataBind();
            drpGameNameDraw.Items.Insert(0, new ListItem { Text = "(Select Lottery Game)", Value ="0" });
        }

        private void BindLotteryDrawing()
        {
            //DrawingCollection drawingList = DrawingBLL.GetCollection(LotteryDrawingEnum.GetItemOrderByDate);
            //txtDrawingDate.DataSource = drawingList;
            //txtDrawingDate.DataBind();
            //txtDrawingDate.Items.Insert(0, new ListItem { Text="(Select Date)", Value="0"});
        }

        private void BindUpdateInfo(VelocityCoders.LotteryGame.Models.Drawing drawingToUpdate)
        {

            //notes: drop-down

            if (drawingToUpdate.LotteryId > 0)
                drpGameNameDraw.SelectedValue = drawingToUpdate.LotteryId.ToString();

            //notes: date fields
            if (drawingToUpdate.DrawingDate != DateTime.MinValue)
                txtDrawingDate.Text = drawingToUpdate.DrawingDate.ToShortDateString();

            //notes: populate form fields for update
            //if (drawingToUpdate.DrawingId != 0)
            //    txtDrawingId.Text = drawingToUpdate.DrawingId.ToString();

            if (drawingToUpdate.Jackpot != 0)
                txtJackpotAmount.Text = drawingToUpdate.Jackpot.ToString();

            if (drawingToUpdate.WinningNumber != null)
                txtNumber.Text = drawingToUpdate.WinningNumber.Number.ToString();

            //notes: update the text of the button
            btnSave.Text = "Update Lottery Drawing";
        }
        #endregion

        #region DELETE

        private void DeleteDrawing()
        {
            int DrawingId = hidDrawingId.Value.ToInt();

            if (DrawingId > 0)
            {
                // notes: call middle tier to delete reocfrd
                if (DrawingBLL.Delete(DrawingId))
                {
                    //notes: redirect to drawing list
                    Response.Redirect("LotteryDrawingForm.aspx");
                }
                else
                    base.DisplayPageMessage(messageToDisplay, "Error. Delete failed.");
            }
            else
                base.DisplayPageMessage(messageToDisplay, "Invalid Id, Delete failed.");
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
                btnDelete.Visible = true;
            }
            else
            {
                btnSave.Text = "Add Lottery Drawing";
                btnCancel.Visible = false;
                btnDelete.Visible = false;
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

        protected void Delete_Click(object sender, EventArgs e)
        {
            this.DeleteDrawing();
        }
        #endregion
    }
}
