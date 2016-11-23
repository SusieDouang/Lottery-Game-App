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
    public class BasicBallTypeDAL
    {

        #region GET ITEM

        public static BasicBallType GetItem(int ballTypeId)
        {
            BasicBallType tempItem = null;
            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetBallType", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", BallTypeEnum.GetCollection);
                    myCommand.Parameters.AddWithValue("@BallTypeId", ballTypeId);



                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        {
                            if (myReader.Read())
                            {
                                tempItem = FillDataBallType(myReader);
                            }
                            myReader.Close();
                        }
                    }
                    myConnection.Close();
                }
            }
            return tempItem;
        }

        #endregion

        #region GET COLLECTION

        public static BasicBallTypeCollection GetCollection(BallTypeEnum description)
        {
            BasicBallTypeCollection tempList = null;
            using (SqlConnection myConnection = new SqlConnection(AppConfiguration.ConnectionString))
            {
                using (SqlCommand myCommand = new SqlCommand("usp_GetBallType", myConnection))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@QueryId", BallTypeEnum.GetCollection);

                    myConnection.Open();
                    using (SqlDataReader myReader = myCommand.ExecuteReader())
                    {
                        if (myReader.HasRows)
                        {
                            tempList = new BasicBallTypeCollection();
                            while (myReader.Read())
                            {
                                tempList.Add(FillDataBallType(myReader));
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

        #region HELPER METHOD

        private static BasicBallType FillDataBallType(IDataRecord myDataRecord)
        {
            BasicBallType myObject = new BasicBallType();

            myObject.BallTypeId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("BallTypeId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("BallTypeId")))
                myObject.BallTypeId = myDataRecord.GetInt32(myDataRecord.GetOrdinal("BallTypeId"));

            if (!myDataRecord.IsDBNull(myDataRecord.GetOrdinal("BallType")))
                myObject.BallType = myDataRecord.GetString(myDataRecord.GetOrdinal("BallType"));

            return myObject;

        } 

        #endregion  

    }
}
