# C-Sharp-Worker-Service; Model za autorov diplomski rad
Aplikacija koja kreira logove tako da podatke povlači s PostgreSQL baze podataka rađena u C# programskom jeziku na .NET Core platformi.
U bazi podataka nalaze se 4 tablice koje sadrže podatke za logove. Program se povezuje sa bazom te povlači podatke iz svake tablice, te ih sprema u listu. 
Korisnik upisuje broj ponavljanja te se logovi ispisuju svakih 100ms, sadržaj loga se bira nasumično iz prethodno kreiranih listi.
Na konzoli prikazuju se logovi obojani različitim bojama, ovisno o njihovom tipu(INFO, WARN, ERROR, itd.).
Logovi se spremaju u dvije datoteke, u prvu se spremaju svi logovi ikada kreirani te se datoteka ne briše nakon ponovnog pokretanja. 
Dok se u drugu datoteku spremaju samo logovi koji su kreirani taj dan, te je naziv datoteke datum tog dana.
