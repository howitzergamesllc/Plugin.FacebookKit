
namespace Plugin.FacebookKit.Login;

/// <summary>
/// (Apple Only) Specifies the direction of the arrow displayed on a login tooltip.
/// </summary>
public enum TooltipViewArrowDirection
{
    /// <summary>
    /// Displays the tooltip arrow pointing downward.
    /// </summary>
    Down,

    /// <summary>
    /// Displays the tooltip arrow pointing upward.
    /// </summary>
    Up,

    /// <summary>
    /// The type was unknown. This could be an update to the facebook-ios-sdk.
    /// </summary>
    Unknown = -1,
}