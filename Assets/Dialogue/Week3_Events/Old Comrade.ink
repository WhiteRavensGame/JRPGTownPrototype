EXTERNAL ChangeVillagerMorale(value, Name)
EXTERNAL Changetroops(value)
VAR morale = 60

->START

== START ==
Old Comrade

The normally quiet Oscar comes to you spirited and says:
“An old comrade of mine is here today, so I’d like to take a day off and spend some time with him. He and, you know, Adelaine’s father, and a bunch of others, we spent most of our youth together, and at some point I lost contacts with all of them…Hopefully it wouldn’t be too troubling for you.”
After he leaves happily, what do you do?

->CHOICES

== CHOICES ==

 * [Keep an eye on his comrade.] ->KEEP_AN_EYE
 * [Leave his comrade be.] ->LEAVE_HIM
 * [Let Oscar know.] ->LET_OSCAR_KNOW
 # Need at least 60 morale

== KEEP_AN_EYE ==
You end up finding him at Adelaine’s place and he seems likely to tell her about her father, so you step in and stop him, and Adelaine is really upset with your sudden interruption
~ ChangeVillagerMorale(-5, "Adelaine")
# -5% Adelaine morale
->END

== LEAVE_HIM ==
He ends up telling Adelaine everything about her father. Oscar, upon knowing this, becomes very upset
~ ChangeVillagerMorale(-5, "Oscar")
// May have consequence on Adelaine’s ending
->END

== LET_OSCAR_KNOW ==
{morale < 60: ->CHOICES}
As you’re spying on him, you see him having conversations with different people in town, so you ask them what they were talking about, and they tell you that he was asking for Black Smith’s place. You then figure out his intention and tell Oscar about it, and the two of you stop him before he can reach Adelaine’s place.
~ ChangeVillagerMorale(5, "Oscar")
# +5% Oscar morale
->END