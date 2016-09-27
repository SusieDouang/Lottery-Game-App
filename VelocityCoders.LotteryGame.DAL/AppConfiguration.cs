using System.Configuration;

namespace VelocityCoders.LotteryGame.DAL
{
    ///<summary>
    /// The AppConfiguration class contains read-only properties that are esstianlly short cuts to settings in the web.config file.
    ///</summary>

    public static class AppConfiguration
    {
        #region PUBLIC PROPERTIES

        ///<summary>
        /// Returns the connectionstring for the application.
        ///</summary>
        ///
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;
            }
        }

        ///<summary>
        /// Returns the name of the current connectionstring for the application
        ///</summary>

        public static string ConnectionStringName
        {
            get
            {
                return ConfigurationManager.AppSettings["ConnectionStringName"];
            }
        }
        #endregion
    }

}

