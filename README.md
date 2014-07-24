Razor Views For Marketers
======================

Razor Views for Marketers is a razor view rendering engine for Web Forms For Marketers. 

##Blade
Through [Blade](https://github.com/kamsar/Blade), we're able to use MVC-style razor views and model binding to take full control over Web Forms for Marketers rendered markup. This form of templating gives full control to developers via strongly-typed views and view models.

##Customizable Forms

The following is fully customizable, all without losing the flexibility Web Forms for Marketers provides content editors. It also works with Sitecore's Page Editor.

* Rendering of a Web Forms for Marketers form
* Field sections
* Fields
* Field validators

The following is replaced by this library:

* Web Forms for Marketers Field rendering
  * Field rendering is completely replaced by the razor views in this library.
* Validation
  * Given the MVC approach with Razor views, existing Web Forms for Marketers validators will not work.

##Dynamic Model Binding

Since Web Forms for Marketers is completely data-driven, field types must be dynamically driven at runtime. A combination of dynamic model binding and MVC editor templates provide full customization for already supported Web Forms for Marketers fields. Adding completely new fields is supported as well.

##Getting Started
###Installation
_note: nuget package to be created to replace manual steps below_


###Installing Manually

1. [Install Blade](https://github.com/kamsar/Blade/wiki/Installation).
2. Add a reference to ```RazorViewsForMarketers```.
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

###Adding a Razor Views for Marketers Rendering
1. Add a Razor Views for Marketers rendering to the presentation details of an item.
   ![](https://github.com/PetersonDave/RazorViewsForMarketers/wiki/Images/Presentation-Details.png)
2. Set its Data Source to a Web Forms for Marketers form, just as you would with Web Forms for Marketers.
   ![](https://github.com/PetersonDave/RazorViewsForMarketers/wiki/Images/Form-Datasource.png)
3. Publish.

##How to Contribute

###Creating New Fields

**Step 1:** Create a Field Model
   
   ```c#
   namespace RazorViewsForMarketers.Models.Fields
   {
       public class SingleLineTextField : WffmField { }
   }
   ```
   
**Step 2:** Create a Field Initializer
   
   The field initializer's role is to fill the model with content from the Web Forms for Marketers Field item. Overridable methods exist for populating both ```Parameters``` and ```Localized Parameters``` fields.
   
   For an example implementation, check out the [DropListField](https://github.com/PetersonDave/RazorViewsForMarketers/blob/master/Source/RazorViewsForMarketers/Core/FieldRenderers/DropListInitializer.cs).
   
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
   
**Step 3:** Create a Validator _(if needed)_
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
   
**Step 4:** Create the Field View
   
   Take note of the model binding fields within comments below. These are required for dynamic model binding to work successfully bind on postback.
   
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
   
**Step 5:** Wire it all up in ```/App_Config/Include/RazorViewsForMarketers.config```
   
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
   
   _Note: validator type is typically always going to be GenericValidatorInitializer. However, this is fully customizable as well._
