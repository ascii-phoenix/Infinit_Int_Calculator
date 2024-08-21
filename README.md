# Infinit Int Calculator
## Grob-Planung

1. Intiger erweiterung Erstellen
2. Addition erstellen
3. Suptration erstellen
4. Multiplikation Progrmieren
5. Division Programieren
6. sqrq adieren
7. Wurtzel?

##16.08.2024
Heute habe ich mit der Erweiterung für große Ganzzahlen (uExdInt) angefangen. Das Ziel ist es, mit sehr großen Zahlen zu arbeiten, die über die normalen Integer-Datentypen hinausgehen. Im Code habe ich eine Methode zur Addition solcher großen Zahlen implementiert.

Die größte Herausforderung war das Handling der Vorkommastellen, insbesondere bei der Berechnung und Formatierung der Ergebnisse. Die Methode verwendet eine benutzerdefinierte Struktur, uIntWithPadding, um sicherzustellen, dass jede Zifferngruppe korrekt formatiert wird, einschließlich der Zero-Padding, um die korrekte Anzahl an Stellen beizubehalten.

Ich stieß auf ein Problem beim Umgang mit dem Padding in der +-Operatorüberladung, insbesondere beim Berechnen und Hinzufügen der Werte. Das Padding und die korrekte Berechnung der Ziffern waren nicht immer korrekt. Es war schwierig, sicherzustellen, dass die Darstellung und die Berechnungen für sehr große Zahlen präzise sind. Außerdem gab es Fehler im ToString-Format der uIntWithPadding-Struktur, die die Darstellung der Vorkommastellen beeinflussten.

Ich habe die Implementierung mit Console.WriteLine-Ausgaben getestet, um die Werte der uIntWithPadding-Struktur zu überprüfen und den Fehler zu lokalisieren. Der nächste Schritt wird sein, die Berechnungen zu korrigieren und sicherzustellen, dass die Padding-Logik die korrekte Anzahl an Dezimalstellen darstellt.

##23.08.2024
-[ ] Addition bugfixen
-[ ] IComparable<ExdInt>, IEquatable<ExdInt> hinzufügen
-[ ] Supbraktion mit postiven zahle wo a grösser ist als b zufüge
-[ ] Supbraktion bugfixen
