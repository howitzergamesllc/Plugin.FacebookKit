
namespace Plugin.FacebookKit.Login;

/// <summary>
/// Contains all the permissions available using Facebook login.
/// </summary>
public static class Permissions
{
    /// <summary>
    /// The AdsManagement permission allows your app to both read and manage the Ads account it owns, or has been granted access to, by the Ad account owner.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="PagesReadEngagement"/> and <see cref="PagesShowList"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string AdsManagement = "ads_management";

    /// <summary>
    /// The AdsMcpManagement permission allows your app to access the Meta ads Model Context Protocol (MCP) server and enable AI agents to interact with Meta Ads on behalf of advertisers.
    /// </summary>
    /// <remarks>
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string AdsMcpManagement = "ads_mcp_management";

    /// <summary>
    /// The AdsRead permission allows your app to access the Ads Insights API to pull Ads report information for Ad accounts you own or have been granted access to by the owner or owners of other ad accounts through this permission.
    /// </summary>
    /// <remarks>
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string AdsRead = "ads_read";

    /// <summary>
    /// The AttributionRead permission grants your app access to the Attribution API to pull attribution report data for lines of business you own or have been granted access to by the owner or owners of other lines of business.
    /// </summary>
    /// <remarks>
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string AttributionRead = "attribution_read";

    /// <summary>
    /// The BusinessManagement permission allows your app to read and write with the Business Manager API.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="PagesReadEngagement"/> and <see cref="PagesShowList"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string BusinessManagement = "business_management";

    /// <summary>
    /// The CatalogManagement permission allows your app to create, read, update and delete business-owned product catalogs that the user is an admin of.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="BusinessManagement"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string CatalogManagement = "catalog_management";

    /// <summary>
    /// The CommerceAccountManageOrders permission allows your app to read and update commerce account orders.
    /// </summary>
    /// <remarks>
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string CommerceAccountManageOrders = "commerce_account_manage_orders";

    /// <summary>
    /// The CommerceAccountReadOrders permission allows your app to read commerce account orders.
    /// </summary>
    /// <remarks>
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string CommerceAccountReadOrders = "commerce_account_read_orders";

    /// <summary>
    /// The CommerceAccountReadReports permission allows your app to read finance reporting data to build custom tax, cash reconciliation and reimbursement reports for a commerce account.
    /// </summary>
    /// <remarks>
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string CommerceAccountReadReports = "commerce_account_read_reports";

    /// <summary>
    /// The CommerceAccountReadSettings permission allows your app to read commerce account settings.
    /// </summary>
    /// <remarks>
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string CommerceAccountReadSettings = "commerce_account_read_settings";

    /// <summary>
    /// The CommerceManageAccounts permission allows your app to create and manage commerce accounts, such as an ecommerce app.
    /// </summary>
    /// <remarks>
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string CommerceManageAccounts = "commerce_manage_accounts";

    /// <summary>
    /// The Email permission allows your app to read a person's primary email address.
    /// </summary>
    /// <remarks>
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string Email = "email";

    /// <summary>
    /// The FacebookBrandedContentAdsBrand permission allows an app to read Facebook posts where the app user's Facebook profile is tagged as a paid partner, and an app user to read, request, and revoke permissions to run Partnership Ads.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="PagesReadEngagement"/> and <see cref="PagesShowList"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string FacebookBrandedContentAdsBrand = "facebook_branded_content_ads_brand";

    /// <summary>
    /// The FacebookCreatorMarketplaceDiscovery permission allows an app to discover content creators on Facebook's creator discovery platform.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="PagesShowList"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string FacebookCreatorMarketplaceDiscovery = "facebook_creator_marketplace_discovery";

    /// <summary>
    /// The GamingProfile permission allows your app to access a person's gaming profile information.
    /// </summary>
    /// <remarks>
    /// This permission is required by <see cref="GamingUserLocale"/>.
    /// </remarks>
    public const string GamingProfile = "gaming_profile";

    /// <summary>
    /// The GamingUserLocale permission allows your app to get a user's preferred language while the user plays a game on Facebook.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="GamingProfile"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string GamingUserLocale = "gaming_user_locale";

    /// <summary>
    /// The InstagramBasic permission allows your app to read an Instagram account profile's info and media.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="PagesReadUserContent"/> and <see cref="PagesShowList"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string InstagramBasic = "instagram_basic";

