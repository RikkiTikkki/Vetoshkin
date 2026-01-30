class Baza:
    def __init__(self, name, year, director):
        self.name = name
        self.year = year
        self.director = director
        
    def display_info(self):
        print(f"Название: {self.name}"
        f"\nГод выпуска: {self.year}"
        f"\nРежиссер: {self.director}")

class Film(Baza):
    def __init__(self, name, year, director, genre, duration):
        super().__init__(name, year, director)
        self.genre = genre
        self.duration = duration
        
class Cartoon(Baza):
    def __init__(self, name, year, director, age_limit, type_of_animation):
        super().__init__(name, year, director)
        self.age_limit = age_limit
        self.type_of_animation = type_of_animation
        
film1 = Film("Гарри Поттер и философский камень", "2001", "Крис Коламбус", "Фэнтези", "2 часа 23 минуты")
cartoon1 = Cartoon("Смешарики. Начало", "2011", "Денис Чернов", "0+", "3D CGI")

film1.display_info()
cartoon1.display_info()