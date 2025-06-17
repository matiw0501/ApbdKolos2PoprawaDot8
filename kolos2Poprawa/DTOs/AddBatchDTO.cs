

using System.ComponentModel.DataAnnotations;

public class AddBatchDTO
{
    [Required]
    public int Quantity { get; set; }

    [Required]
    [MaxLength(100)]
    public string Species { get; set; }

    [Required]
    [MaxLength(100)]
    public string Nursery { get; set; }

    [Required]
    public List<AddResponsibleDTO> Responsible { get; set; }
}

public class AddResponsibleDTO
{
    [Required]
    public int EmployeeId { get; set; }

    [Required]
    [MaxLength(100)]
    public string Role { get; set; }
}