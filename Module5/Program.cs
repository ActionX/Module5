
using System.Text;

class Program
{
    public static void Main(string[] args)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.GetEncoding(1251);

        var userData = GetUserInput();
        //ShowUserData(userData);

    }


    static (string Name, string Surname, int Age, bool HasPets) GetUserInput()
    {
        Console.Write("Введите имя: ");
        var firstName = Console.ReadLine();

        Console.Write("Введите фамилию: ");
        var lastName = Console.ReadLine();

        int age;
        while (true)
        {
            Console.Write("Введите возраст: ");
            if (int.TryParse(Console.ReadLine(), out age) && age > 0)
            {
                break;
            }
            Console.WriteLine("Некорректный ввод. Попробуйте ещё раз.");
        }

        bool hasPets;
        while (true)
        {
            Console.Write("Есть ли у вас питомец? (да/нет) ");
            var hasPetsStr = Console.ReadLine();
            if (hasPetsStr == "да")
            {
                hasPets = true;
                break;
            }
            else if (hasPetsStr == "нет")
            {
                hasPets = false;
                break;
            }
            Console.WriteLine("Некорректный ввод. Попробуйте ещё раз.");
        }

        //string[] petNames = null;
        //if (hasPets)
        //{
        //    int petCount;
        //    while (true)
        //    {
        //        Console.Write("Введите количество питомцев: ");
        //        if (int.TryParse(Console.ReadLine(), out petCount) && petCount > 0)
        //        {
        //            break;
        //        }
        //        Console.WriteLine("Некорректный ввод. Попробуйте ещё раз.");
        //    }

        //    petNames = GetPetNames(petCount);
        //}

        //int colorCount;
        //while (true)
        //{
        //    Console.Write("Введите количество любимых цветов: ");
        //    if (int.TryParse(Console.ReadLine(), out colorCount) && colorCount > 0)
        //    {
        //        break;
        //    }
        //    Console.WriteLine("Некорректный ввод. Попробуйте ещё раз.");
        //}

        //var favoriteColors = GetFavoriteColors(colorCount);

        return (firstName, lastName, age, hasPets);
    }

    static void ShowUserData((string, string, int, bool, string[]) userData)
    {
        Console.WriteLine($"Имя: {userData.Item1}");
        Console.WriteLine($"Фамилия: {userData.Item2}");
        Console.WriteLine($"Возраст: {userData.Item3}");
        Console.WriteLine($"Наличие питомца: {(userData.Item4 ? "да" : "нет")}");
        //if (userData.Item4 && userData.Item5 != null)
        //{
        //    Console.WriteLine($"Количество питомцев: {userData.Item5.Length}");
        //    Console.WriteLine($"Клички питомцев: {string.Join(", ", userData.Item5)}");
        //}
        //Console.WriteLine($"Количество любимых цветов: {userData.Item6.Length}");
        //Console.WriteLine($"Любимые цвета: {string.Join(", ", userData.Item6)}");
    }
}

//        static string[] GetPetNames(int count)
//        {
//            var petNames = new string[count];
//            for (int i = 0; i < count; i++)
//            {
//                Console.Write($"Введите кличку питомца №{i + 1}: ");
//                petNames[i] = Console.ReadLine();
//            }


