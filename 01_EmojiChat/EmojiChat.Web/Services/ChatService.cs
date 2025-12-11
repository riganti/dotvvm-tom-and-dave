using DotVVM.Framework.ViewModel;
using EmojiChat.Web.Hubs;
using Microsoft.AspNetCore.SignalR;
using OpenAI.Responses;
using System;
using System.Threading.Tasks;

namespace EmojiChat.Web.Services;

public class ChatService(
    IHubContext<ChatHub> hubContext,
    OpenAIResponseClient responseClient)
{
    [AllowStaticCommand]
    public async Task Ask(string userMessage)
    {

        await hubContext.Clients.All.SendAsync("assistantMessageStarted");

        var prompt = $"""
            You are a DotVVM expert excited to talk about DotVVM at Update Conference Prague 2025.
            Any question you get explain using dotvvm. Respond using markdown syntax.
            Write short and consise answers. Write a lot of emojis. And also some fancy unicode characters.
            When you're writing code always put the language of the code in the code block so it renders with highlighting.
            
            The question is: {userMessage}
            """;

        await foreach (var update in responseClient.CreateResponseStreamingAsync(userInputText: prompt))
        {
            switch (update)
            {
                case StreamingResponseOutputTextDeltaUpdate delta when !string.IsNullOrEmpty(delta.Delta):
                    await hubContext.Clients.All.SendAsync("assistantMessageDelta", delta.Delta);
                    break;

                case StreamingResponseCompletedUpdate:
                    await hubContext.Clients.All.SendAsync("assistantMessageCompleted");
                    break;

                case StreamingResponseContentPartAddedUpdate:
                    await hubContext.Clients.All.SendAsync("streamingResponseContentPartAddedUpdate");
                    break;

                case StreamingResponseErrorUpdate error:
                    Console.WriteLine($"ERROR: {error.Code}, {error.Message}, {error.Param}");
                    break;

                case StreamingResponseFailedUpdate failed:
                    Console.WriteLine($"FAILED: {failed.Response.Error}");
                    break;
            }

            Console.WriteLine(update.GetType());
        }
    }
}
