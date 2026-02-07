# UseePay 示例项目使用说明

## 项目说明

这是从 [Pek.Zero](https://github.com/PeiKeSmart/Pek.Zero) 仓库的 MVC 项目改造的 UseePay 本地示例项目，用于调试和测试 UseePay 支付组件。

## 项目结构

```
Pek.USEEPAY.Samples/
├── Controllers/
│   ├── CubeHomeController.cs          # 原首页控制器
│   └── UseePayTestController.cs       # UseePay 测试控制器（新增）
├── Views/
│   ├── CubeHome/
│   └── UseePayTest/                   # UseePay 测试视图（新增）
│       ├── Index.cshtml              # 测试主页面
│       └── Return.cshtml             # 支付返回页面
├── Entity/                            # 实体层
├── Common/                            # 公共类
├── Pek.USEEPAY.Samples.csproj        # 项目文件（已添加 Pek.USEEPAY 引用）
└── Program.cs                        # 程序入口
```

## 快速开始

### 1. 运行项目

```bash
cd Pek.USEEPAY.Samples
dotnet run
```

或使用 Visual Studio / VS Code 直接运行。

### 2. 访问测试页面

浏览器访问：`http://localhost:5000/UseePayTest/Index`

（端口号可能不同，请查看启动日志）

### 3. 配置 UseePay

首次运行时，会在应用程序根目录自动生成 `UseePay.config` 配置文件，修改其中的参数：

```xml
<?xml version="1.0" encoding="utf-8"?>
<UseePay>
  <Enable>true</Enable>
  <UseSandbox>true</UseSandbox>
  
  <!-- Sandbox 沙箱环境配置 -->
  <SandboxMerchantId>your_sandbox_merchant_id</SandboxMerchantId>
  <SandboxKey>your_sandbox_key</SandboxKey>
  <SandboxAppId>www.example.com</SandboxAppId>
  <SandboxSignType>MD5</SandboxSignType>
  
  <!-- Prod 生产环境配置 -->
  <ProdMerchantId>your_prod_merchant_id</ProdMerchantId>
  <ProdKey>your_prod_key</ProdKey>
  <ProdAppId>www.example.com</ProdAppId>
  <ProdSignType>MD5</ProdSignType>
  
  <!-- 通用配置 -->
  <NotifyUrl>http://localhost:5000/UseePayTest/Notify</NotifyUrl>
  <ReturnUrl>http://localhost:5000/UseePayTest/Return</ReturnUrl>
</UseePay>
```

## 测试功能

### 配置信息查看

访问 `/UseePayTest/Index` 查看当前 UseePay 配置信息：

- 是否启用
- 当前环境（Sandbox/Prod）
- API 网关地址
- 商户号
- AppId
- 签名类型

### 创建支付订单测试

点击"创建支付订单"按钮，测试配置是否正确加载。

### 支付回调测试

- **异步回调**：`POST /UseePayTest/Notify`
- **同步返回**：`GET /UseePayTest/Return`

## 开发调试

### 添加支付功能

在 `UseePayTestController.cs` 中添加具体的支付逻辑：

```csharp
public ActionResult CreateOrder()
{
    var setting = UseePaySetting.Current;
    
    // 1. 构建支付请求参数
    var paymentData = new 
    {
        merchantId = setting.GetMerchantId(),
        amount = 100.00M,
        orderId = Guid.NewGuid().ToString(),
        // ... 其他参数
    };
    
    // 2. 生成签名
    // var sign = GenerateSign(paymentData, setting.GetKey());
    
    // 3. 调用 UseePay API
    // var result = await CallUseePayApi(paymentData);
    
    return Json(result);
}
```

### 验证签名示例

```csharp
[HttpPost]
public ActionResult Notify()
{
    var setting = UseePaySetting.Current;
    
    // 1. 获取回调参数
    var form = Request.Form;
    
    // 2. 验证签名
    // var isValid = VerifySign(form, setting.GetKey());
    
    // 3. 处理订单状态
    if (isValid)
    {
        // 更新订单状态
        return Content("success");
    }
    
    return Content("fail");
}
```

## 注意事项

1. **环境切换**：开发测试使用 Sandbox 环境，生产环境需切换 `UseSandbox` 为 `false`
2. **配置安全**：不要将包含真实密钥的配置文件提交到代码仓库
3. **回调地址**：确保 NotifyUrl 和 ReturnUrl 配置正确且可访问
4. **签名验证**：所有回调都必须进行签名验证，确保数据安全性

## 相关链接

- [UseePay API 文档](https://openapi-useepay.apifox.cn/)
- [Pek.USEEPAY 配置说明](../Doc/配置说明.md)
- [Pek.Zero 项目](https://github.com/PeiKeSmart/Pek.Zero)
- [Sandbox 商户系统](https://mc1.uat.useepay.com/)

## 问题排查

### 配置文件未生成

首次访问 `UseePaySetting.Current` 时会自动生成配置文件。确保应用程序对根目录有写入权限。

### API 调用失败

1. 检查网络连接
2. 验证商户号、密钥配置是否正确
3. 确认 API 网关地址是否正确
4. 查看错误日志

### 签名验证失败

1. 确认签名类型（MD5/RSA）配置正确
2. 检查密钥是否正确
3. 验证参数顺序和编码方式

## 技术支持

如有问题，请访问：

- [GitHub Issues](https://github.com/PeiKeSmart/Pek.USEEPAY/issues)
- [PeiKeSmart 组织](https://github.com/PeiKeSmart)
