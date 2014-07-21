using System.Collections.Generic;
using System.Linq;
using Blade;
using RazorViewsForMarketers.Model;
using RazorViewsForMarketers.Models;
using RazorViewsForMarketers.Models.Fields;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;

namespace RazorViewsForMarketers.Presenters
{
    public class HackThePlanetPresenter : SitecorePresenter<RazordViewForMarketersFormModel>
    {
        protected override RazordViewForMarketersFormModel GetModel(IView view, Item dataSource)
        {
            ID id;
            ID.TryParse(view.DataSource, out id);
            var model = new RazordViewForMarketersFormModel {Form = GetForm(id), Title = Sitecore.Context.Item.Fields["Title"]};
            return model;
        }

        public WffmForm GetForm(ID formId)
        {
            var theForm = new WffmForm();
            var form = Sitecore.Context.Database.Items[formId];
            if (form != null)
            {
                var showFooterField = FieldTypeManager.GetField(form.Fields["Show Footer"]) as Sitecore.Data.Fields.CheckboxField;
                var showIntroductionField = FieldTypeManager.GetField(form.Fields["Show Introduction"]) as Sitecore.Data.Fields.CheckboxField;
                var showTitle = FieldTypeManager.GetField(form.Fields["show Title"]) as Sitecore.Data.Fields.CheckboxField;

                theForm = new WffmForm()
                {
                    Id = formId,
                    Footer = form.Fields["Footer"].Value,
                    Introduction = form.Fields["Introduction"].Value,
                    ShowFooter = showFooterField != null && showFooterField.Checked,
                    ShowIntroduction = showIntroductionField != null && showIntroductionField.Checked,
                    ShowTitle = showTitle != null && showTitle.Checked,
                    Title = form.Fields["Title"].Value,
                    Sections = new List<WffmSection>(),
                };

                var sections = form.Children.Where(child => child.TemplateName == "Form Section");
                var sectionsArray = sections as Item[] ?? sections.ToArray();
                if (!sectionsArray.Any())
                {
                    var theSection = new WffmSection()
                    {
                        Fields = new List<WffmField>()
                    };

                    var fields = GetFields(form);
                    theSection.Fields.AddRange(fields);

                    theForm.Sections.Add(theSection);                    
                }
                else
                {
                    foreach (var section in sectionsArray)
                    {
                        var theSection = new WffmSection()
                        {
                            Title = section.Fields["Title"].Value,
                            Fields = new List<WffmField>()
                        };

                        var fields = GetFields(section);
                        theSection.Fields.AddRange(fields);

                        theForm.Sections.Add(theSection);
                    }                    
                }
            }
            
            return theForm;
        }

        private IEnumerable<WffmField> GetFields(Item parent)
        {
            var results = new List<WffmField>();

            var fields = parent.Children.Where(field => field.TemplateName == "Field");
            foreach (var field in fields)
            {
                var wffmField = WffmFieldFactory.GetField(field);
                if (wffmField == null) continue;

                results.Add(wffmField);
            }

            return results;
        }

        protected override void HandlePostBackWithModelBinding(IView view, RazordViewForMarketersFormModel model)
        {
            var data = GetModel(view);

            for (int i = 0; i < model.Form.Sections.Count; i++)
            {
                if (model.Form.Sections[i].Fields == null) continue;

                for (int j = 0; j < model.Form.Sections[i].Fields.Count; j++)
                {
                    var source = model.Form.Sections[i].Fields[j];
                    var destination = data.Form.Sections[i].Fields[j];

                    source.CssClass = destination.CssClass;
                    source.Help = destination.Help;
                    source.Information = destination.Information;
                    source.IsRequired = destination.IsRequired;
                    source.Item = destination.Item;
                    source.MaximumLength = destination.MaximumLength;
                    source.MinimumLength = destination.MinimumLength;
                    source.PredefinedValidatorPattern = destination.PredefinedValidatorPattern;
                    source.RegExPattern = destination.RegExPattern;
                    source.Text = destination.Text;
                    source.Title = destination.Title;
                    source.Validators = destination.Validators;
                }
            }

            var form = new ModifiedSimpleForm(model);
            model.SubmitMessage = form.SubmitForm();
        }
    }
}