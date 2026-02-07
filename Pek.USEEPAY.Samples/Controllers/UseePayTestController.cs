using Microsoft.AspNetCore.Mvc;

using Pek.NCube.BaseControllers;
using Pek.UseePay;

namespace PekMvc.Controllers;

/// <summary>UseePay 支付测试</summary>
public class UseePayTestController : PekBaseControllerX
{
    /// <summary>测试页面</summary>
    /// <returns></returns>
    public ActionResult Index()
    {
        ViewBag.Message = "UseePay 支付测试";

        // 获取配置
        var setting = UseePaySetting.Current;

        ViewBag.Setting = setting;
        ViewBag.IsEnable = setting.Enable;
        ViewBag.UseSandbox = setting.UseSandbox;
        ViewBag.ApiUrl = setting.GetApiUrl();
        ViewBag.MerchantId = setting.GetMerchantId();
        ViewBag.AppId = setting.GetAppId();
        ViewBag.SignType = setting.GetSignType();

        return View();
    }

    /// <summary>创建支付订单测试</summary>
    /// <returns></returns>
    public ActionResult CreateOrder()
    {
        var setting = UseePaySetting.Current;

        if (!setting.Enable)
        {
            return Json(new { success = false, message = "UseePay 未启用" });
        }

        // TODO: 这里添加创建支付订单的逻辑
        // 示例：调用 UseePay API 创建订单

        return Json(new
        {
            success = true,
            message = "订单创建成功（示例）",
            data = new
            {
                apiUrl = setting.GetApiUrl(),
                merchantId = setting.GetMerchantId(),
                appId = setting.GetAppId(),
                signType = setting.GetSignType()
            }
        });
    }

    /// <summary>支付回调测试</summary>
    /// <returns></returns>
    [HttpPost]
    public ActionResult Notify()
    {
        // TODO: 这里添加支付回调处理逻辑
        // 验证签名、处理订单状态等

        return Content("success");
    }

    /// <summary>支付返回测试</summary>
    /// <returns></returns>
    public ActionResult Return()
    {
        ViewBag.Message = "支付完成";

        // TODO: 这里添加支付返回处理逻辑

        return View();
    }
}
