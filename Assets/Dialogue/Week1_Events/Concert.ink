
EXTERNAL Changesilk(value)
EXTERNAL Changematerials(value)
EXTERNAL Changefood(value)
EXTERNAL Changemorale(value)

->START

== START ==

A bard “Wymm Hasslefire” shows up to perform (uses most of your starter resources but significantly boosts morale).
#speaker: Lorraine  #portrait: Lorraine
There’s an elf making some noise in the town square, he’s putting up flyers and screaming that there must be a show! The flyer says Wymm Hasslefire, the world-famous bard wants to put a concert on. 
What do you want to do?

->CHOICES

== CHOICES ==

 * [Build a stage for Wymm.] ->Help
 * [Tell Wymm to Leave.] ->Leave
 * [Let him perform in the Inn.] ->Inn

== Help ==
You tell Wymm that he can perform, and you begin gathering resources to set up a stage. He performs a few days later giving your town a magical night to remember.
~ Changematerials(-5)
~ Changemorale(25)
->END

== Leave ==
You realize you don’t have a stage, and it would cost too much to build one. Unfortunately, you have to tell him to leave.
~ Changemorale(-5)
->END

== Inn ==
You get him to perform in the Inn. Unfortunately, it’s not big enough for the whole town, but the people who went had a lot of fun.
~ Changefood(-5)
~ Changesilk(-5)
~ Changemorale(10)
->END