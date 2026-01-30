class Baza
{
    string name = "";
    string year = "";
    string director = "";
    public Baza(string name, string year, string director)
    {
        this.name = name;
        this.year = year;   
        this.director = director;
        Console.WriteLine($"Название: {name} \nГод: {year} \nРежиссер: {director}");
    }
}

class Film : Baza {
    string genre = "";
    string duration = "";
    public Film(string name, string year, string director, string genre, string duration) : base(name, year, director)
    {
        this.genre = genre;
        this.duration = duration;
        Console.WriteLine($"Жанр: {genre} \nПродолжительность: {duration}");
    }
}

class Cartoon : Baza
{
    string age_limit = "";
    string type_of_animation = "";
    public Cartoon(string name, string year, string director, string age_limit, string type_of_animation) : base(name, year, director)
    {
        this.age_limit = age_limit;
        this.type_of_animation = type_of_animation;
        Console.WriteLine($"Возрастное ограничение: {age_limit} \nТип анимации: {type_of_animation}");
    }
}


public class Program
{
    public static void Main()
    {
        Film film1 = new Film("Гарри Поттер и философский камень", "2001", "Крис Коламбус", "Фэнтези", "2 часа 23");
        Console.WriteLine("");
        Cartoon cartoon1 = new Cartoon("Смешарики. Начало", "2011", "Денис Чернов", "0+", "3D CGI");
    }
}