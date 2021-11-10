using System;
using System.Collections.Generic;
using System.Text;

namespace DonationStore.Infrastructure.GenericMessages
{
    public static class ErrorMessages
    {
        public static readonly string GenericError = $@"Opsss... se você está lendo isso é porque deu ruim no servidor :/ Mas em breve vamos resolver :)";
        public static readonly string LoginError = $@"Não foi possível fazer login, verifique o email e senha";
        public static readonly string AuthError = $@"Você não tem permissão para realizar essa ação, faça login novamente";
    }
}
