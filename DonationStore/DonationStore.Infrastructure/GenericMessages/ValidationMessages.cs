namespace DonationStore.Infrastructure.GenericMessages
{
    public static class ValidationMessages
    {
        public static readonly string EmptyFields = $@"Necessário preencher todos os campos";

        public static string MaxLengthError(int size) => $@"O tamanho máximo para cada campo é {size}";
    }
}
