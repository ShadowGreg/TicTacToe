# Крестики нулики с использованием алгоритмической игры компьютера с разными уровнями сложностями

Настраиваемые правила игры:
1) размер поля 3х3 до 5х5;
2) количество клеток в ряд необходимых для выигрыша зависит от размерности поля (3х3 -3 в ряд; 5х5- 5 в ряд) (от себя
   добавил проверку диагонали);
3) режим игры: А) игрок против компьютера; Б) игрок против игрока; В) компьютер против компьютера (демо режим).

Если компьютер ходит первым - должен либо побеждать, либо играть в ничью; если компьютер ходит вторым - максимально
усложнять жизнь игроку.

При сдаче проекта не проверку наличие исходного кода и сборки по Window обязательно.

# Журнал работы над проектом. Рассуждения.

В процессе разработки сделал для себя вывод, "когда я берусь решать задачу - надо исходные данные и модель покрутить
в голове на примерах, выявить характерные стороны точки изменения, а потом начинать писать и описывать что понял".
Чем дольше прорабатываю модель и понимаю закономерности и точки контроля и ответа на задаваемые параметры - тем меньше
переписывать начальный вариант кода.

[ С моделью можно познакомиться тут ](!https://disk.yandex.ru/d/j7ST8evd1dn-qg)

21.10.22

На основании проработки модели делаю вывод.
В классе PlayField. Нужный метод - это подсчёт баллов по строкам и диагоналям.
Стало понятно что баллы - выводить в словарь с ключом по номеру строки, при этом важно в нём же хранить координаты точек
принадлежащих этой строке - пока не понятно как удобней;
При этом надо хранить ещё и баллы внутри каждой клетки.
Думаю это как раз класс ДТО - который будет в себе аккумулировать и обновлять эти значения.
PlayField - заполняет ДТО - инициирует заполнение окончание хода.

структура объекта Словаря линий
1. coordsList - координаты точек 0,0 0,1 0,2 0,3 0,4
2. номер линии 0 - `ключ`				
3. LineWeight - вес линии 21				
4. pointFill - заполнение 1 1 -2 1 -2
5. pointScoreList - вес точки 10 5 2 4 5

как счетает порядковый номер в массив

```
      7д      8д
        4 5 6
       1 | | 
       -------
       2 | |
       -------
       3 | |
       
```
29.10.22
После того как я реализовал логику компьютера на основе одной стороны, я увидел, что если поставить компьютер играть с двух сторон то надо дописывать логику обратной стороны
Что приятно - работающие тесты дают понять - на сколько работоспособен код и сразу увидеть, то что не было видно мне одному до этого, возможно при командной работе слабые стороны решения могли бы быть выявлены раньше.
Нашёл ещё одну тонкость - надо исключать отработанные точки из компьютерного анализа - иначе они по баллам светятся и компьютер норовит ставить туда же