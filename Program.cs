using System.Text.RegularExpressions;

class PasswordManager {
    private static Regex rxUpper = new Regex(@"[A-Z]+");
    private static Regex rxLower = new Regex(@"[a-z]+");
    private static Regex rxNumeric = new Regex(@"[0-9]+");
    private static Regex rxSpecial = new Regex(@"[!@#$%^&*_+=-]+");
    private static Regex rxWhitespace = new Regex(@"[ ]+");

    static void PrintWelcome() {
        char input;
        bool createMas = false;
        string temp;
        Console.WriteLine("\nWelcome to command-line Password Manager");
        Console.WriteLine("****************************************");
        Console.WriteLine("Enter your selection below");
        Console.WriteLine("[1] Create Master Password");
        Console.WriteLine("[2] Enter Master Password");

        while (true) {
            try {
                Console.Write("Selection: ");
                temp = Console.ReadLine();
                if (temp.Length != 1) {
                    throw new Exception();
                }
                input = temp[0];
                switch (input) {
                    case '1':
                        createMas = true;
                        break;
                    case '2':
                        createMas = false;
                        break;
                    default:
                        throw new Exception();
                }
                break;
            } catch (Exception) {
                Console.WriteLine("Invalid Input. Try Again.");
            }
        }
        if (createMas) {
            CreateMaster();
        } else EnterMaster();
    }

    static void CreateMaster() {
        string mpasswd;
        Console.WriteLine("\n****************************************");
        Console.WriteLine("Create A New Master Password");
        while (true) {
            Console.WriteLine("Must contain at least:  1 Uppercase Letter, 1 Lowercase Letter,");
            Console.WriteLine("\t\t\t1 Numeric Character, 1 Special Character,");
            Console.WriteLine("\t\t\tand 8-15 characters in length");
            Console.WriteLine();
            Console.WriteLine("NOTE: This password will not be saved. Please keep it somewhere safe.");
            Console.Write("Enter your new Master Password: ");
            mpasswd = Console.ReadLine();
            if (!ValidMaster(mpasswd)) {
                Console.WriteLine("\nERROR: Invalid Master Password");
                continue;
            } else break;
        }

    }

    static void EnterMaster() {
        Console.WriteLine("TODO");
    }

    static bool ValidMaster(string master) {
        return (ValidLength(master) &&
                ValidUppercase(master) &&
                ValidLowercase(master) &&
                ValidNumeric(master) &&
                ValidSpecial(master) &&
                ValidWhitespace(master)
                );
    }

    static bool ValidLength(string master) {
        Console.WriteLine($"Length: {(master.Length >= 8 && master.Length <= 15)}");
        return (master.Length >= 8 && master.Length <= 15);
    }

    static bool ValidUppercase(string master) {
        Console.WriteLine($"Upper: {rxUpper.Match(master).Success}");
        return rxUpper.Match(master).Success;
    }

    static bool ValidLowercase(string master) {
        Console.WriteLine($"Lower: {rxLower.Match(master).Success}");
        return rxLower.Match(master).Success;
    }

    static bool ValidNumeric(string master) {
        Console.WriteLine($"Numeric: {rxNumeric.Match(master).Success}");
        return rxNumeric.Match(master).Success;
    }

    static bool ValidSpecial(string master) {
        Console.WriteLine($"Special: {rxSpecial.Match(master).Success}");
        return rxSpecial.Match(master).Success;
    }

    static bool ValidWhitespace(string master) {
        Console.WriteLine($"Whitespace: {!rxWhitespace.Match(master).Success}");
        return !rxWhitespace.Match(master).Success;
    }

    static public void Main() {
        PrintWelcome();
    }

}
