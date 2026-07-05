using System.Text.Json.Serialization;

namespace Mastonet;

/// <summary>
/// Represents the automatic quote approval policy of an account.
/// https://docs.joinmastodon.org/entities/QuoteApproval/#automatic
/// Version: 4.5.0
/// </summary>
[JsonConverter(typeof(JsonEnumConverter<QuoteApprovalPolicy>))]
public enum QuoteApprovalPolicy
{
    /// <summary>
    /// Anybody is expected to be able to quote this status and have the quote be automatically accepted.
    /// </summary>
    Public,

    /// <summary>
    /// Followers are expected to be able to quote this status and have the quote be automatically accepted.
    /// </summary>
    Followers,

    /// <summary>
    /// People followed by the author are expected to be able to quote this status and have the quote be automatically accepted.
    /// </summary>
    Following,

    /// <summary>
    /// The underlying quote policy is not supported by Mastodon. Some accounts that do not fit in the above categories may be able to quote and have the quote be automatically accepted.
    /// </summary>
    UnsupportedPolicy,
}
