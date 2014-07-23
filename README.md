Razor Views For Marketers
======================

Razor Views for Marketers is a razor view rendering engine for Web Forms For Marketers. 

##Blade
Through Blade, we're able to use MVC-style razor views and model binding to take full control over Web Forms for Marketers rendered markup. This form of templating gives full control to developers via strongly-typed views and view models.

The following is fully customizable, all without losing the flexibility Web Forms for Marketers provides content editors. It also works with Sitecore's Page Editor.

* Rendering of a Web Forms for Marketers form
* Field sections
* Fields
* Field validators

The following is replaced by this library:

* Web Forms for Marketers Field rendering - Field rendering is completely replaced by the razor views in this library.
* Validation - Given the MVC approach with Razor views, existing Web Forms for Marketers validators will not work.

##Dynamic Model Binding

Since Web Forms for Marketers is completely data-driven, field types must be dynamically driven at runtime. A combination of dynamic model binding and MVC editor templates provide full customization for already supported Web Forms for Marketers fields. Adding completely new fields is supported as well.

##Getting Started

_note: nuget package to be created to replace manual steps below_

1. Install Blade.
2. Add a reference to ```RazorViewsForMarketers``` (or copy dll to bin).
3. Copy ```/App_Config/Include/RazorViewsForMarketers.config``` into includes folder.
4. Update ```global.asax``` for dynamic model binding:

   ```c#
   <%@Application Language='C#' Inherits="Sitecore.Web.Application" %>
   <%@ Import Namespace="RazorViewsForMarketers.ModelBinding" %>
   <%@ Import Namespace="RazorViewsForMarketers.Models.Fields" %>
   <%@ Import Namespace="RazorViewsForMarketers.Providers" %>
   
   <script RunAt="server">
       public void Application_Start()
       {
           // provider overrides
           ModelMetadataProviders.Current = new CustomModelMetadataProvider();
   
           // model binding overrides
           ModelBinders.Binders.Add(typeof(WffmField), new WffmFieldModelBinder());
       }
   </script>
   ```
   
5. Copy ```/Views/*``` to website root.
6. In Sitecore, install package ```/Packages/Razor-Views-For-Marketers-Rendering.zip```.
7. Add a Razor Views for Marketers rendering to the presentation details of an item.
8. Set its datasource to a Web Forms for Marketers form, just as you would with Web Forms for Marketers.
9. Publish.

##How to Contribute

###Creating New Fields

1. Create a Field Model
   
   ```c#
   namespace RazorViewsForMarketers.Models.Fields
   {
       public class SingleLineTextField : WffmField { }
   }
   ```
   
2. Create a Field Initializer
   
   The field initializer's role is to fills the model with content from the Web Forms for Marketers Field item. Overridable methods exist for populating from both ```Parameters``` and ```Localized Parameters``` fields.
   
   For an example implementation, check out the DropListField.
   
   ```c#
   namespace RazorViewsForMarketers.Core.FieldRenderers
   {
       public class SingleLineTextFieldInitializer : FieldInitializerBase<SingleLineTextField>
       {
           public SingleLineTextFieldInitializer(Item fieldItem) : base(fieldItem) { }
   
           public override void PopulateParameters(Field field, SingleLineTextField model)
           {
               // Logic here to parse "Parameters" field of WFFM field item
           }
   
           public override void PopulateLocalizedParameters(Field field, SingleLineTextField model)
           {
               // Logic here to parse "Localized Parameters" field of WFFM field item
           }
       }
   }
   ```
   
3. Create a Validator (if needed)
   ```c#
   namespace RazorViewsForMarketers.Core.Validators
   {
       public class GenericValidator : IValidator
       {
           public GenericValidatorModel Validator { get; set; }
   
           public GenericValidator(GenericValidatorModel model)
           {
               Validator = model;
           }
   
           public bool Validate(string value)
           {
                  bool canValidate = Validator != null &&
							      !string.IsNullOrEmpty(Validator.ValidationExpression);
               if (!canValidate) return true;
   
               var regEx = new Regex(Validator.ValidationExpression);
               return regEx.IsMatch(value);
           }
       }
   }
   ```
   
4. Create the Field View
   
   Take note of the model binding fields. These are required for dynamic model binding to work successfully on postback.
   
   Helper methods exist for generating Page Editor friendly labels and required field indicators.
   
   ```html
   @using System.Web.Mvc.Html
   @using RazorViewsForMarketers.Helpers
   @inherits BladeRazorRenderingEditorTemplate<RazorViewsForMarketers.Models.Fields.SingleLineTextField>
   
   <div class="field">
       <!-- model binding fields -->
       @Html.HiddenFor(model => model.Id)
       @Html.HiddenFor(model => model.IsRequired)
       @Html.Hidden("ModelType", Model.ModelType)
       <!-- model binding fields -->
   
       @BladeHtmlHelper.SitecoreLabel(Html, model => model)
   
       @Html.TextBoxFor(model => model.Response)
       @BladeHtmlHelper.RequiredIndicator(model => model)
   
       <p>@Model.Information</p>
   
       @Html.ValidationMessageFor(model => model.Response)
   </div>
   ```
   
5. Wire it all up in ```/App_Config/Include/RazorViewsForMarketers.config```
   
   ```xml
   <configuration xmlns:patch="http://www.sitecore.net/xmlconfig/">
     <sitecore>
       <rvfm>
         <fields>
		   ...
           <field 
   			   name="Single-Line Text" 
			   type="RazorViewsForMarketers.Core.FieldRenderers.SingleLineTextFieldInitializer" />
		   ...
         </fields>
         <validators>
		   ...
           <validator 
   			   name="Regex Pattern" 
			   type="RazorViewsForMarketers.Core.ValidatorRenderers.GenericValidatorInitializer" 
			   validator="RazorViewsForMarketers.Core.Validators.GenericValidator" />
		   ...
         </validators>
       </rvfm>
     </sitecore>
   </configuration>
   ```
   
   **Field Config Reference**
   
   Attribute | Description
   --- | ---
   name | Field item name as defined within Sitecore
   type | Field model initializer object (created in step 2)
   
   **Validator Config Reference**
   
   Attribute | Description
   --- | ---
   name | Web Forms for Marketers validator item name as defined within Sitecore
   type | Validator model initializer object
   validator | Validator object (created in step 3)
   
   Note: validator type is typically always going to be GenericValidatorInitializer. However, this is fully customizable as well.