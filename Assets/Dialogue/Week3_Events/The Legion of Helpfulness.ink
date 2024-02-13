EXTERNAL Changematerials(value)
EXTERNAL Changesilk(value)
EXTERNAL Changemorale(value)
EXTERNAL Changetroops(value)

VAR material = 10
VAR silk = 10

->START

== START ==
#speaker: Oscar #portrait: Oscar
I found this legion of demons stealing my fish a while ago, but they said they’re trying to be good now. Apparently Hell ain’t all that is cracked up to be. They’re asking if they can help us with anything for free.

->CHOICES

== CHOICES ==

 * {material > 9} [Ask them to build a house.] ->Build
 * [Get them to clean townsquare.] ->Clean
 * {silk > 9} [Teach them about being a hero.] ->Teach
 
== Build ==
#speaker: Narrator #portrait: Default
They sweep up and decorate townsquare, and the citizens think it looks lovely. The demons thank you for letting them help and the scamper off into the woods.
~ Changematerials(-10)
~ Changetroops(4)
->END

== Clean ==
#speaker: Narrator #portrait: Default
They sweep up and decorate townsquare, and the citizens think it looks lovely. The demons thank you for letting them help and the scamper off into the woods.
~ Changemorale(10)
->END

== Teach ==
#speaker: Narrator #portrait: Default
You give them a valiant speech about being a hero and how to truly do good in the world. They cry and need an incredible amount of cloth to soak it up as their tears are acid, They pledge their lives to you.
~ Changesilk(-10)
~ Changetroops(4)
->END