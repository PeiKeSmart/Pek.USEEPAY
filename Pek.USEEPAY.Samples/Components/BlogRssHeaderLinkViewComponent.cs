using Microsoft.AspNetCore.Mvc;

using Pek.NCubeUI.Components;

using Pek.USEEPAY.Samples.Common;

namespace Pek.USEEPAY.Samples.Components;

public partial class BlogRssHeaderLinkViewComponent : PekViewComponent {
    public IViewComponentResult Invoke()
    {
        if (!PekSettings.Current.ShowHeaderRssUrl)
            return Content("");

        return View();
    }
}