    /// <summary>
    /// The InstagramBrandedContentAdsBrand permission allows an app to read Instagram posts where the app user's Instagram account is tagged as a paid partner, and an app user to read, request, and revoke permissions to run Partnership Ads.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="InstagramBasic"/>, <see cref="PagesReadEngagement"/> and <see cref="PagesShowList"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string InstagramBrandedContentAdsBrand = "instagram_branded_content_ads_brand";

    /// <summary>
    /// The InstagramBrandedContentBrand permission allows your app to add, remove and view creators from a specific brand's approved creators list.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="InstagramBasic"/>, <see cref="PagesReadEngagement"/> and <see cref="PagesShowList"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string InstagramBrandedContentBrand = "instagram_branded_content_brand";

    /// <summary>
    /// The InstagramBrandedContentCreator permission allows your app to read and change the boost status of a creator's specific piece of content.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="InstagramBasic"/>, <see cref="PagesReadEngagement"/> and <see cref="PagesShowList"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string InstagramBrandedContentCreator = "instagram_branded_content_creator";

    /// <summary>
    /// The InstagramBusinessBasic permission allows your app to read an Instagram Business account profile's info and media.
    /// </summary>
    /// <remarks>
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string InstagramBusinessBasic = "instagram_business_basic";

    /// <summary>
    /// The InstagramBusinessContentPublish permission allows an app to create organic feed photo and video posts on behalf of a business user.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="InstagramBusinessBasic"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string InstagramBusinessContentPublish = "instagram_business_content_publish";

    /// <summary>
    /// The InstagramBusinessManageComments permission allows an app to access comments on an Instagram professional account.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="InstagramBusinessBasic"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string InstagramBusinessManageComments = "instagram_business_manage_comments";

    /// <summary>
    /// The InstagramBusinessManageInsights permission allows your app to fetch insights for an Instagram Business account.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="InstagramBusinessBasic"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string InstagramBusinessManageInsights = "instagram_business_manage_insights";

    /// <summary>
    /// The InstagramBusinessManageMessages permission allows an app to access messages on an Instagram professional account.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="InstagramBusinessBasic"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string InstagramBusinessManageMessages = "instagram_business_manage_messages";

    /// <summary>
    /// The InstagramContentPublish permission allows your app to publish content to an Instagram account you have access to.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="InstagramBasic"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string InstagramContentPublish = "instagram_content_publish";

    /// <summary>
    /// The InstagramCreatorMarketplaceDiscovery permission allows an app to discover creators on Instagram Creator Marketplace and access eligible creator insights.
    /// </summary>
    /// <remarks>
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string InstagramCreatorMarketplaceDiscovery = "instagram_creator_marketplace_discovery";

    /// <summary>
    /// The InstagramCreatorMarketplaceMessaging permission allows an app to retrieve brand partner conversations and creator messaging IDs for partner messages.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="InstagramCreatorMarketplaceDiscovery"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string InstagramCreatorMarketplaceMessaging = "instagram_creator_marketplace_messaging";

    /// <summary>
    /// The InstagramGraphUserMedia permission allows your app to read the Media node and its edges.
    /// </summary>
    /// <remarks>
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string InstagramGraphUserMedia = "instagram_graph_user_media";

    /// <summary>
    /// The InstagramGraphUserProfile permission allows your app to read the app user's Instagram profile.
    /// </summary>
    /// <remarks>
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string InstagramGraphUserProfile = "instagram_graph_user_profile";

    /// <summary>
    /// The InstagramManageComments permission allows your app to manage comments on Instagram media.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="InstagramBasic"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string InstagramManageComments = "instagram_manage_comments";

    /// <summary>
    /// The InstagramManageContents permission allows your app to delete posts, stories, or reels on behalf of an Instagram account connected to a Facebook Page.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="InstagramBasic"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string InstagramManageContents = "instagram_manage_contents";

    /// <summary>
    /// The InstagramManageEngagement permission allows your app to create or delete likes for Instagram media, comments, and replies.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="InstagramBasic"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string InstagramManageEngagement = "instagram_manage_engagement";

    /// <summary>
    /// The InstagramManageEvents permission allows your app to log events on behalf of Instagram accounts administered by app users.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="InstagramBasic"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string InstagramManageEvents = "instagram_manage_events";

