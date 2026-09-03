
using Net = Android.Net;

namespace Plugin.FacebookKit.Share.Platforms.Android.Extensions;

internal static class ObjectExtensions
{        
    public static Net.Uri? ToNativeUri (this Uri? uri)
    {
        if(uri is null || string.IsNullOrEmpty(uri.AbsoluteUri))
            return null;

        return Net.Uri.Parse(uri.AbsoluteUri);
    }

	public static Net.Uri? LoadContentUri(this Net.Uri destination)
	{
        if(destination is null || System.String.IsNullOrEmpty(destination.ToString()))
            return null;

        var path = destination.EncodedPath?.ToString();

        if(path is null)
            return null;

        var file = new Java.IO.File(path);
        var context = Platform.AppContext;
        return FileProvider.GetUriForFile(context, $"{context.PackageName}.fileprovider", file);
	}
}