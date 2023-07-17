# Animal Shelter
Backend приложение для сайта "Приют для животных" (Учебный проект)

### Использование:
1. Скачать docker-compose.yml
2. Открыть терминал в папке с docker-compose.yml, ввести команду `docker compose -p animal-shelter up -d`  
   *(На устройстве должен быть установлен и запущен Docker)*

### Стек технологий:
- ASP.NET Core Web API
- Docker (docker-compose)
- Entity Framework Core
- SQLite
- MeditoR
- AutoMapper
- Fluent Validation
- Swagger

### Особенности:
- Контейнеризация приложения с помощью Docker, запуск через docker-compose (включая внешние тома для базы данных)
- Clean Architecture, CQRS
- Использование Entity Framework Core для работы с базой данных
- Использование SQLite в качестве базы данных
- Использование MediatoR и AutoMapper для построения архитектуры
- Использование Fluent Validation для валидации запросов и формирования ошибок
- Использование Swagger для документирования API
- Реализация сервиса по сохранению изображений в Base64 на сервер

### Функционал Backend приложения (API):
- Методы Get, Post, Delete для получение списка статуса животных
- Методы Get, Post, Update, Delete для таблицы с животными (фотография, дата принятия, описание, имя, ...)
- Методы Get, Post, Delete для событий приюта (фотография, дата, описание)
- Методы Get, Post, Delete для видов животных
- Методы Get, Post для животных, которые нашли хозяина (фото, дата, отзыв о приюте)
- Методы Get, Post, Delete для оформления заказов животных
- Методы Get, Post для подписок на рассылку сайта

---
**PArrotWeb © 2023**  
(parrotweb44@gmail.com)
