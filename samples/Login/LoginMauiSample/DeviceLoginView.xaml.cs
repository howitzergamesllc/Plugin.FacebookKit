
using Plugin.FacebookKit.Login;

namespace LoginMauiSample;

/// <summary>
/// (Apple Only) A content view to present the <see cref="IDeviceLoginCodeInfo"/>.
/// </summary>
public partial class DeviceLoginView : ContentView
{
    public DeviceLoginView()
    {
        InitializeComponent();
    }

    public static readonly BindableProperty CodeInfoProperty = BindableProperty.Create(nameof(CodeInfo), typeof(IDeviceLoginCodeInfo), typeof(DeviceLoginView), null, BindingMode.OneWay, propertyChanged: DeviceLoginCodeInfoChanged);
    public static readonly BindableProperty DismissProperty = BindableProperty.Create(nameof(Dismiss), typeof(Action), typeof(DeviceLoginView), null, BindingMode.OneWay);


    public IDeviceLoginCodeInfo CodeInfo
    {
        get => (IDeviceLoginCodeInfo)GetValue(CodeInfoProperty);
        set => SetValue(CodeInfoProperty, value);
    }
    
    public Action Dismiss
    {
        get => (Action)GetValue(DismissProperty);
        set => SetValue(DismissProperty, value);
    }

    public static void DeviceLoginCodeInfoChanged(BindableObject control, object? oldValue, object? newValue)
    {
        if(newValue is null)
            return;

        ((DeviceLoginView)control).signInUrl.Text = "Go To: " + ((IDeviceLoginCodeInfo)newValue).VerificationUrl?.ToString();
        ((DeviceLoginView)control).code.Text = "Enter Code: " + ((IDeviceLoginCodeInfo)newValue).LoginCode;
    }

    public void CancelDeviceLogin(object? sender, EventArgs e) => Dismiss();
}