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


 ## Lab3
 ### Zadanie 1: Wysokopoziomowe zrównoleglenie obliczeń (Parallel)
  W ramach zadania zaimplementowano model macierzy aor algorytm mnożący ją z wykorzystaniem bilbioteki Parallel. Program uśrednia wynik z 3 pomiarów oraz wyświetla wynik w milisekundach. Badania przeprowadzono na różnych rozmiarach macierzy oraz na róznej ilości wątków (również większych niż fizyczne). Pomiary wykazały, że podział zadańna wiele wątków redukuje czas obliczeń dla dużych zbiorów. 

  ### Zadanie 2: Niskopoziomoe zarządzanie wątkami (Thread)
  Zadanie 2 to rozszerzona wersja zadania 1 o algorytm mnożenia wykorzystujący klasę Thread. Praca dzielona jest na wiersze przypisywane do konkretnych obiektów, metoda Join() sygnalizuje zakończenie oraz synchronizację. Porównując wyniki lepiej poradziła sobie bilbioteka Parallel udowadniając wydajność dzięki korzystaniu z systemowej puli wątków. 

<img width="1009" height="696" alt="image" src="https://github.com/user-attachments/assets/527745bf-5dfe-436f-a036-1e59f500c0ef" />


  ### Zadanie 3: Wielowątkowe przetwarzanie obrazów w GUI
   Zaprojektowano apliakcję graficzną Windows Forms, w której zaimolenetowano cztery różne filtry przetwarzające piksele obrazu(odcienie szarości, negatyw, progowanie,własny filtr). Za pomocą obiektu Bitmap nałożono wszystkie filtry jednocześnie. Task.RUn pomógł oddzielić cieżkie obliczenia od głównego wątku aplikacji. 
