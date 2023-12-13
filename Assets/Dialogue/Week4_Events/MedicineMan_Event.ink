EXTERNAL Changesilk(value)
EXTERNAL Changemorale(value)
EXTERNAL Changegold(value)
EXTERNAL Changecitizens(value)
VAR troopsAssigned = 50

-> Start

== Start ==
Will: Boss: "Hey Mayor, we got a new guest for business."
"This cloaked man with purple skin from God knows where wants to offer us a large quantity of silk and medicine for a cheap price. He claimed that his medicine and silk came from a blessed source very far away, and their combination can bring any kind of sick man back to life within a day."
"If you ask me, I’d say that he may look mysterious, but his deal is fishy. I’ve met plenty of fancy-dressed crooks when I was in the big city."

-> Choices

== Choices ==
 * [Accept his offer] -> Accept
 * [Reject his offer] -> Reject
 * [Fight the medicine man] -> Fight

== Accept ==
It turns out the medicine he offered are hard drugs that make the matters even worse after few people have taken them. 
While the drugs are not killing anyone, the patients show some minor symptoms that are certainly not helping
#+25 Silk, -5% Morale, -250 Gold
~ Changegold(-250)
~ Changesilk(25)
~ Changemorale(-5)
->END

== Reject ==
You turn down the offer due to your suspicion of it, and the cloaked man leaves without saying a word. 
However, at midnight, someone reports a village folk being missing, and the cloaked man was last seen talking with him. 
The reason he takes a sick man with him remains unclear.
#-1 Population
~ Changecitizens(-1)
->END   

== Fight ==
You turn down the offer due to your suspicion of him, and after he leaves, you gather some men and secretly follow him. 
Later he arrives at a house whose owner is ill, and upon hearing his attempt to seduce the owner with his medicine, you decide to confront him.
{troopsAssigned >= 10: ->Win | {troopsAssigned < 10: ->Lose}}

== Win ==
The defeated cloaked man drops some of his stuff and runs away. The drugs he left are useless, but the silk is useful.
#+10 Silk and +2% Morale
~ Changesilk(10)
~ Changemorale(2)
->END

== Lose ==
Without anyone getting in his way, the cloaked man eventually convinces the sick person to go with him, and his motive remains unclear.
#-1 Population and -2% Morale
~ Changecitizens(-1)
~ Changemorale(-2)
->END   