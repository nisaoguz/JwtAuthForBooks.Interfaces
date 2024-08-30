namespace JwtAuthForBooks.Models
{
    /// <summary>
    /// Generate Token Request
    /// </summary>
    public class GenerateTokenRequest
    {
        /// <summary>Gets or sets the username.</summary>
        /// <value>The username.</value>
        public string UserName { get; set; }

        /// <summary>Gets or sets the refresh token.</summary>
        /// <value>The refresh token.</value>
        public string RefreshToken { get; set; }
    }
}
