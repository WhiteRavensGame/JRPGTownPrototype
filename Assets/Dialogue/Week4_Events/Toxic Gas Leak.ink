EXTERNAL Changegold(value)
EXTERNAL Changematerials(value)
EXTERNAL ChangeVillagerMorale(value, Name)
EXTERNAL Changecitizens(value)
VAR gold = 500

->START

== START ==
Toxic Gas Leak

Roe:
“BOSSSSS!!!! We have a real BIG problem. There was a toxic gas leak we luckily moved away from when it was uncovered, but we need to make a decision fast on what to do!”

->CHOICES

== CHOICES ==

 * [Invest in safety equipment (If player has 500 Gold).] ->Invest
 # Need at least 500 gold
 * [Ventilate the mine shaft (If player has 250 Gold).] ->Ventilate
 # Need at least 250 gold
 * [Seal the mine shaft] ->Seal

== Invest ==
{gold < 500: ->CHOICES}
“Boss y’know I like the helmets and the safety gear but it really gets in the way of my dirt munching. But thanks anyways!”
~ Changegold(-500)
~ Changematerials(-10)
~ ChangeVillagerMorale(-2, "Roe")
->END

== Ventilate ==
{gold < 250: ->CHOICES}
“It smells much better in here now Boss even though I love the smell of the earth too. One guy liked the gas smell though and keeled over earlier but that’s ok.”
~ Changegold(-500)
~ Changecitizens(-1)
->END

== Seal ==
“Boss whyyyyyyyy. He starts crying. I know we found some danger but I felt we were on the road to greatness by going in that direction! Ah fine I’ll dig somewhere else.”
~ Changematerials(-5)
~ ChangeVillagerMorale(-5, "Roe")
->END