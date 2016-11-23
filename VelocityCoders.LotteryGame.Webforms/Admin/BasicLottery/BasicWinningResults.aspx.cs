using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using VelocityCoders.LotteryGame.Models.BasicCollection;
using VelocityCoders.LotteryGame.DAL.BasicDAL;
using VelocityCoders.LotteryGame.BLL.BasicBLL;
using VelocityCoders.LotteryGame.Models.Enums;
using VelocityCoders.LotteryGame.Models;
using Susie.Common;
using System.Web.UI.WebControls;

namespace VelocityCoders.LotteryGame.Webforms
{
    public partial class BasicWinningResults : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindBasicLotteryNavigation();
                this.BindResultsList();
                //this.LoopResult();
    
                //this.BindLotteryNameDropDown();
                //this.BindLotteryDateDropDown();
               }
        }

        //#region CHECK UPDATE

        //private void CheckUpdate()
        //{
        //    if (base.DrawingId > 0 & base.LotteryId > 0)
        //    //if (base.DrawingId > 0)
        //        {
        //        VelocityCoders.LotteryGame.Models.BasicDrawing drawingToUpdate =
        //        BasicDrawingBLL.GetItem(base.DrawingId);

        //        if (drawingToUpdate != null)
        //        {
        //            //this.BindUpdateInfo(drawingToUpdate);
        //        }
        //    }
        //}
        //#endregion

        #region BIND CONTROLS

        private void BindBasicLotteryNavigation()
        {
            basicLotNavigation.BasicNavigationLink = BasicLotteryNavigation.Results;
            basicLotNavigation.LotteryId = 1;
        }

        private void BindResultsList()
        {
            BasicDrawingCollection lotteryResults = new BasicDrawingCollection(DrawingId, LotteryId);
            lotteryResults = BasicDrawingDAL.GetCollectionResults(DrawingId, LotteryId);
       
            rptResults.DataSource = lotteryResults;
            rptResults.DataBind();
        }

        //private void BindLotteryNameDropDown()
        //{
        //    BasicLotteryCollection lotteryNameCollection = BasicLotteryBLL.GetCollection(LotteryEnum.GetItemLotteryName);

        //    drpLotteryId.DataSource = lotteryNameCollection;
        //    drpLotteryId.DataBind();

        //    drpLotteryId.Items.Insert(0, new ListItem { Text = "(Select Lottery)", Value = "0" });
        //}

        //private void BindLotteryDateDropDown()
        //{

        //    BasicDrawing drawingDateList = BasicDrawingBLL.GetItem(DrawingId);
        //    drpDrawingDate.DataSource = drawingDateList;
        //    drpDrawingDate.DataBind();
        //    drpDrawingDate.Items.Insert(0, new ListItem { Text = "(Select Drawing Date)", Value = "0" });
        //}

        //private void BindUpdateInfo(VelocityCoders.LotteryGame.Models.BasicDrawing drawingToUpdate)
        //{
        //    if (drawingToUpdate.LotteryId != 0)
        //        drpLotteryId.Text = drawingToUpdate.LotteryId.ToString();

        //    if (drawingToUpdate.DrawingId != 0)
        //         txtDrawId.Text = drawingToUpdate.DrawingId.ToString();

        //    if (drawingToUpdate.BasicLottery.LotteryId != 0)
        //        drpLotteryId.Text = drawingToUpdate.BasicLottery.LotteryId.ToString();

        //    if (drawingToUpdate.DrawingDate != null)
        //        drpDrawingDate.Text = drawingToUpdate.DrawingDate.ToShortDateString();

        //    if (drawingToUpdate.BasicWinningNumber.Number != 0)
        //        drpNumber.Text = drawingToUpdate.BasicWinningNumber.Number.ToString();

        //    if (drawingToUpdate.BasicBallType.BallType != null)
        //        drpBallType.Text = drawingToUpdate.BasicBallType.BallType.ToString();

        //    if (drawingToUpdate.Jackpot != 0)
        //        drpJackpot.Text = drawingToUpdate.Jackpot.ToString();

        //    hidLotteryId.Value = base.LotteryId.ToString();
        //    hidDrawingId.Value = base.DrawingId.ToString();

        //    //btnSave.Text = "Update Lottery Game";
        //}

        #endregion

        #region EVENT HANDLER

        protected void numberList_OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //BasicDrawingCollection numberList = (BasicDrawingCollection)e.Item.DataItem;
                //numberList = BasicDrawingDAL.GetCollectionNumber();

                //rptNumbers.DataSource = numberList;
                //rptNumbers.DataBind();

            //Find repeater control
            //call the middle tier to get a collection of number by drawingId
            //bind to the repeater

            }
        }


        //private void LoopResult()
        //{

        //    StringBuilder loop = new StringBuilder();

        //    for (int x = 0; x <= 5; x++)

        //        loop.Append(x.ToString() + " ");

        //       LoopingResult.Text = loop.ToString();

        //}


        //private void ArrayResult()
        //{
        //    BasicWinningCollection winningResults = new BasicWinningCollection();
        //}

        #endregion
    }

}
