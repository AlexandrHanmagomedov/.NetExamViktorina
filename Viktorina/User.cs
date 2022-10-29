using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Viktorina {
    internal class User {
        public string login;
        private string password;
        private string date;

        public static string userListPath = string.Format ( "{0}\\{1}", Directory.GetCurrentDirectory ( ), "UserList.txt" );
        public User ( string login, string password,string date ) {
            if ( !validateUserLogin ( login ) ) {
                throw new ArgumentException ( "Логин должен быть больше 3х символов" );
            }
            if ( !validateUserPassword ( password ) ) {
                throw new ArgumentException ( "Пароль должен быть больше 4х символов" );
            }
            this.login = login;
            this.password = password;
            this.date = date;
            createNewUser ( );
        }
        public string getLogin ( ) {
            return login;
        }
        public void setLogin ( string login ) {
            if ( !validateUserLogin ( login ) ) {
                throw new ArgumentException ("Логин должен быть больше 3х символов");
            }
            this.login = login;
        }
        public String getPassword ( string password ) {
            return password;
        }
        public void setPassword ( string password ) {
            if ( !validateUserPassword ( password ) ) {
                throw new ArgumentException ("Пароль должен быть больше 4х символов");
            }
            this.password = password;
        }
        public string getDate ( ) {
            return date;
        }
        public void setDate ( string date) {
            this.date = date;
        }
        private void createNewUser ( ) {
            if ( !File.Exists ( userListPath ) ) {
                try {
                    using ( FileStream fs = File.Create ( userListPath ) ) ;
                }
                catch ( Exception ex ) {
                    Console.WriteLine ( ex.ToString ( ) );
                }
            }
            try {
                using StreamWriter file = new ( userListPath, append: true );
                file.WriteLine ( this.ToString ( ) );
            }
            catch ( FileNotFoundException fnfe ) {
                Console.WriteLine ( fnfe.ToString ( ) );
            }
        }
        public static bool validateUserLogin ( string login ) {
            Regex regex = new Regex ( @"^[\w+]{3,}$" );
            return regex.IsMatch ( login ) && isLoginUnique ( login );
        }
        private static bool isLoginUnique ( string login ) {
            if ( File.Exists ( userListPath ) ) {
                string[] lines = File.ReadAllLines ( userListPath );
                for ( int i = 0; i < lines.Length; i++ ) {
                    string[] userData = lines[i].Split ( ' ' );
                    if ( userData[0].Equals ( login ) ) {
                        Console.WriteLine ( "\n Логин уже занят \n" );
                        return false;
                    }
                }
            }
            return true;
        }
        public static bool validateUserPassword ( string password ) {
            Regex regex = new Regex ( @"^[\w+]{4,}$" );
            return regex.IsMatch ( password );
        }
        public static bool validateUserRepeat ( string userName, string userPassword ) {
            string[] lines = File.ReadAllLines ( userListPath );
            for ( int i = 0; i < lines.Length; i++ ) {
                string[] userData = lines[i].Split ( ' ' );
                if ( userData[0].Equals ( userName ) && userData[1].Equals ( userPassword ) ) {
                    Console.WriteLine("Logged successfully");
                    return true;
                }
            }
            return false;
        }
        public override string ToString ( ) {
            return string.Format ( "{0} {1} {2}", login, password,date );
        }
    }   
}


