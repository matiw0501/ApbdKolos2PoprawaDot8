using System.ComponentModel.DataAnnotations;

namespace kolos2Poprawa.Models;

public class Nursery
{
    [Key]
    public int NurseryId { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }
    public DateTime EstablishedDate { get; set; }
    
    public ICollection<SeedlingBatch> SeedlingBatches { get; set; }
    
}