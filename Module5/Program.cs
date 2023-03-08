
using System.Text;

// Необходимо создать метод, который заполняет данные с клавиатуры по пользователю (возвращает кортеж):
// + Имя;
// + Фамилия;
// + Возраст;
// + Наличие питомца;
// Если питомец есть, то запросить количество питомцев;
// Если питомец есть, вызвать метод, принимающий на вход количество питомцев и возвращающий массив их кличек (заполнение с клавиатуры);
// Запросить количество любимых цветов;
// Вызвать метод, который возвращает массив любимых цветов по их количеству (заполнение с клавиатуры);
// Сделать проверку, ввёл ли пользователь корректные числа: возраст, количество питомцев, количество цветов в отдельном методе;
// Требуется проверка корректного ввода значений и повтор ввода, если ввод некорректен;
// Корректный ввод: ввод числа типа int больше 0.
// Метод, который принимает кортеж из предыдущего шага и показывает на экран данные.
// Вызов методов из метода Main.

class Program
{
    public static void Main(string[] args)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.GetEncoding(1251);

        var userData = GetUserInput();
        ShowUserData(userData);
    }


    static (string FirstName, string LastName, int Age, bool HasPets) GetUserInput()
    {
        Console.Write("Имя: ");
        var firstName = Console.ReadLine();

        Console.Write("Фамилия: ");
        var lastName = Console.ReadLine();

		int age = GetPositiveInt("Возраст: ");

        bool hasPets;
        while (true)
        {
            Console.Write("Есть ли у вас питомец? (Да/Нет) ");
            var hasPetsStr = Console.ReadLine().ToLower();
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
		
		int numberOfPets;
		string[] petNames;
		if (hasPets) {
			numberOfPets = GetPositiveInt("Введите количество питомцев: ");
			petNames = GetPetNames(numberOfPets);
		}

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

        return (FirstName: firstName, LastName: lastName, Age: age, HasPets: hasPets);
    }

    static void ShowUserData((string FirstName, string LastName, int Age, bool HasPets) userData)
    {
        Console.WriteLine($"Имя: {userData.FirstName}");
        Console.WriteLine($"Фамилия: {userData.LastName}");
        Console.WriteLine($"Возраст: {userData.Age}");
        Console.WriteLine($"Наличие питомца: {(userData.HasPets ? "да" : "нет")}");
        //if (userData.Item4 && userData.Item5 != null)
        //{
        //    Console.WriteLine($"Количество питомцев: {userData.Item5.Length}");
        //    Console.WriteLine($"Клички питомцев: {string.Join(", ", userData.Item5)}");
        //}
        //Console.WriteLine($"Количество любимых цветов: {userData.Item6.Length}");
        //Console.WriteLine($"Любимые цвета: {string.Join(", ", userData.Item6)}");
    }
	
	static int GetPositiveInt(string message)
	{
		int result;
		while (true)
		{
			Console.Write(message);
			if (int.TryParse(Console.ReadLine(), out result) && result > 0)
				break;
		}

		return result;
	}
		
	static string[] GetPetNames(int count)
	{
		var names = new string[count];
		for (int i = 0; i < count; i++)
		{
			Console.Write($"Введите кличку питомца {i + 1}: ");
			names[i] = Console.ReadLine();
		}

		return names;
	}

	static string[] GetColors(int count)
	{
		var colors = new string[count];
		for (int i = 0; i < count; i++)
		{
			Console.Write($"Введите любимый цвет {i + 1}: ");
			colors[i] = Console.ReadLine();
		}

		return colors;
	}
}


