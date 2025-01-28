namespace Reservas.DTOs;

public class ReserveDto
{
    public int Id { get; set; }
    public string RoomName { get; set; }
    public string OwnerName { get; set; }
    public int RoomId { get; set; }
    public int UserId { get; set; }
}