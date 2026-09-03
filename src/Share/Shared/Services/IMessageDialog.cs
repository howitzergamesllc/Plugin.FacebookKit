
namespace Plugin.FacebookKit.Share;

/// <summary>
/// Represents a dialog capable of presenting message dialog content.
/// </summary>
/// <remarks>
/// Note: No callback will be invoked on android when calling Show(), use ShowInstance() instead.
/// </remarks>
public interface IMessageDialog : ISharingDialog
{
    /// <summary>
    /// The mode to display the dialog.
    /// </summary>
    ShareDialogMode Mode { get; set; }
}