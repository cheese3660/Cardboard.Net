using Cardboard.Net.Entities.Users;
using Cardboard.Net.Rest;
using Newtonsoft.Json;

namespace Cardboard.Net.Entities;

/// <summary>
/// Class representing a misskey user
/// </summary>
public class User : MisskeyObject
{
    /// <summary>
    /// Optional display name of the current user
    /// </summary>
    [JsonProperty("name")]
    public string? Name { get; init; }

    /// <summary>
    /// The username of the current user
    /// </summary>
    [JsonProperty("username")]
    public required string Username { get; init; }

    /// <summary>
    /// The hostname of the current user, null if it's local to us
    /// </summary>
    [JsonProperty("host")]
    public string? Host { get; init; }
    
    /// <summary>
    /// List of fields configurable in the profile
    /// </summary>
    [JsonIgnore]
    public IReadOnlyList<Users.Field> Fields
        => this.fields;

    [JsonProperty("fields")] 
    internal List<Users.Field> fields = [];

    /// <summary>
    /// The url corresponding to this user's avatar
    /// </summary>
    [JsonProperty("avatarUrl")]
    public Uri? AvatarUrl { get; init; }

    /// <summary>
    /// Whether the user is an administrator
    /// </summary>
    [JsonProperty("isAdministrator")]
    public bool IsAdministrator { get; init; }

    /// <summary>
    /// Whether the user is a moderator
    /// </summary>
    [JsonProperty("isModerator")]
    public bool IsModerator { get; init; }

    /// <summary>
    /// Whether the user is silenced
    /// </summary>
    [JsonProperty("isSilenced")]
    public bool IsSilenced { get; init; }

    /// <summary>
    /// Whether the user has indexing enabled
    /// </summary>
    [JsonProperty("noindex")]
    public bool NoIndex { get; init; }
    
    /// <summary>
    /// Whether the user is a bot
    /// </summary>
    [JsonProperty("isBot")]
    public bool IsBot { get; init; }

    /// <summary>
    /// Whether the user is a cat
    /// </summary>
    [JsonProperty("isCat")]
    public bool IsCat { get; init; }

    /// <summary>
    /// Whether the user speaks like a cat
    /// </summary>
    [JsonProperty("speakAsCat")]
    public bool IsCatSpeak { get; init; }

    /// <summary>
    /// The amount of users this user follows, 0 if private
    /// </summary>
    [JsonProperty("followingCount")]
    public int FollowingCount { get; init; }

    /// <summary>
    /// The amount of users following this user
    /// </summary>
    [JsonProperty("followersCount")]
    public int FollowerCount { get; init; }
    
    /// <summary>
    /// The visibility setting for following
    /// </summary>
    [JsonProperty("followingVisibility")]
    public FollowVisibilityType FollowingVisibility { get; init; }

    /// <summary>
    /// The visibility setting for followers
    /// </summary>
    [JsonProperty("followerVisibility")]
    public FollowVisibilityType FollowerVisibility { get; init; }

    /// <summary>
    /// Sends a follow request to the user stored
    /// </summary>
    /// <param name="withReplies">Whether to display replies on timeline</param>
    public async Task SendFollowRequestAsync(bool withReplies = false)
        => await this.Misskey.ApiClient.SendRequestAsync(Endpoints.FOLLOW_CREATE, 
            JsonConvert.SerializeObject(new { userId = this.Id, withReplies = withReplies }));
}