    /// <summary>
    /// The InstagramManageInsights permission allows your app to read insights for Instagram accounts you have access to.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="InstagramBasic"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string InstagramManageInsights = "instagram_manage_insights";

    /// <summary>
    /// The InstagramManageMessages permission allows business users to read and respond to Instagram Direct messages.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="InstagramBasic"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string InstagramManageMessages = "instagram_manage_messages";

    /// <summary>
    /// The InstagramManageUpcomingEvents permission allows your app to read, create, and update upcoming events on behalf of Instagram accounts.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="InstagramBasic"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string InstagramManageUpcomingEvents = "instagram_manage_upcoming_events";

    /// <summary>
    /// The InstagramShoppingTagProducts permission allows an app to tag Instagram media with product tags and appeal product rejections.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="InstagramBasic"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string InstagramShoppingTagProducts = "instagram_shopping_tag_products";

    /// <summary>
    /// The LeadsRetrieval permission allows your app to retrieve information captured within a lead.
    /// </summary>
    /// <remarks>
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string LeadsRetrieval = "leads_retrieval";

    /// <summary>
    /// The PagesEvents permission allows your app to log events on behalf of Facebook Pages.
    /// </summary>
    /// <remarks>
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string PagesEvents = "page_events";

    /// <summary>
    /// The PagesManageAds permission allows your app to manage ads associated with a Page.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="PagesReadEngagement"/> and <see cref="PagesShowList"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string PagesManageAds = "pages_manage_ads";

    /// <summary>
    /// The PagesManageCta permission allows your app to manage call-to-actions of Pages that you manage.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="PagesShowList"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string PagesManageCta = "pages_manage_cta";

    /// <summary>
    /// The PagesManageEngagement permission allows your app to create, edit, and delete comments posted on a Page.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="PagesReadEngagement"/> and <see cref="PagesShowList"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string PagesManageEngagement = "pages_manage_engagement";

    /// <summary>
    /// The PagesManageInstantArticles permission allows your app to manage Instant Articles on behalf of Facebook Pages.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="PagesShowList"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string PagesManageInstantArticles = "pages_manage_instant_articles";

    /// <summary>
    /// The PagesManageLeads permission allows your app to manage leads retrieved from Lead Ads of Pages that you manage.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="LeadsRetrieval"/> and <see cref="PagesShowList"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string PagesManageLeads = "pages_manage_leads";

    /// <summary>
    /// The PagesManageMetadata permission allows your app to subscribe to and receive webhooks about activity on a Page and update Page settings.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="PagesShowList"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string PagesManageMetadata = "pages_manage_metadata";

    /// <summary>
    /// The PagesManagePosts permission allows your app to create, edit, and delete Page posts.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="PagesShowList"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string PagesManagePosts = "pages_manage_posts";

    /// <summary>
    /// The PagesMessaging permission allows your app to send and receive messages through a Facebook Page.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="PagesManageMetadata"/> and <see cref="PagesShowList"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string PagesMessaging = "pages_messaging";

    /// <summary>
    /// The PagesMessagingPayments permission allows your app to charge users in Messenger conversations on behalf of Pages.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="PagesMessaging"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string PagesMessagingPayments = "pages_messaging_payments";

    /// <summary>
    /// The PagesMessagingPhoneNumber permission allows your app to send and receive messages through a Facebook Page using its phone number.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="PagesMessaging"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string PagesMessagingPhoneNumber = "pages_messaging_phone_number";

    /// <summary>
    /// The PagesMessagingSubscriptions permission allows your app to send and receive messages through a Facebook Page outside the 24-hour window opened by a user action.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="PagesMessaging"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string PagesMessagingSubscriptions = "pages_messaging_subscriptions";

    /// <summary>
    /// The PagesReadEngagement permission allows your app to read content and metadata about a Page, including followers and engagement information.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="PagesShowList"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string PagesReadEngagement = "pages_read_engagement";

    /// <summary>
    /// The PagesReadUserContent permission allows your app to read user-generated content on a Page, such as posts, comments, and ratings.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="PagesReadEngagement"/> and <see cref="PagesShowList"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string PagesReadUserContent = "pages_read_user_content";

    /// <summary>
    /// The PagesShowList permission allows your app to show the list of Pages that a user manages.
    /// </summary>
    /// <remarks>
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string PagesShowList = "pages_show_list";

