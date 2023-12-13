EXTERNAL Changematerials(value)
EXTERNAL Changefood(value)
EXTERNAL Changetroops(value)
EXTERNAL ChangeVillagerMorale(value, Name)
VAR troops = 10

->START

== START ==
Big Bass

Oscar: “Mayor. Big bass has shown up in the river. Been eating all the fish. Could even call it a boss. Need to do something about it.”

->CHOICES

== CHOICES ==

 * [Fight Bass.] ->FIGHT
 * [Fish for Bass.] ->FISH
 * [Do nothing.] ->DO_NOTHING

== FIGHT ==
{troops >= 5: ->Win | {troops < 5: ->Lose}}

== Win ==
“Hm. That’s a lot of food. Good work.”
~ Changefood(10)
~ ChangeVillagerMorale(5, "Oscar")
# +5% Oscar Morale, +10 Food
->END

== Lose ==
“That’s a setback.”
~ Changefood(-10)
~ Changetroops(-3)
~ ChangeVillagerMorale(-5, "Oscar")
# -5% Oscar Morale, -3 Troops, -10 Food
->END

== FISH ==
“We got it. Ate up all our damn bait but we got it."
~ Changefood(5)
~ ChangeVillagerMorale(2, "Oscar")
# +2% Oscar Morale, +5 food
->END

== DO_NOTHING ==
“Bloody fish ate up all the fish for a whole week. Even destroyed a portion of the docks, have to fix it. Finally gone though.”
~ Changefood(-10)
~ Changematerials(-5)
~ ChangeVillagerMorale(-5, "Oscar")
# -10 Food. -5 Materials, and -5% Oscar Morale
->END
