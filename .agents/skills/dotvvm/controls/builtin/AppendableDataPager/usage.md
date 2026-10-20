# <dot:AppendableDataPager>
## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`ClientIDMode`|([ClientIDMode](../_enums/DotVVM.Framework.Controls.ClientIDMode.md))|Gets or sets the client ID generation algorithm.|attribute, static value|Static|
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DataSet`|IGridViewDataSet|The data source GridViewDataSet (AppendableDataPager does not support plain collections)|attribute, bindable||
|`EndTemplate`|ITemplate|Template displayed when we are at the last page.|inner element, static value||
|`ID`|String|Gets or sets the control client ID within its naming container.|attribute, static value, bindable||
|`IncludeInPage`|Boolean|Gets or sets whether the control is included in the DOM of the page.|attribute, static value, bindable|True|
|`InnerText`|String|Gets or sets the inner text of the HTML element. Note that this property can only be used on HtmlGenericControl directly and when the control does not have any children.|attribute, static value, bindable||
|`LoadingTemplate`|ITemplate|Template displayed when the next page is being loaded|inner element, static value||
|`LoadTemplate`|ITemplate|Template displayed when more pages exist (not IsLastPage)             The template should contain a button triggering the loading of more data, it may use the {staticCommand: _dataPager.Load()} binding to invoke the LoadData function.             When this template isn't set, the pager will automatically load the next page when it becomes visible on screen.|inner element, static value, default property||
|`Visible`|Boolean|Gets or sets whether the control is visible. When set to false, `style="display: none"` will be added to this control.|attribute, static value, bindable|True|

## Events
|Name|Type|Description|
|---|---|---|
|`LoadData`|ICommandBinding|Gets or sets the (static) command that will be used to load the next page.             It is recommended to use a staticCommand in AppendableDataPager.             The command accepts one argument of type GridViewDataSetOptions`3 and should return a new GridViewDataSet`1 or GridViewDataSetResult`4.|

