EXTERNAL ChangeVillagerMorale(value, Name)
EXTERNAL ChangeBuildingProduction(value, Name)

->START

== START ==
#speaker: Roe #portrait: Roe
“Hey Mayor uh… I have something to tell you. Nothing bad! Just that I’m part Rock Imp… PLEASE DON’T HATE ME. I’m cousins with the kobolds that come to town to give food too.”

#speaker: Narrator #portrait: Default
What do you do?

->CHOICES

== CHOICES ==

 * [Tell him you accept him.] ->Accept
 * [Accept him and help him tell others.] ->Accept_and_help
 * [Tell him you don’t care.] ->Dont_care

== Accept ==
#speaker: Roe #portrait: Roe
“Thanks Mayor, have some dirt cakes for being so nice!”
~ ChangeVillagerMorale(2, "Roe")
~ ChangeBuildingProduction(1, "Mine")

->END

== Accept_and_help ==
#speaker: Roe #portrait: Roe
“That actually means a lot, I’ll give you my favorite rock for being so nice. His name is Bombabombo and he likes to eat gravel like ME!”
~ ChangeVillagerMorale(5, "Roe")
~ ChangeBuildingProduction(2, "Mine")

->END

== Dont_care ==
#speaker: Roe #portrait: Roe
“Oh uh sorry for saying anything then…”
~ ChangeVillagerMorale(-5, "Roe")
~ ChangeBuildingProduction(-1, "Mine")

->END