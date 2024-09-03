using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    
    static async Task Main(string[] args)
    {
        try
        {
            HttpClient httpClient = new HttpClient();
            string functionEndpoint = "";  // your endpoint url
            httpClient.Timeout = TimeSpan.FromMinutes(20);

            int numRequests = 1000;
            Console.WriteLine("Sending requests to function endpoint...");

            // Create a list of tasks to send multiple requests concurrently
            var tasks = new Task<HttpResponseMessage>[numRequests];
            for (int i = 0; i < tasks.Length; i++)
            {
                Console.WriteLine($"Started request {i + 1}...");
                tasks[i] = httpClient.GetAsync(functionEndpoint);
            }

            // Wait for all tasks to complete
            var responses = await Task.WhenAll(tasks);

            // Process each response
            foreach (var response in responses)
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Response received successfully!");
                    Console.WriteLine(content);
                }
                else
                {
                    Console.WriteLine($"Failed to call the function endpoint. Status code: {response.StatusCode}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
