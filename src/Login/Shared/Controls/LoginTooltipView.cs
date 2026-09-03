
namespace Plugin.FacebookKit.Login.Controls;

/// Designated initializer.
/// If you need to show a tooltip for login, consider using the TooltipView.
public class LoginTooltipView : ContentView
{
    /// <summary>
    /// (Apple Only) Tooltipview will appear.
    /// </summary>
    public event EventHandler? Appearing;
    /// <summary>
    /// (Apple Only) Tooltipview will not appear.
    /// </summary>
    public event EventHandler? NotAppearing;

    /// <summary>
    /// Identifies the <see cref="DisplayDuration"/> bindable property.
    /// </summary>
    public static readonly BindableProperty DisplayDurationProperty = BindableProperty.Create(nameof(DisplayDuration), typeof(TimeSpan), typeof(LoginTooltipView), TimeSpan.FromSeconds(6L));

    /// <summary>
    /// Gets or sets the amount of time in seconds the tooltip should be displayed.
    /// </summary>
    /// <remarks>
    /// Set this value to zero to make the tooltip remain visible until it is explicitly dismissed.
    /// The default value is six seconds.
    /// </remarks>
    public TimeSpan DisplayDuration
    {
        get => (TimeSpan)GetValue(DisplayDurationProperty);
        set => SetValue(DisplayDurationProperty, value);
    }

    /// <summary>
    /// (Apple only) A property that binds <see cref="Tagline"/>.
    /// </summary>
    public static readonly BindableProperty TaglineDialogProperty =
        BindableProperty.Create(nameof(Tagline), typeof(string), typeof(LoginTooltipView), String.Empty, BindingMode.OneWay, null);

    /// <summary>
    /// (Apple only) First part of the label, that will be highlighted with different color. Can be nil.
    /// </summary>
    public string Tagline
    {
        get { return (string)GetValue(TaglineDialogProperty); }
        set { SetValue(TaglineDialogProperty, value); }
    }

    /// <summary>
    /// A property that binds the main <see cref="Message"/> to display.
    /// </summary>
    public static readonly BindableProperty MessageDialogProperty =
        BindableProperty.Create(nameof(Message), typeof(string), typeof(LoginTooltipView), "Sign in here", BindingMode.OneWay, null);

    /// <summary>
    /// Main message to display. Defaults to "Sign in here"
    /// </summary>
    public string Message
    {
        get { return (string)GetValue(MessageDialogProperty); }
        set { SetValue(MessageDialogProperty, value); }
    }
        
    /// <summary>
    /// A property that binds the main view the tooltip will anchor to.
    /// </summary>
    public static readonly BindableProperty AnchorProperty =
        BindableProperty.Create(nameof(AnchorView), typeof(View), typeof(LoginTooltipView), null, BindingMode.OneWay, null);

    /// <summary>
    /// The View to Anchor the tooltip to.
    /// </summary>
    public View? AnchorView
    {
        get { return (View?)GetValue(AnchorProperty); }
        set { SetValue(AnchorProperty, value); }
    }

    /// <summary>
    /// A property that binds the main <see cref="TooltipColorStyle"/> to use for the tooltip.
    /// </summary>
    public static readonly BindableProperty ColorStyleProperty =
        BindableProperty.Create(nameof(ColorStyle), typeof(TooltipColorStyle), typeof(LoginTooltipView), TooltipColorStyle.FriendlyBlue, BindingMode.OneWay, null);

    /// <summary>
    /// Color style to use for tooltip.
    /// </summary>
    public TooltipColorStyle ColorStyle
    {
        get { return (TooltipColorStyle)GetValue(ColorStyleProperty); }
        set { SetValue(ColorStyleProperty, value); }
    }

    /// <summary>
    /// Display this tool tip to the user
    /// </summary>
    public void PresentFrom()
    {
#if IOS || MACCATALYST || ANDROID
        (Handler as LoginTooltipViewHandler)?.PresentFrom();
#endif
    }

    /// <summary>
    /// Dismiss the tool tip
    /// </summary>
    public void Dismiss()
    {
#if IOS || MACCATALYST || ANDROID
        (Handler as LoginTooltipViewHandler)?.Dismiss();
#endif
    }
    
    internal void RaiseAppearingEvent(object? sender, EventArgs e) => Appearing?.Invoke(sender, e);
    internal void RaiseNotAppearingEvent(object? sender, EventArgs e) => NotAppearing?.Invoke(sender, e);
}
