EXTERNAL Changetroops(value)
EXTERNAL ChangeMiningProduction(value)
EXTERNAL ChangeFisheryProduction(value)

->START

== START ==
Magic Disk Dealer

Lorraine:
“Kid, there’s a real interesting and weird vendor in town, even weirder than Roe. It’s called ‘Disk Stop’ and its selling  an experience where you pick a colored disk and then watch it through goggles. The owner claims that it lets you peer into another dimension but anyone who falls for that is just an idiot. But you should still try it out since you’re in charge.”

->CHOICES

== CHOICES ==

 * [Red Disk.] ->RED_DISK
 * [White Disk.] ->WHITE_DISK
 * [Gray Disk.] ->Gray_Disk

== RED_DISK ==
In the red disk is a bloodied battlefield with numerous monstrous beasts roaming the ruins. You see 3 other people in the village try it after you and later you hear that they joined the guards. (Bloodborne 4)
~ Changetroops(3)
# +3 Troops
->END

== WHITE_DISK ==
In the white disk is a restaurant with one angry chef and a lot of annoying customers, yet the chef never stops cooking. You recommend the disk to the Fisherman who gains some cooking knowledge making food taste a little better. (Chef Strikes Back)
~ ChangeFisheryProduction(1)
# +1 Food production
->END

== Gray_Disk ==
In the gray disk is a gargantuan cave that endlessly sprawls out where everything seemed to be strangely square in shape but beautiful in design. You recommend the disk to the miner and he becomes even more enthused about his work. (Minecraft)
~ ChangeMiningProduction(1)
# +1 Mining Production
->END