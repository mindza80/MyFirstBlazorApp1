using System.ComponentModel.DataAnnotations;

namespace ServerSideBlazor.Database.Entities
{
    public class BlazorUser 
    {
        [Key] public int Id { get; set; }

        [Required] public string UserName { get; set; }

        [Required] public string PasswordHash { get; set; }

        [Required] public string Role { get; set; }

        [Required] public DateTime LastSeen { get; set; }

        [Required] public DateTime Created { get; set; }
    }
}
