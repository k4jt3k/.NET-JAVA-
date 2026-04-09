 # Platfromy programistyczne .NET i Java


## Lab0 
Program Fizzbuzz 
 

## Lab1 
### Zadanie 1: Algorytm rozwiązujący problem plecakowy
  Zaimplementowano klase Problem, która generuje przedmioty o losowych wagach i losowych wartościach przy użyciu ziarna. Następnie algorytm sortuje przedmioty według stosunku wartość/ waga i wypełnia plecak tak by nie przekraczał określonej pojemności. Wyniki są zwracane przez klasę Result. 

### Zadanie 2: Testy jednostkowe 
  Przeprowadzono 5 testów jednostkowych sprawdzających program np. poprawność wyniku dla konkretnej instancji. Ostatecznie wszystkie 5 testów przebiegło pomyślnie.

### Zadanie 3: GUI
  Zaprojektowano interfejs graficzny do obsługi algorytmu z pierwszego zadania. Dodano pole tekstowe do wprowadzania wartości oraz przycisk do uruchomienia algorytmu. Zastosowano również walidację danych czyli podświetlenie okna na czerwono w przypadku wprowadzenia nieodpowiednich danych. 

### Poprawki w domu: 
* naprawienie jednego testu jednostkowego by algorytm przechodził poprawnie wszystkie testy
* dodanie walidacji w interfejsie graficznym


## Lab2
### Zadanie 1: Komunikacja z API
 W tym zadaniu napisano aplikacje konsolową, która przyjmuje od użytkownika wartości daty oraz symbol waluty. Następnie klasa ApiService.cs wykorzystuje HttpCLient wysyłając zapytanie do serwisu OpenExchangeRate. Plik ExchangeRate.cs służy jako DTO do któego deserializowany jest format JSON z odpowiedzi API. Wyniki zapytania wyświetlane są w konsoli. 

### Zadanie 2:  Obsługa bazy danych 
 Wprowadzono Entity Framework Core oraz stworzono proste konsolowe MENU do obsługi bazy danych - pozwala na dodanie nowych rekordów, filtrowanie, sortowanie, wyświetlanie. Aplikacja początkowo sprawdza czy dany rekord znajduję sie w bazie, jeśli tak wyświetla go, jeśli nie to pobiera go z API. Filtracja rekordów polega na wybraniu danej waluty(Where) natomiast sortowanie opiera sie na prezentowaniu danych według wartości(OrderBy). Definicja struktury bazy znajduję sie w pliku ExchangeContext.cs. 

### Zadanie 3: GUI
 Stworzono interfejs graficzny za pomocą Avalonia. Interfejs pozwala na graficzne wpisanie wartości daty oraz symbolu waluty, następnie baza danych pobranych wartości jest wyświetlana. Zastosowano automatyczne odświeżanie. 
 
