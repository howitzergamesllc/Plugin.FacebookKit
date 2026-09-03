using System.Diagnostics;
using Plugin.FacebookKit.Login;
using Permissions = Plugin.FacebookKit.Login.Permissions;

namespace LoginMauiSample;

public partial class MainPage : ContentPage
{
	private readonly ILoginManager? loginManager;
	private IDeviceLoginManager? DeviceLoginManager { get; set; }
	private DeviceLoginView? deviceLoginView;

	public MainPage()
	{
		InitializeComponent();
        BindingContext = this;

		InitializeIfSignedIn();

		LogInBtn.Pressed += HandlePress;
		LogInBtn.Released += HandleRelease;
		LogInBtn.Clicked += HandleClicked;
		LogInBtn.LoginCompleted += OnLoginCompleted;
		LogInBtn.LogOutCompleted += OnLogoutCompleted;

		ManualLoginBtn.Pressed += HandlePress;
		ManualLoginBtn.Released += HandleRelease;
		ManualLoginBtn.Clicked += HandleClicked;

		FacebookPluginLogin.Current?.AccessTokenChanged += OnAccessTokenChanged;
		FacebookPluginLogin.Current?.ProfileChanged += OnProfileChanged;

		loginManager ??= FacebookPluginLogin.Current?.CreateLoginManager();
		
		ManualDeviceLoginBtn.Pressed += HandlePress;
		ManualDeviceLoginBtn.Released += HandleRelease;
		ManualDeviceLoginBtn.Clicked += HandleClicked;
		
		LogoutBtn.Pressed += HandlePress;
		LogoutBtn.Released += HandleRelease;
		LogoutBtn.Clicked += HandleClicked;
		
		//var settings = CrossFacebook.SharedSettings;
		//Console.WriteLine($"SDKVersion: {settings.SdkVersion}, App ID: {settings.AppID}, App URL Scheme Suffix: {settings.AppURLSchemeSuffix}, Client Token: {settings.ClientToken}, Display Name: {settings.DisplayName}");
		//Debug.WriteLine($"SDKVersion: {settings.SdkVersion}, App ID: {settings.AppID}, App URL Scheme Suffix: {settings.AppURLSchemeSuffix}, Client Token: {settings.ClientToken}, Display Name: {settings.DisplayName}");
	}

	private void InitializeIfSignedIn()
	{
		var currentToken = FacebookPluginLogin.CurrentToken;
		Console.WriteLine($"CurrentAccessToken CurrentToken={currentToken?.DebugDescription()}");
		Debug.WriteLine($"CurrentAccessToken CurrentToken={currentToken?.DebugDescription()}");
		if(currentToken is not null)
		{
			OnProfileChanged(this, new ProfileChangedEventArgs(FacebookPluginLogin.CurrentProfile));
		}
	}

	private void OnAccessTokenChanged(object? ender, AccessTokenChangedEventArgs e)
	{
		if(e.CurrentToken is null)
		{
			Console.WriteLine("AccessTokenChanged Token is Null");
			Debug.WriteLine("AccessTokenChanged Token is Null");
			return;
		}

		Console.WriteLine($"AccessTokenChanged {e.CurrentToken.DebugDescription()}");
		Debug.WriteLine($"AccessTokenChanged {e.CurrentToken.DebugDescription()}");
	}

	private void OnProfileChanged(object? ender, ProfileChangedEventArgs e)
	{
		//Because ios is forced to limited login, graphapi calls fail so ProfilePicureView cannot be used here.
		//Just load the image instead on ios.
		var profilenull = e.CurrentProfile is null;
		profilePicture.Profile = e.CurrentProfile;
#if MACCATALYST || ANDROID
		profilePicture.IsVisible = !profilenull;
		mainimage.IsVisible = profilenull;
#elif IOS
		if (profilenull || string.IsNullOrEmpty(FacebookPluginLogin.CurrentProfile?.ImageURL?.ToString()))
		{
			mainimage.Source = ImageSource.FromFile("dotnet_bot.png");
		}
		else
		{
			var uri = FacebookPluginLogin.CurrentProfile.ImageURL.AbsoluteUri;
			mainimage.Source = ImageSource.FromUri(new Uri(uri));
		}
#endif

		if(e.CurrentProfile is null)
		{
			Console.WriteLine("ProfileChanged Profile is Null");
			Debug.WriteLine("ProfileChanged Profile is Null");
			return;
		}

		Console.WriteLine($"ProfileChanged {e.CurrentProfile.DebugDescription()}");
		Debug.WriteLine($"ProfileChanged {e.CurrentProfile.DebugDescription()}");
	}

