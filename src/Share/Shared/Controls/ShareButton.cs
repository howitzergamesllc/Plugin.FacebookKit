
namespace Plugin.FacebookKit.Share.Controls;

/// <summary>
/// A shared virtual instance of the native platform facebook share button.
/// </summary>
public class ShareButton : ContentView
{
    /// <summary>
    /// Raised when the button is pressed.
    /// </summary>
    public event EventHandler? Pressed;
    /// <summary>
    /// Raised when the button is released.
    /// </summary>
    public event EventHandler? Released;
    /// <summary>
    /// Raised when the button is clicked.
    /// </summary>
    public event EventHandler? Clicked;

    /// <summary>
    /// The share dialog managing the <see cref="ISharingDelegate"/> for <see cref="ISharingContent"/> when the button is clicked/>.
    /// </summary>
    public static readonly BindableProperty ShareDialogProperty =
        BindableProperty.Create(nameof(ShareDialog), typeof(IShareDialog), typeof(ShareButton), null, BindingMode.OneWay, null);

    /// <summary>
    /// The dialog to share when the button is clicked.
    /// </summary>
    public IShareDialog ShareDialog
    {
        get { return (IShareDialog)GetValue(ShareDialogProperty); }
        set { SetValue(ShareDialogProperty, value); }
    }
    
    /// <summary>
    /// The content (Photo, URL, Media, Video) to share when the button is clicked.
    /// </summary>
    public static readonly BindableProperty ShareContentProperty =
        BindableProperty.Create(nameof(ShareContent), typeof(ISharingContent), typeof(ShareButton), null, BindingMode.OneWay, null);

    /// <summary>
    /// The content (Photo, URL, Media, Video) to share when the button is clicked.
    /// </summary>
    public ISharingContent? ShareContent
    {
        get => (ISharingContent?)GetValue(ShareContentProperty);
        set => SetValue(ShareContentProperty, value);
    }

    internal void RaisePressedEvent(object? sender, EventArgs e) => Pressed?.Invoke(sender, e);
    internal void RaiseReleasedEvent(object? sender, EventArgs e) => Released?.Invoke(sender, e);
    internal void RaiseClickedEvent(object? sender, EventArgs e) => Clicked?.Invoke(sender, e);
}
