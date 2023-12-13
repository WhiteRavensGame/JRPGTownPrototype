EXTERNAL ChangeVillagerMorale(value, Name)
EXTERNAL ChangeBuildingProduction(value, Name)
EXTERNAL Changefood(value)

->START

== START ==
Monstrous thuds approach the town as a 100 foot tall giant marches in your direction.
What do you do?

->CHOICES

== CHOICES ==

 * [Attack him.] ->Attack
 * [Call up to him and insult him.] ->Insult
 * [Welcome him.] ->Welcome

== Attack ==
You gather your best hunters to shoot arrows at the giant, one arrow hits his eye. He yells out in pain and begins crying and runs off.
Roe Kimp meets with you and says “hey have you seen my cousin, he was supposed to arrive this morning”
# -10% Roe Morale, -2 Mining Production
~ ChangeVillagerMorale(-10, "Roe")
~ ChangeBuildingProduction(-2, "Mine")
->END

== Insult ==
You grab what Adelaine calls “the Say Further” and call up to him and say “we don’t like you very much” and you tell him to go away. He replies with “That makes me feel quite unpleasant, please be more careful with your words next time someone visits your town” and he walks away.
Roe Kimp meets with you and says “hey have you seen my cousin, he was supposed to arrive this morning”
# -5% Roe Morale -1 Mining Production
~ ChangeVillagerMorale(-5, "Roe")
~ ChangeBuildingProduction(-1, "Mine")
->END

== Welcome ==
You welcome him to your town and offer him as much beer you can get your hands on. He gladly accepts and says “If it isn’t too much trouble, I prefer tea for next time.”
Roe Kimp meets with you and notices his massive family member “Reginald! You made it, look at my home.” as runs over to give his leg a big hug.
# +10% Roe Morale, +1 Mining Production - 20 food
~ ChangeVillagerMorale(10, "Roe")
~ ChangeBuildingProduction(1, "Mine")
~ Changefood(-20)
->END