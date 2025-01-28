namespace Reservas.DTOs;

public class ReserveUpdateDto
{
    public int Id { get; set; }
    public string Room { get; set; }
    public string Owner { get; set; }
    public int RoomId { get; set; }
    public int UserId { get; set; }
}