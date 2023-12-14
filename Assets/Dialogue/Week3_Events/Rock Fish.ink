EXTERNAL ChangeVillagerMorale(value, Name)
EXTERNAL Changematerials(value)
EXTERNAL Changefood(value)

->START

== START ==
#speaker: Oscar #portrait: Oscar
“Mayor, I just discovered a new, weird species of fish in the past few days. They are like normal fishes during the day but turn to rocks at night. I suggest we farm them for food storage since they’re good for preservation.”

#speaker: Roe #portrait: Roe
“Yo mayor! My man Oscar just found some magical fishes that turn to rocks at night. Those are not ordinary rocks. We should definitely farm them to boost the storage of materials!” 

#speaker: Lorraine #portrait: Lorraine
“Please don’t listen to those men! These fishes are clearly invasive species with unknown black magic cast into them. I’ve lived here my whole life and never seen such a creature. Ever since the Winter of the Dead Sun, weird creatures and phenomenon started to emerge one after another.”

#speaker: Narrator #portrait: Default
What do you do?

->CHOICES

== CHOICES ==

 * [Take Oscar’s advice.] ->Oscar
 * [Take Roe’s advice.] ->Roe
 * [Take Lorraine’s advice.] ->Lorraine

==Oscar==
#speaker: Narrator #portrait: Default
These fishes do last much longer than any other food, but their constant shifting between rock and meat renders them unsafe to consume. After all, nobody wants to have rocks in their stomach.
~ Changefood(-10)
~ ChangeVillagerMorale(5, "Oscar")
~ ChangeVillagerMorale(-10, "Lorraine")
# +5% Oscar morale, -10% Lorraine morale, -10 food
->END

== Roe ==
#speaker: Narrator #portrait: Default
These fishes do turn into fine rocks for crafting, but their constant shifting between rock and meat renders them unsuitable for crafting. The buildings and tools constructed with them just all turn to a battlefield of flesh (LIMBS).
~ Changematerials(-10)
~ ChangeVillagerMorale(5, "Roe")
~ ChangeVillagerMorale(-10, "Lorraine")
# +5% Roe morale, -5% Lorraine morale, -10% materials
->END

== Lorraine ==
#speaker: Narrator #portrait: Default
You also agree that the village should stay away from these strange creatures. Besides, the constant change of states renders them neither consumable nor useful.
~ ChangeVillagerMorale(-2, "Roe")
~ ChangeVillagerMorale(-2, "Oscar")
~ ChangeVillagerMorale(10, "Lorraine")
# +10% Lorraine morale, -2% Oscar morale, -2% Roe morale
->END
