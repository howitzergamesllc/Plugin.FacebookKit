
namespace Plugin.FacebookKit.Login
{
    /// <summary>
    /// Sealed shared class to lazy initialize the Facebook Login SDKs
    /// </summary>
    public sealed class FacebookPluginLogin
    {
        private static Lazy<IFacebookPluginLogin?> _implementation = new Lazy<IFacebookPluginLogin?>(CreateInstance, System.Threading.LazyThreadSafetyMode.PublicationOnly);

        private static IFacebookPluginLogin? CreateInstance()
        {
#if IOS || MACCATALYST || ANDROID
            return new FacebookPluginLoginImplementation();
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
        public static IFacebookPluginLogin? Current {
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
        /// An initialization method to call for iOS implementation
        /// </summary>
        public static void Initialize(bool automaticallyUpdateProfileOnAccessTokenChange = true)
        {
#if IOS || MACCATALYST || ANDROID
            FacebookPluginLoginImplementation.Initialize(automaticallyUpdateProfileOnAccessTokenChange);
#endif
        }

        /// <summary>
        /// The global static current <see cref="IAccessToken"/>.
        /// </summary>
        /// <remarks>Winodws not implemented and returns null.</remarks>
        public static IAccessToken? CurrentToken => 
#if IOS || MACCATALYST || ANDROID
            Current?.CurrentAccessToken;
#elif WINDOWS
            null;
#endif

        /// <summary>
        /// Loads the current profile.
        /// </summary>
        /// <remarks>NOTE: This is not implemented on Windows and always returns null.</remarks>
        /// <returns>A task the asyncronously promises a <see cref="IProfile"/>.</returns>
        public static Task<IProfile?>? LoadCurrentProfileAsync() => 
#if IOS || MACCATALYST || ANDROID
            Current?.LoadCurrentProfileAsync();
#elif WINDOWS
            Task.FromResult<IProfile?>(null);
#endif

        /// <summary>
        /// The global static current <see cref="IProfile"/>.
        /// </summary>
        /// <remarks>NOTE: This is not implemented on Windows and always returns null.</remarks>
        public static IProfile? CurrentProfile => 
#if IOS || MACCATALYST || ANDROID
            Current?.CurrentProfile;
#elif WINDOWS
            null;
#endif

        /// <summary>
        /// Dispose of everything 
        /// </summary>
        public static void Dispose()
        {
            if(_implementation != null && _implementation.IsValueCreated) {
                _implementation.Value?.Dispose();
                _implementation = new Lazy<IFacebookPluginLogin?>(CreateInstance, System.Threading.LazyThreadSafetyMode.PublicationOnly);
            }
        }
    }
}