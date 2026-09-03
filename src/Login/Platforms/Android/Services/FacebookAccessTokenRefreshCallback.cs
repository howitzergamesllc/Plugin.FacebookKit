
namespace Plugin.FacebookKit.Login;

internal class FacebookAccessTokenRefreshedCallback : Java.Lang.Object, Facebook.AccessToken.IAccessTokenRefreshCallback
{
    private Action tokenRefreshedAction;
    internal FacebookAccessTokenRefreshedCallback(Action action)
    {
        tokenRefreshedAction = action;
    }

    public void OnTokenRefreshed(Facebook.AccessToken accessToken)
    {            
        if(accessToken is null)
        {
            Console.WriteLine("Plugin.FacebookKit.Login.FacebookRefreshCurrentAccessToken GraphRequest Result Null.");
            return;
        }

        if(tokenRefreshedAction is not null)
            tokenRefreshedAction();
    }

    public void OnTokenRefreshFailed(Facebook.FacebookException e)
    {
        string inner = "";
        if(e.InnerException is not null)
        {
            inner = $", InnerExceptionMessage={e.InnerException.Message}, InnerExceptionStackTrace={e.InnerException.StackTrace}";
        }
        Console.WriteLine($"Plugin.FacebookKit.Login.FacebookRefreshCurrentAccessToken GraphRequest Error: Message={e.Message}, StackTrace={e.StackTrace}" + inner);
    }
}