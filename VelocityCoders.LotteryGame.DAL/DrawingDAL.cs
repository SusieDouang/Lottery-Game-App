using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using VelocityCoders.LotteryGame.Models;
using VelocityCoders.LotteryGame.Models.Enums;
using VelocityCoders.LotteryGame.Models.Collections;

namespace VelocityCoders.LotteryGame.DAL
{
    public static class DrawingDAL
    {
        #region SELECT
        ///<summary>
        /// Get a collection of LotteryGameDrawing. If no records to return, LotteryDrawingCollection will be null.
        ///</summary>
        ///<returns></returns>

        public static Drawing GetDrawing(int drawingId)
        {
            Drawing tempItem = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetLotteryDrawing", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", LotteryDrawingEnum.GetDrawing);
                    myCommand.Parameters.AddWithValue("@DrawingId", drawingId);

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

        public static  DrawingCollection GetCollection (LotteryDrawingEnum lotteryDrawing)
        {
            DrawingCollection tempList = null;
            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetLotteryDrawing", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", LotteryDrawingEnum.GetDate);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tempList = new DrawingCollection();
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

        private static Drawing FillDataRecord(IDataRecord myDataRecord)
        {
            Drawing myObject = new Drawing();

            myObject.DrawingId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("DrawingId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("LotteryId")))
                myObject.LotteryId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("LotteryId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("DrawingDate")))
                myObject.DrawingDate = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("DrawingDate"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Jackpot")))
                myObject.Jackpot = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Jackpot"));

            //notes: lottery specific properties

            return myObject;
        }
        #endregion

        #region INSERT AND UPDATE
        /// <summary>
        /// Saves the LotteryDrawing to the database. Determines to INSERT or UPDATE based on valid LotteryId.
        /// </summary>
        /// <param name="LotteryToSave"></param>
        /// <returns></returns>

        public static int Save(Drawing lotteryToSave)
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
                using (SqlCommand myCommand = new SqlCommand("usp_GetLotteryDrawing", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", queryId);

                    if (lotteryToSave.DrawingId > 0)
                        myCommand.Parameters.AddWithValue("@DrawingId", lotteryToSave.DrawingId);

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