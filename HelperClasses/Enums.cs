using System.ComponentModel;

namespace DAF.AirplaneTrafficData.HelperClasses
{
    public static class Enums
    {
        public enum AirportICAO
        {
            [Description("Indira Gandhi International Airport")]
            VIDP,
            [Description("Amsterdam Airport Schiphol")]
            EHAM,
            [Description("Ronald Reagan Washington National Airport")]
            KDCA
        }
    }
}