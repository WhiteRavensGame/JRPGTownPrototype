EXTERNAL ChangeBuildingProduction(value, Name)
EXTERNAL Changefood(value)
EXTERNAL Changegold(value)

VAR food = 10

->START

== START ==
#speaker: Adelaine #portrait: Adelaine
“Hey Mayor! I was talking to the lumber jacks and guess what they found! A sentient and talking tree! How cool is that?! I went on down and talked to it and it seems pretty cool and old. What should we do with it?”

->CHOICES

== CHOICES ==

 * [Talk to it and be friendly.] ->TALK_FRIENDLY
 * [Chop it down for potential riches.] ->CHOP
 * {food > 24} [Give it offerings.] ->OFFERINGS

== TALK_FRIENDLY ==
#speaker: Narrator #portrait: Default
The tree appreciates you being kind to it and in return makes the trees in the surrounding area grow faster, boosting the material gain.
~ ChangeBuildingProduction(2, "Smithy")
//+2 Material Production
->DONE

== CHOP ==
#speaker: Narrator #portrait: Default
You order the tree to be chopped down and collect the wood before selling it to a wealthy merchant.
~ Changegold(500)
// +500 Gold
->DONE

== OFFERINGS ==
#speaker: Narrator #portrait: Default
You give offerings of food to the tree and in return it helps you grow trees nearby to collect.
~ Changefood(-25)
~ ChangeBuildingProduction(2, "Smithy")
//-25 Food per week, +2 Material Production
->DONE