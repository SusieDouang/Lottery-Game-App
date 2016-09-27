

namespace VelocityCoders.LotteryGame.Models.Enums
{
    public enum SelectTypeEnum
    {
        None = 0,

        //Gets a single item from the database
        GetDate = 1,

        //Gets a single item from the database filtered by name
        GetItemOrderByDate = 2,

        //Gets a collection of items from the database
        GetLotteryGameNumbers = 3,

        //Gets a collection of filtered by EmployeeId
        GetCollection = 4,

    }
}
