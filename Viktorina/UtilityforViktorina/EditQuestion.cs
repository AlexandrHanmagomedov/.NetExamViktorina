using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UtilityforViktorina
{
    public class Task
    {
        public string Id { get; set; }
        public string Question { get; set; }
        public string CorrectAnswer { get; set; }
        public string Name = "NewViktorina";

        public Task(){}
        public Task(string _Id, string _Question, string _CorrectAnswer)
        {
            Id = _Id;
            Question = _Question;
            CorrectAnswer = _CorrectAnswer;
        }

        public void AddViktorina(){
            try{
                var listTask = from word in XDocument.Load(Path.Combine(Environment.CurrentDirectory,
                    this.Name + ".xml")).Descendants("Viktorina")
                               select new Task{
                                   Id = word.Element("Id").Value.ToString(),
                                   Question = word.Element("Question").Value.ToString(),
                                   CorrectAnswer = word.Element("CorrectAnswer").Value.ToString()
                               };
                int flag = 0;
                foreach (var item in listTask){
                    if (Id == item.Id){
                        flag = 1;
                    }
                }
                if (flag != 1){
                    var xmlDoc = XDocument.Load(Path.Combine(Environment.CurrentDirectory, this.Name + ".xml"));
                    xmlDoc.Element("Viktorina").Add(new XElement(("Viktorina"),
                                     new XElement("Id", this.Id),
                                   new XElement("Question", this.Question),
                                  new XElement("CorrectAnswer", this.CorrectAnswer)));
                    xmlDoc.Save(Path.Combine(Environment.CurrentDirectory, this.Name + ".xml"));
                }
                else{
                    Console.WriteLine($"Викторина {this.Id} уже существует и не может быть добавлена");
                    Console.WriteLine();
                }
            }
            catch (Exception exp){
               var xmlDoc = new XDocument(new XDeclaration("1.0", "utf=16", "yes"),
               new XElement("Viktorina"));                               
               xmlDoc.Root.Add(new XElement("Id", this.Id),
                               new XElement("Question", this.Question),
                               new XElement("CorrectAnswer", this.CorrectAnswer));
                xmlDoc.Save(Path.Combine(Environment.CurrentDirectory, this.Name + ".xml"));
            }
        }
        public void PrintQuestion(){
            var listTask = from word in XDocument.Load(Path.Combine(Environment.CurrentDirectory, this.Name + ".xml")).Descendants("Viktorina")
                           select new Task                           {
                               Id = word.Element("Id").Value.ToString(),
                               Question = word.Element("Question").Value.ToString(),
                               CorrectAnswer = word.Element("CorrectAnswer").Value.ToString()
                           };
            foreach (var item in listTask)            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
        }
        public void DeleteQuestion(string _Id)        {
            try{
                var xmlDoc = XDocument.Load(Path.Combine(Environment.CurrentDirectory, this.Name + ".xml"));

                xmlDoc.Element("Viktorina").Elements("Viktorina").Where(x => x.Element("Id").Value == _Id).FirstOrDefault().Remove();
                xmlDoc.Save(Path.Combine(Environment.CurrentDirectory, this.Name + ".xml"));
                Console.WriteLine($"Викторина  {_Id} была удалена");
                Console.WriteLine();
            }
            catch (Exception exp){
                Console.WriteLine($"{exp}\nВикторина с таким именем отсутствует и не может быть удалена" +
                    $"\nдля продолжения нажмите enter");
                Console.WriteLine();
            }
        }
        public override string ToString(){
            return $"Раздел {Id}\nВопрос:{Question} ";
        }
    }
}
