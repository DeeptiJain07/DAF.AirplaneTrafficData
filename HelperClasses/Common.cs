using System;

namespace DAF.AirplaneTrafficData.HelperClasses
{
    public static class Common
    {
        public static DateTime? UnixTimeStampToDateTime(int? unixTimeStamp)
        {
            if (unixTimeStamp == null)
                return null;

            // Unix timestamp is seconds past epoch
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(Convert.ToDouble(unixTimeStamp)).ToLocalTime();
            return dtDateTime;
        }
    }
}