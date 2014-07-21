using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using RazorViewsForMarketers.Model;
using Sitecore.Data;
using Sitecore.Form.Core;
using Sitecore.Form.Core.Ascx.Controls;
using Sitecore.Form.Core.Configuration;
using Sitecore.Form.Core.ContentEditor.Data;
using Sitecore.Form.Core.Controls.Data;
using Sitecore.Form.Core.Data;
using Sitecore.Form.Core.Pipelines.FormSubmit;
using Sitecore.Forms.Core.Data;
using Sitecore.Pipelines;

namespace RazorViewsForMarketers.Models
{
    public class ModifiedSimpleForm : SimpleForm
    {
        private readonly ID _formId;
        public override ID FormID
        {
            get { return _formId; }
        }
        
        public FormItem FormItem
        {
            get { return formItem; }
            set { formItem = value; }
        }

        public List<DecoratedControlResult> Results { get; set; }

        public ModifiedSimpleForm(RazordViewForMarketersFormModel model)
        {
            _formId = model.Form.Id;
            FormItem = StaticSettings.ContextDatabase.GetItem(_formId);

            var results = new List<DecoratedControlResult>();

            foreach (var section in model.Form.Sections)
            {
                if (section.Fields == null) continue;

                foreach (var field in section.Fields)
                {
                    var result = new DecoratedControlResult(field.Item.ID, field.Item.Name, field.Response, string.Empty);
                    results.Add(result);
                }
            }

            Results = results;
        }

        public ControlResult[] GetControlResults()
        {
            bool hasResults = Results != null && Results.Any();
            return !hasResults ? null : Results.ToList().Select(r => r.ControlResult).ToArray();
        }

        public ActionDefinition[] GetActionDefinitions()
        {
            var list = new List<ActionDefinition>();
            CollectActions(this, list);
            return list.ToArray();
        }

        protected override void CollectActions(Control source, List<ActionDefinition> list)
        {
            ListDefinition actionsDefinition = this.FormItem.ActionsDefinition;
            if (actionsDefinition.Groups.Count <= 0 || actionsDefinition.Groups[0].ListItems.Count <= 0)
                return;
            foreach (GroupDefinition groupDefinition in actionsDefinition.Groups)
            {
                foreach (ListItemDefinition listItemDefinition in groupDefinition.ListItems)
                    list.Add(new ActionDefinition(listItemDefinition.ItemID, listItemDefinition.Parameters)
                    {
                        UniqueKey = listItemDefinition.Unicid
                    });
            }
        }

        public string SubmitForm()
        {
            FormDataHandler.ProcessData(this, GetControlResults(), GetActionDefinitions());

            var submitSuccessArgs = new SubmitSuccessArgs(FormItem);
            CorePipeline.Run("successAction", submitSuccessArgs);
            return submitSuccessArgs.Result;
        }
    }
}