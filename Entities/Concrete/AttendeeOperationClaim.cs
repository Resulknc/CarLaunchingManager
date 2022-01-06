using Core.Entities;

namespace Entities
{
    public class AttendeeOperationClaim:IEntity
    {
        public int Id { get; set; }
        public int AttendeeId { get; set; }
        public int OperationClaimId { get; set; }
    }
}
