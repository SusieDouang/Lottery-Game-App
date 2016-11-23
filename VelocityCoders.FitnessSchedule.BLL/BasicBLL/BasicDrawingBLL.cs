using System;
using System.Collections.Generic;
using System.Linq;
using VelocityCoders.LotteryGame.Models.BasicCollection;
using System.Text;
using System.Threading.Tasks;
using VelocityCoders.LotteryGame.DAL.BasicDAL;
using VelocityCoders.LotteryGame.Models;

namespace VelocityCoders.LotteryGame.BLL.BasicBLL
{
    public class BasicDrawingBLL
    {
        #region GET ITEM

        /// <summary>
        ///  Get a single record for DrawingId
        /// </summary>
        /// <param name="drawingId"></param>
        /// <returns></returns>

        public static BasicDrawing GetItem(int drawingId)
        {
            return BasicDrawingDAL.GetItem(drawingId);
        }

        public static BasicDrawing GetItem()
        {
            return BasicDrawingDAL.GetItem();
        }


        #endregion

        #region GET COLLECTION

        public static BasicDrawingCollection GetCollection()
        {
            BasicDrawingCollection collection = BasicDrawingDAL.GetCollection();
            return collection;
        }

        public static BasicDrawingCollection GetCollectionNumber(BasicWinningNumber number)
        {
            BasicDrawingCollection collectionNumber = BasicDrawingDAL.GetCollectionNumber();
            return collectionNumber;
        }
        #endregion

        #region 

        public static BasicDrawingCollection GetCollectionResults(int drawingId, int lotteryId)
        {
            BasicDrawingCollection collectionResults = BasicDrawingDAL.GetCollectionResults(drawingId, lotteryId);
            return collectionResults;
        }
        #endregion


        #region INSERT, UPDATE

        public static int Save(BasicDrawing drawingToSave)
        {
            int returnValue;
            returnValue = BasicDrawingDAL.Save(drawingToSave);
            return returnValue;
        }
        #endregion

        #region PRIVATE METHOD

        public static int SaveDrawing(BasicDrawing drawingToSave)
        {
            BasicDrawing tempDraw = new BasicDrawing();

            tempDraw.DrawingId = drawingToSave.DrawingId;
            tempDraw.LotteryId = drawingToSave.LotteryId;
            tempDraw.DrawingDate = drawingToSave.DrawingDate;
            tempDraw.Jackpot = drawingToSave.Jackpot;

            int drawingId = BasicDrawingBLL.Save(tempDraw);
            return drawingId;
        }
        #endregion

        #region DELETE

        public static bool Delete(int drawingId)

        //notes: retrieve DrawingId to delete drawing record
        {
            return BasicDrawingDAL.Delete(drawingId);
        }
        #endregion
    }
}
