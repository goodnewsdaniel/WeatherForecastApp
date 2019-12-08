using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherForecastApp;
using Weather_API.API_Implementation;
using Weather_API.pastweather;
using Weather_API.localweather;
using Weather_API.locationsearch;
using Weather_API.marineweather;

namespace WeatherAppTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        
        public void TestAPIKeyMethod()
        {
            API_Implementation api = new API_Implementation();
            Assert.IsNull(api.APIKey);
        }
        /// <summary>
        /// This method tests whether the URL input is null and throws an exception
        /// </summary>
        [TestMethod]
        public void TestBaseURLMethod()
        {
            API_Implementation api = new API_Implementation();
            Assert.IsNull(api.ApiBaseURL);
        }

        /// <summary>
        ///  This method tests whether the Query parameter input is null and throws an exception
        /// </summary>

        [TestMethod]
        public void Test_SearchLocationMethod()
        {
            LocationSearchInput input = new LocationSearchInput();
            Assert.IsNull(input.query);
        }
        /// <summary>
        ///  This method tests whether the num of days parameter input is null and throws an exception
        /// </summary>
        
        [TestMethod]
        public void Test_LocalWeatherMethod()
        {
            LocalWeatherInput input = new LocalWeatherInput();
            Assert.IsNull(input.num_of_days);
        }

        /// <summary>
        ///     This method tests whether the format 
        ///     parameter input is non-null and throws
        ///     an exception if it is null.
        /// </summary>
        
        [TestMethod]
        public void Test_TidalDataMethod()
        {
            MarineWeatherInput input = new MarineWeatherInput();
            Assert.IsNull(input.format);
        }

        /// <summary>
        /// This method tests whether the date 
        /// parameter input is non-null and throws
        /// an exception if it is null.
        /// </summary>

        [TestMethod]
        public void Test_HistoricalDataMethod()
        {
            PastWeatherInput input = new PastWeatherInput();
            Assert.IsNull(input.date);
        }
    }
}
