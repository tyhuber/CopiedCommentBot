namespace RedditSharp.Misc
{
    public interface ICaptchaSolver
    {
        CaptchaResponse HandleCaptcha(Captcha captcha);
    }
}
