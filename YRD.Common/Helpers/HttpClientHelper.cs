using System;
using System.Net.Http;

public class HttpClientHelper
{
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
