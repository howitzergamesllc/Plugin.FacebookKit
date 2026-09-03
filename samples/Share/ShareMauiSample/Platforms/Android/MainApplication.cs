using Android.App;
using Android.Runtime;
using Facebook;

namespace ShareMauiSample;

[Application]
public class MainApplication : MauiApplication
{
	public MainApplication(IntPtr handle, JniHandleOwnership ownership)
		: base(handle, ownership)
	{
	}
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}