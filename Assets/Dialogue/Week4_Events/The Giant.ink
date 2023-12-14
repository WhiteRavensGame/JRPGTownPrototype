EXTERNAL ChangeVillagerMorale(value, Name)
EXTERNAL ChangeBuildingProduction(value, Name)
EXTERNAL Changefood(value)

->START

== START ==
#speaker: Narrator #portrait: Default
Monstrous thuds approach the town as a hundred foot tall giant marches in your direction.
What do you do?

->CHOICES

== CHOICES ==

 * [Attack him.] ->Attack
 * [Call up to him and insult him.] ->Insult
 * [Welcome him.] ->Welcome

== Attack ==
#speaker: Narrator #portrait: Default
You gather your best hunters to shoot arrows at the giant, one arrow hits his eye. He yells out in pain and begins crying and runs off.

Roe Kimp meets with you and says: 

#speaker: Roe #portrait: Roe
“hey have you seen my cousin, he was supposed to arrive this morning.”

~ ChangeVillagerMorale(-10, "Roe")
~ ChangeBuildingProduction(-2, "Mine")
->END

== Insult ==
#speaker: Narrator #portrait: Default
You grab what Adelaine calls “the Say Further” and call up to him and say “we don’t like you very much” and you tell him to go away. He replies with “That makes me feel quite unpleasant, please be more careful with your words next time someone visits your town” and he walks away.

Roe Kimp meets with you and says: 
#speaker: Roe #portrait: Roe
“hey have you seen my cousin, he was supposed to arrive this morning.”

~ ChangeVillagerMorale(-5, "Roe")
~ ChangeBuildingProduction(-1, "Mine")
->END

== Welcome ==
#speaker: Narrator #portrait: Narrator
You welcome him to your town and offer him as much beer you can get your hands on. He gladly accepts and says “If it isn’t too much trouble, I prefer tea for next time.”
Roe Kimp meets with you and notices his massive family member. 
#speaker: Roe #portrait: Roe
“Reginald! You made it, look at my home.” as runs over to give his leg a big hug.

~ ChangeVillagerMorale(10, "Roe")
~ ChangeBuildingProduction(1, "Mine")
~ Changefood(-20)
->END