# Integration guide

Meganav was designed to be as clean and easy for developers as it is for editors to use.

## Strongly typed models

Out of the box Meganav can return strongly typed models for a given navigation.

The following properties are available in the _MeganavItem_ class:

| Property          | Type              | Description |
|-------------------|-------------------|-------------|
| Id                | Int               | The node ID of the selected content item. For external linking nav items this will be "0" |
| Udi               | GuidUdi           | The node UDI of the selected content item. For external linking nav items this will be "0" |
| Title             | String            | The link title, often the node name |
| Target            | String            | The link target |
| Url               | String            | The link url |
| QueryString       | String            | The link querystring / anchor |
| Level             | Int               | The level in the overall navigation that the current item sits at |
| Content           | IPublishedContent | The IPublishedContent for the selected content item. For external linking nav items this will be null |
| Children          | List              | The picked child / sub items for the current item |

## Implementing Razor

Meganav was designed to closely follow the "Umbraco way" of doing things so we don't impose our own styles or markup on you.

It's easy to implement in your own Razor:

```csharp
<ul>
    @foreach (var item in Model.Value<IEnumerable<MeganavV8Item>>("megaNavV8"))
    {
        <li>
            ...
        </li>
    }
</ul>
```

**Note:** For large navigations with multiple levels it is highly recommended that you cache your navigation for optimal performance.

## Complex navigation

Meganav can build any size of navigation, from a small single level list to a large multi-level menu.

Based on the flexible implementation described above it would be possible to create a complex navigation varying on a number of factors, such as:

* The level of an item _(available via x.Level)_
* The doctype alias of an item _(available via x.Content.DocumentTypeAlias)_
* Any custom property _(available via x.Content.Value("..."))_
* Countless more...!
