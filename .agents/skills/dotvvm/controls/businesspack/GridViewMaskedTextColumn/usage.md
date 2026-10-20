# <bp:GridViewMaskedTextColumn>
## Properties
|Name|Type|Description|Notes|Default Value|
|---|---|---|---|---|
|`AdditionalPatterns`|Dictionary<Char,MaskPattern>||attribute, bindable||
|`AllowEditing`|Boolean||attribute, static value|True|
|`AllowFiltering`|Boolean||attribute, static value|False|
|`AllowInserting`|Boolean||attribute, static value|True|
|`AllowSorting`|Boolean||attribute, static value|False|
|`BooleanOperators`|List<IBooleanOperator>||inner element, static value||
|`CollectionOperators`|List<ICollectionOperator>||inner element, static value||
|`ColumnName`|String||attribute, static value||
|`CssClass`|String||attribute, static value, bindable||
|`DataContext`|Object|Gets or sets a data context for the control and its children. All value and command bindings are evaluated in context of this value.             The DataContext is null in client-side templates.|attribute, bindable||
|`DateTimeOperators`|List<IDateTimeOperator>||inner element, static value||
|`EditCssClass`|String||attribute, static value, bindable||
|`EnumOperators`|List<IEnumOperator>||inner element, static value||
|`FilterEditorTemplate`|ITemplate||inner element, static value, bindable||
|`FilterInline`|Boolean||attribute, static value|False|
|`FilterTemplate`|ITemplate||inner element, static value, bindable||
|`FooterCssClass`|String||attribute, static value, bindable||
|`FooterTemplate`|ITemplate||inner element, static value, bindable||
|`HeaderCssClass`|String||attribute, static value, bindable||
|`HeaderTemplate`|ITemplate||inner element, static value, bindable||
|`HeaderText`|String||attribute, static value, bindable||
|`InsertCssClass`|String||attribute, static value, bindable||
|`Mask`|String||attribute, static value||
|`NumberOperators`|List<INumberOperator>||inner element, static value||
|`Patterns`|Dictionary<Char,MaskPattern>||attribute, bindable||
|`Placeholder`|String||attribute, static value, bindable||
|`SortAscendingHeaderCssClass`|String||attribute, static value|dotvvm-bp-state_sorted-asc|
|`SortDescendingHeaderCssClass`|String||attribute, static value|dotvvm-bp-state_sorted-desc|
|`SortExpression`|String||attribute, static value||
|`StringOperators`|List<IStringOperator>||inner element, static value||
|`Title`|String||attribute, static value, bindable||
|`Value`|String||attribute, bindable||
|`Visible`|Boolean||attribute, bindable|True|
|`Width`|String||attribute, static value, bindable||

## Events
|Name|Type|Description|
|---|---|---|
|`Changed`|Command||

