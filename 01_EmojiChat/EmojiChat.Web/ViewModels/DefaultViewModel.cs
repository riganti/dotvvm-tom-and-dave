using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DotVVM.Framework.Hosting;
using DotVVM.Framework.ViewModel;
using Microsoft.AspNetCore.Http;

namespace EmojiChat.Web.ViewModels;

public class DefaultViewModel() : MasterPageViewModel
{
    public string Prompt { get; set; } = "What is DotVVM?";
    public string StreamingAnswer { get; set; } = "## Hello I'm mr. Riganti, ask me anything!";
    public bool IsConnected { get; set; }
    public bool IsLoading { get; set; }
    public bool WasJumping { get; set; } = false;

    public List<string> EventLists { get; set; } = [];
}