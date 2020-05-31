using Umbraco.Core.Logging;
using Umbraco.Core.PropertyEditors;

namespace Our.Umbraco.Meganav.PropertyEditors
{
    [DataEditor(Constants.PropertyEditorAlias, Constants.PackageName, Constants.PackageFilesPath + "views/editor.html", ValueType = "JSON", Group = "pickers", Icon = "icon-sitemap")]
    public class MeganavPropertyEditor : DataEditor
    {
        public MeganavPropertyEditor(ILogger logger)
            : base(logger, EditorType.PropertyValue)
        {

        }

        protected override IConfigurationEditor CreateConfigurationEditor() => new MeganavConfigurationEditor();

        public class MeganavConfigurationEditor : ConfigurationEditor<MeganavConfiguration>
        {

        }
    }
}