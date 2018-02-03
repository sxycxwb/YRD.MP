using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;


/// <summary>
/// Http请求Helper类
/// </summary>
public class HttpHelper
{
    public static T PostAsJsonAsync<T>(string url, object model) where T : class, new()
    {
        try
        {
            var http = HttpClientHelper.GetClient();
            {
                HttpContent content = new StringContent(JsonConvert.SerializeObject(model));
               
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = http.PostAsync(url, content).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    T m = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
                    return m;
                }
                else
                {
                    return new T();
                }
                // var response = http.PostAsJsonAsync(url, model).Result;
                //                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                //                {
                //                    T m = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
                //                    return m;
                //                }
                //                else
                //                {
                //                    return new T();
                //                }
            }
        }
        catch(Exception e)
        {
            throw e;
            return new T();
            
        }
    }

    public static T PostAsync<T>(string url, Dictionary<string, string> p) where T : class, new()
    {
        try
        {
            var http = HttpClientHelper.GetClient();
            {
                var content = new FormUrlEncodedContent(p);
                var response = http.PostAsync(url, content).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    T m = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
                    return m;
                }
                else
                {
                    return new T();
                }
            }
        }
        catch
        {
            return new T();

        }
    }

    public static T GetAsync<T>(string url) where T : class, new()
    {
        try
        {
            var http = HttpClientHelper.GetClient();
            {
                var response = http.GetAsync(url).Result;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    T m = JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
                    return m;
                }
                else
                {
                    return new T();
                }
            }
        }
        catch
        {
            return new T();
        }
    }

    private static HttpClient _client;

    public static HttpClient GetClient()
    {
        try
        {
            if (_client == null)
            {
                _client = new HttpClient();
                _client.DefaultRequestHeaders.Connection.Add("keep-alive");
                _client.Timeout = new TimeSpan(0, 0, 30);
                return _client;
            }
            return _client;
        }
        catch (Exception)
        {
            return new HttpClient();
        }
    }

}
