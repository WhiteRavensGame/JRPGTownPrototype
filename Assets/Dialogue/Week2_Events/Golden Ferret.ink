EXTERNAL ChangeTavernProduction(value)
EXTERNAL Changegold(value)
EXTERNAL Changefood(value)
EXTERNAL Changematerials(value)
VAR gold = 50

->START

== START ==
Will:
“Mayor, we have a major problem in the tavern. This strange golden-looking ferret thing keeps stealing the gold the customers leave to pay! What should I do?”

->CHOICES

== CHOICES ==

 * [Help tame Ferret (1000 Gold required)] ->Tame
 * [Find its lair] ->Find
 * [Fight Ferret] ->Fight

== Tame ==
{gold >= 1000: ->Tame}
“Wow, Mayor… I usually don’t have this much gold on hand so it never came up to me in the first place. With this guy here it adds another reason for travelers to stop by!”
~ Changefood(-5)
~ Changegold(250)
~ ChangeTavernProduction(1)
# -5 food, +250 Gold, +1 Tavern Production
->END

== Find ==
“After tearing up some of the walls and floorboards, we finally found the creature’s lair that was hiding some gold, but I need some materials to fix this mess.”
~ Changegold(250)
~ Changematerials(-10)
#+250 Gold. -10 Materials
->END

== Fight ==
“The creature just ran away when we tried to fight it, I don’t think we’ll find its stash.”
#Nothing
->END