# <bp:MaskedTextBox>
The `MaskedTextBox` control allows to force the entered value to exactly match the specified `Mask`. 

The mask is composed from patterns and hard-coded characters. All patterns are verified against regular expressions on client-side and server-side.

You are free to use the default patterns, specify your own `Patterns`, or use `AdditionalPatterns` to mix your own patters with the default. The default patterns are:

* `0` - Digit. Accepts any digit between 0 and 9.
* `9` - Digit or space. Accepts any digit between 0 and 9 or space.
* `#` - Digit, space, plus or minus. Accepts any digit between 0 and 9, space, and allows also the + (plus) and - (minus) signs.
* `L` - Letter. Restricts the input to a-z and A-Z letters. This rule is equivalent to [a-zA-Z] in regular expressions. 
* `?` - Letter or space. Restricts the input to letters a-z and A-Z and spaces. This rule is equivalent to [a-zA-Z\s] in regular expressions.
* `&` - Character. Accepts any character except a space. The rule is equivalent to \S in regular expressions.
* `C` - Character or space. Accepts any character. The rule is equivalent to `.` in regular expressions.
* `A` - Alphanumeric. Accepts letters and digits only.
* `a` - Alphanumeric or space. Accepts only letters, digits, and spaces.

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AdditionalPatterns`|Dictionary<Char,MaskPattern>||attribute, bindable||
|`AutoFocus`|Boolean||attribute, static value|False|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Enabled`|Boolean||attribute, static value, bindable|True|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`Mask`|String||attribute, static value||
|`Patterns`|Dictionary<Char,MaskPattern>||attribute, bindable||
|`Placeholder`|String||attribute, static value, bindable||
|`TabIndex`|Int32||attribute, static value, bindable|0|
|`Text`|String||attribute, bindable||
|`Visible`|Boolean||attribute, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`Changed`|Command||

## Sample 1: Basic Usage

The `Text` property is binding value of input.

The `Mask` property expects some string input, which defines the data for the control.

The `Placeholder` property works as placeholder on input element.

```DOTHTML
<bp:MaskedTextBox Mask="00/00/0000"
                  Placeholder="mm/dd/yyyy"
                  Text="{value: Text}" />
```

```CSHARP
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.MaskedTextBox.sample1
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string Text { get; set; }
    }
}
```

## Sample 2: Additional Patterns

The `AdditionalPatterns` property expects `Dictionary<char, MaskPattern>`, where the key is text character used in the mask, and `MaskPattern` defines regular expressions for client and server.

It extends the default patterns with your custom ones.

```DOTHTML
 <bp:MaskedTextBox Mask="LL0-11-22"
                   Placeholder="LL0-11-22"
                   Text="{value: Text}"
                   AdditionalPatterns="{value: AdditionalPatterns}" />
```

```CSHARP
using System.Collections.Generic;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.MaskedTextBox.sample2
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string Text { get; set; }

        public Dictionary<char, MaskPattern> AdditionalPatterns { get; set; } = new Dictionary<char, MaskPattern> {
            { '1', new MaskPattern("[0-1]") },
            { '2', new MaskPattern(@"\d") }
        };
    }
}
```

## Sample 3: Custom Patterns

The `Patterns` property expects `Dictionary<char, MaskPattern>`, where the key is text character used in the mask, and `MaskPattern` defines regular expressions for client and server.

Unlike the `AdditionalPatterns` property, this one will replace the default patterns.

```DOTHTML
 <bp:MaskedTextBox Mask="LL0-cc-nn"
                   Placeholder="LL0-cc-nn"
                   Text="{value: Text}"
                   Patterns="{value: Patterns}" />
```

```CSHARP
using System;
using System.Collections.Generic;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.ViewModel;

namespace DotvvmWeb.Views.Docs.Controls.businesspack.MaskedTextBox.sample3
{
    public class ViewModel : DotvvmViewModelBase
    {
        public string Text { get; set; }

        public Dictionary<char, MaskPattern> Patterns { get; set; } = new Dictionary<char, MaskPattern> {
            { 'c', new MaskPattern(@"\w") },
            { 'n', new MaskPattern(@"\d") }
        };
    }
}

```

