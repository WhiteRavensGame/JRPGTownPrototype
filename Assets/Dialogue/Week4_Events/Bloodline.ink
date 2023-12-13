EXTERNAL ChangeVillagerMorale(value, Name)
EXTERNAL ChangeBuildingProduction(value, Name)
// Need function for mining production
->START

== START ==
Bloodline

Roe: “Hey Mayor uh… I have something to tell you. Nothing bad! Just that I’m part Rock Imp… PLEASE DON’T HATE ME. I’m cousins with the kobolds that come to town to give food too.”
What do you do?

->CHOICES

== CHOICES ==

 * [Tell him you accept him.] ->Accept
 * [Accept him and help him tell others.] ->Accept_and_help
 * [Tell him you don’t care.] ->Dont_care

== Accept ==
“Thanks Mayor, have some dirt cakes for being so nice!”
~ ChangeVillagerMorale(2, "Roe")
~ ChangeBuildingProduction(1, "Mine")
# +2% Roe Morale, +1 Mining Production
->END

== Accept_and_help ==
“That actually means a lot, I’ll give you my favorite rock for being so nice. His name is Bombabombo and he likes to eat gravel like ME!”
~ ChangeVillagerMorale(5, "Roe")
~ ChangeBuildingProduction(2, "Mine")
# +5% Roe Morale, +2 Mining Production
->END

== Dont_care ==
“Oh uh sorry for saying anything then…”
~ ChangeVillagerMorale(-5, "Roe")
~ ChangeBuildingProduction(-1, "Mine")
# -5% Roe Morale, -1 Mining Production
->END