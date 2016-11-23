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
    public partial class LotteryForm : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblFormMessage.Text = DateTime.Now.ToShortDateString(); 

            this.BindLotteryNavigation();
            this.BindLotteryName();
//          this.BindLottery();
            this.CheckUpdate();
        }

        #region CHECK UPDATE
        private void CheckUpdate()
        {
            if (base.LotteryId > 0)
            {
                //notes:   in update mode with existence of LotteryId 
                //         check to see if record exists in the database

                VelocityCoders.LotteryGame.Models.Lottery lotteryToUpdate =
                LotteryBLL.GetItem(base.LotteryId);

                if (lotteryToUpdate != null)
                {
                    this.BindUpdateInfo(lotteryToUpdate);
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
        private void LotteryProcessForm()
        {
            StringBuilder formValues = new StringBuilder();

            string lotteryName = drpLotteryName.Text;
            string lotteryNameAbbreviation = txtLotteryNameAbbreviation.Text;
            string howToPlay = txtHowToPlay.Text;
            string description = txtDescription.Text;

            formValues.Append("Lottery Name: " + lotteryName);
            formValues.Append("<br />");
            formValues.Append("Lottery Name Abbreviation: " + lotteryNameAbbreviation);
            formValues.Append("<br />");
            formValues.Append("How to Play: " + howToPlay);
            formValues.Append("<br />");
            formValues.Append("<Description: " + description);

            VelocityCoders.LotteryGame.Models.Lottery lotteryToSave 
            = new VelocityCoders.LotteryGame.Models.Lottery();

            //notes: set Id's from hidden fields to determine insert/update
            lotteryToSave.Drawing.DrawingId = hidDrawingId.Value.ToInt();
            lotteryToSave.LotteryId = hidLotteryId.Value.ToInt();

            //notes: specify lottery properties
//            lotteryToSave.LotteryName = lotteryName;
//            lotteryToSave.LotteryNameAbbreviation = lotteryNameAbbreviation;
//            lotteryToSave.HowToPlay = howToPlay;
//            lotteryToSave.Description = description;

            //notes: call manager class to save lottery
           LotteryBLL.Save(lotteryToSave);

            lblFormMessage.Text = formValues.ToString();
        }
        #endregion

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
//          drpLotteryName.SelectedValue = "2"; 
            drpLotteryName.Items.Insert(0, new ListItem { Text="(Select Lottery Game)", Value ="0"});
        }

        private void BindLottery()
        {
            LotteryCollection lotteryList = LotteryBLL.GetCollection(LotteryEnum.GetItemLotteryName);
            drpLotteryName.DataSource = lotteryList;
            drpLotteryName.DataBind();
            drpLotteryName.Items.Insert(0, new ListItem { Text = "(Select Date)", Value = "0" });
        }


        private void BindUpdateInfo(VelocityCoders.LotteryGame.Models.Lottery lotteryToUpdate)
        {
            //notes: populate form fields for update

            if (lotteryToUpdate.LotteryName != null)
                drpLotteryName.SelectedValue = lotteryToUpdate.LotteryName;

            if (lotteryToUpdate.LotteryNameAbbreviation != null)
                txtLotteryNameAbbreviation.Text = lotteryToUpdate.LotteryNameAbbreviation.ToString();

            if (lotteryToUpdate.HowToPlay != null)
                txtHowToPlay.Text = lotteryToUpdate.HowToPlay.ToString();

            if (lotteryToUpdate.Description != null)
                txtLotteryNameAbbreviation.Text = lotteryToUpdate.Description.ToString();
            
            //notes: update the text of the button
            btnSave.Text = "Update Lottery";
        }


        #endregion

        #region BUTTONS

        private void SetButtons(bool isUpdate)
        {
            if (isUpdate)
            {
                //notes: update the text of the button
                btnSave.Text = "Update Lottery";
                btnCancel.Visible = true;
                btnDelete.Visible = true;
            }
            else
            {
                btnSave.Text = "Add Lottery";
                btnCancel.Visible = false;
                btnDelete.Visible = false;
            }
        }
        #endregion

        #region EVENT HANDLERS

        protected void Save_Click(object sender, EventArgs e)
        {
            this.LotteryProcessForm();
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("LotteryForm.aspx");
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            Response.Redirect("LotteryForm.aspx");
        }

        #endregion

        #region DELETE

        private void DeleteLottery()
        {
            int LotteryId = hidLotteryId.Value.ToInt();

            if (LotteryId > 0)
            {
                // notes: call middle tier to delete reocfrd
                if (LotteryBLL.Delete(LotteryId))
                {
                    //notes: redirect to drawing list
                    Response.Redirect("LotteryForm.aspx");
                }
                else
                    base.DisplayPageMessage(messageToDisplay, "Error. Delete failed.");
            }
            else
                base.DisplayPageMessage(messageToDisplay, "Invalid Id, Delete failed.");
        }

        #endregion
    }
}