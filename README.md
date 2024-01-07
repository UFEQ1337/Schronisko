# Schronisko

## O Projekcie
"Schronisko" to aplikacja webowa stworzona w technologii ASP.NET MVC i .NET 8, przeznaczona do zarządzania schroniskiem dla zwierząt. Aplikacja umożliwia użytkownikom dodawanie schronisk, zwierząt oraz ułatwia proces adopcji.

## Dokumentacja

[Dokumentacja](https://github.com/UFEQ1337/Schronisko/blob/master/Dokumentacja.md)

## Funkcjonalności
- **Logowanie użytkowników:** Umożliwia personalizowaną interakcję z aplikacją.
- **Dodawanie schronisk:** Użytkownicy mogą dodawać schroniska i są automatycznie przypisywani jako ich właściciele.
- **Dodawanie zwierząt:** Możliwość dodania psów do bazy danych wraz z informacją o ich dostępności do adopcji.
- **Przypisywanie psów do schronisk:** Umożliwia przypisanie konkretnego psa do wybranego schroniska.
- **Moduł adopcji:** Umożliwia użytkownikom adoptowanie psów.

## Technologie
- **ASP.NET MVC:** Framework do budowy aplikacji webowych, wspierający model MVC (Model-View-Controller).
- **.NET 8:** Framework programistyczny do tworzenia aplikacji w językach takich jak C#.

## Jak Zacząć
Aby uruchomić projekt "Schronisko" na podstawie dostępnych informacji, możesz postępować zgodnie z poniższymi krokami. Zakładam, że projekt jest aplikacją ASP.NET Core i wymaga środowiska .NET Core oraz SQL Server do działania:

### Wymagania Wstępne
1. **Zainstaluj .NET Core SDK**: Upewnij się, że masz zainstalowane .NET Core SDK. Możesz pobrać je ze strony [Microsoft .NET](https://dotnet.microsoft.com/download).
   
2. **Zainstaluj Visual Studio lub Visual Studio Code**: Zalecane jest użycie Visual Studio (z obsługą ASP.NET i rozwoju aplikacji internetowych) lub Visual Studio Code z odpowiednimi rozszerzeniami dla .NET Core.

#### Klonowanie Repozytorium
3. **Sklonuj Repozytorium**: Użyj Git, aby sklonować repozytorium na swój lokalny komputer. Możesz to zrobić za pomocą polecenia:
   ```
   git clone https://github.com/UFEQ1337/Schronisko.git
   ```

#### Konfiguracja Projektu
4. **Otwórz Projekt**: Otwórz sklonowany folder projektu w Visual Studio lub Visual Studio Code.

5. **Zainstaluj Zależności**: Upewnij się, że wszystkie zależności są zainstalowane. W Visual Studio zależności powinny zostać automatycznie zainstalowane. W Visual Studio Code możesz użyć terminala i uruchomić `dotnet restore`.

#### Uruchomienie Migracji Bazy Danych
6. **Uruchom Migracje**: Aby zaktualizować bazę danych do najnowszego schematu wymaganego przez aplikację, użyj polecenia `dotnet ef database update` w terminalu.

#### Uruchomienie Aplikacji
7. **Uruchom Aplikację**: Uruchom aplikację. Możesz to zrobić z poziomu Visual Studio naciskając `F5` lub `Ctrl + F5`, lub z terminala za pomocą polecenia `dotnet run`.

8. **Przetestuj Aplikację**: Po uruchomieniu aplikacji, przetestuj ją, odwiedzając lokalny adres URL, który jest wyświetlany w konsoli (zazwyczaj `http://localhost:5000` lub `https://localhost:5001`).

#### Dodatkowe Uwagi
- Upewnij się, że masz odpowiednie uprawnienia do bazy danych.
- Jeśli napotkasz błędy dotyczące brakujących zależności lub pakietów, spróbuj je zainstalować ręcznie za pomocą menedżera pakietów NuGet.

### Diagram

![chrome_PfqAKr3VLL](https://github.com/UFEQ1337/Schronisko/assets/64553202/215145ac-aeb8-4d5a-b52e-8dc1ab23b172)

## Autorzy 
- MP - 131508 &amp; AP - 135538
