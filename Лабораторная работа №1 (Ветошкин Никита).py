subjects1 = [1,2,3,4,5,6,7,8,9,1]
print("Задание №1. Cоздание списка из 10 аргументов. ", subjects1)
print("Задание №2. Вывод предпоследнего, последнего и первого элемента. ", subjects1[-2], ",", subjects1[-1], ",", subjects1[0])
subjects1[2] = 1
print("Задание №3. Изменение третьего элемента. ", subjects1[2])
print("Задание №4. Вывод чисел из диапазона. ", subjects1[1:6])
subjects1.append(1)
print("Задание №5. Добавление элемента 1 в конец списка.", subjects1)
subjects1.insert(len(subjects1)//2, 7)
print("Задание №6. Добавление элемента 7 в середину списка. ", subjects1)
print("Задание №7. Вывод количества 1 в списке. ", subjects1.count(1))
subjects2 = subjects1.copy()
subjects1 = subjects1[::-1]
print("Задание №8. Вывод второго списка и инвертированного первого. ", subjects2, ", ", subjects1)




