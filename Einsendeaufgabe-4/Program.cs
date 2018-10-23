//Aufgabenstellung:
/*  Erstellen Sie eine „Lagerverwaltung“, die folgende Daten für Kisten speichern kann:
•	eine eindeutige Nummer zur Identifikation jeder einzelnen Kiste,
•	die Breite, Länge und Höhe jeder Kiste sowie
•	das Volumen der Kiste.
Die Nummer zur Identifikation der Kiste können Sie nach einem beliebigen Schema selbst vergeben. Stellen Sie aber durch geeignete Verfahren sicher, dass bei der Eingabe 
einer neuen Kiste nicht eine bereits vergebene Nummer benutzt wird.
Das Volumen der Kiste soll automatisch vom Programm anhand der Breite, Länge und Höhe berechnet werden können.
Das Programm soll maximal Daten von 75 Kisten verwalten können und folgende Funktionen anbieten:
•	Eingabe einer neuen Kiste,
•	Löschen der Daten einer vorhandenen Kiste,
•	Ändern der Daten einer vorhandenen Kiste,
•	Anzeigen der Daten einer vorhandenen Kiste und
•	eine Listenfunktion, die die Daten aller vorhandenen Kisten anzeigt.
    Beim Löschen, Ändern und Anzeigen soll der Zugriff auf die Daten der Kiste über die Nummer der Kiste erfolgen.
    Für die Umsetzung gelten folgende Vorgaben:
•	Speichern Sie die Daten in einer Struktur und legen Sie ein Array in der erforderlichen Größe für diese Struktur an. Erstellen Sie dieses Array lokal in der Methode Main(). 
    Verwenden Sie keine Klassenvariable.
•	Stellen Sie sicher, dass beim Zugriff auf die Daten der Kisten die Arraygrenzen nicht verlassen werden.
•	Erstellen Sie für das Eingeben, Löschen, Ändern, Anzeigen und Auflisten jeweils eigene Methoden.
•	Sorgen Sie dafür, dass beim Löschen, Ändern, Anzeigen und Auflisten nur auf Einträge zugegriffen werden kann, für die bereits Daten erfasst wurden. 
    Dazu können Sie zum Beispiel beim Start des Programms die Nummer jeder Kiste zunächst auf den Wert 0 setzen und beim Zugriff überprüfen, ob die Nummer der Kiste noch den Wert 0 hat. 
    Um eine Kiste zu löschen, reicht es dann, die Nummer der Kiste wieder auf den Wert 0 zu setzen.
•	Erstellen Sie in der Methode Main() ein Auswahlmenü für den Zugriff auf die einzelnen Funktionen der Lagerverwaltung. 
*/
/* ######################################################
Einsendeaufgabe 4
###################################################### */
using System;

namespace Einsendeaufgabe_4
{
    class Program
    {

        struct Box {
            public int id;
            public int width;
            public int height;
            public int depth;
            public int volume;
        }

        static int Volume(int w, int h, int d) {
            return w * h * d;

        }

        //Methode zur Prüfung ob eine Kiste existiert. Erspart Tipparbeit.
        static int DoesExist(int crateNumber, Box[] crateArray){
            if (crateNumber > 74){
                // Um einen Überlauf vorzubeugen wird hier geprüft, ob die Eingabe größer als das Array ist, wenn ja wird -1 zurück gegeben.
                return -1;
            }
            if (crateArray[crateNumber].id == 0){
                //Wenn der Eintrag im Array leer ist, gib 0 zurück
                return 0;

            }else{
                //ansonsten gib 1 zurück
                return 1;
            }
        }

        static int InputNumber() {
            bool correct = false;
            int input = 0;
            while (correct == false)
            {
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                    correct = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Geben Sie bitte eine Ganzzahl ein! ");
                }
            }
           return input;
        }
        static void AddBox(Box[]crateArray) {
            
        }

        static void DeleteBox(Box[]crateArray) {

        }

        static void EditBox(Box[]crateArray) {

        }

        static void DisplayBox(Box[]crateArray){
            Console.WriteLine("Geben Sie die Nummer der Box ein, die Sie betrachten möchten: ");
            InputNumber();

        }

        static void ListCrates(Box[] crateArray){
            int counter = 0;
            while (crateArray[counter].id != 0){
                counter++;
            }

            for (int i = 0; i <= counter; i++){
                Console.WriteLine("Kiste mit ID: {0}", crateArray[i].id);
                Console.WriteLine("Breite: {0}", crateArray[i].width);
                Console.WriteLine("Höhe: {0}", crateArray[i].height);
                Console.WriteLine("Tiefe: {0}", crateArray[i].depth);
                Console.WriteLine("Volumen: {0}", crateArray[i].depth);
                Console.WriteLine();
            }

        }

       
        static int cratesID = 1;

        static void Main(string[] args)
        {
            //Array für die Lagerverwaltung erstellen
            Box[] crates = new Box[75];

            //Alle Ids der Kisten auf 0 setzen
            for (int i = 0; i < crates.Length; i++) {
                crates[i].id = 0;
            }



            
        }
    }
}
