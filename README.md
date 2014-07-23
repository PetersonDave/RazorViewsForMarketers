Razor Views For Marketers
======================

Razor Views for Marketers is a razor view rendering engine for Web Forms For Marketers. Through Blade, we're able to use MVC-style razor views and model binding to take full control over Web Forms for Marketers rendered markup.

##Blade

By leveraging blade, we're able to use a templating format to define how the form, field sections and fields are rendered. This allows the developer to take full control of field-specific formatting through strongly-typed views and models. 

##Dynamic Model Binding

Since Web Forms for Marketers is completely data-driven, field types must be dynamically driven at runtime. A combination of dynamic model binding and MVC editor templates provide full customization for already supported Web Forms for Marketers fields and any new custom field types.

##Getting Started

_note: nuget package to be created toreplace manual steps below_

1. Install Blade
2. Add a reference to RazordViewsForMarketers (or copy dll to bin)
3. Copy _/App_Config/Include/RazorViewsForMarketers.config_ into includes folder.
4. Update global.asax for dynamic model binding:

```c#
    public void Application_Start()
    {
        // provider overrides
        ModelMetadataProviders.Current = new CustomModelMetadataProvider();

        // model binding overrides
        ModelBinders.Binders.Add(typeof(WffmField), new WffmFieldModelBinder());
    }
```

5. Copy _/Views/*_ to website root
6. In Sitecore, install package /Packages/Razor-Views-For-Marketers-Rendering.zip
7. Add 

##How to Contribute

