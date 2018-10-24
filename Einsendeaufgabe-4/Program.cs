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

        static int cratesCounter = 0;

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
                    if (input > 0)
                    {
                        correct = true;
                    } else{
                        Console.WriteLine("Bitte geben Sie eine Zahl größer als 0 ein!");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Geben Sie bitte eine Ganzzahl ein! ");
                }
            }
           return input;
        }

        static int InputID(Box[]crateArray){
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
            return selection;
        }


        static void AddBox(Box[]crateArray) {
            int localCounter = 0;
            while(crateArray[localCounter].id != 0){
                localCounter++;
            }
            crateArray[localCounter].id = localCounter + 1;
            Console.WriteLine("Neue Kiste mit ID {0} erstellen.",crateArray[localCounter].id);

            Console.WriteLine("Bitte Maße eingeben: ");
           
            Console.Write("Breite: ");
            crateArray[localCounter].width = InputNumber();

            Console.Write("Höhe: ");
            crateArray[localCounter].height = InputNumber();

            Console.Write("Tiefe: ");
            crateArray[localCounter].depth = InputNumber();

            crateArray[localCounter].volume = Volume(crateArray[localCounter].width, crateArray[localCounter].height, crateArray[localCounter].depth);
            Console.WriteLine("Das errechnete Volumen ist: {0}", crateArray[localCounter].volume);
            cratesCounter++;
            Console.ReadKey();

        }

        static void DeleteBox(Box[]crateArray) {
            if (cratesCounter > 0)
            {
                Console.Write("Geben Sie die ID der Kiste ein, die Sie löschen möchten: ");
                int selection = InputID(crateArray);

                crateArray[selection].id = 0;
                crateArray[selection].width = 0;
                crateArray[selection].height = 0;
                crateArray[selection].depth = 0;
                crateArray[selection].volume = 0;
                Console.WriteLine("Kiste mit ID {0} gelöscht.", selection + 1);
                Console.WriteLine();
                cratesCounter--;
                Console.WriteLine("Drücken Sie eine  beliebige Taste um fortzufahren..."); 
                Console.ReadKey();
            }else{
                Console.WriteLine("Es gibt keine Kisten, die man löschen könnte");
                Console.WriteLine();
                Console.WriteLine("Drücken Sie eine  beliebige Taste um fortzufahren...");
                Console.ReadKey();
            }
        }

        static void EditBox(Box[]crateArray) {
            if (cratesCounter > 0)
            {
                Console.Write("Geben Sie die ID der Kiste ein, die Sie bearbeiten möchten: ");
                int selection = InputID(crateArray);

                Console.WriteLine("Kiste: ");
                Console.WriteLine("ID: {0}", crateArray[selection].id);
                Console.WriteLine("Breite: {0}", crateArray[selection].width);
                Console.WriteLine("Höhe: {0}", crateArray[selection].height);
                Console.WriteLine("Tiefe: {0}", crateArray[selection].depth);
                Console.WriteLine("Volumen: {0}", crateArray[selection].volume);
                Console.WriteLine();
                Console.WriteLine("Bitte neue Werte für Kiste mit ID {0} eingeben.", crateArray[selection].id);
                Console.Write("Breite: ");
                crateArray[selection].width = InputNumber();

                Console.Write("Höhe: ");
                crateArray[selection].height = InputNumber();

                Console.Write("Tiefe: ");
                crateArray[selection].depth = InputNumber();

                crateArray[selection].volume = Volume(crateArray[selection].width, crateArray[selection].height, crateArray[selection].depth);
                Console.WriteLine("Das errechnete Volumen ist: {0}", crateArray[selection].volume);
                Console.WriteLine("Bearbeitung der Kiste ID {0} beendet.", crateArray[selection].id);
                Console.WriteLine("Drücken Sie eine  beliebige Taste um fortzufahren...");
                Console.ReadKey();            
             }else{
                Console.WriteLine("Es gibt keine Kisten zum bearbeiten.");
                Console.WriteLine();
                Console.WriteLine("Drücken Sie eine  beliebige Taste um fortzufahren...");
                Console.ReadKey();
            }


        }

        static void DisplayBox(Box[]crateArray){
            if (cratesCounter > 0)
            {
                Console.Write("Geben Sie die ID der Kiste ein, die Sie betrachten möchten: ");
                int selection = InputID(crateArray);

                Console.WriteLine("Kiste: ");
                Console.WriteLine("ID: {0}", crateArray[selection].id);
                Console.WriteLine("Breite: {0}", crateArray[selection].width);
                Console.WriteLine("Höhe: {0}", crateArray[selection].height);
                Console.WriteLine("Tiefe: {0}", crateArray[selection].depth);
                Console.WriteLine("Volumen: {0}", crateArray[selection].volume);
                Console.WriteLine();
                Console.WriteLine("Drücken Sie eine  beliebige Taste um fortzufahren...");
                Console.ReadKey();            
            }else{
                Console.WriteLine("Es gibt keine Kisten, die man anzeigen könnte.");
                Console.WriteLine();
                Console.WriteLine("Drücken Sie eine  beliebige Taste um fortzufahren...");
                Console.ReadKey();
            }

        }

        static void ListAllBoxes(Box[] crateArray){
            if (cratesCounter > 0)
            {
                for (int i = 0; i < crateArray.Length; i++)
                {

                    if (crateArray[i].id != 0)
                    {
                        Console.WriteLine("Kiste mit ID: {0}", crateArray[i].id);
                        Console.WriteLine("Breite: {0}", crateArray[i].width);
                        Console.WriteLine("Höhe: {0}", crateArray[i].height);
                        Console.WriteLine("Tiefe: {0}", crateArray[i].depth);
                        Console.WriteLine("Volumen: {0}", crateArray[i].volume);
                        Console.WriteLine();
                    }
                }
                Console.WriteLine("Drücken Sie eine  beliebige Taste um fortzufahren...");
                Console.ReadKey();
            }else{
                Console.WriteLine("Es gibt keine Kisten, die man anzeigen könnte.");
                Console.WriteLine();
                Console.WriteLine("Drücken Sie eine  beliebige Taste um fortzufahren...");
                Console.ReadKey();
            }

        }


        static void DisplayMenue(){
            Console.Clear();
            Console.WriteLine("Willkommen in der elektronischen Lagerhausverwaltung.");
            Console.WriteLine("Derzeit befinden sich {0} Kisten im Lager.", cratesCounter);
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
