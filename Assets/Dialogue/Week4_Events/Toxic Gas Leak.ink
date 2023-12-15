EXTERNAL Changegold(value)
EXTERNAL Changematerials(value)
EXTERNAL ChangeVillagerMorale(value, Name)
EXTERNAL Changecitizens(value)
VAR gold = 500

->START

== START ==
#speaker: Roe #portrait: Roe
“BOSSSSS!!!! We have a real BIG problem. There was a toxic gas leak we luckily moved away from when it was uncovered, but we need to make a decision fast on what to do!”

->CHOICES

== CHOICES ==

 * {gold > 499} [Invest in safety equipment.] ->Invest
 # Need at least 500 gold
 * {gold > 249} [Ventilate the mine shaft.] ->Ventilate
 # Need at least 250 gold
 * [Seal the mine shaft] ->Seal

== Invest ==
#speaker: Roe #portrait: Roe
“Boss y’know I like the helmets and the safety gear but it really gets in the way of my dirt munching. But thanks anyways!”
~ Changegold(-500)
~ Changematerials(-10)
~ ChangeVillagerMorale(-2, "Roe")
->END

== Ventilate ==
#speaker: Roe #portrait: Roe
“It smells much better in here now Boss even though I love the smell of the earth too. One guy liked the gas smell though and keeled over earlier but that’s ok.”
~ Changegold(-500)
~ Changecitizens(-1)
->END

== Seal ==
#speaker: Roe #portrait: Roe
“Boss whyyyyyyyy. They start crying. I know we found some danger but I felt we were on the road to greatness by going in that direction! Ah fine I’ll dig somewhere else.”
~ Changematerials(-5)
~ ChangeVillagerMorale(-5, "Roe")
->END