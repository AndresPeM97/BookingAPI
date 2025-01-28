using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reservas.Models;

public class Reserve
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string RoomName { get; set; }
    public string ReserveOwner { get; set; }
    
    public int RoomId { get; set; }
    
    public int UserId { get; set; }
    
    [ForeignKey("RoomId")]
    public virtual Room Room { get; set; }
    
    [ForeignKey("UserId")]
    public virtual User User { get; set; }
}