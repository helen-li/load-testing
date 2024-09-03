using System;

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

public static void Run(string myQueueItem, ILogger log)
{
    int size = 1000;

    List<List<int>> m1 = RandomMatrix(size,size);
    List<List<int>> m2 = RandomMatrix(size,size);
    var result = MatrixMultiplication(m1, m2);
    
    log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
}
