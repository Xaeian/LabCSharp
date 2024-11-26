# Wyrażenia Regularne (Regular Expressions)

Wyrażenia regularne (ang. *regular expressions* lub *regex*) to potężne narzędzie służące do przetwarzania i manipulacji tekstem. Umożliwiają wyszukiwanie wzorców, dopasowywanie i zastępowanie fragmentów tekstu na podstawie określonych zasad. Są szeroko stosowane w programowaniu, analizie danych, a także w edytorach tekstu.

## Składnia Podstawowa

### Znaki Specjalne

| Znak    | Znaczenie                                                    |
| ------- | ------------------------------------------------------------ |
| `.`     | Dowolny znak (oprócz znaku nowej linii)                      |
| `^`     | Początek linii                                               |
| `$`     | Koniec linii                                                 |
| `*`     | Zero lub więcej wystąpień poprzedniego znaku                 |
| `+`     | Jedno lub więcej wystąpień poprzedniego znaku                |
| `?`     | Zero lub jedno wystąpienie poprzedniego znaku _(opcjonalny)_ |
| `{n}`   | Dokładnie `n` wystąpień                                      |
| `{n,}`  | Co najmniej `n` wystąpień                                    |
| `{n,m}` | Od `n` do `m` wystąpień                                      |
| `[]`    | Dowolny z określonych znaków                                 |
| `[^]`   | Dowolny z **nie**-określonych znaków                         |
| `\|`    | Alternatywa _(lub) _                                         |
| `()`    | Grupa _(do tworzenia podwyrażeń)_                            |

### Przykłady Podstawowych Wzorców

- `a.b` - Dopasowuje `a`, dowolny znak i `b`, np. `acb`, `a3b`.
- `^abc` - Dopasowuje `abc` tylko na początku linii.
- `abc$` - Dopasowuje `abc` tylko na końcu linii.
- `a+` - Dopasowuje jedno lub więcej wystąpień `a`, np. `a`, `aaa`.
- `colou?r` - Dopasowuje `color` lub `colour`.

## Klasy Znaków

| Klasa   | Znaczenie                                                           |
| ------- | ------------------------------------------------------------------- |
| `[0-9]` | Dowolna cyfra _(0-9)_                                               |
| `[a-z]` | Dowolna mała litera alfabetu _(od `a` do `z`)_                      |
| `[A-Z]` | Dowolna wielka litera alfabetu _(od `A` do `Z`)_                    |
| `\d`    | Dowolna cyfra _(0-9)_                                               |
| `\D`    | Dowolny znak, który nie jest cyfrą                                  |
| `\w`    | Dowolna litera, cyfra lub znak podkreślenia                         |
| `\W`    | Dowolny znak, który nie jest literą, cyfrą lub znakiem podkreślenia |
| `\s`    | Dowolny biały znak _(spacja, tabulator, nowa linia)_                |
| `\S`    | Dowolny znak, który nie jest białym znakiem                         |
| `.`     | Dowolny znak _(oprócz nowej linii)_                                 |

### Przykłady Klasy Znaków

- `[a-z]{5}` - Dopasowuje ciąg pięciu małych liter, np. `abcde`.
- `[A-Z]\d{2}` - Dopasowuje wielką literę, po której następują dwie cyfry, np. `A12`.
- `[0-9a-zA-Z]+` - Dopasowuje ciąg dowolnych cyfr lub liter, np. `A1b2C3`.
- `[a-zA-Z_]` - Dopasowuje dowolną literę (małą lub wielką) lub znak podkreślenia, np. `a`, `B`, `_`.

## Kotwice i Granice

| Kotwica | Znaczenie          |
| ------- | ------------------ |
| `^`     | Początek linii     |
| `$`     | Koniec linii       |
| `\b`    | Granica słowa      |
| `\B`    | Brak granicy słowa |

### Przykłady Kotwic

- `\bcat\b` - Dopasowuje `cat` jako całe słowo.
- `^\d+` - Dopasowuje liczby na początku linii.

