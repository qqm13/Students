using System.Net.Http.Json;
using ConsoleStudents.DTO;
namespace ConsoleStudents
{
    internal class Program
    {
        public static HttpClient httpClient = new HttpClient();
        static void Main()
        {
            httpClient.BaseAddress = new Uri("http://localhost:5175/api/");
            Console.WriteLine("Выберите операцию");
            Console.WriteLine("1. Получить список студентов из группы по указанному индексу группы");
            Console.WriteLine("2. Получить информацию о кол-ве мальчиков и девочек в группе по указанному индексу группы");
            Console.WriteLine("3. Получить список студентов, которые не привязаны ни к одной группе");
            Console.WriteLine("4. Получить список групп, в которых нет студентов");
            Console.WriteLine("5. Получить общую статистику по отделению - список групп с указанием кол-ва студентов в каждой группе");
            Console.WriteLine("6. Такая же задача, как п.5, но с указанием индекса конкретной специальности");
            Console.WriteLine("7. Добавление новой группы для указанной специальности");
            Console.WriteLine("8. Перевод указанного студента в указанную группу");
            Console.WriteLine("9. Добавить метод, который возвратит дублирующегося студента (один и тот же человек в двух разных группах)");
            int.TryParse(Console.ReadLine(), out int operation);
            switch (operation)
            {
                default:
                    Console.WriteLine("Неверная операция, введите номер операции");
                    break;
                case 1:
                    First();
                    Console.ReadLine();
                    break;
                case 2:
                    Second();
                    Console.ReadLine();
                    break;
                case 3:
                    Third();
                    Console.ReadLine();
                    break;
                case 4:
                    Fourth();
                    Console.ReadLine();
                    break;
                case 5:
                    Fifth();
                    Console.ReadLine();
                    break;
                case 6:
                    Six();
                    Console.ReadLine();
                    break;
                case 7:
                    Seven();
                    Console.ReadLine();
                    break;
                case 8:
                    Eight();
                    Console.ReadLine();
                    break;
                case 9:
                    Nine();
                    Console.ReadLine();
                    break;

            }


        }

        public async static void First()
        {
            Console.WriteLine("Введите индекс группы");
            int.TryParse(Console.ReadLine(), out int index);
            var data1 = await httpClient.GetFromJsonAsync<IEnumerable<StudentDTO>>($"Student/GetStudentsByGroup?index={index}");
            string result = "";
            foreach (StudentDTO studentDTO in data1)
            {
                result += studentDTO.FirstName;
                result += ' ';
                result += studentDTO.LastName;
                result += "\n";
            }
            Console.WriteLine(result);

        }
        public async static void Second()
        {
            Console.WriteLine("Введите индекс группы");
            int.TryParse(Console.ReadLine(), out int index);
            var data1 = await httpClient.GetFromJsonAsync<CountGenders>($"Student/GenderCount?index={index}");
            Console.WriteLine($"Количество девушек{data1.CountFemale}");
            Console.WriteLine($"Количество парней{data1.CountMale}");
            


        }

        public async static void Third()
        {

          
            var data1 = await httpClient.GetFromJsonAsync<IEnumerable<StudentDTO>>($"Student/GetStudentsByGroupnull");
            string result = "";
            foreach (StudentDTO studentDTO in data1)
            {
                result += studentDTO.FirstName;
                result += ' ';
                result += studentDTO.LastName;
                result += "\n";
            }
            Console.WriteLine(result);


        }
        public async static void Fourth()
        {

        }

        public async static void Fifth()
        {

        }
        public async static void Six()
        {

        }
        public async static void Seven()
        {

        }

        public async static void Eight()
        {

        }
        public async static void Nine()
        {

        }

    }
}
