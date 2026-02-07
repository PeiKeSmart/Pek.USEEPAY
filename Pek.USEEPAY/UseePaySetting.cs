using System.ComponentModel;

using NewLife.Configuration;

namespace Pek.UseePay;

/// <summary>UseePay支付设置</summary>
[DisplayName("UseePay支付设置")]
[Config("UseePay")]
public class UseePaySetting : Config<UseePaySetting>
{
    #region 属性
    /// <summary>是否启用</summary>
    [Description("是否启用")]
    public Boolean Enable { get; set; }

    /// <summary>是否使用沙箱环境。默认 false</summary>
    [Description("是否使用沙箱环境")]
    public Boolean UseSandbox { get; set; }

    /// <summary>沙箱环境 API 网关地址</summary>
    [Description("沙箱环境 API 网关地址")]
    public String SandboxApiUrl { get; set; } = "https://pay-gateway1.uat.useepay.com/";

    /// <summary>沙箱环境商户系统地址</summary>
    [Description("沙箱环境商户系统地址")]
    public String SandboxMerchantUrl { get; set; } = "https://mc1.uat.useepay.com/";

    /// <summary>沙箱环境商户号</summary>
    [Description("沙箱环境商户号")]
    public String? SandboxMerchantId { get; set; }

    /// <summary>沙箱环境密钥（MD5 或 RSA 私钥）</summary>
    [Description("沙箱环境密钥")]
    public String? SandboxKey { get; set; }

    /// <summary>沙箱环境网站 AppId（域名，不带 http:// 或 https://）</summary>
    [Description("沙箱环境 AppId")]
    public String? SandboxAppId { get; set; }

    /// <summary>沙箱环境签名类型。MD5 或 RSA，默认 MD5</summary>
    [Description("沙箱环境签名类型")]
    public String SandboxSignType { get; set; } = "MD5";

    /// <summary>生产环境 API 网关地址（需要 IP 白名单）</summary>
    [Description("生产环境 API 网关地址")]
    public String ProdApiUrl { get; set; } = "https://pay-gateway.useepay.com/";

    /// <summary>生产环境商户号</summary>
    [Description("生产环境商户号")]
    public String? ProdMerchantId { get; set; }

    /// <summary>生产环境密钥（MD5 或 RSA 私钥）</summary>
    [Description("生产环境密钥")]
    public String? ProdKey { get; set; }

    /// <summary>生产环境网站 AppId（域名，不带 http:// 或 https://）</summary>
    [Description("生产环境 AppId")]
    public String? ProdAppId { get; set; }

    /// <summary>生产环境签名类型。MD5 或 RSA，默认 MD5</summary>
    [Description("生产环境签名类型")]
    public String ProdSignType { get; set; } = "MD5";

    /// <summary>支付结果通知地址</summary>
    [Description("支付结果通知地址")]
    public String? NotifyUrl { get; set; }

    /// <summary>支付完成返回地址</summary>
    [Description("支付完成返回地址")]
    public String? ReturnUrl { get; set; }
    #endregion

    #region 方法
    /// <summary>获取当前使用的 API 网关地址</summary>
    /// <returns>根据环境返回对应的 API 地址</returns>
    public String GetApiUrl() => UseSandbox ? SandboxApiUrl : ProdApiUrl;

    /// <summary>获取当前使用的商户号</summary>
    /// <returns>根据环境返回对应的商户号</returns>
    public String? GetMerchantId() => UseSandbox ? SandboxMerchantId : ProdMerchantId;

    /// <summary>获取当前使用的密钥</summary>
    /// <returns>根据环境返回对应的密钥</returns>
    public String? GetKey() => UseSandbox ? SandboxKey : ProdKey;

    /// <summary>获取当前使用的 AppId</summary>
    /// <returns>根据环境返回对应的 AppId</returns>
    public String? GetAppId() => UseSandbox ? SandboxAppId : ProdAppId;

    /// <summary>获取当前使用的签名类型</summary>
    /// <returns>根据环境返回对应的签名类型</returns>
    public String GetSignType() => UseSandbox ? SandboxSignType : ProdSignType;
    #endregion
}
