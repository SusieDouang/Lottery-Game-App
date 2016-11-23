using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using VelocityCoders.LotteryGame.Models.Enums;
using VelocityCoders.LotteryGame.Models.BasicCollection;
using VelocityCoders.LotteryGame.DAL.BasicDAL;
using VelocityCoders.LotteryGame.Models;
using VelocityCoders.LotteryGame.BLL.BasicBLL;
using Susie.Common.Extensions;



namespace VelocityCoders.LotteryGame.Webforms
{
    public partial class BasicLotteryForm : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblFormMessage.Text = DateTime.Now.ToShortDateString();
                this.BindBasicLotteryNavigation();
                this.BindLotteryList();
                this.CheckUpdate();
            }
        }

        #region CHECK UPDATE

        private void CheckUpdate()
        {
            if (base.LotteryId > 0)
            {
                // notes: in update mode with existence of LotteryId check to see if record
                // exists in the database.
                
                VelocityCoders.LotteryGame.Models.BasicLottery lotteryToUpdate =
                    BasicLotteryBLL.GetItem(base.LotteryId);

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
            string lotteryId = txtLotteryId.Text;
            string lotteryName = txtLotteryName.Text;
            string lotteryNameAbbreviation = txtLotteryNameAbbreviation.Text;
            string specialBall = drpSpecialBall.Text; 
            string howToPlay = txtHowToPlay.Text;
            string description = txtDescription.Text;

            //formValues.Append("Lottery Name: " + lotteryName);
            //formValues.Append("<br />");
            //formValues.Append("Lottery Name Abbreviation: " + lotteryNameAbbreviation);
            //formValues.Append("<br />");
            //formValues.Append("Special Ball: " + specialBall);
            //formValues.Append("<br />");
            //formValues.Append("How To Play: " + howToPlay);
            //formValues.Append("<br />");
            //formValues.Append("Description: + " + description);
            //formValues.Append("<br />");

            VelocityCoders.LotteryGame.Models.BasicLottery lotteryToSave
                = new VelocityCoders.LotteryGame.Models.BasicLottery();

            // notes: specify lotteryToSave properties
            lotteryToSave.LotteryId = lotteryId.ToInt();
            lotteryToSave.LotteryName = lotteryName;
            lotteryToSave.LotteryNameAbbreviation = lotteryNameAbbreviation;
            lotteryToSave.SpecialBall = specialBall.ToInt();
            lotteryToSave.HowToPlay = howToPlay;
            lotteryToSave.Description = description;

            //notes: call the BLL to save CLASS
            lotteryToSave.LotteryId = BasicLotteryBLL.Save(lotteryToSave);

            //notes: set Id from hidden fields to determine insert/update
            lotteryToSave.LotteryId = hideLotteryId.Value.ToInt();

            if (lotteryToSave.LotteryId > 0)
                base.DisplayPageMessage(messageToDisplay, "Update was successful.");
            else
            {
                Response.Redirect("BasicLotteryForm.aspx");
            }

            BasicLotteryBLL.Save(lotteryToSave);
            messageToDisplay.Text = formValues.ToString();

        }

        #endregion

        #region BIND CONTROLS 

        private void BindBasicLotteryNavigation()
        {
            basiclotteryNavigation.BasicNavigationLink = BasicLotteryNavigation.Lottery;
            basiclotteryNavigation.LotteryId = 1;
        }
        private void BindLotteryList()
        {
            BasicLotteryCollection lotteryList = new BasicLotteryCollection();
            lotteryList = BasicLotteryDAL.GetCollectionLot();

            rptLottery.DataSource = lotteryList;
            rptLottery.DataBind();
        }
        private void BindUpdateInfo(VelocityCoders.LotteryGame.Models.BasicLottery lotteryToUpdate)
        {
            //notes: populate form fields for update

            if (lotteryToUpdate.LotteryId != 0)
                txtLotteryId.Text = lotteryToUpdate.LotteryId.ToString();

            if (lotteryToUpdate.LotteryName != null)
                txtLotteryName.Text = lotteryToUpdate.LotteryName;

            if (lotteryToUpdate.LotteryNameAbbreviation != null)
                txtLotteryNameAbbreviation.Text = lotteryToUpdate.LotteryNameAbbreviation;

            if (lotteryToUpdate.SpecialBall != null)
                drpSpecialBall.Text = lotteryToUpdate.SpecialBall.ToString();

            if (lotteryToUpdate.HowToPlay != null)
                txtHowToPlay.Text = lotteryToUpdate.HowToPlay;

            if (lotteryToUpdate.Description != null)
                txtDescription.Text = lotteryToUpdate.Description;

            hideLotteryId.Value = base.LotteryId.ToString();

            btnSave.Text = "Update Lottery Game";
        }

        #endregion

        #region DELETE

        private void DeletethisGame()
        {
            int lotteryId = hideLotteryId.Value.ToInt();
            if (lotteryId > 0)
            {
                // notes: call middle tier to delete reocfrd
                if (BasicLotteryBLL.Delete(lotteryId))
                {
                    //notes: redirect to drawing list
                    Response.Redirect("BasicLotteryForm.aspx");
                }
                else
                    base.DisplayPageMessage(messageToDisplay, "Delete Successful. Click Cancel to Reset.");
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
                btnSave.Text = "Update Lottery Game";
                btnCancel.Visible = true;
                btnDelete.Visible = true;
            }
            else
            {
                btnSave.Text = "Add Lottery Game";
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
            Response.Redirect("BasicLotteryForm.aspx");
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            this.DeletethisGame();
        }
        #endregion

    }
}