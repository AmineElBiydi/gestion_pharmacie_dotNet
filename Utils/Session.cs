using GestionPharmacie.Models;

namespace GestionPharmacie.Utils
{
    public static class Session
    {
        public static User? CurrentUser { get; private set; }
        
        public static bool IsAuthenticated => CurrentUser != null;
        
        public static void Login(User user)
        {
            CurrentUser = user;
        }
        
        public static void Logout()
        {
            CurrentUser = null;
        }
    }
}
