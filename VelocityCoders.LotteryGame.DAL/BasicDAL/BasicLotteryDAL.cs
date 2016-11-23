using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Susie.Common;
using VelocityCoders.LotteryGame.Models;
using VelocityCoders.LotteryGame.Models.Enums;
using VelocityCoders.LotteryGame.Models.BasicCollection;


namespace VelocityCoders.LotteryGame.DAL.BasicDAL
{
    public class BasicLotteryDAL
    {
        #region GET ITEM

        /// <summary>
        /// Get a single record for LotteryId.
        /// </summary>
        /// <param name="lotteryId"></param>
        /// <returns></returns>

        public static BasicLottery GetItem(int lotteryId)
        {
            BasicLottery tempItem = null;
            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetLotteryGame", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", SelectTypeEnum.GetItem);
                    myCommand.Parameters.AddWithValue("@LotteryId", lotteryId);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.Read())
                        {
                            tempItem = BasicFillDataRecord(myReader);
                        }
                        myReader.Close();
                    }
                    myConnection.Close();
                }
            }
            return tempItem;
        }
        #endregion

        #region GET COLLECTION

        public static BasicLotteryCollection GetCollection(LotteryEnum lotteryName)
        {
            BasicLotteryCollection tempList = null;
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
                            tempList = new BasicLotteryCollection();
                            while (myReader.Read())
                            {
                                tempList.Add(BasicFillDataRecord(myReader));
                            }
                            myReader.Close();
                        }
                    }
                    myConnection.Close();
                }
            }
            return tempList;
        }

        public static BasicLotteryCollection GetCollectionLot()
        {
            BasicLotteryCollection tempList = null;
            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetLotteryGame", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", LotteryEnum.GetItemLotteryNameCollection);
             

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        {
                            tempList = new BasicLotteryCollection();
                            while (myReader.Read())
                            {
                                tempList.Add(BasicFillDataRecord(myReader));
                            }
                            myReader.Close();
                        }
                    }
                    myConnection.Close();
                }
            }
            return tempList;
        }

        #endregion

        #region INSERT AND UPDATE

        /// <summary>
        /// Saves the Lottery to the database. Determines to INSERT or UPDATE based on valid LotteryId.
        /// </summary>
        /// <param name="lotteryToSave"></param>
        /// <returns></returns>

        public static int Save(BasicLottery lotteryToSave)
        {
            int result = 0;
            ExecuteTypeEnum queryId = ExecuteTypeEnum.InsertItem;

            //notes: check for vaild LotteryId - if exists then UPDATE, else INSERT

            if (lotteryToSave.LotteryId > 0)
            queryId = ExecuteTypeEnum.UpdateItem;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteLottery", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", queryId);

                    if (lotteryToSave.LotteryId != 0)
                        myCommand.Parameters.AddWithValue("@LotteryId", lotteryToSave.LotteryId);

                    if (lotteryToSave.LotteryName != null)
                        myCommand.Parameters.AddWithValue("@LotteryName", lotteryToSave.LotteryName);

                    if (lotteryToSave.LotteryNameAbbreviation != null)
                        myCommand.Parameters.AddWithValue("@LotteryNameAbbreviation", lotteryToSave.LotteryNameAbbreviation);

                    if (lotteryToSave.SpecialBall > 0)
                        myCommand.Parameters.AddWithValue("@SpecialBall", lotteryToSave.SpecialBall);

                    if (lotteryToSave.HowToPlay != null)
                        myCommand.Parameters.AddWithValue("@HowToPlay", lotteryToSave.HowToPlay);

                    if (lotteryToSave.Description != null)
                        myCommand.Parameters.AddWithValue("@Description", lotteryToSave.Description);

                    //notes: add return output parameter to command object - setting the key and value type
                    myCommand.Parameters.Add(HelperDAL.GetReturnParameterInt("ReturnValue"));

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                    //notes: get return value from stored procedure and return Id
                    result = (int)myCommand.Parameters["@ReturnValue"].Value;
                }
                myConnection.Close();
            }
            return result;
        }
        #endregion

        #region DELETE

        /// <summary>
        /// Delete a LotteryGame from the Lottery table
        /// Returns true if number of records a affected are greater than 0.
        /// </summary>
        /// <param name="LotteryId"></param>
        /// <returns></returns>

        public static bool Delete(int lotteryId)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteLottery", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", ExecuteTypeEnum.DeleteItem);
                    myCommand.Parameters.AddWithValue("@LotteryId", lotteryId);

                    myConnection.Open();
                    result = myCommand.ExecuteNonQuery();
                }
                myConnection.Close();
            }
            return result > 0;
        }
        #endregion

        #region HELPER METHODS

        private static BasicLottery BasicFillDataRecord(IDataRecord myDataRecord)
        {
            BasicLottery myObject = new BasicLottery();

            myObject.LotteryId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("LotteryId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("LotteryId")))
                myObject.LotteryId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("LotteryId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("LotteryName")))
                myObject.LotteryName = myDataRecord.GetString(myDataRecord.GetOrdinal("LotteryName"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("LotteryNameAbbreviation")))
                myObject.LotteryNameAbbreviation = myDataRecord.GetString(myDataRecord.GetOrdinal("LotteryNameAbbreviation"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("SpecialBall")))
                myObject.SpecialBall = myDataRecord.GetInt32(myDataRecord.GetOrdinal("SpecialBall"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("HowToPlay")))
                myObject.HowToPlay = myDataRecord.GetString(myDataRecord.GetOrdinal("HowToPlay"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Description")))
                myObject.Description = myDataRecord.GetString(myDataRecord.GetOrdinal("Description"));

            return myObject;
        }

        #endregion


    }
}