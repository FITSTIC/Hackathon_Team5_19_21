namespace Hackathon_Team5_19_21.Pages.Login
{
    class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string NuovaPassword { get; set; }
        public string RipetiPassword { get; set; }
        public bool ControllaNuovaPassword()
        {
            if (NuovaPassword == null) return false;
            int maiuscole = 0;
            int minuscole = 0;
            int numeri = 0;
            int carSpeciali = 0;
            foreach (char c in NuovaPassword)
            {
                if (char.IsLetter(c) && char.IsUpper(c)) maiuscole++;
                if (char.IsLetter(c) && char.IsLower(c)) minuscole++;
                if (char.IsNumber(c)) numeri++;
                if (char.IsPunctuation(c)) carSpeciali++;
            }
            return NuovaPassword.Length >= 8 && maiuscole >= 1 && minuscole >= 1 && numeri >= 1 && carSpeciali >= 1;
        }
    }
}
