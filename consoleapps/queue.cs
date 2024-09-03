using System; // Namespace for Console output
using System.Configuration; // Namespace for ConfigurationManager
using System.Globalization;
using System.Threading.Tasks; // Namespace for Task
using Azure.Storage.Queues; // Namespace for Queue storage types
using Azure.Storage.Queues.Models; // Namespace for PeekedMessage


string connectionString = ""; // your storage account connection string
int messageCountPerThread = 1000;
int threadCount = 500;

// Instantiate a QueueClient which will be used to create and manipulate the queue
QueueClient queueClient = new QueueClient(connectionString, "queueName");

for (int j = 0; j < threadCount; j++)
{
    Thread thread = new Thread(() => AddMessagesToQueue(queueClient, messageCountPerThread));
    Console.WriteLine($"Starting thread # {j + 1}");
    thread.Start();
}

void AddMessagesToQueue(QueueClient queueClient, int messageCount)
{
    Console.WriteLine("Starting to write messages to queue!");
    for (int i = 0; i < messageCount; i++)
    {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes($"message {i}");
        queueClient.SendMessage(System.Convert.ToBase64String(plainTextBytes));
    }
}
