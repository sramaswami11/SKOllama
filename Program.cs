// See https://aka.ms/new-console-template for more information

using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

var kernelBuilder = Kernel.CreateBuilder();

#pragma warning disable SKEXP0070 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
var kernel = kernelBuilder
    .AddOllamaChatCompletion(
      modelId: "phi3:medium",
      endpoint:new Uri("http://localhost:11434"))
    .Build();
//#pragma warning restore SKEXP0070 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.


var aiModel = kernel.GetRequiredService<IChatCompletionService>();

while (true)
{
    Console.Write("Your Question:");
    var question = Console.ReadLine();

    await foreach (var message  in aiModel.GetStreamingChatMessageContentsAsync(question,kernel:kernel))
    {
        Console.Write(message);
    }
    Console.WriteLine();
}
