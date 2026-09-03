
namespace Plugin.FacebookKit.Share;

/// <summary>
/// Codes mapping to a facebook sdk share error code.
/// </summary>
public enum ShareErrorCode
{
    /// <summary>
    /// Reserved
    /// </summary>
    Reserved = 200,

    /// <summary>
    /// An error with the Graph API
    /// </summary>
    OpenGraph = 201,

    /// <summary>
    /// A <see cref="ISharingDialog"/> error occured.
    /// </summary>
    DialogNotAvailable = 202,

    /// <summary>
    /// An unknown error occured.
    /// </summary>
    Unknown = 203,
}