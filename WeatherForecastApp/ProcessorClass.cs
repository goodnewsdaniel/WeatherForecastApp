using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherForecastApp
{
    
    public class ProcessorClass
    {
        /// <summary>
        /// This declares a public static Operations variable 
        /// </summary>
        public static Operations OP;

        /// <summary>
        /// This Constructor initializes the Operations variable
        /// </summary>
        public ProcessorClass() 
        {
            
            OP = new Operations();
        }

        /// <summary>
        /// This static method calls the Ger_localWeather 
        /// method of the Operations class
        /// </summary>
        public static void ProcessLocalWeather() {

            try
            {
                if (OP != null)
                {
                    OP.Get_LocalWeather();
                }
            }catch(Exception ){
            }
           
        }

        /// <summary>
        /// This static method calls the GerLocation 
        /// method of the Operations class
        /// </summary>
        public static void ProcessSearchLocation() {
            try
            {
                if (OP != null)
                {
                    OP.GetLocation();
                }
            }catch(Exception){
            }
        }

        /// <summary>
        /// This static method calls the GerTidalData 
        /// method of the Operations class
        /// </summary>
        public static void ProcessTidalData()
        {
            try
            {
                if (OP != null)
                {
                    OP.GetTidalData();
                }
            }catch(Exception){
            }
        }

        /// <summary>
        /// This static method calls the GerHistoricalData 
        /// method of the Operations class
        /// </summary>
        public static void ProcessHistoricalData()
        {
            try
            {
                if (OP != null)
                {
                    OP.GetHistoricalData();
                }
            }catch(Exception){
            }
        }
 
    }
}