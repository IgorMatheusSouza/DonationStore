using DonationStore.Enums.DomainEnums;

namespace DonationStore.Enums.EnumServices
{
    public static class DonationEnumService
    {
        public static DonationEnum[] GetOpenDonationStatus() => new DonationEnum[] { DonationEnum.Active, DonationEnum.InProgress };
    }
}