## Znaki Ucieczki
Jeśli chcesz dopasować znak specjalny (np. `.` lub `*`), musisz poprzedzić go ukośnikiem odwrotnym (`\`). Przykład:
- `\.txt` - Dopasowuje `.txt`, a nie dowolny znak.

## Przykłady Użycia

1. **Weryfikacja adresu e-mail**:
   
   ```regex
   ^[\w._%+-]+@[\w.-]+\.[a-zA-Z]{2,}$
   ```
   Ten wzorzec dopasowuje typowy adres e-mail, np. `jan.kowalski@example.com`.

2. **Wyszukiwanie numerów telefonu**:
   
   ```regex
   \(\d{3}\) \d{3}-\d{4}
   ```
   Dopasowuje numer w formacie `(123) 456-7890`.

3. **Wyszukiwanie kodu pocztowego**:
   
   ```regex
   \d{2}-\d{3}
   ```
   Dopasowuje polski kod pocztowy, np. `00-123`.

## Przykładowe Narzędzia do Pracy z Regex
- **Online testers**: [regex101.com](https://regex101.com/), [regexr.com](https://regexr.com/).
- **Edytory tekstu**: Wiele edytorów, takich jak VS Code, Sublime Text, czy Notepad++, wspiera regex do wyszukiwania i zamiany tekstu.

## Porady i Dobre Praktyki
- **Czytelność**: Regex może być trudny do odczytania, więc staraj się pisać go w sposób możliwie przejrzysty. Używaj komentarzy, jeśli to możliwe.
- **Testowanie**: Przetestuj swoje wyrażenia regularne na przykładach, aby upewnić się, że działają zgodnie z oczekiwaniami.
- **Unikaj nadmiernego dopasowywania**: Regex może czasem dopasować więcej niż oczekiwano. Sprawdzaj, czy nie wychodzi poza pożądany zakres.

Spoko kurs: [regexone.com](https://regexone.com/)

---

## Zadania

### 0. Wyszukiwanie hashtagów i użytkowników

**Znajdowanie wyrazów zaczynających się od `#` lub `@`**

Popularne hashtagi na naszej platformie to: #programowanie, #Python3, #Nowosc2024, a także ogólne tematy takie jak #AI i #Nauka. Użytkownicy często używają oznaczeń, takich jak @AnnaNowak, @john123, @dev_team, oraz @PiotrW. Ważne jest, aby oznaczenia były poprawne – niektóre z błędnych przykładów to: @@double (zbyt wiele znaków '@'), # (sam znak bez żadnego wyrazu), @!user (znak specjalny po @), oraz @123#tag (nieprawidłowe znaki po @). Warto też zwrócić uwagę na oznaczenia w środku zdania, takie jak tekst@mention (brak spacji przed znakiem @), #Java@2024 (mieszanie # i @), czy @@admin (dwa znaki @).
Podczas wyszukiwania hashtagów, musimy także ignorować przypadki, gdzie znaki @ lub # są częścią innych słów, np.: email@example.com (adres e-mail, a nie oznaczenie), C#language (nazwa języka), hasz#niepoprawny (znak # w środku wyrazu). Poprawne oznaczenia powinny znajdować się na początku i być poprawnie zbudowane, np.: #NowyProjekt, @Uzytkownik123, #WydarzenieRoku, @SuperTeam2024.
Zwróć uwagę na więcej fałszywych przykładów: abc@john_doe (znak @ w środku wyrazu), #123start (hashtag zaczynający się od cyfry – akceptowalny tylko jako całość), tekst przed @mention, tekst#tag, znak przed #hashtag oraz dodatkowe znaki jak #!notValid, @!@, @use_r123, #12!. Poprawne hashtagi i oznaczenia użytkowników muszą spełniać wymagania dotyczące formatu, takie jak: #Valid_Tag, @correctUser, #2024Update, @Projekt123.

### 1. Dopasowanie poprawnych kodów pocztowych

**Stwórz wyrażenie regularne, które dopasuje polskie kody pocztowe w formacie `00-000`**

Nasze placówki znajdują się w miastach: Warszawa 00-001, Kraków 30-002, Wrocław 50-345, Łódź 90-234, Gdańsk 80-123, Poznań 61-800. Jednak błędne kody, które mogą wyglądać podobnie, to: 000-123 (zły format), 123456 (brak myślnika), kod typu '800123' (nieprawidłowa liczba cyfr), zbyt krótki kod '12-345', oraz nierealistyczny kod '50-ABC'. Kod '12-A34' także nie spełnia kryteriów polskich kodów pocztowych.

### 2. Wyszukaj wszystkie adresy e-mail

**Napisz wyrażenie regularne, które dopasowuje dowolny poprawny adres e-mail, zawierający przedział liter, cyfr, kropkę oraz znak @**

Jeśli masz pytania dotyczące produktów, możesz skontaktować się z nami pod adresem kontakt@firma.pl. Nasze wsparcie techniczne odpowiada również na wiadomości wysłane na adres support@techcorp.com. Jeśli potrzebujesz porady, napisz na adres admin@serwer.edu.pl. Możesz także użyć alternatywnego formatu adresu: support(at)firma(dot)pl. Dla naszych partnerów biznesowych mamy specjalny adres partner@firma-partners.eu, a dla spraw marketingowych: marketing@firma-advert.com. Skontaktuj się z nami również na info@mojafirma.com lub office(at)naszafirma(dot)net. Ważne, abyś nie wysyłał maili na kontakt.com (to jest strona internetowa, nie adres e-mail). Wiele osób popełnia ten błąd pisząc coś@zła-nazwa@domena.com, co również nie jest poprawnym adresem. Pamiętaj także, że customer_service.com to portal obsługi, a nie e-mail.

### 3. Znalezienie numerów telefonów w formacie międzynarodowym

**Utwórz wyrażenie regularne, które znajdzie wszystkie numery telefonów w formacie międzynarodowym, np. `+48 123-456-789` lub `+123 58 123-23-11`**

Nasze biuro międzynarodowe można osiągnąć pod numerami: +48 123-456-789, +1 800-123-4567, +44 207-9876-5432, +91 22-3456-7890, +39 06-1234-5678 oraz +353 1 234-5678. Z kolei nasze biuro w Kanadzie odbiera połączenia pod numerem +1 647 123 4567. Błędne numery to: +99 1234-5678-900 (zbyt długa sekwencja), ++48 123456789 (podwójny plus), brakujące segmenty jak: +12-12-1234. Są także błędne numery takie jak +4820-555-1234 (zbyt dużo cyfr po kierunkowym), (bez plusa) 1 212-345-6789, oraz +12345-67890 (zbyt krótki kod kraju). Numery typu (123) 456-789 czy 123-456-789 nie są w międzynarodowym formacie.

### 4. Sprawdzenie formatu daty

**Napisz wyrażenie regularne, które sprawdzi, czy dana data jest w formacie `DD/MM/RRRR` lub `DD-MM-RRRR`**

Planowane terminy wydarzeń to 15/08/2024, 30-11-2024, a także ważna data to 01/12/2025. Rejestracja jest możliwa do 25/12/2024. Przykłady pozornie poprawnych dat to: 15.08.2024, 30.11.2024 (brak wymaganych separatorów '/'). Wprowadzające w błąd mogą być także daty typu 5/5/24 (zbyt krótki format), 2024-05-05 (format ISO, a nie DD/MM/RRRR), 13/13/2024 (niepoprawny miesiąc), oraz 30-Feb-2025, gdzie luty nigdy nie ma 30 dni. Daty takie jak 00-00-0000 są również nieprawidłowe.

### 5. Wyszukaj wszystkie adresy IP

**Utwórz wyrażenie regularne, które dopasuje dowolny poprawny adres IPv4, np. `192.168.1.1`**

Nasze serwery pracują pod adresami IP: 192.168.1.1, 10.0.0.2, 203.0.113.5, a także zewnętrzny serwer 198.51.100.20. Przykłady błędnych adresów IP to: 192.168.300.1 (liczby poza zakresem), 256.256.256.256, adres z brakującym segmentem jak 192.168.1., za dużo segmentów: 10.0.0.1.5, oraz mieszany format: 10:0:0:1. Adresy IPv6 takie jak fe80::1 nie pasują do wzorca IPv4. Przykłady z błędnymi separatorami: 10-0-0-1 również nie spełniają wymogów.

**Napisz wyrażenie regularne, które znajdzie wszystkie poprawne adresy IPv6  np. `2001:4860:4860::8888`**

Nasza infrastruktura sieciowa obsługuje wiele różnych adresów IP. Przykłady prawidłowych adresów IPv6 to: 2001:0db8:85a3:0000:0000:8a2e:0370:7334, 2001:db8:85a3::8a2e:370:7334 (skrócony zapis), oraz fe80::1ff:fe23:4567:890a (adres lokalny). Adresy takie jak ::1 (pętla zwrotna) również są poprawne.
Niektóre przykłady błędnych adresów to: 12345:db8:85a3::8a2e (zbyt długa grupa), fe80:::1 (zbyt wiele dwukropków), 2001::85a3::8a2e (więcej niż jeden podwójny dwukropek), oraz 2001:db8:85a3:8a2e:370 (zbyt mało grup). Adresy IPv6 mogą także zawierać liczby w zakresie od 0 do f, ale przykłady takie jak 2001:db8:85a3:zzzz:0000:8a2e:0370:7334 (niewłaściwy znak 'z') nie są akceptowalne.
Dodatkowo, niektóre fałszywe adresy IPv4 są mylone z IPv6: 192.168.1.1, 10.0.0.255, a także mieszane formaty, np. 2001:db8::123.456.789.012 (niepoprawny segment IPv4). Ważne jest, aby zignorować też takie sekwencje jak 'IPv6_address: 2001:db8::85a3' (poprzedzone tekstem) oraz adres: fe80:: (niepełny adres). Prawidłowe adresy IPv6 mogą mieć różne długości, na przykład: 1234:5678:9abc:def0:1234:5678:9abc:def0, ::ffff:192.168.1.1 (kompatybilny z IPv4), oraz 2001:db8::1:0:0:1.

### 6. Znalezienie słów zaczynających się na "A"

**Stwórz wyrażenie regularne, które znajdzie wszystkie słowa rozpoczynające się na literę "A" _(bez względu na wielkość litery)_**

Adam, Ania oraz Artur odwiedzili Amfiteatr w Atenach. Andrzej także dołączył, by cieszyć się atmosferą artystycznych występów. Warto zauważyć słowa takie jak: 'atencja', 'androgyniczny', które pozornie zaczynają się na A, ale mają inne znaczenie. Słowa takie jak 'oaza', 'awanse', 'ekspansja' nie spełniają kryteriów, ponieważ nie zaczynają się na tę literę. Również 'agencja' może wydawać się odpowiednie, ale nie pasuje do wzorca.

### 7. Wyszukaj tylko wyrazy złożone z cyfr

**Napisz wyrażenie regularne, które dopasuje wyłącznie wyrazy składające się z samych cyfr, bez znaków specjalnych i liter**

"Podane numery to: 123456789, 987654321, 456789012, 123123123, 456456456, 789789789. Numery takie jak 'ABC123' lub '123-456' zawierają inne znaki i nie pasują do wzorca. Podobnie 'num_12345', '1234xyz', czy '#123456' zawierają dodatkowe litery lub znaki specjalne. Numery typu '001 122', które zawierają spacje, także są niepoprawne."

### 8. Dopasowanie wyrazów o określonej długości

**Utwórz wyrażenie regularne, które znajdzie wyrazy mające dokładnie 5 liter, niezależnie od rodzaju liter _(małe/wielkie)_**

Kwiaty, książka, kamień, droga, lampa, piasek. Te wszystkie wyrazy mają dokładnie pięć liter. Jednak słowa takie jak 'krzesło' (7 liter), 'światło' (7 liter), 'okienko' (8 liter) nie spełniają wymogów. Słowa typu 'most' (4 litery) lub 'morze' (5 liter, ale inne znaczenie) również nie są odpowiednie. Tylko dokładnie pięcioliterowe słowa spełniają wymagania."

### 9. Wyszukiwanie tagów HTML

**Stwórz wyrażenie regularne, które znajdzie wszystkie otwierające i zamykające tagi HTML, np. `<div>` oraz `</div>`**

      W dokumencie HTML znajdziesz elementy takie jak: <html>, <head>, <title>Tytuł strony</title>, <body>, <div class='content'>Treść główna</div>, <h1>Nagłówek 1</h1>, <p>To jest paragraf tekstu</p>, <a href='link.html'>Link</a>, <span>Kolejny element</span>, <footer>Stopka</footer>. Przykłady błędnych tagów to: <img /src='image.png'> (błędny zapis), <span <p> (niepoprawna struktura), brak zamykającego tagu <div class='open', oraz dodatkowe znaki w tagu <footer/>. Tylko poprawne, kompletne struktury HTML będą pasować do wyrażenia.

### 10. Walidacja hasła

**Napisz wyrażenie regularne, które sprawdzi, czy hasło spełnia wymagania: przynajmniej 8 znaków, jedna duża litera, jedna cyfra oraz jeden znak specjalny _(np. `!`, `@`, `#`)_**

Przykłady haseł: P@ssw0rd123!, Moje_Haslo!456, S3kr3t!, Bezpieczne#Haslo2024, Trudn3!Hasło_88, !S1lneHasl0, 1234Pass#Secure, #Mega$trong123, H@sło2025!, W1elki@H4cker. Wiele z tych haseł spełnia wymagania, ale niektóre mają braki: 'NieHasłoBezZnaków' (brak znaków specjalnych), 'Password123' (brak znaku specjalnego), 'Trudne-Haslo' (brak cyfr), 'P4ssword!' (brak dużej litery), '@hasloBezCyfry' (brak cyfry). Hasła takie jak 'silne#Haslo2024' spełniają większość wymogów, ale mogą być zbyt przewidywalne.
