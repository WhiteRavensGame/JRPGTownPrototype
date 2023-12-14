EXTERNAL Changematerials(value)
EXTERNAL Changefood(value)
EXTERNAL Changetroops(value)
EXTERNAL Changegold(value)

VAR food = 10
VAR material = 10

-> Start

== Start ==
#speaker: Narrator  #portrait: Default
A band of heroes have come to stay in Steadville, they search for quests and for weapons.
#speaker: Adelaine  #portrait: Adelaine
"Mayor! A group of adventurers have come to stay in ⁸Steadville, they are searching for work and weapons."
 


-> Choices

== Choices ==
 * {food > 4} [Keep them in town.] -> Keep
 * {material > 4} [Direct them to the blacksmith.] -> Direct
 * [Tell them to leave.] -> Turn_down

== Keep ==
#speaker: Narrator  #portrait: Default
You let them stay in the Inn and in return they vow to protect your town should harm come to it.
~ Changefood(-5)
~ Changetroops(2)

->END

== Direct ==
#speaker: Narrator  #portrait: Default
They give Adelaine all their business, they sharpen their swords and fix their armor and leave that day.
~ Changematerials(-5)
~ Changegold(250)

->END

== Turn_down ==
#speaker: Narrator  #portrait: Default
They're respectful of your choice and leave immediately.
# you don't gain or lose anything
->END