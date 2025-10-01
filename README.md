## Tower defense bo
Naam: Julian

Klas: GD2A

Datum: 08-09-2025

Trello: https://trello.com/b/aoGgXDgA/tower-defense-bo

## Titel: (TBD)
Mijn game is een tower defense game, deze zijn leuk om te spelen en ontspannen. Het is perfect na een dag werken.

## Schets van je level en UI
<img width="768" height="409" alt="concept" src="https://github.com/user-attachments/assets/4c526667-fec0-4f68-8545-61299be2903d" />

## script
```` cs
        for (int i = 0; i < targets.Length; i++) 
        {
            float distance = Vector3.Distance(transform.position, targets[i].transform.position);
            if (distance < nearestDistance) 
            {
                nearestDistance = distance;
                firepoint = targets[i].transform;
            }
        }
````
## Toren
Toren 1 Apollyon, Bereik 10 meter, schade gemiddeld, basic schieter niks speciaals
Toren 2 Atarah, Bereik 2 meter, hoge schade, shotgun achtig.
Meer komen later

## Vijanden
Vijand 1 Slime, gemiddelde snelheid, 3 levens, basic vijand
vijand 2 Necromancer, langzaam, 6 levens, maakt meer vijanden. 

## Gameplay loop
1. Start de game
2. Gebruik geld om een unit te kopen
3. maak vijanden dood met unit om meer geld te krijgen
4. koop meer units
5. maak meer vijanden dood.

## Progressie
De meer waves je doet de meer vijanden komen en hoe sterker ze worden. Je krijgt steeds meer geld als je ze dood maakt en kan daardoor sterkere towers kopen.

## Risico’s en oplossingen volgens PIO
Probleem 1: Vijanden maken
Impact hoog
Oplossing: Blijven proberen

Probleem 2: Towers maken
Impact: hoog
Oplossing: Veel videos kijken

Probleem 3: Economie
Impact: gemiddeld
Oplossing: Nog meer videos kijken

## Planning per sprint en mechanics
Sprint 1 mechanics: Towers

Sprint 2 mechanics: Vijanden

Sprint 3 mechanics: Economie

Sprint 4 mechanics: Upgrades

Sprint 5 mechanics: Bug fixes

## Inspiratie 
Bloons TD6

## Technisch ontwerp mini
Vijandbeweging over het pad
Keuze: Ze gaan van a naar b
Risico: Ze kunnen van het pad raken
Oplossing: Ze een goede route geven
Acceptatie: Ze lopen van a naar b op een goede manier

Doel kiezen en schieten
Keuze: Ze kiezen het doelwit die vooraan staat
Risico: Ze schieten geen andere vijanden tot die ene dood is zelfs als het uit range is.
Oplossing: Goed coderen
Acceptatie: Het werkt goed

Waves en spawnen
Keuze: Waves beginnen pas als iedereen dood is
Risico: checken of alles dood is
Oplossing: Check goed of iedereen dood is
Acceptatie: De wave start nadat iedereen dood is

11.4 Economie en levens
Keuze: Geld krijg je nadat je iets dood maakt
Risico: geen geld krijgen
Oplossing: goed geld geven
Acceptatie: Geld krijgen

11.5 UI basis
Keuze: geld levens en towers plaatsen
Risico: Te druk
Oplossing: rustig maken
Acceptatie: een goed overzichtelijk ui
