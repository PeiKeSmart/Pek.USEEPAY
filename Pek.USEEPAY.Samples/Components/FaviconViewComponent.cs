using Microsoft.AspNetCore.Mvc;

using NewLife;

using Pek;
using Pek.NCubeUI.Components;

using Pek.USEEPAY.Samples.Models;

namespace Pek.USEEPAY.Samples.Components;

public partial class FaviconViewComponent : PekViewComponent {
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var model = await Task.FromResult(new FaviconAndAppIconsModel
        {
            HeadCode = DHSetting.Current.FaviconAndAppIconsHeadCode
        });

        if (model.HeadCode.IsNullOrEmpty()) return Content("");

        return View(model);
    }
}
