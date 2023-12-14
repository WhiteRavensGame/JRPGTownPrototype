EXTERNAL Changegold(value)
EXTERNAL Changetroops(value)
EXTERNAL Changefood(value)
EXTERNAL Changematerials(value)
VAR food = 50
VAR troops = 50

-> Start

== Start ==
#speaker: Roe #portrait: Roe
"MAYOR!! The mines! They’ve been breached by goblins! I can’t mine with them here, what should we do?"

-> Choices

== Choices ==
 * [Send Soldiers.] -> Send_Soldiers
 * [Don't send soldiers.] -> Dont_Send
 * [Lead away from village.] -> Lead_Away
 #Need 10 Food

== Send_Soldiers ==
#speaker: Narrator #portrait: Default
"You have an EASY encounter with goblins and send 5 soldiers."
* [Win] -> Win
* [Lose] -> Lose

== Dont_Send ==
#speaker: Narrator #portrait: Default
"The goblins continue hurting the mines."
~ Changematerials(-25)
#-25 Materials
->END

== Lead_Away == 
{food <= 10: ->Choices}
#speaker: Narrator #portrait: Default
"You lead the goblins away from the mines using food. But you are now safe from goblins."
~ Changefood(-10)
#-10 Food
->END

== Win ==
{troops >= 5: ->Win}
#speaker: Narrator #portrait: Default
"You win the battle against the goblins."
~ Changegold(100)
#+100 Gold
->END

== Lose ==
{troops < 5: ->Lose}
#speaker: Narrator #portrait: Default
"You lose 5 citizens."
~ Changetroops(-5)
~ Changematerials(-25)
#-5 troops & -25 materials
->END