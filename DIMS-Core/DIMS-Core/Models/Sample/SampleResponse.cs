using System.ComponentModel.DataAnnotations;

namespace DIMS_Core.Models.Sample;

public class SampleResponse
{
    public int SampleId { get; set; }

    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [MaxLength(50)]
    public string Description { get; set; }
}