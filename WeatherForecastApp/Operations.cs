using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
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
    public class Operations : _Default
    {
        public Operations() 
        { 
        
        }
        /// <summary>
        /// This method consumes the API to display local weather
        /// </summary>
        public void Get_LocalWeather() 
        {
            try
            {
                /* Set input parameters for the API */
                LocalWeatherInput input = new LocalWeatherInput();

                input.query = Constants.query;
                input.num_of_days = Constants.Days;
                input.format = Constants.Format;

                /*Call the LocalWeather method  and pass in the input parameters*/
                API_Implementation api = new API_Implementation();
                LocalWeather localWeather = api.GetLocalWeather(input);
                    
                /* Display Output */
                DisplayResultsTextBox.Text = "\r\n Cloud Cover: " + localWeather.data.current_Condition[0].cloudcover;
                DisplayResultsTextBox.Text += "\r\n Humidity: " + localWeather.data.current_Condition[0].humidity;
                DisplayResultsTextBox.Text += "\r\n Temp C: " + localWeather.data.current_Condition[0].temp_C;
                DisplayResultsTextBox.Text += "\r\n Visibility: " + localWeather.data.current_Condition[0].weatherDesc[0].value;
                DisplayResultsTextBox.Text += "\r\n Observation Time: " + localWeather.data.current_Condition[0].observation_time;
                DisplayResultsTextBox.Text += "\r\n Pressue: " + localWeather.data.current_Condition[0].pressure;
            }
            catch (Exception ex)
            {
                ex.GetBaseException();
            }
        }

        /// <summary>
        /// This method consumes the API to display location
        /// </summary>
        public void GetLocation()
        {
            try
            {
                String results = NoOfDaysDropDownList.SelectedValue.ToString();
                String Format = "JSON";

                /*Set input parameters for the API*/
                LocationSearchInput input = new LocationSearchInput();
                input.query = SearchTextBox.Text;
                input.num_of_results = results;
                input.format = Format;

                /* Call the SearchLocation method and pass in the input parameters*/
                API_Implementation api = new API_Implementation();
                LocationSearch locationSearch = api.SearchLocation(input);

                /*Display Results*/
                DisplayResultsTextBox.Text = "\r\n Area Name: " + locationSearch.search_API.result[0].areaName[0].value;
                DisplayResultsTextBox.Text += "\r\n Country: " + locationSearch.search_API.result[0].country[0].value;
                DisplayResultsTextBox.Text += "\r\n Latitude: " + locationSearch.search_API.result[0].latitude;
                DisplayResultsTextBox.Text += "\r\n Longitude: " + locationSearch.search_API.result[0].longitude;
                DisplayResultsTextBox.Text += "\r\n Population: " + locationSearch.search_API.result[0].population;
                DisplayResultsTextBox.Text += "\r\n Region: " + locationSearch.search_API.result[0].region[0].value;

            }
            catch (Exception ex)
            {
                ex.GetBaseException();
            }
        }

        /// <summary>
        /// This method consumes the World Weather 
        /// Premium API to show location TimeZone in JSON Format
        /// </summary>
        public void GetTimeZone()
        {
            try {
                /* Set input parameters for the API */
                String Format = "JSON";
                TimeZoneInput input = new TimeZoneInput();
                input.query = SearchTextBox.Text;
                input.format = Format;

                /* Call GetTimeZone method with input parameters */
                API_Implementation api = new API_Implementation();
                Timezone timeZone = api.GetTimeZone(input);

                /*Display Results*/
                DisplayResultsTextBox.Text = "\r\n Local Time: " + timeZone.data.time_zone[0].localtime;
                DisplayResultsTextBox.Text += "\r\n Time Offset: " + timeZone.data.time_zone[0].utcOffset;
            }
            catch (Exception ex) { 
            ex.GetBaseException();
            }
            }

        /// <summary>
        /// This method consumes the World Weather 
        /// PremiumAPI to show marine data in JSON format,
        /// and display results in a Textbox
        /// </summary>
        public void GetTidalData()
        {
            try
            {
                /* Set input parameters for the API */
                MarineWeatherInput input = new MarineWeatherInput();
                input.query = "45,-2";
                input.format = "JSON";

                /* Call GetMarineWeather() method with input parameters */
                API_Implementation api = new API_Implementation();
                MarineWeather marineWeather = api.GetMarineWeather(input);

                /* Display Results */
                DisplayResultsTextBox.Text = "\r\n Date: " + marineWeather.data.weather[0].date;
                DisplayResultsTextBox.Text += "\r\n Min Temp (c): " + marineWeather.data.weather[0].mintempC;
                DisplayResultsTextBox.Text += "\r\n Max Temp (c): " + marineWeather.data.weather[0].maxtempC;
                DisplayResultsTextBox.Text += "\r\n Cloud Cover: " + marineWeather.data.weather[0].hourly[0].cloudcover;
            }
            catch (Exception ex) {
                ex.GetBaseException();
            }
        }

        /// <summary>
        /// This method consumes the WorldWeather Premium API
        /// to show past weather data of any given location
        /// for a given period
        /// </summary>
        public void GetHistoricalData()
        {
            try
            {
                String location = SearchTextBox.Text.ToString();
                PastWeatherInput input = new PastWeatherInput();
                input.query = location;
                input.date = "2017-01-01";
                input.enddate = "2019-01-01";
                input.format = "JSON";

                /* Call the GetPastWeather method and pass in input parameters*/
                API_Implementation api = new API_Implementation();
                PastWeather pastWeather = api.GetPastWeather(input);

                /*Display Results*/
                DisplayResultsTextBox.Text = "\r\n Date: " + pastWeather.data.weather[0].date;
                DisplayResultsTextBox.Text += "\r\n Max Temp(C): " + pastWeather.data.weather[0].maxtempC;
                DisplayResultsTextBox.Text += "\r\n Max Temp(F): " + pastWeather.data.weather[0].maxtempF;
                DisplayResultsTextBox.Text += "\r\n Min Temp(C): " + pastWeather.data.weather[0].mintempC;
                DisplayResultsTextBox.Text += "\r\n Min Temp(F): " + pastWeather.data.weather[0].mintempF;
                DisplayResultsTextBox.Text += "\r\n Cloud Cover: " + pastWeather.data.weather[0].hourly[0].cloudcover;
            }
            catch (Exception ex) {
                ex.GetBaseException();
            }

        }
    }
}