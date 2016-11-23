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
using VelocityCoders.LotteryGame.DAL;
using Susie.Common.Extensions;

namespace VelocityCoders.LotteryGame.Webforms.Admin.Lottery
{
    public partial class DrawingIdForm : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int queryStringValue = base.LotteryId;
            this.CheckUpdate();
            this.BindLotteryNavigation();
            //this.BindDrawingIdList();


            if (!IsPostBack)
            {
                this.BindLotteryNameDrp();
                this.BindLotteryDate();
                this.BindBallTypeIdDrp();
                this.BindNumberList();
            }
        }

        #region CHECK UPDATE
        private void CheckUpdate()
        {
            if (base.LotteryId > 0)
            {
                //notes: in update mode with existence of Lottery Id
                //       check to see if record exists in the database


                //VelocityCoders.LotteryGame.Models.Lottery drawingToUpdate =
                //LotteryBLL.GetItem(base.LotteryId);

                VelocityCoders.LotteryGame.Models.Drawing drawingToUpdate =
                    DrawingBLL.GetDrawing(base.LotteryId);

                //Lottery winningToUpdate = WinningNumberBLL.GetWinningNumber(base.WinningNumberId);
                //if (winningToUpdate != null)

                if (drawingToUpdate != null)
                {
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

            string lotteryName = drpLotteryName.SelectedItem.Text;
            string drawingDate = drpDrawingDate.SelectedItem.Text;
            string description = drpBallTypeId.SelectedItem.Text;
            string number = txtNumber.Text;

            //notes: instantiate WinningNumber    

            VelocityCoders.LotteryGame.Models.WinningNumber winToSave 
                = new VelocityCoders.LotteryGame.Models.WinningNumber();

            VelocityCoders.LotteryGame.Models.Lottery lotteryToSave
                  = new VelocityCoders.LotteryGame.Models.Lottery();

            //notes: set the properties to the object to the form variables that were entered in 
            // on the main form screen

            formValues.Append("Lottery Name: " + lotteryName);
            formValues.Append("<br />");
            formValues.Append("Drawing Date:" + drawingDate);
            formValues.Append("<br/>");
            formValues.Append("Description: " + description);
            formValues.Append("<br />");
            formValues.Append("Number: " + number);
            formValues.Append("<br />");

            winToSave.LotteryName = lotteryName;
            winToSave.DrawingDate = drawingDate.ToDate();
            winToSave.Description = description.ToString();
            winToSave.Number = number.ToInt(); 

            //notes: call manager class to save lottery
            winToSave.LotteryId = LotteryBLL.Save(lotteryToSave);

            //lotteryToSave.Drawing.DrawingId = hidDrawingId.Value.ToInt();
            lotteryToSave.LotteryId = hidLotteryId.Value.ToInt();

            if (winToSave.LotteryId > 0)
                base.DisplayPageMessage(messageToDisplay, "Update was successful.");

                else
                {
                Response.Redirect("WinningNumberForm.aspx");
                }
            //messageToDisplay.Text = formValues.ToString();
        }

        #endregion

        #region BIND CONTROLS

        private void BindLotteryNavigation()
        {
            lotteryNavigation.CurrentNavigationLink = LotteryNavigation.WinningNumberForm;
            lotteryNavigation.LotteryId = 1;
        }

        private void BindLotteryIdList()
        {
            DrawingCollection winningNumberDrawList = DrawingBLL.GetCollection(LotteryId);

            rptWinningNumber.DataSource = winningNumberDrawList;
            rptWinningNumber.DataBind(); 
        }

        private void BindLotteryNameDrp()
        {
            LotteryCollection lotteryNameList = LotteryBLL.GetCollection(LotteryEnum.GetItemLotteryName);

            drpLotteryName.DataSource = lotteryNameList;
            drpLotteryName.DataBind();

            drpLotteryName.Items.Insert(0, new ListItem { Text = "(Select Lottery Name)", Value = "0" });
        }

        private void BindLotteryDate()
        {
            DrawingCollection drawingDateList = DrawingBLL.GetCollection(LotteryId);
            drpDrawingDate.DataSource = drawingDateList;
            drpDrawingDate.DataBind();
            drpDrawingDate.Items.Insert(0, new ListItem { Text = "(Select Drawing Date)", Value = "0" });
        }

        //private void BindBallTypeIdDrp()
        //{
        //    WinningNumberCollection ballTypeList = WinningNumberBLL.GetCollectionBallType(LotteryId, DrawingId);
        //    drpBallTypeId.DataSource = ballTypeList;
        //    drpBallTypeId.DataBind();
        //    drpBallTypeId.Items.Insert(0, new ListItem { Text = "(Select BallTypeId)", Value = "0" });
        //}


        private void BindBallTypeIdDrp()
        {
            BallTypeCollection ballTypeList = BallTypeBLL.GetCollection(BallTypeEnum.GetCollection);

            drpBallTypeId.DataSource = ballTypeList;
            drpBallTypeId.DataBind();

            drpBallTypeId.Items.Insert(0, new ListItem { Text = "(Select BallType)", Value = "0" });
        }


        private void BindNumberList()
        {
            //WinningNumber numberList = WinningNumberBLL.GetWinningNumber(LotteryId);
            //WinningNumber numberList = WinningNumberBLL.GetCollection();

            WinningNumberCollection numberList = new WinningNumberCollection(LotteryId, DrawingId);
            numberList = WinningNumberDAL.GetCollection(LotteryId, DrawingId);

            rptWinningNumber.DataSource = numberList;
            rptWinningNumber.DataBind();
        }


        private void BindUpdateInfo(VelocityCoders.LotteryGame.Models.Drawing winningToUpdate)
        {
            //notes: dropdown

            if (winningToUpdate.LotteryId > 0)
                drpLotteryName.SelectedValue = winningToUpdate.LotteryId.ToString();

            if (winningToUpdate.DrawingDate != null)
                drpDrawingDate.SelectedValue = winningToUpdate.DrawingDate.ToShortDateString();

            if (winningToUpdate.BallTypeId > 0)
                drpBallTypeId.SelectedValue = winningToUpdate.Description.ToString();

            if (winningToUpdate.Number != null)
                txtNumber.Text = winningToUpdate.Number.ToString();

            //notes: update the ext of the button
            btnSave.Text = "Update Winning Number";
        }

        #endregion

        #region BUTTONS

        private void SetButtons(bool isUpdate)
        {
            if (isUpdate)
            {
                //notes: update the text of the button
                btnSave.Text = "Update Winning Number";
                btnCancel.Visible = true;
                btnDelete.Visible = true;
            }
            else
            {
                btnSave.Text = "Add Winning Number";
                btnCancel.Visible = false;
                btnDelete.Visible = false;
            }
        }
        #endregion

        #region EVENT HANDLER
        protected void Save_Click(object sender, EventArgs e)
        {
            this.ProcessForm();
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("WinningDrawingForm.aspx");
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
        }
        #endregion
    }
}