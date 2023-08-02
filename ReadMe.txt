Programmet skall göras ”vackrare” genom utförande av refaktorisering på lämpliga delar.
Kursbokens ideer om
• Namngivning
• Funktioner/metoder
• Kommentarer
• Klasser
• Felhantering
• Clean tests

Programmets olika skikt som sköter
• Användargränssnitt
• Programlogik
• Statistikinsamling/redovisning
skall separeras och delarna skall inte känna till annat om de andra delarna än ett interface och skall
använda Dependency Injection för sammansättning av delarna. Konkret objektskapande och
sammansättning av delarna kan skötas med manuell kod i mainmetoden/klassen.

	

