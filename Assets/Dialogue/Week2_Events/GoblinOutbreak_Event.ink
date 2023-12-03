EXTERNAL Changegold(value)
EXTERNAL Changetroops(value)
EXTERNAL Changefood(value)
EXTERNAL Changematerials(value)

-> Start

== Start ==
Roe Kimp: "MAYOR!! The mines! They’ve been breached by goblins! I can’t mine with them here, what should we do?"

-> Choices

== Choices ==
 * [Send Soldiers.] -> Send_Soldiers
 * [Don't send soldiers] -> Dont_Send
 * [Lead away from village - Need 10 Food] -> Lead_Away
 #Need 10 Food

== Send_Soldiers ==
You have an EASY encounter with goblins and send 5 soldiers.
* [Win] -> Win
* [Lose] -> Lose

== Dont_Send ==
The goblins continue hurting the mines.
You lose 25 Materials.
~ Changematerials(-25)
#-25 Materials
->END

== Lead_Away == 
You lead the goblins away from the mines using food.
You lose 10 Food but you are now safe from goblins.
~ Changefood(-10)
#-10 Food
->END

== Win ==
You win the battle against the goblins.
You find 100 gold in the mines.
~ Changegold(100)
#+100 Gold
->END

== Lose ==
You lose 5 citizens and 25 Materials.
~ Changetroops(-5)
~ Changematerials(-25)
#-5 troops & -25 materials
->END