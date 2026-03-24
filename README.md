# CoordSystemsLab1
Бучко Вікторія IПЗ-4.02 Лаб № 1
Тема: Програмні моделі систем координат
Мета: 
- Спроектувати та реалізувати імутабельні програмні моделі для представлення точок у 2D та 3D системах координат.
- Реалізувати механізми перетворення між декартовою, полярною та сферичною системами координат з використанням статичних фабричних методів.
- Навчитись обчислювати відстані між точками, використовуючи різні математичні підходи.
- Провести аналіз продуктивності обчислень для різних представлень даних.

Вимоги до середовища
- Встановлена платформа .NET (версія 6.0 або новіша)
- Будь-яке середовище розробки (Visual Studio / VS Code...)




1. Проектування та реалізація імутабельних моделей даних
Необхідно спроектувати та реалізувати імутабельні (immutable) класи або структури для представлення точок. Після створення об'єкта його стан (координати) не повинен змінюватися.

Створіть наступні моделі даних:
- CartesianPoint2D(x, y)
- PolarPoint(radius, angle)
- CartesianPoint3D(x, y, z)
- SphericalPoint(radius, azimuth, polarAngle) (де radius - радіус-вектор , azimuth - азимутальний кут , polarAngle - полярний кут )

![CartesianPoint2D](img1.png)  

Рисунок 1 – CartesianPoint2D(x, y)

![PolarPoint](img2.png)  

Рисунок 2 – PolarPoint(radius, angle)

![CartesianPoint3D](img3.png)  

Рисунок 3 – CartesianPoint3D(x, y, z)

![SphericalPoint](img4.png)  

Рисунок 4 – SphericalPoint(radius, azimuth, polarAngle)



2. Реалізовано статичні фабричні методи для перетворення між системами координат.

Для двовимірного простору (2D):
- у класі CartesianPoint2D реалізовано метод fromPolar(PolarPoint p)
- у класі PolarPoint реалізовано метод fromCartesian(CartesianPoint2D p)

![Методи 2D](img5.png)  
Рисунок 5 – Методи fromCartesian та fromPolar

Для тривимірного простору (3D):
- у класі CartesianPoint3D реалізовано метод fromSpherical(SphericalPoint p)
- у класі SphericalPoint реалізовано метод fromCartesian(CartesianPoint3D p)

![Методи 3D](img6.png)  
Рисунок 6 – Методи fromSpherical та fromCartesian (3D)
