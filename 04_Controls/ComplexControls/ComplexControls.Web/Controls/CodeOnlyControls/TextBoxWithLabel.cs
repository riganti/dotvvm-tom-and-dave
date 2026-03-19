using DotVVM.Framework.Binding;
using DotVVM.Framework.Controls;
using DotVVM.Framework.Hosting;

namespace ComplexControls.Web.Controls;

public class TextBoxWithLabel : HtmlGenericControl
{
    public string LabelText
    {
        get { return (string)GetValue(LabelTextProperty); }
        set { SetValue(LabelTextProperty, value); }
    }
    public static readonly DotvvmProperty LabelTextProperty =
        DotvvmProperty.Register<string, TextBoxWithLabel>(c => c.LabelText);

    public string Text
    {
        get { return (string)GetValue(TextProperty); }
        set { SetValue(TextProperty, value); }
    }
    public static readonly DotvvmProperty TextProperty =
        DotvvmProperty.Register<string, TextBoxWithLabel>(c => c.Text);

    public TextBoxWithLabel() : base("div")
    {
    }

    protected override void OnInit(IDotvvmRequestContext context)
    {
        CssStyles.Add("display", "flex");
        CssStyles.Add("flex-direction", "column");
        CssStyles.Add("gap", "0.5rem");

        var textBox = new TextBox();
        textBox.SetBinding(TextBox.TextProperty, GetValueBinding(TextProperty));
        textBox.AddCssClasses("bg-gray-800 text-white border-gray-600 border-2 rounded");
    
        var label = new Literal(LabelText);
        Children.Add(label);
        Children.Add(textBox);

        base.OnInit(context);
    }
}