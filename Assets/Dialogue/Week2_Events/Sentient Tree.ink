EXTERNAL ChangeSmithyProduction(value)
EXTERNAL Changegold(value)
EXTERNAL ChangeFisheryProduction(value)

->START

== START ==
Sentient Tree

Adelaine: “Hey Mayor! I was talking to the lumber jacks and guess what they found! A sentient and talking tree! How cool is that?! I went on down and talked to it and it seems pretty cool and old. What should we do with it?”

->CHOICES

== CHOICES ==

 * [Talk to it and be friendly.] ->TALK_FRIENDLY
 * [Chop it down for potential riches.] ->CHOP
 * [Give it offerings.] ->OFFERINGS

== TALK_FRIENDLY ==
The tree appreciates you being kind to it and in return makes the trees in the surrounding area grow faster, boosting the material gain.
~ ChangeSmithyProduction(2)
# +2 Material Production
->END

== CHOP ==
You order the tree to be chopped down and collect the wood before selling it to a wealthy merchant for 500 Gold.
~ Changegold(500)
# +500 Gold
->END

== OFFERINGS ==
You give offerings of food to the tree and in return it helps you grow trees nearby to collect.
~ ChangeFisheryProduction(-25)
~ ChangeSmithyProduction(2)
#-25 Food per week, +2 Material Production
->END