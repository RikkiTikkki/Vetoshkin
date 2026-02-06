class Baza
{
    string name = "";
    int year = 0;
    string director = "";
    public Baza(string name, int year, string director)
    {
        this.name = name;
        this.year = year;
        this.director = director;
        Console.WriteLine($"Название: {name} \nГод: {year} \nРежиссер: {director}");
    }
    public void Proverka()
    {
        if(this.year < 2010 )
        {
            Console.WriteLine($"Фильм вышел раньше 2010 года");
        }
        else if (this.year == 2010)
        {
            Console.WriteLine($"Фильм вышел в 2010 году");
        }
        else 
        {
            Console.WriteLine($"Фильм вышел позднее 2010 года");
        }
    }
}

class Film : Baza
{
    string genre = "";
    int duration = 0;
    public Film(string name, int year, string director, string genre, int duration) : base(name, year, director)
    {
        this.genre = genre;
        this.duration = duration;
        Console.WriteLine($"Жанр: {genre} \nПродолжительность (в минутах): {duration}");
    }
    public void Duration_Proverka()
    {
        if (this.duration <= 50)
        {
            Console.WriteLine($"Короткометражный фильм");
        }
        else
        {
            Console.WriteLine($"Полнометражный фильм (длиннее 50 минут)");
        }
    }
}

class Cartoon : Baza
{
    int age_limit = 0;
    string type_of_animation = "";
    public Cartoon(string name, int year, string director, int age_limit, string type_of_animation) : base(name, year, director)
    {
        this.age_limit = age_limit;
        this.type_of_animation = type_of_animation;
        Console.WriteLine($"Возрастное ограничение: {age_limit} \nТип анимации: {type_of_animation}");
    }
    public void Age_Limit_Proverka()
    {
        if (this.age_limit >= 18)
        {
            Console.WriteLine($"Не для детей и подростков");
        }
        else 
        {
            Console.WriteLine($"Для детей и подростков");
        }
    }
}


public class Program
{
    public static void Main()
    {
        Film film1 = new Film("Гарри Поттер и философский камень", 2001, "Крис Коламбус", "Фэнтези", 140);
        film1.Proverka();
        film1.Duration_Proverka();
        Console.WriteLine("");
        Cartoon cartoon1 = new Cartoon("Смешарики. Начало", 2011, "Денис Чернов", 0, "3D CGI");
        cartoon1.Proverka();
        cartoon1.Age_Limit_Proverka();
    }
}
