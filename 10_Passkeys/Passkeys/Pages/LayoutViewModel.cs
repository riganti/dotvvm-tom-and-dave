using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Hosting;
using DotVVM.Controls.Tailwind.Controls;

namespace _10_Passkeys.Pages;

public class LayoutViewModel : DotvvmViewModelBase
{
    public List<NotificationData> Notifications { get; set; } = [];

    public string PageTitle { get; set; } = "_10_Passkeys";
}