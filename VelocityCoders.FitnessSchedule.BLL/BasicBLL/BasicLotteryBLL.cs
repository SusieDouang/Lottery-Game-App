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
    public static class BasicLotteryBLL
    {

        #region GET ITEM
        public static BasicLottery GetItem(int lotteryId)
        {
            return BasicLotteryDAL.GetItem(lotteryId);
        }
        #endregion

        #region GET COLLECTION

        public static BasicLotteryCollection GetCollection(LotteryEnum lotteryName)
        {
            BasicLotteryCollection collection = BasicLotteryDAL.GetCollection(lotteryName);
            return collection;
        }

        public static BasicLotteryCollection GetCollectionLot(int lotteryId)
        {
            return BasicLotteryDAL.GetCollectionLot();
        }

        #endregion

        #region INSERT, UPDATE

        public static int Save(BasicLottery lotteryToSave)
        {
            int returnValue;
            returnValue = BasicLotteryDAL.Save(lotteryToSave);
            return returnValue;

            //return BasicLotteryBLL.Save(lotterytoSave);

            //int lotteryId = SaveLottery(lotteryToSave);
            //lotteryToSave.LotteryId = lotteryId;

            ////notes: call data access layer to save
            //return BasicLotteryDAL.Save(lotteryToSave);
        }
        #endregion

        #region PRIVATE METHOD

        private static int SaveLottery(BasicLottery lotteryToSave)
        {
            BasicLottery tempLot = new BasicLottery();
            tempLot.LotteryId = lotteryToSave.LotteryId;

            //    tempLot.LotteryName = lotteryToSave.LotteryName;
            //    tempLot.LotteryNameAbbreviation = lotteryToSave.LotteryNameAbbreviation;
            //    tempLot.SpecialBall = lotteryToSave.SpecialBall;
            //    tempLot.HowToPlay = lotteryToSave.HowToPlay;
            //    tempLot.Description = lotteryToSave.Description;

            //    //notes: call Lottery BLL to Save
            int lotteryId = BasicLotteryBLL.Save(tempLot);
            return lotteryId;
        }

        #endregion

        #region DELETE

        public static bool Delete(int lotteryId)

        //notes: retrieve LotteryId to delete lottery record
        {
            return BasicLotteryDAL.Delete(lotteryId);
        }

        #endregion
    }
}
