﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;

/// <summary>
/// Summary description for RequestHandler
/// </summary>
public class RequestHandler
{
    public RequestHandler()
    {
      
    }
    /// <summary>
    /// This static method handles HttpRequest
    /// </summary>
    /// <param name="url"></param>
    /// <returns>Response</returns>
    public static string Process(string url)
    {
        var request = (HttpWebRequest)WebRequest.Create(url);
        HttpWebResponse HttpWResp = (HttpWebResponse)request.GetResponse();
        Stream streamResponse = HttpWResp.GetResponseStream();

        // And read it out
        StreamReader reader = new StreamReader(streamResponse);
        string response = reader.ReadToEnd();

        reader.Close();
        reader.Dispose();

        return response;
    }
}