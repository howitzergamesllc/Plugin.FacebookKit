
namespace Plugin.FacebookKit.Share;

/// <summary>
/// Represents a single hashtag that can be used with <see cref="ISharingDialog"/>.
/// </summary>
public sealed class HashTag
{
    /// <summary>
    /// The hashtag string.
    /// You are responsible for making sure that <code>stringRepresentation</code> is a valid hashtag (a single ‘#’ followed by one or more
    /// word characters). Invalid hashtags are ignored when sharing content. You can check validity with the<code>valid</code> property.
    /// @return The hashtag string
    /// </summary>
    public string StringRepresentation { get; set; } = "";
    
    /// <summary>
    /// Tests if a hashtag is valid.
    /// A valid hashtag matches the regular expression “#\w+”: A single ‘#’ followed by one or more word characters.
    /// @return true if the hashtag is valid, false otherwise.
    /// </summary>
    public bool IsValid => !string.IsNullOrWhiteSpace(StringRepresentation) && StringRepresentation.StartsWith('#');

    /// <summary>
    /// Returns the unassigned integer of the native HashTag object.
    /// </summary>
    public int Hash { get; set; }

    /// <summary>
    /// Constructs a HashTag for sharing to Facebook.
    /// </summary>
    /// <param name="stringRepresentation">The string to represent the HashTag(i.e. #washingtondc)</param>
    public HashTag(string stringRepresentation)
    {
        StringRepresentation = stringRepresentation;
    }

    /// <summary>
    /// Returns the string representation of the object.
    /// </summary>
    /// <returns></returns>
    public string DebugDescription() => $"HashTag StringRepresentation={StringRepresentation}, IsValid={IsValid}, Hash={Hash}";
}