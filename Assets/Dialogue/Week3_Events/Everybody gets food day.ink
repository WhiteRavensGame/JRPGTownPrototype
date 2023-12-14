EXTERNAL Changefood(value)
EXTERNAL Changemorale(value)
VAR troops = 50

->START

== START ==
#speaker: Narrator #portrait: Default
Two kobolds wander into town throwing slices of bread at people.
#speaker: Kobold #portrait: Default
"Heya big man, we got some food for you if you’d like to partake. What’d ya say?"

->CHOICES

== CHOICES ==

 * [Enough for me.] ->Me
 * [Enough for the village.] ->Village
 * [I hate food.] ->Hate

== Me ==
#speaker: Kobold #portrait: Default
“Well isn’t that soooooo nice of you.”
~ Changefood(5)
~ Changemorale(-2)
->END

== Village ==
#speaker: Kobold #portrait: Default
“That’s great! We want to give some to everyone also!”
~ Changefood(25)
~ Changemorale(5)
->END

== Hate ==
#speaker: Kobold #portrait: Default
“YOU WANNA FIGHT PAL?”
# Starts at medium-difficulty fight with 2 kobolds

{troops >= 15: ->Win | {troops < 15: ->Lose}}

== Win ==
#speaker: Kobold #portrait: Default
“Alright you FOOD HATER, we’ll leave!”
~ Changefood(10)
->END

== Lose ==
#speaker: Kobold #portrait: Default
“Serves you right you dumb FOOD HATER!”
~ Changefood(-10)
->END