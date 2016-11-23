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
    public class BasicWinningDAL
    {
        #region GET ITEM

        public static  BasicWinningNumber GetItem(int winningNumberId)
        {
            BasicWinningNumber tempItem = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetWinningNumber", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("QueryId", WinningNumberEnum.GetWinningNumberId);
                    myCommand.Parameters.AddWithValue("WinningNumberId", winningNumberId);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.Read())
                        {
                            tempItem = FillDataWin(myReader);
                        }
                        myReader.Close();
                    }
                }
            }
            return tempItem;
        }

        #endregion

        #region GET COLLECTION

        public static BasicWinningCollection GetCollectionWin()
        {
            BasicWinningCollection tempList = null;
            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetWinningNumber", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", WinningNumberEnum.GetCollection);
         

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        {
                            tempList = new BasicWinningCollection();
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataWin(myReader));
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

        #region INSERT, UPDATE
         
        public static int Save(BasicWinningNumber winningNumberToSave)
        {
            int result = 0;
            ExecuteTypeEnum queryId = ExecuteTypeEnum.InsertItem;

            if (winningNumberToSave.WinningNumberId > 0)
                queryId = ExecuteTypeEnum.UpdateItem;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteWinningNumber", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", queryId);

                    if (winningNumberToSave.WinningNumberId != 0)
                        myCommand.Parameters.AddWithValue("@WinningNumberId", winningNumberToSave.WinningNumberId);

                    if (winningNumberToSave.DrawingId != 0)
                        myCommand.Parameters.AddWithValue("@DrawingId", winningNumberToSave.DrawingId);

                    if (winningNumberToSave.BallTypeId > 0)
                        myCommand.Parameters.AddWithValue("@BallTypeId", winningNumberToSave.BallTypeId);

                    if (winningNumberToSave.Number != 0)
                        myCommand.Parameters.AddWithValue("@Number", winningNumberToSave.Number);
                      

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
        /// Delete a LotteryGame from the WinningNumber table
        /// Returns true if number of records a affected are greater than 0.
        /// </summary>
        /// <param name="WinningNumberId"></param>
        /// <returns></returns>

        public static bool Delete(int winningNumberId)
        {
            int result = 0;
            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_ExecuteWinningNumber", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", ExecuteTypeEnum.DeleteItem);
                    myCommand.Parameters.AddWithValue("@WinningNumberId", winningNumberId);

                    myConnection.Open();
                    result = myCommand.ExecuteNonQuery();
                }
                myConnection.Close();
            }
            return result > 0;
        }
        #endregion

        #region HELPER RECORD

        private static BasicWinningNumber FillDataWin(IDataRecord myDataRecord)
        {
            BasicWinningNumber myObject = new BasicWinningNumber();

            myObject.WinningNumberId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("WinningNumberId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("WinningNumberId")))
                myObject.WinningNumberId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("WinningNumberId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("DrawingId")))
                myObject.DrawingId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("DrawingId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("BallTypeId")))
            {
                myObject.BallTypeId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("BallTypeId"));
                myObject.BasicBallType = BasicBallTypeDAL.GetItem(myDataRecord.GetInt32(myDataRecord.GetOrdinal("BallTypeId")));
            }

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Number")))
                myObject.Number = myDataRecord.GetInt32(myDataRecord.GetOrdinal("Number"));

            

            return myObject;
        }

        #endregion
    }
}
