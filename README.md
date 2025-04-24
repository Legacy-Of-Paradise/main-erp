<p align="center"> <img alt="Legacy of Paradise" width="653" height="256" src="https://github.com/Legacy-Of-Paradise/main-erp/blob/master/Resources/Textures/_NewParadise/Logo/logo.png?raw=true" /></p>

Legacy of Paradise — это форк [Space Station 14](https://github.com/space-wizards/space-station-14), работающий на движке [Robust Toolbox](https://github.com/space-wizards/RobustToolbox), написанном на C#.

Это основной репозиторий Legacy Of Paradise.

Если вы хотите запустить сервер или создавать контент для LOP, то вам нужен именно этот репозиторий. В нём содержится как RobustToolbox, так и набор ресурсов для разработки новых контент-паков.

## Ссылки

[Discord](https://wiki.legacyofparadise.space/discord/) | [Steam](https://store.steampowered.com/app/1255460/Space_Station_14/)

## Документация/Вики

В нашей [вики](https://wiki.legacyofparadise.space/) есть документация по контенту LOP.

## Внесение вклада

Мы рады принять вклад от любого участника. Присоединяйтесь к нашему Discord, если хотите помочь. У нас есть [список идей](https://wiki.legacyofparadise.space/discord/), которые можно реализовать, и любой желающий может их взять. Не бойтесь спрашивать, если вам нужна помощь!

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

### Основные решения проблем

Попробуйте удалить папку bin и внутренности RobustToolBox.

## Лицензия

Контент, внесенный в этот репозиторий после комита 47c7281645525a21a2519befa95b89e062334076 лицензируется под GNU Affero General Public License version 3.0, если не указано иное. См. `LICENSE-AGPLv3.txt`.
Контент, внесенный в этот репозиторий до комита 47c7281645525a21a2519befa95b89e062334076 лицензируется под MIT, если не указано иное. См. `LICENSE-MIT.txt`.

[47c7281645525a21a2519befa95b89e062334076](https://github.com/Legacy-Of-Paradise/main-erp/commit/47c7281645525a21a2519befa95b89e062334076) опубликован Sep 21, 2024, 12:30 AM GMT+3

Большинство ассетов лицензированы под [CC-BY-SA 3.0](https://creativecommons.org/licenses/by-sa/3.0/), если не указано иное. Ассеты имеют свою лицензию и авторские права в файле метаданных. [Пример](https://github.com/Legacy-Of-Paradise/main-erp/blob/master/Resources/Textures/Objects/Tools/crowbar.rsi/meta.json).

Обратите внимание, что некоторые ассеты лицензированы на некоммерческой основе [CC-BY-NC-SA 3.0](https://creativecommons.org/licenses/by-nc-sa/3.0/) или аналогичной некоммерческой лицензией, и их необходимо удалить, если вы хотите использовать этот проект в коммерческих целях.

![Alt](https://repobeats.axiom.co/api/embed/51894b7102af659f0a2876d3930680c91cd302ca.svg "Repobeats analytics image")
