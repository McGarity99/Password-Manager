#require 'tty'
require 'tty-box'
require 'sqlite3'

WELCOME_MSG = [
    "\nWelcome to command-line Password Manager",
    "******************************************",
    "Enter your selection below",
    "[1] Create Master Password",
    "[2] Enter Master Password",
    "[3] Exit",
]

CREATE_MASTER_MSG = [
    "Must contain at least:  1 uppercase letter, 1 lowercase letter,",
    "\t\t\t1 Numeric character, 1 Special character,",
    "\t\t\tand 8-15 characters in length",
    "\n",
    "NOTE: This password will NOT be saved. Please keep it somewhere safe.",
    "Enter your new Master Password: ",
]

REGEX_HASH = {
    "rxUpper" => /[A-Z]+/,
    "rxLower" => /[a-z]+/,
    "rxNumeric" => /[0-9]+/,
    "rxSpecial" => /[!@#$%^&*_+=-]+/,
    "rxWhitespace" => /^\S*$/,
}

$failed_strings = {}
REGEX_HASH.each_key {|k|
    $failed_strings[k] = k.gsub("rx", "")
}

$exit = false

def print_welcome()
    WELCOME_MSG.each {|line|
    puts(line)
    }
    box = TTY::Box.frame "Drawing a box in", "terminal emulator", padding: 3, align: :center
        print(box)
    create_master = false
    loop {
        begin
            puts("Selection: ")
            input = gets.chomp
            if input.length() != 1
                raise $!
            end
            selection = input[0]
            case selection
            when '1'
                create_master = true
                break
            when '2'
                break
            when '3'
                $exit = true
                break
            else
                raise $!
            end
        rescue Exception
            puts("Invlid Input. Try Again.")
        end
    }
    abort unless !$exit
    if create_master
        create_master_pass()
    else
        enter_master_pass()
    end
end

def create_master_pass()
    puts("\n**********************************")
    puts("Create a New Master Password")
    loop {
        CREATE_MASTER_MSG.each {|line|
            puts(line)
        }
        mpasswd = gets.chomp
        if !valid_master(mpasswd)
            puts("\nERROR: Invalid Master Password")
            next
        end
        puts("Master Password Validated")
        break
    }
end

def valid_master(master)
    failed_exps = []
    if master.length() < 8 || master.length() > 15
        failed_exps << "Invalid Length"
    end
    REGEX_HASH.each {|name, regex| 
        if (master =~ regex).nil?
            failed_exps << "Invalid #{$failed_strings[name]}"
        end
    }
    failed_exps.each {|fail|
        puts("FAILED: #{fail}")
    }
    return failed_exps.length() == 0
end

def enter_master_pass()
    puts("TODO")
end


# Main Below
print_welcome()