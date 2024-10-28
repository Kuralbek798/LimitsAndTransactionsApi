using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LimitsAndTransactionsApi.Models.Entity
{
    [Table("api_key")]
    public class ApiKey
    {
        public Guid Id { get; set; }

        [Column("encrypted_api_path")]
        [Required]
        public string EncryptedApiKey { get; set; }
        [Column("created_time")]
        [Required]
        public DateTimeOffset CreatedTime { get; set; }
        [Column("description")]
        [Required]
        public string Description { get; set; }
        [Column("active")]
        [Required]
        public bool Active { get; set; } = true;

        public ApiKey(Guid id, string encryptedApiPath, DateTimeOffset createdTime, string description, bool active)
        {
            Id = id;
            EncryptedApiKey = encryptedApiPath;
            CreatedTime = createdTime;
            Description = description;
            Active = active;
        }
        public ApiKey()
        {
            Id = Guid.NewGuid();
        }

        public override string ToString()
        {
            return $"ApiKey [Id={Id}, EncryptedApiKey {EncryptedApiKey}, CreatedTime={CreatedTime}, Description={Description}, Activ={Active}]";
        }
    }
}