	private void HandlePress(object? sender, EventArgs e)
	{
		Console.WriteLine($"{sender?.GetType().ToString()} Pressed");
		Debug.WriteLine($"{sender?.GetType().ToString()} Pressed");
	}
	private void HandleRelease(object? sender, EventArgs e)
	{
		Console.WriteLine($"{sender?.GetType().ToString()} Released");
		Debug.WriteLine($"{sender?.GetType().ToString()} Released");
	}
	private void HandleClicked(object? sender, EventArgs e)
	{
		Console.WriteLine($"{sender?.GetType().ToString()} Clicked");
		Debug.WriteLine($"{sender?.GetType().ToString()} Clicked");
	}

	private async void OnLoginCompleted(object? sender, LoggedInEventArgs e)
	{
		var result = e.Result;
		var token = e.Result?.Token;
		if(token is not null)
		{
			Console.WriteLine($"Logged In to Facebook Token: {token.DebugDescription()}");
			Debug.WriteLine($"Logged In to Facebook Token: {token.DebugDescription()}");
			
			if(FacebookPluginLogin.Current is not IFacebookPluginLogin plugin)
				return;

			var profile = await plugin.LoadCurrentProfileAsync();
			Console.WriteLine(profile?.DebugDescription());
			Debug.WriteLine(profile?.DebugDescription());
		}
		else
		{
			Console.WriteLine($"Facebook Access Token is null. If you are using iOS and are limited in login you may have to manage the token yourself " +
				"Also, you may have requested a improper permission. Now printing declined permissions.");
			Debug.WriteLine($"Facebook Access Token is null. If you are using iOS and are limited in login you may have to manage the token yourself " +
				"Also, you may have requested a improper permission. Now printing declined permissions.");
			Console.WriteLine($"LoginResult={e.Result?.DebugDescription()}");
			Debug.WriteLine($"LoginResult={e.Result?.DebugDescription()}");
		}
	}

	private void OnLogoutCompleted(object? sender, LoggedOutEventArgs e)
	{
		Console.WriteLine($"Logged Out Of Facebook");
		Debug.WriteLine($"Logged Out Of Facebook");
	}

	private void CheckLoggedIn(object? sender, EventArgs e)
	{
		var token = FacebookPluginLogin.CurrentToken;
		if(token is null)
		{
			Console.WriteLine($"Facebook Access Token is null. If you are using limited login you may have to manage the token yourself " +
				"Also, you may have requested a improper permission.");
			Debug.WriteLine($"Facebook Access Token is null. If you are using limited login you may have to manage the token yourself " +
				"Also, you may have requested a improper permission.");
			return;
		}
		Console.WriteLine($"Logged In to Facebook Token={token.DebugDescription()}");
		Debug.WriteLine($"Logged In to Facebook Token={token.DebugDescription()}");
	}
	
	private async void Login(object? sender, EventArgs args)
	{
		if(loginManager is null)
			return;

		try
		{
			await loginManager.LoginAsync(new LoginConfiguration());
		}
		catch(Exception e)
		{
			string inner = "";
			if(e.InnerException is not null)
				inner = $"InnerMessage={e.InnerException.Message}, InnerStackTrace={e.InnerException.StackTrace}";
			Console.WriteLine($"LoginMauiSample.MainPage.Login Exception Message={e.Message}, StackTrace={e.StackTrace}, " + inner);
			Debug.WriteLine($"LoginMauiSample.MainPage.Login Exception Message={e.Message}, StackTrace={e.StackTrace}, " + inner);
		}
	}
	
