using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityforViktorina {
    internal class Program
    {
        public void NewQuestion(string _Id, string _Question, string _CorrectAnswer){
            Task quest = new Task(_Id, _Question, _CorrectAnswer);
            quest.AddViktorina();
        }

        public void DeleteQuestion(string _Id){
            Task quest = new Task();
            quest.DeleteQuestion(_Id);
        }
        public void PrintQuestion(){
            Task quest = new Task();
            quest.PrintQuestion();
        }

        static void Main(string[] args){

            Program quest= new Program();

                int key = 0;

                while (key != 4){
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine($"\n\t1.Добавить викторину\n\t" +
                                        $"2.Удалить викторину\n\t" +
                                        $"3.Вывести список викторин\n\t" +
                                        $"4.Выход\n");
                    try{
                        key = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (Exception ex){
                        Console.WriteLine($"{ex}\nYажмите клавишу 1, 2, 3, 4 затем enter\nНажмите enter для продолжения");
                        Console.ReadKey();
                    }
                    switch (key){
                        case 1:
                            Console.WriteLine("Введите название новой викторины");
                            string _Id1 = Console.ReadLine();
                            Console.WriteLine("Введите вопрос ");
                            string _Question1 = Console.ReadLine();
                            Console.WriteLine("Введите правильный ответ");
                            string _CorrectAnswer1 = Console.ReadLine();
                            quest.NewQuestion(_Id1, _Question1, _CorrectAnswer1);
                            Console.WriteLine("Нажмите enter");
                            Console.ReadKey();
                            break;
                        case 2:
                            quest.PrintQuestion();
                            
                            Console.WriteLine("Введите название викторины , которое хотите удалить");
                            _Id1 = Console.ReadLine();
                            quest.DeleteQuestion(_Id1);
                            
                            Console.WriteLine("Нажмите enter");
                            Console.ReadKey();
                            break;

                        case 3:
                            quest.PrintQuestion();
                          
                            Console.WriteLine("Нажмите enter");
                            Console.ReadKey();
                            break;

                        default:
                            Console.WriteLine("Возврат в основную программу");
                            break;
                    }
                }
                Console.Read();
        }
    }
}
