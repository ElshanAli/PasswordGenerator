namespace PasswordGenerator
{
    class PasswordGenerator
    {
        private int passwordLength;
        private bool useNumbers;
        private bool useLetters;

        public void SetPasswordLength(int length)
        {
            passwordLength = length;
        }

        public int GetPasswordLength()
        {
            return passwordLength;
        }

        public void SetUseNumbers(bool use)
        {
            useNumbers = use;
        }

        public bool GetUseNumbers()
        {
            return useNumbers;
        }

        public void SetUseLetters(bool use)
        {
            useLetters = use;
        }

        public bool GetUseLetters()
        {
            return useLetters;
        }

        private string GeneratePassword()
        {
            string password = "";
            Random random = new Random();

            for (int i = 0; i < passwordLength; i++)
            {
                if (useNumbers && useLetters)
                {
                    if (random.Next(2) == 0)
                    {
                        password += (char)random.Next('0', '9' + 1);
                    }
                    else
                    {
                        password += (char)random.Next('a', 'z' + 1);
                    }
                }
                else if (useNumbers)
                {
                    password += (char)random.Next('0', '9' + 1);
                }
                else if (useLetters)
                {
                    password += (char)random.Next('a', 'z' + 1);
                }
            }

            return password;
        }

        public string GetPassword()
        {
            return GeneratePassword();
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            PasswordGenerator passwordGenerator = new PasswordGenerator();

            Console.Write("Enter the length of the password: ");
            int length = int.Parse(Console.ReadLine());
            passwordGenerator.SetPasswordLength(length);

            Console.Write("Use numbers? (y/n): ");
            char useNumbersChar = Console.ReadLine()[0];
            bool useNumbers = useNumbersChar == 'y' || useNumbersChar == 'Y';
            passwordGenerator.SetUseNumbers(useNumbers);

            Console.Write("Use letters? (y/n): ");
            char useLettersChar = Console.ReadLine()[0];
            bool useLetters = useLettersChar == 'y' || useLettersChar == 'Y';
            passwordGenerator.SetUseLetters(useLetters);

            Console.WriteLine("Password: " + passwordGenerator.GetPassword());
        }
    }


}