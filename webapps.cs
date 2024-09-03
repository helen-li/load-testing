using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.Extensions.Primitives;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapGet("/", () => ReturnMatMultResult());

app.Run();

List<List<int>> RandomMatrix(int h, int w)
{
    Random rand = new Random();
    List<List<int>> matrix = Enumerable.Repeat(Enumerable.Repeat(rand.Next(), w).ToList(), h).ToList();
    return matrix;
}

List<List<int>> MatrixMultiplication(List<List<int>> m1, List<List<int>> m2)
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

int ReturnMatMultResult()
{
    int size = 300;

    List<List<int>> m1 = RandomMatrix(size, size);
    List<List<int>> m2 = RandomMatrix(size, size);
    var result = MatrixMultiplication(m1, m2);

    return result[0][0];
}