    /// <summary>
    /// The PagesUserGender permission allows your app to access a user's gender through a Page your app is connected to.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="PagesReadEngagement"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string PagesUserGender = "pages_user_gender";

    /// <summary>
    /// The PagesUserLocale permission allows your app to access a user's locale through a Page your app is connected to.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="PagesReadEngagement"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string PagesUserLocale = "pages_user_locale";

    /// <summary>
    /// The PagesUserTimezone permission allows your app to access a user's timezone through a Page your app is connected to.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="PagesReadEngagement"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string PagesUserTimezone = "pages_user_timezone";

    /// <summary>
    /// The PrivateComputationAccess permission allows your app to access Meta Private Computation products.
    /// </summary>
    /// <remarks>
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string PrivateComputationAccess = "private_computation_access";

    /// <summary>
    /// The PublicProfile permission allows your app to access a subset of information from a person's public profile.
    /// </summary>
    /// <remarks>
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string PublicProfile = "public_profile";

    /// <summary>
    /// The PublishVideo permission allows your app to publish live videos to the app user's timeline.
    /// </summary>
    /// <remarks>
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string PublishVideo = "publish_video";

    /// <summary>
    /// The ReadAudienceNetworkInsights permission provides read-only access to Audience Network Insights data for apps the person owns.
    /// </summary>
    /// <remarks>
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string ReadAudienceNetworkInsights = "read_audience_network_insights";

    /// <summary>
    /// The ReadInsights permission allows your app to read Insights data for Pages, apps, and web domains the person owns.
    /// </summary>
    /// <remarks>
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string ReadInsights = "read_insights";

    /// <summary>
    /// The ResearchApis permission allows your app to access data on public Facebook Pages, Groups, and Events through the Facebook Open Research and Transparency Tool.
    /// </summary>
    /// <remarks>
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string ResearchApis = "research_apis";

    /// <summary>
    /// The RsvpEvent permission allows your app to set a person's attendee status on Facebook Events.
    /// </summary>
    /// <remarks>
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string RsvpEvent = "rsvp_event";

    /// <summary>
    /// The ThreadsBasic permission allows your app to access a user's Threads profile information and media and text content they posted.
    /// </summary>
    /// <remarks>
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string ThreadsBasic = "threads_basic";

    /// <summary>
    /// The ThreadsBusinessBasic permission allows your app to fetch the Threads account ID connected to an Instagram account.
    /// </summary>
    /// <remarks>
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string ThreadsBusinessBasic = "threads_business_basic";

    /// <summary>
    /// The ThreadsContentPublish permission allows your app to create and publish content on behalf of a Threads profile.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="ThreadsBasic"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string ThreadsContentPublish = "threads_content_publish";

    /// <summary>
    /// The ThreadsDelete permission allows your app to delete an app user's Threads posts.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="ThreadsBasic"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string ThreadsDelete = "threads_delete";

    /// <summary>
    /// The ThreadsKeywordSearch permission allows your app to search for and fetch Threads content using keywords.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="ThreadsBasic"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string ThreadsKeywordSearch = "threads_keyword_search";

    /// <summary>
    /// The ThreadsLocationTagging permission allows your app to search for public locations and publish Threads media with a location tag.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="ThreadsContentPublish"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string ThreadsLocationTagging = "threads_location_tagging";

    /// <summary>
    /// The ThreadsManageInsights permission allows your app to access insights for a Threads profile.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="ThreadsBasic"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string ThreadsManageInsights = "threads_manage_insights";

    /// <summary>
    /// The ThreadsManageMentions permission allows your app to fetch content where the user is mentioned on Threads.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="ThreadsBasic"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string ThreadsManageMentions = "threads_manage_mentions";

    /// <summary>
    /// The ThreadsManageReplies permission allows your app to create, hide, unhide, and manage replies on behalf of a Threads profile.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="ThreadsBasic"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string ThreadsManageReplies = "threads_manage_replies";

    /// <summary>
    /// The ThreadsProfileDiscovery permission allows your app to discover public Threads profiles and their public posts.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="ThreadsBasic"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string ThreadsProfileDiscovery = "threads_profile_discovery";

    /// <summary>
    /// The ThreadsReadReplies permission allows your app to read replies to a user's Threads posts.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="ThreadsBasic"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string ThreadsReadReplies = "threads_read_replies";

