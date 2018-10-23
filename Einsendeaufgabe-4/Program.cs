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

//TODO: Absturz bei Eingabe einer 0 verhindern!

namespace Einsendeaufgabe_4
{
    class Program
    {

        static int cratesID = 0;

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
            crateArray[cratesID].id = cratesID + 1;
            Console.WriteLine("Neue Kiste mit ID {0} erstellen.",crateArray[cratesID].id);

            Console.WriteLine("Bitte Maße eingeben: ");
           
            Console.WriteLine("Breite: ");
            crateArray[cratesID].width = InputNumber();

            Console.WriteLine("Höhe: ");
            crateArray[cratesID].height = InputNumber();

            Console.WriteLine("Tiefe: ");
            crateArray[cratesID].depth = InputNumber();

            crateArray[cratesID].volume = Volume(crateArray[cratesID].width, crateArray[cratesID].height, crateArray[cratesID].depth);
            Console.WriteLine("Das errechnete Volumen ist: {0}", crateArray[cratesID].volume);
            cratesID++;

        }

        static void DeleteBox(Box[]crateArray) {
            Console.WriteLine("Geben Sie die ID der Kiste ein, die Sie entfernen möchten: ");
            int selection = InputNumber() - 1;
            int crateExists = DoesExist(selection, crateArray);
            while (crateExists != 1)
            {
                if (crateExists == 0)
                {
                    Console.WriteLine("Die Kiste mit dieser ID existiert nicht!");
                }
                else
                {
                    Console.WriteLine("So groß ist unser Lagerhaus nicht!");
                }
                Console.WriteLine("Geben Sie eine gültige ID ein: ");
                selection = InputNumber() - 1;
                crateExists = DoesExist(selection, crateArray);
            }
            crateArray[selection].id = 0;
            crateArray[selection].width = 0;
            crateArray[selection].height = 0;
            crateArray[selection].depth = 0;
            crateArray[selection].volume = 0;
            Console.WriteLine("Kiste mit ID {0} gelöscht.", selection + 1);
            Console.WriteLine();

        }

        static void EditBox(Box[]crateArray) {

        }

        static void DisplayBox(Box[]crateArray){
            Console.WriteLine("Geben Sie die ID der Kiste ein, die Sie betrachten möchten: ");
            int selection = InputNumber() - 1;
            int crateExists = DoesExist(selection, crateArray);
            while (crateExists != 1){
                    if(crateExists == 0) {
                    Console.WriteLine("Die Kiste mit dieser ID existiert nicht!");
                    } else {
                    Console.WriteLine("So groß ist unser Lagerhaus nicht!");
                    }
                Console.WriteLine("Geben Sie eine gültige ID ein: ");
                selection = InputNumber() - 1;
                crateExists = DoesExist(selection, crateArray);
            }
            Console.WriteLine("Kiste: ");
            Console.WriteLine("ID: {0}", crateArray[selection].id);
            Console.WriteLine("Breite: {0}", crateArray[selection].width);
            Console.WriteLine("Höhe: {0}", crateArray[selection].height);
            Console.WriteLine("Tiefe: {0}", crateArray[selection].depth);
            Console.WriteLine("Volumen: {0}", crateArray[selection].volume);
            Console.WriteLine();


        }

        static void ListAllBoxes(Box[] crateArray){
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


        static void DisplayMenue(){
            Console.Clear();
            Console.WriteLine("Willkommen in der elektronischen Lagerhausverwaltung.");
            Console.WriteLine("Was möchten Sie tun?");
            Console.WriteLine("(1) Neue Kiste anlegen.");
            Console.WriteLine("(2) Vorhandene Kiste anzeigen.");
            Console.WriteLine("(3) Vorhandene Kiste bearbeiten.");
            Console.WriteLine("(4) Vorhandene Kiste löschen.");
            Console.WriteLine("(5) Alle vorhandenen Kisten anzeigen");
            Console.WriteLine("(6) Programm beenden.");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int menueSelect = 0;

            //Array für die Lagerverwaltung erstellen
            Box[] crates = new Box[75];

            //Alle Ids und Werte der Kisten auf 0 setzen.
            for (int i = 0; i < crates.Length; i++) {
                crates[i].id = 0;
                crates[i].width = 0;
                crates[i].height = 0;
                crates[i].depth = 0;
                crates[i].volume = 0;

            }


            while (menueSelect != 6){

                DisplayMenue();

                menueSelect = InputNumber();

                switch (menueSelect)
                {
                    case 1:
                        AddBox(crates);
                        break;
                    case 2:
                        DisplayBox(crates);
                        break;
                    case 3:
                        EditBox(crates);
                        break;
                    case 4:
                        DeleteBox(crates);
                        break;
                    case 5:
                        ListAllBoxes(crates);
                        break;
                    case 6:
                        break;
                    default:
                        DisplayMenue();
                        Console.WriteLine("Bitte geben Sie eine Zahl zwischen 1 und 6 ein!");
                        break;

                }

            }



        }
    }
}
