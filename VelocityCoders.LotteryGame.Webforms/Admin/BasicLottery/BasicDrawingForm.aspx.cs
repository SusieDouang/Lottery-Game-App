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
    public partial class BasicDrawingForm : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                lblFormMessage.Text = DateTime.Now.ToShortDateString();
                this.BindBasicLotteryNavigation();
                this.CheckUpdate();
                this.BindLotteryName();
                this.BindDrawingList();
            }
        }

        #region CHECK UPDATE

        private void CheckUpdate()
        {
            if (base.DrawingId > 0)
            {
                // notes: in update mode with existence of DrawingId check to see if record
                // exists in the database.

                VelocityCoders.LotteryGame.Models.BasicDrawing drawingToUpdate =
                BasicDrawingBLL.GetItem(base.DrawingId);

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

        private void DrawingProcessForm()
        {
            StringBuilder formValues = new StringBuilder();
            string drawingId = txtDrawingId.Text;
            string lotteryId = drpLotteryId.Text;
            string drawingDate = txtDrawingDate.Text;
            string jackpot = txtJackpot.Text;

            VelocityCoders.LotteryGame.Models.BasicDrawing drawingToSave
                = new VelocityCoders.LotteryGame.Models.BasicDrawing();

            // notes: specify drawingToSave properties
            drawingToSave.DrawingId = drawingId.ToInt();
            drawingToSave.LotteryId = lotteryId.ToInt();

            drawingToSave.DrawingDate = drawingDate.ToDate();
            drawingToSave.Jackpot = jackpot.ToInt();

            //notes: call the BLL to save CLASS
            drawingToSave.DrawingId = BasicDrawingBLL.Save(drawingToSave);

            //notes: set Id from hidden fields to deternmine insert/update
            drawingToSave.DrawingId = hideDrawingId.Value.ToInt();

            if (drawingToSave.DrawingId > 0)
                base.DisplayPageMessage(lblFormMessage, "Update was successful.");
            else
            {
 
                //notes: insert was successful - redirect to the drawing list
                Response.Redirect("BasicDrawingForm.aspx");
            }

            BasicDrawingBLL.Save(drawingToSave);
            lblFormMessage.Text = formValues.ToString();                    
        }
        #endregion

        #region BIND CONTROLS 

        private void BindBasicLotteryNavigation()
        {
            basiclotteryNavigation.BasicNavigationLink = BasicLotteryNavigation.Lottery;
            basiclotteryNavigation.LotteryId = 1;
        }

        private void BindDrawingList()
        {
            BasicDrawingCollection drawingList = new BasicDrawingCollection(DrawingId, LotteryId);
            drawingList = BasicDrawingDAL.GetCollection();

            rptDrawing.DataSource = drawingList;
            rptDrawing.DataBind();
        }

        private void BindLotteryName()
        {
            BasicLotteryCollection lotteryNameCollection = BasicLotteryBLL.GetCollection(LotteryEnum.GetItemLotteryName);

            drpLotteryId.DataSource = lotteryNameCollection;
            drpLotteryId.DataBind();

            drpLotteryId.Items.Insert(0, new ListItem { Text = "(Select Lottery)", Value = "0" });
        }

        private void BindUpdateInfo(BasicDrawing drawingToUpdate)
        {
            //notes: populate form fields for update

            if (drawingToUpdate.DrawingId != 0)
                txtDrawingId.Text = drawingToUpdate.DrawingId.ToString();

            if (drawingToUpdate.LotteryId != 0)
                drpLotteryId.Text = drawingToUpdate.LotteryId.ToString();

            if (drawingToUpdate.DrawingDate != null)
                txtDrawingDate.Text = drawingToUpdate.DrawingDate.ToShortDateString();

            if (drawingToUpdate.Jackpot != 0)
                txtJackpot.Text = drawingToUpdate.Jackpot.ToString();

            hideDrawingId.Value = drawingToUpdate.DrawingId.ToString();

            btnSave.Text = "Update Drawing";
        }

        #endregion

        #region DELETE

        private void DeletethisDraw()
        {
            int drawingId = hideDrawingId.Value.ToInt();
            if (drawingId > 0)
            {
                // notes: call middle tier to delete record
                if (BasicDrawingBLL.Delete(drawingId))
                {
                    //notes: redirect to drawing list
                    Response.Redirect("BasicDrawingForm.aspx");
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
            this.DrawingProcessForm();
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("BasicDrawingForm.aspx");
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            this.DeletethisDraw();
        }

        #endregion

    }
}