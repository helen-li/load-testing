#r "Newtonsoft.Json"

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

public static List<List<int>> RandomMatrix(int h, int w) 
{
    Random rand = new Random();
    List<List<int>> matrix = Enumerable.Repeat(Enumerable.Repeat(rand.Next(), w).ToList(), h).ToList();
    return matrix; 
}

public static List<List<int>> MatrixMultiplication(List<List<int>> m1, List<List<int>> m2) 
{
    int R1 = m1.Count;
    int R2 = m2.Count;
    int C1 = m1[0].Count;
    int C2 = m2[0].Count;

    List<List<int>> result = Enumerable.Repeat(Enumerable.Repeat(0, C2).ToList(), R1).ToList();

    for (int i = 0; i < R1; i++)
    {
        for (int j = 0; j < C2; j++)
        {
            for (int k = 0; k < R2; k++)
            {
                result[i][j] += m1[i][k] * m2[k][j];
            }
        }
    }
    
    return result;
}

public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
{
    log.LogInformation("C# HTTP trigger function processed a request.");

    string name = req.Query["name"];

    string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
    dynamic data = JsonConvert.DeserializeObject(requestBody);
    name = name ?? data?.name;

    string responseMessage = string.IsNullOrEmpty(name)
        ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

    int size = 300;

    List<List<int>> m1 = RandomMatrix(size,size);
    List<List<int>> m2 = RandomMatrix(size,size);
    var result = MatrixMultiplication(m1, m2);
    
    return new OkObjectResult(responseMessage);
}