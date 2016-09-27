using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VelocityCoders.LotteryGame.Models.Enums
{
    public enum ExecuteTypeEnum
    {
        ///<summary>
        /// Defaults to none.
        ///</summary>
        None = 0,

        ///<summary>
        /// Insert an item into the database.
        /// </summary>
        InsertItem = 10,

        ///<summary>
        /// Update an item in the database.
        ///</summary>
        UpdateItem = 20,

        ///<summary> 
        ///Delete an item from the database.
        /// </summary>
        DeleteItem = 30,
    }
}