EXTERNAL Changematerials(value)
EXTERNAL Changefood(value)
EXTERNAL Changetroops(value)
EXTERNAL Changegold(value)

-> Start

== Start ==
Water Symbol (Heros)

A band of heroes have come to stay in Steadville, they search for quests and for weapons.
Blacksmith: "Mayor! A group of adventurers have come to stay in ⁸Steadville, they are searching for work and weapons."
 


-> Choices

== Choices ==
 * [Keep them in town.] -> Keep
 * [Direct them to the blacksmith.] -> Direct
 * [Tell them to leave.] -> Turn_down

== Keep ==
You let them stay in the Inn and in return they vow to protect your town should harm come to it.
~ Changefood(-5)
~ Changetroops(2)

->END

== Direct ==
They give Adelaine all their business, they sharpen their swords and fix their armor and leave that day.
~ Changematerials(-5)
~ Changegold(250)

->END

== Turn_down ==
They're respectful of your choice and leave immediately.
# you don't gain or lose anything
->END