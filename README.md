<p align="center"> <img alt="Space Station 14" width="880" height="300" src="https://raw.githubusercontent.com/space-wizards/asset-dump/de329a7898bb716b9d5ba9a0cd07f38e61f1ed05/github-logo.svg" /></p>

Space Station 14 это ремейк SS13, который работает на собственном движке [Robust Toolbox](https://github.com/space-wizards/RobustToolbox), написанном на C#.

Это репозиторий первого русскоязычного сервера по Space Station 14, целью которого является полный перевод игры на русский язык, поддержка актуальных изменений из основного репозитория, а так же добавление собственных изменений по необходимости.

## Ссылки

[Discord](https://wiki.legacyofparadise.space/discord/) | [Steam](https://store.steampowered.com/app/1255460/Space_Station_14/)

## Документация

На официальном сайте с [документацией](https://docs.spacestation14.io/) имеется вся необходимая информация о контенте SS14, движке, дизайне игры и многом другом. Также имеется много информации для начинающих разработчиков.

## Контрибьют

Мы рады принять вклад от любого человека. Заходите в Discord, если хотите помочь. У нас есть [список проблем](https://github.com/space-syndicate/space-station-14-content/issues), которые нужно решить, и любой может за них взяться. Не бойтесь просить о помощи!
Только убедитесь, что ваши изменения и PRы соответствуют [руководству по контрибьюту](https://docs.spacestation14.com/en/general-development/codebase-info/pull-request-guidelines.html).

## Сборка проекта.

### Зависимости

> - Git
> - .NET SDK 9.0.x

### Windows

> 1. Клонируйте репо
> 3. Запустите `Scripts/bat/buildAllDebug.bat` после каждого измения в C#.
> 4. Запустите `Scripts/bat/runQuickAll.bat` для запуска клиента и сервера.
> 5. Подключитесь к "localhost" в клиенте.

### Linux

> 1. Клонируйте репо
> 3. Запустите `Scripts/sh/buildAllDebug.sh` после каждого изменения в C#.
> 4. Запустите `Scripts/sh/runQuickAll.sh` для запуска клиента и сервера.
> 5. Подключитесь к "localhost" в клиенте.

## Лицензия

Весь код репозитория лицензирован под [MIT](https://github.com/space-syndicate/space-station-14/blob/master/LICENSE.TXT).

Большинство ассетов лицензированы под [CC-BY-SA 3.0](https://creativecommons.org/licenses/by-sa/3.0/), если не указано иное. Ассеты имеют свою лицензию и авторские права в файле метаданных. [Пример](https://github.com/space-syndicate/space-station-14/blob/master/Resources/Textures/Objects/Tools/crowbar.rsi/meta.json).

Обратите внимание, что некоторые ассеты лицензированы на некоммерческой основе [CC-BY-NC-SA 3.0](https://creativecommons.org/licenses/by-nc-sa/3.0/) или аналогичной некоммерческой лицензией, и их необходимо удалить, если вы хотите использовать этот проект в коммерческих целях.
