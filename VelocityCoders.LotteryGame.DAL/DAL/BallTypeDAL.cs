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
    public static class BallTypeDAL
    {
        #region SELECT  
        ///<summary> 
        /// Get Collection of Lottery Ball Type.
        /// </summary>
        
        
        public static BallTypeCollection GetCollection(BallTypeEnum ballType)
        {
            BallTypeCollection tempItem = null;

            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetBallType", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", BallTypeEnum.GetCollection);
                    myCommand.Parameters.AddWithValue("@Description", ballType.ToString());
             

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tempItem = new BallTypeCollection();
                            while (myReader.Read())
                            {
                                tempItem.Add(FillDataRecordBallType(myReader));
                            }
                            myReader.Close();
                        }

                    }
                    //myConnection.Close();
                }
            }
            return tempItem;
        }

        #endregion

        #region HELPER METHODS

        public static BallType FillDataRecordBallType(IDataRecord myDataRecord)
        {
            BallType myObject = new BallType();

            myObject.BallTypeId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("BallTypeId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("Description")))
                myObject.Description = myDataRecord.GetString(myDataRecord.GetOrdinal("Description"));

            return myObject;
        }
        #endregion
    }
}
