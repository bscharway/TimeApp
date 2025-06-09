using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeZoneConverter;

namespace TimeApp.Components.Services
{
    public class TimeService
    {
        private readonly List<CityTime> _cities = new();
        public IReadOnlyList<CityTime> Cities => _cities.AsReadOnly();

        public DateTime GetUtcTime() => DateTime.UtcNow;

        public DateTime GetLocalTime(string timeZoneId)
        {
            try
            {
                var timeZoneInfo = TZConvert.GetTimeZoneInfo(timeZoneId);
                return TimeZoneInfo.ConvertTimeFromUtc(GetUtcTime(), timeZoneInfo);
            }
            catch
            {
                return GetUtcTime();
            }
        }

        public bool AddCity(string cityName, string timeZoneId)
        {
            try
            {
                var timeZoneInfo = TZConvert.GetTimeZoneInfo(timeZoneId);
                _cities.Add(new CityTime { Name = cityName, TimeZoneId = timeZoneId });
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void RemoveCity(string cityName)
        {
            _cities.RemoveAll(c => c.Name == cityName);
        }
    }

    public class CityTime
    {
        public string Name { get; set; } = string.Empty;
        public string TimeZoneId { get; set; } = string.Empty;
    }
}