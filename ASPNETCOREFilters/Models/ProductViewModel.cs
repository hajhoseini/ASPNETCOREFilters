using System.ComponentModel.DataAnnotations;

namespace ASPNETCOREFilters.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Price { get; set; }
    }
}
