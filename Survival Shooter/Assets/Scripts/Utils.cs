public static class Utils
{
    public static string getTimeFromSeconds(int time)
    {
        // minute, second from seconds
        int minute = time / 60;
        int second = time % 60;
        string timeString = "";
        if (minute < 10)
        {
            timeString += "0" + minute + ":";
        }
        else
        {
            timeString += minute + ":";
        }
        if (second < 10)
        {
            timeString += "0" + second;
        }
        else
        {
            timeString += second;
        }
        return timeString;
    }

    public static int getSecondsFromTimeString(string timeString)
    {
        //get seconds from time string
        string[] time = timeString.Split(':');
        int minute = int.Parse(time[0]);
        int second = int.Parse(time[1]);
        return minute * 60 + second;
    }

}
