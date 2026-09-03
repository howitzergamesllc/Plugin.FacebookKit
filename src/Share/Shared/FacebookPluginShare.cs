
namespace Plugin.FacebookKit.Share
{
    /// <summary>
    /// Sealed shared class to lazy initialize the Facebook Share SDK
    /// </summary>
    public sealed class FacebookPluginShare
    {
        private static Lazy<IFacebookPluginShare?> _implementation = new Lazy<IFacebookPluginShare?>(CreateInstance, System.Threading.LazyThreadSafetyMode.PublicationOnly);

        private static IFacebookPluginShare? CreateInstance()
        {
#if IOS || MACCATALYST || ANDROID
            return new FacebookPluginShareImplementation();
#else
#pragma warning disable IDE0022 // Use expression body for methods
            return null;
#pragma warning restore IDE0022 // Use expression body for methods
#endif
        }

        /// <summary>
        /// Gets if the plugin is supported on the current platform.
        /// </summary>
        public static bool IsSupported => _implementation.Value != null;

        /// <summary>
        /// Current plugin implementation to use
        /// </summary>
        public static IFacebookPluginShare? Current {
            get {
                var ret = _implementation.Value;
                if(ret == null) {
                    NotImplementedInReferenceAssembly();
                }
                return ret;
            }
        }

        private static void NotImplementedInReferenceAssembly()
        {
            try
            {
                throw new NotImplementedException("This platform has not been implemented into this version of the plugin. All future calls to this plugin, will not work.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.Message}, StackTrace={e.StackTrace}");
            }
        }

        /// <summary>
        /// Dispose of everything 
        /// </summary>
        public static void Dispose()
        {
            if(_implementation != null && _implementation.IsValueCreated) {
                _implementation.Value?.Dispose();
                _implementation = new Lazy<IFacebookPluginShare?>(CreateInstance, System.Threading.LazyThreadSafetyMode.PublicationOnly);
            }
        }
    }
}