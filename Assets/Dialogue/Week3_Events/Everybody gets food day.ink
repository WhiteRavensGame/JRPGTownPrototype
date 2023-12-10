EXTERNAL Changefood(value)
EXTERNAL Changemorale(value)
VAR troops = 10

->START

== START ==
Everybody gets Food Day!

Two Kobolds: Heya big man, we got some food for you if you’d like to partake. What’d ya say?

->CHOICES

== CHOICES ==

 * [Enough for me.] ->Me
 * [Enough for the village.] ->Village
 * [I hate food.] ->Hate

== Me ==
“Well isn’t that soooooo nice of you.”
~ Changefood(5)
~ Changemorale(-2)
->END

== Village ==
“That’s great! We want to give to everyone also!”
~ Changefood(25)
~ Changemorale(5)
->END

== Hate ==
# Starts at medium-difficulty fight with 2 kobolds
“YOU WANNA FIGHT PAL?”

* [Win] ->Win
* [Lose] ->Lose

== Win ==
{troops >= 10: ->Win}
“Alright you FOOD HATER, we’ll leave!”
~ Changefood(10)
->END

== Lose ==
{troops < 10: ->Lose}
“Serves you right you dumb FOOD HATER!”
~ Changefood(-10)
->END