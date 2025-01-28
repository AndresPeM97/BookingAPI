namespace Reservas.DTOs;

public class ReserveInsertDto
{
    public string RoomName { get; set; }
    public string OwnerName { get; set; }
    public int RoomId { get; set; }
    public int UserId { get; set; }
}