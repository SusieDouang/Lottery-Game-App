using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient; 
using VelocityCoders.LotteryGame.Models;
using VelocityCoders.LotteryGame.Models.Enums;
using VelocityCoders.LotteryGame.Models.Collections;

namespace VelocityCoders.LotteryGame.DAL
{
    public static class WinningNumberDAL
    {
        #region SELECT
        /// <summary>
        /// Get a collection of WinningNumberDrawing. If no records return, WinningNumber collection
        /// will be null.
        /// </summary>
        /// <returns></returns>

        public static WinningNumber GetWinningNumber(int LotteryId)
        {
            WinningNumber tempItem = null;
            //System.Diagnostics.Debug.WriteLine("i am here 1");

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetWinningNumber", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", WinningNumberEnum.GetItemWinningNumber);
                    myCommand.Parameters.AddWithValue("@LotteryId", LotteryId);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.Read())
                        {
                            //System.Diagnostics.Debug.WriteLine("i am here");
                            //System.Diagnostics.Debug.WriteLine(myReader.FieldCount);
                            //System.Diagnostics.Debug.WriteLine(myReader.GetName(0));
                            //System.Diagnostics.Debug.WriteLine(myReader.GetName(1));
                            //System.Diagnostics.Debug.WriteLine(myReader.GetName(2));
                            //System.Diagnostics.Debug.WriteLine(myReader.GetName(3));

                            tempItem = FillDataRecordWin(myReader);
                        }
                        myReader.Close();
                    }
                    myConnection.Close();
                }
            }
            return tempItem;
        }

        public static WinningNumberCollection GetCollectionBallType(int lotteryId, int drawingId)
        {
            WinningNumberCollection tempList = null;
            //System.Diagnostics.Debug.WriteLine("i am here 2");
            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetWinningNumber", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", WinningNumberEnum.GetBallTypeId);
                    myCommand.Parameters.AddWithValue("@LotteryId", lotteryId);
                    myCommand.Parameters.AddWithValue("@DrawingId", drawingId);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        tempList = new WinningNumberCollection(lotteryId, drawingId);
                        while (myReader.Read())
                        {
                            tempList.Add(FillDataRecordWin(myReader));
                        }
                        myReader.Close();
                    }
                }
                return tempList;
            }
        }

        /// <summary>
        /// Get a collection of Winning Number. If no records to return, WinningNumberCollection object will be null.
        /// </summary>
        /// <param name="winningNumber"></param>
        /// <returns></returns>


        public static WinningNumberCollection GetCollection(int lotteryId, int drawingId)
        {

            WinningNumberCollection tempList = null;
            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetWinningNumber", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", WinningNumberEnum.GetCollection);
                    myCommand.Parameters.AddWithValue("@LotteryId", lotteryId);
                    myCommand.Parameters.AddWithValue("DrawingId", drawingId);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tempList = new WinningNumberCollection(lotteryId, drawingId);
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecordWin(myReader));
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


        #region HELPER METHODS

        public static WinningNumber FillDataRecordWin(IDataRecord myDataRecord)
        {
            WinningNumber myObject = new WinningNumber();
   

            myObject.LotteryId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("LotteryId"));


            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("LotteryId")))
                myObject.LotteryId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("LotteryId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("LotteryName")))
                myObject.LotteryName = myDataRecord.GetString(myDataRecord.GetOrdinal("LotteryName"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("DrawingDate")))
                myObject.DrawingDate = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("DrawingDate"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Description")))
                myObject.Description = myDataRecord.GetString(myDataRecord.GetOrdinal("Description"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Number")))
                myObject.Number = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Number"));

            return myObject;
        }
        #endregion

        #region INSERT AND UPDATE
        ///<summary>
        /// Saves the WinningNumber to the database. Determines to INSERT or UPDATE based on the vaild WinningNumberID
        /// </summary>
        /// <param name="winningNumberToSave"></param>
        /// <returns></returns>

        public static int Save(WinningNumber winningNumberToSave)
        {
            int result = 0;
            ExecuteTypeEnum queryId = ExecuteTypeEnum.InsertItem;

            //notes: check for valid WinningNumberId - if exists then UPDATE, else INSERT
            // 10 = INSERT_ITEM
            // 20 = UPDATE_ITEM

            if (winningNumberToSave.WinningNumberId > 0)
                queryId = ExecuteTypeEnum.UpdateItem;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetWinningNumber", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", queryId);

                    if (winningNumberToSave.WinningNumberId > 0)
                        myCommand.Parameters.AddWithValue("@WinningNumberId", winningNumberToSave.WinningNumberId);

                    if (winningNumberToSave.DrawingId != 0)
                        myCommand.Parameters.AddWithValue("@DrawingNumberId", winningNumberToSave.DrawingId);

                    if (winningNumberToSave.Number != 0)
                        myCommand.Parameters.AddWithValue("@Number", winningNumberToSave.Number);

                    //notes: add return output parameter to command object
                    myCommand.Parameters.Add(HelperDAL.GetReturnParameterInt("ReturnValue"));

                    myConnection.Open();
                    myCommand.ExecuteNonQuery();

                    //notes: get return value from store procedure and return Id
                    result = (int)myCommand.Parameters["@ReturnValue"].Value;
                }
                myConnection.Close();
            }
            return result;
        }
        #endregion


    }
}