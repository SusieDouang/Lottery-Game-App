

namespace VelocityCoders.LotteryGame.Models.Enums
{
    public enum SelectTypeEnum
    {
        None = 0,

        //Gets a single item from the database
        GetItem = 1,

        //Gets a single item from the database filtered by name
        GetItemLotteryName = 2,

        //Gets a collection of items from the database
        GetItemLotteryNameCollection = 3,

        //Gets a collection of filtered by Id
        GetCollection = 4,

        //Gets Item - LotteryId
        GetLotteryId = 5

    }
}
