using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyFirstServerSideBlazor.Database.Entities
{
    [Table("BlazorUser")]
    public class BlazorUser 
    {
        [Key] public int Id { get; set; }

        [Required] public string UserName { get; set; } = "";

        [Required] public string PasswordHash { get; set; } = "";

        [Required] public string Role { get; set; } = "";

        [Required] public DateTime LastSeen { get; set; }

        [Required] public DateTime Created { get; set; }
    }
}
