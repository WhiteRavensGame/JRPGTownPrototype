EXTERNAL Changefood(value)
EXTERNAL Changematerials(value)
EXTERNAL Changesilk(value)
EXTERNAL Changetroops(value)

#speaker: Oscar #portrait: Oscar
“Sir, due to all the fishing, some river seagulls have been harassing the fisherman and stealing some food, how do you want to deal with them?”

* [Fight seagulls (Easy Battle)]
if Win:
“Sir it was a hard-fought battle as they kept swooping down from the sky to attack us but we won in the end.”
~ Changefood(10)
Lose
“Sir, unfortunately, the battle ended in a failure for us and the birds stole some more food.”
~ Changefood(-10)


* [Lure seagulls away]
“Sir, the seagulls followed the trail of food away but they just came right back, we have to just wait until they leave soon”
~ Changefood(-10)
#-10 Food, -1 Fishing Production for 1 week.

* [Train archers to shoot them]
“Sir, the archers you trained were able to get rid of the seagulls and make the rest fly away. Good choice.”
~ Changematerials(-10)
~ Changesilk (-10)
~ Changetroops(4)
~ Changefood(10)
#-10 Materials, -10 Silk, +4 Troops, +10 Food
