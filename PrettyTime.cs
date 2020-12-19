using System;

namespace Matix.PrettyTime
{
    public class PrettyTime
    {
        /// <summary>
        /// Get pretty time out of a TimeSpan
        /// </summary>
        /// <param name="s">TimeSpan value</param>
        /// <returns></returns>
        static string GetPrettyTime(TimeSpan s)
        {
            int dayDiff = (int)s.TotalDays;

            int secDiff = (int)s.TotalSeconds;

            if (dayDiff < 0 || dayDiff >= 31)
            {
                return null;
            }

            if (dayDiff == 0)
            {
                if (secDiff < 60)
                {
                    return "just now";
                }
                if (secDiff < 120)
                {
                    return "1 minute ago";
                }
                if (secDiff < 3600)
                {
                    return string.Format("{0} minutes ago",
                        Math.Floor((double)secDiff / 60));
                }
                if (secDiff < 7200)
                {
                    return "1 hour ago";
                }
                if (secDiff < 86400)
                {
                    return string.Format("{0} hours ago",
                        Math.Floor((double)secDiff / 3600));
                }
            }
            if (dayDiff == 1)
            {
                return "yesterday";
            }
            if (dayDiff < 7)
            {
                return string.Format("{0} days ago",
                    dayDiff);
            }
            if (dayDiff < 31)
            {
                return string.Format("{0} weeks ago",
                    Math.Ceiling((double)dayDiff / 7));
            }
            return null;
        }

        /// <summary>
        /// Get pretty time from DateTime (Elapsed Time gets automatically calculated.
        /// </summary>
        /// <param name="d">DateTime value</param>
        /// <returns></returns>
        static string GetPrettyEleapsedTime(DateTime d)
        {
            TimeSpan s = DateTime.Now.Subtract(d);

            return GetPrettyTime(s);
        }
    }
}
