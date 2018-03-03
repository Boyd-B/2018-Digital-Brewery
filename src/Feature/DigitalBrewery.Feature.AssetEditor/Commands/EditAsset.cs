using Sitecore.Data.Items;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web.UI.Sheer;
using System.Linq;

namespace DigitalBrewery.Feature.AssetEditor.Commands
{
    public class EditAsset : Command
    {
        public override void Execute(CommandContext context)
        {
            Item item = context.Items[0];
            //Sitecore.Context.ClientPage.Start(this, "Edit", context.Parameters);
        }

        private void Edit(ClientPipelineArgs args)
        {
            if (args != null && args.Parameters != null && !string.IsNullOrEmpty(args.Parameters["id"]))
            {
                SheerResponse.Alert(args.Parameters["id"]);
            }
        }

        private void Editor(Item item)
        {
            
        }
    }
}