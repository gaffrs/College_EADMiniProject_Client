//***Installed NuGet Microsoft.AspNet.WebApi Client ***

// 1) Using statements	….put in x6 Using statements
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BikeHire.Models;   //need to add the namespace for the Models, to access the Class


namespace BikeHireClient
{
    // test
    class BikeHireClient
    {
        // RunAsync awaits results from async methods so must be async itself
        static async Task RunAsync()                         // async methods return Task or Task<T>
        {
            try
            {
                using (HttpClient client = new HttpClient())                                            // Dispose() called autmatically in finally block
                {
                    client.BaseAddress = new Uri("http://localhost:5593/");                             // base URL for API Controller i.e. RESTFul service

                    // add an Accept header for JSON
                    client.DefaultRequestHeaders.
                        Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));            // or application/xml


                    // GET ../Bikes/all
                    // get all posts
                    Console.WriteLine("GET All Bikes");
                    HttpResponseMessage response = await client.GetAsync("api/bikesapi");                  // async call, await suspends until task finished            
                    if (response.IsSuccessStatusCode)                                                   // 200.299
                    {
                        // read result 
                        var result = await response.Content.ReadAsAsync<IEnumerable<Bike>>();
                        foreach (var r in result)                   //***NOTE: FOREACH....need to use IEnumerable****
                        {
                            Console.WriteLine(r);
                                                      
                        }
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }


                    // GET ../Hires/all
                    // get all posts
                    Console.WriteLine("GET All Hires");
                    response = await client.GetAsync("api/hiresapi");                  // async call, await suspends until task finished            
                    if (response.IsSuccessStatusCode)                                                   // 200.299
                    {
                        // read result 
                        var result = await response.Content.ReadAsAsync<IEnumerable<Hire>>();
                        foreach (var r in result)                   //***NOTE: FOREACH....need to use IEnumerable****
                        {
                            Console.WriteLine(r);
                        }
                    }
                    else
                    {
                        Console.WriteLine(response.StatusCode + " " + response.ReasonPhrase);
                    }



                    // GET bike/id/2    
                    Console.WriteLine("GET All Bikes with BikeID = 1");
                    try
                    {
                        response = await client.GetAsync("api/bikesapi/1");

                        response.EnsureSuccessStatusCode();                         // throw exception if not success
                        var result = await response.Content.ReadAsAsync<Bike>();
                        Console.WriteLine(result); 
                        //***NOTE: NO FOREACH....NO need to use IEnumerable****
                    }
                    catch (HttpRequestException e)
                    {
                        Console.WriteLine(e.Message);
                    }


                    // GET hire/id/2  
                    Console.WriteLine("GET All Hires with HireID = 1");
                try
                {
                    response = await client.GetAsync("api/hiresapi/1");

                    response.EnsureSuccessStatusCode();                         // throw exception if not success
                    var result = await response.Content.ReadAsAsync<Hire>();
                    Console.WriteLine(result);
                    //***NOTE: NO FOREACH....NO need to use IEnumerable****
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        // kick off
        static void Main()
        {
            Task result = RunAsync();               // convention is for async methods to finish in Async
            result.Wait();                          // block, not the same as await
        }
    }
}


