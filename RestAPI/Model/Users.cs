using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace RestAPI.Model {
    public class Users {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [NotNull]
        public string UserName { get; set; }

        [Required]
        [MaxLength(130)]
        [NotNull]
        public string Password { get; set; }

        [MaxLength(120)]
        [NotNull]
        public string FullName { get; set; }

        [MaxLength(500)]
        [NotNull]
        public string? RefreshToken { get; set; }

        public DateTime? RefreshTokenExpiryTime { get; set; }
    }
}
