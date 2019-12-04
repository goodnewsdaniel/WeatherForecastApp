using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Weather_API.localweather;
using Weather_API.locationsearch;
using Weather_API.timezone;
using Weather_API.marineweather;
using System.Collections;
using System.Reflection;
using Weather_API.pastweather;
using Weather_API.API_Implementation;

namespace WeatherForecastApp
{
    /// <summary>
    /// This Class provides Parameter inputs for API Consumption
    /// </summary>
    public class Constants : _Default
    {
        /// <summary>
        /// Global Variables Declaration
        /// </summary>
        public static String query;
        public static String Format;
        public static String Days;
        public static String Results;
        public static LocalWeatherInput input;
        public static API_Implementation api;
        public static LocalWeather localWeather;

        /// <summary>
        /// This Constructor initializes the global variables
        /// </summary>
        public Constants() 
        {

            query = SearchTextBox.Text.ToString();
            Format = "JSON";
            Days = NoOfDaysDropDownList.SelectedValue.ToString();
            Results = NoOfDaysDropDownList.SelectedValue.ToString();
            input = new LocalWeatherInput();
            api = new API_Implementation();
            localWeather = api.GetLocalWeather(input);
             
        }
        

        
    }
}