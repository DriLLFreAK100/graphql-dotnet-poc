using System;

namespace Demo.Server.Core.BusinessEntity.Enum
{
    public enum Month
    {
        Jan = 1,
        Feb = 2,
        Mar = 3,
        Apr = 4,
        May = 5,
        Jun = 6,
        Jul = 7,
        Aug = 8,
        Sep = 9,
        Oct = 10,
        Nov = 11,
        Dec = 12
    }

    public static class MonthExtensions
    {
        public static Month GetMonth(this DateTime dateTime)
        {
            switch (dateTime.Month)
            {
                case 1:
                    return Month.Jan;
                case 2:
                    return Month.Feb;
                case 3:
                    return Month.Mar;
                case 4:
                    return Month.Apr;
                case 5:
                    return Month.May;
                case 6:
                    return Month.Jun;
                case 7:
                    return Month.Jul;
                case 8:
                    return Month.Aug;
                case 9:
                    return Month.Sep;
                case 10:
                    return Month.Oct;
                case 11:
                    return Month.Nov;
                case 12:
                    return Month.Dec;
                default:
                    throw new Exception("Input is not a valid month, i.e. within 1 to 12");
            }
        }
    }
}
