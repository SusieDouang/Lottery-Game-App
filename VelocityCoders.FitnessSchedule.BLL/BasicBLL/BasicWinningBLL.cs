using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelocityCoders.LotteryGame.Models;
using VelocityCoders.LotteryGame.Models.Enums;
using VelocityCoders.LotteryGame.Models.BasicCollection;
using VelocityCoders.LotteryGame.DAL.BasicDAL;

namespace VelocityCoders.LotteryGame.BLL.BasicBLL
{
    public static class BasicWinningBLL
    {
        #region GET ITEM

        public static BasicWinningNumber GetItem(int winningNumberId)
        {
            return BasicWinningDAL.GetItem(winningNumberId);
        }
        #endregion

        #region GET COLLECTION

        public static BasicWinningCollection GetCollectionWin()
        {
            BasicWinningCollection collection = BasicWinningDAL.GetCollectionWin();
            return collection;
        }
        #endregion
        
        #region INSERT, UPDATE

        public static int Save(BasicWinningNumber winningNumberToSave)
        {
            int returnValue;
            returnValue = BasicWinningDAL.Save(winningNumberToSave);
            return returnValue;
        }
        #endregion

        #region PRIVATE METHOD

        private static int SaveWinning(BasicWinningNumber winningNumberToSave)
        {
            BasicWinningNumber tempWin = new BasicWinningNumber();
            tempWin.WinningNumberId = winningNumberToSave.WinningNumberId;

            int winningNumberId = BasicWinningBLL.Save(tempWin);
            return winningNumberId;
        }
        #endregion

        #region DELETE

        public static bool Delete(int winningNumberId)

        //notes: retrieve WinningNumberId to delete drawing record
        {
            return BasicWinningDAL.Delete(winningNumberId);
        }
        #endregion

    }
}
