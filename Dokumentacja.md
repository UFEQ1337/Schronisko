# Dokumentacja Techniczna Projektu "Schronisko"
## Wprowadzenie
Projekt "Schronisko" to aplikacja webowa przeznaczona do zarządzania schroniskiem dla zwierząt. Wykorzystuje technologie takie jak ASP.NET Core, Entity Framework Core oraz SQL Server.

## Architektura Aplikacji
Aplikacja jest zbudowana w oparciu o wzorzec MVC (Model-View-Controller), co umożliwia wyraźne oddzielenie logiki biznesowej od interfejsu użytkownika.

## Kontrolery
1. **AnimalsController**: Zarządza operacjami na zwierzętach (wyświetlanie, dodawanie, edycja, usuwanie).
2. **HomeController**: Obsługuje ogólne żądania, takie jak strona główna i polityka prywatności.
3. **OwnersController**: Zarządza operacjami na właścicielach zwierząt.
4. **SheltersController**: Odpowiada za operacje związane ze schroniskami.

## Modele
1. **Animal**: Reprezentuje zwierzę, zawiera informacje takie jak imię, rasa, wiek.
2. **Owner**: Reprezentuje właściciela zwierzęcia, zawiera dane takie jak nazwa właściciela, czas adopcji.
3. **Shelter**: Model dla schroniska, zawiera informacje takie jak nazwa i adres schroniska.

## Warstwa Danych
- **ApplicationDbContext**: Konfiguruje kontekst Entity Framework z zestawami DbSets dla Animals, Owners i Shelters.

## Widoki (Views)
- Widoki zapewniają interfejs użytkownika dla różnych operacji, takich jak tworzenie, edycja i wyświetlanie rekordów.

## Konfiguracja Aplikacji
- **Program.cs**: Konfiguruje aplikację, w tym usługi i oprogramowanie pośredniczące.

## Bezpieczeństwo i Uwierzytelnianie
- Aplikacja zawiera mechanizmy uwierzytelniania i autoryzacji użytkowników.

## Funkcjonalności
1. **Logowanie**: Użytkownicy mogą logować się do systemu przy użyciu swoich danych uwierzytelniających.
2. **Dodawanie schroniska**: Umożliwia dodawanie nowych schronisk, gdzie użytkownik jest automatycznie przypisywany jako właściciel schroniska.
3. **Dodawanie psa**: Pozwala na dodawanie informacji o psach, takich jak imię, wiek, rasa, itp.
4. **Przypisywanie psa do schroniska**: Umożliwia przypisywanie konkretnego psa do wybranego schroniska.
5. **Moduł adopcji**: Użytkownicy mogą wybierać psy do adopcji. Po adopcji status psa zmienia się, aby uniemożliwić kolejne adopcje tego samego psa.

## Scenariusze Użycia
1. **Logowanie do systemu**
   - Wejdź na stronę logowania.
   - Wprowadź dane uwierzytelniające.
   - Kliknij "Zaloguj się".
2. **Dodawanie schroniska**
   - Przejdź do sekcji "Dodaj Schronisko".
   - Wypełnij formularz danymi schroniska.
   - Kliknij "Dodaj Schronisko".
3. **Dodawanie psa**
   - Przejdź do sekcji "Dodaj Psa".
   - Wypełnij formularz danymi psa.
   - Kliknij "Dodaj Psa".
4. **Przypisywanie psa do schroniska**
   - Przejdź do sekcji "Przypisz Psa do Schroniska".
   - Wybierz psa i schronisko.
   - Kliknij "Przypisz Psa".
5. **Adopcja psa**
   - Przejdź do sekcji "Moduł Adopcji".
   - Wybierz psa dostępnego do adopcji.
   - Kliknij "Adoptuj".
   - Potwierdź adopcję.
---

# Autorzy
**Mateusz Popielarz**  |  **Albert Piskorz**
