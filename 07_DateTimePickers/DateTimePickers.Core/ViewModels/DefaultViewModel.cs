using System;
using DotVVM.Framework.ViewModel;

namespace DateTimePickers.Core.ViewModels;

public class DefaultViewModel : DotvvmViewModelBase
{

    public DateTime SelectedDate { get; set; } = DateTime.Now;

}