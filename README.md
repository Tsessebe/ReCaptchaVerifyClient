# ReCaptchaVerifyClient

ReCaptcha Verify Client is a http client to do server side verification of a recaptha token.

Target platform: .NET Standard 2.1

## Interface

```c#
Task<Result> VerifyAsync(string recaptchaToken);
void UpdateSecretKey(string key);
```


## Setup guide
Install the package https://www.nuget.org/packages/ReCaptchaVerifyClient/ using nuget

Update your middleware
```c#
builder.Services.AddReCaptchaClient(options =>
{
    options.SiteKey = "YOUR_SITE_KEY";
    options.SecretKey = "YOUR_SECRET_KEY";
});
```

Inject where needed
```c#
private readonly IReCaptchaClient client;
public HomeController(IReCaptchaClient client)
{
    this.client = client;
}
```

## Gotcha's

* None

## Versions

* 20 Dec 2022 - v1.0.0 Initial Release
* 20 Jun 2022 - v1.0.0-preview1 Initial Preview Release

