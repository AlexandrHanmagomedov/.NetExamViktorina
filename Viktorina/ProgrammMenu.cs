using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Viktorina {
        internal class ProgramMenu {

        public static string curUserLogin;
        public static string curUserPassword;
        public static void start ( ) {

                string[] items = { "Ввести логин и пароль", "Зарегистрироваться", "Выход\n" };

                method[] methods = new method[] { Method1, Method2, Exit };
                ConsoleMenu menu = new ConsoleMenu ( items );
                int menuResult;
                do {
                    menuResult = menu.PrintMenu ( );
                    methods[menuResult] ( );
                    Console.WriteLine ( "\nДля продолжения нажмите любую клавишу" );
                    Console.ReadKey ( );
                }
                while ( menuResult != items.Length - 1 );
            }
            static void Method1 ( ) {

                displayLoginScreen ( );
            if ( User.validateUserRepeat(curUserLogin,curUserPassword)==true ){
                displayMenuScreen ( );
            }
            }

            static void Method2 ( ) {
                displayNewUserRegistrationScreen ( );
            }        

            static void Exit ( ) {
                Console.WriteLine ( "Пока!" );
            }

        public static void displayMenuScreen ( ) {
            int key = 0;
            while ( true ) {
                Console.Clear ( );
                Console.WriteLine ( "\n\n\t1.Пройти викторину.\n\t2. Сменить дату рождения.\n\t3.Сменить пароль.\n\t4. Утилита для вопросов.\n\t5.Выход" );
                key = Convert.ToInt32 ( Console.ReadLine ( ) );
                switch ( key ) {
                    case 1:
                        Console.WriteLine ( "Пройти викторину" );
                        Questions questions = new Questions ( curUserLogin );
                        questions.QuestionMenu ( );
                        break;
                    case 2:
                        Console.WriteLine ( "Сменить дату рождения" );
                        EditUserDate ( );
                        break;
                    case 3:
                        
                        Console.WriteLine ( "Сменить пароль" );
                        EditUserPassword ( );
                        break;
                    case 4:
                        Console.WriteLine ( "Утилита для вопросов" );
                        var p = new Process ( );
                        string path = Directory.GetCurrentDirectory ( );
                        p.StartInfo.FileName = Path ( );
                        p.Start ( );
                        break;
                }
                if ( key == 5 )
                    break;
            }
        }
        public static void displayLoginScreen ( ) {
            Console.WriteLine ( "Введите логин:\t" );
            string userLogin = Console.ReadLine ( );
            Console.WriteLine ( "\nВведите пароль:\t" );
            string userPassword = Console.ReadLine ( );

            if ( User.validateUserRepeat ( userLogin, userPassword ) ) {
                Console.WriteLine ( "\nУспешный вход \n" );
                curUserLogin = userLogin;
                curUserPassword=userPassword;
            }
            else {
                Console.WriteLine ( "\n Неправильный логин или пароль\n" );
            }
        }        
        internal static string Path ( ) {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent ( workingDirectory ).Parent.FullName;
            string util = @"\UtilityforViktorina\bin\Debug\UtilityforViktorina.exe";
            return ( projectDirectory + util );
        }
        public static void displayNewUserRegistrationScreen ( ) {
        bool isCorrectInput = true;
        string userName = "";
        string userPassword = "";
        string userDate = "";
        do {
            Console.WriteLine ( isCorrectInput ? "\nВведите логин :\t" : 
                                                    "\nОшибка, попробуйте еще раз \n\n" );
            userName = Console.ReadLine ( );
            isCorrectInput = false;
        } while ( !User.validateUserLogin ( userName ) );

        isCorrectInput = true;
        do {
            Console.WriteLine ( isCorrectInput ? "  \nВведите пароль:\t" :
                                                    "\n Ошибка, попробуйте еще раз\n\n" );
            userPassword = Console.ReadLine ( );
            isCorrectInput = false;
        } while ( !User.validateUserPassword ( userPassword ) );
        isCorrectInput = true;

        Console.Write ( "Введите дату рождения\n" );
        userDate = Console.ReadLine ( );
        User newUser = new User ( userName, userPassword, userDate );
        }
        public static void EditUserPassword ( ) {
            Console.WriteLine ( "Изменить пароль\nВведите новый пароль : " );
            string [] lines=File.ReadAllLines(User.userListPath);
            for ( int i = 0; i < lines.Length; i++ ) {
                string[] userData = lines[i].Split (' ');
                if ( userData[0] == curUserLogin ) {
                    userData[1] = Console.ReadLine ( );
                 lines[i] = string.Join ( " ", userData );
                }
            }
            File.WriteAllLines(User.userListPath, lines );
        }
        public static void EditUserDate ( ) {
            Console.WriteLine ( "Изменить дату рождения \nВведите новую дату : " );
            string[] lines = File.ReadAllLines ( User.userListPath );
            for ( int i = 0; i < lines.Length; i++ ) {
                string[] userData = lines[i].Split ( ' ' );
                if ( userData[0] == curUserLogin ) {
                    userData[2] = Console.ReadLine ( );
                    lines[i] = string.Join ( " ", userData );
                }
            }
            File.WriteAllLines ( User.userListPath, lines );
        }
    }
}
