using Sitecore.Data.Items;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web.UI.Sheer;

namespace DigitalBrewery.Feature.AssetEditor.Commands
{
    public class EditAsset : Command
    {
        public override void Execute(CommandContext context)
        {
            if (context == null || context.Items.Length != 1)
                return;

            Item item = context.Items[0];

            if (item == null)
            {
                SheerResponse.Alert("No item found.");
                return;
            }

            LaunchEditor(item);
        }

        protected void LaunchEditor(MediaItem mediaItem)
        {
            if (mediaItem == null)
            {
                SheerResponse.Alert("Unable to launch editor, Media item cannot be null");
                return;
            }

            Sitecore.Text.UrlString url = new Sitecore.Text.UrlString("/sitecore/client/Your Apps/AssetEditorPage");
            url.Append("id", mediaItem.ID.ToGuid().ToString());

            SheerResponse.ShowModalDialog(new ModalDialogOptions(url.ToString())
            {
                Width = "1000",
                Height = "1000",
                Response = true,
                ForceDialogSize = true
            });
        }
    }
}