using System.ComponentModel.DataAnnotations;

namespace PracticaFinalFranciscoPerez.Models
{
    public class PersonaItem
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? IsCompleted { get; set; }
    }
}
