using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelocityCoders.LotteryGame.Models;
using VelocityCoders.LotteryGame.Models.Enums;
using VelocityCoders.LotteryGame.Models.Collections;
using VelocityCoders.LotteryGame.DAL;

namespace VelocityCoders.LotteryGame.BLL
{
    public static class DrawingBLL
    {
        #region GET ITEM DRAWING

        public static Drawing GetDrawing(int drawingId)
        {
            return DrawingDAL.GetDrawing(drawingId);
        }

        #endregion

        #region GET COLLECTION

        public static DrawingCollection GetCollection(int lotteryId)
        {
            return DrawingDAL.GetCollection(lotteryId);
        }

        public static DrawingCollection GetCollectionDraw()
        {
            return DrawingDAL.GetCollectionDraw();
        }

        //public static LotteryCollection GetCollection()
        //{
        //    LotteryCollection collection = LotteryCollection
        //    return collection;
        //}

        #endregion

        #region INSERT, UPDATE

        public static int Save(Drawing drawingtoSave)
        {
            int returnValue;
            returnValue = DrawingDAL.Save(drawingtoSave);

            return returnValue;
        }

        #endregion

        #region DELETE
        public static bool Delete(int drawingId)
        {
            //notes: retrieve lottery id so we can delete lottery record
            Drawing toDelete = DrawingBLL.GetDrawing(drawingId);
            if (toDelete != null)
            {
                if (toDelete != null)
                {
                    if (toDelete.LotteryId > 0 && toDelete.DrawingId > 0)
                    {
                        //notes: delete drawing first
                    }
                    if (DrawingDAL.Delete(toDelete.DrawingId))
                    {
                        return LotteryDAL.Delete(toDelete.LotteryId);
                    }
                    else
                        return false;
                }
                else
                    return false;
            }
            else return false;
        }
        #endregion
    }
}
