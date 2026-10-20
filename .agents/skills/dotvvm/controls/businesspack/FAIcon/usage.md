# <bp:FAIcon>
Renders an icon from the [FontAwesome](http://fontawesome.io/) symbol pack.

The *Business Pack* uses the version _4.7_.

## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../../builtin/_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`Icon`|FAIconType||attribute, static value, bindable|Empty|
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`Visible`|Boolean||attribute, bindable|True|

## Sample 1: Basic Usage

The `Icon` property specifies which icon will be used.


```DOTHTML
<p>This is
<bp:FAIcon Icon="BombSolid" />-astic!</p>

```

