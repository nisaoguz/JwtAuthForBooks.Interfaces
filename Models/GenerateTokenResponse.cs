namespace JwtAuthForBooks.Models
{
    /// <summary>
    /// Generate Token Response
    /// </summary>
    public class GenerateTokenResponse
    {
        /// <summary>Gets or sets the access token.</summary>
        /// <value>The access token.</value>
        public string AccessToken { get; set; }

        /// <summary>Gets or sets the access token expire date.</summary>
        /// <value>The access token expire date.</value>
        public DateTime AccessTokenExpireDate { get; set; }

        /// <summary>Gets or sets the refresh token.</summary>
        /// <value>The refresh token.</value>
        public string RefreshToken { get; set; }

        /// <summary>Gets or sets the token.</summary>
        /// <value>The token.</value>
        public string Token { get; set; } // Yeni eklenen özellik

        /// <summary>Gets or sets the token expire date.</summary>
        /// <value>The token expire date.</value>
        public DateTime TokenExpireDate { get; set; } // Yeni eklenen özellik
    }
}
