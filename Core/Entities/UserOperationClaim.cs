using Core.DataAccess;

namespace Core.Entities
{
    public class UserOperationClaim : BaseEntity
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }

         
    }
}
