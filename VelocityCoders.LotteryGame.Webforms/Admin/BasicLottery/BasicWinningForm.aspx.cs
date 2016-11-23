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
using VelocityCoders.LotteryGame.BLL.BasicBLL;
using VelocityCoders.LotteryGame.Models;
using Susie.Common.Extensions;


namespace VelocityCoders.LotteryGame.Webforms
{
    public partial class BasicWinningForm : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblFormMessages.Text = DateTime.Now.ToShortDateString();
                this.BindBasicLotteryNavigation();
                this.BindDrawingList();
                this.BindBallTypeId();
                this.CheckUpdate();
            }
        }

        #region CHECK UPDATE

        private void CheckUpdate()
        {
            if (base.WinningNumberId > 0)
            {
                // notes: in update mode with existence of WinningNumberId check to see if record
                // exists in the database.

                VelocityCoders.LotteryGame.Models.BasicWinningNumber winningNumberToUpdate =
                    BasicWinningBLL.GetItem(base.WinningNumberId);

                if (winningNumberToUpdate != null)
                    {
                        this.BindUpdateInfo(winningNumberToUpdate);
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

        private void WinningProcessForm()
        {
            StringBuilder formValues = new StringBuilder();

            string winningNumberId = txtWinningNumId.Text;
            string drawingId = txtDrawId.Text;
            string ballTypeId = drpBallTypeId.Text;
            string number = txtNumbers.Text;

            VelocityCoders.LotteryGame.Models.BasicWinningNumber winningNumberToSave
                = new VelocityCoders.LotteryGame.Models.BasicWinningNumber();

            // notse: specify winningNumberToSave properties
            winningNumberToSave.WinningNumberId = winningNumberId.ToInt();
            winningNumberToSave.DrawingId = drawingId.ToInt();
            winningNumberToSave.BallTypeId = ballTypeId.ToInt();
            winningNumberToSave.Number = number.ToInt();

            //notes: call the BLL to save CLASS
            winningNumberToSave.WinningNumberId = BasicWinningBLL.Save(winningNumberToSave);

            //notes: set Id from hidden fields to determine insert/update
            winningNumberToSave.WinningNumberId = hideWinningNumberId.Value.ToInt();

            if (winningNumberToSave.WinningNumberId > 0)
                base.DisplayPageMessage(lblFormMessages, "Update was successful.");
            else
            {

                //notes: insert was successful - redirect to the drawing list
                Response.Redirect("BasicWinningForm.aspx");
            }

            BasicWinningBLL.Save(winningNumberToSave);
            lblFormMessages.Text = formValues.ToString();
        }

        #endregion

        #region BIND CONTROLS 

        private void BindBasicLotteryNavigation()
        {
            basiclotNavigation.BasicNavigationLink = BasicLotteryNavigation.Lottery;
            basiclotNavigation.LotteryId = 1;
        }

        private void BindDrawingList()
        {
            BasicWinningCollection winningList = new BasicWinningCollection();
            winningList = BasicWinningDAL.GetCollectionWin();

            rptWinningNumber.DataSource = winningList;
            rptWinningNumber.DataBind();
        }

        private void BindBallTypeId()
        {
            BasicBallTypeCollection ballTypeCollection = BasicBallTypeBLL.GetCollection(BallTypeEnum.GetCollection);

            drpBallTypeId.DataSource = ballTypeCollection;
            drpBallTypeId.DataBind();

            drpBallTypeId.Items.Insert(0, new ListItem { Text = "(Select Ball Type)", Value = "0" });
        }

        private void BindUpdateInfo(BasicWinningNumber winningNumberToUpdate)
        {
            // notes: populate form fields for update

            if (winningNumberToUpdate.WinningNumberId != 0)
                txtWinningNumId.Text = winningNumberToUpdate.WinningNumberId.ToString();

            if (winningNumberToUpdate.DrawingId != 0)
                txtDrawId.Text = winningNumberToUpdate.DrawingId.ToString();

            if (winningNumberToUpdate.BallTypeId > 0)
                drpBallTypeId.SelectedValue = winningNumberToUpdate.BallTypeId.ToString();

            if (winningNumberToUpdate.Number > 0)
                txtNumbers.Text = winningNumberToUpdate.Number.ToString();

            hideWinningNumberId.Value = winningNumberToUpdate.WinningNumberId.ToString();

            btnSave.Text = "Update Winning Numbers.";

        }
        #endregion

        #region DELETE

        private void DeletethisDraw()
        {
            int winningId = hideWinningNumberId.Value.ToInt();
            if (winningId > 0)
            {
                // notes: call middle tier to delete record
                if(BasicWinningBLL.Delete(WinningNumberId))
                {
                    //notes: redirect to drawing list
                    Response.Redirect("BasicWinningForm.aspx");
                }
            }
        }

        #endregion   

        #region BUTTONS
        private void SetButtons(bool isUpdate)
        {
            if (isUpdate)
            {
                btnSave.Text = "Update Drawing";
                btnCancel.Visible = true;
                btnDelete.Visible = true;
            }
            else
            {
                btnSave.Text = "Add Drawing";
                btnCancel.Visible = false;
                btnDelete.Visible = false;
            }
        }
        #endregion

        #region EVENT HANDLERS

        protected void Save_Click(object sender, EventArgs e)
        {
            this.WinningProcessForm();
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("BasicWinningForm.aspx");
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            this.DeletethisDraw();
        }

        #endregion

    }
}