class Baza:
    def __init__(self, name, year, director):
        self.name = name
        self.year = year
        self.director = director
        
    def display_info(self):
        print(f"Название: {self.name}"
        f"\nГод выпуска: {self.year}"
        f"\nРежиссер: {self.director}")
    
    def proverka(self):
        if self.year < 2010:
            print(f"Фильм вышел раньше 2010 года")
        elif self.year == 2010:
            print(f"Фильм вышел в 2010 году")
        else:
            print(f"Фильм вышел позднее 2010 года")

class Film(Baza):
    def __init__(self, name, year, director, genre, duration):
        super().__init__(name, year, director)
        self.genre = genre
        self.duration = duration
        
    def durationproverka(self):
        if self.duration <= 50:
            print(f"Короткометражный фильмва")
        else:
            print(f"Полнометражный фильм (длиннее 50 минут)")
        
class Cartoon(Baza):
    def __init__(self, name, year, director, age_limit, type_of_animation):
        super().__init__(name, year, director)
        self.age_limit = age_limit
        self.type_of_animation = type_of_animation
        
    def agelimitproverka(self):
        if self.age_limit >= 18:
            print(f"Не для детей и подросткова")
        else:
            print(f"Для детей и подростков")
        
film1 = Film("Гарри Поттер и философский камень", 2001, "Крис Коламбус", "Фэнтези", 140)
cartoon1 = Cartoon("Смешарики. Начало", 2011, "Денис Чернов", 0, "3D CGI")

film1.display_info()
film1.proverka()
film1.durationproverka()
print("")
cartoon1.display_info()
cartoon1.proverka()
cartoon1.agelimitproverka()
