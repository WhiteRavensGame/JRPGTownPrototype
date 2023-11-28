EXTERNAL Changefood(value)
EXTERNAL ChangeLorraineMorale(value)
EXTERNAL Changetroops(value)
EXTERNAL Changegold(value)
EXTERNAL Changemorale(value)

-> Start

== Start ==
Lorraine: "Hey youngun, there’s a group of farmers at the gate. Those poor fellows had their homes destroyed by a pack of orcs and was wondering if we could let them stay for a few nights."
"Maybe you should go talk with them and decide whether to let them or not, and also to know what was going on with the orcs."

-> Choices

== Choices ==
 * [Help them] -> Help
 * [Don't help] -> No_Help
 * [Investigate the incident] -> Ask
 #Need 25 Food

== Help ==
Out of sympathy, you let them stay for a few nights for free, and they are full of gratitude
~ ChangeLorraineMorale(5)
~ Changefood(-10)
~ Changemorale(2)
->END

== No_Help ==
At this critical time when the two kingdoms are at the brink of war, there really is no spare resources to share with outsiders. Thus, despite that they may not last long out there, they can’t stay in the village
~ ChangeLorraineMorale(-5)
->END   

== Ask ==
You ask the farmers to describe the traits of the orcs and how they invaded their farms. With the descriptions from them, you are eventually able to track down the orcs.
*[Fight the  orcs] -> Orcs
*[Don' fight] -> No_fight
->END 

== Orcs ==
You got out to challenge the orcs in a hard battle against them.
*[Win] -> Win
*[Lose] -> Lose
->END

== No_fight == 
You decide to not battle the orcs due to their overwhelming strength.
~ ChangeLorraineMorale(-5)
->END

== Win ==
You win against the orcs, regaining the farmers food but also the orc's wealth.
#+25 Food, and +500 Weath
~ Changefood(25)
~ Changegold(500)
~ Changemorale(2)
->END

== Lose ==
You lose troops during the battle against the orcs.
#-5 troops
~ Changetroops(-5)
~ Changemorale(-2)
->END