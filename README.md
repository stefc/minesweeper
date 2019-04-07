# Minesweeper Example


Das Riesenpuzzle 4 Jahre x 24 Puzzle => 96 für angehende C# Coder.

## Vorraussetzung

Was benötigst du um deine Fähigkeiten unter Beweis zu stellen. 

* Einen Computer (Windows oder Mac)
* Einen Editor (VSCode)
* Die .Net Core Platform (C#)
* Einen GitHub Account  


### Editor

Im folgenden gehen wir von Visual Studio Code (VSCode) als Editor aus. Es tut auch jeder andere Editor, aber mit VSCode kennen 
wir uns schon recht gut aus und wenn du Fragen in der Form hast (Wie war noch kurz das Tastenkürzel um eine Zeile auf dem Mac 
zu duplizieren?) rufst du in dem Raum und bekommst vermutlich die Antwort "Alt+Shift Cursor Down" aus drei Ecken zugerufen.
Alternativ guckst du auf die laminierte Übersicht, die du bekommen hast und die du gerne mitnehmen magst. 

Die Installationsanweisung inkl. Downloadlink findest du auf der Web-Seite https://code.visualstudio.com

### .NetCore 

Nur mit dem Editor wirst du allerdings noch kein C# Code ausführen können. Hierzu benötigst du auf dem Computer noch das 
sogenannte .NetCore Framework. Wir gehen aktuell von der Version 2.2 aus. Das wird jedoch laufend angepasst sobald neue Versionen 
released werden. 

https://dotnet.microsoft.com/download

Im VSCode wird C# über eine Extension sehr gut unterstützt. Die Extension bietet neben einem Syntax Highlighting auch Refactoring und Debugging. Die Extension heisst 'C#' und kommt direkt von Microsoft.

### Github 

Es gibt wohl keinen Programmierer der nicht ab und zu auf Beispielcode auf Github stößt. NetCore und VSCode selbst sind ebenfalls dort als OpenSource gehostet. Du benötigst ein Github Account sobald du selbst etwas in dieses Repository einchecken willst. z.B. hast du ein bisher noch nicht gelöstes Rätsel erfolgreich gelöst und möchtes das deine Lösung den Kollegen präsentieren. Das Vorgehen wäre dann das du :

1. Ein Fork von 'git@github.com:stefc/Minesweeper.git' in deinen eigenen Github Bereich ziehst.
2. Dort deine Lösung eincheckst
3. Mit einer kleinen Beschreibung einen Pull-Request beantragst
4. Wenn alles ok ist wird deine Lösung dann in das Haupt-Repo gemergt

#### Private-Public-Key Verfahren (PPKI)

Bevor es soweit ist musst du jedoch ein wenig über private und öffentliche (public) Schlüssel verstehen. 

Neben der bekannten Authentifizierung (User/Kennwort) gibt es bei git auch das Private-Public-Key  (PPK) Verfahren per SSH. Dieses ist nachdem es einmal eingerichtet ist, äußerst sicher und einfach in der Anwendung. 

Hierzu erzeugst du ein Paar von Schlüsseln. Ein Private Key den du erstellst und auf den du besonders aufpassen musst. Dieser Schlüssel 
darf in keinem Fall das Gerät auf dem du den Schlüssel erzeugt hast verlassen. Hast du weitere Geräte erzeugst du am besten pro Gerät einen neuen Schlüssel. Zu dem Privaten Key wird sofort auch ein sogenannter Public Key erzeugt (*.pub). Dieser Schlüssel kann ohne Bedenken an andere verteilt werden. z.B. auf Github hochgeladen werden. Mit dem Public Key ist jemand in Lage dir eine verschlüsselte 
Nachricht zu schicken, die nur derjenige entschlüsseln kann der im Besitz des dazugehörigen Private Keys ist.

Alles was du hierfür benötigst ist eigentlich bei einem Entwickler Rechner schon mit an Board ('git' und 'openssl').

Das folgende Kommando erzeugt soein Schlüsselpaar für dich: 

ssh-keygen -b 2048 -t rsa -f .ssh/id_stefc -q -N "" -C "stefan.boether@txs.de"

Die *2048* gibt an wieviel Bit dein Schlüssel haben soll. *rsa* Gibt das Verfahren der Verschlüsselung an. *.ssh/id_stefc* ist der Dateiname in dem der Schlüssel gespeichert wird. Der Public Key befindet sich in *id_stefc.pub*. Der letzte Parameter ist dann noch ein Kommentar für den Schlüssel, ich verwende dort immer meine EMail Adresse. 

#### Zwei Faktor Authentifizierung (2FA)

Das ist auch schon alles. Jetzt musst du nur noch einen privaten Github Account einrichten und los geht es. Übrigends auch hier ist 
es ratsam den Account abzusichern mit einer sogenannten Zwei Faktor Authentifizierung (2FA). Entweder mit einer Mobilfunknummer oder einer Authentificator App auf deinem Handy.

Der erste Faktor ist dann bei der Anmeldung nachwievor dein Benutzername und dein Kennwort. Der zweite Faktor ist dann die App oder die SMS an das Handy. Ein Unberechtigter Dritte müsste dann sowohl das Kennwort als auch das Handy in seinem Besitz haben um sich bei Github anmelden zu können. Dieses Szenario ist aber sehr unwahrscheinlich und ein Hacker müsste schon sehr viel Aufwand betreiben um an beide Faktoren zu gelangen.

Bei der Erstellung eines Github Account's und des Schlüsselpaares fragst du am besten einen Mitarbeiter, der dir dabei über die Schultern schaut. 

## Der Start 


Per 'dotnet' Befehl generieren wir uns ein Projekt. 

´´´dotnet new xunit --name minesweeper -o minesweeper

Um nachher die Struktur möglichst einfach in das Hauptprojekt mergen zu können, empfehlen wir folgende Verzeichnisstruktur einzuhalten. 

´´´
\tests
\src

´´´

Also Unittests immer im Unterverzeichnis \tests, der richtige Code in das Verzeihnis \src. 

Das Programm baust du mit dem Aufruf 'dotnet build' und mit 'dotnet test' lässt du die Test's durchlaufen. 

Die Tests sagen dir das dein Algorithmus funktioniert. 

Wichtig ist allerdings das bei einem Pullrequest immer noch alle Test's mit grün abgeschlossen sind! 