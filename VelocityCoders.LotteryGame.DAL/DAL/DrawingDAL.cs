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
                        {
                            tempItem = FillDataRecord(myReader);
                        }
                        myReader.Close();
                    }
                    myConnection.Close();
                }
            }
            return tempItem;
        }

        public static DrawingCollection GetCollection(int lotteryId)
        {
                DrawingCollection tempList = null;
                using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
                {
                    using (SqlCommand myCommand = new SqlCommand("usp_GetLotteryDrawing", myConnection))
                    {
                        myCommand.CommandType = CommandType.StoredProcedure;
                        myCommand.Parameters.AddWithValue("@QueryId", LotteryDrawingEnum.GetDate);
                        myCommand.Parameters.AddWithValue("@LotteryId", lotteryId);

                    myConnection.Open();
                        using (SqlDataReader myReader = myCommand.ExecuteReader())
                        {
                            {
                                tempList = new DrawingCollection();
                                while (myReader.Read())
                                {
                                    tempList.Add(FillDataRecord(myReader));
                                }
                                myReader.Close();
                            } 
                        }
                        myConnection.Close();
                    }
                }
                return tempList;
        }

        public static DrawingCollection GetCollectionDraw()
        {
            DrawingCollection tempList = null;
            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetLotteryDrawing", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", LotteryDrawingEnum.GetCollection);
                    

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        {
                            tempList = new DrawingCollection();
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecordDraw(myReader));
                            }
                            myReader.Close();
                        }
                    }
                    myConnection.Close();
                }
            }
            return tempList;
        }

        ///<summary>
        /// Get a collection of Drawings. If no records to return, DrawingCollection object will be null. 
        /// </summary>
        /// <returns></returns>

        public static  DrawingCollection GetCollection(LotteryDrawingEnum lotteryDrawing)
        {
            DrawingCollection tempList = null;
            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetLotteryDrawing", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", LotteryDrawingEnum.GetCollection);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tempList = new DrawingCollection();
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataRecord(myReader));
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

        private static Drawing FillDataRecordDraw(IDataRecord myDataRecord)
        {
            Drawing myObject = new Drawing();

            myObject.DrawingId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("DrawingId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("LotteryName")))
                myObject.LotteryName = myDataRecord.GetString(myDataRecord.GetOrdinal("LotteryName"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("DrawingDate")))
                myObject.DrawingDate = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("DrawingDate"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Jackpot")))
                myObject.Jackpot = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Jackpot"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Number")))
                myObject.WinningNumber.Number = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Number"));

            //if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Number")))
            //    myObject.WinningNumber.Number = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Number"));

            //if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Number")))
            //    myObject.WinningNumber.Number = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Number"));

            //if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Number")))
            //    myObject.WinningNumber.Number = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Number"));

            //if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Number")))
            //    myObject.WinningNumber.Number = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Number"));

            //if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Number")))
            //    myObject.WinningNumber.Number = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Number"));

            //notes: lottery specific properties

            return myObject;
        }


        private static Drawing FillDataRecord(IDataRecord myDataRecord)
        {
            Drawing myObject = new Drawing();

            myObject.DrawingId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("DrawingId"));

            //if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("LotteryName")))
            //    myObject.LotteryName = myDataRecord.GetString(myDataRecord.GetOrdinal("LotteryName"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("DrawingDate")))
                myObject.DrawingDate = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("DrawingDate"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Jackpot")))
                myObject.Jackpot = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Jackpot"));

            //if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Number")))
            //    myObject.WinningNumber.Number = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Number"));

            //if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Number")))
            //    myObject.WinningNumber.Number = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Number"));

            //if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Number")))
            //    myObject.WinningNumber.Number = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Number"));

            //if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Number")))
            //    myObject.WinningNumber.Number = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Number"));

            //if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Number")))
            //    myObject.WinningNumber.Number = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Number"));

            //if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Number")))
            //    myObject.WinningNumber.Number = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Number"));

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

        public static int Save(Drawing drawingToSave)
        {
            int result = 0;
            ExecuteTypeEnum queryId = ExecuteTypeEnum.InsertItem;

            //notes: check for vaild DrawingId - if exists then UPDATE, else INSERT
            //      10 = INSERT_ITEM
            //      20 = UPDATE_ITEM

            if (drawingToSave.LotteryId > 0)
                queryId = ExecuteTypeEnum.UpdateItem;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteLotteryDrawing", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", queryId);

                    //if (drawingToSave.DrawingId > 0)
                    //    myCommand.Parameters.AddWithValue("@DrawingId", drawingToSave.DrawingId);

                    if (drawingToSave.DrawingDate != null)
                        myCommand.Parameters.AddWithValue("@DrawingDate", drawingToSave.DrawingDate.ToShortDateString());

                    if (drawingToSave.Jackpot != 0)
                        myCommand.Parameters.AddWithValue("@Jackpot", drawingToSave.LotteryNameAbbreviation);

                    if (drawingToSave.Number != null)
                        myCommand.Parameters.AddWithValue("@Number", drawingToSave.Number);

                    //if (drawingToSave.WinningNumber != null)
                    //    myCommand.Parameters.AddWithValue("@Number", drawingToSave.WinningNumber);

                    //if (drawingToSave.WinningNumber != null)
                    //    myCommand.Parameters.AddWithValue("@Number", drawingToSave.WinningNumber);

                    //if (drawingToSave.WinningNumber != null)
                    //    myCommand.Parameters.AddWithValue("@Number", drawingToSave.WinningNumber);

                    //if (drawingToSave.WinningNumber != null)
                    //    myCommand.Parameters.AddWithValue("@Number", drawingToSave.WinningNumber);

                    //if (drawingToSave.WinningNumber != null)
                    //    myCommand.Parameters.AddWithValue("@Number", drawingToSave.WinningNumber);

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
        }
            #endregion

        #region DELETE
        ///<summary>
        /// Delete a drawing from the Drawing table.
        /// Returns true if number of records affected is greater than 0.
        ///</summary>
        ///<param name="drawingId"></param>

        public static bool Delete(int drawingId)
        {
            int results = 0;
            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteLottery", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", ExecuteTypeEnum.DeleteItem);
                    myCommand.Parameters.AddWithValue("@DrawingId", drawingId);

                    myConnection.Open();
                    results = myCommand.ExecuteNonQuery();
                }
                myConnection.Close();
            }
            return results > 0;
        }
        #endregion
    }
}