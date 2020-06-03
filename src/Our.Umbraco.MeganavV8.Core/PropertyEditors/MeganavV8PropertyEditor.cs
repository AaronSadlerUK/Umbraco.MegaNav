using Our.Umbraco.MeganavV8.Core.PropertyEditors;
using Umbraco.Core.Logging;
using Umbraco.Core.PropertyEditors;

namespace Our.Umbraco.MeganavV8.Api.PropertyEditors
{
    [DataEditor(Constants.PropertyEditorAlias, Constants.PackageName, Constants.PackageFilesPath + "views/editor.html", ValueType = "JSON", Group = "pickers", Icon = "icon-sitemap")]
    public class MeganavV8PropertyEditor : DataEditor
    {
        public MeganavV8PropertyEditor(ILogger logger)
            : base(logger, EditorType.PropertyValue)
        {

        }

        protected override IConfigurationEditor CreateConfigurationEditor() => new MeganavConfigurationEditor();

        public class MeganavConfigurationEditor : ConfigurationEditor<MeganavV8Configuration>
        {

        }
    }
}