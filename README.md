# Aplikacja FRIDGamE
Aplikacja jest prototypem sklepu z grami na wzór steama. Administrator może dodawać gry, promocje, dane twórców i wydawców oraz wpisy o nowościach w sklepie. Użytkownicy mogą przeglądać newsy, sklep z grami i promocje a także zasilić konto którym opłacają zakupy w aplikacji.
# Przototowanie do uruchomienia
W pierwszej kolejności należy skonfigurować plik appsettings.json wprowadzając connectionstring umożliwiający połączenie się z serwerem SQL.
Następnie należy wykonać migrację aby utworzyć bazę danych.
```sh
dotnet ef migrations add initalMigration
dotnet ef database update
```
Następnie należy zarejestrować konto administratora i nadać mu odpowiednie uprawnienia w bazie danych za pomocą Microsoft SQL server Managment Studio zmieniając w tabeli dbo.AspNetUserRoles pole RoleId na Id roli o nazwie Admin z tabeli dbo.AspNetRoles. Warto na koniec zarejestrować zwykłego użytkownika, jednak nie jest to wymagane do działania aplikacji.
# Funkcjonalność aplikacji dla użytkownika
W prawym górnym rogu są przyciski umożliwiające rejestrację i logowanie, a po zalogowaniu możliwość wylogowania się, ustawień konta oraz bibliotekę.
Biblioteka pozwala sprawdzić stan konta, doładować je a także sprawdzić posiadane gry.

Strona główna pozwala na przeglądanie opublikowanych newsów. Można tu znaleźć przykładowo informację o premierze nowej gry albo weekendowej wyprzedaży.

Sklep pozwala na kupowanie gier oraz zapoznawanie się ze szczegółami takimi jak opis. Gry early access są opatrzone dodatkowym opisem wczesny dostęp.

Promocje to zakładka która pozwala na łatwiejszy dostęp do przecenionych gier, czytania ich opisów oraz dokonania ich zakupu.

# Funkcjonalność aplikacji dla administratora
Na stronie głównej są widoczne również posty których data publikacji jest ustawiona na przyszłą, a ich brak widoczności dla użytkowników jest oznaczony szarym kolorem.

Sklep pozwala dodatkowo na dodawanie nowych gier, edytowanie istniejących, wycofywanie ze sprzedaży.

Promocje pozwalają na zarządzanie istniejącymi promocjami, dodawaniu nowych oraz dostępu do tych które już wygasły i nie są widoczne dla zwykłego użytkownika

Panele Twórcy oraz Wydawcy pozwalają na wprowadzanie, edytowanie i sprawdzanie szczegółów danych twórców i wydawców.

Panel Zarządzaj Aktualnościami pozwala dodawać nowe wpisy które będą widoczne na stronie głównej.

# Api

Aplikacja obsługuje technologię API.

Najprościej przetestować działanie API w rozszerzeniu do przeglądarki - narzędziu Boomerang.
GET, POST, DELETE, PUT lub UPDATE)

# Testowanie aplikacji
W projekcie są zaimplementowane testy jednostkowe kontrolera API. Aby je uruchomić należy prawym przyciskiem myszy kliknąć na GamesControllerTest i wybrać opcję "Uruchom testy".
