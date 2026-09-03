
namespace Plugin.FacebookKit.Share;

/// <summary>
/// WARNING: NOT IMPLEMENTED
/// </summary>
public sealed partial class ShareDialog : IShareDialog
{
    /// <summary>
    /// WARNING: NOT IMPLEMENTED
    /// </summary>
    public ISharingContent? ShareContent { get; set; }

    /// <summary>
    /// WARNING: NOT IMPLEMENTED
    /// </summary>
    public ShareDialogMode Mode { get; set; }
    
    /// <summary>
    /// WARNING: NOT IMPLEMENTED
    /// </summary>
    public bool CanShow => false;

    /// <summary>
    /// WARNING: NOT IMPLEMENTED
    /// </summary>
    public bool Show() => false;

    /// <summary>
    /// WARNING: NOT IMPLEMENTED
    /// </summary>
    public bool ShouldFailOnDataError { get; set; } = false;
}