    /// <summary>
    /// The ThreadsShareToInstagram permission allows your app to share a user's Threads post to their linked Instagram account.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="ThreadsBasic"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string ThreadsShareToInstagram = "threads_share_to_instagram";

    /// <summary>
    /// The UserAgeRange permission provides access to a person's age range.
    /// </summary>
    /// <remarks>
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string UserAgeRange = "user_age_range";

    /// <summary>
    /// The UserBirthday permission provides access to the date and month of a person's birthday.
    /// </summary>
    /// <remarks>
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string UserBirthday = "user_birthday";

    /// <summary>
    /// The UserEvents permission provides read-only access to Events a person is hosting or has RSVP'd to.
    /// </summary>
    /// <remarks>
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string UserEvents = "user_events";

    /// <summary>
    /// The UserFriends permission provides access to the list of friends who also use your app.
    /// </summary>
    /// <remarks>
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string UserFriends = "user_friends";

    /// <summary>
    /// The UserGender permission provides access to a person's gender.
    /// </summary>
    /// <remarks>
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string UserGender = "user_gender";

    /// <summary>
    /// The UserHometown permission provides access to a person's hometown.
    /// </summary>
    /// <remarks>
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string UserHometown = "user_hometown";

    /// <summary>
    /// The UserLikes permission provides access to the Facebook Pages and Open Graph objects that a person has liked.
    /// </summary>
    /// <remarks>
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string UserLikes = "user_likes";

    /// <summary>
    /// The UserLink permission provides access to the Facebook profile URL for another user of the app.
    /// </summary>
    /// <remarks>
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string UserLink = "user_link";

    /// <summary>
    /// The UserLocation permission provides access to a person's current city.
    /// </summary>
    /// <remarks>
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string UserLocation = "user_location";

    /// <summary>
    /// The UserManagedGroups permission enables your app to read the Groups a person is an administrator of.
    /// </summary>
    /// <remarks>
    /// This permission is deprecated and is limited to testing.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string UserManagedGroups = "user_managed_groups";

    /// <summary>
    /// The UserMedia permission allows your app to read media using the Instagram Basic Display API.
    /// </summary>
    /// <remarks>
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string UserMedia = "user_media";

    /// <summary>
    /// The UserMessengerContact permission allows a business to contact a person via Messenger after the person approves or initiates a chat with the business's Page.
    /// </summary>
    /// <remarks>
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string UserMessengerContact = "user_messenger_contact";

    /// <summary>
    /// The UserPhotos permission provides access to photos a person has uploaded or been tagged in.
    /// </summary>
    /// <remarks>
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string UserPhotos = "user_photos";

    /// <summary>
    /// The UserPosts permission provides access to posts on a person's Timeline.
    /// </summary>
    /// <remarks>
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string UserPosts = "user_posts";

    /// <summary>
    /// The UserProfile permission allows your app to read the app user's profile using the Instagram Basic Display API.
    /// </summary>
    /// <remarks>
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string UserProfile = "user_profile";

    /// <summary>
    /// The UserTaggedPlaces permission provides access to places a person has been tagged in.
    /// </summary>
    /// <remarks>
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string UserTaggedPlaces = "user_tagged_places";

    /// <summary>
    /// The UserVideos permission provides access to videos a person has uploaded or been tagged in.
    /// </summary>
    /// <remarks>
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string UserVideos = "user_videos";

    /// <summary>
    /// The WhatsAppBusinessManageEvents permission allows your app to log events on behalf of a WhatsApp Business account.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="WhatsAppBusinessManagement"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string WhatsAppBusinessManageEvents = "whatsapp_business_manage_events";

    /// <summary>
    /// The WhatsAppBusinessManagement permission allows your app to read and manage WhatsApp Business assets.
    /// </summary>
    /// <remarks>
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string WhatsAppBusinessManagement = "whatsapp_business_management";

    /// <summary>
    /// The WhatsAppBusinessMessaging permission allows your app to send WhatsApp messages and manage WhatsApp Business messaging functionality.
    /// </summary>
    /// <remarks>
    /// Depends on <see cref="WhatsAppBusinessManagement"/>.
    /// See https://developers.facebook.com/docs/permissions#reference for more details.
    /// </remarks>
    public const string WhatsAppBusinessMessaging = "whatsapp_business_messaging";
}