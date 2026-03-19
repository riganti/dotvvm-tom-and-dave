using DotVVM.Framework.Binding;
using DotVVM.Framework.Controls;

namespace ComplexControls.Web.Controls;

public class AddressForm : DotvvmMarkupControl
{
    public string Street         
    {
        get { return (string)GetValue(StreetProperty); }
        set { SetValue(StreetProperty, value); }
    }
    public static readonly DotvvmProperty StreetProperty = 
        DotvvmProperty.Register<string, AddressForm>(c => c.Street);
    public string City         
    {
        get { return (string)GetValue(CityProperty); }
        set { SetValue(CityProperty, value); }
    }
    public static readonly DotvvmProperty CityProperty = 
        DotvvmProperty.Register<string, AddressForm>(c => c.City);
    public string State         
    {
        get { return (string)GetValue(StateProperty); }
        set { SetValue(StateProperty, value); }
    }
    public static readonly DotvvmProperty StateProperty = 
        DotvvmProperty.Register<string, AddressForm>(c => c.State);
    public string ZipCode        
    {
        get { return (string)GetValue(ZipCodeProperty); }
        set { SetValue(ZipCodeProperty, value); }
    }
    public static readonly DotvvmProperty ZipCodeProperty = 
        DotvvmProperty.Register<string, AddressForm>(c => c.ZipCode);
    public bool IsHuman         
    {
        get { return (bool)GetValue(IsHumanProperty); }
        set { SetValue(IsHumanProperty, value); }
    }
    public static readonly DotvvmProperty IsHumanProperty = 
        DotvvmProperty.Register<bool, AddressForm>(c => c.IsHuman);
}