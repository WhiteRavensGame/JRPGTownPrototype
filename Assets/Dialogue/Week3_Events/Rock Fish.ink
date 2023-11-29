EXTERNAL ChangeOscarMorale(value)
EXTERNAL ChangeRoeMorale(value)
EXTERNAL ChangeLorraineMorale(value)
EXTERNAL Changematerials(value)
EXTERNAL Changefood(value)

->START

== START ==
Rock Fish

Oscar: “Mayor, I just discovered a new, weird species of fish in the past few days. They are like normal fishes during the day but turn to rocks at night. I suggest we farm them for food storage since they’re good for preservation.”

Roe: “Yo mayor! My man Oscar just found some magical fishes that turn to rocks at night. Those are not ordinary rocks. We should definitely farm them to boost the storage of materials!” 

Lorraine: “Please don’t listen to those men! These fishes are clearly invasive species with unknown black magic cast into them. I’ve lived here my whole life and never seen such a creature. Ever since the Winter of the Dead Sun, weird creatures and phenomenon started to emerge one after another.”

What do you do?

->CHOICES

== CHOICES ==

 * [Take Oscar’s advice.] ->Oscar
 * [Take Roe’s advice.] ->Roe
 * [Take Lorraine’s advice.] ->Lorraine

==Oscar==
These fishes do last much longer than any other food, but their constant shifting between rock and meat renders them unsafe to consume. After all, nobody wants to have rocks in their stomach.
~ Changefood(-10)
~ ChangeOscarMorale(5)
~ ChangeLorraineMorale(-10)
# +5% Oscar morale, -10% Lorraine morale, -10 food
->END

== Roe ==
These fishes do turn into fine rocks for crafting, but their constant shifting between rock and meat renders them unsuitable for crafting. The buildings and tools constructed with them just all turn to the battlefield of LIMBS.
~ Changematerials(-10)
~ ChangeRoeMorale(5)
~ ChangeLorraineMorale(-5)
# +5% Roe morale, -5% Lorraine morale, -10% materials
->END

== Lorraine ==
You also agree that the village should stay away from these strange creatures. Besides, the constant change of states renders them neither consumable nor useful.
~ ChangeRoeMorale(-2)
~ ChangeOscarMorale(-2)
~ ChangeLorraineMorale(10)
# +10% Lorraine morale, -2% Oscar morale, -2% Roe morale
->END
