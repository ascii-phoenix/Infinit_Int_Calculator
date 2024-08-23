# Infinit Int Calculator
## Grob-Planung

1. Intiger erweiterung Erstellen
2. Zwei zahlen vergleichen
3. Addition erstellen
4. Suptration erstellen
5. Multiplikation Progrmieren
6. Division Programieren
7. sqrq adieren
8. Wurtzel?

##16.08.2024
Heute habe ich mit der Erweiterung für große Ganzzahlen (uExdInt) angefangen. Das Ziel ist es, mit sehr großen Zahlen zu arbeiten, die über die normalen Integer-Datentypen hinausgehen. Im Code habe ich eine Methode zur Addition solcher großen Zahlen implementiert.

Die größte Herausforderung war das Handling der Vorkommastellen, insbesondere bei der Berechnung und Formatierung der Ergebnisse. Die Methode verwendet eine benutzerdefinierte Struktur, uIntWithPadding, um sicherzustellen, dass jede Zifferngruppe korrekt formatiert wird, einschließlich der Zero-Padding, um die korrekte Anzahl an Stellen beizubehalten.

Ich stieß auf ein Problem beim Umgang mit dem Padding in der +-Operatorüberladung, insbesondere beim Berechnen und Hinzufügen der Werte. Das Padding und die korrekte Berechnung der Ziffern waren nicht immer korrekt. Es war schwierig, sicherzustellen, dass die Darstellung und die Berechnungen für sehr große Zahlen präzise sind. Außerdem gab es Fehler im ToString-Format der uIntWithPadding-Struktur, die die Darstellung der Vorkommastellen beeinflussten.

Ich habe die Implementierung mit Console.WriteLine-Ausgaben getestet, um die Werte der uIntWithPadding-Struktur zu überprüfen und den Fehler zu lokalisieren. Der nächste Schritt wird sein, die Berechnungen zu korrigieren und sicherzustellen, dass die Padding-Logik die korrekte Anzahl an Dezimalstellen darstellt.

##23.08.2024
- [ ] Addition bugfixen
- [x] IComparable<ExdInt>, IEquatable<ExdInt> hinzufügen
- [x] Supbraktion mit postiven zahle wo a grösser ist als b zufüge
- [ ] Supbraktion bugfixen

Heute habe ich mit der Erweiterung für große Ganzzahlen (uExdInt) weitergemacht und einige wichtige Fortschritte erzielt. Zunächst habe ich die Interfaces IComparable<ExdInt> und IEquatable<ExdInt> implementiert, um die Vergleichbarkeit und Gleichheit von großen Ganzzahlen zu ermöglichen. Diese Implementierungen sind entscheidend, um uExdInt-Objekte in Collections zu verwenden und einfache Vergleichsoperationen durchzuführen. Ein weiterer Meilenstein war die Implementierung der Subtraktion für Fälle, in denen der Minuend größer ist als der Subtrahend. Diese Operation funktioniert nun korrekt für positive Zahlen.

Allerdings sind bei der Subtraktion einige Fehler aufgetreten, die ich im nächsten Schritt beheben muss. Insbesondere die Handhabung von Überträgen und das korrekte Abziehen von Ziffern führen noch zu unerwarteten Ergebnissen. Daher werde ich mich darauf konzentrieren, diese Probleme zu lösen und sicherzustellen, dass die Subtraktion genauso robust wie die Addition funktioniert.
## 
30.08.2024
- [ ] Addition bugfixen
- [ ] Supbraktion bugfixen
- [ ] Multiplikation
- [ ] Multiplikation bugfixen
