-поменял структуру папок
-выделил интрфейсы для каждого типа объектов
-избавился от тяжелых вызовов в Update
-вынес настройки в конфиги
-сделал пул объектов
-реализовал стрельбу с упреждением для CannonTower: добавить функционал поиска цели и наведения на неё (поворот). ScanRange - область поиска, AttackRange - область поражения
-для CannonTower реализовал режим стрельбы на упреждение по параболической траектории
-сделал, чтоб мобы по кругу бегали
-добавил GameEvents с сигналами для ключевых событий
-в TargetingSystem содержатся математические вычисления траекторий снарядов
