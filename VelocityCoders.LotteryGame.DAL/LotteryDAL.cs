using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Susie.Common;
using VelocityCoders.LotteryGame.Models;
using VelocityCoders.LotteryGame.Models.Enums;
using VelocityCoders.LotteryGame.Models.Collections;

namespace VelocityCoders.LotteryGame.DAL
{
    public static class LotteryDAL
    {
        #region SELECT
        ///<summary>
        /// Get a collection of LotteryGame. If no records to return, LotteryCollection will be null.
        ///</summary>
        ///<returns></returns>

        public static Lottery GetItem(int lotteryId)
        {
            Lottery tempItem = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetLottery", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", LotteryEnum.GetItemLotteryName);
                    myCommand.Parameters.AddWithValue("@LotteryId", lotteryId);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.Read())

                            tempItem = FillDataRecord(myReader);

                        myReader.Close();

                        return tempItem;
                    }
                }
            }
        }

        public static LotteryCollection GetCollection(LotteryEnum lotteryName)
        {
            LotteryCollection tempList = null;
            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetLotteryGame", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", LotteryEnum.GetItemLotteryName);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tempList = new LotteryCollection();
                            while (myReader.Read())
                            
                               tempList.Add(FillDataRecord(myReader));
                            
                            myReader.Close();
                        }
                    }
                }
            }
            return tempList;
        }

        #endregion

        #region HELPER METHODS

        private static Lottery FillDataRecord(IDataRecord myDataRecord)
        {
            Lottery myObject = new Lottery();

            myObject.LotteryId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("LotteryId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("LotteryName")))
                myObject.LotteryName = myDataRecord.GetString(myDataRecord.GetOrdinal("LotteryName"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("SpecialBall")))
                myObject.SpecialBall = myDataRecord.GetInt32(myDataRecord.GetOrdinal("SpecialBall"));
             
            //notes: lottery specific properties

            return myObject;
        }
        #endregion

        #region INSERT AND UPDATE
        /// <summary>
        /// Saves the Lottery to the database. Determines to INSERT or UPDATE based on valid LotteryId.
        /// </summary>
        /// <param name="LotteryToSave"></param>
        /// <returns></returns>

        public static int Save(Lottery lotteryToSave)
        {
            int result = 0;
            ExecuteTypeEnum queryId = ExecuteTypeEnum.InsertItem;

            //notes: check for vaild LotteryId - if exists then UPDATE, else INSERT
            //      10 = INSERT_ITEM
            //      20 = UPDATE_ITEM

            if (lotteryToSave.LotteryId > 0)
                queryId = ExecuteTypeEnum.UpdateItem;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteLottery", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", queryId);

                    if (lotteryToSave.LotteryId > 0)
                        myCommand.Parameters.AddWithValue("@LotteryId", lotteryToSave.LotteryId);

                    if (lotteryToSave.LotteryName != null)
                        myCommand.Parameters.AddWithValue("@LotteryName", lotteryToSave.LotteryName);

                    if (lotteryToSave.SpecialBall > 0)
                        myCommand.Parameters.AddWithValue("@SpecialBall", lotteryToSave.SpecialBall);

                    //notes: add return output parameter to command object
                    myCommand.Parameters.Add(HelperDAL.GetReturnParameterInt("ReturnValue"));

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                    //notes: get return value from stored procedure and return Id
                    result = (int)myCommand.Parameters["@ReturnValue"].Value;
                }
                myConnection.Close();
            }
            return result;

            #endregion
        }
    }
}