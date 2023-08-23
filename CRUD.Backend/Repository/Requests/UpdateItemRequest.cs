namespace CRUD.Backend.Repository.Requests
{
    public class UpdateItemRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
