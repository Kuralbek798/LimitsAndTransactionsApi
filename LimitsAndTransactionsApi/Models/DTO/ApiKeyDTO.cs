namespace LimitsAndTransactionsApi.Models.DTO
{
    public class ApiKeyDTO
    {
        public Guid? Id { get; private set; }
        public string? EncryptedApiKey { get; private set; }
        public DateTimeOffset? CreatedTime { get; private set; }
        public string? Description {  get; private set; }
        public bool Active { get; private set; } = true;

        public ApiKeyDTO(Guid id, string encryptedApiKey, DateTimeOffset createdTime, string description, bool active)
        {
            Id = id;
            EncryptedApiKey = encryptedApiKey;
            CreatedTime = createdTime;
            Description = description;
            Active = active;
        }

        public ApiKeyDTO()
        {
        }

        public override bool Equals(object? obj)
        {
           return obj is ApiKeyDTO other && 
                Id == other.Id && 
                EncryptedApiKey == other.EncryptedApiKey &&
                CreatedTime == other.CreatedTime &&
                Description == other.Description &&
                Active == other.Active;
        }

       /* public override int GetHashCode()
        {
            const int PRIME = 31;
            int result = 1;
            result = PRIME * result + (Id != null ? Id.GetHashCode() : 13);
            result = PRIME * result + (EncryptedApiKey != null ? EncryptedApiKey.GetHashCode() : 13);
            result = PRIME * result + (CreatedTime != null ? CreatedTime.GetHashCode() : 13);
            result = PRIME * result + (Description != null ? Description.GetHashCode() : 13);
            result = PRIME * result + (Active ? Active.GetHashCode() : 13);
            HashCode.Combine()

            return result ;
        }*/

        public override string? ToString()
        {
            return $"ApiKeyDTO [Id = {Id}, EncryptedApiKey = {EncryptedApiKey}, CreatedTime = {CreatedTime}, Description = {Description}, Active = {Active}]";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, EncryptedApiKey, CreatedTime, Description, Active);
        }
    }
}
