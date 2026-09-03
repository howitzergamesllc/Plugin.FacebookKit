
using Plugin.FacebookKit.Login.Controls;
using Plugin.FacebookKit.Login.Platforms.Android.Extensions;

namespace Plugin.FacebookKit.Login;

internal sealed class LoginCallback : Java.Lang.Object, Facebook.IFacebookCallback
{
    private readonly LoginButton? loginButton;
    private readonly TaskCompletionSource<ILoginResult>? loginTask;
    private readonly DeviceLoginManager? deviceLoginManager;

    internal LoginCallback(LoginButton loginButton)
    {
        this.loginButton = loginButton;
    }

    internal LoginCallback(TaskCompletionSource<ILoginResult> loginTask)
    {
        this.loginTask = loginTask;
    }    
    internal LoginCallback(DeviceLoginManager deviceLoginManager)
    {
        this.deviceLoginManager = deviceLoginManager;
    }

    public void OnSuccess(Java.Lang.Object genericResult)
    {
        if(genericResult is not Facebook.Login.LoginResult nativeResult)
            return;
        
        var result = nativeResult.ToLoginResult();

        loginButton?.RaiseLoginCompleted(null, new LoggedInEventArgs(result));
        loginTask?.TrySetResult(result);
        deviceLoginManager?.OnLoginCompleted(null, new LoggedInEventArgs(result));
    }

    public void OnError(Facebook.FacebookException nativeException)
    {
        var exception = new LoginException(nativeException?.Message ?? "", nativeException);
        
        loginButton?.RaiseLoginCompleted(null, new LoggedInEventArgs(null, exception));
        loginTask?.TrySetException(exception);
        deviceLoginManager?.OnLoginCompleted(null, new LoggedInEventArgs(null, exception));
    }

    public void OnCancel()
    {
        loginButton?.RaiseLoginCompleted(null, new LoggedInEventArgs(exception: null));
        loginTask?.TrySetCanceled();
        deviceLoginManager?.OnLoginCompleted(null, new LoggedInEventArgs(exception: null));
    }
}