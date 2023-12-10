EXTERNAL Changematerials(value)
EXTERNAL Changemorale(value)
EXTERNAL ChangeVillagerMorale(value, Name)

->START

== START ==
Sewer Monster

Will:
“Mayor! Mayor! We have a really big problem down in the sewers! There’s some sort of creature slime creature living down there. What should we do?”

->CHOICES

== CHOICES ==

 * [Drown the monster.] ->Drawn
 * [Order troops to kill it.] ->Troops
 * [Face it in single combat.] ->Face

== Drawn ==
“Mayor, we tried pouring a bunch of water down there but it didn’t seem to do anything. I think we just have to board it up for now.”
#-10 Materials, -5% Town Morale
~ Changematerials(-10)
~ Changemorale(-5)
->END

== Troops ==
“Mayor the soldiers you sent in killed it but they ended up smelling pretty bad and need to go wash up out of town.”
~ Changemorale(-2)
->END

== Face ==
“Mayor I can’t believe you managed to fight that thing 1 on 1! That’s very impressive but you do stink so please go wash up.”
~ Changemorale(5)
~ ChangeVillagerMorale(2, "Will")
->END