	private void Logout(object? sender, EventArgs e) 
	{
		loginManager?.Logout();
	}

	private void DeviceLogin(object? sender, EventArgs e)
	{
		//Because ios is forced to limited login, DeviceLogin fails on ios.
		if(DeviceLoginManager is null)
		{
			DeviceLoginManager ??= FacebookPluginLogin.Current?.CreateDeviceLoginManager([Permissions.PublicProfile]);
			DeviceLoginManager?.Started += OnDeviceLoginStarted;
			DeviceLoginManager?.Completed += OnDeviceLoginCompleted;
		}
		DeviceLoginManager?.Start();
	}

	private void CancelDeviceLogin()
	{
		Console.WriteLine($"DeviceLoginCancelling");
		Debug.WriteLine($"DeviceLoginCancelling");
		if(deviceLoginView is not null)
		{
			layout.Remove(deviceLoginView);
			deviceLoginView = null;
		}
		if(DeviceLoginManager is not null)
		{
			DeviceLoginManager.Cancel();
			DeviceLoginManager.Started -= OnDeviceLoginStarted;
			DeviceLoginManager.Completed -= OnDeviceLoginCompleted;
			DeviceLoginManager = null;
		}
	}

	private void OnDeviceLoginStarted(object? manager, DeviceLoginStartedEventArgs e)
	{
		if(e.CodeInfo is not null)
		{
			Console.WriteLine($"Device Login started: CodeInfo={e.CodeInfo.DebugDescription()}");
			Debug.WriteLine($"Device Login started: CodeInfo={e.CodeInfo.DebugDescription()}");
			if(deviceLoginView is null)
			{
				deviceLoginView = new DeviceLoginView(){ CodeInfo = e.CodeInfo, Dismiss = CancelDeviceLogin };
				layout.Add(deviceLoginView);
			}
		}
	}

	private void OnDeviceLoginCompleted(object? manager, LoggedInEventArgs e)
	{
		if(deviceLoginView is not null)
		{
			layout.Remove(deviceLoginView);
			DeviceLoginManager?.Started -= OnDeviceLoginStarted;
			DeviceLoginManager?.Completed -= OnDeviceLoginCompleted;
			deviceLoginView = null;
		}
		if(e.Exception is not null)
		{
			Console.WriteLine($"Device Login Failed Error: {e.Exception.DebugDescription()}");
			Debug.WriteLine($"Device Login Failed Error: {e.Exception.DebugDescription()}");
			return;
		}
		if(e.Result is null)
		{
			Console.WriteLine($"LoginResult and LoginException are null)");
			Debug.WriteLine($"LoginResult and LoginException are null)");
			return;
		}
		if(e.Result.AppleExtras is not null && e.Result.AppleExtras.IsCancelled)
		{
			Console.WriteLine($"Loging Cancelled.");
			Debug.WriteLine($"Loging Cancelled.");
		}

		if(e.Result.Token is not null)
		{
			Console.WriteLine($"Device Logged In to Facebook Results: {e.Result.DebugDescription()}");
			Debug.WriteLine($"Device Logged In to Facebook Results: {e.Result.DebugDescription()}");
		}
		if(e.Result.Token is null)
		{
			Console.WriteLine($"Facebook Access Token is null. If you are using limited login you may have to manage the token yourself " +
				"Also, you may have requested a improper permission.");
			Debug.WriteLine($"Facebook Access Token is null. If you are using limited login you may have to manage the token yourself " +
				"Also, you may have requested a improper permission.");
			if(e.Result.AppleExtras is not null && e.Result.AppleExtras.IsCancelled)
			{
				Console.WriteLine($"Device Signin Cancelled)");
				Debug.WriteLine($"Device Signin Cancelled)");
			}
		}
	}

	private void TestProfilePicView(object? sender, EventArgs e)
	{
		Console.WriteLine($"Static Profile={FacebookPluginLogin.CurrentProfile?.DebugDescription()}");
		profilePicture.Profile = FacebookPluginLogin.CurrentProfile;
	}
}