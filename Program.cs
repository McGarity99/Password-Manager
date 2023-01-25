using System.Text.RegularExpressions;

class PasswordManager {
    private static Regex rxValidator = new Regex("^[A-Za-z0-9]{8,}$");

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
            } catch (Exception e) {
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
        Console.Write("Must contain at least: 1 Uppercase Letter, 1 Lowercase Letter, 1 Numeric Character, ");
        Console.WriteLine(" 1 Special Character, and 8 total characters with no whitespace");
        Console.WriteLine();
        Console.WriteLine("NOTE: This password will not be saved. Please keep it somewhere safe.");
        Console.Write("Enter your new Master Password: ");
        mpasswd = Console.ReadLine();
        Console.WriteLine($"Valid: {ValidMaster(mpasswd)}");

    }

    static void EnterMaster() {

    }

    static bool ValidMaster(string master) {
        return rxValidator.Match(master).Success;
    }

    static bool ValidUppercase(string master) {
        return false;
    }

    static bool ValidLowercase(string master) {
        return false;
    }

    static bool ValidNumeric(string master) {
        return false;
    }

    static bool ValidSpecial(string master) {
        return false;
    }

    static bool ValidWhitespace(string master) {
        return false;
    }

    static public void Main() {
        PrintWelcome();
    }

}
