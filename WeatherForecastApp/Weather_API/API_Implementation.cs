using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Script.Serialization;
using Weather_API.localweather;
using Weather_API.locationsearch;
using Weather_API.timezone;
using Weather_API.marineweather;
using Weather_API.pastweather;

namespace Weather_API.API_Implementation
{
/// <summary>
/// This class implements the API
/// </summary>
public class API_Implementation
{
    /// <summary>
    /// These are the API URL and Key
    /// </summary>
    public string ApiBaseURL = ConfigurationManager.AppSettings["ApiBaseURL"];
    public string APIKey = ConfigurationManager.AppSettings["APIKey"];

    /// <summary>
    /// This method gets local weather condition
    /// </summary>
    /// <param name="input"></param>
    /// <returns>local weather</returns>
    public LocalWeather GetLocalWeather(LocalWeatherInput input)
    {
        /*Create URL based on input paramters*/
        string apiURL = ApiBaseURL + "weather.ashx?q=" + input.query + "&format=" + input.format + "&extra=" + input.extra + "&num_of_days=" + input.num_of_days + "&date=" + input.date + "&fx=" + input.fx + "&cc=" + input.cc + "&includelocation=" + input.includelocation + "&show_comments=" + input.show_comments + "&callback=" + input.callback + "&key=" + APIKey;

        /*Get the web response*/
        string result = RequestHandler.Process(apiURL);

        /*Serialize the json output and parse in the helper class*/
        LocalWeather lWeather = (LocalWeather)new JavaScriptSerializer().Deserialize(result, typeof(LocalWeather));

        return lWeather;
    }

    /// <summary>
    /// THis method searches for given location 
    /// and provides specific data
    /// </summary>
    /// <param name="input"></param>
    /// <returns>location search results</returns>
    public LocationSearch SearchLocation(LocationSearchInput input)
    {
        /*Create URL based on input paramters*/
        string apiURL = ApiBaseURL + "search.ashx?q=" + input.query + "&format=" + input.format + "&timezone=" + input.timezone + "&popular=" + input.popular + "&num_of_results=" + input.num_of_results + "&callback=" + input.callback + "&key=" + APIKey;

        /*Get the web response*/
        string result = RequestHandler.Process(apiURL);

        /*Serialize the json output and parse in the helper class*/
        LocationSearch locationSearch = (LocationSearch)new JavaScriptSerializer().Deserialize(result, typeof(LocationSearch));

        return locationSearch;
    }

    /// <summary>
    /// This method gets the timezone 
    /// of a given location
    /// </summary>
    /// <param name="input"></param>
    /// <returns>location timezone</returns>
    public Timezone GetTimeZone(TimeZoneInput input)
    {
        /* Create URL based on input paramters */
        string apiURL = ApiBaseURL + "tz.ashx?q=" + input.query + "&format=" + input.format + "&callback=" + input.callback + "&key=" + APIKey;

        /* Get the web response*/
        string result = RequestHandler.Process(apiURL);

        /*Serialize the json output and parse in the helper class*/
        Timezone timeZone = (Timezone)new JavaScriptSerializer().Deserialize(result, typeof(Timezone));

        return timeZone;
    }

    /// <summary>
    /// This method gets the tidal data of 
    /// a given location in a given period of time 
    /// </summary>
    /// <param name="input"></param>
    /// <returns>tidal data</returns>
    public MarineWeather GetMarineWeather(MarineWeatherInput input)
    {
        /* Create URL based on input paramters */
        string apiURL = ApiBaseURL + "marine.ashx?q=" + input.query + "&format=" + input.format + "&fx=" + input.fx + "&callback=" + input.callback + "&key=" + APIKey;

        /*Get the web response*/
        string result = RequestHandler.Process(apiURL);

        /*Serialize the json output and parse in the helper class*/
        MarineWeather mWeather = (MarineWeather)new JavaScriptSerializer().Deserialize(result, typeof(MarineWeather));

        return mWeather;
    }

    /// <summary>
    /// This method gets the historical
    /// weather data of a given location
    /// for a given period of time
    /// </summary>
    /// <param name="input"></param>
    /// <returns>weather history</returns>
    public PastWeather GetPastWeather(PastWeatherInput input)
    {
        /* Create URL based on input paramters */
        string apiURL = ApiBaseURL + "past-weather.ashx?q=" + input.query + "&format=" + input.format + "&extra=" + input.extra + "&enddate=" + input.enddate + "&date=" + input.date + "&includelocation=" + input.includelocation + "&callback=" + input.callback + "&key=" + APIKey;

        /* Get the web response */
        string result = RequestHandler.Process(apiURL);

        /* Serialize the json output and parse in the helper class */
        PastWeather pWeather = (PastWeather)new JavaScriptSerializer().Deserialize(result, typeof(PastWeather));

        return pWeather;
    }

}
}