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
Heute habe ich mit der Erweiterung für grosse Ganzzahlen (uExdInt) angefangen. Das Ziel ist es, mit sehr grossen Zahlen zu arbeiten, die über die normalen Integer-Datentypen hinausgehen. Im Code habe ich eine Methode zur Addition solcher grossen Zahlen implementiert.

Die grösste Herausforderung war das Handling der Vorkommastellen, insbesondere bei der Berechnung und Formatierung der Ergebnisse. Die Methode verwendet eine benutzerdefinierte Struktur, uIntWithPadding, um sicherzustellen, dass jede Zifferngruppe korrekt formatiert wird, einschliesslich der Zero-Padding, um die korrekte Anzahl an Stellen beizubehalten.

Ich stiess auf ein Problem beim Umgang mit dem Padding in der +-Operatorüberladung, insbesondere beim Berechnen und Hinzufügen der Werte. Das Padding und die korrekte Berechnung der Ziffern waren nicht immer korrekt. Es war schwierig, sicherzustellen, dass die Darstellung und die Berechnungen für sehr grosse Zahlen präzise sind. Ausserdem gab es Fehler im ToString-Format der uIntWithPadding-Struktur, die die Darstellung der Vorkommastellen beeinflussten.

Ich habe die Implementierung mit Console.WriteLine-Ausgaben getestet, um die Werte der uIntWithPadding-Struktur zu überprüfen und den Fehler zu lokalisieren. Der nächste Schritt wird sein, die Berechnungen zu korrigieren und sicherzustellen, dass die Padding-Logik die korrekte Anzahl an Dezimalstellen darstellt.

##23.08.2024
- [ ] Addition bugfixen
- [x] IComparable<ExdInt>, IEquatable<ExdInt> hinzufügen
- [x] Supbraktion mit postiven zahle wo a grösser ist als b zufüge
- [ ] Supbraktion bugfixen

Heute habe ich mit der Erweiterung für grosse Ganzzahlen (uExdInt) weitergemacht und einige wichtige Fortschritte erzielt. Zunächst habe ich die Interfaces IComparable<ExdInt> und IEquatable<ExdInt> implementiert, um die Vergleichbarkeit und Gleichheit von grossen Ganzzahlen zu ermöglichen. Diese Implementierungen sind entscheidend, um uExdInt-Objekte in Collections zu verwenden und einfache Vergleichsoperationen durchzuführen. Ein weiterer Meilenstein war die Implementierung der Subtraktion für Fälle, in denen der Minuend grösser ist als der Subtrahend. Diese Operation funktioniert nun korrekt für positive Zahlen.

Allerdings sind bei der Subtraktion einige Fehler aufgetreten, die ich im nächsten Schritt beheben muss. Insbesondere die Handhabung von Überträgen und das korrekte Abziehen von Ziffern führen noch zu unerwarteten Ergebnissen. Daher werde ich mich darauf konzentrieren, diese Probleme zu lösen und sicherzustellen, dass die Subtraktion genauso robust wie die Addition funktioniert.
## 
30.08.2024
- [ ] Addition bugfixen
- [ ] Supbraktion bugfixen
- [ ] Multiplikation
- [ ] Multiplikation bugfixen

Heute habe ich am PromilleRechner aus Modul 320 weitergearbeitet und wichtige Fortschritte erzielt. Zunächst habe ich mehrere Fehler behoben, die sich auf die Berechnung des Alkoholabbaus ausgewirkt haben. Ausserdem habe ich die Klasse "Sprüche" überarbeitet, um benutzerdefinierte Nachrichten je nach Promillewert auszugeben. Ein weiterer Schwerpunkt war die Verbesserung der Berechnung der Promillewerte, sodass nun genauere Ergebnisse erzielt werden können. Es gab einige Herausforderungen bei der Implementierung der Formeln. Link zum PromilleRechner-Repo --> https://github.com/ascii-phoenix/PromilleRechner

06.09.2024
- [x] Addition bugfixen
- [x] Supbraktion bugfixen
- [x] Multiplikation
- [ ] Multiplikation bugfixen

Heute habe ich die Arbeit an der Erweiterung für große Ganzzahlen (uExdInt) fortgesetzt und einige bedeutende Fortschritte erzielt.
Ich habe die Rechenfehler bei der Addition und Subtraktion behoben. Hierzu zählte beispielsweise die korrekte Behandlung negativer Zahlen.
Die Implementierung der Multiplikation ist noch in Arbeit. Bisherige Ergebnisse entsprechen noch nicht den Erwartungen. Ich werde mich in den nächsten Schritten auf die Ursachenforschung und die Optimierung konzentrieren.

13.09.2024
- [ ] Multiplikation bugfixen
- [ ] Division Implemetiren als bruch
- [ ] Division bei output
- [ ] Division Bugfix

Heute habe ich mit meinem neuen Raspberry
