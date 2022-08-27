using System;
using System.Globalization;

namespace BookStore.Application.Utiliy;

public static class DateTimeHelper
{
    public static string ToShamsi(this DateTime val)
    {
        PersianCalendar persianCalendar = new PersianCalendar();
        return persianCalendar.GetYear(val) + "/" +
               persianCalendar.GetMonth(val).ToString("00") + "/" +
               persianCalendar.GetDayOfMonth(val).ToString("00");
    }
}
