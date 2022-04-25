using System.ComponentModel.DataAnnotations;

namespace ContadorDeAssistencineitor.Client.Models
{
    public class UserModel
    {
        [Required]
        public string? Name { get; set; }
    }
}
