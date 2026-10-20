# <auto:AutoGridViewColumns>
## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AllowSorting`|Boolean||attribute, static value|False|
|`CellDecorators`|List<Decorator>|Gets or sets a list of decorators that will be applied on each cell which is not in the edit mode.|inner element, static value||
|`CssClass`|String||attribute, static value, bindable||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`EditCellDecorators`|List<Decorator>|Gets or sets a list of decorators that will be applied on each cell which is in the edit mode.|inner element, static value||
|`EditTemplate`|ITemplate||inner element, static value||
|`ExcludeProperties`|String[]|The specified properties will not be included in this form.|attribute, static value|System.String[]|
|`FilterTemplate`|ITemplate||inner element, static value, bindable||
|`GroupName`|String|Gets or sets the group of fields that should be rendered. If not set, fields from all groups will be rendered.|attribute, static value||
|`HeaderCellDecorators`|List<Decorator>|Gets or sets a list of decorators that will be applied on each header cell.|inner element, static value||
|`HeaderCssClass`|String||attribute, static value, bindable||
|`HeaderTemplate`|ITemplate||inner element, static value, bindable||
|`HeaderText`|String||attribute, static value, bindable||
|`IncludeProperties`|String[]|Only the specified properties will be included in this form. Using ViewName, GroupName or ExcludedProperties at the same time as IncludedProperties does not make sense. The properties will be listed in the exact order defined in this property.|attribute, static value||
|`IsEditable`|Boolean||attribute, static value|True|
|`SortAscendingHeaderCssClass`|String||attribute, static value|sort-asc|
|`SortDescendingHeaderCssClass`|String||attribute, static value|sort-desc|
|`SortExpression`|String||attribute, static value||
|`ViewName`|String|Gets or sets the view name (e.g. Insert, Edit, ReadOnly). Some fields may have different metadata for each view.|attribute, static value||
|`Visible`|Boolean||attribute, static value, bindable|True|
|`Width`|String||attribute, static value||

