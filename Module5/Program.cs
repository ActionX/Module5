
class Program
{
    public static void Main(string[] args)
    {
        var userData = GetUserData();
        ShowUserData(userData);

        Console.ReadKey();
    }


    static (string FirstName, string LastName, int Age, bool HasPets, string[] PetNames, string[] FavoriteColors) GetUserData()
    {
        Console.Write("Введите имя: ");
        var firstName = Console.ReadLine();

        Console.Write("Введите фамилию: ");
        var lastName = Console.ReadLine();

		int age = GetPositiveInt("Введите возраст: ");

        bool hasPets = GetHasPets();
		
		int numberOfPets;
		string[] petNames = new string[0];

		if (hasPets)
        {
			numberOfPets = GetPositiveInt("Введите количество питомцев: ");
			petNames = GetPetNames(numberOfPets);
		}

        int favouriteColorCount = GetPositiveInt("Введите количество любимых цветов: ");
        var favoriteColors = GetFavoriteColors(favouriteColorCount);

        return (FirstName: firstName, LastName: lastName, Age: age, HasPets: hasPets, PetNames: petNames, FavoriteColors: favoriteColors);
    }

    static void ShowUserData((string FirstName, string LastName, int Age, bool HasPets, string[] PetNames, string[] FavoriteColors) userData)
    {
        Console.WriteLine($"Имя: {userData.FirstName}");
        Console.WriteLine($"Фамилия: {userData.LastName}");
        Console.WriteLine($"Возраст: {userData.Age}");
        Console.WriteLine($"Наличие питомца: {(userData.HasPets ? "да" : "нет")}");
        if (userData.HasPets && userData.PetNames != null)
        {
            Console.WriteLine($"Количество питомцев: {userData.PetNames.Length}");
            Console.WriteLine($"Клички питомцев: {string.Join(", ", userData.PetNames)}");
        }
        Console.WriteLine($"Количество любимых цветов: {userData.FavoriteColors.Length}");
        Console.WriteLine($"Любимые цвета: {string.Join(", ", userData.FavoriteColors)}");
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
	
    static bool GetHasPets()
    {
        while (true)
        {
            Console.Write("Есть ли у вас питомец? (Да/Нет) ");
            var hasPetsStr = Console.ReadLine().ToLower();
            switch (hasPetsStr)
            {
                case "да":
                    return true;
                case "нет":
                    return false;
                default:
                    break;
            }
            Console.WriteLine("Некорректный ввод. Попробуйте ещё раз.");
        }
    }

	static string[] GetPetNames(int count)
	{
		var names = new string[count];
		for (int i = 0; i < count; i++)
		{
			Console.Write($"Введите имя питомца {i + 1}: ");
			names[i] = Console.ReadLine();
		}

		return names;
	}

	static string[] GetFavoriteColors(int count)
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


