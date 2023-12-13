EXTERNAL Changefood(value)
EXTERNAL ChangeVillagerMorale(value, Name)
EXTERNAL Changematerials(value)
EXTERNAL Changegold(value)
EXTERNAL Changemorale(value)
VAR troops = 10

-> Start

== Start ==
Lorraine: "Hey youngun, there’s a group of farmers at the gate. Those poor fellows had their homes destroyed by a pack of orcs and was wondering if we could let them stay for a few nights."
"Maybe you should go talk with them and decide whether to let them or not, and also to know what was going on with the orcs."

-> Choices

== Choices ==
 * [Help them] -> Help
 * [Don't help] -> No_Help
 * [Engaging the orcs] -> Ask
 #Need 25 Food

== Help ==
Out of sympathy, you let them stay for a few nights for free, and they are full of gratitude
~ ChangeVillagerMorale(5, "Lorraine")
~ Changefood(-10)
~ Changemorale(2)
->END

== No_Help ==
At this critical time when the two kingdoms are at the brink of war, there really is no spare resources to share with outsiders. Thus, despite that they may not last long out there, they can’t stay in the village
~ ChangeVillagerMorale(-5, "Lorraine")
->END   

== Ask ==
You ask the farmers to describe the traits of the orcs and how they invaded their farms. With the descriptions from them, you are eventually able to track down the orcs and decide to fight a HARD battle against them.
{troops >= 15: ->Win | {troops < 15: ->Lose}}


== Win ==
You win against the orcs, regaining the farmers food and also the orc's wealth.
#+25 Food, and +500 Weath
~ Changefood(25)
~ Changegold(500)
~ Changemorale(2)
->END

== Lose ==
You lose troops during the battle against the orcs.
#-5 troops
~ Changematerials(-5)
~ Changemorale(-2)
->END