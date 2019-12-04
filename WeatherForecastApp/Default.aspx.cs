using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebSockets;
using System.Web.UI;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Net;
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
using System.Windows;

namespace WeatherForecastApp
{
    public partial class _Default : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// This event handler method calls 
        /// the ProcessLocalWeather method of the ProcessorClass class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DisplayWeatherForecastButton_Click(object sender, EventArgs e)
        {
            try
            {
                /* Set input parameters for the API */
                LocalWeatherInput input = new LocalWeatherInput();

                input.query = SearchTextBox.Text;
                input.num_of_days = NoOfDaysDropDownList.SelectedValue.ToString();
                input.format = "JSON";

                /*Call the LocalWeather method  and pass in the input parameters*/
                API_Implementation api = new API_Implementation();
                LocalWeather localWeather = api.GetLocalWeather(input);

                /* Display Output */
                DisplayResultsTextBox.Text = "\r\n Cloud Cover: " + localWeather.data.current_Condition[0].cloudcover;
                DisplayResultsTextBox.Text += "\r\n Humidity: " + localWeather.data.current_Condition[0].humidity;
                DisplayResultsTextBox.Text += "\r\n Temp C: " + localWeather.data.current_Condition[0].temp_C;
                DisplayResultsTextBox.Text += "\r\n Visibility: " + localWeather.data.current_Condition[0].weatherDesc[0].value;
                DisplayResultsTextBox.Text += "\r\n Observation Time: " + localWeather.data.current_Condition[0].observation_time;
                DisplayResultsTextBox.Text += "\r\n Pressure: " + localWeather.data.current_Condition[0].pressure;
                
                
            }catch(Exception ex){
                ex.GetBaseException();
            }
        }
        /// <summary>
        /// This event handler method calls 
        /// the ProcessTidalData method of the ProcessorClass class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DisplayTidalDataButton_Click(object sender, EventArgs e)
        {
           // ProcessorClass.ProcessTidalData();
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
            catch (Exception ex)
            {
                ex.GetBaseException();
            }
        }
        /// <summary>
        /// This event handler method calls 
        /// the ProcessHistoricalData method of the ProcessorClass class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DisplayHistoricalDataButton_Click(object sender, EventArgs e)
        {
            //ProcessorClass.ProcessHistoricalData();
            try
            {
                String location = SearchTextBox.Text.ToString();
                PastWeatherInput input = new PastWeatherInput();
                input.query = location;
                input.date = "2013-03-01";
                input.enddate = "2018-03-03";
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
            catch (Exception ex)
            {
                ex.GetBaseException();
            }
            
        }
        /// <summary>
        /// This event handler method calls 
        /// the ProcessLocation method of the ProcessorClass class
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SearchLocationButton_Click(object sender, EventArgs e)
        {
            //ProcessorClass.ProcessSearchLocation();
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

        protected void SearchTextBox_TextChanged(object sender, EventArgs e)
        {

        }

    }
}