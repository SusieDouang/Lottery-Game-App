using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VelocityCoders.LotteryGame.Models;
using VelocityCoders.LotteryGame.Models.Enums;
using VelocityCoders.LotteryGame.Models.BasicCollection;


namespace VelocityCoders.LotteryGame.DAL.BasicDAL
{
    public class BasicDrawingDAL
    {
        #region GET ITEM

        public static BasicDrawing GetItem(int drawingId)
        {
            BasicDrawing tempItem = null;     
            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetLotteryDrawing", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", LotteryDrawingEnum.GetItem);
                    myCommand.Parameters.AddWithValue("@DrawingId", drawingId);
                    

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.Read())
                        {
                            tempItem = FillDataDraw(myReader);
                        }
                        myReader.Close();
                    }
                }
            }
            return tempItem;
        }
        #endregion

        public static BasicDrawing GetItem()
        {
            BasicDrawing tempItem = null;
            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetLotteryDrawing", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;

                    myCommand.Parameters.AddWithValue("@QueryId", LotteryDrawingEnum.GetItemNumber);


                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.Read())
                        {
                            tempItem = FillNumber(myReader);
                        }
                        myReader.Close();
                    }
                }
            }
            return tempItem;
        }

        #region GET COLLECTION

        public static BasicDrawingCollection GetCollection()
        {
            BasicDrawingCollection tempList = null;
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
                            tempList = new BasicDrawingCollection();
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataDraw(myReader));
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

        public static BasicDrawingCollection GetCollectionResults(int drawingId, int lotteryId)
        {
            BasicDrawingCollection tempList = null;
            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetLotteryDrawing", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", LotteryDrawingEnum.GetDrawing);

                    myCommand.Parameters.AddWithValue("@DrawingId", drawingId);
                    myCommand.Parameters.AddWithValue("@LotteryId", lotteryId);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tempList = new BasicDrawingCollection();
                            while (myReader.Read())
                            {
                                tempList.Add(FillResults(myReader));
                            }
                            myReader.Close();
                        }
                    }
                    myConnection.Close();
                }
            }
            return tempList;
        }

        public static BasicDrawingCollection GetCollectionNumber()
        {
            BasicDrawingCollection tempList = null;
            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetLotteryDrawing", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", LotteryDrawingEnum.GetItemNumber);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tempList = new BasicDrawingCollection();
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataDraw(myReader));
                            }
                            myReader.Close();
                        }
                    }
                    myConnection.Close();
                }
            }
            return tempList;
        }




        #region INSERT AND UPDATE
        /// <summary>
        /// Save the Drawing to the database. Determines to INSERT or UPDATE based on the vaild DrawingId.
        /// </summary>
        /// <param name="drawingToSave"></param>
        /// <returns></returns>

        public static int Save(BasicDrawing drawingToSave)
        {
            int result = 0;
            ExecuteTypeEnum queryId = ExecuteTypeEnum.InsertItem;

            if (drawingToSave.DrawingId > 0)
                queryId = ExecuteTypeEnum.UpdateItem;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteLotteryDrawing", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", queryId);

                    if (drawingToSave.DrawingId != 0)
                        myCommand.Parameters.AddWithValue("@DrawingId", drawingToSave.DrawingId);

                    if (drawingToSave.LotteryId != 0)
                        myCommand.Parameters.AddWithValue("@LotteryId", drawingToSave.LotteryId);

                    if (drawingToSave.DrawingDate != DateTime.MinValue)
                        myCommand.Parameters.AddWithValue("@DrawingDate", drawingToSave.DrawingDate);

                    if (drawingToSave.Jackpot != 0)
                        myCommand.Parameters.AddWithValue("@Jackpot", drawingToSave.Jackpot);

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
        /// Delete a Draw from the Drawing table
        /// Returns true if number of records a affected are greater than 0.
        /// </summary>
        /// <param name="DrawingId"></param>
        /// <returns></returns>

        public static bool Delete(int drawingId)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteLotteryDrawing", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", ExecuteTypeEnum.DeleteItem);
                    myCommand.Parameters.AddWithValue("@DrawingId", drawingId);

                    myConnection.Open();
                    result = myCommand.ExecuteNonQuery();
                }
                myConnection.Close();
            }
            return result > 0;
        }

        #endregion

        #region HELPER METHOD

        private static BasicDrawing FillDataDraw(IDataRecord myDataRecord)
        {
            BasicDrawing myObject = new BasicDrawing();

            myObject.DrawingId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("DrawingId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("DrawingId")))
                myObject.DrawingId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("DrawingId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("LotteryId")))
                myObject.LotteryId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("LotteryId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("LotteryName")))
                myObject.BasicLottery.LotteryName = myDataRecord.GetString(myDataRecord.GetOrdinal("LotteryName"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("DrawingDate")))
                myObject.DrawingDate = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("DrawingDate"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Jackpot")))
                myObject.Jackpot = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Jackpot"));

            return myObject;
        }
        #endregion

        private static BasicDrawing FillResults(IDataRecord myDataRecord)
        {
            BasicDrawing myObject = new BasicDrawing();

            myObject.DrawingId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("DrawingId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("DrawingId")))
                myObject.DrawingId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("DrawingId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("LotteryId")))
                myObject.LotteryId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("LotteryId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("LotteryName")))
                myObject.BasicLottery.LotteryName = myDataRecord.GetString(myDataRecord.GetOrdinal("LotteryName"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("DrawingDate")))
                myObject.DrawingDate = myDataRecord.GetDateTime(myDataRecord.GetOrdinal("DrawingDate"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Number")))
                myObject.BasicWinningNumber.Number = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Number"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("BallType")))
                myObject.BasicBallType.BallType = myDataRecord.GetString(myDataRecord.GetOrdinal("BallType"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Jackpot")))
                myObject.Jackpot = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Jackpot"));

            return myObject;
        }

        private static BasicDrawing FillNumber(IDataRecord myDataRecord)
        {
            BasicDrawing myObject = new BasicDrawing();

            myObject.DrawingId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("DrawingId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Number")))
                myObject.BasicWinningNumber.Number = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Number"));

            return myObject;
        }

    }
}
