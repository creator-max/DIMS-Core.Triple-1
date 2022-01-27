using System.ComponentModel.DataAnnotations;

namespace DIMS_Core.Models.Sample
{
    public class SampleRequest
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}