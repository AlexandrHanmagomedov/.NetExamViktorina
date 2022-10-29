using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Viktorina 
    {
    internal class Questions {

        string curUserLogin;
        public int CorectAnswers;
        public int IncorectAnswers;    
        public string[] AnsData { get; set; }
        
        internal List<string> Categories = new List<string> { "История", "Биология", "География", "Космос" };
        public Questions (string curUserLogin ) { 
            this.curUserLogin = curUserLogin;
        }
        internal void QuestionMenu ( ) {
                int MenuKey;
                while ( true ) {
                    Console.Clear ( );
                    Console.WriteLine ( $"\n\tПривет {curUserLogin} " );
                    Console.WriteLine ( "\t\t" +
                        "\n\tВИКТОРИНА\n\n " +
                        "\t1. Начать новую викторину.\n " +
                        "\t2. Просмотреть результаты прошлых игр.\n" +
                        "\t3. Выход." );

                    MenuKey = Convert.ToInt32 ( Console.ReadLine ( ) );

                    switch ( MenuKey ) {
                        case 1:
                            Console.Clear ( );
                            Console.WriteLine ( "\t\tВЫБЕРИТЕ КАТЕГОРИЮ!" );
                            Console.WriteLine ( " 1. История        " );
                            Console.WriteLine ( " 2. Биология       " );
                            Console.WriteLine ( " 3. География      " );
                            Console.WriteLine ( " 4. Космос         " );
                            Console.WriteLine ( " 5. Случайная тема " );
                            Console.WriteLine ( " 6. Созданная викторина" );
                        try {
                            MenuKey = Convert.ToInt32 ( Console.ReadLine ( ) );
                            Question ( MenuKey );
                        }
                        catch ( Exception ) {

                            Console.WriteLine ( "Неправильный ввод\n" );
                        }

                        Console.WriteLine ( " Сыграть Викторину еще раз?\n " +
                                "1. Да\n " +
                                "2. Нет" );

                            MenuKey = Convert.ToInt32 ( Console.ReadLine ( ) );
                            if ( MenuKey == 1 )
                                QuestionMenu ( );
                            if ( MenuKey == 2 ) {
                                Console.Clear ( );
                                break;
                            }
                            break;

                        case 2:
                            Console.Clear ( );
                            Console.WriteLine ( "\tРЕЗУЛЬТАТЫ ПРОШЛЫХ ВИКТОРИН!" );
                            Console.WriteLine ( "Логин\t  Верно\t    Неверно   Тема" );
                            Statistic ( 0, false );
                            Console.ReadKey ( );
                            Console.Clear ( );
                            break;
                        case 3:

                            break;
                    }
                    if ( MenuKey == 3 )
                        break;
                }
           
        }
    internal void Question ( int choise ) {
            Console.Clear ( );
            switch ( choise ) {
                case 1:
                    for ( int i = 0; i < 10; i++ ) {
                        ReadingData ( choise, true, i );           
                        Console.WriteLine ( "\nВарианты ответа! " );
                        ReadingData ( choise, false, i );          
                        AnswersReading ( );                       
                    }
                    Console.WriteLine ( " Викторина завершена!" );
                    Console.ReadKey ( );
                    Statistic ( choise, true );                   
                    break;
                case 2:
                    for ( int i = 0; i < 10; i++ ) {
                        ReadingData ( choise, true, i );
                        Console.WriteLine ("\nВарианты ответа! ");
                        ReadingData ( choise, false, i );
                        AnswersReading ( );
                    }
                    Console.WriteLine ( " Викторина завершена!" );
                    Console.ReadKey ( );
                    Statistic ( choise, true );
                    break;
                case 3:
                    for ( int i = 0; i < 10; i++ ) {
                        ReadingData ( choise, true, i );
                        Console.WriteLine ( "\nВаринаты ответа! " );
                        ReadingData ( choise, false, i );
                        AnswersReading ( );
                    }
                    Console.WriteLine ( " Викторина завершена!" );
                    Console.ReadKey ( );
                    Statistic ( choise, true );
                    break;
                case 4:
                    for ( int i = 0; i < 10; i++ ) {
                        ReadingData ( choise, true, i );
                        Console.WriteLine ( "\nВарианты ответа! " );
                        ReadingData ( choise, false, i );
                        AnswersReading ( );
                    }
                    Console.WriteLine ( " Викторина завершена!" );
                    Console.ReadKey ( );
                    Statistic ( choise, true );
                    break;
                case 5:
                    for ( int i = 0; i < 10; i++ ) {
                        ReadingData ( choise, true, i );
                        Console.WriteLine ( "\nВаринаты ответа! " );
                        ReadingData ( choise, false, i );
                        AnswersReading ( );
                    }
                    Console.WriteLine ( " Викторина завершена!" );
                    Console.ReadKey ( );
                    Statistic ( choise, true );
                    break;
                case 6:
                    for (int i = 0; i < 10; i++)
                    {
                        ReadingData(choise, true, i);
                        Console.WriteLine("\nВаринаты ответа! ");
                        ReadingData(choise, false, i);
                        AnswersReading();
                    }
                    Console.WriteLine(" Викторина завершена!");
                    Console.ReadKey();
                    Statistic(choise, true);
                    break;
            }
        }

        internal void ReadingData ( int Qdir, bool ANSdir, int index ) {
            try            {
                if (ANSdir == true)                {
                    using (StreamReader sr = new StreamReader(Pathes(Qdir, ANSdir),
                        Encoding.Default))                    {
                        string line;
                        while ((line = sr.ReadLine()) != null){
                            line = File.ReadLines(Pathes(Qdir, ANSdir)).ElementAt(index);
                            Console.WriteLine(line);
                            break;
                        }
                    }
                }
                else if (ANSdir == false)                {
                    using (StreamReader sr = new StreamReader(Pathes(Qdir, ANSdir), Encoding.Default)){
                        string line;
                        while ((line = sr.ReadLine()) != null){
                            line = File.ReadLines(Pathes(Qdir, ANSdir)).ElementAt(index);
                            AnsData = line.Split(' ');
                            break;
                        }
                    }
                }
            }
            catch (Exception e){
                Console.WriteLine(e.Message);
            }
        }

        internal string Pathes ( int Qdir, bool ANSdir ) {
            string workingDirectory = Environment.CurrentDirectory;                         
            string projectDirectory = Directory.GetParent ( workingDirectory ).Parent.FullName;

            var RndCategory = new string[]{
                @"Files\History.txt",
                @"Files\Biology.txt",
                @"Files\Geography.txt",
                @"Files\Space.txt"
            };
            var RndCategoryAns = new string[]{
                @"Files\HistoryAnswers.txt",
                @"Files\BiologyAnswers.txt",
                @"Files\GeographyAnswers.txt",
                @"Files\SpaceAnswers.txt"
            };
            Random RandomCategory = new Random ( );

            if ( Qdir == 1 && ANSdir == true ) {
                return Path.Combine ( projectDirectory, @"Files\History.txt" ); 
            }
            if ( Qdir == 2 && ANSdir == true ) { 
                return Path.Combine ( projectDirectory, @"Files\Biology.txt" ); 
            }
            if ( Qdir == 3 && ANSdir == true ) { 
                return Path.Combine ( projectDirectory, @"Files\Geography.txt" ); 
            }
            if ( Qdir == 4 && ANSdir == true ) {
                return Path.Combine ( projectDirectory, @"Files\Space.txt" ); 
            }
            if ( Qdir == 5 && ANSdir == true ) { 
                return Path.Combine ( projectDirectory, RndCategory[RandomCategory.Next ( 0, 4 )] ); 
            }

            if ( Qdir == 1 && ANSdir == false ) { 
                return Path.Combine ( projectDirectory, @"Files\HistoryAnswers.txt" ); 
            }
            if ( Qdir == 2 && ANSdir == false ) {
                return Path.Combine ( projectDirectory, @"Files\BiologyAnswers.txt" ); 
            }
            if ( Qdir == 3 && ANSdir == false ) { 
                return Path.Combine ( projectDirectory, @"Files\GeographyAnswers.txt" ); 
            }
            if ( Qdir == 4 && ANSdir == false ) { 
                return Path.Combine ( projectDirectory, @"Files\SpaceAnswers.txt" ); 
            }
            if ( Qdir == 5 && ANSdir == false ) { 
                return Path.Combine ( projectDirectory, RndCategoryAns[RandomCategory.Next ( 0, 4 )] ); 
            }
            if ( Qdir == 6 && ANSdir == false ) { 
                return Path.Combine ( projectDirectory, @"Files\Rate.txt" ); 
            }

            return @"НЕ ВЕРНЫЙ ВВОД";
        }
        internal void AnswersReading ( ) {
            int tmp = 1;
            int AnsCheck = int.Parse ( AnsData[4] );
            foreach ( var i in AnsData ){
                Console.WriteLine ( $"{tmp}. {i}" );
                tmp++;
                if ( tmp == 5 ) break;
            }
            Console.WriteLine ( "\nВаш ответ? " );
            int ans = int.Parse ( Console.ReadLine ( ) );                                        
            if ( ans == AnsCheck ) {
                Console.WriteLine ( "Правильный ответ! ");
                CorectAnswers++;                                                            
                Console.ReadKey ( );
                Console.Clear ( );
            }
            else {                                                                               
                Console.WriteLine ( "Не правильный ответ! ");
                IncorectAnswers++;                                                          
                Console.ReadKey ( );
                Console.Clear ( );
            }
        }
        internal void Statistic ( int choise, bool WR ) {
            string[] read;
            try {
                if ( WR == true ) {
                    using ( StreamWriter sw = new StreamWriter ( Pathes ( 6, false ), true ) ) {
                        sw.WriteLine ( $"{curUserLogin,-10}{CorectAnswers,-10}{IncorectAnswers,-10}{Categories[choise - 1],-10}" );
                    }
                }
                if ( WR == false ) {
                    read = File.ReadAllLines ( Pathes ( 6, false ) );
                    foreach ( string line in read ) {
                        Console.WriteLine ( line );
                    }
                    Console.ReadKey ( );
                }
            }
            catch ( Exception e ) {
                Console.WriteLine ( e.Message );
            }
        }
    }
}

    
